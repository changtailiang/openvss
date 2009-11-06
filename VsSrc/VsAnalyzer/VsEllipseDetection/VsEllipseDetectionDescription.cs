// uhjg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mbol	
// hxsm	 By downloading, copying, installing or using the software you agree to this license.
// tdlr	 If you do not agree to this license, do not download, install,
// gdus	 copy or use the software.
// leer	
// vuyj	                          License Agreement
// qiki	         For OpenVss - Open Source Video Surveillance System
// rpdp	
// udpm	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jiio	
// asqo	Third party copyrights are property of their respective owners.
// dvss	
// cowp	Redistribution and use in source and binary forms, with or without modification,
// dsls	are permitted provided that the following conditions are met:
// dfvz	
// nkue	  * Redistribution's of source code must retain the above copyright notice,
// avxc	    this list of conditions and the following disclaimer.
// nhid	
// vpqc	  * Redistribution's in binary form must reproduce the above copyright notice,
// djfv	    this list of conditions and the following disclaimer in the documentation
// prgc	    and/or other materials provided with the distribution.
// tnmc	
// sxje	  * Neither the name of the copyright holders nor the names of its contributors 
// njbq	    may not be used to endorse or promote products derived from this software 
// ymoi	    without specific prior written permission.
// yqfu	
// gtun	This software is provided by the copyright holders and contributors "as is" and
// bjot	any express or implied warranties, including, but not limited to, the implied
// zajv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// erkm	In no event shall the Prince of Songkla University or contributors be liable 
// jvkp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ydqm	(including, but not limited to, procurement of substitute goods or services;
// oadr	loss of use, data, or profits; or business interruption) however caused
// vxwz	and on any theory of liability, whether in contract, strict liability,
// mlwa	or tort (including negligence or otherwise) arising in any way out of
// tyai	the use of this software, even if advised of the possibility of such damage.

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
