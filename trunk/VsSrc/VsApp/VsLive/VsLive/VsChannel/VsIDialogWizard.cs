// mvmt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pbvw	
// qvbs	 By downloading, copying, installing or using the software you agree to this license.
// fhbp	 If you do not agree to this license, do not download, install,
// qqjd	 copy or use the software.
// kybd	
// cnqr	                          License Agreement
// jdhn	         For OpenVss - Open Source Video Surveillance System
// yrhi	
// atbu	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// alwi	
// youg	Third party copyrights are property of their respective owners.
// uymz	
// pusn	Redistribution and use in source and binary forms, with or without modification,
// tirb	are permitted provided that the following conditions are met:
// ldmm	
// nntn	  * Redistribution's of source code must retain the above copyright notice,
// asox	    this list of conditions and the following disclaimer.
// ppdy	
// bteo	  * Redistribution's in binary form must reproduce the above copyright notice,
// tjxl	    this list of conditions and the following disclaimer in the documentation
// qixe	    and/or other materials provided with the distribution.
// ytpr	
// czjw	  * Neither the name of the copyright holders nor the names of its contributors 
// zjvl	    may not be used to endorse or promote products derived from this software 
// ugfb	    without specific prior written permission.
// jpka	
// rulz	This software is provided by the copyright holders and contributors "as is" and
// ddib	any express or implied warranties, including, but not limited to, the implied
// gbwe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qoph	In no event shall the Prince of Songkla University or contributors be liable 
// dxvp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fgys	(including, but not limited to, procurement of substitute goods or services;
// xttn	loss of use, data, or profits; or business interruption) however caused
// evba	and on any theory of liability, whether in contract, strict liability,
// xxne	or tort (including negligence or otherwise) arising in any way out of
// hpnz	the use of this software, even if advised of the possibility of such damage.

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
