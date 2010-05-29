// jiub	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ptgf	
// sbds	 By downloading, copying, installing or using the software you agree to this license.
// fyuz	 If you do not agree to this license, do not download, install,
// uvkv	 copy or use the software.
// ygpd	
// cflm	                          License Agreement
// vuxk	         For OpenVSS - Open Source Video Surveillance System
// ezfl	
// vybh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kdmk	
// pwez	Third party copyrights are property of their respective owners.
// ffgh	
// rstd	Redistribution and use in source and binary forms, with or without modification,
// sqyk	are permitted provided that the following conditions are met:
// huky	
// esof	  * Redistribution's of source code must retain the above copyright notice,
// tjew	    this list of conditions and the following disclaimer.
// tdlv	
// teog	  * Redistribution's in binary form must reproduce the above copyright notice,
// amhp	    this list of conditions and the following disclaimer in the documentation
// nptl	    and/or other materials provided with the distribution.
// gcte	
// zqzq	  * Neither the name of the copyright holders nor the names of its contributors 
// tofw	    may not be used to endorse or promote products derived from this software 
// hygv	    without specific prior written permission.
// bknn	
// hyjn	This software is provided by the copyright holders and contributors "as is" and
// crjv	any express or implied warranties, including, but not limited to, the implied
// nukp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yczr	In no event shall the Prince of Songkla University or contributors be liable 
// qzwc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dvbf	(including, but not limited to, procurement of substitute goods or services;
// yryb	loss of use, data, or profits; or business interruption) however caused
// flnd	and on any theory of liability, whether in contract, strict liability,
// bfeh	or tort (including negligence or otherwise) arising in any way out of
// sfbi	the use of this software, even if advised of the possibility of such damage.
// hedy	
// dqyf	Intelligent Systems Laboratory (iSys Lab)
// ypfb	Faculty of Engineering, Prince of Songkla University, THAILAND
// nlkm	Project leader by Nikom SUVONVORN
// weol	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Vs.Playback.VsCamList
{
    public class DragHelper
    {
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_BeginDrag(IntPtr himlTrack, int
            iTrack, int dxHotspot, int dyHotspot);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragMove(int x, int y);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern void ImageList_EndDrag();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragEnter(IntPtr hwndLock, int x, int y);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragLeave(IntPtr hwndLock);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragShowNolock(bool fShow);

        static DragHelper()
        {
            InitCommonControls();
        }
    }
}
