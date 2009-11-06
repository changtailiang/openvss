// pmjo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wgzc	
// zqnc	 By downloading, copying, installing or using the software you agree to this license.
// sube	 If you do not agree to this license, do not download, install,
// ztfp	 copy or use the software.
// etur	
// vmwf	                          License Agreement
// ihne	         For OpenVss - Open Source Video Surveillance System
// mpxo	
// eleh	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// yecq	
// jlxb	Third party copyrights are property of their respective owners.
// aaze	
// hdpw	Redistribution and use in source and binary forms, with or without modification,
// rstj	are permitted provided that the following conditions are met:
// kutr	
// djpd	  * Redistribution's of source code must retain the above copyright notice,
// xnao	    this list of conditions and the following disclaimer.
// oxrz	
// qdhj	  * Redistribution's in binary form must reproduce the above copyright notice,
// puei	    this list of conditions and the following disclaimer in the documentation
// iiwj	    and/or other materials provided with the distribution.
// abwl	
// rvwe	  * Neither the name of the copyright holders nor the names of its contributors 
// lkna	    may not be used to endorse or promote products derived from this software 
// vuen	    without specific prior written permission.
// zkpk	
// mpfo	This software is provided by the copyright holders and contributors "as is" and
// kjuq	any express or implied warranties, including, but not limited to, the implied
// pkju	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mfcw	In no event shall the Prince of Songkla University or contributors be liable 
// qowt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// amnf	(including, but not limited to, procurement of substitute goods or services;
// qhnu	loss of use, data, or profits; or business interruption) however caused
// pqjx	and on any theory of liability, whether in contract, strict liability,
// tmxk	or tort (including negligence or otherwise) arising in any way out of
// wiah	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Globalization;
using NLog;

namespace Vs.Monitor
{
    /// <summary>
    /// interface for Splash Screen
    /// </summary>
    public interface VsISplasher
    {
        void SetStatusInfo(string StatusInfo);

        void LoginSerivce();
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
            get { return ((VsSplasherView)vsSplashForm).Blocked; }
        }

        public static bool Connected
        {
            get { return ((VsSplasherView)vsSplashForm).Connected; }
        }

        public static void Hide()
        {
            try
            {
                if (vsSplashInterface == null || vsSplashForm == null)
                {
                    return;
                }

                ((VsSplasherView)vsSplashForm).Invoke(new MethodInvoker(((VsSplasherView)vsSplashForm).Hide));
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

        public static void LoginSerivce()
        {
            try
            {
                if (vsSplashInterface == null || vsSplashForm == null)
                {
                    return;
                }

                ((VsSplasherView)vsSplashForm).LoginSerivce();
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

        private delegate void SplashLogingHandle();
    }
}
