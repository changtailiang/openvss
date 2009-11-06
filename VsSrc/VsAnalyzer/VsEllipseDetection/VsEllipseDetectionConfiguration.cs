// sbzc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// smzn	
// owar	 By downloading, copying, installing or using the software you agree to this license.
// vlcx	 If you do not agree to this license, do not download, install,
// qdbx	 copy or use the software.
// osmw	
// msfw	                          License Agreement
// xgkd	         For OpenVss - Open Source Video Surveillance System
// eycu	
// aepf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xwyf	
// kcmo	Third party copyrights are property of their respective owners.
// ghep	
// fvia	Redistribution and use in source and binary forms, with or without modification,
// pcpa	are permitted provided that the following conditions are met:
// hcqh	
// lxmx	  * Redistribution's of source code must retain the above copyright notice,
// jiwm	    this list of conditions and the following disclaimer.
// nwzr	
// uhmj	  * Redistribution's in binary form must reproduce the above copyright notice,
// frqp	    this list of conditions and the following disclaimer in the documentation
// cuyj	    and/or other materials provided with the distribution.
// qcex	
// opyv	  * Neither the name of the copyright holders nor the names of its contributors 
// grtn	    may not be used to endorse or promote products derived from this software 
// ppex	    without specific prior written permission.
// ksbj	
// vqgi	This software is provided by the copyright holders and contributors "as is" and
// qfuq	any express or implied warranties, including, but not limited to, the implied
// laer	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ydhh	In no event shall the Prince of Songkla University or contributors be liable 
// eyyy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xekc	(including, but not limited to, procurement of substitute goods or services;
// oyuq	loss of use, data, or profits; or business interruption) however caused
// mtfk	and on any theory of liability, whether in contract, strict liability,
// spnz	or tort (including negligence or otherwise) arising in any way out of
// wwhi	the use of this software, even if advised of the possibility of such damage.

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
