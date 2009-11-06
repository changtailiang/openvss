// sffu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lbuo	
// mdhe	 By downloading, copying, installing or using the software you agree to this license.
// geln	 If you do not agree to this license, do not download, install,
// nxtt	 copy or use the software.
// iosv	
// mrwt	                          License Agreement
// xsxi	         For OpenVss - Open Source Video Surveillance System
// cvhf	
// cgdd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xacx	
// tuov	Third party copyrights are property of their respective owners.
// owpb	
// rped	Redistribution and use in source and binary forms, with or without modification,
// njhu	are permitted provided that the following conditions are met:
// faru	
// gybk	  * Redistribution's of source code must retain the above copyright notice,
// xglg	    this list of conditions and the following disclaimer.
// tqvh	
// lvbs	  * Redistribution's in binary form must reproduce the above copyright notice,
// cafa	    this list of conditions and the following disclaimer in the documentation
// dwrn	    and/or other materials provided with the distribution.
// rdss	
// yjxw	  * Neither the name of the copyright holders nor the names of its contributors 
// iiqu	    may not be used to endorse or promote products derived from this software 
// seyh	    without specific prior written permission.
// kihb	
// twss	This software is provided by the copyright holders and contributors "as is" and
// iprf	any express or implied warranties, including, but not limited to, the implied
// vqrj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gosu	In no event shall the Prince of Songkla University or contributors be liable 
// nsij	for any direct, indirect, incidental, special, exemplary, or consequential damages
// syyc	(including, but not limited to, procurement of substitute goods or services;
// egzx	loss of use, data, or profits; or business interruption) however caused
// bxpu	and on any theory of liability, whether in contract, strict liability,
// oqtv	or tort (including negligence or otherwise) arising in any way out of
// laki	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vs.Client
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
            Application.Run(new frmMain());
        }
    }
}
