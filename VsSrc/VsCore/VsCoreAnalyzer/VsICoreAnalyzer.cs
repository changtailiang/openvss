// rwrt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xbjv	
// ukdp	 By downloading, copying, installing or using the software you agree to this license.
// utcm	 If you do not agree to this license, do not download, install,
// auzq	 copy or use the software.
// uvoc	
// bcni	                          License Agreement
// ecsc	         For OpenVss - Open Source Video Surveillance System
// sqim	
// jnoo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// idet	
// fvoq	Third party copyrights are property of their respective owners.
// rpjm	
// imfv	Redistribution and use in source and binary forms, with or without modification,
// ipsu	are permitted provided that the following conditions are met:
// nbrr	
// rawd	  * Redistribution's of source code must retain the above copyright notice,
// lqdm	    this list of conditions and the following disclaimer.
// flhr	
// rvxf	  * Redistribution's in binary form must reproduce the above copyright notice,
// oxqo	    this list of conditions and the following disclaimer in the documentation
// tgtf	    and/or other materials provided with the distribution.
// kmet	
// vtah	  * Neither the name of the copyright holders nor the names of its contributors 
// lnbe	    may not be used to endorse or promote products derived from this software 
// zkea	    without specific prior written permission.
// mxgx	
// fnen	This software is provided by the copyright holders and contributors "as is" and
// smgq	any express or implied warranties, including, but not limited to, the implied
// kcxl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hqtz	In no event shall the Prince of Songkla University or contributors be liable 
// ljrl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kafe	(including, but not limited to, procurement of substitute goods or services;
// tsgd	loss of use, data, or profits; or business interruption) however caused
// sqcw	and on any theory of liability, whether in contract, strict liability,
// zwaw	or tort (including negligence or otherwise) arising in any way out of
// hrbj	the use of this software, even if advised of the possibility of such damage.

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
