// khsm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nixl	
// zcil	 By downloading, copying, installing or using the software you agree to this license.
// duhd	 If you do not agree to this license, do not download, install,
// ojas	 copy or use the software.
// tjrf	
// tvbt	                          License Agreement
// jclu	         For OpenVSS - Open Source Video Surveillance System
// qqsq	
// unaw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nnyw	
// oluv	Third party copyrights are property of their respective owners.
// cueg	
// rrhb	Redistribution and use in source and binary forms, with or without modification,
// pmss	are permitted provided that the following conditions are met:
// gecw	
// rnun	  * Redistribution's of source code must retain the above copyright notice,
// bqib	    this list of conditions and the following disclaimer.
// jeff	
// kuqh	  * Redistribution's in binary form must reproduce the above copyright notice,
// agro	    this list of conditions and the following disclaimer in the documentation
// yecz	    and/or other materials provided with the distribution.
// irah	
// uhpj	  * Neither the name of the copyright holders nor the names of its contributors 
// kbfa	    may not be used to endorse or promote products derived from this software 
// rhul	    without specific prior written permission.
// mdxn	
// lcqv	This software is provided by the copyright holders and contributors "as is" and
// wlsa	any express or implied warranties, including, but not limited to, the implied
// moym	warranties of merchantability and fitness for a particular purpose are disclaimed.
// luej	In no event shall the Prince of Songkla University or contributors be liable 
// qagc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pwvj	(including, but not limited to, procurement of substitute goods or services;
// ppqs	loss of use, data, or profits; or business interruption) however caused
// lfbv	and on any theory of liability, whether in contract, strict liability,
// hpog	or tort (including negligence or otherwise) arising in any way out of
// aflj	the use of this software, even if advised of the possibility of such damage.
// oowv	
// dtpw	Intelligent Systems Laboratory (iSys Lab)
// ckvl	Faculty of Engineering, Prince of Songkla University, THAILAND
// wuxo	Project leader by Nikom SUVONVORN
// ghfh	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.LineDetection
{
    class VsLineDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Line Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsLineDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsLineDetectionConfiguration cfg = (VsLineDetectionConfiguration)config;

            if (cfg != null)
            {
                VsLineDetection analyser = new VsLineDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsLineDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsLineDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsLineDetectionConfiguration config = new VsLineDetectionConfiguration();

            try
            {
                config.ThresholdStrong = int.Parse(reader.GetAttribute("ThresholdStrong"));
                config.ThresholdWeak   = int.Parse(reader.GetAttribute("ThresholdWeak"));
                config.ThresholdHough = int.Parse(reader.GetAttribute("ThresholdHough"));
            }
            catch (Exception)
            {
            }
            return config;
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(Hashtable reader)
        {
            VsLineDetectionConfiguration config = new VsLineDetectionConfiguration();

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
            VsLineDetectionConfiguration cfg = (VsLineDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdStrong", cfg.ThresholdStrong.ToString());
                writer.WriteAttributeString("ThresholdWeak", cfg.ThresholdWeak.ToString());
                writer.WriteAttributeString("ThresholdHough", cfg.ThresholdHough.ToString());
            }
        }
    }
}
