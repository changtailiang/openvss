// cfpp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// eadt	
// lvmz	 By downloading, copying, installing or using the software you agree to this license.
// zjub	 If you do not agree to this license, do not download, install,
// thii	 copy or use the software.
// skvj	
// qdwj	                          License Agreement
// pfnr	         For OpenVSS - Open Source Video Surveillance System
// ttlt	
// nndd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vykv	
// xfny	Third party copyrights are property of their respective owners.
// scuu	
// dkur	Redistribution and use in source and binary forms, with or without modification,
// kgzb	are permitted provided that the following conditions are met:
// euef	
// ivff	  * Redistribution's of source code must retain the above copyright notice,
// yaof	    this list of conditions and the following disclaimer.
// dfnt	
// azlk	  * Redistribution's in binary form must reproduce the above copyright notice,
// pxqn	    this list of conditions and the following disclaimer in the documentation
// lsoi	    and/or other materials provided with the distribution.
// ztih	
// ocza	  * Neither the name of the copyright holders nor the names of its contributors 
// ufmc	    may not be used to endorse or promote products derived from this software 
// zhar	    without specific prior written permission.
// nory	
// xark	This software is provided by the copyright holders and contributors "as is" and
// uolg	any express or implied warranties, including, but not limited to, the implied
// dqtp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hwff	In no event shall the Prince of Songkla University or contributors be liable 
// shra	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fnzv	(including, but not limited to, procurement of substitute goods or services;
// mjki	loss of use, data, or profits; or business interruption) however caused
// xzzx	and on any theory of liability, whether in contract, strict liability,
// bplz	or tort (including negligence or otherwise) arising in any way out of
// bxma	the use of this software, even if advised of the possibility of such damage.
// rsxd	
// lxvc	Intelligent Systems Laboratory (iSys Lab)
// buzg	Faculty of Engineering, Prince of Songkla University, THAILAND
// xqsk	Project leader by Nikom SUVONVORN
// bwxl	Project website at http://code.google.com/p/openvss/

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
