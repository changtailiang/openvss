// doyu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wlug	
// ogno	 By downloading, copying, installing or using the software you agree to this license.
// alsq	 If you do not agree to this license, do not download, install,
// kluh	 copy or use the software.
// thhk	
// mtlw	                          License Agreement
// ynxy	         For OpenVSS - Open Source Video Surveillance System
// enab	
// gxbf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bnlr	
// mrsh	Third party copyrights are property of their respective owners.
// dszp	
// pnov	Redistribution and use in source and binary forms, with or without modification,
// hoic	are permitted provided that the following conditions are met:
// zyib	
// ipkm	  * Redistribution's of source code must retain the above copyright notice,
// kqkn	    this list of conditions and the following disclaimer.
// kogg	
// wpxu	  * Redistribution's in binary form must reproduce the above copyright notice,
// besf	    this list of conditions and the following disclaimer in the documentation
// nhiq	    and/or other materials provided with the distribution.
// zfur	
// ozgd	  * Neither the name of the copyright holders nor the names of its contributors 
// ekix	    may not be used to endorse or promote products derived from this software 
// hfwn	    without specific prior written permission.
// hmfb	
// hhzr	This software is provided by the copyright holders and contributors "as is" and
// qnau	any express or implied warranties, including, but not limited to, the implied
// fcnb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gtmf	In no event shall the Prince of Songkla University or contributors be liable 
// wsyk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hdbm	(including, but not limited to, procurement of substitute goods or services;
// gznw	loss of use, data, or profits; or business interruption) however caused
// ifyb	and on any theory of liability, whether in contract, strict liability,
// bgjr	or tort (including negligence or otherwise) arising in any way out of
// gcbb	the use of this software, even if advised of the possibility of such damage.
// zlxb	
// whqn	Intelligent Systems Laboratory (iSys Lab)
// sqro	Faculty of Engineering, Prince of Songkla University, THAILAND
// ovue	Project leader by Nikom SUVONVORN
// gmlr	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InsertComment
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
            Application.Run(new VsLicense());
        }
    }
}
