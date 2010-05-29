// zpar	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ccca	
// qnvq	 By downloading, copying, installing or using the software you agree to this license.
// nlxe	 If you do not agree to this license, do not download, install,
// gpvy	 copy or use the software.
// twtm	
// pawi	                          License Agreement
// ocet	         For OpenVSS - Open Source Video Surveillance System
// atao	
// zimu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kose	
// bben	Third party copyrights are property of their respective owners.
// dibs	
// omod	Redistribution and use in source and binary forms, with or without modification,
// vocc	are permitted provided that the following conditions are met:
// fumo	
// icpu	  * Redistribution's of source code must retain the above copyright notice,
// kiey	    this list of conditions and the following disclaimer.
// dbnf	
// dpkn	  * Redistribution's in binary form must reproduce the above copyright notice,
// vjef	    this list of conditions and the following disclaimer in the documentation
// alfo	    and/or other materials provided with the distribution.
// fxtl	
// gkoq	  * Neither the name of the copyright holders nor the names of its contributors 
// cevz	    may not be used to endorse or promote products derived from this software 
// lkdv	    without specific prior written permission.
// edpm	
// yjzg	This software is provided by the copyright holders and contributors "as is" and
// dogw	any express or implied warranties, including, but not limited to, the implied
// pgnw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xbom	In no event shall the Prince of Songkla University or contributors be liable 
// ptrs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nxdz	(including, but not limited to, procurement of substitute goods or services;
// tlbl	loss of use, data, or profits; or business interruption) however caused
// gjbw	and on any theory of liability, whether in contract, strict liability,
// wspw	or tort (including negligence or otherwise) arising in any way out of
// xmir	the use of this software, even if advised of the possibility of such damage.
// erav	
// qybk	Intelligent Systems Laboratory (iSys Lab)
// vqfk	Faculty of Engineering, Prince of Songkla University, THAILAND
// lxzb	Project leader by Nikom SUVONVORN
// fanr	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.OpticalFlow
{
    class VsOpticalFlowConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdAlpha;
        public int ThresholdSigma;

        public VsOpticalFlowConfiguration()
        {
            ThresholdAlpha = 5;
            ThresholdSigma = 5;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("ThresholdAlpha", ThresholdAlpha);
            config.Add("ThresholdSigma", ThresholdSigma);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            ThresholdAlpha = int.Parse(config["ThresholdAlpha"].ToString());
            ThresholdSigma = int.Parse(config["ThresholdSigma"].ToString());
        }

    }
}
