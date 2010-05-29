// nvtr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// sana	
// euot	 By downloading, copying, installing or using the software you agree to this license.
// oppy	 If you do not agree to this license, do not download, install,
// iayx	 copy or use the software.
// ocns	
// sbjq	                          License Agreement
// xlou	         For OpenVSS - Open Source Video Surveillance System
// hslx	
// skxq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// umje	
// jhuo	Third party copyrights are property of their respective owners.
// pjdt	
// hvsk	Redistribution and use in source and binary forms, with or without modification,
// iazr	are permitted provided that the following conditions are met:
// rwct	
// ftmw	  * Redistribution's of source code must retain the above copyright notice,
// erfx	    this list of conditions and the following disclaimer.
// dhcb	
// tjjk	  * Redistribution's in binary form must reproduce the above copyright notice,
// guao	    this list of conditions and the following disclaimer in the documentation
// hvnl	    and/or other materials provided with the distribution.
// aaor	
// lgzx	  * Neither the name of the copyright holders nor the names of its contributors 
// jpyp	    may not be used to endorse or promote products derived from this software 
// uykx	    without specific prior written permission.
// dgpz	
// tqqz	This software is provided by the copyright holders and contributors "as is" and
// rokw	any express or implied warranties, including, but not limited to, the implied
// wolk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gbwe	In no event shall the Prince of Songkla University or contributors be liable 
// colx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ifrd	(including, but not limited to, procurement of substitute goods or services;
// ktpi	loss of use, data, or profits; or business interruption) however caused
// kcka	and on any theory of liability, whether in contract, strict liability,
// fnsj	or tort (including negligence or otherwise) arising in any way out of
// jpax	the use of this software, even if advised of the possibility of such damage.
// vcbv	
// enjt	Intelligent Systems Laboratory (iSys Lab)
// cgup	Faculty of Engineering, Prince of Songkla University, THAILAND
// vrqn	Project leader by Nikom SUVONVORN
// ynox	Project website at http://code.google.com/p/openvss/

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
