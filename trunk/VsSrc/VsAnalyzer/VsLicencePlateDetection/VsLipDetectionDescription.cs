// qhzz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nuga	
// ldjx	 By downloading, copying, installing or using the software you agree to this license.
// wtfx	 If you do not agree to this license, do not download, install,
// gysi	 copy or use the software.
// jtwp	
// tqts	                          License Agreement
// shix	         For OpenVss - Open Source Video Surveillance System
// jxmn	
// qnqi	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hojs	
// llcx	Third party copyrights are property of their respective owners.
// phbz	
// mgfw	Redistribution and use in source and binary forms, with or without modification,
// kkfx	are permitted provided that the following conditions are met:
// aoie	
// vmoy	  * Redistribution's of source code must retain the above copyright notice,
// hsgs	    this list of conditions and the following disclaimer.
// ikau	
// jedi	  * Redistribution's in binary form must reproduce the above copyright notice,
// nvck	    this list of conditions and the following disclaimer in the documentation
// fild	    and/or other materials provided with the distribution.
// rpdg	
// htht	  * Neither the name of the copyright holders nor the names of its contributors 
// gfxz	    may not be used to endorse or promote products derived from this software 
// xepx	    without specific prior written permission.
// airb	
// flng	This software is provided by the copyright holders and contributors "as is" and
// gxjf	any express or implied warranties, including, but not limited to, the implied
// lxym	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bkgs	In no event shall the Prince of Songkla University or contributors be liable 
// oalp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dgnd	(including, but not limited to, procurement of substitute goods or services;
// hekj	loss of use, data, or profits; or business interruption) however caused
// fejx	and on any theory of liability, whether in contract, strict liability,
// qjyg	or tort (including negligence or otherwise) arising in any way out of
// bwaj	the use of this software, even if advised of the possibility of such damage.

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
