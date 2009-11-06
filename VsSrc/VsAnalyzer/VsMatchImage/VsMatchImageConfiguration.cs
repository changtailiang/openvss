// zxpp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ixll	
// uyuz	 By downloading, copying, installing or using the software you agree to this license.
// pdir	 If you do not agree to this license, do not download, install,
// wayk	 copy or use the software.
// bqhf	
// vtlo	                          License Agreement
// bqkg	         For OpenVss - Open Source Video Surveillance System
// eobe	
// ykvc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// yfid	
// zhxk	Third party copyrights are property of their respective owners.
// artl	
// xqsi	Redistribution and use in source and binary forms, with or without modification,
// pkup	are permitted provided that the following conditions are met:
// lxjd	
// oova	  * Redistribution's of source code must retain the above copyright notice,
// bdsl	    this list of conditions and the following disclaimer.
// fwlw	
// hdgo	  * Redistribution's in binary form must reproduce the above copyright notice,
// wank	    this list of conditions and the following disclaimer in the documentation
// xyio	    and/or other materials provided with the distribution.
// vsoo	
// qgqa	  * Neither the name of the copyright holders nor the names of its contributors 
// wfpk	    may not be used to endorse or promote products derived from this software 
// mwjw	    without specific prior written permission.
// yigb	
// ewbm	This software is provided by the copyright holders and contributors "as is" and
// eftl	any express or implied warranties, including, but not limited to, the implied
// jzgp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fhfi	In no event shall the Prince of Songkla University or contributors be liable 
// oeuz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fkac	(including, but not limited to, procurement of substitute goods or services;
// nvca	loss of use, data, or profits; or business interruption) however caused
// rqlo	and on any theory of liability, whether in contract, strict liability,
// rhjy	or tort (including negligence or otherwise) arising in any way out of
// rcjk	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.MatchImage
{
    class VsMatchImageConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdStrong;
        public int ThresholdWeak;
        public int ThresholdHough;

        public VsMatchImageConfiguration()
        {
            ThresholdStrong = 50;
            ThresholdWeak = 200;
            ThresholdHough = 100;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("ThresholdStrong", ThresholdStrong);
            config.Add("ThresholdWeak", ThresholdWeak);
            config.Add("ThresholdHough", ThresholdHough);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            ThresholdStrong = int.Parse(config["ThresholdStrong"].ToString());
            ThresholdWeak = int.Parse(config["ThresholdWeak"].ToString());
            ThresholdHough = int.Parse(config["ThresholdHough"].ToString());
        }
    }
}
