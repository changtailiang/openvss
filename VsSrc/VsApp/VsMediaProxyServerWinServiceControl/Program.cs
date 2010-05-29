// mkzz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// coam	
// lkov	 By downloading, copying, installing or using the software you agree to this license.
// ufye	 If you do not agree to this license, do not download, install,
// jkuj	 copy or use the software.
// dcsv	
// dtpn	                          License Agreement
// sntt	         For OpenVSS - Open Source Video Surveillance System
// aqzz	
// ncni	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dcle	
// xwgx	Third party copyrights are property of their respective owners.
// bgrt	
// mtrk	Redistribution and use in source and binary forms, with or without modification,
// revi	are permitted provided that the following conditions are met:
// zmuy	
// rvvd	  * Redistribution's of source code must retain the above copyright notice,
// gyqh	    this list of conditions and the following disclaimer.
// wmfb	
// roxh	  * Redistribution's in binary form must reproduce the above copyright notice,
// nrml	    this list of conditions and the following disclaimer in the documentation
// vzgg	    and/or other materials provided with the distribution.
// yphi	
// gfir	  * Neither the name of the copyright holders nor the names of its contributors 
// hnnc	    may not be used to endorse or promote products derived from this software 
// bcrc	    without specific prior written permission.
// qkwa	
// oqtd	This software is provided by the copyright holders and contributors "as is" and
// gouh	any express or implied warranties, including, but not limited to, the implied
// zjcr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// opeq	In no event shall the Prince of Songkla University or contributors be liable 
// rhar	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dotd	(including, but not limited to, procurement of substitute goods or services;
// avgk	loss of use, data, or profits; or business interruption) however caused
// akuk	and on any theory of liability, whether in contract, strict liability,
// dgsi	or tort (including negligence or otherwise) arising in any way out of
// wdcr	the use of this software, even if advised of the possibility of such damage.
// kbrx	
// kwnm	Intelligent Systems Laboratory (iSys Lab)
// yaki	Faculty of Engineering, Prince of Songkla University, THAILAND
// kfwz	Project leader by Nikom SUVONVORN
// xpcl	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VsMediaProxyServerWinServiceControl
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
            Application.Run(new VsMediaProxyServerWinServiceControl());
        }
    }
}
