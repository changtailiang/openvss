// opzt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// flhz	
// jijw	 By downloading, copying, installing or using the software you agree to this license.
// gddk	 If you do not agree to this license, do not download, install,
// ewtf	 copy or use the software.
// wbup	
// qeqq	                          License Agreement
// dzci	         For OpenVSS - Open Source Video Surveillance System
// bqag	
// eexi	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yphk	
// vxdd	Third party copyrights are property of their respective owners.
// jzmm	
// cxnn	Redistribution and use in source and binary forms, with or without modification,
// vkcb	are permitted provided that the following conditions are met:
// uqvj	
// favq	  * Redistribution's of source code must retain the above copyright notice,
// dwga	    this list of conditions and the following disclaimer.
// ykgg	
// tjtt	  * Redistribution's in binary form must reproduce the above copyright notice,
// anhd	    this list of conditions and the following disclaimer in the documentation
// nqfd	    and/or other materials provided with the distribution.
// cnlu	
// bvnh	  * Neither the name of the copyright holders nor the names of its contributors 
// txeu	    may not be used to endorse or promote products derived from this software 
// cnam	    without specific prior written permission.
// tmnr	
// rgtl	This software is provided by the copyright holders and contributors "as is" and
// rjbh	any express or implied warranties, including, but not limited to, the implied
// jrwp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vroq	In no event shall the Prince of Songkla University or contributors be liable 
// klyd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wynv	(including, but not limited to, procurement of substitute goods or services;
// fyqm	loss of use, data, or profits; or business interruption) however caused
// muka	and on any theory of liability, whether in contract, strict liability,
// comv	or tort (including negligence or otherwise) arising in any way out of
// tads	the use of this software, even if advised of the possibility of such damage.
// ugxc	
// bpzk	Intelligent Systems Laboratory (iSys Lab)
// zkbi	Faculty of Engineering, Prince of Songkla University, THAILAND
// okus	Project leader by Nikom SUVONVORN
// txfs	Project website at http://code.google.com/p/openvss/

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
