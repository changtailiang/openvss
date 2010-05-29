// qidm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mudv	
// erth	 By downloading, copying, installing or using the software you agree to this license.
// gpvf	 If you do not agree to this license, do not download, install,
// mihu	 copy or use the software.
// dwdo	
// tgpg	                          License Agreement
// pnrc	         For OpenVSS - Open Source Video Surveillance System
// yqwu	
// uqyq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kjay	
// wkru	Third party copyrights are property of their respective owners.
// tfcp	
// zuku	Redistribution and use in source and binary forms, with or without modification,
// fpsg	are permitted provided that the following conditions are met:
// exfr	
// aqjq	  * Redistribution's of source code must retain the above copyright notice,
// sblv	    this list of conditions and the following disclaimer.
// kqjt	
// veri	  * Redistribution's in binary form must reproduce the above copyright notice,
// ovmk	    this list of conditions and the following disclaimer in the documentation
// lbce	    and/or other materials provided with the distribution.
// fcoe	
// xrmn	  * Neither the name of the copyright holders nor the names of its contributors 
// djxg	    may not be used to endorse or promote products derived from this software 
// bbbr	    without specific prior written permission.
// tgfj	
// krya	This software is provided by the copyright holders and contributors "as is" and
// xksj	any express or implied warranties, including, but not limited to, the implied
// kvfz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nfkq	In no event shall the Prince of Songkla University or contributors be liable 
// mgxt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ewpm	(including, but not limited to, procurement of substitute goods or services;
// hlhm	loss of use, data, or profits; or business interruption) however caused
// tvqf	and on any theory of liability, whether in contract, strict liability,
// vtto	or tort (including negligence or otherwise) arising in any way out of
// dngn	the use of this software, even if advised of the possibility of such damage.
// ycci	
// dysw	Intelligent Systems Laboratory (iSys Lab)
// rken	Faculty of Engineering, Prince of Songkla University, THAILAND
// imen	Project leader by Nikom SUVONVORN
// bmtm	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionDetection
{
    class VsMotionDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdAlpha;
        public int ThresholdSigma;

        public VsMotionDetectionConfiguration()
        {
            ThresholdAlpha = 2;
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
