// nfrw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yzff	
// qait	 By downloading, copying, installing or using the software you agree to this license.
// nhwt	 If you do not agree to this license, do not download, install,
// wyyi	 copy or use the software.
// dsts	
// nryy	                          License Agreement
// xhrm	         For OpenVss - Open Source Video Surveillance System
// ukla	
// tddo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pwjq	
// irbk	Third party copyrights are property of their respective owners.
// kpbs	
// ebgu	Redistribution and use in source and binary forms, with or without modification,
// lzjg	are permitted provided that the following conditions are met:
// bghj	
// jvyd	  * Redistribution's of source code must retain the above copyright notice,
// vwat	    this list of conditions and the following disclaimer.
// uksh	
// jdjw	  * Redistribution's in binary form must reproduce the above copyright notice,
// qoni	    this list of conditions and the following disclaimer in the documentation
// fyht	    and/or other materials provided with the distribution.
// drou	
// uxmj	  * Neither the name of the copyright holders nor the names of its contributors 
// pahm	    may not be used to endorse or promote products derived from this software 
// syoo	    without specific prior written permission.
// ohyu	
// izli	This software is provided by the copyright holders and contributors "as is" and
// pnqn	any express or implied warranties, including, but not limited to, the implied
// tzdl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ofze	In no event shall the Prince of Songkla University or contributors be liable 
// hgzx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xjri	(including, but not limited to, procurement of substitute goods or services;
// wwds	loss of use, data, or profits; or business interruption) however caused
// zyty	and on any theory of liability, whether in contract, strict liability,
// znld	or tort (including negligence or otherwise) arising in any way out of
// ggeh	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MatchImage
{
    class VsMatchImageDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Images Matching";
        static private string algoDescription = "Image processing algorithm";

        public VsMatchImageDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsMatchImageConfiguration cfg = (VsMatchImageConfiguration)config;

            if (cfg != null)
            {
                VsMatchImage analyser = new VsMatchImage(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsMatchImage)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsMatchImageSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsMatchImageConfiguration config = new VsMatchImageConfiguration();

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
            VsMatchImageConfiguration config = new VsMatchImageConfiguration();

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
            VsMatchImageConfiguration cfg = (VsMatchImageConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdStrong", cfg.ThresholdStrong.ToString());
                writer.WriteAttributeString("ThresholdWeak", cfg.ThresholdWeak.ToString());
                writer.WriteAttributeString("ThresholdHough", cfg.ThresholdHough.ToString());
            }
        }
    }
}
