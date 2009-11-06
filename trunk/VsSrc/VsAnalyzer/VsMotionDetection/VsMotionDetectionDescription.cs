// kiyz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wlbr	
// qkgg	 By downloading, copying, installing or using the software you agree to this license.
// fmjl	 If you do not agree to this license, do not download, install,
// jzbm	 copy or use the software.
// eiyd	
// dlgs	                          License Agreement
// syxk	         For OpenVss - Open Source Video Surveillance System
// jkqz	
// pbym	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rkal	
// wyfw	Third party copyrights are property of their respective owners.
// jmow	
// kekb	Redistribution and use in source and binary forms, with or without modification,
// jvwl	are permitted provided that the following conditions are met:
// eiys	
// mwxu	  * Redistribution's of source code must retain the above copyright notice,
// vkvi	    this list of conditions and the following disclaimer.
// bovt	
// imgf	  * Redistribution's in binary form must reproduce the above copyright notice,
// fjig	    this list of conditions and the following disclaimer in the documentation
// kbae	    and/or other materials provided with the distribution.
// zoqu	
// enhi	  * Neither the name of the copyright holders nor the names of its contributors 
// miya	    may not be used to endorse or promote products derived from this software 
// akaz	    without specific prior written permission.
// qgvv	
// irtw	This software is provided by the copyright holders and contributors "as is" and
// prgu	any express or implied warranties, including, but not limited to, the implied
// arhl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wsvg	In no event shall the Prince of Songkla University or contributors be liable 
// ubdn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gnhz	(including, but not limited to, procurement of substitute goods or services;
// ogev	loss of use, data, or profits; or business interruption) however caused
// iiqe	and on any theory of liability, whether in contract, strict liability,
// gewi	or tort (including negligence or otherwise) arising in any way out of
// vtfn	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionDetection
{
    class VsMotionDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Motion Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsMotionDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsMotionDetectionConfiguration cfg = (VsMotionDetectionConfiguration)config;

            if (cfg != null)
            {
                VsMotionDetection analyser = new VsMotionDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();
                analyser.AnalyserName = algorithmName;

                return (VsMotionDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsMotionDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsMotionDetectionConfiguration config = new VsMotionDetectionConfiguration();

            try
            {
                config.ThresholdAlpha = int.Parse(reader.GetAttribute("ThresholdAlpha"));
                config.ThresholdSigma   = int.Parse(reader.GetAttribute("ThresholdSigma"));
            }
            catch (Exception)
            {
            }
            return config;
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(Hashtable reader)
        {
            VsMotionDetectionConfiguration config = new VsMotionDetectionConfiguration();

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
            VsMotionDetectionConfiguration cfg = (VsMotionDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdAlpha", cfg.ThresholdAlpha.ToString());
                writer.WriteAttributeString("ThresholdSigma", cfg.ThresholdSigma.ToString());
            }
        }
    }
}
