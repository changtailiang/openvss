// oecj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// znjt	
// hrkx	 By downloading, copying, installing or using the software you agree to this license.
// lwet	 If you do not agree to this license, do not download, install,
// cpzs	 copy or use the software.
// vgcv	
// zvqf	                          License Agreement
// ykwu	         For OpenVSS - Open Source Video Surveillance System
// tlzd	
// huil	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qpgd	
// xoud	Third party copyrights are property of their respective owners.
// gfou	
// clzh	Redistribution and use in source and binary forms, with or without modification,
// chjd	are permitted provided that the following conditions are met:
// xduw	
// updz	  * Redistribution's of source code must retain the above copyright notice,
// xbmi	    this list of conditions and the following disclaimer.
// gobf	
// ayxl	  * Redistribution's in binary form must reproduce the above copyright notice,
// anzt	    this list of conditions and the following disclaimer in the documentation
// wcrh	    and/or other materials provided with the distribution.
// mraa	
// kfon	  * Neither the name of the copyright holders nor the names of its contributors 
// vkii	    may not be used to endorse or promote products derived from this software 
// kugf	    without specific prior written permission.
// tgno	
// kthd	This software is provided by the copyright holders and contributors "as is" and
// jycj	any express or implied warranties, including, but not limited to, the implied
// eazs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xvnf	In no event shall the Prince of Songkla University or contributors be liable 
// alxa	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zojq	(including, but not limited to, procurement of substitute goods or services;
// poag	loss of use, data, or profits; or business interruption) however caused
// guaq	and on any theory of liability, whether in contract, strict liability,
// odxs	or tort (including negligence or otherwise) arising in any way out of
// jxqm	the use of this software, even if advised of the possibility of such damage.
// ceiv	
// kqlp	Intelligent Systems Laboratory (iSys Lab)
// haeh	Faculty of Engineering, Prince of Songkla University, THAILAND
// jmpw	Project leader by Nikom SUVONVORN
// jrnu	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vs.Core.Image
{
    // New Image delegate
    public delegate void VsEncodeEventHandler(object sender, VsEncodeEventArgs e);

    /// <summary>
    /// Camera event arguments
    /// </summary>
    public class VsEncodeEventArgs : EventArgs
    {
        private VsEncode vsEncode;

        // Constructor
        public VsEncodeEventArgs(VsEncode vsEnc)
        {
            vsEncode = vsEnc;
        }

        // Image property
        public VsEncode Encode
        {
            get { return vsEncode; }
        }
    }
}
