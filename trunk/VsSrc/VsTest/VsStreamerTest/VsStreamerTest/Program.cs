// yzpw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mgkk	
// kzbx	 By downloading, copying, installing or using the software you agree to this license.
// cqaf	 If you do not agree to this license, do not download, install,
// noem	 copy or use the software.
// wqds	
// buug	                          License Agreement
// hjiu	         For OpenVss - Open Source Video Surveillance System
// heml	
// huvj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jbth	
// tuas	Third party copyrights are property of their respective owners.
// ogvz	
// ivjh	Redistribution and use in source and binary forms, with or without modification,
// wxur	are permitted provided that the following conditions are met:
// medb	
// qgpy	  * Redistribution's of source code must retain the above copyright notice,
// doyt	    this list of conditions and the following disclaimer.
// tvdu	
// wvyh	  * Redistribution's in binary form must reproduce the above copyright notice,
// ubrb	    this list of conditions and the following disclaimer in the documentation
// ojll	    and/or other materials provided with the distribution.
// uepj	
// zexf	  * Neither the name of the copyright holders nor the names of its contributors 
// ysqn	    may not be used to endorse or promote products derived from this software 
// fboa	    without specific prior written permission.
// ibgn	
// spka	This software is provided by the copyright holders and contributors "as is" and
// znxk	any express or implied warranties, including, but not limited to, the implied
// mcmh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uedz	In no event shall the Prince of Songkla University or contributors be liable 
// zouo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xyve	(including, but not limited to, procurement of substitute goods or services;
// flcs	loss of use, data, or profits; or business interruption) however caused
// mrsn	and on any theory of liability, whether in contract, strict liability,
// dxsf	or tort (including negligence or otherwise) arising in any way out of
// tpjl	the use of this software, even if advised of the possibility of such damage.

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
