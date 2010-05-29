// gehb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bboh	
// aaqu	 By downloading, copying, installing or using the software you agree to this license.
// nrcp	 If you do not agree to this license, do not download, install,
// edrs	 copy or use the software.
// izpq	
// awkk	                          License Agreement
// tuam	         For OpenVSS - Open Source Video Surveillance System
// gzzs	
// yyxb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ohyd	
// nfcm	Third party copyrights are property of their respective owners.
// hwyt	
// ljjg	Redistribution and use in source and binary forms, with or without modification,
// prae	are permitted provided that the following conditions are met:
// rdnf	
// zdoo	  * Redistribution's of source code must retain the above copyright notice,
// rkrg	    this list of conditions and the following disclaimer.
// fqda	
// bmcv	  * Redistribution's in binary form must reproduce the above copyright notice,
// uxdw	    this list of conditions and the following disclaimer in the documentation
// vhbw	    and/or other materials provided with the distribution.
// ptdg	
// xskl	  * Neither the name of the copyright holders nor the names of its contributors 
// tsdj	    may not be used to endorse or promote products derived from this software 
// rnvx	    without specific prior written permission.
// frnu	
// fifd	This software is provided by the copyright holders and contributors "as is" and
// ofkt	any express or implied warranties, including, but not limited to, the implied
// arks	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cryy	In no event shall the Prince of Songkla University or contributors be liable 
// hkim	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fshj	(including, but not limited to, procurement of substitute goods or services;
// iteg	loss of use, data, or profits; or business interruption) however caused
// cfqd	and on any theory of liability, whether in contract, strict liability,
// tgqg	or tort (including negligence or otherwise) arising in any way out of
// oars	the use of this software, even if advised of the possibility of such damage.
// iqlc	
// hlgz	Intelligent Systems Laboratory (iSys Lab)
// owqv	Faculty of Engineering, Prince of Songkla University, THAILAND
// japm	Project leader by Nikom SUVONVORN
// bvuv	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EllipseDetection
{
    class VsEllipseDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Ellipse Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsEllipseDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsEllipseDetectionConfiguration cfg = (VsEllipseDetectionConfiguration)config;

            if (cfg != null)
            {
                VsEllipseDetection analyser = new VsEllipseDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsEllipseDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsEllipseDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsEllipseDetectionConfiguration config = new VsEllipseDetectionConfiguration();

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
            VsEllipseDetectionConfiguration config = new VsEllipseDetectionConfiguration();

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
            VsEllipseDetectionConfiguration cfg = (VsEllipseDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("Threshold", cfg.Threshold.ToString());
            }
        }
    }
}
