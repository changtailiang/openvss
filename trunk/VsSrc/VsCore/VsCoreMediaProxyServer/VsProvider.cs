// ihmn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// firv	
// icbu	 By downloading, copying, installing or using the software you agree to this license.
// qzmg	 If you do not agree to this license, do not download, install,
// wboi	 copy or use the software.
// sgqg	
// ydhp	                          License Agreement
// wabt	         For OpenVSS - Open Source Video Surveillance System
// jugz	
// mjxg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xxja	
// uuex	Third party copyrights are property of their respective owners.
// fkgb	
// oxrc	Redistribution and use in source and binary forms, with or without modification,
// qgoc	are permitted provided that the following conditions are met:
// bbzh	
// ailv	  * Redistribution's of source code must retain the above copyright notice,
// smun	    this list of conditions and the following disclaimer.
// eiku	
// wple	  * Redistribution's in binary form must reproduce the above copyright notice,
// yjjm	    this list of conditions and the following disclaimer in the documentation
// uael	    and/or other materials provided with the distribution.
// deig	
// uvew	  * Neither the name of the copyright holders nor the names of its contributors 
// ycam	    may not be used to endorse or promote products derived from this software 
// iift	    without specific prior written permission.
// qtwf	
// nxgb	This software is provided by the copyright holders and contributors "as is" and
// ujds	any express or implied warranties, including, but not limited to, the implied
// rnnz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// daso	In no event shall the Prince of Songkla University or contributors be liable 
// eosi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dovt	(including, but not limited to, procurement of substitute goods or services;
// pzwq	loss of use, data, or profits; or business interruption) however caused
// dqwa	and on any theory of liability, whether in contract, strict liability,
// dzyg	or tort (including negligence or otherwise) arising in any way out of
// xhll	the use of this software, even if advised of the possibility of such damage.
// rlel	
// paih	Intelligent Systems Laboratory (iSys Lab)
// qrob	Faculty of Engineering, Prince of Songkla University, THAILAND
// bncy	Project leader by Nikom SUVONVORN
// bmlu	Project website at http://code.google.com/p/openvss/

using System;
using System.Xml;
using System.Collections;
//using Vs.Core.Encoder;
using Vs.Core.Provider;
using System.Globalization;
using NLog; 

namespace Vs.Core.MediaProxyServer
{
    public class VsProvider : IComparable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private VsICoreProviderDescription sourceDesc = null;

        // Name property
        public string Name
        {
            get { return sourceDesc.Name; }
        }

        // Description property
        public string Description
        {
            get { return sourceDesc.Description; }
        }

        // ProviderName property
        public string ProviderName
        {
            get { return sourceDesc.GetType().ToString(); }
        }


        // Constructor
        public VsProvider(VsICoreProviderDescription sourceDesc)
        {
            this.sourceDesc = sourceDesc;
        }

        // Compares objects of the type
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            VsProvider p = (VsProvider)obj;
            return (this.Name.CompareTo(p.Name));
        }

        // Get video source settings page
        public VsICoreProviderPage GetSettingsPage()
        {
            try
            {
                return sourceDesc.GetSettingsPage();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            try
            {
                sourceDesc.SaveConfiguration(writer, config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            try
            {
                return sourceDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            try
            {
                return sourceDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        // Create video source
        public VsICoreProvider CreateVideoSource(object config)
        {
            try
            {
                return sourceDesc.CreateVideoSource(config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }
    }
}
