// vpsc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bmgk	
// bogm	 By downloading, copying, installing or using the software you agree to this license.
// oghm	 If you do not agree to this license, do not download, install,
// fuox	 copy or use the software.
// lalr	
// ghlo	                          License Agreement
// omeg	         For OpenVss - Open Source Video Surveillance System
// goei	
// rple	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wnkv	
// tgis	Third party copyrights are property of their respective owners.
// vazp	
// dfiu	Redistribution and use in source and binary forms, with or without modification,
// eavu	are permitted provided that the following conditions are met:
// arvo	
// kzgz	  * Redistribution's of source code must retain the above copyright notice,
// bzvp	    this list of conditions and the following disclaimer.
// ijby	
// pqyz	  * Redistribution's in binary form must reproduce the above copyright notice,
// ytso	    this list of conditions and the following disclaimer in the documentation
// nocb	    and/or other materials provided with the distribution.
// gkdq	
// urde	  * Neither the name of the copyright holders nor the names of its contributors 
// rwkt	    may not be used to endorse or promote products derived from this software 
// ajrw	    without specific prior written permission.
// fjgu	
// ekeo	This software is provided by the copyright holders and contributors "as is" and
// cwvh	any express or implied warranties, including, but not limited to, the implied
// yhaw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xetr	In no event shall the Prince of Songkla University or contributors be liable 
// vevr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gwgt	(including, but not limited to, procurement of substitute goods or services;
// ffyp	loss of use, data, or profits; or business interruption) however caused
// bwje	and on any theory of liability, whether in contract, strict liability,
// hixv	or tort (including negligence or otherwise) arising in any way out of
// fpnx	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Globalization;
using NLog;

namespace Vs.Playback
{
    /// <summary>
    /// interface for Splash Screen
    /// </summary>
    public interface VsISplasher
    {
        void SetStatusInfo(string StatusInfo);

        void LoginSerivce(getAllcam allcam, setServerURL setServer);
    }

    public class VsSplasher
    {
        private static Form vsSplashForm = null;
        private static VsISplasher vsSplashInterface = null;
        private static Thread vsSplashThread = null;
        private static string vsTempStatus = string.Empty;
        static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool Blocked
        {
            get { return ((VsLogin)vsSplashForm).Blocked;  }
        }

        public static bool Connected
        {
            get { return ((VsLogin)vsSplashForm).Connected; }
        }

        public static void Hide()
        {
            try
            {
                if (vsSplashInterface == null || vsSplashForm == null)
                {
                    return;
                }

                ((VsLogin)vsSplashForm).Invoke( new MethodInvoker(((VsLogin)vsSplashForm).Hide));
                /*
                vsSplashForm.Invoke(
                        new SplashLogindHandle(delegate(getAllcam, setServerURL) 
                            {
                                vsSplashInterface.LoginSerivce(allcam, setServer); 
                            }),
                        new object[] {allcam, setServer}
                );
                */
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// Show the SplashForm
        /// </summary>
        public static void Show(Type splashFormType)
        {
            try
            {
                if (vsSplashThread != null)
                    return;
                if (splashFormType == null)
                {
                    throw (new Exception("splashFormType is null"));
                }

                vsSplashThread = new Thread(new ThreadStart(delegate()
                {
                    CreateInstance(splashFormType);
                    Application.Run(vsSplashForm);
                }));

                vsSplashThread.IsBackground = true;
                vsSplashThread.SetApartmentState(ApartmentState.STA);
                vsSplashThread.Start();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        public static void LoginSerivce(getAllcam allcam, setServerURL setServer)
        {
            try
            {
                if (vsSplashInterface == null || vsSplashForm == null)
                {
                    return;
                }
                
                ((VsLogin)vsSplashForm).LoginSerivce(allcam, setServer);
                /*
                vsSplashForm.Invoke(
                        new SplashLogindHandle(delegate(getAllcam, setServerURL) 
                            {
                                vsSplashInterface.LoginSerivce(allcam, setServer); 
                            }),
                        new object[] {allcam, setServer}
                );
                */
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// set the loading Status
        /// </summary>
        public static string Status
        {
            set
            {
                try
                {
                    if (vsSplashInterface == null || vsSplashForm == null)
                    {
                        vsTempStatus = value;
                        return;
                    }
                    vsSplashForm.Invoke(
                            new SplashStatusChangedHandle(delegate(string str) { vsSplashInterface.SetStatusInfo(str); }),
                            new object[] { value }
                    );
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                }
            }
        }

        /// <summary>
        /// Colse the SplashForm
        /// </summary>
        public static void Close()
        {
            try
            {
                if (vsSplashThread == null || vsSplashForm == null) return;

                try
                {
                    vsSplashForm.Invoke(new MethodInvoker(vsSplashForm.Close));
                }
                catch (Exception)
                {
                }
                vsSplashThread = null;
                vsSplashForm = null;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        private static void CreateInstance(Type FormType)
        {
            try
            {
                object obj = FormType.InvokeMember(null,
                                    BindingFlags.DeclaredOnly |
                                    BindingFlags.Public | BindingFlags.NonPublic |
                                    BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                vsSplashForm = obj as Form;
                vsSplashInterface = obj as VsISplasher;
                if (vsSplashForm == null)
                {
                    throw (new Exception("Splash Screen must inherit from System.Windows.Forms.Form"));
                }
                if (vsSplashInterface == null)
                {
                    throw (new Exception("must implement interface VsISplasher"));
                }

                if (!string.IsNullOrEmpty(vsTempStatus))
                    vsSplashInterface.SetStatusInfo(vsTempStatus);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        private delegate void SplashStatusChangedHandle(string StatusInfo);

        private delegate void SplashLogingHandle(getAllcam allcam, setServerURL setServer);
    }
}
