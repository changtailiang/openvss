// euwz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yxsj	
// oscw	 By downloading, copying, installing or using the software you agree to this license.
// ycmz	 If you do not agree to this license, do not download, install,
// qllc	 copy or use the software.
// jnuj	
// wzde	                          License Agreement
// foij	         For OpenVSS - Open Source Video Surveillance System
// jwuk	
// plcm	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mwkx	
// sted	Third party copyrights are property of their respective owners.
// znqd	
// yynr	Redistribution and use in source and binary forms, with or without modification,
// zmcz	are permitted provided that the following conditions are met:
// unea	
// ktmc	  * Redistribution's of source code must retain the above copyright notice,
// hcke	    this list of conditions and the following disclaimer.
// jzpm	
// dxrd	  * Redistribution's in binary form must reproduce the above copyright notice,
// uzfr	    this list of conditions and the following disclaimer in the documentation
// xekl	    and/or other materials provided with the distribution.
// jdkc	
// jdry	  * Neither the name of the copyright holders nor the names of its contributors 
// skmz	    may not be used to endorse or promote products derived from this software 
// gcww	    without specific prior written permission.
// dmuz	
// ianb	This software is provided by the copyright holders and contributors "as is" and
// vzev	any express or implied warranties, including, but not limited to, the implied
// imcf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ibte	In no event shall the Prince of Songkla University or contributors be liable 
// rivg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hqut	(including, but not limited to, procurement of substitute goods or services;
// lrwr	loss of use, data, or profits; or business interruption) however caused
// diol	and on any theory of liability, whether in contract, strict liability,
// klci	or tort (including negligence or otherwise) arising in any way out of
// pjgj	the use of this software, even if advised of the possibility of such damage.
// ywqg	
// hgqe	Intelligent Systems Laboratory (iSys Lab)
// jrfu	Faculty of Engineering, Prince of Songkla University, THAILAND
// qosr	Project leader by Nikom SUVONVORN
// guqd	Project website at http://code.google.com/p/openvss/

namespace Vs.Monitor
{
	using System;

	/// <summary>
	/// VsIDialogWizard - interface of a wizard page
	/// </summary>
	public interface VsIDialogWizard
	{
		/// <summary>
		/// State changed event - notify wizard if the page is completed
		/// and it can proceed to the next page
		/// </summary>
		event EventHandler StateChanged;

		/// <summary>
		/// Reset event - notify wizard if there are such changes on the
		/// page, which can lead to changing completion status of other pages
		/// </summary>
		event EventHandler Reset;

		/// <summary>
		/// PageName property - short name
		/// </summary>
		string PageName { get; }

		/// <summary>
		/// Description property
		/// </summary>
		string PageDescription { get; }

		/// <summary>
		/// Completed property
		/// true, if the page is completed and wizard can proceed to next page
		/// </summary>
		bool Completed { get; }

		/// <summary>
		/// Display - display the page
		/// VsPageWizard call the method after the page was shown
		/// </summary>
		void Display();

		/// <summary>
		/// Apply - check and update all variables
		/// Return false if something wrong and we want to stay on the page
		/// </summary>
		bool Apply();
	}
}
