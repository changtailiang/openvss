// eszu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cplz	
// pcyu	 By downloading, copying, installing or using the software you agree to this license.
// mxfk	 If you do not agree to this license, do not download, install,
// axih	 copy or use the software.
// xmxc	
// nqyt	                          License Agreement
// gfzx	         For OpenVSS - Open Source Video Surveillance System
// ncyr	
// dchl	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hwkx	
// jcqg	Third party copyrights are property of their respective owners.
// pssu	
// uper	Redistribution and use in source and binary forms, with or without modification,
// uwhl	are permitted provided that the following conditions are met:
// qssk	
// dbhk	  * Redistribution's of source code must retain the above copyright notice,
// yogy	    this list of conditions and the following disclaimer.
// pxab	
// bask	  * Redistribution's in binary form must reproduce the above copyright notice,
// aseo	    this list of conditions and the following disclaimer in the documentation
// mecy	    and/or other materials provided with the distribution.
// xgwh	
// uvup	  * Neither the name of the copyright holders nor the names of its contributors 
// daui	    may not be used to endorse or promote products derived from this software 
// vghb	    without specific prior written permission.
// ltew	
// pdpu	This software is provided by the copyright holders and contributors "as is" and
// dwly	any express or implied warranties, including, but not limited to, the implied
// oexy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yjmr	In no event shall the Prince of Songkla University or contributors be liable 
// rzdt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dkxa	(including, but not limited to, procurement of substitute goods or services;
// fkpu	loss of use, data, or profits; or business interruption) however caused
// kcct	and on any theory of liability, whether in contract, strict liability,
// afju	or tort (including negligence or otherwise) arising in any way out of
// qbdy	the use of this software, even if advised of the possibility of such damage.
// kvby	
// dwjm	Intelligent Systems Laboratory (iSys Lab)
// uqkm	Faculty of Engineering, Prince of Songkla University, THAILAND
// pkte	Project leader by Nikom SUVONVORN
// fpos	Project website at http://code.google.com/p/openvss/

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
