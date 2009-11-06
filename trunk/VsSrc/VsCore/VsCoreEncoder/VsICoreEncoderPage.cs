// pehv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kzdv	
// sgub	 By downloading, copying, installing or using the software you agree to this license.
// ilsm	 If you do not agree to this license, do not download, install,
// hcxo	 copy or use the software.
// mijw	
// xuyg	                          License Agreement
// vnvs	         For OpenVss - Open Source Video Surveillance System
// gayl	
// fpgu	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// caqj	
// hopn	Third party copyrights are property of their respective owners.
// unru	
// qhlh	Redistribution and use in source and binary forms, with or without modification,
// ukyp	are permitted provided that the following conditions are met:
// bxze	
// kbvh	  * Redistribution's of source code must retain the above copyright notice,
// nhgr	    this list of conditions and the following disclaimer.
// wclm	
// saoj	  * Redistribution's in binary form must reproduce the above copyright notice,
// fkli	    this list of conditions and the following disclaimer in the documentation
// wbcy	    and/or other materials provided with the distribution.
// prqu	
// rrtf	  * Neither the name of the copyright holders nor the names of its contributors 
// blzf	    may not be used to endorse or promote products derived from this software 
// siam	    without specific prior written permission.
// gzyn	
// vyou	This software is provided by the copyright holders and contributors "as is" and
// vokq	any express or implied warranties, including, but not limited to, the implied
// lqii	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zwrv	In no event shall the Prince of Songkla University or contributors be liable 
// rmaf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jglg	(including, but not limited to, procurement of substitute goods or services;
// ajqw	loss of use, data, or profits; or business interruption) however caused
// kzbw	and on any theory of liability, whether in contract, strict liability,
// docr	or tort (including negligence or otherwise) arising in any way out of
// cwyc	the use of this software, even if advised of the possibility of such damage.

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
