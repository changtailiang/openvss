// ldol	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rjmh	
// oplk	 By downloading, copying, installing or using the software you agree to this license.
// mfua	 If you do not agree to this license, do not download, install,
// nsel	 copy or use the software.
// layu	
// yayq	                          License Agreement
// vbmt	         For OpenVSS - Open Source Video Surveillance System
// nwdx	
// ipiq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kmrq	
// ekkq	Third party copyrights are property of their respective owners.
// gmzm	
// lnzl	Redistribution and use in source and binary forms, with or without modification,
// fumr	are permitted provided that the following conditions are met:
// kwln	
// dsxq	  * Redistribution's of source code must retain the above copyright notice,
// cwry	    this list of conditions and the following disclaimer.
// jnay	
// ihpo	  * Redistribution's in binary form must reproduce the above copyright notice,
// pijj	    this list of conditions and the following disclaimer in the documentation
// bahz	    and/or other materials provided with the distribution.
// wsro	
// crgo	  * Neither the name of the copyright holders nor the names of its contributors 
// aemm	    may not be used to endorse or promote products derived from this software 
// muok	    without specific prior written permission.
// vbcx	
// nacx	This software is provided by the copyright holders and contributors "as is" and
// fybc	any express or implied warranties, including, but not limited to, the implied
// ncld	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kytk	In no event shall the Prince of Songkla University or contributors be liable 
// fdvs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hmye	(including, but not limited to, procurement of substitute goods or services;
// vdbv	loss of use, data, or profits; or business interruption) however caused
// uzoa	and on any theory of liability, whether in contract, strict liability,
// xklv	or tort (including negligence or otherwise) arising in any way out of
// ptie	the use of this software, even if advised of the possibility of such damage.
// qeay	
// tibo	Intelligent Systems Laboratory (iSys Lab)
// ader	Faculty of Engineering, Prince of Songkla University, THAILAND
// fjqb	Project leader by Nikom SUVONVORN
// cycb	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace Vs.Core.MediaProxyServer
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
