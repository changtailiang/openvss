// raer	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gmpj	
// dhhy	 By downloading, copying, installing or using the software you agree to this license.
// mqqw	 If you do not agree to this license, do not download, install,
// qygw	 copy or use the software.
// eisu	
// dlkk	                          License Agreement
// pyje	         For OpenVss - Open Source Video Surveillance System
// vwax	
// teum	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// fqdm	
// jkpr	Third party copyrights are property of their respective owners.
// gegb	
// pmqi	Redistribution and use in source and binary forms, with or without modification,
// hjou	are permitted provided that the following conditions are met:
// cftf	
// xdcq	  * Redistribution's of source code must retain the above copyright notice,
// ptdm	    this list of conditions and the following disclaimer.
// etqo	
// eglt	  * Redistribution's in binary form must reproduce the above copyright notice,
// wtek	    this list of conditions and the following disclaimer in the documentation
// rioj	    and/or other materials provided with the distribution.
// frpj	
// paja	  * Neither the name of the copyright holders nor the names of its contributors 
// xyof	    may not be used to endorse or promote products derived from this software 
// izbm	    without specific prior written permission.
// btxw	
// vceb	This software is provided by the copyright holders and contributors "as is" and
// yvxi	any express or implied warranties, including, but not limited to, the implied
// ainp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ptkx	In no event shall the Prince of Songkla University or contributors be liable 
// euwe	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kqqf	(including, but not limited to, procurement of substitute goods or services;
// rflx	loss of use, data, or profits; or business interruption) however caused
// rrjy	and on any theory of liability, whether in contract, strict liability,
// ksnd	or tort (including negligence or otherwise) arising in any way out of
// nnku	the use of this software, even if advised of the possibility of such damage.

using System;
using Vs.Core.Image;

namespace Vs.Core
{
    public interface VsAppInterface
    {
        /// <summary>
        /// FrameIn
        /// </summary>
        void FrameIn(object sender, VsImageEventArgs e);
 
    }

    public interface VsEventInterface
    {
        /// <summary>
        /// FrameIn
        /// </summary>
        void FrameIn(object sender, VsMotionEventArgs e);
    }
}
