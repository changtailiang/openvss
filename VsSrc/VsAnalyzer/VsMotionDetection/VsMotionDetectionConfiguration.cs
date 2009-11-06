// bizu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ypbj	
// aflf	 By downloading, copying, installing or using the software you agree to this license.
// fnna	 If you do not agree to this license, do not download, install,
// halm	 copy or use the software.
// orkp	
// euso	                          License Agreement
// opun	         For OpenVss - Open Source Video Surveillance System
// rbch	
// floa	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// sedm	
// kvqq	Third party copyrights are property of their respective owners.
// icay	
// cuuk	Redistribution and use in source and binary forms, with or without modification,
// xjpe	are permitted provided that the following conditions are met:
// wnvk	
// lxnd	  * Redistribution's of source code must retain the above copyright notice,
// lgvv	    this list of conditions and the following disclaimer.
// lluj	
// oyfj	  * Redistribution's in binary form must reproduce the above copyright notice,
// ebgm	    this list of conditions and the following disclaimer in the documentation
// pvlx	    and/or other materials provided with the distribution.
// hrkv	
// vkdf	  * Neither the name of the copyright holders nor the names of its contributors 
// isan	    may not be used to endorse or promote products derived from this software 
// hmec	    without specific prior written permission.
// genr	
// akvy	This software is provided by the copyright holders and contributors "as is" and
// egav	any express or implied warranties, including, but not limited to, the implied
// gjvp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mqwu	In no event shall the Prince of Songkla University or contributors be liable 
// vzza	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hobv	(including, but not limited to, procurement of substitute goods or services;
// xscr	loss of use, data, or profits; or business interruption) however caused
// wdfk	and on any theory of liability, whether in contract, strict liability,
// itxx	or tort (including negligence or otherwise) arising in any way out of
// wlqp	the use of this software, even if advised of the possibility of such damage.

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
