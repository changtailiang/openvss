// pxqs	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// efhk	
// yjar	 By downloading, copying, installing or using the software you agree to this license.
// luhv	 If you do not agree to this license, do not download, install,
// iybr	 copy or use the software.
// vscl	
// casl	                          License Agreement
// zruz	         For OpenVss - Open Source Video Surveillance System
// xikd	
// drrb	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// emio	
// ukfq	Third party copyrights are property of their respective owners.
// qujv	
// tpqw	Redistribution and use in source and binary forms, with or without modification,
// vfqe	are permitted provided that the following conditions are met:
// nvkh	
// obud	  * Redistribution's of source code must retain the above copyright notice,
// jdrq	    this list of conditions and the following disclaimer.
// gznj	
// knqr	  * Redistribution's in binary form must reproduce the above copyright notice,
// ucvf	    this list of conditions and the following disclaimer in the documentation
// izgh	    and/or other materials provided with the distribution.
// rnix	
// bnni	  * Neither the name of the copyright holders nor the names of its contributors 
// baas	    may not be used to endorse or promote products derived from this software 
// qcgm	    without specific prior written permission.
// ctot	
// bhmh	This software is provided by the copyright holders and contributors "as is" and
// pyjl	any express or implied warranties, including, but not limited to, the implied
// afzo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// umlw	In no event shall the Prince of Songkla University or contributors be liable 
// utos	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lfhj	(including, but not limited to, procurement of substitute goods or services;
// nxar	loss of use, data, or profits; or business interruption) however caused
// vicp	and on any theory of liability, whether in contract, strict liability,
// knfk	or tort (including negligence or otherwise) arising in any way out of
// bbid	the use of this software, even if advised of the possibility of such damage.

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
