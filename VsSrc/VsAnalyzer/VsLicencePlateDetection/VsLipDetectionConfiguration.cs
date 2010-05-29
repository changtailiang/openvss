// krsq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vkhg	
// cqnd	 By downloading, copying, installing or using the software you agree to this license.
// ttzi	 If you do not agree to this license, do not download, install,
// fchr	 copy or use the software.
// amsc	
// nqjc	                          License Agreement
// tgbv	         For OpenVSS - Open Source Video Surveillance System
// kbhx	
// loxe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// prsi	
// ofue	Third party copyrights are property of their respective owners.
// xxzx	
// feny	Redistribution and use in source and binary forms, with or without modification,
// yqde	are permitted provided that the following conditions are met:
// aemw	
// pssr	  * Redistribution's of source code must retain the above copyright notice,
// lcwr	    this list of conditions and the following disclaimer.
// edbi	
// tjnh	  * Redistribution's in binary form must reproduce the above copyright notice,
// vefv	    this list of conditions and the following disclaimer in the documentation
// gdpf	    and/or other materials provided with the distribution.
// njyv	
// ksdk	  * Neither the name of the copyright holders nor the names of its contributors 
// fwtw	    may not be used to endorse or promote products derived from this software 
// mdtv	    without specific prior written permission.
// bisb	
// dfeo	This software is provided by the copyright holders and contributors "as is" and
// dviv	any express or implied warranties, including, but not limited to, the implied
// zqpl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cndb	In no event shall the Prince of Songkla University or contributors be liable 
// dbgm	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zrdx	(including, but not limited to, procurement of substitute goods or services;
// pqvs	loss of use, data, or profits; or business interruption) however caused
// lkuy	and on any theory of liability, whether in contract, strict liability,
// knci	or tort (including negligence or otherwise) arising in any way out of
// fjro	the use of this software, even if advised of the possibility of such damage.
// khlo	
// hity	Intelligent Systems Laboratory (iSys Lab)
// zrrz	Faculty of Engineering, Prince of Songkla University, THAILAND
// bgcl	Project leader by Nikom SUVONVORN
// bhzm	Project website at http://code.google.com/p/openvss/

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
