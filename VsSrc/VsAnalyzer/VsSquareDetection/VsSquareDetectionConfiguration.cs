// xyjq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pxok	
// gulq	 By downloading, copying, installing or using the software you agree to this license.
// ojhs	 If you do not agree to this license, do not download, install,
// lucq	 copy or use the software.
// qcxi	
// kmya	                          License Agreement
// ulpz	         For OpenVss - Open Source Video Surveillance System
// ujad	
// afns	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ltez	
// xyaz	Third party copyrights are property of their respective owners.
// vmpy	
// fgsu	Redistribution and use in source and binary forms, with or without modification,
// bagc	are permitted provided that the following conditions are met:
// yopv	
// emvf	  * Redistribution's of source code must retain the above copyright notice,
// jesf	    this list of conditions and the following disclaimer.
// hjex	
// yyll	  * Redistribution's in binary form must reproduce the above copyright notice,
// lzei	    this list of conditions and the following disclaimer in the documentation
// wrtn	    and/or other materials provided with the distribution.
// qfcz	
// zktw	  * Neither the name of the copyright holders nor the names of its contributors 
// diul	    may not be used to endorse or promote products derived from this software 
// cvpr	    without specific prior written permission.
// tjrv	
// cvvc	This software is provided by the copyright holders and contributors "as is" and
// purz	any express or implied warranties, including, but not limited to, the implied
// jhzn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// shod	In no event shall the Prince of Songkla University or contributors be liable 
// btgw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// phtp	(including, but not limited to, procurement of substitute goods or services;
// dzjp	loss of use, data, or profits; or business interruption) however caused
// jnom	and on any theory of liability, whether in contract, strict liability,
// aylu	or tort (including negligence or otherwise) arising in any way out of
// jzjf	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.SquareDetection
{
    class VsSquareDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int Threshold;

        public VsSquareDetectionConfiguration()
        {
            Threshold = 30;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("Threshold", Threshold);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            Threshold = int.Parse(config["Threshold"].ToString());
        }

    }
}
