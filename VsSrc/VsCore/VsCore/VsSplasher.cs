// igga	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tnuy	
// pqjf	 By downloading, copying, installing or using the software you agree to this license.
// zggm	 If you do not agree to this license, do not download, install,
// kkgv	 copy or use the software.
// xogh	
// gcmq	                          License Agreement
// tetz	         For OpenVss - Open Source Video Surveillance System
// mikt	
// lyft	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hina	
// ovum	Third party copyrights are property of their respective owners.
// euir	
// qcat	Redistribution and use in source and binary forms, with or without modification,
// zytq	are permitted provided that the following conditions are met:
// adek	
// wksr	  * Redistribution's of source code must retain the above copyright notice,
// wmbl	    this list of conditions and the following disclaimer.
// ennp	
// agtk	  * Redistribution's in binary form must reproduce the above copyright notice,
// haly	    this list of conditions and the following disclaimer in the documentation
// vcjk	    and/or other materials provided with the distribution.
// hqum	
// eotd	  * Neither the name of the copyright holders nor the names of its contributors 
// dcee	    may not be used to endorse or promote products derived from this software 
// cdpr	    without specific prior written permission.
// twmd	
// olss	This software is provided by the copyright holders and contributors "as is" and
// fjja	any express or implied warranties, including, but not limited to, the implied
// sgou	warranties of merchantability and fitness for a particular purpose are disclaimed.
// aikg	In no event shall the Prince of Songkla University or contributors be liable 
// sohq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tjlx	(including, but not limited to, procurement of substitute goods or services;
// cphe	loss of use, data, or profits; or business interruption) however caused
// ktez	and on any theory of liability, whether in contract, strict liability,
// pgvv	or tort (including negligence or otherwise) arising in any way out of
// ybhv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
    /// <summary>
    /// interface for Splash Screen
    /// </summary>
    public interface VsISplasher
    {
        void SetStatusInfo(string StatusInfo);
    }

    public class VsSplasher
    {
        private static Form vsSplashForm = null;
        private static VsISplasher vsSplashInterface = null;
        private static Thread vsSplashThread = null;
        private static string vsTempStatus = string.Empty;
        static Logger logger = LogManager.GetCurrentClassLogger(); 

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
    }
}
