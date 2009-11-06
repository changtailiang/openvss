// lzlh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zndn	
// qcoh	 By downloading, copying, installing or using the software you agree to this license.
// fniq	 If you do not agree to this license, do not download, install,
// tehk	 copy or use the software.
// lcaf	
// saso	                          License Agreement
// vazf	         For OpenVss - Open Source Video Surveillance System
// uocg	
// tcgd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ppjb	
// lhzu	Third party copyrights are property of their respective owners.
// fesj	
// iaji	Redistribution and use in source and binary forms, with or without modification,
// yfpz	are permitted provided that the following conditions are met:
// vpsp	
// cinq	  * Redistribution's of source code must retain the above copyright notice,
// lbxr	    this list of conditions and the following disclaimer.
// yeuw	
// tytk	  * Redistribution's in binary form must reproduce the above copyright notice,
// axiq	    this list of conditions and the following disclaimer in the documentation
// ipxt	    and/or other materials provided with the distribution.
// fuhn	
// nhha	  * Neither the name of the copyright holders nor the names of its contributors 
// wtyd	    may not be used to endorse or promote products derived from this software 
// ujjd	    without specific prior written permission.
// hale	
// fnoz	This software is provided by the copyright holders and contributors "as is" and
// leyy	any express or implied warranties, including, but not limited to, the implied
// hchn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ltlq	In no event shall the Prince of Songkla University or contributors be liable 
// ujdq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wuza	(including, but not limited to, procurement of substitute goods or services;
// aqqr	loss of use, data, or profits; or business interruption) however caused
// neih	and on any theory of liability, whether in contract, strict liability,
// esns	or tort (including negligence or otherwise) arising in any way out of
// fhbj	the use of this software, even if advised of the possibility of such damage.

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
