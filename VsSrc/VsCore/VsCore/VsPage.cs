// jcac	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tesk	
// camt	 By downloading, copying, installing or using the software you agree to this license.
// pdxl	 If you do not agree to this license, do not download, install,
// ydvl	 copy or use the software.
// orhm	
// srce	                          License Agreement
// ihbd	         For OpenVss - Open Source Video Surveillance System
// gcoz	
// kiob	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// duwl	
// ebwi	Third party copyrights are property of their respective owners.
// lwbi	
// ouur	Redistribution and use in source and binary forms, with or without modification,
// uokb	are permitted provided that the following conditions are met:
// cncv	
// zjmm	  * Redistribution's of source code must retain the above copyright notice,
// pybp	    this list of conditions and the following disclaimer.
// ptit	
// vwiq	  * Redistribution's in binary form must reproduce the above copyright notice,
// vutm	    this list of conditions and the following disclaimer in the documentation
// ftpl	    and/or other materials provided with the distribution.
// iwew	
// xnzp	  * Neither the name of the copyright holders nor the names of its contributors 
// salu	    may not be used to endorse or promote products derived from this software 
// ojsn	    without specific prior written permission.
// vltu	
// mawy	This software is provided by the copyright holders and contributors "as is" and
// ftfh	any express or implied warranties, including, but not limited to, the implied
// uqpg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tbes	In no event shall the Prince of Songkla University or contributors be liable 
// terb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ttau	(including, but not limited to, procurement of substitute goods or services;
// kncm	loss of use, data, or profits; or business interruption) however caused
// bgqu	and on any theory of liability, whether in contract, strict liability,
// zuzh	or tort (including negligence or otherwise) arising in any way out of
// agre	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Drawing;
using Vs.Core.Image;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
    public class ChannelList
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        public ChannelList(int pageID, VsChannel channel)
        {
            ChannelID = pageID;
            ChannelHandler = channel;
        }
        public int ChannelID;
        public VsChannel ChannelHandler;
        public int TimerSlide;
    }

	/// <summary>
	/// VsPage
	/// </summary>
	public class VsPage : IDisposable
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		private int		pageID = 0;
		private string	pageName;
		private string	pageDescription;

        public ArrayList vsChannelList = new ArrayList();

		public const int MaxChannel = 5;

        private bool bRunning = false;

        // new frame out
        public event VsImageEventHandler FrameOut;

        // timer
        //private System.Threading.Timer timer = null;
        //TimerCallback tcallback = null;

        // Lock object
        readonly private object lockBuffer = new object();

        // Provider
        String rtpModule;

        // Receiver
        private int receiverVideoPort;
        private int receiverAudioPort;

        // Stremer
        private VsStreamer vsStreamer = null;

        // Streamer parameters
        private String multicastAddress;
        private int streamerVideoPort;
        private int streamerAudioPort;
        private Size streamerSize;

        // enable/disable streammer
        private bool bStream = false;

        long syncTimer;

        #region Page Properties
        // ID property
        public int PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }
        // Name property
        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }
        // Description property
        public string Description
        {
            get { return pageDescription; }
            set { pageDescription = value; }
        }

        // FullName property
        public string FullName
        {
            get { return pageName; }
        }

        // Channels property
        public int Channels
        {
            get { return vsChannelList.Count; }
        }

        // RtpModule
        public string RtpModule
        {
            get { return rtpModule; }
            set { rtpModule = value; }
        }

        // Running
        public bool Running
        {
            get { return bRunning; }
            set { bRunning = value; }
        }
        #endregion

        #region Constructor

        // Constructor

        public VsPage()
        {
            try
            {
                this.pageName = "";
                this.bStream = false;

                this.syncTimer = 100;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer, 320, 240, 74);
                streamerSize = new Size(320, 240);

                // timer
                //tcallback = new TimerCallback(process_NewFrame);
                // define the dueTime and period 
                //long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                //timer = new Timer(tcallback, null, dTime, syncTimer);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        public VsPage(string pageName, long syncTimer)
        {
            try
            {
                this.pageName = pageName;
                this.bStream = false;

                this.syncTimer = syncTimer;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer, 320, 240, 74);
                streamerSize = new Size(320, 240);

                // timer
                //tcallback = new TimerCallback(process_NewFrame);
                // define the dueTime and period 
                //long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                //timer = new Timer(tcallback, null, dTime, syncTimer);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        public void Dispose()
        {
        } 
        #endregion

        #region Streamer properties

        // Streaming property
        public bool Streaming
        {
            get { return bStream; }
            set
            {
                bStream = value;
                StreamerLinking();
            }
        }

        //  property
        public String MulticastAddress
        {
            get { return multicastAddress; }
            set { multicastAddress = value; }
        }

        //  VideoPort property
        public int StreamerVideoPort
        {
            get { return streamerVideoPort; }
            set { streamerVideoPort = value; }
        }

        //  AudioPort property
        public int StreamerAudioPort
        {
            get { return streamerAudioPort; }
            set { streamerAudioPort = value; }
        }

        //  ReceiverVideoPort property
        public int ReceiverVideoPort
        {
            get { return receiverVideoPort; }
            set { receiverVideoPort = value; }
        }

        //  ReceiverAudioPort property
        public int ReceiverAudioPort
        {
            get { return receiverAudioPort; }
            set { receiverAudioPort = value; }
        }

        #endregion

        #region Streamer Linking

        private void StreamerLinking()
        {
            try
            {
                if (bStream)
                {
                    // detach events
                    try { FrameOut -= new VsImageEventHandler(vsStreamer.FrameIn); }
                    catch { }

                    // connect and start streaming
                    vsStreamer.Connect(pageName, MulticastAddress, StreamerVideoPort);

                    // send timed-logoed images to function "FrameIn" for streamming
                    FrameOut += new VsImageEventHandler(vsStreamer.FrameIn);
                }
                else
                {
                    // stop sending timed-logoed images to function "FrameIn" for processing
                    try { FrameOut -= new VsImageEventHandler(vsStreamer.FrameIn); }
                    catch { }

                    // stop streaming and disconnect
                    vsStreamer.Disconnect();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        #endregion

        #region Viewer Linking

        // Attach channel to view
        public bool AttachChannelView(VsAppInterface vsApp)
        {
            try { this.FrameOut += new VsImageEventHandler(vsApp.FrameIn); }
            catch { return false; }

            return true;
        }

        // Detach channel from view
        public bool DetachChannelView(VsAppInterface vsApp)
        {
            try { this.FrameOut -= new VsImageEventHandler(vsApp.FrameIn); }
            catch { return false; }

            return true;
        }

        #endregion

        #region Page Methods
        // Set channel
        public void SetChannel(int channelID, VsChannel vsChannel)
        {
            try
            {
                if (vsChannelList.Count >= MaxChannel) return;

                // add to list
                vsChannelList.Add(new ChannelList(channelID, vsChannel));
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Get channel
        public VsChannel GetChannelByID(int id)
        {
            try
            {
                foreach (ChannelList cl in vsChannelList)
                    if (cl.ChannelID == id) return cl.ChannelHandler;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

        // Get channel
        public VsChannel GetChannelByName(string name)
        {
            try
            {
                foreach (ChannelList cl in vsChannelList)
                    if (cl.ChannelHandler.ChannelName == name) return cl.ChannelHandler;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Remove channel
        public bool RemoveChannelByID(int id)
        {
            try
            {
                foreach (ChannelList cl in vsChannelList)
                {
                    if (cl.ChannelID == id)
                    {
                        vsChannelList.Remove(cl);
                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Remove channel
        public bool RemoveChannelByName(string name)
        {
            try
            {
                foreach (ChannelList cl in vsChannelList)
                {
                    if (cl.ChannelHandler.ChannelName == name)
                    {
                        vsChannelList.Remove(cl);
                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        } 
        #endregion

        #region Process frame

        // Generate main to theme
        private Bitmap GenerateBitmap()
        {
            Bitmap imgDraw = null;

            try
            {
                //imgDraw = new Bitmap(streamerSize.Width, streamerSize.Height);

                //using (Graphics g = Graphics.FromImage(imgDraw))
                //{
                    /*
                    g.FillRectangle(new SolidBrush(Color.Black), 0, 0, streamerSize.Width, streamerSize.Height);
                    foreach (CameraList cl in vsCameraList)
                    {
                        cl.CameraHandler.LockImage();
                        if (cl.CameraHandler.lastFrame != null)
                        {
                            g.DrawImage(cl.CameraHandler.lastFrame.Image,
                                cl.LayoutPoint.X, cl.LayoutPoint.Y,
                                cl.LayoutSize.Width, cl.LayoutSize.Height);
                        }
                        cl.CameraHandler.UnlockImage();
                    }
                    */
                //}
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return imgDraw;
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object stateInfo)
        {
            Monitor.Enter(lockBuffer);

            try
            {
                Bitmap imgBuffer = GenerateBitmap();
                if (imgBuffer != null)
                {
                    // 
                    VsImage lastFrame = new VsImage(imgBuffer);
                    // output
                    if (FrameOut != null) FrameOut(this, new VsImageEventArgs(lastFrame));
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(lockBuffer);
            }
        }
        #endregion
	}
}
