// qitk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// abwh	
// jgql	 By downloading, copying, installing or using the software you agree to this license.
// irdy	 If you do not agree to this license, do not download, install,
// owvk	 copy or use the software.
// qsgo	
// kmbr	                          License Agreement
// renk	         For OpenVss - Open Source Video Surveillance System
// ycou	
// ezmv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hpna	
// dwdg	Third party copyrights are property of their respective owners.
// hbdu	
// qmjx	Redistribution and use in source and binary forms, with or without modification,
// bfao	are permitted provided that the following conditions are met:
// afpf	
// tgnf	  * Redistribution's of source code must retain the above copyright notice,
// citp	    this list of conditions and the following disclaimer.
// jacb	
// egkn	  * Redistribution's in binary form must reproduce the above copyright notice,
// jujq	    this list of conditions and the following disclaimer in the documentation
// bstm	    and/or other materials provided with the distribution.
// trtz	
// yyvc	  * Neither the name of the copyright holders nor the names of its contributors 
// zihw	    may not be used to endorse or promote products derived from this software 
// jxez	    without specific prior written permission.
// hokq	
// jisv	This software is provided by the copyright holders and contributors "as is" and
// umef	any express or implied warranties, including, but not limited to, the implied
// vzda	warranties of merchantability and fitness for a particular purpose are disclaimed.
// maml	In no event shall the Prince of Songkla University or contributors be liable 
// puql	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fzbw	(including, but not limited to, procurement of substitute goods or services;
// ynel	loss of use, data, or profits; or business interruption) however caused
// qkin	and on any theory of liability, whether in contract, strict liability,
// idck	or tort (including negligence or otherwise) arising in any way out of
// yyem	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.DummyDetection
{
    class VsDummyDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdAlpha;
        public int ThresholdSigma;

        public VsDummyDetectionConfiguration()
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
