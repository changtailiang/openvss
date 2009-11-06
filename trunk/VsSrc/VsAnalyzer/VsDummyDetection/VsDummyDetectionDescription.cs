// tpga	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ehki	
// lsjn	 By downloading, copying, installing or using the software you agree to this license.
// xzlk	 If you do not agree to this license, do not download, install,
// gwwh	 copy or use the software.
// htpl	
// qqsj	                          License Agreement
// ybnr	         For OpenVss - Open Source Video Surveillance System
// perp	
// sbrr	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dwax	
// avpi	Third party copyrights are property of their respective owners.
// rseb	
// bxea	Redistribution and use in source and binary forms, with or without modification,
// avjo	are permitted provided that the following conditions are met:
// pajj	
// fsxt	  * Redistribution's of source code must retain the above copyright notice,
// hvrf	    this list of conditions and the following disclaimer.
// efdl	
// srlv	  * Redistribution's in binary form must reproduce the above copyright notice,
// ajsg	    this list of conditions and the following disclaimer in the documentation
// xlps	    and/or other materials provided with the distribution.
// zrpx	
// rdbd	  * Neither the name of the copyright holders nor the names of its contributors 
// mrsh	    may not be used to endorse or promote products derived from this software 
// xwaw	    without specific prior written permission.
// azww	
// tsii	This software is provided by the copyright holders and contributors "as is" and
// konf	any express or implied warranties, including, but not limited to, the implied
// idlt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// deuq	In no event shall the Prince of Songkla University or contributors be liable 
// gtnb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dazb	(including, but not limited to, procurement of substitute goods or services;
// ydxe	loss of use, data, or profits; or business interruption) however caused
// jwfy	and on any theory of liability, whether in contract, strict liability,
// pszg	or tort (including negligence or otherwise) arising in any way out of
// ihnd	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.DummyDetection
{
    class VsDummyDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Dummy Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsDummyDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsDummyDetectionConfiguration cfg = (VsDummyDetectionConfiguration)config;

            if (cfg != null)
            {
                VsDummyDetection analyser = new VsDummyDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();
                analyser.AnalyserName = algorithmName;

                return (VsDummyDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsDummyDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsDummyDetectionConfiguration config = new VsDummyDetectionConfiguration();

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
            VsDummyDetectionConfiguration config = new VsDummyDetectionConfiguration();

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
            VsDummyDetectionConfiguration cfg = (VsDummyDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdAlpha", cfg.ThresholdAlpha.ToString());
                writer.WriteAttributeString("ThresholdSigma", cfg.ThresholdSigma.ToString());
            }
        }
    }
}
