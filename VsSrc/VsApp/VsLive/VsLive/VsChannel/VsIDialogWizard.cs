// qljo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zpcx	
// ijif	 By downloading, copying, installing or using the software you agree to this license.
// qkmh	 If you do not agree to this license, do not download, install,
// dyor	 copy or use the software.
// sele	
// btwp	                          License Agreement
// anib	         For OpenVSS - Open Source Video Surveillance System
// zgdn	
// zspu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cbbm	
// vtqp	Third party copyrights are property of their respective owners.
// evmf	
// ygel	Redistribution and use in source and binary forms, with or without modification,
// zeng	are permitted provided that the following conditions are met:
// smxv	
// aggj	  * Redistribution's of source code must retain the above copyright notice,
// hzhl	    this list of conditions and the following disclaimer.
// iupr	
// czji	  * Redistribution's in binary form must reproduce the above copyright notice,
// chlf	    this list of conditions and the following disclaimer in the documentation
// addt	    and/or other materials provided with the distribution.
// csnv	
// ejbp	  * Neither the name of the copyright holders nor the names of its contributors 
// eglo	    may not be used to endorse or promote products derived from this software 
// mhif	    without specific prior written permission.
// nbwd	
// qmja	This software is provided by the copyright holders and contributors "as is" and
// vfel	any express or implied warranties, including, but not limited to, the implied
// brux	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cnho	In no event shall the Prince of Songkla University or contributors be liable 
// lmgz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tanv	(including, but not limited to, procurement of substitute goods or services;
// nuvu	loss of use, data, or profits; or business interruption) however caused
// ygry	and on any theory of liability, whether in contract, strict liability,
// hacp	or tort (including negligence or otherwise) arising in any way out of
// inaz	the use of this software, even if advised of the possibility of such damage.
// fpnm	
// molz	Intelligent Systems Laboratory (iSys Lab)
// atta	Faculty of Engineering, Prince of Songkla University, THAILAND
// vwkq	Project leader by Nikom SUVONVORN
// znma	Project website at http://code.google.com/p/openvss/

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
