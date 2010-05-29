// arah	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fwfm	
// gyhb	 By downloading, copying, installing or using the software you agree to this license.
// hoyw	 If you do not agree to this license, do not download, install,
// otiu	 copy or use the software.
// xndi	
// afwf	                          License Agreement
// mrgg	         For OpenVSS - Open Source Video Surveillance System
// cknw	
// fouf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lrbp	
// cuwa	Third party copyrights are property of their respective owners.
// qqvn	
// cpwm	Redistribution and use in source and binary forms, with or without modification,
// nrha	are permitted provided that the following conditions are met:
// azzp	
// sbzw	  * Redistribution's of source code must retain the above copyright notice,
// abqz	    this list of conditions and the following disclaimer.
// zdjf	
// logf	  * Redistribution's in binary form must reproduce the above copyright notice,
// iwow	    this list of conditions and the following disclaimer in the documentation
// vtdn	    and/or other materials provided with the distribution.
// obin	
// huel	  * Neither the name of the copyright holders nor the names of its contributors 
// rlxa	    may not be used to endorse or promote products derived from this software 
// vzzp	    without specific prior written permission.
// zvnz	
// fqby	This software is provided by the copyright holders and contributors "as is" and
// lbre	any express or implied warranties, including, but not limited to, the implied
// ldty	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yliz	In no event shall the Prince of Songkla University or contributors be liable 
// scse	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yyoa	(including, but not limited to, procurement of substitute goods or services;
// rfki	loss of use, data, or profits; or business interruption) however caused
// wzwz	and on any theory of liability, whether in contract, strict liability,
// fehx	or tort (including negligence or otherwise) arising in any way out of
// zkcg	the use of this software, even if advised of the possibility of such damage.
// dazn	
// rycj	Intelligent Systems Laboratory (iSys Lab)
// rawx	Faculty of Engineering, Prince of Songkla University, THAILAND
// djag	Project leader by Nikom SUVONVORN
// cagf	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EdgeDetection
{
    class VsEdgeDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Edge Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsEdgeDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsEdgeDetectionConfiguration cfg = (VsEdgeDetectionConfiguration)config;

            if (cfg != null)
            {
                VsEdgeDetection analyser = new VsEdgeDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsEdgeDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsEdgeDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsEdgeDetectionConfiguration config = new VsEdgeDetectionConfiguration();

            try
            {
                config.ThresholdStrong = int.Parse(reader.GetAttribute("ThresholdStrong"));
                config.ThresholdWeak   = int.Parse(reader.GetAttribute("ThresholdWeak"));
            }
            catch (Exception)
            {
            }
            return config;
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(Hashtable reader)
        {
            VsEdgeDetectionConfiguration config = new VsEdgeDetectionConfiguration();

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
            VsEdgeDetectionConfiguration cfg = (VsEdgeDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdStrong", cfg.ThresholdStrong.ToString());
                writer.WriteAttributeString("ThresholdWeak", cfg.ThresholdWeak.ToString());
            }
        }
    }
}
