// wfcd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ikam	
// xlga	 By downloading, copying, installing or using the software you agree to this license.
// jkzq	 If you do not agree to this license, do not download, install,
// nnxg	 copy or use the software.
// dkpx	
// tite	                          License Agreement
// wdwo	         For OpenVSS - Open Source Video Surveillance System
// vasr	
// cbrw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nkbh	
// vtbt	Third party copyrights are property of their respective owners.
// brsg	
// gtpm	Redistribution and use in source and binary forms, with or without modification,
// qeja	are permitted provided that the following conditions are met:
// qvpt	
// orei	  * Redistribution's of source code must retain the above copyright notice,
// riom	    this list of conditions and the following disclaimer.
// vbst	
// jhba	  * Redistribution's in binary form must reproduce the above copyright notice,
// gace	    this list of conditions and the following disclaimer in the documentation
// kqic	    and/or other materials provided with the distribution.
// kgbx	
// rqfr	  * Neither the name of the copyright holders nor the names of its contributors 
// vhtd	    may not be used to endorse or promote products derived from this software 
// osbt	    without specific prior written permission.
// dfke	
// awdi	This software is provided by the copyright holders and contributors "as is" and
// djtq	any express or implied warranties, including, but not limited to, the implied
// skix	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jcyl	In no event shall the Prince of Songkla University or contributors be liable 
// gqvf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wbyb	(including, but not limited to, procurement of substitute goods or services;
// oymn	loss of use, data, or profits; or business interruption) however caused
// yibf	and on any theory of liability, whether in contract, strict liability,
// gdco	or tort (including negligence or otherwise) arising in any way out of
// csuh	the use of this software, even if advised of the possibility of such damage.
// xpyk	
// yvul	Intelligent Systems Laboratory (iSys Lab)
// uqnn	Faculty of Engineering, Prince of Songkla University, THAILAND
// jeiz	Project leader by Nikom SUVONVORN
// ybue	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionHistory
{
    class VsMotionHistoryConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdAlpha;
        public int ThresholdSigma;

        public VsMotionHistoryConfiguration()
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
