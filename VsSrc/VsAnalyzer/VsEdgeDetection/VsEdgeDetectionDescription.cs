// atrn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// diyc	
// qebg	 By downloading, copying, installing or using the software you agree to this license.
// dgaq	 If you do not agree to this license, do not download, install,
// yzmo	 copy or use the software.
// koni	
// mhuk	                          License Agreement
// bwgm	         For OpenVss - Open Source Video Surveillance System
// lvbz	
// udpz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// czkv	
// dnsw	Third party copyrights are property of their respective owners.
// jcls	
// gptl	Redistribution and use in source and binary forms, with or without modification,
// gjaw	are permitted provided that the following conditions are met:
// ooau	
// ypvh	  * Redistribution's of source code must retain the above copyright notice,
// ebwv	    this list of conditions and the following disclaimer.
// knlk	
// erfy	  * Redistribution's in binary form must reproduce the above copyright notice,
// oxbz	    this list of conditions and the following disclaimer in the documentation
// knfv	    and/or other materials provided with the distribution.
// cqsl	
// cslo	  * Neither the name of the copyright holders nor the names of its contributors 
// ypxn	    may not be used to endorse or promote products derived from this software 
// skri	    without specific prior written permission.
// gqht	
// dihp	This software is provided by the copyright holders and contributors "as is" and
// dbiq	any express or implied warranties, including, but not limited to, the implied
// nbjk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kzfo	In no event shall the Prince of Songkla University or contributors be liable 
// ikss	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bxlo	(including, but not limited to, procurement of substitute goods or services;
// urge	loss of use, data, or profits; or business interruption) however caused
// fstu	and on any theory of liability, whether in contract, strict liability,
// gmst	or tort (including negligence or otherwise) arising in any way out of
// ichb	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EdgeDetection
{
    class VsEdgeDetectionDescription : VsICoreAnalyzerDescription
    {
        static private string algorithmName = "Edge Detection";
        static private string algoDescription = "Image processing algorithm";

        public VsEdgeDetectionDescription()
        {
        }

        VsICoreAnalyzer VsICoreAnalyzerDescription.CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config)
        {
            VsEdgeDetectionConfiguration cfg = (VsEdgeDetectionConfiguration)config;

            if (cfg != null)
            {
                VsEdgeDetection analyser = new VsEdgeDetection(syncTimer);

                analyser.AnalyzerConfiguration = cfg.GetConfiguration();

                return (VsEdgeDetection)analyser;
            }
            return null;
        }

        string VsICoreAnalyzerDescription.Description
        {
            get { return algoDescription; }
        }

        VsICoreAnalyzerPage VsICoreAnalyzerDescription.GetSettingsPage()
        {
            return new VsEdgeDetectionSetupPage(); 
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsEdgeDetectionConfiguration config = new VsEdgeDetectionConfiguration();

            try
            {
                config.ThresholdStrong = int.Parse(reader.GetAttribute("ThresholdStrong"));
                config.ThresholdWeak   = int.Parse(reader.GetAttribute("ThresholdWeak"));
            }
            catch (Exception)
            {
            }
            return config;
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerDescription.LoadConfiguration(Hashtable reader)
        {
            VsEdgeDetectionConfiguration config = new VsEdgeDetectionConfiguration();

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
            VsEdgeDetectionConfiguration cfg = (VsEdgeDetectionConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ThresholdStrong", cfg.ThresholdStrong.ToString());
                writer.WriteAttributeString("ThresholdWeak", cfg.ThresholdWeak.ToString());
            }
        }
    }
}
