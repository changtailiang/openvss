// xzxk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// clju	
// fjau	 By downloading, copying, installing or using the software you agree to this license.
// xfht	 If you do not agree to this license, do not download, install,
// cmez	 copy or use the software.
// vgsz	
// kjsq	                          License Agreement
// vyyk	         For OpenVss - Open Source Video Surveillance System
// bqvu	
// wzcj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// snhu	
// ctts	Third party copyrights are property of their respective owners.
// ukhz	
// wgzq	Redistribution and use in source and binary forms, with or without modification,
// gxas	are permitted provided that the following conditions are met:
// tszg	
// lpsh	  * Redistribution's of source code must retain the above copyright notice,
// kmxd	    this list of conditions and the following disclaimer.
// jvgh	
// zyxr	  * Redistribution's in binary form must reproduce the above copyright notice,
// qzvk	    this list of conditions and the following disclaimer in the documentation
// qyou	    and/or other materials provided with the distribution.
// qeoy	
// yjpz	  * Neither the name of the copyright holders nor the names of its contributors 
// naim	    may not be used to endorse or promote products derived from this software 
// amii	    without specific prior written permission.
// nepb	
// arrh	This software is provided by the copyright holders and contributors "as is" and
// ajct	any express or implied warranties, including, but not limited to, the implied
// xppm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bxqf	In no event shall the Prince of Songkla University or contributors be liable 
// yzea	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fguy	(including, but not limited to, procurement of substitute goods or services;
// pkqd	loss of use, data, or profits; or business interruption) however caused
// rnxm	and on any theory of liability, whether in contract, strict liability,
// imuy	or tort (including negligence or otherwise) arising in any way out of
// ngxp	the use of this software, even if advised of the possibility of such damage.

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
