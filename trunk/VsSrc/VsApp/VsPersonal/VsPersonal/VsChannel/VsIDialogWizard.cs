// oubj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// skzg	
// knca	 By downloading, copying, installing or using the software you agree to this license.
// nomq	 If you do not agree to this license, do not download, install,
// rnot	 copy or use the software.
// wwss	
// umfc	                          License Agreement
// uatx	         For OpenVSS - Open Source Video Surveillance System
// olve	
// udtx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bsjr	
// sfkj	Third party copyrights are property of their respective owners.
// toeq	
// cxmr	Redistribution and use in source and binary forms, with or without modification,
// bjpf	are permitted provided that the following conditions are met:
// fwmk	
// uelc	  * Redistribution's of source code must retain the above copyright notice,
// siwn	    this list of conditions and the following disclaimer.
// urse	
// mbao	  * Redistribution's in binary form must reproduce the above copyright notice,
// cvif	    this list of conditions and the following disclaimer in the documentation
// vcvr	    and/or other materials provided with the distribution.
// ydcl	
// onre	  * Neither the name of the copyright holders nor the names of its contributors 
// fyxo	    may not be used to endorse or promote products derived from this software 
// thrl	    without specific prior written permission.
// sqwl	
// ehez	This software is provided by the copyright holders and contributors "as is" and
// jadj	any express or implied warranties, including, but not limited to, the implied
// ngor	warranties of merchantability and fitness for a particular purpose are disclaimed.
// itep	In no event shall the Prince of Songkla University or contributors be liable 
// flzg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// znyo	(including, but not limited to, procurement of substitute goods or services;
// elvu	loss of use, data, or profits; or business interruption) however caused
// exnf	and on any theory of liability, whether in contract, strict liability,
// gknq	or tort (including negligence or otherwise) arising in any way out of
// ycbn	the use of this software, even if advised of the possibility of such damage.
// kiqz	
// kffa	Intelligent Systems Laboratory (iSys Lab)
// dbfh	Faculty of Engineering, Prince of Songkla University, THAILAND
// qqmr	Project leader by Nikom SUVONVORN
// jqvx	Project website at http://code.google.com/p/openvss/

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
