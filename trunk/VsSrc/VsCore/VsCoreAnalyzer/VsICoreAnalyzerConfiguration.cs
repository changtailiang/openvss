// mkwj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ppxi	
// rfoc	 By downloading, copying, installing or using the software you agree to this license.
// gumf	 If you do not agree to this license, do not download, install,
// iatz	 copy or use the software.
// fcyu	
// abmk	                          License Agreement
// pwru	         For OpenVss - Open Source Video Surveillance System
// hhya	
// dwpe	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vxmm	
// bape	Third party copyrights are property of their respective owners.
// kvoh	
// xcdk	Redistribution and use in source and binary forms, with or without modification,
// lbin	are permitted provided that the following conditions are met:
// dmsu	
// nuuy	  * Redistribution's of source code must retain the above copyright notice,
// vlbl	    this list of conditions and the following disclaimer.
// lpeh	
// qltz	  * Redistribution's in binary form must reproduce the above copyright notice,
// mhau	    this list of conditions and the following disclaimer in the documentation
// hkwf	    and/or other materials provided with the distribution.
// dooc	
// nbai	  * Neither the name of the copyright holders nor the names of its contributors 
// frzg	    may not be used to endorse or promote products derived from this software 
// friy	    without specific prior written permission.
// tdvi	
// ywta	This software is provided by the copyright holders and contributors "as is" and
// iibw	any express or implied warranties, including, but not limited to, the implied
// mync	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xouh	In no event shall the Prince of Songkla University or contributors be liable 
// wzxj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ovcy	(including, but not limited to, procurement of substitute goods or services;
// mmuu	loss of use, data, or profits; or business interruption) however caused
// ybae	and on any theory of liability, whether in contract, strict liability,
// pohh	or tort (including negligence or otherwise) arising in any way out of
// vote	the use of this software, even if advised of the possibility of such damage.

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
