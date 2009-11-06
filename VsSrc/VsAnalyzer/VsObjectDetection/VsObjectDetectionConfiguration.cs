// envh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// izlj	
// vayp	 By downloading, copying, installing or using the software you agree to this license.
// wvte	 If you do not agree to this license, do not download, install,
// xekm	 copy or use the software.
// thpu	
// nzta	                          License Agreement
// xlgx	         For OpenVss - Open Source Video Surveillance System
// edjc	
// rabs	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// varm	
// ylll	Third party copyrights are property of their respective owners.
// xdza	
// lyix	Redistribution and use in source and binary forms, with or without modification,
// xaui	are permitted provided that the following conditions are met:
// gllk	
// tbls	  * Redistribution's of source code must retain the above copyright notice,
// lqmw	    this list of conditions and the following disclaimer.
// dsqs	
// qdvb	  * Redistribution's in binary form must reproduce the above copyright notice,
// ohct	    this list of conditions and the following disclaimer in the documentation
// lglg	    and/or other materials provided with the distribution.
// vmfr	
// gslk	  * Neither the name of the copyright holders nor the names of its contributors 
// ogsx	    may not be used to endorse or promote products derived from this software 
// aszh	    without specific prior written permission.
// rcxt	
// hpgu	This software is provided by the copyright holders and contributors "as is" and
// esuy	any express or implied warranties, including, but not limited to, the implied
// iszn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pfxy	In no event shall the Prince of Songkla University or contributors be liable 
// kvqk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ggdk	(including, but not limited to, procurement of substitute goods or services;
// kybv	loss of use, data, or profits; or business interruption) however caused
// huci	and on any theory of liability, whether in contract, strict liability,
// jsyf	or tort (including negligence or otherwise) arising in any way out of
// glno	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.ObjectDetection
{
    class VsObjectDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int SelectedObject;

        public VsObjectDetectionConfiguration()
        {
            SelectedObject = 0;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("SelectedObject", SelectedObject);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            SelectedObject = int.Parse(config["SelectedObject"].ToString());
        }
    }
}
