// nfoi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bghg	
// mofw	 By downloading, copying, installing or using the software you agree to this license.
// mxps	 If you do not agree to this license, do not download, install,
// mkzp	 copy or use the software.
// zdss	
// xtht	                          License Agreement
// keme	         For OpenVss - Open Source Video Surveillance System
// xubo	
// lhau	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pjqb	
// jhys	Third party copyrights are property of their respective owners.
// oxvc	
// sotk	Redistribution and use in source and binary forms, with or without modification,
// nwki	are permitted provided that the following conditions are met:
// yowi	
// cbzr	  * Redistribution's of source code must retain the above copyright notice,
// vbge	    this list of conditions and the following disclaimer.
// jeap	
// nqiq	  * Redistribution's in binary form must reproduce the above copyright notice,
// uoem	    this list of conditions and the following disclaimer in the documentation
// ikli	    and/or other materials provided with the distribution.
// brap	
// xsva	  * Neither the name of the copyright holders nor the names of its contributors 
// nhzh	    may not be used to endorse or promote products derived from this software 
// igxm	    without specific prior written permission.
// rqsn	
// odww	This software is provided by the copyright holders and contributors "as is" and
// ounk	any express or implied warranties, including, but not limited to, the implied
// jjzs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// prqe	In no event shall the Prince of Songkla University or contributors be liable 
// aqgq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// iacf	(including, but not limited to, procurement of substitute goods or services;
// raho	loss of use, data, or profits; or business interruption) however caused
// rsus	and on any theory of liability, whether in contract, strict liability,
// rytx	or tort (including negligence or otherwise) arising in any way out of
// uebd	the use of this software, even if advised of the possibility of such damage.

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
