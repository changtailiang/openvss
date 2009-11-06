// tunw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jhsu	
// gmpa	 By downloading, copying, installing or using the software you agree to this license.
// dufu	 If you do not agree to this license, do not download, install,
// cfzq	 copy or use the software.
// lbpw	
// snnu	                          License Agreement
// wutb	         For OpenVss - Open Source Video Surveillance System
// jacv	
// uwgv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// gojx	
// xnif	Third party copyrights are property of their respective owners.
// sqrd	
// atts	Redistribution and use in source and binary forms, with or without modification,
// frdv	are permitted provided that the following conditions are met:
// uyym	
// soqc	  * Redistribution's of source code must retain the above copyright notice,
// skaf	    this list of conditions and the following disclaimer.
// zdjw	
// ssye	  * Redistribution's in binary form must reproduce the above copyright notice,
// eibf	    this list of conditions and the following disclaimer in the documentation
// cpbq	    and/or other materials provided with the distribution.
// hkpd	
// tkbi	  * Neither the name of the copyright holders nor the names of its contributors 
// pxej	    may not be used to endorse or promote products derived from this software 
// xfmi	    without specific prior written permission.
// qlew	
// kwan	This software is provided by the copyright holders and contributors "as is" and
// syrm	any express or implied warranties, including, but not limited to, the implied
// xtjc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mavi	In no event shall the Prince of Songkla University or contributors be liable 
// uxmo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bahu	(including, but not limited to, procurement of substitute goods or services;
// nohz	loss of use, data, or profits; or business interruption) however caused
// vtpq	and on any theory of liability, whether in contract, strict liability,
// legk	or tort (including negligence or otherwise) arising in any way out of
// jcku	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.SquareDetection
{
    class VsSquareDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Square Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsSquareDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsSquareDetectionConfiguration cfg = (VsSquareDetectionConfiguration)config;

            if (cfg != null)
            {
                VsSquareDetection analyser = new VsSquareDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsSquareDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsSquareDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsSquareDetectionConfiguration config = new VsSquareDetectionConfiguration();

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
            VsSquareDetectionConfiguration config = new VsSquareDetectionConfiguration();

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
            VsSquareDetectionConfiguration cfg = (VsSquareDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("Threshold", cfg.Threshold.ToString());
            }
        }
    }
}
