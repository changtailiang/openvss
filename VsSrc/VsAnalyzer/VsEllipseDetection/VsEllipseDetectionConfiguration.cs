// znjt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// firo	
// kcwv	 By downloading, copying, installing or using the software you agree to this license.
// fqqd	 If you do not agree to this license, do not download, install,
// uinl	 copy or use the software.
// dojx	
// tnem	                          License Agreement
// qcmx	         For OpenVSS - Open Source Video Surveillance System
// smxi	
// rknl	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fmac	
// aztb	Third party copyrights are property of their respective owners.
// jhlg	
// knql	Redistribution and use in source and binary forms, with or without modification,
// elzr	are permitted provided that the following conditions are met:
// eeyh	
// qzdt	  * Redistribution's of source code must retain the above copyright notice,
// shlj	    this list of conditions and the following disclaimer.
// vcfr	
// nhxu	  * Redistribution's in binary form must reproduce the above copyright notice,
// tccj	    this list of conditions and the following disclaimer in the documentation
// rgnf	    and/or other materials provided with the distribution.
// wmeg	
// lvhb	  * Neither the name of the copyright holders nor the names of its contributors 
// otma	    may not be used to endorse or promote products derived from this software 
// wajc	    without specific prior written permission.
// vckh	
// hzxw	This software is provided by the copyright holders and contributors "as is" and
// oexb	any express or implied warranties, including, but not limited to, the implied
// bpqj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mxxf	In no event shall the Prince of Songkla University or contributors be liable 
// cfya	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vecu	(including, but not limited to, procurement of substitute goods or services;
// uwyt	loss of use, data, or profits; or business interruption) however caused
// tano	and on any theory of liability, whether in contract, strict liability,
// vfxw	or tort (including negligence or otherwise) arising in any way out of
// pirg	the use of this software, even if advised of the possibility of such damage.
// xfzz	
// ccoy	Intelligent Systems Laboratory (iSys Lab)
// ddzq	Faculty of Engineering, Prince of Songkla University, THAILAND
// ekmd	Project leader by Nikom SUVONVORN
// wcbs	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.EllipseDetection
{
    class VsEllipseDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int Threshold;

        public VsEllipseDetectionConfiguration()
        {
            Threshold = 40;
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
