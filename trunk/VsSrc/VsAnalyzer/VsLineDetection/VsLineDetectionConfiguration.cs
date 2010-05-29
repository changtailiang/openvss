// zuvi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nihi	
// peuz	 By downloading, copying, installing or using the software you agree to this license.
// vwmw	 If you do not agree to this license, do not download, install,
// fqvv	 copy or use the software.
// jstr	
// rusf	                          License Agreement
// nlkg	         For OpenVSS - Open Source Video Surveillance System
// bzro	
// pmox	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eqie	
// grax	Third party copyrights are property of their respective owners.
// gagr	
// lyig	Redistribution and use in source and binary forms, with or without modification,
// bers	are permitted provided that the following conditions are met:
// pbue	
// tnyw	  * Redistribution's of source code must retain the above copyright notice,
// fygs	    this list of conditions and the following disclaimer.
// bxrt	
// jokz	  * Redistribution's in binary form must reproduce the above copyright notice,
// uuyn	    this list of conditions and the following disclaimer in the documentation
// esud	    and/or other materials provided with the distribution.
// rknl	
// vwhc	  * Neither the name of the copyright holders nor the names of its contributors 
// vels	    may not be used to endorse or promote products derived from this software 
// tesi	    without specific prior written permission.
// tnpn	
// hoxm	This software is provided by the copyright holders and contributors "as is" and
// trxu	any express or implied warranties, including, but not limited to, the implied
// dhza	warranties of merchantability and fitness for a particular purpose are disclaimed.
// svev	In no event shall the Prince of Songkla University or contributors be liable 
// lvxf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// poxf	(including, but not limited to, procurement of substitute goods or services;
// dsgq	loss of use, data, or profits; or business interruption) however caused
// cqtr	and on any theory of liability, whether in contract, strict liability,
// dgvc	or tort (including negligence or otherwise) arising in any way out of
// mard	the use of this software, even if advised of the possibility of such damage.
// ymzn	
// ekzx	Intelligent Systems Laboratory (iSys Lab)
// zxwy	Faculty of Engineering, Prince of Songkla University, THAILAND
// pjxs	Project leader by Nikom SUVONVORN
// qsjb	Project website at http://code.google.com/p/openvss/

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
