// sige	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gfjh	
// lsnd	 By downloading, copying, installing or using the software you agree to this license.
// zkqb	 If you do not agree to this license, do not download, install,
// wlxa	 copy or use the software.
// ikau	
// uxjw	                          License Agreement
// mfyq	         For OpenVSS - Open Source Video Surveillance System
// yusu	
// uiue	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dhob	
// sypo	Third party copyrights are property of their respective owners.
// rjyr	
// byai	Redistribution and use in source and binary forms, with or without modification,
// hmki	are permitted provided that the following conditions are met:
// vnvg	
// uwff	  * Redistribution's of source code must retain the above copyright notice,
// svgo	    this list of conditions and the following disclaimer.
// qtxa	
// vybv	  * Redistribution's in binary form must reproduce the above copyright notice,
// iued	    this list of conditions and the following disclaimer in the documentation
// ggoz	    and/or other materials provided with the distribution.
// tjni	
// ymip	  * Neither the name of the copyright holders nor the names of its contributors 
// mhhw	    may not be used to endorse or promote products derived from this software 
// tjvv	    without specific prior written permission.
// ckah	
// bami	This software is provided by the copyright holders and contributors "as is" and
// kpza	any express or implied warranties, including, but not limited to, the implied
// iszn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hflj	In no event shall the Prince of Songkla University or contributors be liable 
// ixpe	for any direct, indirect, incidental, special, exemplary, or consequential damages
// khoo	(including, but not limited to, procurement of substitute goods or services;
// rfcy	loss of use, data, or profits; or business interruption) however caused
// ziav	and on any theory of liability, whether in contract, strict liability,
// fgyt	or tort (including negligence or otherwise) arising in any way out of
// xexj	the use of this software, even if advised of the possibility of such damage.
// migt	
// itoo	Intelligent Systems Laboratory (iSys Lab)
// ymne	Faculty of Engineering, Prince of Songkla University, THAILAND
// uwxt	Project leader by Nikom SUVONVORN
// lyrf	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.Runtime.CompilerServices;
using Vs.Core.Image;
using Vs.Core.Analyzer;
using Vs.Core.Encoder;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
    public enum ChannelLayout
    {
        TH_GRID_0 = 0,
        TH_GRID_1,
        TH_GRID_2
    }

    public class CameraList
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        public CameraList(int id, VsCamera camera)
        {
            CameraID = id;
            CameraHandler = camera;
        }
        public int CameraID;
        public VsCamera CameraHandler;
        public Point LayoutPoint;
        public Size LayoutSize;
    }

	/// <summary>
	/// VsChannel
	/// </summary>
    public class VsChannel : IDisposable
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        #region Definition Channel

        // Processing host
        private string pcHost;
        private string pcDirt;

        private bool bRunning = false;
        private int channelID = 0;
        private string channelName;
        private string channelDescription;
        public ArrayList vsCameraList = new ArrayList();
        ChannelLayout vsLayout = ChannelLayout.TH_GRID_1;
        public static int MaxCam = 25;

        // new frame out
        public event VsImageEventHandler FrameOut;

        // timer
        private System.Threading.Timer timer = null;
        TimerCallback tcallback = null;

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
        private int Width=320, Height=240;

        long syncTimer;

        #endregion

        #region Channel Properties

        // ID property
        public int ChannelID
        {
            get { return channelID; }
            set { channelID = value; }
        }

        // Name property
        public string ChannelName
        {
            get { return channelName; }
            set { channelName = value; }
        }

        // Description property
        public string Description
        {
            get { return channelDescription; }
            set { channelDescription = value; }
        }

        // FullName property
        public string FullName
        {
            get { return channelName; }
        }

        // Localhost property
        public string LocalHost
        {
            get { return pcHost; }
            set { pcHost = value; }
        }

        // Data storage directory
        public string LocalStorage
        {
            get { return pcDirt; }
            set { pcDirt = value; }
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

        // Cols property
        public short Cols
        {
            get
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        return gLayoutCols;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }

                return gLayoutCols;
            }
            set
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        gLayoutCols = Math.Max((short)1, Math.Min((short)gLayoutMaxCols, value));
                        break;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
            }
        }

        // Rows property
        public short Rows
        {
            get
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        return gLayoutRows;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
                return gLayoutRows;
            }

            set
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        gLayoutRows = Math.Max((short)1, Math.Min((short)gLayoutMaxRows, value));
                        break;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
            }
        }

        // CellWidth property
        public short CellWidth
        {
            get
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        return gLayoutCellWidth;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
                return gLayoutCellWidth;
            }

            set
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        gLayoutCellWidth = Math.Max((short)50, Math.Min((short)800, value));
                        break;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
            }
        }

        // CellHeight property
        public short CellHeight
        {
            get
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        return gLayoutCellHeight;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
                return gLayoutCellHeight;
            }

            set
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        gLayoutCellHeight = Math.Max((short)50, Math.Min((short)800, value));
                        break;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2
                        break;
                }
            }
        }

        // Camera Number
        public int CameraNumber
        {
            get { return vsCameraList.Count; }
        }

        #endregion

        #region Definition Analyzer
        // Analyser
        private bool bAnalysis = false;
        private string analyzerName;
        private string analyzerDescription = "";
        private VsICoreAnalyzerConfiguration analyzerConfiguration = null;
        private VsAnalyzer vsAnalyzer = null;
        private VsICoreAnalyzer vsAnalyserSource = null;
        #endregion

        #region Definition Encoder
        // Encoder
        private bool bRecord = false;
        private string encoderName;
        private string encoderDescription = "";
        private object encoderConfiguration = null;
        private VsEncoder vsEncoder = null;
        private VsICoreEncoder vsEncoderSource = null;
        #endregion

        #region Definition Grid Layout
        /// <summary>
        /// Grid theme definition
        /// </summary>
        private short gLayoutCols = 2;
        private short gLayoutRows = 2;
        private short gLayoutCellWidth = 320;
        private short gLayoutCellHeight = 240;
        private const int gLayoutMaxRows = 5;
        private const int gLayoutMaxCols = 5;
        #endregion

        #region Action flags properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Action flags properties
        // -----------------------------------------------------------------------------------------------------------------------

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

        // Analysing property
        public bool Analysing
        {
            get { return bAnalysis; }
            set
            {
                bAnalysis = value;
                AnalyzerLinking();
            }
        }

        // Recording property
        public bool Recording
        {
            get { return bRecord; }
            set
            {
                bRecord = value;
                EncoderLinking();
            }
        }
        #endregion

        #region Streamer properties

        //  property
        public String MulticastAddress
        {
            get { return multicastAddress; }
            set { multicastAddress = value;}
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

        #region Analyser properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Analyser
        // -----------------------------------------------------------------------------------------------------------------------
        public string AnalyserName
        {
            get { return (vsAnalyserSource == null) ? "" : vsAnalyserSource.AnalyserName; ; }
            set { analyzerName = value; }
        }

        public string AnalyserDescription
        {
            get { return analyzerDescription; }
            set { analyzerDescription = value; }
        }

        public VsICoreAnalyzerConfiguration AnalyserConfiguration
        {
            get { return analyzerConfiguration; }
            set { analyzerConfiguration = value; }
        }

        public VsAnalyzer Analyser
        {
            get { return vsAnalyzer; }
            set { vsAnalyzer = value; }
        }

        public VsICoreAnalyzer AnalyzerSource
        {
            get { return vsAnalyserSource; }
            set { vsAnalyserSource = value; }
        }

        #endregion

        #region Encoder properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Encoder
        // -----------------------------------------------------------------------------------------------------------------------
        public string EncoderName
        {
            get { return (vsEncoderSource == null) ? "" : vsEncoderSource.EncoderName; ; }
            set { encoderName = value; }
        }

        public string EncoderDescription
        {
            get { return encoderDescription; }
            set { encoderDescription = value; }
        }

        public object EncoderConfiguration
        {
            get { return encoderConfiguration; }
            set { encoderConfiguration = value; }
        }

        public VsEncoder Encoder
        {
            get { return vsEncoder; }
            set { vsEncoder = value; }
        }

        public VsICoreEncoder EncoderSource
        {
            get { return vsEncoderSource; }
            set { vsEncoderSource = value; }
        }

        #endregion

        #region Constructor/destructor

        // Constructor
        public VsChannel()
        {
            try
            {
                this.channelName = "";
                this.bStream = false;

                syncTimer = 100;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer);
                streamerSize = new Size(Width, Height);

                // timer
                tcallback = new TimerCallback(process_NewFrame);
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

        // Constructor
        public VsChannel(string channelName, long syncTimer)
        {
            try
            {
                this.channelName = channelName;
                this.bStream = false;
                this.syncTimer = syncTimer;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer);
                streamerSize = new Size(Width, Height);

                // timer
                tcallback = new TimerCallback(process_NewFrame);
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

        public VsChannel(string channelName, long syncTimer, int streamWidth, int streamHeight, int streamQuality)
        {
            try
            {
                this.channelName = channelName;
                this.bStream = false;
                this.syncTimer = syncTimer;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer, streamWidth, streamHeight, streamQuality);
                streamerSize = new Size(streamWidth, streamHeight);

                // timer
                tcallback = new TimerCallback(process_NewFrame);
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

        // destructor
        public void Dispose()
        {
            try
            {
                if (vsStreamer != null)
                {
                    vsStreamer.Dispose();
                    vsStreamer = null;
                }

                // stop process
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        } 
        #endregion

        #region Create/Close AnalyserSource

        // -----------------------------------------------------------------------------------------------------------------------
        // Create vsAnalyzer source
        // -----------------------------------------------------------------------------------------------------------------------
        public bool CreateAnalyserSource()
        {
            try
            {
                if (vsAnalyzer != null)
                {
                    if ((vsAnalyserSource = vsAnalyzer.CreateAnalyserSource(syncTimer, AnalyserConfiguration)) != null)
                    {
                        AnalyzerLinking();

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

        // Close video source
        public void CloseAnalyserSource()
        {
            try
            {
                if (vsAnalyserSource != null)
                {
                    vsAnalyserSource = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        #endregion

        #region Create/Close EncoderSource
        // -----------------------------------------------------------------------------------------------------------------------
        // Create vsEncoder source
        // -----------------------------------------------------------------------------------------------------------------------
        public bool CreateEncoderSource()
        {
            try
            {
                if (vsEncoder != null)
                {
                    if ((vsEncoderSource = vsEncoder.CreateEncoderSource(syncTimer, EncoderConfiguration)) != null)
                    {
                        EncoderLinking();

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

        // Close vsEncoder source
        public void CloseEncoderSource()
        {
            try
            {
                if (vsEncoderSource != null)
                {
                    vsEncoderSource = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        #endregion

        #region Channel methods

        // Start method
        public void Start(bool stream)
        {
            try
            {
                if (!CreateAnalyserSource())
                    return;

                if (!CreateEncoderSource())
                    return;

                this.Running = true;
                this.Streaming = stream;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Stop method
        public void Stop()
        {
            try
            {
                CloseAnalyserSource();

                CloseEncoderSource();

                this.Running = false;
                this.Streaming = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Set camera
        public void SetCamera(int cameraID, VsCamera vsCam)
        {
            try
            {
                if (vsCameraList.Count >= MaxCam) return;

                // add to list
                vsCameraList.Add(new CameraList(cameraID, vsCam));

                // generate layout
                GenerateLayout();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Get camera
        public VsCamera GetCameraByID(int id)
        {
            try
            {
                foreach (CameraList cl in vsCameraList)
                    if (cl.CameraID == id) return cl.CameraHandler;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get camera
        public VsCamera GetCameraByIP(string ip)
        {
            try
            {
                foreach (CameraList cl in vsCameraList)
                    if (cl.CameraHandler.CameraIP == ip) return cl.CameraHandler;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Remove camera
        public bool RemoveCameraByID(int id)
        {
            try
            {
                foreach (CameraList cl in vsCameraList)
                {
                    if (cl.CameraID == id)
                    {
                        vsCameraList.Remove(cl);
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

        // Remove camera
        public bool RemoveCameraByIP(string ip)
        {
            try
            {
                foreach (CameraList cl in vsCameraList)
                {
                    if (cl.CameraHandler.CameraIP == ip)
                    {
                        vsCameraList.Remove(cl);
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

        // Remove camera
        public bool RemoveCameraByName(string name)
        {
            try
            {
                foreach (CameraList cl in vsCameraList)
                {
                    if (cl.CameraHandler.CameraName == name)
                    {
                        vsCameraList.Remove(cl);
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

        // Set Layout
        public void SetLayout(ChannelLayout cLayout)
        {
            try
            {
                vsLayout = cLayout;
                GenerateLayout();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Generate main to theme
        public void GenerateLayout()
        {
            try
            {
                switch (vsLayout)
                {
                    case ChannelLayout.TH_GRID_1:
                        GenerateLayoutGrid1();
                        break;
                    case ChannelLayout.TH_GRID_2:
                        // TODO : grid theme #2                    
                        break;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        #endregion

        #region Analyser Linking

        private void AnalyzerLinking()
        {
            try
            {
                int i = 1;
                foreach (CameraList cl in vsCameraList)
                {
                    if (vsAnalyserSource != null)
                    {
                        // set current host
                        vsAnalyserSource.CameraName = ChannelName;
                        vsAnalyserSource.LocalHost = LocalHost;

                        if (i == 1)
                        {
                            if (bAnalysis)
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                                catch { }

                                // send timed-logoed images to function "FrameIn" for processing
                                cl.CameraHandler.FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn1);
                            }
                            else
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                                catch { }
                            }
                        }
                        else if (i == 2)
                        {
                            if (bAnalysis)
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn2); }
                                catch { }

                                // send timed-logoed images to function "FrameIn" for processing
                                cl.CameraHandler.FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn2);
                            }
                            else
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn2); }
                                catch { }
                            }
                        }
                        else if (i == 3)
                        {
                            if (bAnalysis)
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn3); }
                                catch { }

                                // send timed-logoed images to function "FrameIn" for processing
                                cl.CameraHandler.FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn3);
                            }
                            else
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn3); }
                                catch { }
                            }
                        }
                        else if (i == 4)
                        {
                            if (bAnalysis)
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn4); }
                                catch { }

                                // send timed-logoed images to function "FrameIn" for processing
                                cl.CameraHandler.FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn4);
                            }
                            else
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn4); }
                                catch { }
                            }
                        }
                        else if (i == 5)
                        {
                            if (bAnalysis)
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn5); }
                                catch { }

                                // send timed-logoed images to function "FrameIn" for processing
                                cl.CameraHandler.FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn5);
                            }
                            else
                            {
                                // detach events
                                try { cl.CameraHandler.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn5); }
                                catch { }
                            }
                        }
                    }
                    i++;
                }

                /*
                if (vsVideoSource == null || vsAnalyserSource == null) return;

                // set current host
                vsAnalyserSource.CameraName = ChannelName;
                vsAnalyserSource.LocalHost = ChannelName;

                if (bAnalysis)
                {
                    // detach events
                    try { vsVideoSource.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                    catch { }

                    // send timed-logoed images to function "FrameIn" for processing
                    vsVideoSource.FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn1);
                }
                else
                {
                    // detach events
                    try { vsVideoSource.FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                    catch { }
                }
                */
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        #endregion

        #region Encoder Linking

        private void EncoderLinking()
        {
            try
            {
                if (vsAnalyserSource == null || vsEncoderSource == null) return;

                // set current host
                vsEncoderSource.CameraName = ChannelName;
                vsEncoderSource.LocalHost = LocalHost;
                vsEncoderSource.LocalStorage = LocalStorage;

                // stop current recording
               // try { vsEncoderSource.SignalToStop(); }
               // catch { }

                if (bRecord)
                {
                    // detach events
                    try { vsAnalyserSource.FrameOut1 -= new VsImageEventHandler(vsEncoderSource.FrameIn); }
                    catch { }

                    // send motion detection images to function "FrameIn" for encoding
                    vsAnalyserSource.FrameOut1 += new VsImageEventHandler(vsEncoderSource.FrameIn);
                }
                else
                {
                    // detach events
                    try { vsAnalyserSource.FrameOut1 -= new VsImageEventHandler(vsEncoderSource.FrameIn); }
                    catch { }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
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
                    vsStreamer.Connect(channelName, MulticastAddress, StreamerVideoPort);

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
            try
            {
                try { this.FrameOut += new VsImageEventHandler(vsApp.FrameIn); }
                catch { return false; }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return true;
        }

        // Detach channel from view
        public bool DetachChannelView(VsAppInterface vsApp)
        {
            try
            {
                try { this.FrameOut -= new VsImageEventHandler(vsApp.FrameIn); }
                catch { return false; }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return true;
        }

        // Attach camera to view
        public bool AttachChannelViewAnalyzer(VsAppInterface vsApp)
        {
            try
            {
                try { vsAnalyserSource.FrameOut1 += new VsImageEventHandler(vsApp.FrameIn); }
                catch { return false; }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return true;
        }

        // Detach camera from view
        public bool DetachChannelViewAnalyzer(VsAppInterface vsApp)
        {
            try
            {
                try { vsAnalyserSource.FrameOut1 -= new VsImageEventHandler(vsApp.FrameIn); }
                catch { return false; }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return true;
        }

        #endregion

        #region Grid Layout #1 methods

        private void GenerateLayoutGrid1()
        {
            try
            {
                // calculate width & height of cameras to fit the view to the window
                int width = (streamerSize.Width / gLayoutCols);
                int height = (streamerSize.Height / gLayoutRows);

                // starting position of the view
                int startX = (streamerSize.Width - gLayoutCols * width) / 2;
                int startY = (streamerSize.Height - gLayoutRows * height) / 2;

                int count = 0;
                foreach (CameraList cl in vsCameraList)
                {

                    int j = count % gLayoutCols;
                    int i = (count - j) / gLayoutRows;
                    cl.LayoutPoint = new Point(startX + width * j + 1, startY + height * i + 1);
                    cl.LayoutSize = new Size(width, height);

                    count++;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        #endregion

        #region Process frame

        // Generate main to theme
        private Bitmap GenerateBitmap()
        {
            Bitmap imgDraw = null;
            try
            {
                imgDraw = new Bitmap(streamerSize.Width, streamerSize.Height);

                using (Graphics g = Graphics.FromImage(imgDraw))
                {
                    g.FillRectangle(new SolidBrush(Color.Black), 0, 0, streamerSize.Width, streamerSize.Height);
                    foreach (CameraList cl in vsCameraList)
                    {
                        Bitmap curImg = cl.CameraHandler.GetFrame();
                        if (curImg != null)
                        {
                            g.DrawImage(curImg, cl.LayoutPoint.X, cl.LayoutPoint.Y,
                                cl.LayoutSize.Width, cl.LayoutSize.Height);
                        }
                    }
                }
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
        } 
        #endregion

        #region Utility
        public override String ToString()
        {
            String desStr = null;

            try
            {
                desStr = "Name: " + ChannelName + ", " +
                    "Streamming: " + Streaming.ToString() + ", " +
                    "Multicast Address: " + MulticastAddress + ", " +
                    "Streamer VideoPort: " + StreamerVideoPort.ToString() + ", " +
                    "Streamer AudioPort: " + StreamerAudioPort.ToString() + ", " +
                    "Receiver VideoPort: " + ReceiverVideoPort.ToString() + ", " +
                    "Receiver AudioPort: " + ReceiverAudioPort.ToString();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return desStr;
        }
 
	    #endregion    
    }
}
