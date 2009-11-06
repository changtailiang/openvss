// cbzo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lzqo	
// odih	 By downloading, copying, installing or using the software you agree to this license.
// wtle	 If you do not agree to this license, do not download, install,
// lyks	 copy or use the software.
// jaqi	
// zoew	                          License Agreement
// fgkq	         For OpenVss - Open Source Video Surveillance System
// jcci	
// rcts	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// owio	
// jcbr	Third party copyrights are property of their respective owners.
// giso	
// drkb	Redistribution and use in source and binary forms, with or without modification,
// kqox	are permitted provided that the following conditions are met:
// utjh	
// tryu	  * Redistribution's of source code must retain the above copyright notice,
// rdni	    this list of conditions and the following disclaimer.
// fren	
// sczx	  * Redistribution's in binary form must reproduce the above copyright notice,
// mnqw	    this list of conditions and the following disclaimer in the documentation
// ovnr	    and/or other materials provided with the distribution.
// raya	
// owxv	  * Neither the name of the copyright holders nor the names of its contributors 
// mbur	    may not be used to endorse or promote products derived from this software 
// dhad	    without specific prior written permission.
// vjjl	
// nxjh	This software is provided by the copyright holders and contributors "as is" and
// rrkh	any express or implied warranties, including, but not limited to, the implied
// cnsx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// egdq	In no event shall the Prince of Songkla University or contributors be liable 
// enui	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uibr	(including, but not limited to, procurement of substitute goods or services;
// ihtf	loss of use, data, or profits; or business interruption) however caused
// nnbf	and on any theory of liability, whether in contract, strict liability,
// mbdu	or tort (including negligence or otherwise) arising in any way out of
// rqjw	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Runtime.CompilerServices;
using Vs.Core.Encoder;
using Vs.Core.Analyzer;
using Vs.Core.Provider;
using Vs.Core.DataAlert;
using Vs.Core.EventAlert;
using Vs.Core.EmailAlert;
using Vs.Core.Image;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// VsCamera class
	/// </summary>
	public class VsCamera : IDisposable
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        #region Definition

        // Camera description
        private int camID = 0;
        private string camName;
        private string camDesp;
        private string camIP;

        // Processing host
        private string pcHost;
        private string pcDirt;

        // Database host
        private string dbHost;
        private string dbUser;
        private string dbPasswd;
        private string dbDatabase;

        // Email host
        private string smtpHost;
        private string smtpUser;
        private string smtpPasswd;
        private string emailFrom;
        private string emailTo;

        // Timer synchronization
        private long syncTimer=20;

        // Action flags
        private bool bPreview = false;
        private bool bStream = false;
        private bool bAnalysis = false;
        private bool bRecord = false;
        private bool bDataAlert = false;
        private bool bEventAlert = false;
        private bool bEmailAlert = false;

        // Stremer
        private VsStreamer vsStreamer = null;

        // Provider
        private object providerConfiguration = null;
        private VsProvider vsProvider = null;
        private VsICoreProvider vsVideoSource = null;

        // Analyser
        private string analyzerName;
        private string analyzerDescription = "";
        private VsICoreAnalyzerConfiguration analyzerConfiguration = null;
        private VsAnalyzer vsAnalyzer = null;
        private VsICoreAnalyzer vsAnalyserSource = null;

        // Encoder
        private string encoderName;
        private string encoderDescription = "";
        private object encoderConfiguration = null;
        private VsEncoder vsEncoder = null;
        private VsICoreEncoder vsEncoderSource = null;

        // Event alert
        private VsEventGenerator vsEventAlert = null;

        // Data alert
        private VsDataGenerator vsDataAlert = null;

        // Email alert
        private VsEmailGenerator vsEmailAlert = null;

        // buffer
        protected Queue imgBuffer = null;

        // timer
        private System.Threading.Timer timer = null;
        TimerCallback tcallback = null;

        // current frame
        public VsImage lastFrame = null;

        // control object
        private readonly object syncCtrl = new object();

        // new frame out
        public event VsImageEventHandler FrameOut;

        #endregion

        #region Properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Synchronization properties
        // -----------------------------------------------------------------------------------------------------------------------
        // SyncTimer property
        public long SyncTimer
        {
            get { return syncTimer; }
            set { syncTimer = value; }
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // Local host properties
        // -----------------------------------------------------------------------------------------------------------------------
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
        #endregion

        #region Email Server properties
        // SmtpHost property
        public string SmtpHost
        {
            get { return smtpHost; }
            set { smtpHost = value; }
        }

        // SmtpUser property
        public string SmtpUser
        {
            get { return smtpUser; }
            set { smtpUser = value; }
        }

        // SmtpPasswd property
        public string SmtpPasswd
        {
            get { return smtpPasswd; }
            set { smtpPasswd = value; }
        }

        // EmailFrom property
        public string EmailFrom
        {
            get { return emailFrom; }
            set { emailFrom = value; }
        }

        // EmailTo property
        public string EmailTo
        {
            get { return emailTo; }
            set { emailTo = value; }
        }

        #endregion

        #region Database Server properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Database host properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Database host property
        public string DataHost
        {
            get { return dbHost; }
            set { dbHost = value; }
        }

        // Data user property
        public string DataUser
        {
            get { return dbUser; }
            set { dbUser = value; }
        }

        // Data password property
        public string DataPasswd
        {
            get { return dbPasswd; }
            set { dbPasswd = value; }
        }

        // Data database property
        public string DataDatabase
        {
            get { return dbDatabase; }
            set { dbDatabase = value; }
        }

        #endregion

        #region Action flags properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Action flags properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Previewing property
        public bool Previewing
        {
            get { return bPreview; }
            set { bPreview = value; }
        }

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

        // DataAlerting property
        public bool DataAlerting
        {
            get { return bDataAlert; }
            set
            {
                bDataAlert = value;
                DataAlertLinking();
            }
        }

        // EventAlerting property
        public bool EventAlerting
        {
            get { return bEventAlert; }
            set
            {
                bEventAlert = value;
                EventAlertLinking();
            }
        }

        // EmailAlerting property
        public bool EmailAlerting
        {
            get { return bEmailAlert; }
            set
            {
                bEmailAlert = value;
                EmailAlertLinking();
            }
        }
        #endregion

        #region Camera properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Camera description
        // -----------------------------------------------------------------------------------------------------------------------
        // ID property
        public int CameraID
        {
            get { return camID; }
            set { camID = value; }
        }

        // Name property
        public string CameraName
        {
            get { return camName; }
            set { camName = value; }
        }

        // IP Adress property
        public string CameraIP
        {
            get { return camIP; }
            set { camIP = value; }
        }

        // Description property
        public string CameraDescription
        {
            get { return camDesp; }
            set { camDesp = value; }
        }

        // Configuration property
        public object CameraConfiguration
        {
            get { return providerConfiguration; }
            set { providerConfiguration = value; }
        }
        #endregion

        #region Streamer properties
        // Streamer properties
        public VsStreamer Streamer
        {
            get { return vsStreamer; }
            set { vsStreamer = value; }
        }

        #endregion

        #region Provider properties
        // Provider properties
        public VsProvider Provider
        {
            get { return vsProvider; }
            set { vsProvider = value; }
        }

        // VideoSource property
        public string VideoSource
        {
            get { return (vsVideoSource == null) ? "" : vsVideoSource.VideoSource; }
        }

        // FramesReceived property
        public int FramesReceived
        {
            get { return (vsVideoSource == null) ? 0 : vsVideoSource.FramesReceived; }
        }

        // BytesReceived property
        public int BytesReceived
        {
            get { return (vsVideoSource == null) ? 0 : vsVideoSource.BytesReceived; }
        }

        // Running property
        public bool Running
        {
            get { return (vsVideoSource == null) ? false : vsVideoSource.Running; }
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
        // -----------------------------------------------------------------------------------------------------------------------
        // constructor/destructor
        // -----------------------------------------------------------------------------------------------------------------------
        public VsCamera()
        {
            try
            {
                // camera
                this.camName = "";
                this.syncTimer = 100;

                // action
                this.bPreview = true;
                this.bStream = false;
                this.bAnalysis = false;
                this.bRecord = false;
                this.bDataAlert = false;
                this.bEventAlert = false;

                // Data Generator 
                vsDataAlert = new VsDataGenerator(syncTimer, dbHost, dbUser, dbPasswd, dbDatabase);

                // Event Generator
                vsEventAlert = new VsEventGenerator(syncTimer, dbHost, dbUser, dbPasswd, dbDatabase);

                // syncronized queue
                imgBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);

                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        public VsCamera(string camName, long syncTimer)
        {
            try
            {
                // camera
                this.camName = camName;
                this.syncTimer = syncTimer;

                // action
                this.bPreview = true;
                this.bStream = false;
                this.bAnalysis = false;
                this.bRecord = false;
                this.bDataAlert = false;
                this.bEventAlert = false;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer, 320, 240, 74);

                // Data Generator 
                vsDataAlert = new VsDataGenerator(syncTimer, dbHost, dbUser, dbPasswd, dbDatabase);

                // Event Generator
                vsEventAlert = new VsEventGenerator(syncTimer, dbHost, dbUser, dbPasswd, dbDatabase);

                // syncronized queue
                imgBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);

                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        public VsCamera(int camID, string camName, string camDesp,
            long syncTimer,
            string pcHost, string pcDirt,
            string dbHost, string dbUser, string dbPasswd, string dbDatabase,
            string smtpHost, string smtpUser, string smtpPasswd, string emailFrom, string emailTo,
            bool bPreview, bool bStream, bool bAnalysis, bool bRecord, bool bEventAlert, bool bDataAlert, bool bMailAlert)
        {
            try
            {
                // camera
                this.camID = camID;
                this.camName = camName;
                this.camDesp = camDesp;
                this.syncTimer = syncTimer;

                // local host
                this.pcHost = pcHost;
                this.pcDirt = pcDirt;

                // data host
                this.dbHost = dbHost;
                this.dbUser = dbUser;
                this.dbPasswd = dbPasswd;
                this.dbDatabase = dbDatabase;

                // mail host
                this.smtpHost = smtpHost;
                this.smtpUser = smtpUser;
                this.smtpPasswd = smtpPasswd;
                this.emailFrom = emailFrom;
                this.emailTo = emailTo;

                // action
                this.bPreview = bPreview;
                this.bStream = bStream;
                this.bAnalysis = bAnalysis;
                this.bRecord = bRecord;
                this.bDataAlert = bDataAlert;
                this.bEventAlert = bEventAlert;
                this.bEmailAlert = bMailAlert;

                // Streamer 
                vsStreamer = new VsStreamer(syncTimer, 320, 240, 74);

                // Data Generator 
                vsDataAlert = new VsDataGenerator(syncTimer, dbHost, dbUser, dbPasswd, dbDatabase);

                // Event Generator
                vsEventAlert = new VsEventGenerator(syncTimer, dbHost, dbUser, dbPasswd, dbDatabase);

                // Email Generation
                vsEmailAlert = new VsEmailGenerator(syncTimer, smtpHost, smtpUser, smtpPasswd, emailFrom, emailTo);

                // syncronized queue
                imgBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);

                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);
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

                if (vsEventAlert != null)
                {
                    vsEventAlert.Dispose();
                    vsEventAlert = null;
                }

                if (vsDataAlert != null)
                {
                    vsDataAlert.Dispose();
                    vsDataAlert = null;
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

        #region Create/Close VideoSource
        // -----------------------------------------------------------------------------------------------------------------------
        // Create video source
        // -----------------------------------------------------------------------------------------------------------------------
        public bool CreateVideoSource()
        {
            try
            {
                if ((vsProvider != null) && ((vsVideoSource = vsProvider.CreateVideoSource(providerConfiguration)) != null))
                {
                    // transfer images from video source to function "process_NewFrame"
                    // for adding logo and time
                    vsVideoSource.FrameOut += new VsImageEventHandler(FrameIn);

                    StreamerLinking();

                    return true;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Close video source
        public void CloseVideoSource()
        {
            try
            {
                if (vsVideoSource != null)
                {                    
                    vsVideoSource = null;
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
                        DataAlertLinking();

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

        #region Analyser Linking

        private void AnalyzerLinking()
        {
            try
            {
                if (vsVideoSource == null || vsAnalyserSource == null) return;

                // set current host
                vsAnalyserSource.CameraName = CameraName;
                vsAnalyserSource.LocalHost = LocalHost;

                if (bAnalysis)
                {
                    // detach events
                    try { FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                    catch { }

                    // send timed-logoed images to function "FrameIn" for processing
                    FrameOut += new VsImageEventHandler(vsAnalyserSource.FrameIn1);
                }
                else
                {
                    // detach events
                    try { FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                    catch { }
                }
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
                vsEncoderSource.CameraName = CameraName;
                vsEncoderSource.LocalHost = LocalHost;
                vsEncoderSource.LocalStorage = LocalStorage;

                // stop current recording
                //try { vsEncoderSource.SignalToStop(); }
                //catch { }

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

        #region Event Alert Linking
        // -----------------------------------------------------------------------------------------------------------------------
        // Event source
        // -----------------------------------------------------------------------------------------------------------------------
        private void EventAlertLinking()
        {
            try
            {
                if (vsAnalyserSource == null || vsEventAlert == null) return;

                if (bEventAlert)
                {
                    // detach events
                    try { vsAnalyserSource.MotionOut -= new VsMotionEventHandler(vsEventAlert.FrameIn); }
                    catch { }

                    // send motion event from the Smoother to database server
                    vsAnalyserSource.MotionOut += new VsMotionEventHandler(vsEventAlert.FrameIn);
                }
                else
                {
                    // detach events
                    try { vsAnalyserSource.MotionOut -= new VsMotionEventHandler(vsEventAlert.FrameIn); }
                    catch { }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }


        // Attach camera to view
        public bool AttachEventView(VsEventInterface vsEvent)
        {
            try { vsEncoderSource.EventOut += new VsDataEventHandler(vsEmailAlert.FrameIn); }
            catch { return false; }

            return true;
        }

        // Detach camera from view
        public bool DetachEventView(VsEventInterface vsEvent)
        {
            try { vsAnalyserSource.MotionOut -= new VsMotionEventHandler(vsEvent.FrameIn); }
            catch { return false; }

            return true;
        }
        #endregion

        #region Email Alert Linking
        // -----------------------------------------------------------------------------------------------------------------------
        // Email source
        // -----------------------------------------------------------------------------------------------------------------------
        private void EmailAlertLinking()
        {
            try
            {
                if (vsEncoderSource == null || vsEmailAlert == null) return;

                if (bEmailAlert)
                {
                    // detach events
                    try { vsEncoderSource.EventOut -= new VsDataEventHandler(vsEmailAlert.FrameIn); }
                    catch { }

                    // send motion event from the Smoother to email sender
                    vsEncoderSource.EventOut += new VsDataEventHandler(vsEmailAlert.FrameIn);
                }
                else
                {
                    // detach events
                    try { vsEncoderSource.EventOut -= new VsDataEventHandler(vsEmailAlert.FrameIn); }
                    catch { }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        #endregion

        #region Data Alert Linking
        // -----------------------------------------------------------------------------------------------------------------------
        // Data source
        // -----------------------------------------------------------------------------------------------------------------------
        private void DataAlertLinking()
        {
            try
            {
                if (vsEncoderSource == null || vsDataAlert == null) return;
                if (bDataAlert)
                {
                    // detach events
                    try { vsEncoderSource.DataOut -= new VsDataEventHandler(vsDataAlert.FrameIn); }
                    catch { }

                    // after finishing encoding, send matadata to database server for searching/playback 
                    vsEncoderSource.DataOut += new VsDataEventHandler(vsDataAlert.FrameIn);
                }
                else
                {
                    // detach events
                    try { vsEncoderSource.DataOut -= new VsDataEventHandler(vsDataAlert.FrameIn); }
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
                    vsStreamer.Connect(CameraName, "224.0.0.1", 5000);

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

        // Attach camera to view
        public bool AttachCameraView(VsAppInterface vsApp)
        {
            try { FrameOut += new VsImageEventHandler(vsApp.FrameIn); }
            catch { return false; }

            return true;
        }

        // Detach camera from view
        public bool DetachCameraView(VsAppInterface vsApp)
        {
            try { FrameOut -= new VsImageEventHandler(vsApp.FrameIn); }
            catch { return false; }

            return true;
        }

        // Attach camera to view
        public bool AttachCameraViewAnalyzer(VsAppInterface vsApp)
        {
            try { vsAnalyserSource.FrameOut1 += new VsImageEventHandler(vsApp.FrameIn); }
            catch { return false; }

            return true;
        }

        // Detach camera from view
        public bool DetachCameraViewAnalyzer(VsAppInterface vsApp)
        {
            try { vsAnalyserSource.FrameOut1 -= new VsImageEventHandler(vsApp.FrameIn); }
            catch { return false; }

            return true;
        }

        #endregion

        #region Camera Start/Stop
		// -----------------------------------------------------------------------------------------------------------------------
        // Start video source
        // -----------------------------------------------------------------------------------------------------------------------
        public void Start()
		{
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null)
                {
                    vsVideoSource.Start();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

		// Siganl video source to stop
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SignalToStop()
		{
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null)
                {
                    // detache events
                    try { FrameOut -= new VsImageEventHandler(vsAnalyserSource.FrameIn1); }
                    catch { }

                    // send processed images to function "FrameIn" for motion event smooting
                    try { vsAnalyserSource.FrameOut1 -= new VsImageEventHandler(vsEncoderSource.FrameIn); }
                    catch { }

                    vsVideoSource.SignalToStop();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

		// Wait video source for stop
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void WaitForStop()
		{
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null)
                {
                    vsVideoSource.WaitForStop();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // Abort camera
        // -----------------------------------------------------------------------------------------------------------------------
        public void Stop()
		{
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null)
                {
                    vsVideoSource.Stop();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
		}
	    #endregion

        #region Camera Controls

        public void GoHome()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.GoHome();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            finally 
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void PanLeft()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.PanLeft();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void PanRight()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.PanRight();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void TiltUp()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.TiltUp();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void TiltDown()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.TiltDown();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void ZoomIn()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.ZoomIn();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void ZoomOut()
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.ZoomOut();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void ZoomAt(int factor)
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.ZoomAt(factor);
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public void PanTilt(int x, int y)
        {
            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    vsVideoSource.PanTilt(x, y);
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                Monitor.Exit(syncCtrl);
            }
        }

        public bool IsPanTiltZoom()
        {
            bool ret = false;

            Monitor.Enter(syncCtrl);
            try
            {
                if (vsVideoSource != null && vsVideoSource.IsPanTiltZoom())
                {
                    ret = vsVideoSource.IsPanTiltZoom();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return ret;
        }  
        #endregion

        #region Process image

        // On new frame ready
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer.Count >= 1)
                {
                    VsImage rm = (VsImage)imgBuffer.Dequeue();
                    rm.Dispose(); rm = null;
                }

                VsImage img = (VsImage)e.Image.Clone();
                imgBuffer.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object stateInfo)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                // get new one
                if (imgBuffer.Count > 0)
                {
                    lastFrame = (VsImage)imgBuffer.Dequeue();
                }

                if (lastFrame != null)
                {
                    using (Graphics gb = Graphics.FromImage(lastFrame.Image))
                    {
                        SolidBrush drawRec = new SolidBrush(Color.Black);
                        gb.FillRectangle(drawRec, 0, 0, lastFrame.Image.Width, 16);
                        //gb.DrawImage(isysLogo, 3, 3, 15, 15);

                        DateTime date = DateTime.Now;

                        // Create font and brush
                        Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
                        SolidBrush drawBrush = new SolidBrush(Color.White);

                        gb.DrawString(date.ToString(), drawFont, drawBrush, new PointF(18, 0));
                        
                        drawBrush.Dispose();
                        drawFont.Dispose();
                        drawRec.Dispose();
                    }

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
                if(lastFrame != null) 
                    lastFrame.Dispose();
                lastFrame = null;
            }
        }

        // Get current
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Bitmap GetFrame()
        {
            try
            {
                if(lastFrame != null) return lastFrame.Image;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        #endregion

        #region Utility

		public override String ToString()
        {
            String desStr = "";
            
            try
            {
                 desStr = "Name: " + CameraName + ", " +
                    "Previewing: " + Previewing.ToString() + ", " +
                    "Streamming: " + Streaming.ToString() + ", " +
                    "Analysing: " + Analysing.ToString() + ", " +
                    "Recording: " + Recording.ToString() + ", " +
                    "DataAlerting: " + DataAlerting.ToString() + ", " +
                    "EventAlerting: " + EventAlerting.ToString();
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
