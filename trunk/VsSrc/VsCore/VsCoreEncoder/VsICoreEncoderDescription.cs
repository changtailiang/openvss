// wlum	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ourj	
// typu	 By downloading, copying, installing or using the software you agree to this license.
// twvg	 If you do not agree to this license, do not download, install,
// zffz	 copy or use the software.
// fhjn	
// nreg	                          License Agreement
// tbdd	         For OpenVSS - Open Source Video Surveillance System
// xjai	
// wmre	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wcdz	
// phhq	Third party copyrights are property of their respective owners.
// ygnd	
// hhfo	Redistribution and use in source and binary forms, with or without modification,
// chzx	are permitted provided that the following conditions are met:
// plqr	
// vmxk	  * Redistribution's of source code must retain the above copyright notice,
// vmkn	    this list of conditions and the following disclaimer.
// obcc	
// djyf	  * Redistribution's in binary form must reproduce the above copyright notice,
// johm	    this list of conditions and the following disclaimer in the documentation
// oavp	    and/or other materials provided with the distribution.
// emgp	
// mtol	  * Neither the name of the copyright holders nor the names of its contributors 
// llec	    may not be used to endorse or promote products derived from this software 
// kxul	    without specific prior written permission.
// wzof	
// ecks	This software is provided by the copyright holders and contributors "as is" and
// iunb	any express or implied warranties, including, but not limited to, the implied
// dedu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rhfj	In no event shall the Prince of Songkla University or contributors be liable 
// fuau	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mrrr	(including, but not limited to, procurement of substitute goods or services;
// fwvm	loss of use, data, or profits; or business interruption) however caused
// twpo	and on any theory of liability, whether in contract, strict liability,
// lpkc	or tort (including negligence or otherwise) arising in any way out of
// bngs	the use of this software, even if advised of the possibility of such damage.
// fnih	
// iklc	Intelligent Systems Laboratory (iSys Lab)
// rlfb	Faculty of Engineering, Prince of Songkla University, THAILAND
// zutn	Project leader by Nikom SUVONVORN
// ltnm	Project website at http://code.google.com/p/openvss/

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
