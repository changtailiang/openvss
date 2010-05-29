// muqg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// frae	
// lspc	 By downloading, copying, installing or using the software you agree to this license.
// kanv	 If you do not agree to this license, do not download, install,
// xhju	 copy or use the software.
// jrpp	
// dqkz	                          License Agreement
// toqx	         For OpenVSS - Open Source Video Surveillance System
// zqej	
// btqy	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yxyd	
// acal	Third party copyrights are property of their respective owners.
// jeex	
// qsiv	Redistribution and use in source and binary forms, with or without modification,
// fado	are permitted provided that the following conditions are met:
// gblx	
// crdu	  * Redistribution's of source code must retain the above copyright notice,
// vdud	    this list of conditions and the following disclaimer.
// rkwm	
// smoa	  * Redistribution's in binary form must reproduce the above copyright notice,
// qzpp	    this list of conditions and the following disclaimer in the documentation
// jsgg	    and/or other materials provided with the distribution.
// ijea	
// qbrw	  * Neither the name of the copyright holders nor the names of its contributors 
// mabj	    may not be used to endorse or promote products derived from this software 
// zfqf	    without specific prior written permission.
// kbgg	
// wvdt	This software is provided by the copyright holders and contributors "as is" and
// lcxh	any express or implied warranties, including, but not limited to, the implied
// lwoj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kwll	In no event shall the Prince of Songkla University or contributors be liable 
// ztmp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// szar	(including, but not limited to, procurement of substitute goods or services;
// lfbk	loss of use, data, or profits; or business interruption) however caused
// jkfi	and on any theory of liability, whether in contract, strict liability,
// makm	or tort (including negligence or otherwise) arising in any way out of
// glpo	the use of this software, even if advised of the possibility of such damage.
// ekkq	
// mryc	Intelligent Systems Laboratory (iSys Lab)
// uefq	Faculty of Engineering, Prince of Songkla University, THAILAND
// oqnw	Project leader by Nikom SUVONVORN
// vlig	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.OpticalFlow
{
    class VsOpticalFlowDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Optical Flow";
        static private string algoDescription = "Image processing algorithm";

        public VsOpticalFlowDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsOpticalFlowConfiguration cfg = (VsOpticalFlowConfiguration)config;

            if (cfg != null)
            {
                VsOpticalFlow analyser = new VsOpticalFlow(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsOpticalFlow)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsOpticalFlowSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsOpticalFlowConfiguration config = new VsOpticalFlowConfiguration();

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
            VsOpticalFlowConfiguration config = new VsOpticalFlowConfiguration();

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
            VsOpticalFlowConfiguration cfg = (VsOpticalFlowConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdAlpha", cfg.ThresholdAlpha.ToString());
                writer.WriteAttributeString("ThresholdSigma", cfg.ThresholdSigma.ToString());
            }
        }
    }
}
