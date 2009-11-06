// jcsp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// excr	
// jbdu	 By downloading, copying, installing or using the software you agree to this license.
// bmhq	 If you do not agree to this license, do not download, install,
// auzw	 copy or use the software.
// isjb	
// oaud	                          License Agreement
// tnrc	         For OpenVss - Open Source Video Surveillance System
// cvrk	
// pivc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xgyy	
// uuhf	Third party copyrights are property of their respective owners.
// pnqo	
// mkbr	Redistribution and use in source and binary forms, with or without modification,
// srae	are permitted provided that the following conditions are met:
// czxv	
// kbsf	  * Redistribution's of source code must retain the above copyright notice,
// vxas	    this list of conditions and the following disclaimer.
// ywzb	
// tlgu	  * Redistribution's in binary form must reproduce the above copyright notice,
// tpog	    this list of conditions and the following disclaimer in the documentation
// xdqs	    and/or other materials provided with the distribution.
// tzrx	
// irzx	  * Neither the name of the copyright holders nor the names of its contributors 
// icnt	    may not be used to endorse or promote products derived from this software 
// bbjr	    without specific prior written permission.
// mxpp	
// kzxh	This software is provided by the copyright holders and contributors "as is" and
// kflm	any express or implied warranties, including, but not limited to, the implied
// lryh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kalv	In no event shall the Prince of Songkla University or contributors be liable 
// gckh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wbsq	(including, but not limited to, procurement of substitute goods or services;
// xnsr	loss of use, data, or profits; or business interruption) however caused
// gwuz	and on any theory of liability, whether in contract, strict liability,
// nbht	or tort (including negligence or otherwise) arising in any way out of
// cknc	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Core.Encoder
{
	using System;
    using System.Drawing;
    using Vs.Core.Image;

	/// <summary>
	/// VsIAnalysis interface
	/// </summary>
	public interface VsICoreEncoder
	{
         /// <summary>
        /// New frame out
        /// </summary>
        event VsImageEventHandler FrameOut;

        // new data event out
        event VsDataEventHandler DataOut;

        // new data event out
        event VsDataEventHandler EventOut;

        /// <summary>
        /// Add new frame
        /// </summary>
        void FrameIn(object sender, VsImageEventArgs e);

        /// <summary>
        /// EncoderName
        /// </summary>
        string EncoderName { get; set; }

        /// <summary>
        /// Data directory
        /// </summary>
        string CameraName { get; set; }

        /// <summary>
        /// LocalHost
        /// </summary>
        string LocalHost { get; set; }

        /// <summary>
        /// Data directory
        /// </summary>
        string LocalStorage { get; set; }

        /// <summary>
        /// StartRecord
        /// </summary>
        void StartRecord();

        /// <summary>
        /// DoRecord
        /// </summary>
        void DoRecord(VsImage lastFrame);

        /// <summary>
        /// StopRecord
        /// </summary>
        void StopRecord();
    }
}
