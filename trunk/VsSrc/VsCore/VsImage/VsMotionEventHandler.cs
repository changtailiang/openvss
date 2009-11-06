// ikcu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dmwm	
// qdqq	 By downloading, copying, installing or using the software you agree to this license.
// jxie	 If you do not agree to this license, do not download, install,
// eddd	 copy or use the software.
// ewea	
// oezg	                          License Agreement
// jbec	         For OpenVss - Open Source Video Surveillance System
// ipvh	
// uhcd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// znyw	
// msqo	Third party copyrights are property of their respective owners.
// nehn	
// famm	Redistribution and use in source and binary forms, with or without modification,
// fcgy	are permitted provided that the following conditions are met:
// nqdp	
// zniu	  * Redistribution's of source code must retain the above copyright notice,
// bakx	    this list of conditions and the following disclaimer.
// badr	
// xhnv	  * Redistribution's in binary form must reproduce the above copyright notice,
// olte	    this list of conditions and the following disclaimer in the documentation
// urxi	    and/or other materials provided with the distribution.
// cjcs	
// bdqj	  * Neither the name of the copyright holders nor the names of its contributors 
// kixy	    may not be used to endorse or promote products derived from this software 
// kvmm	    without specific prior written permission.
// tjlf	
// wvoy	This software is provided by the copyright holders and contributors "as is" and
// okjc	any express or implied warranties, including, but not limited to, the implied
// wyvi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qzrs	In no event shall the Prince of Songkla University or contributors be liable 
// yswx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ktgp	(including, but not limited to, procurement of substitute goods or services;
// kpls	loss of use, data, or profits; or business interruption) however caused
// yhkk	and on any theory of liability, whether in contract, strict liability,
// fslh	or tort (including negligence or otherwise) arising in any way out of
// uddq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vs.Core.Image
{
    // New Image delegate
    public delegate void VsMotionEventHandler(object sender, VsMotionEventArgs e);

    /// <summary>
    /// Camera event arguments
    /// </summary>
    public class VsMotionEventArgs : EventArgs
    {
        private VsMotion vsMotion;

        // Constructor
        public VsMotionEventArgs(VsMotion motion)
        {
            vsMotion = motion;
        }

        // Image property
        public VsMotion Motion
        {
            get { return vsMotion; }
        }
    }
}
