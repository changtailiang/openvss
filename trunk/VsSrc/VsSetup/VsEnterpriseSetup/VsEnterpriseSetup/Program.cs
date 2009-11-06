// czng	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jpxq	
// hfcd	 By downloading, copying, installing or using the software you agree to this license.
// itvm	 If you do not agree to this license, do not download, install,
// irgf	 copy or use the software.
// ahhv	
// sbte	                          License Agreement
// qwlx	         For OpenVss - Open Source Video Surveillance System
// vcot	
// cist	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// zfkj	
// nwvu	Third party copyrights are property of their respective owners.
// yypb	
// yopu	Redistribution and use in source and binary forms, with or without modification,
// srni	are permitted provided that the following conditions are met:
// vszl	
// tfig	  * Redistribution's of source code must retain the above copyright notice,
// fbka	    this list of conditions and the following disclaimer.
// yngu	
// xyiw	  * Redistribution's in binary form must reproduce the above copyright notice,
// fygs	    this list of conditions and the following disclaimer in the documentation
// gkyg	    and/or other materials provided with the distribution.
// mtbk	
// ukxh	  * Neither the name of the copyright holders nor the names of its contributors 
// fzph	    may not be used to endorse or promote products derived from this software 
// nppw	    without specific prior written permission.
// opcl	
// huxt	This software is provided by the copyright holders and contributors "as is" and
// jrcw	any express or implied warranties, including, but not limited to, the implied
// lhfj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hbtl	In no event shall the Prince of Songkla University or contributors be liable 
// azfo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pzpy	(including, but not limited to, procurement of substitute goods or services;
// jaiq	loss of use, data, or profits; or business interruption) however caused
// jkdq	and on any theory of liability, whether in contract, strict liability,
// imzs	or tort (including negligence or otherwise) arising in any way out of
// whad	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace VsSetup
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
            Application.Run(new VsInstall());
        }
    }
}
