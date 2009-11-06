// aevg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ewjr	
// wbbu	 By downloading, copying, installing or using the software you agree to this license.
// fltc	 If you do not agree to this license, do not download, install,
// tvov	 copy or use the software.
// ogxl	
// xjni	                          License Agreement
// hnmi	         For OpenVss - Open Source Video Surveillance System
// fsik	
// avup	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ddxw	
// zgyd	Third party copyrights are property of their respective owners.
// ufnz	
// ayqu	Redistribution and use in source and binary forms, with or without modification,
// gjjv	are permitted provided that the following conditions are met:
// jajj	
// ptpn	  * Redistribution's of source code must retain the above copyright notice,
// cjby	    this list of conditions and the following disclaimer.
// bysl	
// ialq	  * Redistribution's in binary form must reproduce the above copyright notice,
// kjoc	    this list of conditions and the following disclaimer in the documentation
// zmhg	    and/or other materials provided with the distribution.
// codq	
// lyfc	  * Neither the name of the copyright holders nor the names of its contributors 
// tohg	    may not be used to endorse or promote products derived from this software 
// rkak	    without specific prior written permission.
// dpyb	
// felg	This software is provided by the copyright holders and contributors "as is" and
// xtka	any express or implied warranties, including, but not limited to, the implied
// mhkd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lilo	In no event shall the Prince of Songkla University or contributors be liable 
// glmc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tpsu	(including, but not limited to, procurement of substitute goods or services;
// tfza	loss of use, data, or profits; or business interruption) however caused
// idzj	and on any theory of liability, whether in contract, strict liability,
// ngax	or tort (including negligence or otherwise) arising in any way out of
// dwss	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Xml;
using System.Collections;

namespace Vs.Core.Analyzer
{

	/// <summary>
	/// VsIAnalysisDescription interface - description of video source
	/// </summary>
	public interface VsICoreAnalyzerDescription
	{
		/// <summary>
		/// Name property
		/// </summary>
		string Name{get;}

		/// <summary>
		/// Description property
		/// </summary>
		string Description{get;}

		/// <summary>
		/// Return settings page
		/// </summary>
		VsICoreAnalyzerPage GetSettingsPage();

		/// <summary>
		/// Save configuration
		/// </summary>
        void SaveConfiguration(XmlTextWriter writer, VsICoreAnalyzerConfiguration config);

		/// <summary>
		/// Load configuration
		/// </summary>
        VsICoreAnalyzerConfiguration LoadConfiguration(XmlTextReader reader);

        /// <summary>
        /// Load configuration
        /// </summary>
        VsICoreAnalyzerConfiguration LoadConfiguration(Hashtable reader);

		/// <summary>
		/// Create video source object
		/// </summary>
        VsICoreAnalyzer CreateAnalyser(long syncTimer, VsICoreAnalyzerConfiguration config);
	}
}
