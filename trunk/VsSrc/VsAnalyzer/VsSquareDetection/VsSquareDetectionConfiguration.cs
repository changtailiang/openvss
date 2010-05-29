// uncy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cgnn	
// ehrv	 By downloading, copying, installing or using the software you agree to this license.
// nbho	 If you do not agree to this license, do not download, install,
// xvld	 copy or use the software.
// xeam	
// gxjk	                          License Agreement
// shpf	         For OpenVSS - Open Source Video Surveillance System
// jydv	
// hxjx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qfov	
// sfze	Third party copyrights are property of their respective owners.
// ehfd	
// emiq	Redistribution and use in source and binary forms, with or without modification,
// mqsf	are permitted provided that the following conditions are met:
// xduw	
// smmo	  * Redistribution's of source code must retain the above copyright notice,
// xlgz	    this list of conditions and the following disclaimer.
// momr	
// pfta	  * Redistribution's in binary form must reproduce the above copyright notice,
// xefk	    this list of conditions and the following disclaimer in the documentation
// blax	    and/or other materials provided with the distribution.
// qnir	
// fdzm	  * Neither the name of the copyright holders nor the names of its contributors 
// lsdf	    may not be used to endorse or promote products derived from this software 
// tlhs	    without specific prior written permission.
// bfrp	
// zqah	This software is provided by the copyright holders and contributors "as is" and
// wris	any express or implied warranties, including, but not limited to, the implied
// yjvg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// loyj	In no event shall the Prince of Songkla University or contributors be liable 
// coui	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oagx	(including, but not limited to, procurement of substitute goods or services;
// cohl	loss of use, data, or profits; or business interruption) however caused
// xmjv	and on any theory of liability, whether in contract, strict liability,
// ulxz	or tort (including negligence or otherwise) arising in any way out of
// mbvo	the use of this software, even if advised of the possibility of such damage.
// vhoc	
// xwte	Intelligent Systems Laboratory (iSys Lab)
// nxpm	Faculty of Engineering, Prince of Songkla University, THAILAND
// libz	Project leader by Nikom SUVONVORN
// kdei	Project website at http://code.google.com/p/openvss/

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
