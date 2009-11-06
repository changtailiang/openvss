// zyhz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gjwj	
// otgj	 By downloading, copying, installing or using the software you agree to this license.
// ugfk	 If you do not agree to this license, do not download, install,
// pgng	 copy or use the software.
// qxvb	
// zcqz	                          License Agreement
// jplb	         For OpenVss - Open Source Video Surveillance System
// etdw	
// wugt	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// merx	
// sbwj	Third party copyrights are property of their respective owners.
// qbos	
// feyc	Redistribution and use in source and binary forms, with or without modification,
// cgae	are permitted provided that the following conditions are met:
// swaz	
// heea	  * Redistribution's of source code must retain the above copyright notice,
// dinu	    this list of conditions and the following disclaimer.
// ztum	
// fyjy	  * Redistribution's in binary form must reproduce the above copyright notice,
// fhih	    this list of conditions and the following disclaimer in the documentation
// atva	    and/or other materials provided with the distribution.
// vatq	
// ucap	  * Neither the name of the copyright holders nor the names of its contributors 
// erpn	    may not be used to endorse or promote products derived from this software 
// wvfh	    without specific prior written permission.
// ntsm	
// klwd	This software is provided by the copyright holders and contributors "as is" and
// xbyl	any express or implied warranties, including, but not limited to, the implied
// oszo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jefc	In no event shall the Prince of Songkla University or contributors be liable 
// oxax	for any direct, indirect, incidental, special, exemplary, or consequential damages
// sehn	(including, but not limited to, procurement of substitute goods or services;
// ivbk	loss of use, data, or profits; or business interruption) however caused
// baug	and on any theory of liability, whether in contract, strict liability,
// ajqj	or tort (including negligence or otherwise) arising in any way out of
// epts	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Jpeg
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Threading;
	using System.Net;

    using System.Reflection;
    using Vs.Core.Provider;
    using Vs.Core.Image;

	/// <summary>
	/// JPEGSource - JPEG downloader
	/// </summary>
	public class JPEGSource : VsICoreProvider
	{
		private string	source;
        private string  camera;
		private string	login = null;
		private string	password = null;
		private object	userData = null;
		private int		framesReceived;
		private int		bytesReceived;
		private bool	useSeparateConnectionGroup = false;
		private bool	preventCaching = false;
		private int		frameInterval = 0;		// frame interval in miliseconds

		private const int	bufSize = 512 * 1024;	// buffer size
		private const int	readSize = 1024;		// portion size to read

		private Thread	thread = null;
		private ManualResetEvent stopEvent = null;

		// new frame event
		public event VsImageEventHandler FrameOut;

		// SeparateConnectioGroup property
		// indicates to open WebRequest in separate connection group
		public bool	SeparateConnectionGroup
		{
			get { return useSeparateConnectionGroup; }
			set { useSeparateConnectionGroup = value; }
		}
       
		// PreventCaching property
		// If the property is set to true, we are trying to prevent caching
		// appneding fake parameter to URL. It's needed is client is behind
		// proxy server.
		public bool	PreventCaching
		{
			get { return preventCaching; }
			set { preventCaching = value; }
		}
		// FrameInterval property - interval between frames
		// If the property is set 100, than the source will produce 10 frames
		// per second if it possible
		public int FrameInterval
		{
			get { return frameInterval; }
			set { frameInterval = value; }
		}
		// VideoSource property
		public virtual string VideoSource
		{
			get { return source; }
			set { source = value; }
		}

		// Login property
		public string Login
		{
			get { return login; }
			set { login = value; }
		}
		// Password property
		public string Password
		{
			get { return password; }
			set { password = value; }
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
			get
			{
				int bytes = bytesReceived;
				bytesReceived = 0;
				return bytes;
			}
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
		public JPEGSource()
		{
		}

		// Start work
		public void Start()
		{
			if (thread == null)
			{
				framesReceived = 0;
				bytesReceived = 0;

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
			byte[]			buffer = new byte[bufSize];	// buffer to read stream
			HttpWebRequest	req = null;
			WebResponse		resp = null;
			Stream			stream = null;
			Random			rnd = new Random((int) DateTime.Now.Ticks);
			DateTime		start;
			TimeSpan		span;

			while (true)
			{
				int	read, total = 0;

				try
				{
					start = DateTime.Now;

					// create request
					if (!preventCaching)
					{
						req = (HttpWebRequest) WebRequest.Create(source);
					}
					else
					{
						req = (HttpWebRequest) WebRequest.Create(source + ((source.IndexOf('?') == -1) ? '?' : '&') + "fake=" + rnd.Next().ToString());
					}
                    
					// set login and password
					if ((login != null) && (password != null) && (login != ""))
						req.Credentials = new NetworkCredential(login, password);
					// set connection group name
					if (useSeparateConnectionGroup)
						req.ConnectionGroupName = GetHashCode().ToString();
					// get response
					resp = req.GetResponse();

					// get response stream
					stream = resp.GetResponseStream();

					// loop
					while (!stopEvent.WaitOne(0, true))
					{
						// check total read
						if (total > bufSize - readSize)
						{
							total = 0;
						}

						// read next portion from stream
						if ((read = stream.Read(buffer, total, readSize)) == 0)
							break;

						total += read;

						// increment received bytes counter
						bytesReceived += read;
					}

					if (!stopEvent.WaitOne(0, true))
					{
						// increment frames counter
						framesReceived++;

						// image at stop
                        if (FrameOut != null)
						{
							Bitmap	bmp = (Bitmap) Bitmap.FromStream(new MemoryStream(buffer, 0, total));
							// notify client
                            VsImage img = new VsImage(bmp);
                            FrameOut(this, new VsImageEventArgs(img));
							// release the image
                            img.Dispose();
                            img = null;
						}
					}

					// wait for a while ?
					if (frameInterval > 0)
					{
						// times span
						span = DateTime.Now.Subtract(start);
						// miliseconds to sleep
						int msec = frameInterval - (int) span.TotalMilliseconds;

						while ((msec > 0) && (stopEvent.WaitOne(0, true) == false))
						{
							// sleeping ...
							Thread.Sleep((msec < 100) ? msec : 100);
							msec -= 100;
						}
					}
				}
				catch (WebException ex)
				{
					System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
					// wait for a while before the next try
					Thread.Sleep(250);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
				}
				finally
				{
					// abort request
					if (req != null)
					{
						req.Abort();
						req = null;
					}
					// close response stream
					if (stream != null)
					{
						stream.Close();
						stream = null;
					}
					// close response
					if (resp != null)
					{
						resp.Close();
						resp = null;
					}
				}

				// need to stop ?
				if (stopEvent.WaitOne(0, true))
					break;
			}
		}

        public static bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Control Cameras Methods
        /// </summary>
        public void ExecuteCommand(String controlCmd)
        {
            HttpWebRequest req = null;
            WebResponse resp = null;
            Stream stream = null;
            DateTime start;
            try
            {
                start = DateTime.Now;

                req = (HttpWebRequest)WebRequest.Create(controlCmd);

                // set login and password
                if ((this.Login != null) && (this.Password != null) && (this.Login != ""))
                    req.Credentials = new NetworkCredential(this.Login, this.Password);
                // set connection group name
                req.ConnectionGroupName = GetHashCode().ToString();

                // get response
                resp = req.GetResponse();

                // get response stream
                stream = resp.GetResponseStream();
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                // wait for a while before the next try
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
            }
            finally
            {
                // abort request
                if (req != null)
                {
                    req.Abort();
                    req = null;
                }
                // close response stream
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
                // close response
                if (resp != null)
                {
                    resp.Close();
                    resp = null;
                }
            }
        }

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
