// xjfp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// myds	
// jmhq	 By downloading, copying, installing or using the software you agree to this license.
// njin	 If you do not agree to this license, do not download, install,
// goha	 copy or use the software.
// szdt	
// bslc	                          License Agreement
// xeqn	         For OpenVSS - Open Source Video Surveillance System
// zkmt	
// fchu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wnlf	
// injv	Third party copyrights are property of their respective owners.
// fdcn	
// kfmx	Redistribution and use in source and binary forms, with or without modification,
// gmou	are permitted provided that the following conditions are met:
// mbvf	
// vuqd	  * Redistribution's of source code must retain the above copyright notice,
// wohd	    this list of conditions and the following disclaimer.
// gmdf	
// oxln	  * Redistribution's in binary form must reproduce the above copyright notice,
// iqwu	    this list of conditions and the following disclaimer in the documentation
// cccu	    and/or other materials provided with the distribution.
// xpnt	
// onhu	  * Neither the name of the copyright holders nor the names of its contributors 
// rfkn	    may not be used to endorse or promote products derived from this software 
// xfyq	    without specific prior written permission.
// vzhx	
// bgii	This software is provided by the copyright holders and contributors "as is" and
// balw	any express or implied warranties, including, but not limited to, the implied
// ebdt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// svfg	In no event shall the Prince of Songkla University or contributors be liable 
// boot	for any direct, indirect, incidental, special, exemplary, or consequential damages
// finj	(including, but not limited to, procurement of substitute goods or services;
// nxqd	loss of use, data, or profits; or business interruption) however caused
// rfyc	and on any theory of liability, whether in contract, strict liability,
// vesr	or tort (including negligence or otherwise) arising in any way out of
// hesn	the use of this software, even if advised of the possibility of such damage.
// clqq	
// cqvb	Intelligent Systems Laboratory (iSys Lab)
// asph	Faculty of Engineering, Prince of Songkla University, THAILAND
// knss	Project leader by Nikom SUVONVORN
// szvd	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;

using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// Monitor Application Manager
	/// </summary>
	public class VsCoreApp : IDisposable
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        #region Definition

        // configuration file name
        private bool bSaveConfig = false;
        private string vsAppPath;
        private string vsSettingsFile;
        private string vsCamerasFile;
        private string vsChannelsFile;
        private string vsPagesFile;

        // Auto running
        protected int vsOpenType;
        protected int vsOpenItem;

        // Processing host
        protected string vsPcHost = "localhost";
        protected string vsPcDirt;

        // Database Server
        protected string vsDbHost = "localhost";
        protected string vsDbHostIP = "172.30.3.51";
        protected string vsDbUser = "kom";
        protected string vsDbPasswd = "eimhtsj4";
        protected string vsDbDatabase = "vsa-main";
        protected string vsDbDatabaseClient = "vsa-client";

        // Smtp Server
        protected string vsSmtpHost = "fivedots.coe.psu.ac.th ";
        protected string vsSmtpUser = "kom";
        protected string vsSmtpPasswd = "eimhtsj4230*)((";
        protected string vsEmailFrom = "kom@fivedots.coepsu.ac.th";
        protected string vsEmailTo = "kom@fivedots.coe.psu.ac.th";

        // Timer synchronization
        protected long vsSyncTimer = 100;

        // Action flags
        protected bool vsPreview = false;
        protected bool vsStream = false;
        protected bool vsAnalysis = false;
        protected bool vsRecord = false;
        protected bool vsDataAlert = false;
        protected bool vsEventAlert = false;
        protected bool bMailAlert = false;

        // main window size and position
        protected Point vsWindowLocation = new Point(100, 50);
        protected Size vsWindowSize = new Size(800, 600);

        // vsCameras tree view width and status
        protected bool vsShowCameraBar = true;
        protected int vsCameraBarWidth = 150;

        // display
        protected bool vsFitToScreen = false;
        protected bool vsFullScreen = false;

        // IDs generator
        private int vsNextCameraID = 1;
        private int vsNextChannelID = 1;
        private int vsNextPageID = 1;

        // Data receiving statistics
        protected const int vsStatLength = 15;
        protected int vsStatIndex = 0, vsStatReady = 0;
        protected long[] vsStatReceived = new long[vsStatLength];
        protected int[] vsStatCount = new int[vsStatLength];
        public float vsFps = 0, vsBps = 0;

        private System.Timers.Timer vsTimer;
        //private System.Timers.Timer dbTimer;
        private System.Timers.Timer dlTimer;

        // Connecting IDs reference
        //private int vsOpenID;
        //private bool vsCameraOpened;
        //private bool vsChannelOpened;
        //private bool vsPageOpened;

        ///
        // vsProviders
        protected readonly VsProviderCollection vsProviders = new VsProviderCollection();
        // vsAnalysers
        protected readonly VsAnalyzerCollection vsAnalysers = new VsAnalyzerCollection();
        // vsEncoders
        protected readonly VsEncoderCollection vsEncoders = new VsEncoderCollection();

        ///
        // vsCameras
        protected readonly VsCameraCollection vsCameras = new VsCameraCollection();
        // vsChannels
        protected readonly VsChannelCollection vsChannels = new VsChannelCollection();
        // vsPages
        protected readonly VsPageCollection vsPages = new VsPageCollection();

        ///
        // camera running pool
        private VsMonitorRunningPool vsRunningPool = new VsMonitorRunningPool();
        // camera finalizing pool
        private VsMonitorStoppingPool vsFinalizationPool = new VsMonitorStoppingPool();

        #endregion

        #region Properties

        // save/unsave configuration to file
        public bool SaveConfigToFile
        {
            get { return bSaveConfig; }
            set { bSaveConfig = value;}
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // Synchronization properties
        // -----------------------------------------------------------------------------------------------------------------------
        // SyncTimer property
        public long SyncTimer
        {
            get { return vsSyncTimer; }
            set { vsSyncTimer = value; }
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // Local host properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Localhost property
        public string LocalHost
        {
            get { return vsPcHost; }
            set { vsPcHost = value; }
        }

        // Data storage directory
        public string LocalStorage
        {
            get { return vsPcDirt; }
            set { vsPcDirt = value; }
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // Database host properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Database host property
        public string DataHost
        {
            get { return vsDbHost; }
            set { vsDbHost = value; }
        }

        // Data user property
        public string DataUser
        {
            get { return vsDbUser; }
            set { vsDbUser = value; }
        }

        // Data password property
        public string DataPasswd
        {
            get { return vsDbPasswd; }
            set { vsDbPasswd = value; }
        }

        // Data database property
        public string DataDatabase
        {
            get { return vsDbDatabase; }
            set { vsDbDatabase = value; }
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // Action flags properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Previewing property
        public bool Previewing
        {
            get { return vsPreview; }
            set { vsPreview = value; }
        }

        // Streaming property
        public bool Streaming
        {
            get { return vsStream; }
            set { vsStream = value; }
        }

        // Analysing property
        public bool Analysing
        {
            get { return vsAnalysis; }
            set { vsAnalysis = value; }
        }

        // Recording property
        public bool Recording
        {
            get { return vsRecord; }
            set { vsRecord = value; }
        }

        // DataAlerting property
        public bool DataAlerting
        {
            get { return vsDataAlert; }
            set { vsDataAlert = value; }
        }

        // EventAlerting property
        public bool EventAlerting
        {
            get { return vsEventAlert; }
            set { vsEventAlert = value; }
        }

        #region Email Server properties
        // SmtpHost property
        public string SmtpHost
        {
            get { return vsSmtpHost; }
            set { vsSmtpHost = value; }
        }

        // SmtpUser property
        public string SmtpUser
        {
            get { return vsSmtpUser; }
            set { vsSmtpUser = value; }
        }

        // SmtpPasswd property
        public string SmtpPasswd
        {
            get { return vsSmtpPasswd; }
            set { vsSmtpPasswd = value; }
        }

        // EmailFrom property
        public string EmailFrom
        {
            get { return vsEmailFrom; }
            set { vsEmailFrom = value; }
        }

        // EmailTo property
        public string EmailTo
        {
            get { return vsEmailTo; }
            set { vsEmailTo = value; }
        }

        #endregion

        #endregion

        #region Constructor/Dispose

		// Constructor
        public VsCoreApp()
        {
            try
            {
                vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
                vsSettingsFile = Path.Combine(vsAppPath, "app.config");
                vsCamerasFile = Path.Combine(vsAppPath, "cameras.config");
                vsChannelsFile = Path.Combine(vsAppPath, "channels.config");
                vsPagesFile = Path.Combine(vsAppPath, "pages.config");
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public VsCoreApp(string path)
		{
            try
            {
                vsAppPath = path;
                vsSettingsFile = Path.Combine(vsAppPath, "app.config");
                vsCamerasFile = Path.Combine(vsAppPath, "cameras.config");
                vsChannelsFile = Path.Combine(vsAppPath, "channels.config");
                vsPagesFile = Path.Combine(vsAppPath, "pages.config");
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        public bool VsMonitorInitial()
        {
            try
            {
                vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
                vsSettingsFile = Path.Combine(vsAppPath, "app.config");
                vsCamerasFile = Path.Combine(vsAppPath, "cameras.config");
                vsChannelsFile = Path.Combine(vsAppPath, "channels.config");
                vsPagesFile = Path.Combine(vsAppPath, "pages.config");

                return VsMonitorLoad();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return false;
        }

        public bool VsMonitorInitial(string path)
        {
            try
            {
                string vsAppPath = path;
                vsSettingsFile = Path.Combine(vsAppPath, "app.config");
                vsCamerasFile = Path.Combine(vsAppPath, "cameras.config");
                vsChannelsFile = Path.Combine(vsAppPath, "channels.config");
                vsPagesFile = Path.Combine(vsAppPath, "pages.config");

                return VsMonitorLoad();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return false;
        }

        private bool VsMonitorLoad()
        {
            try
            {
                // load configuration
                if (!LoadSettings()) return false;

                // load providers
                vsProviders.Load(vsAppPath);

                // load analysers
                vsAnalysers.Load(vsAppPath);

                // load analysers
                vsEncoders.Load(vsAppPath);

                // load cameras 
                LoadCameras();

                // load channel 
                LoadChannels();

                // load page 
                LoadPages();

                // start finalization pool
                vsFinalizationPool.Start();

                // 
                // vsTimer
                // 
                this.vsTimer = new System.Timers.Timer();
                this.vsTimer.Interval = 1000;
                this.vsTimer.SynchronizingObject = null;
                this.vsTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.StatCounter);

                // 
                // dbTimer
                // 
                //this.dbTimer = new System.Timers.Timer();
                //this.dbTimer.Interval = 300000; // every 5 min.
                //this.dbTimer.SynchronizingObject = null;
                //this.dbTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.DbUpdate);
                //this.dbTimer.Start();

                // 
                // dlTimer
                // 
                this.dlTimer = new System.Timers.Timer();
                this.dlTimer.Interval = 900000; // every 15 min.
                this.dlTimer.SynchronizingObject = null;
                this.dlTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.DbDelete);
                this.dlTimer.Start();

                // set process to high priority
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return true;
        }

        public void SetApplicationPath(string path)
        {
            try
            {
                vsAppPath = path;
                vsSettingsFile = Path.Combine(vsAppPath, "app.config");
                vsCamerasFile = Path.Combine(vsAppPath, "cameras.config");
                vsChannelsFile = Path.Combine(vsAppPath, "channels.config");
                vsPagesFile = Path.Combine(vsAppPath, "pages.config");
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Clean up any resources being used.
        public void Dispose()
        {
            Dispose(true);
        }

        // Clean up any resources being used.
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (vsTimer != null)
                    {
                        vsTimer.Dispose();
                        vsTimer = null;
                    }

                    //if (dbTimer != null)
                    //{
                    //    dbTimer.Dispose();
                    //    dbTimer = null;
                    //}

                    if (dlTimer != null)
                    {
                        dlTimer.Dispose();
                        dlTimer = null;
                    }

                    VsMonitorManagerClose();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Closing 
        private void VsMonitorManagerClose()
        {
            try
            {
                SaveSettings();

                // disconnect all camera
                DisconnectChannelAll();

                // sleep for a while - give a chance for cameras to stop
                Thread.Sleep(500);

                // stop finalization pool
                vsFinalizationPool.Stop();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

	    #endregion    
    
        #region Statistic counter
        // On vsTimer event - gather statistic
        private void StatCounter(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (vsRunningPool.Count != 0)
                {
                    vsFps = 0;
                    vsBps = 0;

                    // get number of frames and bytes received for the last second
                    vsStatCount[vsStatIndex] = 0;
                    vsStatReceived[vsStatIndex] = 0;
                    foreach (VsCamera camera in vsRunningPool)
                    {
                        vsStatCount[vsStatIndex] += camera.FramesReceived;
                        vsStatReceived[vsStatIndex] += camera.BytesReceived;
                    }

                    // increment indexes
                    if (++vsStatIndex >= vsStatLength)
                        vsStatIndex = 0;
                    if (vsStatReady < vsStatLength)
                        vsStatReady++;

                    // calculate average value
                    for (int i = 0; i < vsStatReady; i++)
                    {
                        vsFps += vsStatCount[i];
                        vsBps += vsStatReceived[i];
                    }
                    vsFps /= vsStatReady;
                    vsBps /= (vsStatReady * 1024);

                    vsStatReceived[vsStatIndex] = 0;
                    vsStatCount[vsStatIndex] = 0;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            //infoPanel.Text = " Preview : " + vsConfig.Previewing.ToString() +
            //", Analyse : " + vsConfig.Analysing.ToString() +
            //", Record : " + vsConfig.Recording.ToString() +
            //", EventAlert : " + vsConfig.EventAlerting.ToString() +
            //", DataAlert : " + vsConfig.DataAlerting.ToString();
        }

        #endregion

        #region Database Update
        // On vsTimer event - database update
        private void DbUpdate(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                string appFile = string.Format("VsDbUpdate.exe");

                System.Diagnostics.Process vsProcess;
                vsProcess = new System.Diagnostics.Process();

                string sysFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8)); ;
                vsProcess.StartInfo.FileName = "cmd.exe";
                vsProcess.StartInfo.Arguments = "/C cd " + sysFolder + " && " + appFile + " && exit";
                vsProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                vsProcess.StartInfo.CreateNoWindow = true;
                vsProcess.Start();
                vsProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                vsProcess.WaitForExit();
                vsProcess.Close();
                vsProcess.Dispose();
                vsProcess = null;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        #endregion

        #region Database Delete
        // On vsTimer event - database delete
        private void DbDelete(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DateTime vsDate = DateTime.Now;
                int vsMonths = -2;
                //vsDate = vsDate.AddMonths(vsMonths);
                vsDate = vsDate.AddDays(-5.0);

                string appFile = string.Format("VsUtility.exe delete \"{0}\"", vsDate.ToString("yyyy/MM/dd HH:mm:ss"));

                System.Diagnostics.Process vsProcess;
                vsProcess = new System.Diagnostics.Process();

                string sysFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8)); ;
                vsProcess.StartInfo.FileName = "cmd.exe";
                vsProcess.StartInfo.Arguments = "/C cd " + sysFolder + " && " + appFile + " && exit";
                vsProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                vsProcess.StartInfo.CreateNoWindow = true;
                vsProcess.Start();
                vsProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                vsProcess.WaitForExit();
                vsProcess.Close();
                vsProcess.Dispose();
                vsProcess = null;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        #endregion

        #region Providers

        // List Providers
        public String[] ListProviders()
        {
            try
            {

                String[] listProvider = new String[vsProviders.Count];
                int i = 0;
                foreach (VsProvider pv in vsProviders)
                {
                    listProvider[i] = pv.Name;
                    i++;
                }
                return listProvider;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

        // Get Provider By Name
        public VsProvider GetProviderByName(String providerName)
        {
            try
            {
                foreach (VsProvider pv in vsProviders)
                {
                    if (pv.Name == providerName)
                        return pv;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get provider parameters
        public String[] GetProviderParameters(String provName)
        {
            try
            {
                VsProvider vsProv = vsProviders.GetProviderByName(provName);

                // TODO... 
                // vsProv.GetParameters
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        #endregion

        #region Analyzers

        // List Analyzers
        public String[] ListAnalyzers()
        {
            try
            {
                String[] listAnalyzers = new String[vsAnalysers.Count];
                int i = 0;
                foreach (VsAnalyzer az in vsAnalysers)
                {
                    listAnalyzers[i] = az.Name;
                    i++;
                }
                return listAnalyzers;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get Analyzer By Name
        public VsAnalyzer GetAnalyzerByName(String analyzerName)
        {
            try
            {
                foreach (VsAnalyzer ay in vsAnalysers)
                {
                    if (ay.Name == analyzerName)
                        return ay;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get analyzer parameters
        public String[] GetAnalyzerParameters(String analyzerName)
        {
            try
            {
                VsAnalyzer vsAna = vsAnalysers.GetAnalyserByName(analyzerName);

                // TODO... 
                // vsAna.GetParameters
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        #endregion

        #region Encoders

        // List Encoders
        public String[] ListEncoders()
        {
            try
            {
                String[] listEncoders = new String[vsEncoders.Count];
                int i = 0;
                foreach (VsEncoder ed in vsEncoders)
                {
                    listEncoders[i] = ed.Name;
                    i++;
                }
                return listEncoders;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

        // Get Analyzer By Name
        public VsEncoder GetEncoderByName(String encoderName)
        {
            try
            {
                foreach (VsEncoder ed in vsEncoders)
                {
                    if (ed.Name == encoderName)
                        return ed;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get encoder parameters
        public String[] GetEncoderParameters(String encoderName)
        {
            try
            {
                VsEncoder vsEnc = vsEncoders.GetEncoderByName(encoderName);

                // TODO... 
                // vsAnaly.GetParameters
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        #endregion

        #region Add/Edit/Delete/Connect/Disconnect Camera

        // New camera
        public VsCamera NewCamera(String cameraName)
        {
            try
            {
                VsCamera vsCamera = new VsCamera(cameraName, SyncTimer);
                return vsCamera;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

        // Add camera
        public void AddCamera(VsCamera camera)
        {
            try
            {
                camera.CameraID = vsNextCameraID++;
                vsCameras.Add(camera);

                // save
                if (bSaveConfig) SaveCameras();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Add camera
        public VsCamera AddCamera(String cameraName,
            String providerName, Hashtable prividerConfig,
            String analyserName, Hashtable analyserConfig,
            String encoderName, Hashtable encoderConfig)
        {
            try
            {
                // if this name is already exist
                if (GetCameraByName(cameraName) != null)
                    return null;

                // create new camera
                VsCamera vsCamera = new VsCamera(cameraName, SyncTimer);

                // set provider
                vsCamera.Provider = vsProviders.GetProviderByName(providerName);
                if (vsCamera.Provider == null) return null;
                vsCamera.CameraConfiguration = vsCamera.Provider.LoadConfiguration(prividerConfig);
                if (vsCamera.CameraConfiguration == null) return null;

                // set analyser
                vsCamera.Analyser = vsAnalysers.GetAnalyserByName(analyserName);
                if (vsCamera.Analyser == null) return null;
                vsCamera.AnalyserConfiguration = vsCamera.Analyser.LoadConfiguration(analyserConfig);
                if (vsCamera.AnalyserConfiguration == null) return null;

                // set encoder
                vsCamera.Encoder = vsEncoders.GetEncoderByName(encoderName);
                if (vsCamera.Encoder == null) return null;
                vsCamera.EncoderConfiguration = vsCamera.Encoder.LoadConfiguration(encoderConfig);
                if (vsCamera.EncoderConfiguration == null) return null;

                // add camera
                AddCamera(vsCamera);
                return vsCamera;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        // Add camera
        public VsCamera AddCamera(String cameraName,
            String providerName, Hashtable prividerConfig)
        {
            try
            {
                // if this name is already exist
                if (GetCameraByName(cameraName) != null)
                    return null;

                // create new camera
                VsCamera vsCamera = new VsCamera(cameraName, SyncTimer);

                // set provider
                vsCamera.Provider = vsProviders.GetProviderByName(providerName);
                if (vsCamera.Provider == null) return null;
                vsCamera.CameraConfiguration = vsCamera.Provider.LoadConfiguration(prividerConfig);
                if (vsCamera.CameraConfiguration == null) return null;

                // set analyser
                Hashtable analyserConfig = new Hashtable();
                String analyserName = "VsMotionDetector.VsMotionDetectorDescription";
                analyserConfig.Add("AlgorithmName", "VsMotionDetectorDescription");
                analyserConfig.Add("MotionLevel", "0.012");

                vsCamera.Analyser = vsAnalysers.GetAnalyserByName(analyserName);
                if (vsCamera.Analyser == null) return null;
                vsCamera.AnalyserConfiguration = vsCamera.Analyser.LoadConfiguration(analyserConfig);
                if (vsCamera.AnalyserConfiguration == null) return null;

                // set encoder
                Hashtable encoderConfig = new Hashtable();
                String encoderName = "VsAviEncoder.VsAviEncoderDescription";
                encoderConfig.Add("ImageWidth", "320");
                encoderConfig.Add("ImageHeight", "240");
                encoderConfig.Add("CodecsName", "Windows Media Codecs 9.0");
                encoderConfig.Add("Quality", "100");

                vsCamera.Encoder = vsEncoders.GetEncoderByName(encoderName);
                if (vsCamera.Encoder == null) return null;
                vsCamera.EncoderConfiguration = vsCamera.Encoder.LoadConfiguration(encoderConfig);
                if (vsCamera.EncoderConfiguration == null) return null;

                // add camera
                AddCamera(vsCamera);

                return vsCamera;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // Set camera provider 
        public bool SetCameraProvider(String cameraName, String providerName)
        {
            try
            {
                // get camera
                VsCamera vsCamera = GetCameraByName(cameraName);
                if (vsCamera == null) return false;

                // set provider
                vsCamera.Provider = GetProviderByName(providerName);
                if (vsCamera.Provider == null) return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Set camera analyzer 
        public bool SetCameraAnalyzer(String cameraName, String analyzerName)
        {
            try
            {
                // get camera
                VsCamera vsCamera = GetCameraByName(cameraName);
                if (vsCamera == null) return false;

                // set analyzer
                vsCamera.Analyser = GetAnalyzerByName(analyzerName);
                if (vsCamera.Analyser == null) return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Set camera encoder 
        public bool SetCameraEncoder(String cameraName, String encoderName)
        {
            try
            {
                // get camera
                VsCamera vsCamera = GetCameraByName(cameraName);
                if (vsCamera == null) return false;

                // set analyzer
                vsCamera.Encoder = GetEncoderByName(encoderName);
                if (vsCamera.Encoder == null) return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Edit camera
        public VsCamera EditCamera(String cameraName)
        {
            try
            {
                // get camera
                VsCamera vsCameraToEdit = GetCameraByName(cameraName);

                // edit camera


                // save
                if (bSaveConfig) SaveCameras();

                return vsCameraToEdit;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // Delete camera
        public bool DeleteCamera(VsCamera camera)
        {
            try
            {
                // delete from list
                vsCameras.Remove(camera);

                // save
                if (bSaveConfig) SaveCameras();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Delete camera
        public void DeleteCamera(String cameraName)
        {
            try
            {
                // get camera
                VsCamera vsCamera = GetCameraByName(cameraName);

                if (vsCamera != null)
                {
                    // disconnect camera
                    DisconnectCamera(cameraName);

                    // delete the camera
                    DeleteCamera(vsCamera);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete camera all
        public void DeleteCameraAll()
        {
            try
            {
                while(vsCameras.Count != 0)
                {
                    DeleteCamera(vsCameras[0].CameraName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Connecting 
        public bool ConnectingCamera(string cameraName)
        {
            try
            {
                // get camera
                VsCamera vsCamera = GetCameraByName(cameraName);

                if (vsCamera == null) return false;

                // test
                return vsCamera.Running;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return false;
        }

        // Connect camera
        public bool ConnectCamera(String cameraName, bool bStream)
        {
            try
            {
                // get camera
                VsCamera vsCamera = GetCameraByName(cameraName);

                // running
                if (vsCamera.Running) return false;

                // abort the camera, if it is in finalization pool
                vsFinalizationPool.Remove(vsCamera);

                // add camera to running pool
                if (vsRunningPool.Add(vsCamera))
                {
                    // stream
                    vsCamera.Streaming = bStream;

                    // reset statistics indexes
                    vsStatIndex = 0;
                    vsStatReady = 0;

                    // start vsTimer
                    vsTimer.Start();
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        // Disconnect camera
        public bool DisconnectCamera(String cameraName)
        {
            try
            {
                VsCamera vsCamera = GetCameraByName(cameraName);

                if (vsCamera != null)
                {
                    // stop vsTimer
                    if(vsTimer != null)
                        vsTimer.Stop();

                    // disconnect all
                    vsCamera.DataAlerting = false;
                    vsCamera.EventAlerting = false;
                    vsCamera.Recording = false;
                    vsCamera.Analysing = false;
                    vsCamera.Streaming = false;

                    // remove camera from running pool
                    vsRunningPool.Remove(vsCamera);

                    // add camera to finilization pool
                    vsFinalizationPool.Add(vsCamera);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        // Disconnect camera all
        public void DisconnectCameraAll()
        {
            try
            {
                for( int i=0; i< vsCameras.Count; i++)
                {
                    DisconnectCamera(vsCameras[i].CameraName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Get camera by name
        public VsCamera GetCameraByName(string name)
        {
            try
            {
                string[] nameParts = name.Split('\\');

                // get camera
                return vsCameras.GetCameraByName(nameParts[nameParts.Length - 1]);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get camera by id
        public VsCamera GetCameraByID(int camID)
        {
            try
            {

                // get camera
                return vsCameras.GetCameraByID(camID);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get camera by ip adress
        public VsCamera GetCameraByIP(string ip)
        {
            try
            {
                // get camera
                return vsCameras.GetCameraByIP(ip);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Change Camera Name
        public bool ChangeCameraName(String cameraName, String newName)
        {
            try
            {
                VsCamera vsCamera = GetCameraByName(cameraName);
                if (vsCamera == null) return false;

                vsCamera.CameraName = newName;

                return true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return false;
        }

        // Check camera
        public bool CheckCamera(VsCamera camera)
        {
            try
            {
                foreach (VsCamera c in vsCameras)
                {
                    if ((camera.CameraName == c.CameraName) && ((camera.CameraID == 0) || (camera.CameraID != c.CameraID)))
                        return false;
                }
                return true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return false;
        }

        // List camera
        public String[] ListCameras()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName;
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Attach camera to view
        public bool AttachCameraView(String cameraName, VsAppInterface vsApp)
        {
            try
            {
                VsCamera vsCam = vsCameras.GetCameraByName(cameraName);

                return vsCam.AttachCameraView(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Detach camera from view
        public bool DetachCameraView(String cameraName, VsAppInterface vsApp)
        {
            try
            {
                VsCamera vsCam = vsCameras.GetCameraByName(cameraName);

                return vsCam.DetachCameraView(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Attach camera to view analyzer
        public bool AttachCameraViewAnalyzer(String cameraName, VsAppInterface vsApp)
        {
            try
            {
                VsCamera vsCam = vsCameras.GetCameraByName(cameraName);

                return vsCam.AttachCameraViewAnalyzer(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return false;
        }

        // Detach camera from view analyzer
        public bool DetachCameraViewAnalyzer(String cameraName, VsAppInterface vsApp)
        {
            try
            {
                VsCamera vsCam = vsCameras.GetCameraByName(cameraName);

                return vsCam.DetachCameraViewAnalyzer(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return false;
        }

        // Attach event to view
        public bool AttachEventView(String cameraName, VsEventInterface vsEvent)
        {
            try
            {
                VsCamera vsCam = vsCameras.GetCameraByName(cameraName);

                return vsCam.AttachEventView(vsEvent);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Detach event from view
        public bool DetachEventView(String cameraName, VsEventInterface vsEvent)
        {
            try
            {
                VsCamera vsCam = vsCameras.GetCameraByName(cameraName);

                return vsCam.DetachEventView(vsEvent);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }
        #endregion

        #region Add/Edit/Delete/Connect/Disconnect Channel

        // Add channel
        public void AddChannel(VsChannel channel)
        {
            try
            {
                // add channel
                channel.ChannelID = vsNextChannelID++;
                vsChannels.Add(channel);

                // save
                if (bSaveConfig) SaveChannels();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Add channel
        public VsChannel AddChannel(String channelName, int width, int height, int quality)
        {
            try
            {
                // if this name is already exist
                if (GetChannelByName(channelName) != null)
                    return null;

                VsChannel vsChannel = new VsChannel(channelName, SyncTimer, width, height, quality);

                AddChannel(vsChannel);

                return vsChannel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // Add channel
        public bool AddChannel(String channelName, String[] cameraList)
        {
            try
            {
                // if this name is already exist
                if (GetChannelByName(channelName) != null)
                    return false;

                VsChannel vsChannel = new VsChannel(channelName, SyncTimer);

                // set layout
                vsChannel.SetLayout(ChannelLayout.TH_GRID_1);
                vsChannel.Rows = 5;
                vsChannel.Cols = 5;

                foreach (String cameraName in cameraList)
                {
                    VsCamera vsCam = GetCameraByName(cameraName);
                    if (vsCam != null)
                        vsChannel.SetCamera(vsCam.CameraID, vsCam);
                }

                // add to views collection
                AddChannel(vsChannel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Edit channel
        public VsChannel EditChannel(String channelName)
        {
            try
            {
                // get channel to edit
                VsChannel vsChannelToEditt = GetChannelByName(channelName);

                // TODO ...

                // modified it
                if (bSaveConfig) SaveChannels();

                return vsChannelToEditt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //  Delete channel
        public bool DeleteChannel(VsChannel channel)
        {
            try
            {
                vsChannels.Remove(channel);

                // save
                if (bSaveConfig) SaveChannels();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }
        
        //  Delete channel
        public void DeleteChannel(String channelName)
        {
            try
            {
                // get channel to delete
                VsChannel vsChannel = GetChannelByName(channelName);

                if (vsChannel != null)
                {
                    // disconnect channel
                    DisconnectChannel(channelName);

                    // delete it
                    DeleteChannel(vsChannel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //  Delete channel all
        public void DeleteChannelAll()
        {
            try
            {
                while (vsChannels.Count != 0)
                {
                    DeleteChannel(vsChannels[0].ChannelName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Connecting 
        public bool ConnectingChannel(string channelName)
        {
            try
            {
                // get channel to delete
                VsChannel vsChannel = GetChannelByName(channelName);

                if (vsChannel == null) return false;

                // test
                return vsChannel.Running;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Connect channel
        public bool ConnectChannel(string channelName, bool bStream)
        {
            try
            {
                // get channel to delete
                VsChannel vsChannel = GetChannelByName(channelName);

                // connect all cameras
                foreach(CameraList cl in vsChannel.vsCameraList)
                {
                    VsCamera vsCamera = cl.CameraHandler;
                    if (vsCamera != null && !ConnectingCamera(vsCamera.CameraName))
                    {
                        ConnectCamera(vsCamera.CameraName, false);
                    }
                }

                // reset statistics indexes
                vsStatIndex = 0;
                vsStatReady = 0;

                // start
                vsChannel.Start(bStream);

                // start vsTimer
                vsTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Start Stream Channel
        public bool StartStreamChannel(string channelName, string ipAddress, int portNumber)
        {
            try
            {
                // get channel to stream
                VsChannel vsChannel = GetChannelByName(channelName);
                if (vsChannel == null || vsChannel.Streaming) return false;

                vsChannel.MulticastAddress = ipAddress;
                vsChannel.StreamerVideoPort = portNumber;
                vsChannel.Streaming = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Stop Stream Channel
        public bool StopStreamChannel(string channelName)
        {
            try
            {
                // get channel to stream
                VsChannel vsChannel = GetChannelByName(channelName);
                if (vsChannel == null || !vsChannel.Streaming) return false;

                vsChannel.Streaming = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Disconnect channel
        public bool DisconnectChannel(string channelName)
        {
            try
            {
                VsChannel vsChannel = GetChannelByName(channelName);

                if (vsChannel != null)
                {
                    // disconnect all cameras
                    foreach(CameraList cl in vsChannel.vsCameraList)
                    {
                        VsCamera vsCamera = cl.CameraHandler;
                        //if (vsCamera != null) DisconnectCamera(vsCamera.CameraName);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        // Disconnect channel all
        public void DisconnectChannelAll()
        {
            try
            {
                for(int i=0; i< vsChannels.Count ; i++)
                {
                    DisconnectChannel(vsChannels[i].ChannelName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Attach channel to view
        public bool AttachChannelView(String channelName, VsAppInterface vsApp)
        {
            try
            {
                VsChannel vsChannel = GetChannelByName(channelName);

                return vsChannel.AttachChannelView(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Detach channel from view
        public bool DetachChannelView(String channelName, VsAppInterface vsApp)
        {
            try
            {
                VsChannel vsChannel = GetChannelByName(channelName);

                return vsChannel.DetachChannelView(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Attach channel to view analyzer
        public bool AttachChannelViewAnalyzer(String channelName, VsAppInterface vsApp)
        {
            try
            {
                VsChannel vsChannel = GetChannelByName(channelName);

                return vsChannel.AttachChannelViewAnalyzer(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Detach channel from view analyzer
        public bool DetachChannelViewAnalyzer(String channelName, VsAppInterface vsApp)
        {
            try
            {
                VsChannel vsChannel = GetChannelByName(channelName);

                return vsChannel.DetachChannelViewAnalyzer(vsApp);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // Get view by name
        public VsChannel GetChannelByName(string name)
        {
            try
            {
                string[] nameParts = name.Split('\\');

                // get camera
                return vsChannels.GetChannel(nameParts[nameParts.Length - 1]);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Get view by name
        public VsChannel GetChannelByID(int ID)
        {
            try
            {
                // get camera
                return vsChannels.GetChannel(ID);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

        // Check channel
        public bool CheckChannel(VsChannel channel)
        {
            try
            {
                foreach (VsChannel v in vsChannels)
                {
                    if ((channel.ChannelName == v.ChannelName) && ((channel.ChannelID == 0) || (channel.ChannelID != v.ChannelID)))
                        return false;
                }
                return true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // List channel
        public String[] ListChannels()
        {
            try
            {
                String[] listChannel = new String[vsChannels.Count];
                int i = 0;
                foreach (VsChannel cn in vsChannels)
                {
                    listChannel[i] = cn.ChannelName;
                    i++;
                }
                return listChannel;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        #endregion

        #region Add/Edit/Delete/Connect/Disconnect Page

        // Add new page
        public void AddPage(VsPage page)
        {
            try
            {
                page.PageID = vsNextPageID++;
                vsPages.Add(page);

                // save
                if (bSaveConfig) SavePages();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Add channel
        public bool AddPage(String pageName, String[] channelList)
        {
            try
            {
                // if this name is already exist
                if (GetPageByName(pageName) != null)
                    return false;

                VsPage vsPage = new VsPage(pageName, SyncTimer);

                foreach (String channelName in channelList)
                {
                    VsChannel vsChannel = GetChannelByName(channelName);
                    if (vsChannel != null)
                        vsPage.SetChannel(vsChannel.ChannelID, vsChannel);
                }

                // add to page collection
                AddPage(vsPage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        // Edit channel
        public VsPage EditPage(String channelName)
        {
            try
            {
                // get channel to edit
                VsPage vsPageToEditt = GetPageByName(channelName);

                // TODO ...

                // modified it
                if (bSaveConfig) SavePages();

                return vsPageToEditt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //  Delete page
        public bool DeletePage(VsPage page)
        {
            try
            {
                vsPages.Remove(page);

                // save
                if (bSaveConfig) SavePages();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        //  Delete page
        public void DeletePage(String pageName)
        {
            try
            {
                // get page to delete
                VsPage vsPage = GetPageByName(pageName);

                if (vsPage != null)
                {
                    // disconnect page
                    DisconnectPage(pageName);

                    // delete it
                    DeletePage(vsPage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //  Delete page all
        public void DeletePageAll()
        {
            try
            {
                while (vsPages.Count != 0)
                {
                    DeletePage(vsPages[0].PageName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool ConnectingPage(string pageName)
        {
            try
            {
                // get page to delete
                VsPage vsPage = GetPageByName(pageName);

                // check if it is already running
                //if ((vsPageOpened == true) && (vsOpenID == vsPage.PageID))
                //    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        // Connect page
        public bool ConnectPage(string pageName, bool bStream)
        {
            try
            {
                // get page to delete
                VsPage vsPage = GetPageByName(pageName);

                // check if it is already running
                //if ((vsPageOpened == true) && (vsOpenID == vsPage.PageID))
                //    return false;

                // connect all channels

                foreach (ChannelList cl in vsPage.vsChannelList)
                {
                    VsChannel vsChannel = cl.ChannelHandler;
                    if (vsChannel != null) ConnectChannel(vsChannel.ChannelName, false);
                }

                // reset statistics indexes
                vsStatIndex = 0;
                vsStatReady = 0;

                // set current 
                //vsOpenID = vsPage.PageID;
                //vsCameraOpened = false;
                //vsChannelOpened = true;
                //vsPageOpened = false;

                // TODO....
                // vsPage.Streaming = bStream

                // start vsTimer
                vsTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        // Disconnect page
        public bool DisconnectPage(string pageName)
        {
            try
            {
                VsPage vsPage = GetPageByName(pageName);

                //if ((vsPage != null) && vsPageOpened && (vsOpenID == vsPage.PageID))
                if (vsPage != null)
                {
                    // disconnect all pages
                    foreach (ChannelList cl in vsPage.vsChannelList)
                    {
                        VsChannel vsChannel = cl.ChannelHandler;
                        if (vsChannel != null) DisconnectChannel(vsChannel.ChannelName);
                    }

                    // re - initial value
                    //vsOpenID = -1;
                    //vsCameraOpened = false;
                    //vsChannelOpened = false;
                    //vsPageOpened = false;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        // Disconnect page all
        public void DisconnectPageAll()
        {
            try
            {
                for (int i = 0; i < vsPages.Count; i++)
                {
                    DisconnectPage(vsPages[i].PageName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Get page by name
        public VsPage GetPageByName(string name)
        {
            try
            {
                string[] nameParts = name.Split('\\');

                // get page
                return vsPages.GetPage(nameParts[nameParts.Length - 1]);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

        // Get page by ID
        public VsPage GetPageByID(int pageID)
        {
            try
            {
                // get page
                return vsPages.GetPage(pageID);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Check page
        public bool CheckPage(VsPage page)
        {
            try
            {
                foreach (VsPage p in vsPages)
                {
                    if ((page.PageName == p.PageName) && ((page.PageID == 0) || (page.PageID != p.PageID)))
                        return false;
                }
                return true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return false;
        }

        // List page
        public String[] ListPages()
        {
            try
            {
                String[] listPage = new String[vsPages.Count];
                int i = 0;
                foreach (VsPage cn in vsPages)
                {
                    listPage[i] = cn.PageName;
                    i++;
                }
                return listPage;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }
     
        #endregion

        #region Save/Load Application Setting
        
        // Save application settings
        public void SaveSettings()
        {
            try
            {
                if (vsSettingsFile == null) return;
                // open file
                FileStream fs = new FileStream(vsSettingsFile, FileMode.Create);
                // create XML writer
                XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

                // use indenting for readability
                xmlOut.Formatting = Formatting.Indented;

                // start document
                xmlOut.WriteStartDocument();
                xmlOut.WriteComment("Visual Surveillance System configuration file");

                // main node
                xmlOut.WriteStartElement("Application");

                // main window node
                xmlOut.WriteStartElement("MainWindow");
                xmlOut.WriteAttributeString("x", vsWindowLocation.X.ToString());
                xmlOut.WriteAttributeString("y", vsWindowLocation.Y.ToString());
                xmlOut.WriteAttributeString("width", vsWindowSize.Width.ToString());
                xmlOut.WriteAttributeString("height", vsWindowSize.Height.ToString());
                xmlOut.WriteAttributeString("cameraBar", vsShowCameraBar.ToString());
                xmlOut.WriteAttributeString("vsCameraBarWidth", vsCameraBarWidth.ToString());
                xmlOut.WriteEndElement();

                // Auto run (camera, channel, or page)
                xmlOut.WriteStartElement("Autorun");
                xmlOut.WriteAttributeString("Type", vsOpenType.ToString());
                xmlOut.WriteAttributeString("Item", vsOpenItem.ToString());
                xmlOut.WriteEndElement();

                // localhost node
                xmlOut.WriteStartElement("LocalHost");
                xmlOut.WriteAttributeString("Host", vsPcHost);
                xmlOut.WriteAttributeString("Storage", vsPcDirt);
                xmlOut.WriteEndElement();

                // datahost node
                xmlOut.WriteStartElement("DataHost");
                xmlOut.WriteAttributeString("Host", vsDbHost);
                xmlOut.WriteAttributeString("HostIP", vsDbHostIP);
                xmlOut.WriteAttributeString("User", vsDbUser);
                xmlOut.WriteAttributeString("Passwd", vsDbPasswd);
                xmlOut.WriteAttributeString("Database", vsDbDatabase);
                xmlOut.WriteAttributeString("DatabaseClient", vsDbDatabaseClient);
                xmlOut.WriteEndElement();

                // move to email node
                xmlOut.WriteStartElement("SmtpHost");
                xmlOut.WriteAttributeString("Host", vsSmtpHost);
                xmlOut.WriteAttributeString("User", vsSmtpUser);
                xmlOut.WriteAttributeString("Passwd", vsSmtpPasswd);
                xmlOut.WriteAttributeString("EmailFrom", vsEmailFrom);
                xmlOut.WriteAttributeString("EmailTo", vsEmailTo);
                xmlOut.WriteEndElement();

                // synchronization
                xmlOut.WriteStartElement("Synchronize");
                xmlOut.WriteAttributeString("Timer", vsSyncTimer.ToString());
                xmlOut.WriteEndElement();

                // actions
                xmlOut.WriteStartElement("Actions");
                xmlOut.WriteAttributeString("Previewing", vsPreview.ToString());
                xmlOut.WriteAttributeString("Streaming", vsStream.ToString());
                xmlOut.WriteAttributeString("Analysing", vsAnalysis.ToString());
                xmlOut.WriteAttributeString("Recording", vsRecord.ToString());
                xmlOut.WriteAttributeString("DataAlerting", vsDataAlert.ToString());
                xmlOut.WriteAttributeString("EventAlerting", vsEventAlert.ToString());
                xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                // close file
                xmlOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Load application settings
        public bool LoadSettings()
        {
            bool ret = false;

            // check file existance
            if (File.Exists(vsSettingsFile))
            {
                VsSplasher.Status = "Load setting...";

                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsSettingsFile, FileMode.Open);
                    // create XML reader
                    xmlIn = new XmlTextReader(fs);

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // check for main node
                    if (xmlIn.Name != "Application")
                        throw new ApplicationException("");

                    // ------------------------------------------------------------------------
                    // move to main window node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "MainWindow")
                        throw new ApplicationException("");

                    int x = Convert.ToInt32(xmlIn.GetAttribute("x"));
                    int y = Convert.ToInt32(xmlIn.GetAttribute("y"));
                    int width = Convert.ToInt32(xmlIn.GetAttribute("width"));
                    int height = Convert.ToInt32(xmlIn.GetAttribute("height"));

                    this.vsShowCameraBar = Convert.ToBoolean(xmlIn.GetAttribute("cameraBar"));
                    this.vsCameraBarWidth = Convert.ToInt32(xmlIn.GetAttribute("vsCameraBarWidth"));

                    // ------------------------------------------------------------------------
                    // move to Auto run (camera, channel, or page) node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Autorun")
                        throw new ApplicationException("");

                    this.vsOpenType = Convert.ToInt32(xmlIn.GetAttribute("Type"));
                    this.vsOpenItem = Convert.ToInt32(xmlIn.GetAttribute("Item"));

                    // ------------------------------------------------------------------------
                    // move to localhost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "LocalHost")
                        throw new ApplicationException("");

                    this.vsPcHost = xmlIn.GetAttribute("Host");
                    this.vsPcDirt = xmlIn.GetAttribute("Storage");

                    // ------------------------------------------------------------------------
                    // move to datahost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "DataHost")
                        throw new ApplicationException("");

                    this.vsDbHost = xmlIn.GetAttribute("Host");
                    this.vsDbHostIP = xmlIn.GetAttribute("HostIP");
                    this.vsDbUser = xmlIn.GetAttribute("User");
                    this.vsDbPasswd = xmlIn.GetAttribute("Passwd");
                    this.vsDbDatabase = xmlIn.GetAttribute("Database");
                    this.vsDbDatabaseClient = xmlIn.GetAttribute("DatabaseClient");

                    // ------------------------------------------------------------------------
                    // move to email node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "SmtpHost")
                        throw new ApplicationException("");

                    this.vsSmtpHost = xmlIn.GetAttribute("Host");
                    this.vsSmtpUser = xmlIn.GetAttribute("User");
                    this.vsSmtpPasswd = xmlIn.GetAttribute("Passwd");
                    this.vsEmailFrom = xmlIn.GetAttribute("EmailFrom");
                    this.vsEmailTo = xmlIn.GetAttribute("EmailTo");

                    //string test = VsCryptography.Decrypt(VsCryptography.Encrypt(vsSmtpPasswd, "nikom"), "nikom");

                    // ------------------------------------------------------------------------
                    // move to synchronization node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Synchronize")
                        throw new ApplicationException("");

                    this.vsSyncTimer = Convert.ToInt32(xmlIn.GetAttribute("Timer"));
                    if (this.vsSyncTimer == 0) this.vsSyncTimer = 100;

                    // ------------------------------------------------------------------------
                    // move to actions node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Actions")
                        throw new ApplicationException("");

                    this.vsPreview = Convert.ToBoolean(xmlIn.GetAttribute("Previewing"));
                    this.vsStream = Convert.ToBoolean(xmlIn.GetAttribute("Streaming"));
                    this.vsAnalysis = Convert.ToBoolean(xmlIn.GetAttribute("Analysing"));
                    this.vsRecord = Convert.ToBoolean(xmlIn.GetAttribute("Recording"));
                    this.vsDataAlert = Convert.ToBoolean(xmlIn.GetAttribute("DataAlerting"));
                    this.vsEventAlert = Convert.ToBoolean(xmlIn.GetAttribute("EventAlerting"));

                    // ------------------------------------------------------------------------
                    vsWindowLocation = new Point(x, y);
                    vsWindowSize = new Size(width, height);

                    ret = true;
                }
                // catch any exceptions
                catch (Exception)
                {
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
            return ret;
        } 
        #endregion

        #region Save/Load Cameras Setting
        // Save vsCameras list to file
        public void SaveCameras()
        {
            try
            {
                // open file
                FileStream fs = new FileStream(vsCamerasFile, FileMode.Create);
                // create XML writer
                XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

                // use indenting for readability
                xmlOut.Formatting = Formatting.Indented;

                // start document
                xmlOut.WriteStartDocument();

                // main node
                xmlOut.WriteStartElement("Cameras");

                // save all vsCameras
                SaveCameras(xmlOut);

                // close "Cameras" node
                xmlOut.WriteEndElement();

                // close file
                xmlOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // save vsCameras of the parent group
        private void SaveCameras(XmlTextWriter writer)
        {
            try
            {
                foreach (VsCamera camera in vsCameras)
                {
                    // new "Camera" node
                    writer.WriteStartElement("Camera");

                    // write node
                    writer.WriteAttributeString("id", camera.CameraID.ToString());
                    writer.WriteAttributeString("name", camera.CameraName);
                    writer.WriteAttributeString("desc", camera.CameraDescription);

                    // write status
                    writer.WriteAttributeString("run", camera.Running.ToString());
                    writer.WriteAttributeString("analyse", camera.Analysing.ToString());
                    writer.WriteAttributeString("record", camera.Recording.ToString());
                    writer.WriteAttributeString("event", camera.EventAlerting.ToString());
                    writer.WriteAttributeString("data", camera.DataAlerting.ToString());

                    if (camera.Provider != null)
                    {
                        // write provider name
                        writer.WriteAttributeString("provider", camera.Provider.ProviderName);

                        if (camera.CameraConfiguration != null)
                        {
                            // write camera configuration
                            camera.Provider.SaveConfiguration(writer, camera.CameraConfiguration);
                        }
                    }

                    if (camera.Analyser != null)
                    {
                        // write analyser name
                        writer.WriteAttributeString("analyzer", camera.Analyser.AnalyserName);

                        if (camera.AnalyserConfiguration != null)
                        {
                            // write camera configuration
                            camera.Analyser.SaveConfiguration(writer, camera.AnalyserConfiguration);
                        }
                    }

                    if (camera.Encoder != null)
                    {
                        // write encoder name
                        writer.WriteAttributeString("encoder", camera.Encoder.EncoderName);

                        if (camera.EncoderConfiguration != null)
                        {
                            // write camera configuration
                            camera.Encoder.SaveConfiguration(writer, camera.EncoderConfiguration);
                        }
                    }
                    // close "Camera" node
                    writer.WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Load vsCameras collection from file
        public void LoadCameras()
        {
            // check file existance
            if (File.Exists(vsCamerasFile))
            {
                VsSplasher.Status = "Load camera setting...";

                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsCamerasFile, FileMode.Open);
                    // create XML reader
                    xmlIn = new XmlTextReader(fs);

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // check for main node
                    if (xmlIn.Name != "Cameras")
                        throw new ApplicationException("");

                    // move to next node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    // load vsCameras
                    LoadCameras(xmlIn);
                }
                // catch any exceptions
                catch (Exception)
                {
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
        }

        // Load vsCameras
        private void LoadCameras(XmlTextReader reader)
        {
            try
            {
                // load all vsCameras
                while (reader.Name == "Camera")
                {
                    int depth = reader.Depth;
                    int vsId = int.Parse(reader.GetAttribute("id"));
                    string vsName = reader.GetAttribute("name");
                    string vsDesc = reader.GetAttribute("desc");
                    bool bRun = Convert.ToBoolean(reader.GetAttribute("run"));
                    bool bAnalysis = Convert.ToBoolean(reader.GetAttribute("analyse"));
                    bool bRecord = Convert.ToBoolean(reader.GetAttribute("record"));
                    bool bEventAlert = Convert.ToBoolean(reader.GetAttribute("event"));
                    bool bDataAlert = Convert.ToBoolean(reader.GetAttribute("data"));

                    // create new camera
                    VsCamera camera = new VsCamera(vsId, 
                        vsName, 
                        vsDesc,
                        vsSyncTimer,
                        vsPcHost, vsPcDirt,
                        vsDbHost, vsDbUser, vsDbPasswd, vsDbDatabase,
                        vsSmtpHost, vsSmtpUser, vsSmtpPasswd, vsEmailFrom, vsEmailTo,
                        vsPreview, vsStream, bAnalysis, bRecord, bEventAlert, bDataAlert, bMailAlert);

                    // camera configuration
                    camera.Provider = vsProviders.GetProviderByName(reader.GetAttribute("provider"));
                    camera.Analyser = vsAnalysers.GetAnalyserByName(reader.GetAttribute("analyzer"));
                    camera.Encoder = vsEncoders.GetEncoderByName(reader.GetAttribute("encoder"));

                    // load provider configuration
                    if (camera.Provider != null)
                        camera.CameraConfiguration = camera.Provider.LoadConfiguration(reader);

                    // load analyser configuration
                    if (camera.Analyser != null)
                        camera.AnalyserConfiguration = camera.Analyser.LoadConfiguration(reader);

                    // load encoder configuration
                    if (camera.Encoder != null)
                        camera.EncoderConfiguration = camera.Encoder.LoadConfiguration(reader);

                    // add camera
                    vsCameras.Add(camera);

                    if (camera.CameraID >= vsNextCameraID)
                        vsNextCameraID = camera.CameraID + 1;

                    // move to next node
                    reader.Read();

                    // move to next element node
                    while (reader.NodeType == XmlNodeType.EndElement)
                        reader.Read();
                    if (reader.Depth < depth)
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        #endregion

        #region Save/Load Channels Setting

        // Save vsChannels list to file
        public void SaveChannels()
        {
            try
            {
                VsSplasher.Status = "Load channels setting...";

                // open file
                FileStream fs = new FileStream(vsChannelsFile, FileMode.Create);
                // create XML writer
                XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

                // use indenting for readability
                xmlOut.Formatting = Formatting.Indented;

                // start document
                xmlOut.WriteStartDocument();

                // main node
                xmlOut.WriteStartElement("Channels");

                // save all vsCameras
                SaveChannels(xmlOut);

                // close "Channels" node
                xmlOut.WriteEndElement();

                // close file
                xmlOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // save vsChannels of the parent group
        private void SaveChannels(XmlTextWriter writer)
        {
            try
            {
                foreach (VsChannel view in vsChannels)
                {
                    // new "VsChannel" node
                    writer.WriteStartElement("Channel");

                    // write node
                    writer.WriteAttributeString("id", view.ChannelID.ToString());
                    writer.WriteAttributeString("name", view.ChannelName);
                    writer.WriteAttributeString("desc", view.Description);

                    // view size
                    writer.WriteAttributeString("rows", view.Rows.ToString());
                    writer.WriteAttributeString("cols", view.Cols.ToString());
                    writer.WriteAttributeString("width", view.CellWidth.ToString());
                    writer.WriteAttributeString("height", view.CellHeight.ToString());

                    // write vsCameras
                    int i=0;
                    string[] strIDs = new string[VsChannel.MaxCam];
                    foreach (CameraList cl in view.vsCameraList)
                    {
                        strIDs[i] = cl.CameraID.ToString();
                        i++;
                    }
                    writer.WriteAttributeString("cameras", string.Join(",", strIDs));

                    if (view.Analyser != null)
                    {
                        // write analyser name
                        writer.WriteAttributeString("analyzer", view.Analyser.AnalyserName);

                        if (view.AnalyserConfiguration != null)
                        {
                            // write camera configuration
                            view.Analyser.SaveConfiguration(writer, view.AnalyserConfiguration);
                        }
                    }

                    if (view.Encoder != null)
                    {
                        // write encoder name
                        writer.WriteAttributeString("encoder", view.Encoder.EncoderName);

                        if (view.EncoderConfiguration != null)
                        {
                            // write camera configuration
                            view.Encoder.SaveConfiguration(writer, view.EncoderConfiguration);
                        }
                    }

                    // close "VsChannel" node
                    writer.WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Load vsChannels collection from file
        public void LoadChannels()
        {
            // check file existance
            if (File.Exists(vsChannelsFile))
            {
                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsChannelsFile, FileMode.Open);
                    // create XML reader
                    xmlIn = new XmlTextReader(fs);

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // check for main node
                    if (xmlIn.Name != "Channels")
                        throw new ApplicationException("");

                    // move to next node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    // load vsChannels
                    LoadChannels(xmlIn);
                }
                // catch any exceptions
                catch (Exception)
                {
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
        }

        // Load vsChannels
        private void LoadChannels(XmlTextReader reader)
        {
            try
            {
                // load all vsChannels
                while (reader.Name == "Channel")
                {
                    int depth = reader.Depth;

                    // create new camera
                    VsChannel view = new VsChannel(reader.GetAttribute("name"), SyncTimer);

                    view.LocalHost = LocalHost;
                    view.LocalStorage = LocalStorage;
                    
                    view.ChannelID = int.Parse(reader.GetAttribute("id"));
                    view.Description = reader.GetAttribute("desc");

                    // view size
                    view.Rows = short.Parse(reader.GetAttribute("rows"));
                    view.Cols = short.Parse(reader.GetAttribute("cols"));
                    view.CellWidth = short.Parse(reader.GetAttribute("width"));
                    view.CellHeight = short.Parse(reader.GetAttribute("height"));

                    // read vsCameras
                    string[] strIDs = reader.GetAttribute("cameras").Split(',');
                    for (int i = 0; i < VsChannel.MaxCam; i++)
                    {
                        if (strIDs[i].Length > 0)
                        {
                            int id = int.Parse(strIDs[i]);
                            view.SetCamera(id, GetCameraByID(id));
                        }
                    }

                    view.SetLayout(ChannelLayout.TH_GRID_1);

                    // view configuration
                    view.Analyser = vsAnalysers.GetAnalyserByName(reader.GetAttribute("analyzer"));
                    view.Encoder = vsEncoders.GetEncoderByName(reader.GetAttribute("encoder"));

                    // load analyser configuration
                    if (view.Analyser != null)
                        view.AnalyserConfiguration = view.Analyser.LoadConfiguration(reader);

                    // load encoder configuration
                    if (view.Encoder != null)
                        view.EncoderConfiguration = view.Encoder.LoadConfiguration(reader);

                    // add view
                    vsChannels.Add(view);

                    if (view.ChannelID >= vsNextChannelID)
                        vsNextChannelID = view.ChannelID + 1;

                    // move to next node
                    reader.Read();

                    // move to next element node
                    while (reader.NodeType == XmlNodeType.EndElement)
                        reader.Read();
                    if (reader.Depth < depth)
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        #endregion

        #region Save/Load Pages Setting
		        // Save vsPages list to file
        public void SavePages()
        {
            try
            {
                // open file
                FileStream fs = new FileStream(vsPagesFile, FileMode.Create);
                // create XML writer
                XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

                // use indenting for readability
                xmlOut.Formatting = Formatting.Indented;

                // start document
                xmlOut.WriteStartDocument();

                // main node
                xmlOut.WriteStartElement("Pages");

                // save all vsCameras
                SavePages(xmlOut);

                // close "Channels" node
                xmlOut.WriteEndElement();

                // close file
                xmlOut.Close();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // save vsPages of the parent group
        private void SavePages(XmlTextWriter writer)
        {
            try
            {
                foreach (VsPage page in vsPages)
                {
                    // new "VsPage" node
                    writer.WriteStartElement("Page");

                    // write node
                    writer.WriteAttributeString("id", page.PageID.ToString());
                    writer.WriteAttributeString("name", page.PageName);
                    writer.WriteAttributeString("desc", page.Description);

                    // write vsChannel
                    int i = 0;
                    string[] strIDs = new string[VsPage.MaxChannel];
                    foreach (ChannelList cl in page.vsChannelList)
                    {
                        strIDs[i] = cl.ChannelID.ToString();
                        i++;
                    }
                    writer.WriteAttributeString("channels", string.Join(",", strIDs));

                    // close "VsPage" node
                    writer.WriteEndElement();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Load vsPages collection from file
        public void LoadPages()
        {
            // check file existance
            if (File.Exists(vsPagesFile))
            {
                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsPagesFile, FileMode.Open);
                    // create XML reader
                    xmlIn = new XmlTextReader(fs);

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // check for main node
                    if (xmlIn.Name != "Pages")
                        throw new ApplicationException("");

                    // move to next node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    // load vsPages
                    LoadPages(xmlIn);
                }
                // catch any exceptions
                catch (Exception)
                {
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
        }

        // Load vsPages
        private void LoadPages(XmlTextReader reader)
        {
            try
            {
                // load all vsPages
                while (reader.Name == "Page")
                {
                    int depth = reader.Depth;

                    // create new camera
                    VsPage page = new VsPage(reader.GetAttribute("name"), SyncTimer);

                    page.PageID = int.Parse(reader.GetAttribute("id"));
                    page.Description = reader.GetAttribute("desc");

                    // read vsCameras
                    string[] strIDs = reader.GetAttribute("channels").Split(',');

                    for (int i = 0; i < VsPage.MaxChannel; i++)
                    {
                        int id = int.Parse(strIDs[i]);
                        page.SetChannel(id, GetChannelByID(id));
                    }

                    // add page
                    vsPages.Add(page);

                    if (page.PageID >= vsNextPageID)
                        vsNextPageID = page.PageID + 1;

                    // move to next node
                    reader.Read();

                    // move to next element node
                    while (reader.NodeType == XmlNodeType.EndElement)
                        reader.Read();
                    if (reader.Depth < depth)
                        return;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }
	    #endregion	
    }
}
