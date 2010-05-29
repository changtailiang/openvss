// keaj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xvsz	
// icru	 By downloading, copying, installing or using the software you agree to this license.
// qpyf	 If you do not agree to this license, do not download, install,
// ofyq	 copy or use the software.
// remt	
// ktca	                          License Agreement
// qjwc	         For OpenVSS - Open Source Video Surveillance System
// slof	
// qehg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// attj	
// qpyw	Third party copyrights are property of their respective owners.
// rjco	
// zjrf	Redistribution and use in source and binary forms, with or without modification,
// sgze	are permitted provided that the following conditions are met:
// sriz	
// focf	  * Redistribution's of source code must retain the above copyright notice,
// btoj	    this list of conditions and the following disclaimer.
// xsqx	
// lcdv	  * Redistribution's in binary form must reproduce the above copyright notice,
// vgih	    this list of conditions and the following disclaimer in the documentation
// ghcj	    and/or other materials provided with the distribution.
// tjnk	
// fcoi	  * Neither the name of the copyright holders nor the names of its contributors 
// lteb	    may not be used to endorse or promote products derived from this software 
// mtuy	    without specific prior written permission.
// vsqh	
// sutp	This software is provided by the copyright holders and contributors "as is" and
// dejl	any express or implied warranties, including, but not limited to, the implied
// jbty	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mtls	In no event shall the Prince of Songkla University or contributors be liable 
// fdeu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dhlr	(including, but not limited to, procurement of substitute goods or services;
// ybic	loss of use, data, or profits; or business interruption) however caused
// lkln	and on any theory of liability, whether in contract, strict liability,
// rvqy	or tort (including negligence or otherwise) arising in any way out of
// pxha	the use of this software, even if advised of the possibility of such damage.
// tdzk	
// afpt	Intelligent Systems Laboratory (iSys Lab)
// hcsr	Faculty of Engineering, Prince of Songkla University, THAILAND
// nvek	Project leader by Nikom SUVONVORN
// jbrc	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.ObjectDetection
{
    class VsObjectDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Harr-like Object Detection";
        static private string algoDescription = "Pattern Recognition";

        public VsObjectDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsObjectDetectionConfiguration cfg = (VsObjectDetectionConfiguration)config;

            if (cfg != null)
            {
                VsObjectDetection analyser = new VsObjectDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsObjectDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsObjectDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsObjectDetectionConfiguration config = new VsObjectDetectionConfiguration();

            try
            {
                config.SelectedObject = int.Parse(reader.GetAttribute("SelectedObject"));
            }
            catch (Exception)
            {
            }
            return config;
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(Hashtable reader)
        {
            VsObjectDetectionConfiguration config = new VsObjectDetectionConfiguration();

            try
            {
                config.LoadConfiguration(reader);
            }
            catch (Exception)
            {
            }
            return config;
        }

        string VsICoreAnalyzerDescription.Name
        {
            get { return algorithmName; }
        }

        void VsICoreAnalyzerDescription.SaveConfiguration(System.Xml.XmlTextWriter writer, VsICoreAnalyzerConfiguration config)
        {
            VsObjectDetectionConfiguration cfg = (VsObjectDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("SelectedObject", cfg.SelectedObject.ToString());
            }
        }
    }
}
