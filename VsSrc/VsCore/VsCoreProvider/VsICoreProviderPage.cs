// oxlr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xuid	
// hyml	 By downloading, copying, installing or using the software you agree to this license.
// swjc	 If you do not agree to this license, do not download, install,
// iplt	 copy or use the software.
// dkqo	
// wavs	                          License Agreement
// zclb	         For OpenVss - Open Source Video Surveillance System
// jtjk	
// ocdc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xjbx	
// kcvn	Third party copyrights are property of their respective owners.
// zdqa	
// cjyd	Redistribution and use in source and binary forms, with or without modification,
// hxvx	are permitted provided that the following conditions are met:
// yqee	
// nlbz	  * Redistribution's of source code must retain the above copyright notice,
// myof	    this list of conditions and the following disclaimer.
// livt	
// jsdt	  * Redistribution's in binary form must reproduce the above copyright notice,
// ehtv	    this list of conditions and the following disclaimer in the documentation
// mkza	    and/or other materials provided with the distribution.
// ufdq	
// hgeg	  * Neither the name of the copyright holders nor the names of its contributors 
// fwkz	    may not be used to endorse or promote products derived from this software 
// bwba	    without specific prior written permission.
// okou	
// nfup	This software is provided by the copyright holders and contributors "as is" and
// ucsr	any express or implied warranties, including, but not limited to, the implied
// xisc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mbeg	In no event shall the Prince of Songkla University or contributors be liable 
// vxyf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dpnn	(including, but not limited to, procurement of substitute goods or services;
// hdsi	loss of use, data, or profits; or business interruption) however caused
// gtgc	and on any theory of liability, whether in contract, strict liability,
// wenp	or tort (including negligence or otherwise) arising in any way out of
// lnwe	the use of this software, even if advised of the possibility of such damage.

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
