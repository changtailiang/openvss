// rgvi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fwis	
// gvnw	 By downloading, copying, installing or using the software you agree to this license.
// tdfw	 If you do not agree to this license, do not download, install,
// zdav	 copy or use the software.
// akvc	
// xuep	                          License Agreement
// ewvg	         For OpenVSS - Open Source Video Surveillance System
// nbpi	
// oizx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ubve	
// jncz	Third party copyrights are property of their respective owners.
// yxxn	
// onth	Redistribution and use in source and binary forms, with or without modification,
// ktkl	are permitted provided that the following conditions are met:
// stnk	
// zhis	  * Redistribution's of source code must retain the above copyright notice,
// owir	    this list of conditions and the following disclaimer.
// ddaz	
// prsj	  * Redistribution's in binary form must reproduce the above copyright notice,
// reqg	    this list of conditions and the following disclaimer in the documentation
// yira	    and/or other materials provided with the distribution.
// hixu	
// xofb	  * Neither the name of the copyright holders nor the names of its contributors 
// nkeb	    may not be used to endorse or promote products derived from this software 
// fjlb	    without specific prior written permission.
// ogjl	
// murt	This software is provided by the copyright holders and contributors "as is" and
// aatn	any express or implied warranties, including, but not limited to, the implied
// cgmq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qhlg	In no event shall the Prince of Songkla University or contributors be liable 
// zntp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xzme	(including, but not limited to, procurement of substitute goods or services;
// mqeh	loss of use, data, or profits; or business interruption) however caused
// spsr	and on any theory of liability, whether in contract, strict liability,
// zgom	or tort (including negligence or otherwise) arising in any way out of
// qetw	the use of this software, even if advised of the possibility of such damage.
// urzg	
// ynlx	Intelligent Systems Laboratory (iSys Lab)
// yfcb	Faculty of Engineering, Prince of Songkla University, THAILAND
// ntnm	Project leader by Nikom SUVONVORN
// ingk	Project website at http://code.google.com/p/openvss/

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
