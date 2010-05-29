// hdhu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vazg	
// vbpf	 By downloading, copying, installing or using the software you agree to this license.
// ukcs	 If you do not agree to this license, do not download, install,
// merr	 copy or use the software.
// ohbj	
// oocb	                          License Agreement
// gqgu	         For OpenVSS - Open Source Video Surveillance System
// wozh	
// cmfb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vqiw	
// luvk	Third party copyrights are property of their respective owners.
// znxd	
// odfz	Redistribution and use in source and binary forms, with or without modification,
// byfg	are permitted provided that the following conditions are met:
// xyae	
// vvif	  * Redistribution's of source code must retain the above copyright notice,
// kvqz	    this list of conditions and the following disclaimer.
// zpvx	
// zeyt	  * Redistribution's in binary form must reproduce the above copyright notice,
// trbs	    this list of conditions and the following disclaimer in the documentation
// scgs	    and/or other materials provided with the distribution.
// jafe	
// gydx	  * Neither the name of the copyright holders nor the names of its contributors 
// qdbq	    may not be used to endorse or promote products derived from this software 
// lpae	    without specific prior written permission.
// xyey	
// ihaw	This software is provided by the copyright holders and contributors "as is" and
// amnf	any express or implied warranties, including, but not limited to, the implied
// xhls	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ppwj	In no event shall the Prince of Songkla University or contributors be liable 
// pmsa	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lyhv	(including, but not limited to, procurement of substitute goods or services;
// diid	loss of use, data, or profits; or business interruption) however caused
// rwvu	and on any theory of liability, whether in contract, strict liability,
// xhkb	or tort (including negligence or otherwise) arising in any way out of
// ajeu	the use of this software, even if advised of the possibility of such damage.
// lxai	
// riav	Intelligent Systems Laboratory (iSys Lab)
// tqpk	Faculty of Engineering, Prince of Songkla University, THAILAND
// femk	Project leader by Nikom SUVONVORN
// zetr	Project website at http://code.google.com/p/openvss/

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
