// hmbc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ygmv	
// gysu	 By downloading, copying, installing or using the software you agree to this license.
// ltag	 If you do not agree to this license, do not download, install,
// spll	 copy or use the software.
// ukrk	
// fstj	                          License Agreement
// bpgk	         For OpenVSS - Open Source Video Surveillance System
// pzll	
// qvus	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// trib	
// vjgh	Third party copyrights are property of their respective owners.
// zbca	
// tvzw	Redistribution and use in source and binary forms, with or without modification,
// vqwf	are permitted provided that the following conditions are met:
// nctr	
// siem	  * Redistribution's of source code must retain the above copyright notice,
// iopx	    this list of conditions and the following disclaimer.
// usrd	
// cpov	  * Redistribution's in binary form must reproduce the above copyright notice,
// lmka	    this list of conditions and the following disclaimer in the documentation
// nfru	    and/or other materials provided with the distribution.
// zoqa	
// yofr	  * Neither the name of the copyright holders nor the names of its contributors 
// xrin	    may not be used to endorse or promote products derived from this software 
// fuzl	    without specific prior written permission.
// mega	
// dwuf	This software is provided by the copyright holders and contributors "as is" and
// baua	any express or implied warranties, including, but not limited to, the implied
// rtdn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qjmt	In no event shall the Prince of Songkla University or contributors be liable 
// ypzf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mzfk	(including, but not limited to, procurement of substitute goods or services;
// hbqr	loss of use, data, or profits; or business interruption) however caused
// nzoi	and on any theory of liability, whether in contract, strict liability,
// yrrc	or tort (including negligence or otherwise) arising in any way out of
// tlyx	the use of this software, even if advised of the possibility of such damage.
// ufze	
// nuwv	Intelligent Systems Laboratory (iSys Lab)
// hfmw	Faculty of Engineering, Prince of Songkla University, THAILAND
// fane	Project leader by Nikom SUVONVORN
// rkxa	Project website at http://code.google.com/p/openvss/

using System;
using System.Drawing;
using System.Collections;

using Vs.Core.Image;

namespace Vs.Core.Analyzer
{

	/// <summary>
	/// VsIAnalysis interface
	/// </summary>
	public interface VsICoreAnalyzer
	{
        /// <summary>
        /// Output1
        /// </summary>
        event VsImageEventHandler FrameOut1;

        /// <summary>
        /// Output 2
        /// </summary>
        event VsImageEventHandler FrameOut2;

        /// <summary>
        /// Output 3
        /// </summary>
        event VsImageEventHandler FrameOut3;

        /// <summary>
        /// Output 4
        /// </summary>
        event VsImageEventHandler FrameOut4;

        /// <summary>
        /// Output 5
        /// </summary>
        event VsImageEventHandler FrameOut5;

        // new motion event out
        event VsMotionEventHandler MotionOut;

        /// <summary>
        /// Input 1
        /// </summary>
        void FrameIn1(object sender, VsImageEventArgs e);

        /// <summary>
        /// Input 2
        /// </summary>
        void FrameIn2(object sender, VsImageEventArgs e);

        /// <summary>
        /// Input 3
        /// </summary>
        void FrameIn3(object sender, VsImageEventArgs e);

        /// <summary>
        /// Input 4
        /// </summary>
        void FrameIn4(object sender, VsImageEventArgs e);

        /// <summary>
        /// Input 5
        /// </summary>
        void FrameIn5(object sender, VsImageEventArgs e);

        /// <summary>
        /// AnalyserName
        /// </summary>
        string AnalyserName { get; set; }

        /// <summary>
        /// Analyzer configuration
        /// </summary>
        Hashtable AnalyzerConfiguration { get; set;}

        /// <summary>
        /// Data directory
        /// </summary>
        string CameraName { get; set; }

        /// <summary>
        /// LocalHost
        /// </summary>
        string LocalHost { get; set; }
    }
}
