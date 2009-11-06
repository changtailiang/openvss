// rosl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// buls	
// qrbv	 By downloading, copying, installing or using the software you agree to this license.
// dqey	 If you do not agree to this license, do not download, install,
// ayqc	 copy or use the software.
// bimn	
// zpwu	                          License Agreement
// jssq	         For OpenVss - Open Source Video Surveillance System
// gljc	
// pzrw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// blbe	
// emsq	Third party copyrights are property of their respective owners.
// neje	
// unjj	Redistribution and use in source and binary forms, with or without modification,
// cfll	are permitted provided that the following conditions are met:
// xrix	
// zkpr	  * Redistribution's of source code must retain the above copyright notice,
// gbia	    this list of conditions and the following disclaimer.
// htaq	
// hhim	  * Redistribution's in binary form must reproduce the above copyright notice,
// wfgf	    this list of conditions and the following disclaimer in the documentation
// iows	    and/or other materials provided with the distribution.
// bazk	
// nfzk	  * Neither the name of the copyright holders nor the names of its contributors 
// cdfu	    may not be used to endorse or promote products derived from this software 
// xbjl	    without specific prior written permission.
// vjwa	
// ntcu	This software is provided by the copyright holders and contributors "as is" and
// wyos	any express or implied warranties, including, but not limited to, the implied
// kdpl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// oxpg	In no event shall the Prince of Songkla University or contributors be liable 
// cymc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uqnd	(including, but not limited to, procurement of substitute goods or services;
// copv	loss of use, data, or profits; or business interruption) however caused
// vvjz	and on any theory of liability, whether in contract, strict liability,
// rvei	or tort (including negligence or otherwise) arising in any way out of
// yeop	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.LipDetection
{
    class VsLipDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int Threshold;

        public VsLipDetectionConfiguration()
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
