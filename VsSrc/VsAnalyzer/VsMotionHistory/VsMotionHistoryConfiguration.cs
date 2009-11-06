// ehry	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// djiq	
// iuic	 By downloading, copying, installing or using the software you agree to this license.
// xdva	 If you do not agree to this license, do not download, install,
// wyqp	 copy or use the software.
// hxtl	
// ggme	                          License Agreement
// ipec	         For OpenVss - Open Source Video Surveillance System
// clwr	
// icox	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jmaq	
// huqd	Third party copyrights are property of their respective owners.
// wokm	
// uadh	Redistribution and use in source and binary forms, with or without modification,
// ogrx	are permitted provided that the following conditions are met:
// wdht	
// pgzl	  * Redistribution's of source code must retain the above copyright notice,
// geru	    this list of conditions and the following disclaimer.
// jsfv	
// wcel	  * Redistribution's in binary form must reproduce the above copyright notice,
// pjht	    this list of conditions and the following disclaimer in the documentation
// frhb	    and/or other materials provided with the distribution.
// hpcb	
// kraf	  * Neither the name of the copyright holders nor the names of its contributors 
// fhaa	    may not be used to endorse or promote products derived from this software 
// vfws	    without specific prior written permission.
// wpdc	
// vikl	This software is provided by the copyright holders and contributors "as is" and
// cgin	any express or implied warranties, including, but not limited to, the implied
// wnny	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yxer	In no event shall the Prince of Songkla University or contributors be liable 
// cpjs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rzpp	(including, but not limited to, procurement of substitute goods or services;
// cdqk	loss of use, data, or profits; or business interruption) however caused
// mpwp	and on any theory of liability, whether in contract, strict liability,
// ofgy	or tort (including negligence or otherwise) arising in any way out of
// fqze	the use of this software, even if advised of the possibility of such damage.

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
