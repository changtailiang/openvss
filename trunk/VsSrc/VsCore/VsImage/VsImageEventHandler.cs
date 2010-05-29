// vizk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ftyv	
// pcgt	 By downloading, copying, installing or using the software you agree to this license.
// zpvy	 If you do not agree to this license, do not download, install,
// tsaz	 copy or use the software.
// tgyd	
// dlve	                          License Agreement
// wxvj	         For OpenVSS - Open Source Video Surveillance System
// rocy	
// qbzp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vbuo	
// ttty	Third party copyrights are property of their respective owners.
// qwwb	
// alfp	Redistribution and use in source and binary forms, with or without modification,
// kvgu	are permitted provided that the following conditions are met:
// xtzs	
// gwcl	  * Redistribution's of source code must retain the above copyright notice,
// nxhr	    this list of conditions and the following disclaimer.
// tler	
// lkkj	  * Redistribution's in binary form must reproduce the above copyright notice,
// rwoz	    this list of conditions and the following disclaimer in the documentation
// aujf	    and/or other materials provided with the distribution.
// imnu	
// verb	  * Neither the name of the copyright holders nor the names of its contributors 
// cchw	    may not be used to endorse or promote products derived from this software 
// rhlt	    without specific prior written permission.
// ofhp	
// hnez	This software is provided by the copyright holders and contributors "as is" and
// lwda	any express or implied warranties, including, but not limited to, the implied
// fzrl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nwca	In no event shall the Prince of Songkla University or contributors be liable 
// jmwp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tdpi	(including, but not limited to, procurement of substitute goods or services;
// cnsj	loss of use, data, or profits; or business interruption) however caused
// lukv	and on any theory of liability, whether in contract, strict liability,
// mtyv	or tort (including negligence or otherwise) arising in any way out of
// iojy	the use of this software, even if advised of the possibility of such damage.
// arvc	
// lvjv	Intelligent Systems Laboratory (iSys Lab)
// ekjb	Faculty of Engineering, Prince of Songkla University, THAILAND
// jsvd	Project leader by Nikom SUVONVORN
// yvxx	Project website at http://code.google.com/p/openvss/

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
