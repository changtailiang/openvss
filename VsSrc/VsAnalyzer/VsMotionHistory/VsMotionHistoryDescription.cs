// jmjr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tccx	
// afph	 By downloading, copying, installing or using the software you agree to this license.
// glkv	 If you do not agree to this license, do not download, install,
// sujz	 copy or use the software.
// pxbg	
// qxjs	                          License Agreement
// qfll	         For OpenVss - Open Source Video Surveillance System
// qfie	
// qywz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// asjh	
// zpjd	Third party copyrights are property of their respective owners.
// vlfk	
// gaol	Redistribution and use in source and binary forms, with or without modification,
// lcaw	are permitted provided that the following conditions are met:
// tjgu	
// teqa	  * Redistribution's of source code must retain the above copyright notice,
// cffu	    this list of conditions and the following disclaimer.
// ykyw	
// ouha	  * Redistribution's in binary form must reproduce the above copyright notice,
// ogwf	    this list of conditions and the following disclaimer in the documentation
// zbep	    and/or other materials provided with the distribution.
// rxtn	
// yzgq	  * Neither the name of the copyright holders nor the names of its contributors 
// monv	    may not be used to endorse or promote products derived from this software 
// zjaq	    without specific prior written permission.
// gllw	
// brxr	This software is provided by the copyright holders and contributors "as is" and
// vzim	any express or implied warranties, including, but not limited to, the implied
// mbvs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zajf	In no event shall the Prince of Songkla University or contributors be liable 
// lrvy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dhkz	(including, but not limited to, procurement of substitute goods or services;
// gmbe	loss of use, data, or profits; or business interruption) however caused
// fgzo	and on any theory of liability, whether in contract, strict liability,
// phoz	or tort (including negligence or otherwise) arising in any way out of
// acsz	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionHistory
{
    class VsMotionHistoryDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Motion History";
        static private string algoDescription = "Image processing algorithm";

        public VsMotionHistoryDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsMotionHistoryConfiguration cfg = (VsMotionHistoryConfiguration)config;

            if (cfg != null)
            {
                VsMotionHistory analyser = new VsMotionHistory(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsMotionHistory)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsMotionHistorySetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsMotionHistoryConfiguration config = new VsMotionHistoryConfiguration();

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
            VsMotionHistoryConfiguration config = new VsMotionHistoryConfiguration();

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
            VsMotionHistoryConfiguration cfg = (VsMotionHistoryConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdAlpha", cfg.ThresholdAlpha.ToString());
                writer.WriteAttributeString("ThresholdSigma", cfg.ThresholdSigma.ToString());
            }
        }
    }
}
