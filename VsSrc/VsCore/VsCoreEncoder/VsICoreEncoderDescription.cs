// gnmr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// egib	
// qolj	 By downloading, copying, installing or using the software you agree to this license.
// nisi	 If you do not agree to this license, do not download, install,
// ghjw	 copy or use the software.
// nugo	
// xztj	                          License Agreement
// tstw	         For OpenVss - Open Source Video Surveillance System
// phaj	
// pbmq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// erar	
// lklf	Third party copyrights are property of their respective owners.
// iymu	
// aqpl	Redistribution and use in source and binary forms, with or without modification,
// gxuf	are permitted provided that the following conditions are met:
// nziy	
// vouf	  * Redistribution's of source code must retain the above copyright notice,
// hitf	    this list of conditions and the following disclaimer.
// vssv	
// tpdm	  * Redistribution's in binary form must reproduce the above copyright notice,
// nnbu	    this list of conditions and the following disclaimer in the documentation
// fyvy	    and/or other materials provided with the distribution.
// spdr	
// ghdf	  * Neither the name of the copyright holders nor the names of its contributors 
// jcww	    may not be used to endorse or promote products derived from this software 
// qfyz	    without specific prior written permission.
// ehzi	
// ytsq	This software is provided by the copyright holders and contributors "as is" and
// uirz	any express or implied warranties, including, but not limited to, the implied
// ynsw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tvns	In no event shall the Prince of Songkla University or contributors be liable 
// fczo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pmlq	(including, but not limited to, procurement of substitute goods or services;
// tgvi	loss of use, data, or profits; or business interruption) however caused
// pbqx	and on any theory of liability, whether in contract, strict liability,
// ynzz	or tort (including negligence or otherwise) arising in any way out of
// wnwy	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Core.Encoder
{
	using System;
	using System.Xml;
    using System.Collections;

	/// <summary>
	/// VsIAnalysisDescription interface - description of video source
	/// </summary>
	public interface VsICoreEncoderDescription
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
		VsICoreEncoderPage GetSettingsPage();

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
        VsICoreEncoder CreateEncoder(long syncTimer, object config);
	}
}
