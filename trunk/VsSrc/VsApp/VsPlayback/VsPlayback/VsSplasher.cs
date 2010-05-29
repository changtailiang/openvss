// wdir	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rphd	
// drlk	 By downloading, copying, installing or using the software you agree to this license.
// ebol	 If you do not agree to this license, do not download, install,
// nshe	 copy or use the software.
// lpnz	
// jhom	                          License Agreement
// nosx	         For OpenVSS - Open Source Video Surveillance System
// fewq	
// hrui	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// txti	
// wexy	Third party copyrights are property of their respective owners.
// buam	
// xtjg	Redistribution and use in source and binary forms, with or without modification,
// qihk	are permitted provided that the following conditions are met:
// bvpp	
// ynea	  * Redistribution's of source code must retain the above copyright notice,
// eydw	    this list of conditions and the following disclaimer.
// yykn	
// vfdf	  * Redistribution's in binary form must reproduce the above copyright notice,
// jqkt	    this list of conditions and the following disclaimer in the documentation
// ogam	    and/or other materials provided with the distribution.
// uqzz	
// jjhy	  * Neither the name of the copyright holders nor the names of its contributors 
// iejj	    may not be used to endorse or promote products derived from this software 
// axtc	    without specific prior written permission.
// qdny	
// iwkl	This software is provided by the copyright holders and contributors "as is" and
// fcak	any express or implied warranties, including, but not limited to, the implied
// lwbs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mrfo	In no event shall the Prince of Songkla University or contributors be liable 
// yemp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rmfr	(including, but not limited to, procurement of substitute goods or services;
// vtem	loss of use, data, or profits; or business interruption) however caused
// whdk	and on any theory of liability, whether in contract, strict liability,
// sbey	or tort (including negligence or otherwise) arising in any way out of
// fotg	the use of this software, even if advised of the possibility of such damage.
// iwnl	
// drwi	Intelligent Systems Laboratory (iSys Lab)
// rfel	Faculty of Engineering, Prince of Songkla University, THAILAND
// qyhw	Project leader by Nikom SUVONVORN
// rtqm	Project website at http://code.google.com/p/openvss/

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
