// jusp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xgaa	
// buou	 By downloading, copying, installing or using the software you agree to this license.
// qexj	 If you do not agree to this license, do not download, install,
// gdai	 copy or use the software.
// ozfz	
// qasq	                          License Agreement
// pnhc	         For OpenVSS - Open Source Video Surveillance System
// jlst	
// kuqz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vvbz	
// iquq	Third party copyrights are property of their respective owners.
// qxbf	
// hkrj	Redistribution and use in source and binary forms, with or without modification,
// psyx	are permitted provided that the following conditions are met:
// oklo	
// nmkf	  * Redistribution's of source code must retain the above copyright notice,
// lezm	    this list of conditions and the following disclaimer.
// mant	
// ygra	  * Redistribution's in binary form must reproduce the above copyright notice,
// fbzr	    this list of conditions and the following disclaimer in the documentation
// lbuy	    and/or other materials provided with the distribution.
// tjds	
// vtlk	  * Neither the name of the copyright holders nor the names of its contributors 
// jmlv	    may not be used to endorse or promote products derived from this software 
// fpel	    without specific prior written permission.
// ypsh	
// wylj	This software is provided by the copyright holders and contributors "as is" and
// byrm	any express or implied warranties, including, but not limited to, the implied
// ktdl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sllc	In no event shall the Prince of Songkla University or contributors be liable 
// ahqs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// odjl	(including, but not limited to, procurement of substitute goods or services;
// uvup	loss of use, data, or profits; or business interruption) however caused
// wotv	and on any theory of liability, whether in contract, strict liability,
// jmcv	or tort (including negligence or otherwise) arising in any way out of
// xuqx	the use of this software, even if advised of the possibility of such damage.
// cyzp	
// jzdt	Intelligent Systems Laboratory (iSys Lab)
// eclr	Faculty of Engineering, Prince of Songkla University, THAILAND
// yzst	Project leader by Nikom SUVONVORN
// paof	Project website at http://code.google.com/p/openvss/

namespace Vs.Core.Provider
{
	using System;
	using System.Xml;
    using System.Collections;

	/// <summary>
	/// IVideoSourceDescription interface - description of video source
	/// </summary>
	public interface VsICoreProviderDescription
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
		VsICoreProviderPage GetSettingsPage();

		/// <summary>
		/// Save configuration
		/// </summary>
		void SaveConfiguration(XmlTextWriter writer, object config);

		/// <summary>
		/// Load configuration
		/// </summary>
		object LoadConfiguration(XmlTextReader reader);

        /// <summary>
        /// Load configuration
        /// </summary>
        object LoadConfiguration(Hashtable reader);

		/// <summary>
		/// Create video source object
		/// </summary>
		VsICoreProvider CreateVideoSource(object config);
	}
}
