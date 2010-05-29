// cmvq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nvns	
// pefj	 By downloading, copying, installing or using the software you agree to this license.
// llnh	 If you do not agree to this license, do not download, install,
// qkol	 copy or use the software.
// hgpf	
// snvm	                          License Agreement
// torr	         For OpenVSS - Open Source Video Surveillance System
// wyvx	
// ejiv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// baio	
// myrv	Third party copyrights are property of their respective owners.
// ccma	
// fksw	Redistribution and use in source and binary forms, with or without modification,
// wpya	are permitted provided that the following conditions are met:
// abza	
// nnmm	  * Redistribution's of source code must retain the above copyright notice,
// qqdg	    this list of conditions and the following disclaimer.
// csjh	
// yatt	  * Redistribution's in binary form must reproduce the above copyright notice,
// vzjq	    this list of conditions and the following disclaimer in the documentation
// brlm	    and/or other materials provided with the distribution.
// fzao	
// liva	  * Neither the name of the copyright holders nor the names of its contributors 
// ahby	    may not be used to endorse or promote products derived from this software 
// lffm	    without specific prior written permission.
// zgyn	
// alxv	This software is provided by the copyright holders and contributors "as is" and
// weeb	any express or implied warranties, including, but not limited to, the implied
// riyw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bahq	In no event shall the Prince of Songkla University or contributors be liable 
// povt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xjgq	(including, but not limited to, procurement of substitute goods or services;
// zuiq	loss of use, data, or profits; or business interruption) however caused
// twrv	and on any theory of liability, whether in contract, strict liability,
// sylu	or tort (including negligence or otherwise) arising in any way out of
// bfsg	the use of this software, even if advised of the possibility of such damage.
// duis	
// iewl	Intelligent Systems Laboratory (iSys Lab)
// yoxk	Faculty of Engineering, Prince of Songkla University, THAILAND
// kepr	Project leader by Nikom SUVONVORN
// ehvb	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VsMediaProxyServerApplication
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
            Application.Run(new Form1());
        }
    }
}
