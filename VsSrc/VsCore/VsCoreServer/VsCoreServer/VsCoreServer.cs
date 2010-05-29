// rdhq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bjis	
// jlkb	 By downloading, copying, installing or using the software you agree to this license.
// rqug	 If you do not agree to this license, do not download, install,
// syul	 copy or use the software.
// vjwc	
// bmhs	                          License Agreement
// kqzs	         For OpenVSS - Open Source Video Surveillance System
// igff	
// esst	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dxne	
// drza	Third party copyrights are property of their respective owners.
// ickg	
// rivi	Redistribution and use in source and binary forms, with or without modification,
// geoo	are permitted provided that the following conditions are met:
// bpht	
// mssk	  * Redistribution's of source code must retain the above copyright notice,
// lpbz	    this list of conditions and the following disclaimer.
// faiy	
// wryj	  * Redistribution's in binary form must reproduce the above copyright notice,
// mhkh	    this list of conditions and the following disclaimer in the documentation
// gsaa	    and/or other materials provided with the distribution.
// lxyz	
// edsn	  * Neither the name of the copyright holders nor the names of its contributors 
// ptsl	    may not be used to endorse or promote products derived from this software 
// zpot	    without specific prior written permission.
// akbr	
// axmp	This software is provided by the copyright holders and contributors "as is" and
// ffct	any express or implied warranties, including, but not limited to, the implied
// eznt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rszn	In no event shall the Prince of Songkla University or contributors be liable 
// qcvb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// iuic	(including, but not limited to, procurement of substitute goods or services;
// znkx	loss of use, data, or profits; or business interruption) however caused
// trhv	and on any theory of liability, whether in contract, strict liability,
// rjzn	or tort (including negligence or otherwise) arising in any way out of
// ljuz	the use of this software, even if advised of the possibility of such damage.
// ayip	
// gyug	Intelligent Systems Laboratory (iSys Lab)
// pbcy	Faculty of Engineering, Prince of Songkla University, THAILAND
// ozig	Project leader by Nikom SUVONVORN
// pjps	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using Vs.Core;
using System.Globalization;
using NLog; 

namespace Vs.Core.Server
{
	/// <summary>
	/// Monitor Application Manager
	/// </summary>
    public sealed class VsCoreServer : VsCoreApp
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        #region Definition
        private static VsCoreServer instance = null;
        private static readonly object padlock = new object();
        #endregion

        #region Properties
        public static VsCoreServer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new VsCoreServer();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Constructor/Dispose

		// Constructor
        public VsCoreServer() : base()
        {
        }

		public VsCoreServer(string path) : base(path)
		{
        }

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                base.Dispose(disposing);
            }
        }

        private void SendError(String msgErr)
        {
            logger.Log(LogLevel.Error, msgErr); ;
        }

	    #endregion        

        #region Start/Stop Camera Methods
        public bool Start(String camName)
        {
            try
            {
                StartConnect(camName);

                StartAnalyse(camName);

                StartEventAlert(camName);

                StartRecord(camName);

                StartDataAlert(camName);

                return true;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StartAll()
        {
            try
            {
                StartConnectAll();

                StartAnalyseAll();

                StartEventAlertAll();

                StartRecordAll();

                StartDataAlertAll();

                return true;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool Stop(String camName)
        {
            try
            {
                StopDataAlert(camName);

                StopRecord(camName);

                StopEventAlert(camName);

                StopAnalyse(camName);

                StopConnect(camName);

                return true;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopAll()
        {
            try
            {
                StopDataAlertAll();

                StopRecordAll();

                StopEventAlertAll();

                StopAnalyseAll();

                StopConnectAll();
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }
        
        #endregion

        #region Connect/Disconnect Camera Methods
        public bool StartConnect(String camName)
        {
            try
            {
                return ConnectCamera(camName, false);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StartConnectAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    bConnect &= ConnectCamera(cm.CameraName, false);
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopConnect(String camName)
        {
            return DisconnectCamera(camName);
        }

        public bool StopConnectAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    bConnect &= DisconnectCamera(cm.CameraName);
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        } 
        #endregion

        #region Analyse Methods
        public bool StartAnalyse(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.Analysing = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StartAnalyseAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.Analysing = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopAnalyse(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.Analysing = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopAnalyseAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.Analysing = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }
        
        #endregion

        #region Event Alert Methods
        public bool StartEventAlert(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.EventAlerting = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StartEventAlertAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.EventAlerting = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopEventAlert(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.EventAlerting = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopEventAlertAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.EventAlerting = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }
        
        #endregion

        #region Record Methods
        public bool StartRecord(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.Recording = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StartRecordAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.Recording = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopRecord(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.Recording = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopRecordAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.Recording = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }
        
        #endregion

        #region Data Alert Methods
        public bool StartDataAlert(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.DataAlerting = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StartDataAlertAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.DataAlerting = true;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopDataAlert(String camName)
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                        cm.DataAlerting = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }

        public bool StopDataAlertAll()
        {
            try
            {
                bool bConnect = true;
                foreach (VsCamera cm in vsCameras)
                {
                    cm.DataAlerting = false;
                }
                return bConnect;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return false;
        }
        
        #endregion

        #region List Camera Info Methods
        public String[] ListCamerasName()
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
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String[] ListCamerasDetail()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName +
                        ", Running=" + cm.Running.ToString() +
                        ", Analysing=" + cm.Analysing.ToString() +
                        ", EventAlerting=" + cm.EventAlerting.ToString() +
                        ", Recording=" + cm.Recording.ToString() +
                        ", DataAlerting=" + cm.DataAlerting.ToString();
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String[] ListCamerasConnect()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName +
                        ", Running=" + cm.Running.ToString();
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        public String[] ListCamerasAnalyse()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName +
                        ", Analysing=" + cm.Analysing.ToString();
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String[] ListCamerasEventAlert()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName +
                        ", EventAlerting=" + cm.EventAlerting.ToString();
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String[] ListCamerasRecord()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName +
                        ", Recording=" + cm.Recording.ToString();
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String[] ListCamerasDataAlert()
        {
            try
            {
                String[] listCamera = new String[vsCameras.Count];
                int i = 0;
                foreach (VsCamera cm in vsCameras)
                {
                    listCamera[i] = cm.CameraName +
                        ", DataAlerting=" + cm.DataAlerting.ToString();
                    i++;
                }
                return listCamera;
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String ListCameraConnect(String camName)
        {
            try
            {
                String listCamera = "";
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                    {
                        listCamera = cm.CameraName + ", Running=" + cm.Running.ToString();
                        return listCamera;
                    }
                }
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String ListCameraAnalyse(String camName)
        {
            try
            {
                String listCamera = "";
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                    {
                        listCamera = cm.CameraName + ", Analysing=" + cm.Analysing.ToString();
                        return listCamera;
                    }
                }
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String ListCameraEventAlert(String camName)
        {
            try
            {
                String listCamera = "";
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                    {
                        listCamera = cm.CameraName + ", EventAlerting=" + cm.EventAlerting.ToString();
                        return listCamera;
                    }
                }
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String ListCameraRecord(String camName)
        {
            try
            {
                String listCamera = "";
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                    {
                        listCamera = cm.CameraName + ", Recording=" + cm.Recording.ToString();
                        return listCamera;
                    }
                }
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String ListCameraDataAlert(String camName)
        {
            try
            {
                String listCamera = "";
                foreach (VsCamera cm in vsCameras)
                {
                    if (cm.CameraName == camName)
                    {
                        listCamera = cm.CameraName + ", DataAlerting=" + cm.DataAlerting.ToString();
                        return listCamera;
                    }
                }
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return null;
        }

        public String ListInfo()
        {
            return null;
        }
        
        #endregion
    }
}
