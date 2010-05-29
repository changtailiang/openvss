// cxyn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ywuj	
// duuy	 By downloading, copying, installing or using the software you agree to this license.
// wfjw	 If you do not agree to this license, do not download, install,
// pcxy	 copy or use the software.
// cawx	
// gjll	                          License Agreement
// eswv	         For OpenVSS - Open Source Video Surveillance System
// akoo	
// ygey	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// aokl	
// qrcu	Third party copyrights are property of their respective owners.
// esvw	
// yjic	Redistribution and use in source and binary forms, with or without modification,
// aago	are permitted provided that the following conditions are met:
// kifl	
// xyxm	  * Redistribution's of source code must retain the above copyright notice,
// qvxi	    this list of conditions and the following disclaimer.
// xyyo	
// qlho	  * Redistribution's in binary form must reproduce the above copyright notice,
// hqhl	    this list of conditions and the following disclaimer in the documentation
// xaxq	    and/or other materials provided with the distribution.
// bmny	
// zqos	  * Neither the name of the copyright holders nor the names of its contributors 
// jznr	    may not be used to endorse or promote products derived from this software 
// updi	    without specific prior written permission.
// umyz	
// lump	This software is provided by the copyright holders and contributors "as is" and
// tsgt	any express or implied warranties, including, but not limited to, the implied
// btox	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bgke	In no event shall the Prince of Songkla University or contributors be liable 
// hzjh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kgfq	(including, but not limited to, procurement of substitute goods or services;
// xqur	loss of use, data, or profits; or business interruption) however caused
// nyrl	and on any theory of liability, whether in contract, strict liability,
// bxfh	or tort (including negligence or otherwise) arising in any way out of
// ayeh	the use of this software, even if advised of the possibility of such damage.
// kurp	
// lqpo	Intelligent Systems Laboratory (iSys Lab)
// fzav	Faculty of Engineering, Prince of Songkla University, THAILAND
// crof	Project leader by Nikom SUVONVORN
// pvsc	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VsStreamerTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VsStreamerTest());
        }
    }
}
