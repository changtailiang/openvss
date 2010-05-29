// qzrj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lsnh	
// jyan	 By downloading, copying, installing or using the software you agree to this license.
// iunn	 If you do not agree to this license, do not download, install,
// twhv	 copy or use the software.
// ntst	
// clni	                          License Agreement
// dbcu	         For OpenVSS - Open Source Video Surveillance System
// srfj	
// ryov	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// osji	
// trvq	Third party copyrights are property of their respective owners.
// ruzr	
// zxox	Redistribution and use in source and binary forms, with or without modification,
// hyga	are permitted provided that the following conditions are met:
// ffei	
// vfvq	  * Redistribution's of source code must retain the above copyright notice,
// pewu	    this list of conditions and the following disclaimer.
// imhu	
// kjal	  * Redistribution's in binary form must reproduce the above copyright notice,
// pwri	    this list of conditions and the following disclaimer in the documentation
// bluu	    and/or other materials provided with the distribution.
// dibt	
// rnqj	  * Neither the name of the copyright holders nor the names of its contributors 
// nbmn	    may not be used to endorse or promote products derived from this software 
// vfbm	    without specific prior written permission.
// yejn	
// qtmx	This software is provided by the copyright holders and contributors "as is" and
// xvli	any express or implied warranties, including, but not limited to, the implied
// nvgk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kamg	In no event shall the Prince of Songkla University or contributors be liable 
// dcdu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wygj	(including, but not limited to, procurement of substitute goods or services;
// xmqk	loss of use, data, or profits; or business interruption) however caused
// ufkw	and on any theory of liability, whether in contract, strict liability,
// chek	or tort (including negligence or otherwise) arising in any way out of
// vdvw	the use of this software, even if advised of the possibility of such damage.
// chvs	
// ubdu	Intelligent Systems Laboratory (iSys Lab)
// sviv	Faculty of Engineering, Prince of Songkla University, THAILAND
// boqr	Project leader by Nikom SUVONVORN
// mdal	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vs.Core.Image
{
    // New Image delegate
    public delegate void VsDataEventHandler(object sender, VsDataEventArgs e);

    /// <summary>
    /// Camera event arguments
    /// </summary>
    public class VsDataEventArgs : EventArgs
    {
        private VsData vsdata;

        // Constructor
        public VsDataEventArgs(VsData dt)
        {
            vsdata = dt;
        }

        // Image property
        public VsData Data
        {
            get { return vsdata; }
        }
    }
}
