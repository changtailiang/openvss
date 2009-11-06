// bmpn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ocqy	
// ynin	 By downloading, copying, installing or using the software you agree to this license.
// dxzh	 If you do not agree to this license, do not download, install,
// telt	 copy or use the software.
// gtxw	
// kkxw	                          License Agreement
// rsph	         For OpenVss - Open Source Video Surveillance System
// kyay	
// jeue	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mpts	
// duue	Third party copyrights are property of their respective owners.
// dkrn	
// dpji	Redistribution and use in source and binary forms, with or without modification,
// psce	are permitted provided that the following conditions are met:
// ftgg	
// yacf	  * Redistribution's of source code must retain the above copyright notice,
// waxp	    this list of conditions and the following disclaimer.
// kghq	
// zesp	  * Redistribution's in binary form must reproduce the above copyright notice,
// qtsh	    this list of conditions and the following disclaimer in the documentation
// abev	    and/or other materials provided with the distribution.
// osir	
// bpzs	  * Neither the name of the copyright holders nor the names of its contributors 
// jnud	    may not be used to endorse or promote products derived from this software 
// sohc	    without specific prior written permission.
// mcdx	
// isil	This software is provided by the copyright holders and contributors "as is" and
// zmom	any express or implied warranties, including, but not limited to, the implied
// bygw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vgre	In no event shall the Prince of Songkla University or contributors be liable 
// sgnu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gohm	(including, but not limited to, procurement of substitute goods or services;
// jpxb	loss of use, data, or profits; or business interruption) however caused
// lpux	and on any theory of liability, whether in contract, strict liability,
// yhnv	or tort (including negligence or otherwise) arising in any way out of
// jxro	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vs.Core.Image
{
    // New Image delegate
    public delegate void VsImageEventHandler(object sender, VsImageEventArgs e);

    /// <summary>
    /// Camera event arguments
    /// </summary>
    public class VsImageEventArgs : EventArgs
    {
        private VsImage vsImage;

        // Constructor
        public VsImageEventArgs(VsImage vsImg)
        {
            vsImage = vsImg;
        }

        // Image property
        public VsImage Image
        {
            get { return vsImage; }
        }
    }
}
