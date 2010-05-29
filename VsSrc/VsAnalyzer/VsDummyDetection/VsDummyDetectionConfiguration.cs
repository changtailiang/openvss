// lgbn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gqtz	
// cybk	 By downloading, copying, installing or using the software you agree to this license.
// uplb	 If you do not agree to this license, do not download, install,
// hxsv	 copy or use the software.
// evok	
// uyma	                          License Agreement
// rdys	         For OpenVSS - Open Source Video Surveillance System
// gidz	
// onhr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vpst	
// nsgt	Third party copyrights are property of their respective owners.
// nfxz	
// sqpq	Redistribution and use in source and binary forms, with or without modification,
// sqth	are permitted provided that the following conditions are met:
// dsiy	
// zjdm	  * Redistribution's of source code must retain the above copyright notice,
// mlnt	    this list of conditions and the following disclaimer.
// pbzp	
// duwb	  * Redistribution's in binary form must reproduce the above copyright notice,
// rsnl	    this list of conditions and the following disclaimer in the documentation
// gzap	    and/or other materials provided with the distribution.
// snhx	
// uznc	  * Neither the name of the copyright holders nor the names of its contributors 
// gtte	    may not be used to endorse or promote products derived from this software 
// ouhb	    without specific prior written permission.
// sdkq	
// qanx	This software is provided by the copyright holders and contributors "as is" and
// trqk	any express or implied warranties, including, but not limited to, the implied
// fwsa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iouy	In no event shall the Prince of Songkla University or contributors be liable 
// epzp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nxij	(including, but not limited to, procurement of substitute goods or services;
// asnx	loss of use, data, or profits; or business interruption) however caused
// lltc	and on any theory of liability, whether in contract, strict liability,
// ojyr	or tort (including negligence or otherwise) arising in any way out of
// ajdc	the use of this software, even if advised of the possibility of such damage.
// jdwk	
// atva	Intelligent Systems Laboratory (iSys Lab)
// zixc	Faculty of Engineering, Prince of Songkla University, THAILAND
// dvdt	Project leader by Nikom SUVONVORN
// sdwb	Project website at http://code.google.com/p/openvss/

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
