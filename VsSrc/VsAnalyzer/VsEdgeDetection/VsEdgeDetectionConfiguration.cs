// xnqt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jgjv	
// qara	 By downloading, copying, installing or using the software you agree to this license.
// fkom	 If you do not agree to this license, do not download, install,
// puzr	 copy or use the software.
// gfeh	
// jyol	                          License Agreement
// wqpv	         For OpenVss - Open Source Video Surveillance System
// lacv	
// dabz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// cugq	
// nlbl	Third party copyrights are property of their respective owners.
// zfsc	
// trbs	Redistribution and use in source and binary forms, with or without modification,
// ijkl	are permitted provided that the following conditions are met:
// ryyz	
// kvof	  * Redistribution's of source code must retain the above copyright notice,
// isjp	    this list of conditions and the following disclaimer.
// sapl	
// znty	  * Redistribution's in binary form must reproduce the above copyright notice,
// wdlr	    this list of conditions and the following disclaimer in the documentation
// xncu	    and/or other materials provided with the distribution.
// zknu	
// pqhd	  * Neither the name of the copyright holders nor the names of its contributors 
// vggs	    may not be used to endorse or promote products derived from this software 
// wwcg	    without specific prior written permission.
// wcjs	
// bpsu	This software is provided by the copyright holders and contributors "as is" and
// qmpn	any express or implied warranties, including, but not limited to, the implied
// mhcx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tugx	In no event shall the Prince of Songkla University or contributors be liable 
// fpzc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// slqt	(including, but not limited to, procurement of substitute goods or services;
// hbba	loss of use, data, or profits; or business interruption) however caused
// aeuv	and on any theory of liability, whether in contract, strict liability,
// djsk	or tort (including negligence or otherwise) arising in any way out of
// rted	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.EdgeDetection
{
    class VsEdgeDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int ThresholdStrong;
        public int ThresholdWeak;

        public VsEdgeDetectionConfiguration()
        {
            ThresholdStrong = 40;
            ThresholdWeak = 5;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("ThresholdStrong", ThresholdStrong);
            config.Add("ThresholdWeak", ThresholdWeak);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            ThresholdStrong = int.Parse(config["ThresholdStrong"].ToString());
            ThresholdWeak = int.Parse(config["ThresholdWeak"].ToString());
        }

    }
}
