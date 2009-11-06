// ofqm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// eduj	
// zmer	 By downloading, copying, installing or using the software you agree to this license.
// dwiq	 If you do not agree to this license, do not download, install,
// lqnr	 copy or use the software.
// tkri	
// hapf	                          License Agreement
// hnkj	         For OpenVss - Open Source Video Surveillance System
// stnn	
// zgqp	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lpaw	
// zhgr	Third party copyrights are property of their respective owners.
// yklm	
// jaze	Redistribution and use in source and binary forms, with or without modification,
// oied	are permitted provided that the following conditions are met:
// opcm	
// bvzk	  * Redistribution's of source code must retain the above copyright notice,
// iuqf	    this list of conditions and the following disclaimer.
// axge	
// juja	  * Redistribution's in binary form must reproduce the above copyright notice,
// txgw	    this list of conditions and the following disclaimer in the documentation
// bxzr	    and/or other materials provided with the distribution.
// ujzr	
// bmbw	  * Neither the name of the copyright holders nor the names of its contributors 
// noud	    may not be used to endorse or promote products derived from this software 
// hwjd	    without specific prior written permission.
// ugmm	
// uuut	This software is provided by the copyright holders and contributors "as is" and
// ydkq	any express or implied warranties, including, but not limited to, the implied
// igkd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vhqy	In no event shall the Prince of Songkla University or contributors be liable 
// uzdn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wkqv	(including, but not limited to, procurement of substitute goods or services;
// afsx	loss of use, data, or profits; or business interruption) however caused
// ocbv	and on any theory of liability, whether in contract, strict liability,
// lnxz	or tort (including negligence or otherwise) arising in any way out of
// ofsy	the use of this software, even if advised of the possibility of such damage.

using System;

namespace Vs.Core.Analyzer
{

	/// <summary>
	/// VsIAnalysisPage interface
	/// </summary>
	public interface VsICoreAnalyzerPage
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
        VsICoreAnalyzerConfiguration GetConfiguration();

		/// <summary>
		/// Set configuration
		/// </summary>
        void SetConfiguration(VsICoreAnalyzerConfiguration config);
	}
}
