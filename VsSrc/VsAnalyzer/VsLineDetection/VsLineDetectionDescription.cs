// tfoz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rgde	
// wvgq	 By downloading, copying, installing or using the software you agree to this license.
// hksy	 If you do not agree to this license, do not download, install,
// fyng	 copy or use the software.
// hxfs	
// bfsc	                          License Agreement
// vrtf	         For OpenVss - Open Source Video Surveillance System
// drjl	
// xkgn	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// gvru	
// ysol	Third party copyrights are property of their respective owners.
// mhmg	
// ylpv	Redistribution and use in source and binary forms, with or without modification,
// zwym	are permitted provided that the following conditions are met:
// objf	
// camq	  * Redistribution's of source code must retain the above copyright notice,
// ahau	    this list of conditions and the following disclaimer.
// razl	
// gkuj	  * Redistribution's in binary form must reproduce the above copyright notice,
// qgqn	    this list of conditions and the following disclaimer in the documentation
// emhs	    and/or other materials provided with the distribution.
// colb	
// muzf	  * Neither the name of the copyright holders nor the names of its contributors 
// mmsy	    may not be used to endorse or promote products derived from this software 
// gylf	    without specific prior written permission.
// hspx	
// mdpo	This software is provided by the copyright holders and contributors "as is" and
// bovh	any express or implied warranties, including, but not limited to, the implied
// lvap	warranties of merchantability and fitness for a particular purpose are disclaimed.
// stom	In no event shall the Prince of Songkla University or contributors be liable 
// vzhw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// btzu	(including, but not limited to, procurement of substitute goods or services;
// swcs	loss of use, data, or profits; or business interruption) however caused
// vkgm	and on any theory of liability, whether in contract, strict liability,
// xkgy	or tort (including negligence or otherwise) arising in any way out of
// zxzx	the use of this software, even if advised of the possibility of such damage.

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
