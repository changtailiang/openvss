// xdkr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uhrk	
// frzg	 By downloading, copying, installing or using the software you agree to this license.
// tlwx	 If you do not agree to this license, do not download, install,
// zzrn	 copy or use the software.
// qbdh	
// aito	                          License Agreement
// zrue	         For OpenVss - Open Source Video Surveillance System
// nnfd	
// ldqh	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hcaj	
// ublr	Third party copyrights are property of their respective owners.
// fzdj	
// oyww	Redistribution and use in source and binary forms, with or without modification,
// zcrl	are permitted provided that the following conditions are met:
// oclo	
// xvtg	  * Redistribution's of source code must retain the above copyright notice,
// ftmv	    this list of conditions and the following disclaimer.
// ikgo	
// btny	  * Redistribution's in binary form must reproduce the above copyright notice,
// xbja	    this list of conditions and the following disclaimer in the documentation
// nlpo	    and/or other materials provided with the distribution.
// qjdi	
// mfse	  * Neither the name of the copyright holders nor the names of its contributors 
// rllz	    may not be used to endorse or promote products derived from this software 
// hfmm	    without specific prior written permission.
// niad	
// siug	This software is provided by the copyright holders and contributors "as is" and
// psnn	any express or implied warranties, including, but not limited to, the implied
// tkam	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ffpw	In no event shall the Prince of Songkla University or contributors be liable 
// pdid	for any direct, indirect, incidental, special, exemplary, or consequential damages
// scwp	(including, but not limited to, procurement of substitute goods or services;
// inrs	loss of use, data, or profits; or business interruption) however caused
// pwne	and on any theory of liability, whether in contract, strict liability,
// kmwi	or tort (including negligence or otherwise) arising in any way out of
// oxsu	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Multisource
{
	using System;
	using System.Collections;
    using System.Net;
    using System.IO;
    using System.Threading;
    using Vs.Core.Provider;
    using Vs.Provider.Jpeg;
    using Vs.Provider.Mjpeg;
    using Vs.Core.Image;

	/// <summary>
	/// MultimodeVideoSource - abstract class for video sources, which support
	/// multiple working mode
	/// </summary>
	public abstract class MultimodeVideoSource : VsICoreProvider
	{
		protected VsICoreProvider	videoSource;
		protected StreamType	streamType;
		private ArrayList		delegates = new ArrayList();
        private String          controlCommand;
        private Thread thread = null;
        private ManualResetEvent stopEvent = null;
        private ManualResetEvent execEvent = null;

        private bool useSeparateConnectionGroup = false;
        private bool preventCaching = true;

		// New frame event
		public event VsImageEventHandler FrameOut
		{
			add
			{
				videoSource.FrameOut += value;
				delegates.Add((object) value);
			}
			remove
			{
				videoSource.FrameOut -= value;
				delegates.Remove((object) value);
			}
		}

        // SeparateConnectioGroup property
        // indicates to open WebRequest in separate connection group
        public bool SeparateConnectionGroup
        {
            get { return useSeparateConnectionGroup; }
            set { useSeparateConnectionGroup = value; }
        }

        // PreventCaching property
        // If the property is set to true, we are trying to prevent caching
        // appneding fake parameter to URL. It's needed is client is behind
        // proxy server.
        public bool PreventCaching
        {
            get { return preventCaching; }
            set { preventCaching = value; }
        }

		// Constructor
		public MultimodeVideoSource()
		{
		}

		// StreamType property
		public virtual StreamType StreamType
		{
			get { return streamType; }
			set
			{
				// update stream type if video source is not running
				if ((streamType != value) && (!videoSource.Running))
				{
					streamType = value;
					
					// save credentials and user data
					object	userData = videoSource.UserData;
					string	login = videoSource.Login;
					string	password = videoSource.Password;

					// create new base video source
					switch (streamType)
					{
						case StreamType.Jpeg:
							videoSource = new JPEGSource();
							break;
						case StreamType.MJpeg:
							videoSource = new MJPEGSource();
							break;
					}

					// set credentials and user data back to the new source
					videoSource.Login		= login;
					videoSource.Password	= password;
					videoSource.UserData	= userData;

					// add delegates to FrameOut event
					foreach (object handler in delegates)
						videoSource.FrameOut += (VsImageEventHandler) handler;

					UpdateVideoSource();
				}
			}
		}

		// Video source property
		public abstract string VideoSource
		{
			get;
			set;
		}

		// Login property
		public string Login
		{
			get { return videoSource.Login; }
			set { videoSource.Login = value; }
		}

		// Password property
		public string Password
		{
			get { return videoSource.Password; }
			set { videoSource.Password = value; }
		}

		// FramesReceived property
		public int FramesReceived
		{
			get { return videoSource.FramesReceived; }
		}

		// BytesReceived property
		public int BytesReceived
		{
			get { return videoSource.BytesReceived; }
		}

		// UserData property
		public object UserData
		{
			get { return videoSource.UserData; }
			set { videoSource.UserData = value; }
		}

		// Get state of video source
		public bool Running
		{
			get 
            {
                bool bVideo = videoSource.Running;
                bool bColtrol = false;
                if (thread != null)
                {
                    if (thread.Join(0) == false)
                        bColtrol=true;
                    else
                        // the thread is not running, so free resources
                        Free();
                }
                else bColtrol = false;

                if (bVideo || bColtrol) return true;
                else return false;
            }
		}

		// Start receiving video frames
		public void Start()
		{
			videoSource.Start();

            if (thread == null)
            {
                // create events
                stopEvent = new ManualResetEvent(false);
                execEvent = new ManualResetEvent(false);

                // create and start new thread
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Name = this.controlCommand;
                thread.IsBackground = true;
                thread.Start();

                JPEGSource.SetAllowUnsafeHeaderParsing20();
            }
		}

		// Stop receiving video frames
		public void SignalToStop()
		{
			videoSource.SignalToStop();

            // stop thread
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
                execEvent.Set();
            }
		}

		// Wait for stop
		public void WaitForStop()
		{
			videoSource.WaitForStop();

            if (thread != null)
            {
                // wait for thread stop
                thread.Join();

                Free();
            }
		}

		// Stop work
		public void Stop()
		{
            videoSource.Stop();

            if (this.Running)
            {
                thread.Abort();
                WaitForStop();
            }

		}

		// Update video source
		protected abstract void UpdateVideoSource();


        /// <summary>
        /// Control Cameras Methods
        /// </summary>

        public void ExecuteCommand(String controlCmd)
        {
            controlCommand = controlCmd;
            execEvent.Set();
        }

        // Free resources
        private void Free()
        {
            thread = null;

            // release events
            stopEvent.Close();
            stopEvent = null;

            execEvent.Close();
            execEvent = null;
        }

        // Thread entry point
        public void WorkerThread()
        {
            HttpWebRequest req = null;
            WebResponse resp = null;
            Random rnd = new Random((int)DateTime.Now.Ticks);

            while (true)
            {
                try
                {
                    execEvent.WaitOne(-1, true);

                    // need to stop ?
                    if (stopEvent.WaitOne(0, true))
                        break;

                    // create request
                    if (!preventCaching)
                    {
                        req = (HttpWebRequest)WebRequest.Create(this.controlCommand);
                    }
                    else
                    {
                        req = (HttpWebRequest)WebRequest.Create(this.controlCommand + ((this.controlCommand.IndexOf('?') == -1) ? '?' : '&') + "fake=" + rnd.Next().ToString());
                    }

                    // set login and password
                    if ((Login != null) && (Password != null) && (Login != ""))
                        req.Credentials = new NetworkCredential(Login, Password);
                    // set connection group name
                    if (useSeparateConnectionGroup)
                        req.ConnectionGroupName = GetHashCode().ToString();
                    // get response
                    resp = req.GetResponse();
                    StreamReader reader = new StreamReader(resp.GetResponseStream()); 
                    string str = reader.ReadLine();
                    while(str != null)
                    {
                        Console.WriteLine(str);
                        str = reader.ReadLine();
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
                    // close response
                    if (resp != null)
                    {
                        resp.Close();
                        resp = null;
                    }
                }

                execEvent.Reset();
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
