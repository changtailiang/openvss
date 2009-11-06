// mbca	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zrot	
// dndi	 By downloading, copying, installing or using the software you agree to this license.
// nflg	 If you do not agree to this license, do not download, install,
// svhf	 copy or use the software.
// oopu	
// edbl	                          License Agreement
// lmou	         For OpenVss - Open Source Video Surveillance System
// pgmp	
// kyxf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bdut	
// nxom	Third party copyrights are property of their respective owners.
// lfox	
// gvzy	Redistribution and use in source and binary forms, with or without modification,
// lhww	are permitted provided that the following conditions are met:
// pdir	
// zish	  * Redistribution's of source code must retain the above copyright notice,
// svwu	    this list of conditions and the following disclaimer.
// ybek	
// tvgg	  * Redistribution's in binary form must reproduce the above copyright notice,
// ppzf	    this list of conditions and the following disclaimer in the documentation
// yqnu	    and/or other materials provided with the distribution.
// godc	
// bbpx	  * Neither the name of the copyright holders nor the names of its contributors 
// vduf	    may not be used to endorse or promote products derived from this software 
// fgtp	    without specific prior written permission.
// jtye	
// qoeq	This software is provided by the copyright holders and contributors "as is" and
// apha	any express or implied warranties, including, but not limited to, the implied
// ecti	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uxae	In no event shall the Prince of Songkla University or contributors be liable 
// stsx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lgpp	(including, but not limited to, procurement of substitute goods or services;
// bbai	loss of use, data, or profits; or business interruption) however caused
// vjwe	and on any theory of liability, whether in contract, strict liability,
// sjds	or tort (including negligence or otherwise) arising in any way out of
// jmbm	the use of this software, even if advised of the possibility of such damage.

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
