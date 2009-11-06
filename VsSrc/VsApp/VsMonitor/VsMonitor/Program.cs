// dtqt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// sdze	
// lrui	 By downloading, copying, installing or using the software you agree to this license.
// molm	 If you do not agree to this license, do not download, install,
// dshx	 copy or use the software.
// hoqp	
// vuwx	                          License Agreement
// jicx	         For OpenVss - Open Source Video Surveillance System
// mfcu	
// yruv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wewd	
// yxct	Third party copyrights are property of their respective owners.
// ojoc	
// yiqp	Redistribution and use in source and binary forms, with or without modification,
// cayy	are permitted provided that the following conditions are met:
// hcuc	
// owwh	  * Redistribution's of source code must retain the above copyright notice,
// mrol	    this list of conditions and the following disclaimer.
// ymac	
// rmry	  * Redistribution's in binary form must reproduce the above copyright notice,
// scia	    this list of conditions and the following disclaimer in the documentation
// taze	    and/or other materials provided with the distribution.
// pnsx	
// tvnu	  * Neither the name of the copyright holders nor the names of its contributors 
// jupb	    may not be used to endorse or promote products derived from this software 
// buhx	    without specific prior written permission.
// udem	
// hnxp	This software is provided by the copyright holders and contributors "as is" and
// jzfe	any express or implied warranties, including, but not limited to, the implied
// ttin	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xssy	In no event shall the Prince of Songkla University or contributors be liable 
// yqrc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ygtx	(including, but not limited to, procurement of substitute goods or services;
// xpwy	loss of use, data, or profits; or business interruption) however caused
// vkfq	and on any theory of liability, whether in contract, strict liability,
// wnwb	or tort (including negligence or otherwise) arising in any way out of
// qcnt	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Vs.Core;

namespace Vs.Monitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.IO.Directory.SetCurrentDirectory(
              System.IO.Path.GetDirectoryName(
              System.Reflection.Assembly.GetExecutingAssembly().Location));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            VsSplasher.Show(typeof(VsSplasherView));
            Application.Run(new VsMonitor());
        }
    }
}
