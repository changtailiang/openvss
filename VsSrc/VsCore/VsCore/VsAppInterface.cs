// dsws	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hplf	
// wnuy	 By downloading, copying, installing or using the software you agree to this license.
// dsvn	 If you do not agree to this license, do not download, install,
// sbcv	 copy or use the software.
// llyi	
// wuby	                          License Agreement
// tgzk	         For OpenVSS - Open Source Video Surveillance System
// ckdt	
// ehve	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yvfy	
// qyya	Third party copyrights are property of their respective owners.
// ceuw	
// igvr	Redistribution and use in source and binary forms, with or without modification,
// unwm	are permitted provided that the following conditions are met:
// onlp	
// nkwt	  * Redistribution's of source code must retain the above copyright notice,
// ocjk	    this list of conditions and the following disclaimer.
// gyxq	
// gasx	  * Redistribution's in binary form must reproduce the above copyright notice,
// wbvo	    this list of conditions and the following disclaimer in the documentation
// ldbv	    and/or other materials provided with the distribution.
// omzq	
// lipk	  * Neither the name of the copyright holders nor the names of its contributors 
// jpkg	    may not be used to endorse or promote products derived from this software 
// bfla	    without specific prior written permission.
// vkpk	
// iekt	This software is provided by the copyright holders and contributors "as is" and
// vyqm	any express or implied warranties, including, but not limited to, the implied
// swdk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ibec	In no event shall the Prince of Songkla University or contributors be liable 
// cszy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// inhr	(including, but not limited to, procurement of substitute goods or services;
// pmwq	loss of use, data, or profits; or business interruption) however caused
// pvtb	and on any theory of liability, whether in contract, strict liability,
// nqnj	or tort (including negligence or otherwise) arising in any way out of
// bfvm	the use of this software, even if advised of the possibility of such damage.
// rdsm	
// laxa	Intelligent Systems Laboratory (iSys Lab)
// bjxc	Faculty of Engineering, Prince of Songkla University, THAILAND
// krcv	Project leader by Nikom SUVONVORN
// xtei	Project website at http://code.google.com/p/openvss/

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
