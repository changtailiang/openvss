// qekf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// drdp	
// qsbh	 By downloading, copying, installing or using the software you agree to this license.
// ddyg	 If you do not agree to this license, do not download, install,
// uqul	 copy or use the software.
// jdff	
// qpvh	                          License Agreement
// lbln	         For OpenVss - Open Source Video Surveillance System
// nkab	
// qucu	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// tbkp	
// dtaz	Third party copyrights are property of their respective owners.
// rmeh	
// iham	Redistribution and use in source and binary forms, with or without modification,
// yfpo	are permitted provided that the following conditions are met:
// wwdo	
// gout	  * Redistribution's of source code must retain the above copyright notice,
// cwpz	    this list of conditions and the following disclaimer.
// nzrh	
// sqbw	  * Redistribution's in binary form must reproduce the above copyright notice,
// ovqy	    this list of conditions and the following disclaimer in the documentation
// xeff	    and/or other materials provided with the distribution.
// kncl	
// foyx	  * Neither the name of the copyright holders nor the names of its contributors 
// xwip	    may not be used to endorse or promote products derived from this software 
// zhxu	    without specific prior written permission.
// wfti	
// psui	This software is provided by the copyright holders and contributors "as is" and
// dtza	any express or implied warranties, including, but not limited to, the implied
// gerc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iojo	In no event shall the Prince of Songkla University or contributors be liable 
// teuz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bukw	(including, but not limited to, procurement of substitute goods or services;
// hlxg	loss of use, data, or profits; or business interruption) however caused
// xvcr	and on any theory of liability, whether in contract, strict liability,
// kxpr	or tort (including negligence or otherwise) arising in any way out of
// tuhm	the use of this software, even if advised of the possibility of such damage.

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
