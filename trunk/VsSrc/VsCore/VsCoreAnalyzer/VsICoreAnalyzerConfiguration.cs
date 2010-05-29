// kdns	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// eupz	
// sjzn	 By downloading, copying, installing or using the software you agree to this license.
// qblh	 If you do not agree to this license, do not download, install,
// zawn	 copy or use the software.
// eujh	
// mrdy	                          License Agreement
// dnlj	         For OpenVSS - Open Source Video Surveillance System
// nynr	
// shzs	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fxdx	
// gzfd	Third party copyrights are property of their respective owners.
// pger	
// nkvp	Redistribution and use in source and binary forms, with or without modification,
// tfgn	are permitted provided that the following conditions are met:
// rqwf	
// ypzs	  * Redistribution's of source code must retain the above copyright notice,
// ntos	    this list of conditions and the following disclaimer.
// aehh	
// rmbm	  * Redistribution's in binary form must reproduce the above copyright notice,
// lziw	    this list of conditions and the following disclaimer in the documentation
// iuwd	    and/or other materials provided with the distribution.
// cyym	
// bmbo	  * Neither the name of the copyright holders nor the names of its contributors 
// byzq	    may not be used to endorse or promote products derived from this software 
// anpv	    without specific prior written permission.
// rlqj	
// coyh	This software is provided by the copyright holders and contributors "as is" and
// etbr	any express or implied warranties, including, but not limited to, the implied
// hawd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// twpp	In no event shall the Prince of Songkla University or contributors be liable 
// vcrn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// csfs	(including, but not limited to, procurement of substitute goods or services;
// mkmy	loss of use, data, or profits; or business interruption) however caused
// jnew	and on any theory of liability, whether in contract, strict liability,
// dnao	or tort (including negligence or otherwise) arising in any way out of
// zqih	the use of this software, even if advised of the possibility of such damage.
// kjgb	
// bvwe	Intelligent Systems Laboratory (iSys Lab)
// xazp	Faculty of Engineering, Prince of Songkla University, THAILAND
// ucgj	Project leader by Nikom SUVONVORN
// ifut	Project website at http://code.google.com/p/openvss/

using System;
using System.Drawing;
using System.Collections;

using Vs.Core.Image;

namespace Vs.Core.Analyzer
{

	/// <summary>
    /// VsICoreAnalyzerConfiguration interface
	/// </summary>
    public interface VsICoreAnalyzerConfiguration
	{
        /// <summary>
        /// Get configuration
        /// </summary>
        Hashtable GetConfiguration();

        /// <summary>
        /// Load configuration
        /// </summary>
        /// <param name="config"></param>
        void LoadConfiguration(Hashtable config);
    }
}
