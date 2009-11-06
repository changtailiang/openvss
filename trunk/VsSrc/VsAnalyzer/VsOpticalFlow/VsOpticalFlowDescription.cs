// jgoa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ursf	
// npyb	 By downloading, copying, installing or using the software you agree to this license.
// vjlc	 If you do not agree to this license, do not download, install,
// mbjs	 copy or use the software.
// oysy	
// vfnx	                          License Agreement
// edxg	         For OpenVss - Open Source Video Surveillance System
// sisw	
// ybxe	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vlul	
// bvyo	Third party copyrights are property of their respective owners.
// frgw	
// wjil	Redistribution and use in source and binary forms, with or without modification,
// nqep	are permitted provided that the following conditions are met:
// euak	
// ssin	  * Redistribution's of source code must retain the above copyright notice,
// rpdk	    this list of conditions and the following disclaimer.
// efxd	
// dhwz	  * Redistribution's in binary form must reproduce the above copyright notice,
// hzrm	    this list of conditions and the following disclaimer in the documentation
// wbjj	    and/or other materials provided with the distribution.
// ahii	
// xhab	  * Neither the name of the copyright holders nor the names of its contributors 
// kksj	    may not be used to endorse or promote products derived from this software 
// nkwq	    without specific prior written permission.
// ovrr	
// lfhg	This software is provided by the copyright holders and contributors "as is" and
// teie	any express or implied warranties, including, but not limited to, the implied
// conr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iymj	In no event shall the Prince of Songkla University or contributors be liable 
// hvnw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fwst	(including, but not limited to, procurement of substitute goods or services;
// onmw	loss of use, data, or profits; or business interruption) however caused
// cbyb	and on any theory of liability, whether in contract, strict liability,
// jryv	or tort (including negligence or otherwise) arising in any way out of
// zcot	the use of this software, even if advised of the possibility of such damage.

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
