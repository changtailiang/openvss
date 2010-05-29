// dbqw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ahcf	
// jpff	 By downloading, copying, installing or using the software you agree to this license.
// qtqq	 If you do not agree to this license, do not download, install,
// dtbv	 copy or use the software.
// salu	
// cbwj	                          License Agreement
// tjgx	         For OpenVSS - Open Source Video Surveillance System
// glta	
// idpc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wxko	
// xfbf	Third party copyrights are property of their respective owners.
// icqv	
// ysnd	Redistribution and use in source and binary forms, with or without modification,
// pvty	are permitted provided that the following conditions are met:
// ktla	
// jhze	  * Redistribution's of source code must retain the above copyright notice,
// aqhz	    this list of conditions and the following disclaimer.
// eyyu	
// pxxx	  * Redistribution's in binary form must reproduce the above copyright notice,
// arar	    this list of conditions and the following disclaimer in the documentation
// skyn	    and/or other materials provided with the distribution.
// yqkm	
// jqsc	  * Neither the name of the copyright holders nor the names of its contributors 
// mkep	    may not be used to endorse or promote products derived from this software 
// gwfs	    without specific prior written permission.
// uqra	
// ttns	This software is provided by the copyright holders and contributors "as is" and
// ywxs	any express or implied warranties, including, but not limited to, the implied
// tuhy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jlgk	In no event shall the Prince of Songkla University or contributors be liable 
// gvqn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gwif	(including, but not limited to, procurement of substitute goods or services;
// tird	loss of use, data, or profits; or business interruption) however caused
// miwc	and on any theory of liability, whether in contract, strict liability,
// tytf	or tort (including negligence or otherwise) arising in any way out of
// csom	the use of this software, even if advised of the possibility of such damage.
// szjr	
// dffu	Intelligent Systems Laboratory (iSys Lab)
// qvmz	Faculty of Engineering, Prince of Songkla University, THAILAND
// zdtx	Project leader by Nikom SUVONVORN
// khyq	Project website at http://code.google.com/p/openvss/

namespace Vs.Core.Provider
{
	using System;

	/// <summary>
	/// IVideoSourcePage interface
	/// </summary>
	public interface VsICoreProviderPage
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
