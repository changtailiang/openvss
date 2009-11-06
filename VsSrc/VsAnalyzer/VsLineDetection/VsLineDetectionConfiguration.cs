// pfqw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vjjn	
// ygks	 By downloading, copying, installing or using the software you agree to this license.
// jnaz	 If you do not agree to this license, do not download, install,
// mtyj	 copy or use the software.
// icjd	
// gqdk	                          License Agreement
// jfho	         For OpenVss - Open Source Video Surveillance System
// asop	
// vukg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lolu	
// hzwt	Third party copyrights are property of their respective owners.
// ipnx	
// ajkn	Redistribution and use in source and binary forms, with or without modification,
// wnpf	are permitted provided that the following conditions are met:
// fzes	
// zvsr	  * Redistribution's of source code must retain the above copyright notice,
// zlds	    this list of conditions and the following disclaimer.
// iryu	
// qowh	  * Redistribution's in binary form must reproduce the above copyright notice,
// tkbu	    this list of conditions and the following disclaimer in the documentation
// rknq	    and/or other materials provided with the distribution.
// hbti	
// efbm	  * Neither the name of the copyright holders nor the names of its contributors 
// jsvl	    may not be used to endorse or promote products derived from this software 
// gftx	    without specific prior written permission.
// lvoi	
// kqwh	This software is provided by the copyright holders and contributors "as is" and
// qilv	any express or implied warranties, including, but not limited to, the implied
// xkbo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hbjy	In no event shall the Prince of Songkla University or contributors be liable 
// rvnd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qmky	(including, but not limited to, procurement of substitute goods or services;
// tkan	loss of use, data, or profits; or business interruption) however caused
// qeiw	and on any theory of liability, whether in contract, strict liability,
// wfgr	or tort (including negligence or otherwise) arising in any way out of
// elrw	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.LineDetection
{
    class VsLineDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdStrong;
        public int ThresholdWeak;
        public int ThresholdHough;

        public VsLineDetectionConfiguration()
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
