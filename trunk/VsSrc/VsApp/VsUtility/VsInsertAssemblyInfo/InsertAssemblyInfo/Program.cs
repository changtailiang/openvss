// vlsu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uzem	
// vrjl	 By downloading, copying, installing or using the software you agree to this license.
// leqz	 If you do not agree to this license, do not download, install,
// rgju	 copy or use the software.
// zkic	
// pfph	                          License Agreement
// ttkp	         For OpenVss - Open Source Video Surveillance System
// nbsp	
// hpwv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// voyv	
// vwnh	Third party copyrights are property of their respective owners.
// qzxc	
// fook	Redistribution and use in source and binary forms, with or without modification,
// cpfp	are permitted provided that the following conditions are met:
// kwtb	
// gtxj	  * Redistribution's of source code must retain the above copyright notice,
// mbsc	    this list of conditions and the following disclaimer.
// jozl	
// lnht	  * Redistribution's in binary form must reproduce the above copyright notice,
// shqt	    this list of conditions and the following disclaimer in the documentation
// wiky	    and/or other materials provided with the distribution.
// mhnr	
// jgly	  * Neither the name of the copyright holders nor the names of its contributors 
// vwob	    may not be used to endorse or promote products derived from this software 
// ydvp	    without specific prior written permission.
// gusr	
// pcyo	This software is provided by the copyright holders and contributors "as is" and
// imxc	any express or implied warranties, including, but not limited to, the implied
// fzfy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jzwe	In no event shall the Prince of Songkla University or contributors be liable 
// nbsc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// caqp	(including, but not limited to, procurement of substitute goods or services;
// yfuo	loss of use, data, or profits; or business interruption) however caused
// mbmb	and on any theory of liability, whether in contract, strict liability,
// psjj	or tort (including negligence or otherwise) arising in any way out of
// iyix	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InsertAssemblyInfo
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
            Application.Run(new VsInseartAssemblyInfo());
        }
    }
}
