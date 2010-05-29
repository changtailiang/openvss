// ybhh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ooib	
// wdir	 By downloading, copying, installing or using the software you agree to this license.
// oioy	 If you do not agree to this license, do not download, install,
// jjjv	 copy or use the software.
// ltui	
// qnpr	                          License Agreement
// wxrh	         For OpenVSS - Open Source Video Surveillance System
// atte	
// gbtt	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bjfo	
// donr	Third party copyrights are property of their respective owners.
// guec	
// krbf	Redistribution and use in source and binary forms, with or without modification,
// gzqa	are permitted provided that the following conditions are met:
// zrfz	
// maru	  * Redistribution's of source code must retain the above copyright notice,
// ojsh	    this list of conditions and the following disclaimer.
// pptb	
// ngeb	  * Redistribution's in binary form must reproduce the above copyright notice,
// aylb	    this list of conditions and the following disclaimer in the documentation
// toxi	    and/or other materials provided with the distribution.
// snxg	
// kstj	  * Neither the name of the copyright holders nor the names of its contributors 
// egcd	    may not be used to endorse or promote products derived from this software 
// wscw	    without specific prior written permission.
// cwmu	
// yasa	This software is provided by the copyright holders and contributors "as is" and
// upab	any express or implied warranties, including, but not limited to, the implied
// gdfx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cica	In no event shall the Prince of Songkla University or contributors be liable 
// mlxx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vjxg	(including, but not limited to, procurement of substitute goods or services;
// ebeh	loss of use, data, or profits; or business interruption) however caused
// vozw	and on any theory of liability, whether in contract, strict liability,
// cdks	or tort (including negligence or otherwise) arising in any way out of
// vxlv	the use of this software, even if advised of the possibility of such damage.
// ssda	
// afao	Intelligent Systems Laboratory (iSys Lab)
// pckq	Faculty of Engineering, Prince of Songkla University, THAILAND
// zoyo	Project leader by Nikom SUVONVORN
// cmvt	Project website at http://code.google.com/p/openvss/

namespace Vs.Core.Encoder
{
	using System;

	/// <summary>
	/// VsIAnalysisPage interface
	/// </summary>
	public interface VsICoreEncoderPage
	{
		/// <summary>
		/// State changed event - notify client if the page is completed
		/// </summary>
		event EventHandler StateChanged;

		/// <summary>
		/// Completed property
		/// true, if the page is completed and wizard can proceed to next page
		/// </summary>
        bool Completed { get; }

		/// <summary>
		/// Display - display the page
		/// Wizard call the method after the page was shown
		/// </summary>
		void Display();

		/// <summary>
		/// Apply - check and update all variables
		/// Return false if something wrong and we want to stay on the page
		/// </summary>
		bool Apply();

		/// <summary>
		/// Get configuration object
		/// </summary>
		object GetConfiguration();

		/// <summary>
		/// Set configuration
		/// </summary>
		void SetConfiguration(object config);
	}
}
