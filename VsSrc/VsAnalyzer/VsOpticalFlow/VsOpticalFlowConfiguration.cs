// fbzb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kodf	
// vitc	 By downloading, copying, installing or using the software you agree to this license.
// xjom	 If you do not agree to this license, do not download, install,
// giiu	 copy or use the software.
// azxy	
// djiu	                          License Agreement
// sbnx	         For OpenVss - Open Source Video Surveillance System
// wsxq	
// jzqf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vfny	
// djqx	Third party copyrights are property of their respective owners.
// jzgd	
// rnjf	Redistribution and use in source and binary forms, with or without modification,
// ebya	are permitted provided that the following conditions are met:
// fjmt	
// vvgf	  * Redistribution's of source code must retain the above copyright notice,
// mydg	    this list of conditions and the following disclaimer.
// rczv	
// mzvt	  * Redistribution's in binary form must reproduce the above copyright notice,
// tlkt	    this list of conditions and the following disclaimer in the documentation
// ujgi	    and/or other materials provided with the distribution.
// irli	
// bqam	  * Neither the name of the copyright holders nor the names of its contributors 
// tudh	    may not be used to endorse or promote products derived from this software 
// dkkk	    without specific prior written permission.
// walo	
// ootf	This software is provided by the copyright holders and contributors "as is" and
// gegt	any express or implied warranties, including, but not limited to, the implied
// ytzl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pxxv	In no event shall the Prince of Songkla University or contributors be liable 
// mueb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cmbs	(including, but not limited to, procurement of substitute goods or services;
// vnqi	loss of use, data, or profits; or business interruption) however caused
// aaxt	and on any theory of liability, whether in contract, strict liability,
// xrtt	or tort (including negligence or otherwise) arising in any way out of
// xgcw	the use of this software, even if advised of the possibility of such damage.

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
