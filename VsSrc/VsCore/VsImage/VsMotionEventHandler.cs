// mnov	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qvxe	
// dyuv	 By downloading, copying, installing or using the software you agree to this license.
// jedj	 If you do not agree to this license, do not download, install,
// nbzw	 copy or use the software.
// ttqb	
// tyin	                          License Agreement
// edul	         For OpenVSS - Open Source Video Surveillance System
// dlge	
// jebk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pelp	
// wbtk	Third party copyrights are property of their respective owners.
// fgdd	
// febs	Redistribution and use in source and binary forms, with or without modification,
// wncr	are permitted provided that the following conditions are met:
// njaz	
// disx	  * Redistribution's of source code must retain the above copyright notice,
// yzzj	    this list of conditions and the following disclaimer.
// aphp	
// hber	  * Redistribution's in binary form must reproduce the above copyright notice,
// fyhy	    this list of conditions and the following disclaimer in the documentation
// zqgy	    and/or other materials provided with the distribution.
// knhw	
// cjwg	  * Neither the name of the copyright holders nor the names of its contributors 
// dmlo	    may not be used to endorse or promote products derived from this software 
// ivlg	    without specific prior written permission.
// gudp	
// xllv	This software is provided by the copyright holders and contributors "as is" and
// ikmp	any express or implied warranties, including, but not limited to, the implied
// bczm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ctnk	In no event shall the Prince of Songkla University or contributors be liable 
// rdgq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// salu	(including, but not limited to, procurement of substitute goods or services;
// pqij	loss of use, data, or profits; or business interruption) however caused
// mbsf	and on any theory of liability, whether in contract, strict liability,
// nray	or tort (including negligence or otherwise) arising in any way out of
// cmns	the use of this software, even if advised of the possibility of such damage.
// xheb	
// nymo	Intelligent Systems Laboratory (iSys Lab)
// ibpd	Faculty of Engineering, Prince of Songkla University, THAILAND
// omww	Project leader by Nikom SUVONVORN
// aqfs	Project website at http://code.google.com/p/openvss/

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
