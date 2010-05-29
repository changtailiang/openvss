// anqd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// memk	
// vabv	 By downloading, copying, installing or using the software you agree to this license.
// vunb	 If you do not agree to this license, do not download, install,
// eirj	 copy or use the software.
// imwg	
// ykpz	                          License Agreement
// jvvw	         For OpenVSS - Open Source Video Surveillance System
// mkvz	
// dmsp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wufr	
// nuns	Third party copyrights are property of their respective owners.
// ijam	
// ctun	Redistribution and use in source and binary forms, with or without modification,
// qjeb	are permitted provided that the following conditions are met:
// onba	
// feil	  * Redistribution's of source code must retain the above copyright notice,
// yoyr	    this list of conditions and the following disclaimer.
// qbno	
// hfte	  * Redistribution's in binary form must reproduce the above copyright notice,
// xxqz	    this list of conditions and the following disclaimer in the documentation
// vius	    and/or other materials provided with the distribution.
// phit	
// iqaj	  * Neither the name of the copyright holders nor the names of its contributors 
// sflj	    may not be used to endorse or promote products derived from this software 
// lctt	    without specific prior written permission.
// liwa	
// fgfl	This software is provided by the copyright holders and contributors "as is" and
// qzer	any express or implied warranties, including, but not limited to, the implied
// wbfw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kqvr	In no event shall the Prince of Songkla University or contributors be liable 
// feiz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bewc	(including, but not limited to, procurement of substitute goods or services;
// tktu	loss of use, data, or profits; or business interruption) however caused
// dxom	and on any theory of liability, whether in contract, strict liability,
// mtmj	or tort (including negligence or otherwise) arising in any way out of
// cxdi	the use of this software, even if advised of the possibility of such damage.
// ljmq	
// apyv	Intelligent Systems Laboratory (iSys Lab)
// gcng	Faculty of Engineering, Prince of Songkla University, THAILAND
// zwzb	Project leader by Nikom SUVONVORN
// kdsg	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.FqiDetection
{
    class VsFqiDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Face Quality Index Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsFqiDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsFqiDetectionConfiguration cfg = (VsFqiDetectionConfiguration)config;

            if (cfg != null)
            {
                VsFqiDetection analyser = new VsFqiDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsFqiDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsFqiDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsFqiDetectionConfiguration config = new VsFqiDetectionConfiguration();

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
            VsFqiDetectionConfiguration config = new VsFqiDetectionConfiguration();

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
            VsFqiDetectionConfiguration cfg = (VsFqiDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("Threshold", cfg.Threshold.ToString());
            }
        }
    }
}
