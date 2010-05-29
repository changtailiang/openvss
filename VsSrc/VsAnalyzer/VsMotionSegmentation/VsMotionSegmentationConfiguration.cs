// ocba	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wlso	
// kpoi	 By downloading, copying, installing or using the software you agree to this license.
// gxgc	 If you do not agree to this license, do not download, install,
// gnkf	 copy or use the software.
// hzkv	
// csay	                          License Agreement
// ouir	         For OpenVSS - Open Source Video Surveillance System
// trti	
// maos	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ldir	
// jhqq	Third party copyrights are property of their respective owners.
// evxo	
// dvao	Redistribution and use in source and binary forms, with or without modification,
// sfye	are permitted provided that the following conditions are met:
// luaq	
// gxpo	  * Redistribution's of source code must retain the above copyright notice,
// eyqg	    this list of conditions and the following disclaimer.
// zrtd	
// rsmu	  * Redistribution's in binary form must reproduce the above copyright notice,
// bjts	    this list of conditions and the following disclaimer in the documentation
// wuox	    and/or other materials provided with the distribution.
// qfqg	
// cjhr	  * Neither the name of the copyright holders nor the names of its contributors 
// cslm	    may not be used to endorse or promote products derived from this software 
// sbmg	    without specific prior written permission.
// fqpl	
// cxxz	This software is provided by the copyright holders and contributors "as is" and
// tdcb	any express or implied warranties, including, but not limited to, the implied
// bitl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iryz	In no event shall the Prince of Songkla University or contributors be liable 
// ijep	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kcay	(including, but not limited to, procurement of substitute goods or services;
// haca	loss of use, data, or profits; or business interruption) however caused
// xmmg	and on any theory of liability, whether in contract, strict liability,
// ecvt	or tort (including negligence or otherwise) arising in any way out of
// hqnz	the use of this software, even if advised of the possibility of such damage.
// gfqu	
// zzda	Intelligent Systems Laboratory (iSys Lab)
// dmyw	Faculty of Engineering, Prince of Songkla University, THAILAND
// maba	Project leader by Nikom SUVONVORN
// wyst	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionSegmentation
{
    class VsMotionSegmentationConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdAlpha;
        public int ThresholdSigma;

        public VsMotionSegmentationConfiguration()
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
