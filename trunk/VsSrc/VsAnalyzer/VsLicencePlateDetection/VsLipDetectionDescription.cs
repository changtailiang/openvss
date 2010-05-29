// aqkp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wqbo	
// kvwt	 By downloading, copying, installing or using the software you agree to this license.
// krcr	 If you do not agree to this license, do not download, install,
// fpqh	 copy or use the software.
// xwtu	
// svxd	                          License Agreement
// lqhx	         For OpenVSS - Open Source Video Surveillance System
// kfot	
// xwrq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hfoe	
// uypj	Third party copyrights are property of their respective owners.
// ekgm	
// rrpd	Redistribution and use in source and binary forms, with or without modification,
// xpwa	are permitted provided that the following conditions are met:
// txdt	
// ozie	  * Redistribution's of source code must retain the above copyright notice,
// citj	    this list of conditions and the following disclaimer.
// xzar	
// ipau	  * Redistribution's in binary form must reproduce the above copyright notice,
// gnyb	    this list of conditions and the following disclaimer in the documentation
// kugt	    and/or other materials provided with the distribution.
// plwi	
// zrxj	  * Neither the name of the copyright holders nor the names of its contributors 
// cuqv	    may not be used to endorse or promote products derived from this software 
// qkgw	    without specific prior written permission.
// qwpr	
// qxvh	This software is provided by the copyright holders and contributors "as is" and
// pcuf	any express or implied warranties, including, but not limited to, the implied
// ybit	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sopr	In no event shall the Prince of Songkla University or contributors be liable 
// llkg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// crpn	(including, but not limited to, procurement of substitute goods or services;
// yfdv	loss of use, data, or profits; or business interruption) however caused
// gcko	and on any theory of liability, whether in contract, strict liability,
// fpcs	or tort (including negligence or otherwise) arising in any way out of
// qosw	the use of this software, even if advised of the possibility of such damage.
// wrka	
// lwcb	Intelligent Systems Laboratory (iSys Lab)
// vplf	Faculty of Engineering, Prince of Songkla University, THAILAND
// mipz	Project leader by Nikom SUVONVORN
// hhjk	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.LipDetection
{
    class VsLipDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Licence Plate Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsLipDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsLipDetectionConfiguration cfg = (VsLipDetectionConfiguration)config;

            if (cfg != null)
            {
                VsLipDetection analyser = new VsLipDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsLipDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsLipDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsLipDetectionConfiguration config = new VsLipDetectionConfiguration();

            try
            {
                config.Threshold = int.Parse(reader.GetAttribute("Threshold"));
            }
            catch (Exception)
            {
            }
            return config;
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(Hashtable reader)
        {
            VsLipDetectionConfiguration config = new VsLipDetectionConfiguration();

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
            VsLipDetectionConfiguration cfg = (VsLipDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("Threshold", cfg.Threshold.ToString());
            }
        }
    }
}
