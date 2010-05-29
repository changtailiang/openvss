// djoa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lrvh	
// eujg	 By downloading, copying, installing or using the software you agree to this license.
// iyon	 If you do not agree to this license, do not download, install,
// xzdv	 copy or use the software.
// hmja	
// hkps	                          License Agreement
// uacv	         For OpenVSS - Open Source Video Surveillance System
// qmqc	
// jzxa	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mtqz	
// hjcg	Third party copyrights are property of their respective owners.
// qyma	
// axkr	Redistribution and use in source and binary forms, with or without modification,
// znta	are permitted provided that the following conditions are met:
// bcne	
// rnqw	  * Redistribution's of source code must retain the above copyright notice,
// hmey	    this list of conditions and the following disclaimer.
// bdio	
// vktx	  * Redistribution's in binary form must reproduce the above copyright notice,
// ijcv	    this list of conditions and the following disclaimer in the documentation
// ocvs	    and/or other materials provided with the distribution.
// bzcw	
// gwzk	  * Neither the name of the copyright holders nor the names of its contributors 
// fmhu	    may not be used to endorse or promote products derived from this software 
// tgze	    without specific prior written permission.
// unyx	
// owvp	This software is provided by the copyright holders and contributors "as is" and
// tvss	any express or implied warranties, including, but not limited to, the implied
// zrpp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sxuh	In no event shall the Prince of Songkla University or contributors be liable 
// khrf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dyij	(including, but not limited to, procurement of substitute goods or services;
// czeb	loss of use, data, or profits; or business interruption) however caused
// jyba	and on any theory of liability, whether in contract, strict liability,
// dxdf	or tort (including negligence or otherwise) arising in any way out of
// emcl	the use of this software, even if advised of the possibility of such damage.
// dgko	
// xsbv	Intelligent Systems Laboratory (iSys Lab)
// mrtm	Faculty of Engineering, Prince of Songkla University, THAILAND
// wttq	Project leader by Nikom SUVONVORN
// ommu	Project website at http://code.google.com/p/openvss/

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
