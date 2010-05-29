// wfsj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jdqf	
// ajin	 By downloading, copying, installing or using the software you agree to this license.
// woig	 If you do not agree to this license, do not download, install,
// cods	 copy or use the software.
// dath	
// vnwb	                          License Agreement
// vcqb	         For OpenVSS - Open Source Video Surveillance System
// ypkr	
// woav	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eoll	
// izrv	Third party copyrights are property of their respective owners.
// wbwk	
// ycbw	Redistribution and use in source and binary forms, with or without modification,
// mkow	are permitted provided that the following conditions are met:
// gpkx	
// thpg	  * Redistribution's of source code must retain the above copyright notice,
// dqkn	    this list of conditions and the following disclaimer.
// nhnp	
// pizv	  * Redistribution's in binary form must reproduce the above copyright notice,
// waet	    this list of conditions and the following disclaimer in the documentation
// fgcw	    and/or other materials provided with the distribution.
// ooel	
// aeop	  * Neither the name of the copyright holders nor the names of its contributors 
// dnra	    may not be used to endorse or promote products derived from this software 
// kksg	    without specific prior written permission.
// rjwr	
// olge	This software is provided by the copyright holders and contributors "as is" and
// lszf	any express or implied warranties, including, but not limited to, the implied
// krrn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// etso	In no event shall the Prince of Songkla University or contributors be liable 
// mynj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// txmb	(including, but not limited to, procurement of substitute goods or services;
// qykm	loss of use, data, or profits; or business interruption) however caused
// iycw	and on any theory of liability, whether in contract, strict liability,
// klhd	or tort (including negligence or otherwise) arising in any way out of
// hzah	the use of this software, even if advised of the possibility of such damage.
// eifl	
// wewr	Intelligent Systems Laboratory (iSys Lab)
// sdts	Faculty of Engineering, Prince of Songkla University, THAILAND
// wmxr	Project leader by Nikom SUVONVORN
// yfon	Project website at http://code.google.com/p/openvss/

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
