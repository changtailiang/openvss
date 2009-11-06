// ldty	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ltce	
// rpwf	 By downloading, copying, installing or using the software you agree to this license.
// owit	 If you do not agree to this license, do not download, install,
// opdc	 copy or use the software.
// ehwp	
// ypww	                          License Agreement
// dxgv	         For OpenVss - Open Source Video Surveillance System
// gdcb	
// cuam	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lhuk	
// zkkv	Third party copyrights are property of their respective owners.
// pang	
// wqoe	Redistribution and use in source and binary forms, with or without modification,
// hdav	are permitted provided that the following conditions are met:
// wgbu	
// ibyk	  * Redistribution's of source code must retain the above copyright notice,
// ugqu	    this list of conditions and the following disclaimer.
// pqrw	
// mlqn	  * Redistribution's in binary form must reproduce the above copyright notice,
// ebgc	    this list of conditions and the following disclaimer in the documentation
// jayq	    and/or other materials provided with the distribution.
// pyuy	
// tepe	  * Neither the name of the copyright holders nor the names of its contributors 
// fzcx	    may not be used to endorse or promote products derived from this software 
// mzai	    without specific prior written permission.
// jsqg	
// zrrv	This software is provided by the copyright holders and contributors "as is" and
// mmqv	any express or implied warranties, including, but not limited to, the implied
// zyki	warranties of merchantability and fitness for a particular purpose are disclaimed.
// divw	In no event shall the Prince of Songkla University or contributors be liable 
// mrak	for any direct, indirect, incidental, special, exemplary, or consequential damages
// amrn	(including, but not limited to, procurement of substitute goods or services;
// jtbf	loss of use, data, or profits; or business interruption) however caused
// aytr	and on any theory of liability, whether in contract, strict liability,
// jsrx	or tort (including negligence or otherwise) arising in any way out of
// gymh	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Stream
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;
	using System.Threading;
	using System.Runtime.InteropServices;
	using System.Net;

    using Vs.Core.Provider;
	using Vs.Provider.Dshow;
	using Vs.Provider.Dshow.Core;
    using Vs.Core.Image;

	/// <summary>
	/// VideoStream - stream downloader
	/// </summary>
	public class VideoStream : VsICoreProvider
	{
		private string	source;
		private object	userData = null;
		private int		framesReceived;

		private Thread	thread = null;
		private ManualResetEvent stopEvent = null;

		// new frame event
		public event VsImageEventHandler FrameOut;

		// VideoSource property
		public virtual string VideoSource
		{
			get { return source; }
			set { source = value; }
		}
		// Login property
		public string Login
		{
			get { return null; }
			set { }
		}
		// Password property
		public string Password
		{
			get { return null; }
			set {  }
		}
		// FramesReceived property
		public int FramesReceived
		{
			get
			{
				int frames = framesReceived;
				framesReceived = 0;
				return frames;
			}
		}
		// BytesReceived property
		public int BytesReceived
		{
			get { return 0; }
		}
		// UserData property
		public object UserData
		{
			get { return userData; }
			set { userData = value; }
		}
		// Get state of the video source thread
		public bool Running
		{
			get
			{
				if (thread != null)
				{
					if (thread.Join(0) == false)
						return true;

					// the thread is not running, so free resources
					Free();
				}
				return false;
			}
		}


		// Constructor
		public VideoStream()
		{
		}

		// Start work
		public void Start()
		{
			if (thread == null)
			{
				framesReceived = 0;

				// create events
				stopEvent	= new ManualResetEvent(false);
				
				// create and start new thread
				thread = new Thread(new ThreadStart(WorkerThread));
				thread.Name = source;
                thread.IsBackground = true;
				thread.Start();
			}
		}

		// Signal thread to stop work
		public void SignalToStop()
		{
			// stop thread
			if (thread != null)
			{
				// signal to stop
				stopEvent.Set();
			}
		}

		// Wait for thread stop
		public void WaitForStop()
		{
			if (thread != null)
			{
				// wait for thread stop
				thread.Join();

				Free();
			}
		}

		// Abort thread
		public void Stop()
		{
			if (this.Running)
			{
				thread.Abort();
				WaitForStop();
			}
		}

		// Free resources
		private void Free()
		{
			thread = null;

			// release events
			stopEvent.Close();
			stopEvent = null;
		}

		// Thread entry point
		public void WorkerThread()
		{
			bool	failed = false;

			// grabber
			Grabber	grabber = new Grabber(this);

			// objects
			object	graphObj = null;
			object	sourceObj = null;
			object	grabberObj = null;

			// interfaces
			IGraphBuilder	graph = null;
			IBaseFilter		sourceBase = null;
			IBaseFilter		grabberBase = null;
			ISampleGrabber	sg = null;
			IFileSourceFilter	fileSource = null;
			IMediaControl	mc = null;
			IMediaEventEx	mediaEvent = null;

			int	code, param1, param2;

			while ((!failed) && (!stopEvent.WaitOne(0, true)))
			{
				try
				{
					// Get type for filter graph
					Type srvType = Type.GetTypeFromCLSID(Clsid.FilterGraph);
					if (srvType == null)
						throw new ApplicationException("Failed creating filter graph");

					// create filter graph
					graphObj = Activator.CreateInstance(srvType);
					graph = (IGraphBuilder) graphObj;

					// Get type for windows media source filter
					srvType = Type.GetTypeFromCLSID(Clsid.WindowsMediaSource);
					if (srvType == null)
						throw new ApplicationException("Failed creating WM source");

					// create windows media source filter
					sourceObj = Activator.CreateInstance(srvType);
					sourceBase = (IBaseFilter) sourceObj;

					// Get type for sample grabber
					srvType = Type.GetTypeFromCLSID(Clsid.SampleGrabber);
					if (srvType == null)
						throw new ApplicationException("Failed creating sample grabber");

					// create sample grabber
					grabberObj = Activator.CreateInstance(srvType);
					sg = (ISampleGrabber) grabberObj;
					grabberBase = (IBaseFilter) grabberObj;

					// add source filter to graph
					graph.AddFilter(sourceBase, "source");
					graph.AddFilter(grabberBase, "grabber");

					// set media type
					AMMediaType mt = new AMMediaType();
					mt.majorType = MediaType.Video;
					mt.subType = MediaSubType.RGB24;
					sg.SetMediaType(mt);

					// load file
					fileSource = (IFileSourceFilter) sourceObj;
					fileSource.Load(this.source, null);

					// connect pins
					if (graph.Connect(DSTools.GetOutPin(sourceBase, 0), DSTools.GetInPin(grabberBase, 0)) < 0)
						throw new ApplicationException("Failed connecting filters");

					// get media type
					if (sg.GetConnectedMediaType(mt) == 0)
					{
						VideoInfoHeader vih = (VideoInfoHeader) Marshal.PtrToStructure(mt.formatPtr, typeof(VideoInfoHeader));

						grabber.Width = vih.BmiHeader.Width;
						grabber.Height = vih.BmiHeader.Height;
						mt.Dispose();
					}

					// render
					graph.Render(DSTools.GetOutPin(grabberBase, 0));

					//
					sg.SetBufferSamples(false);
					sg.SetOneShot(false);
					sg.SetCallback(grabber, 1);

					// window
					IVideoWindow win = (IVideoWindow) graphObj;
					win.put_AutoShow(false);
					win = null;

					// get events interface
					mediaEvent = (IMediaEventEx) graphObj;

					// get media control
					mc = (IMediaControl) graphObj;

					// run
					mc.Run();

					while (!stopEvent.WaitOne(0, true))
					{
						Thread.Sleep(100);

						// get an event
						if (mediaEvent.GetEvent(out code, out param1, out param2, 0) == 0)
						{
							// release params
							mediaEvent.FreeEventParams(code, param1, param2);

							//
							if (code == (int) EventCode.Complete)
							{
								break;
							}
						}
					}

					mc.StopWhenReady();
				}
					// catch any exceptions
				catch (Exception e)
				{
					System.Diagnostics.Debug.WriteLine("----: " + e.Message);
					failed = true;
				}
					// finalization block
				finally
				{
					// release all objects
					mediaEvent = null;
					mc = null;
					fileSource = null;
					graph = null;
					sourceBase = null;
					grabberBase = null;
					sg = null;

					if (graphObj != null)
					{
						Marshal.ReleaseComObject(graphObj);
						graphObj = null;
					}
					if (sourceObj != null)
					{
						Marshal.ReleaseComObject(sourceObj);
						sourceObj = null;
					}
					if (grabberObj != null)
					{
						Marshal.ReleaseComObject(grabberObj);
						grabberObj = null;
					}
				}
			}
		}

		// new frame
		protected void OnNewFrame(Bitmap image)
		{
			framesReceived++;
            if (FrameOut != null)
            {
                VsImage img = new VsImage(image);

                FrameOut(this, new VsImageEventArgs(img));

                img.Dispose();
                img = null;
            }
		}

		// Grabber
		private class Grabber : ISampleGrabberCB
		{
			private VideoStream parent;
			private int width, height;

			// Width property
			public int Width
			{
				get { return width; }
				set { width = value; }
			}
			// Height property
			public int Height
			{
				get { return height; }
				set { height = value; }
			}

			// Constructor
			public Grabber(VideoStream parent)
			{
				this.parent = parent;
			}

			//
			public int SampleCB(double SampleTime, IntPtr pSample)
			{
				return 0;
			}

			// Callback method that receives a pointer to the sample buffer
			public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
			{
				// create new image
				System.Drawing.Bitmap img = new Bitmap(width, height, PixelFormat.Format24bppRgb);

				// lock bitmap data
				BitmapData	bmData = img.LockBits(
					new Rectangle(0, 0, width, height),
					ImageLockMode.ReadWrite,
					PixelFormat.Format24bppRgb);

				// copy image data
				int srcStride = bmData.Stride;
				int dstStride = bmData.Stride;

				int dst = bmData.Scan0.ToInt32() + dstStride * (height - 1);
				int src = pBuffer.ToInt32();

				for (int y = 0; y < height; y++)
				{
					Win32.memcpy(dst, src, srcStride);
					dst -= dstStride;
					src += srcStride;
				}

				// unlock bitmap data
				img.UnlockBits(bmData);

				// notify parent
				parent.OnNewFrame(img);

				// release the image
				img.Dispose();

				return 0;
			}
		}


        /// <summary>
        /// Control Cameras Methods
        /// </summary>
        public virtual bool IsPanTiltZoom()
        {
            return false;
        }

        public virtual void GoHome()
        {
        }

        public virtual void PanLeft()
        {
        }

        public virtual void PanRight()
        {
        }

        public virtual void TiltUp()
        {
        }

        public virtual void TiltDown()
        {
        }

        public virtual void ZoomIn()
        {
        }

        public virtual void ZoomOut()
        {
        }

        public virtual void ZoomAt(int factor)
        {
        }

        public virtual void PanTilt(int x, int y)
        {
        }
	}
}
