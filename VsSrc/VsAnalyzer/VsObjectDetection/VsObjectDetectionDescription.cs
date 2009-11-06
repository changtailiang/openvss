// ymbw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hfiu	
// ubxw	 By downloading, copying, installing or using the software you agree to this license.
// mnnb	 If you do not agree to this license, do not download, install,
// lwjf	 copy or use the software.
// qzqn	
// pqex	                          License Agreement
// gssz	         For OpenVss - Open Source Video Surveillance System
// hclt	
// ehcf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// qgag	
// xgwv	Third party copyrights are property of their respective owners.
// fxtj	
// bhyz	Redistribution and use in source and binary forms, with or without modification,
// vnhq	are permitted provided that the following conditions are met:
// bknc	
// ixok	  * Redistribution's of source code must retain the above copyright notice,
// btwe	    this list of conditions and the following disclaimer.
// tepj	
// ykqi	  * Redistribution's in binary form must reproduce the above copyright notice,
// uisj	    this list of conditions and the following disclaimer in the documentation
// yiya	    and/or other materials provided with the distribution.
// dmxq	
// zmdf	  * Neither the name of the copyright holders nor the names of its contributors 
// sxxa	    may not be used to endorse or promote products derived from this software 
// slul	    without specific prior written permission.
// bppw	
// roal	This software is provided by the copyright holders and contributors "as is" and
// xyvs	any express or implied warranties, including, but not limited to, the implied
// seez	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zngo	In no event shall the Prince of Songkla University or contributors be liable 
// wfeg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// akqa	(including, but not limited to, procurement of substitute goods or services;
// mqqj	loss of use, data, or profits; or business interruption) however caused
// nhii	and on any theory of liability, whether in contract, strict liability,
// tbip	or tort (including negligence or otherwise) arising in any way out of
// lltb	the use of this software, even if advised of the possibility of such damage.

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
