// xisn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jrbg	
// nafg	 By downloading, copying, installing or using the software you agree to this license.
// ujyu	 If you do not agree to this license, do not download, install,
// ccya	 copy or use the software.
// fkmh	
// gmvo	                          License Agreement
// veff	         For OpenVSS - Open Source Video Surveillance System
// cvyd	
// kquv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// oyrl	
// quwt	Third party copyrights are property of their respective owners.
// gycj	
// rghn	Redistribution and use in source and binary forms, with or without modification,
// vlhx	are permitted provided that the following conditions are met:
// vnki	
// vaey	  * Redistribution's of source code must retain the above copyright notice,
// kvjl	    this list of conditions and the following disclaimer.
// icmh	
// sbrl	  * Redistribution's in binary form must reproduce the above copyright notice,
// pcix	    this list of conditions and the following disclaimer in the documentation
// bvov	    and/or other materials provided with the distribution.
// nlhy	
// jwzb	  * Neither the name of the copyright holders nor the names of its contributors 
// niqq	    may not be used to endorse or promote products derived from this software 
// qyjk	    without specific prior written permission.
// oqbo	
// uauu	This software is provided by the copyright holders and contributors "as is" and
// uvit	any express or implied warranties, including, but not limited to, the implied
// fnhz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mily	In no event shall the Prince of Songkla University or contributors be liable 
// olcm	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cktj	(including, but not limited to, procurement of substitute goods or services;
// lbvr	loss of use, data, or profits; or business interruption) however caused
// txik	and on any theory of liability, whether in contract, strict liability,
// uzbn	or tort (including negligence or otherwise) arising in any way out of
// qmeo	the use of this software, even if advised of the possibility of such damage.
// ngwz	
// bqdi	Intelligent Systems Laboratory (iSys Lab)
// nkwd	Faculty of Engineering, Prince of Songkla University, THAILAND
// opmj	Project leader by Nikom SUVONVORN
// gkjt	Project website at http://code.google.com/p/openvss/

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
