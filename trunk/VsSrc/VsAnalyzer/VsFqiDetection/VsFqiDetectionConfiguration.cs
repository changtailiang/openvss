// udgu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fqoh	
// qauo	 By downloading, copying, installing or using the software you agree to this license.
// dfki	 If you do not agree to this license, do not download, install,
// fezo	 copy or use the software.
// bayr	
// xdai	                          License Agreement
// qebm	         For OpenVSS - Open Source Video Surveillance System
// wkqp	
// ugpx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ncnp	
// sndw	Third party copyrights are property of their respective owners.
// ufak	
// kzjt	Redistribution and use in source and binary forms, with or without modification,
// epxb	are permitted provided that the following conditions are met:
// qfql	
// zhrt	  * Redistribution's of source code must retain the above copyright notice,
// puny	    this list of conditions and the following disclaimer.
// ocbz	
// njyj	  * Redistribution's in binary form must reproduce the above copyright notice,
// zdnl	    this list of conditions and the following disclaimer in the documentation
// ercx	    and/or other materials provided with the distribution.
// bwke	
// jogh	  * Neither the name of the copyright holders nor the names of its contributors 
// lbqk	    may not be used to endorse or promote products derived from this software 
// vkhz	    without specific prior written permission.
// rbwh	
// yjgv	This software is provided by the copyright holders and contributors "as is" and
// rncm	any express or implied warranties, including, but not limited to, the implied
// rfhh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fuss	In no event shall the Prince of Songkla University or contributors be liable 
// kipa	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vtol	(including, but not limited to, procurement of substitute goods or services;
// snnp	loss of use, data, or profits; or business interruption) however caused
// wotc	and on any theory of liability, whether in contract, strict liability,
// vuzr	or tort (including negligence or otherwise) arising in any way out of
// qpnv	the use of this software, even if advised of the possibility of such damage.
// mupf	
// uiea	Intelligent Systems Laboratory (iSys Lab)
// sppi	Faculty of Engineering, Prince of Songkla University, THAILAND
// mwle	Project leader by Nikom SUVONVORN
// vudd	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.FqiDetection
{
    class VsFqiDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int Threshold;

        public VsFqiDetectionConfiguration()
        {
            Threshold = 30;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("Threshold", Threshold);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            Threshold = int.Parse(config["Threshold"].ToString());
        }

    }
}
