// ycmt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dkes	
// jmun	 By downloading, copying, installing or using the software you agree to this license.
// nnbf	 If you do not agree to this license, do not download, install,
// ewzx	 copy or use the software.
// kwfe	
// ivfo	                          License Agreement
// welw	         For OpenVSS - Open Source Video Surveillance System
// bdzt	
// qhrt	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jqkq	
// lhch	Third party copyrights are property of their respective owners.
// qljb	
// ormb	Redistribution and use in source and binary forms, with or without modification,
// whli	are permitted provided that the following conditions are met:
// fqwe	
// axmj	  * Redistribution's of source code must retain the above copyright notice,
// ohpw	    this list of conditions and the following disclaimer.
// efou	
// mpsa	  * Redistribution's in binary form must reproduce the above copyright notice,
// txxl	    this list of conditions and the following disclaimer in the documentation
// vjhj	    and/or other materials provided with the distribution.
// rxxi	
// wjos	  * Neither the name of the copyright holders nor the names of its contributors 
// tfpn	    may not be used to endorse or promote products derived from this software 
// vssi	    without specific prior written permission.
// vmxj	
// drph	This software is provided by the copyright holders and contributors "as is" and
// pkoh	any express or implied warranties, including, but not limited to, the implied
// skjr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qcsr	In no event shall the Prince of Songkla University or contributors be liable 
// kgav	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qvah	(including, but not limited to, procurement of substitute goods or services;
// zeeb	loss of use, data, or profits; or business interruption) however caused
// fppi	and on any theory of liability, whether in contract, strict liability,
// mygz	or tort (including negligence or otherwise) arising in any way out of
// iqtl	the use of this software, even if advised of the possibility of such damage.
// uhzi	
// vyxt	Intelligent Systems Laboratory (iSys Lab)
// zbxp	Faculty of Engineering, Prince of Songkla University, THAILAND
// mcsh	Project leader by Nikom SUVONVORN
// qhhl	Project website at http://code.google.com/p/openvss/

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
