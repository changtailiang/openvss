// kwul	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zzma	
// rzwb	 By downloading, copying, installing or using the software you agree to this license.
// tgmh	 If you do not agree to this license, do not download, install,
// leaf	 copy or use the software.
// ucya	
// wxkl	                          License Agreement
// kypj	         For OpenVSS - Open Source Video Surveillance System
// wndy	
// mdcx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ktnn	
// aotf	Third party copyrights are property of their respective owners.
// vtof	
// dzni	Redistribution and use in source and binary forms, with or without modification,
// xuoc	are permitted provided that the following conditions are met:
// paqt	
// jnef	  * Redistribution's of source code must retain the above copyright notice,
// cnui	    this list of conditions and the following disclaimer.
// bcvb	
// okzi	  * Redistribution's in binary form must reproduce the above copyright notice,
// depq	    this list of conditions and the following disclaimer in the documentation
// jjgx	    and/or other materials provided with the distribution.
// zvbr	
// oaij	  * Neither the name of the copyright holders nor the names of its contributors 
// cuen	    may not be used to endorse or promote products derived from this software 
// koch	    without specific prior written permission.
// zfdb	
// dmum	This software is provided by the copyright holders and contributors "as is" and
// vgyk	any express or implied warranties, including, but not limited to, the implied
// kajz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hgfh	In no event shall the Prince of Songkla University or contributors be liable 
// mdtb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tlyt	(including, but not limited to, procurement of substitute goods or services;
// gmxp	loss of use, data, or profits; or business interruption) however caused
// bhre	and on any theory of liability, whether in contract, strict liability,
// gftn	or tort (including negligence or otherwise) arising in any way out of
// bowi	the use of this software, even if advised of the possibility of such damage.
// cxyc	
// lefd	Intelligent Systems Laboratory (iSys Lab)
// ivvw	Faculty of Engineering, Prince of Songkla University, THAILAND
// mchs	Project leader by Nikom SUVONVORN
// oafi	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.SquareDetection
{
    class VsSquareDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Square Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsSquareDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsSquareDetectionConfiguration cfg = (VsSquareDetectionConfiguration)config;

            if (cfg != null)
            {
                VsSquareDetection analyser = new VsSquareDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsSquareDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsSquareDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsSquareDetectionConfiguration config = new VsSquareDetectionConfiguration();

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
            VsSquareDetectionConfiguration config = new VsSquareDetectionConfiguration();

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
            VsSquareDetectionConfiguration cfg = (VsSquareDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("Threshold", cfg.Threshold.ToString());
            }
        }
    }
}
