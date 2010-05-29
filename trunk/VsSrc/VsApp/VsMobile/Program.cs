// vxrn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kgil	
// hmwk	 By downloading, copying, installing or using the software you agree to this license.
// zjqs	 If you do not agree to this license, do not download, install,
// hfxi	 copy or use the software.
// jqih	
// mkjj	                          License Agreement
// wfnu	         For OpenVSS - Open Source Video Surveillance System
// bhdq	
// qkjq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// deta	
// vhqp	Third party copyrights are property of their respective owners.
// tbov	
// shef	Redistribution and use in source and binary forms, with or without modification,
// pjbz	are permitted provided that the following conditions are met:
// xzpc	
// zcjr	  * Redistribution's of source code must retain the above copyright notice,
// fzbw	    this list of conditions and the following disclaimer.
// whff	
// wimf	  * Redistribution's in binary form must reproduce the above copyright notice,
// ttpv	    this list of conditions and the following disclaimer in the documentation
// qsbt	    and/or other materials provided with the distribution.
// dybg	
// jjte	  * Neither the name of the copyright holders nor the names of its contributors 
// pras	    may not be used to endorse or promote products derived from this software 
// yzju	    without specific prior written permission.
// zszl	
// czjh	This software is provided by the copyright holders and contributors "as is" and
// xvfd	any express or implied warranties, including, but not limited to, the implied
// julh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bpoh	In no event shall the Prince of Songkla University or contributors be liable 
// yumm	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oape	(including, but not limited to, procurement of substitute goods or services;
// hthu	loss of use, data, or profits; or business interruption) however caused
// kvvy	and on any theory of liability, whether in contract, strict liability,
// sqqd	or tort (including negligence or otherwise) arising in any way out of
// pujn	the use of this software, even if advised of the possibility of such damage.
// dpuv	
// gtri	Intelligent Systems Laboratory (iSys Lab)
// kcve	Faculty of Engineering, Prince of Songkla University, THAILAND
// gmwb	Project leader by Nikom SUVONVORN
// jeze	Project website at http://code.google.com/p/openvss/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VsMobile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new VsMLogin());
            

        }

    }
}
