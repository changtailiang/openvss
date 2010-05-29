// aceo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wmhg	
// werr	 By downloading, copying, installing or using the software you agree to this license.
// vfie	 If you do not agree to this license, do not download, install,
// lgzh	 copy or use the software.
// wbwk	
// nqte	                          License Agreement
// bvxj	         For OpenVSS - Open Source Video Surveillance System
// yuye	
// bbym	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// sxey	
// vhah	Third party copyrights are property of their respective owners.
// rxop	
// zkwy	Redistribution and use in source and binary forms, with or without modification,
// gtaf	are permitted provided that the following conditions are met:
// tcea	
// hitb	  * Redistribution's of source code must retain the above copyright notice,
// gecj	    this list of conditions and the following disclaimer.
// impz	
// xypg	  * Redistribution's in binary form must reproduce the above copyright notice,
// pmme	    this list of conditions and the following disclaimer in the documentation
// ghkn	    and/or other materials provided with the distribution.
// xzyi	
// bstp	  * Neither the name of the copyright holders nor the names of its contributors 
// sdrn	    may not be used to endorse or promote products derived from this software 
// oyan	    without specific prior written permission.
// vehm	
// vxbi	This software is provided by the copyright holders and contributors "as is" and
// duph	any express or implied warranties, including, but not limited to, the implied
// qata	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xfeh	In no event shall the Prince of Songkla University or contributors be liable 
// gtiq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tzgt	(including, but not limited to, procurement of substitute goods or services;
// gcsr	loss of use, data, or profits; or business interruption) however caused
// lyjc	and on any theory of liability, whether in contract, strict liability,
// axsa	or tort (including negligence or otherwise) arising in any way out of
// ypeg	the use of this software, even if advised of the possibility of such damage.
// clzs	
// jrpi	Intelligent Systems Laboratory (iSys Lab)
// uthb	Faculty of Engineering, Prince of Songkla University, THAILAND
// vrsv	Project leader by Nikom SUVONVORN
// qhbb	Project website at http://code.google.com/p/openvss/

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
