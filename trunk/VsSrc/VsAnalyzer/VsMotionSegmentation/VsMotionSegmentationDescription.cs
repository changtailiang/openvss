// hvcy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kwlc	
// wckn	 By downloading, copying, installing or using the software you agree to this license.
// zpwt	 If you do not agree to this license, do not download, install,
// xsrq	 copy or use the software.
// syck	
// rddo	                          License Agreement
// drsr	         For OpenVss - Open Source Video Surveillance System
// bosj	
// evot	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ynho	
// cjms	Third party copyrights are property of their respective owners.
// qbbu	
// ohxi	Redistribution and use in source and binary forms, with or without modification,
// tsgh	are permitted provided that the following conditions are met:
// txze	
// ksll	  * Redistribution's of source code must retain the above copyright notice,
// xmob	    this list of conditions and the following disclaimer.
// eyrf	
// rohi	  * Redistribution's in binary form must reproduce the above copyright notice,
// qkxc	    this list of conditions and the following disclaimer in the documentation
// qxdu	    and/or other materials provided with the distribution.
// rkqm	
// pgab	  * Neither the name of the copyright holders nor the names of its contributors 
// ocdk	    may not be used to endorse or promote products derived from this software 
// xbve	    without specific prior written permission.
// mzqp	
// psqf	This software is provided by the copyright holders and contributors "as is" and
// kxri	any express or implied warranties, including, but not limited to, the implied
// zwon	warranties of merchantability and fitness for a particular purpose are disclaimed.
// prtm	In no event shall the Prince of Songkla University or contributors be liable 
// wcmy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ypqo	(including, but not limited to, procurement of substitute goods or services;
// kwlo	loss of use, data, or profits; or business interruption) however caused
// otqq	and on any theory of liability, whether in contract, strict liability,
// hnfz	or tort (including negligence or otherwise) arising in any way out of
// tkbr	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionSegmentation
{
    class VsMotionSegmentationDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Motion Segmentation";
        static private string algoDescription = "Image processing algorithm";

        public VsMotionSegmentationDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsMotionSegmentationConfiguration cfg = (VsMotionSegmentationConfiguration)config;

            if (cfg != null)
            {
                VsMotionSegmentation analyser = new VsMotionSegmentation(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsMotionSegmentation)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsMotionSegmentationSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsMotionSegmentationConfiguration config = new VsMotionSegmentationConfiguration();

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
            VsMotionSegmentationConfiguration config = new VsMotionSegmentationConfiguration();

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
            VsMotionSegmentationConfiguration cfg = (VsMotionSegmentationConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdAlpha", cfg.ThresholdAlpha.ToString());
                writer.WriteAttributeString("ThresholdSigma", cfg.ThresholdSigma.ToString());
            }
        }
    }
}
