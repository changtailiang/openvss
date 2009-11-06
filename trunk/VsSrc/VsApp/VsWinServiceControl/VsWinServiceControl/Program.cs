// rgik	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yfmw	
// ibyp	 By downloading, copying, installing or using the software you agree to this license.
// klpu	 If you do not agree to this license, do not download, install,
// jqau	 copy or use the software.
// hlqx	
// ggse	                          License Agreement
// xzif	         For OpenVss - Open Source Video Surveillance System
// dcau	
// iupf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// efab	
// ykld	Third party copyrights are property of their respective owners.
// bwvy	
// wqkf	Redistribution and use in source and binary forms, with or without modification,
// qkdr	are permitted provided that the following conditions are met:
// nizj	
// stmh	  * Redistribution's of source code must retain the above copyright notice,
// kump	    this list of conditions and the following disclaimer.
// avqc	
// loyv	  * Redistribution's in binary form must reproduce the above copyright notice,
// uoca	    this list of conditions and the following disclaimer in the documentation
// djin	    and/or other materials provided with the distribution.
// svex	
// qysv	  * Neither the name of the copyright holders nor the names of its contributors 
// gqjf	    may not be used to endorse or promote products derived from this software 
// ydth	    without specific prior written permission.
// kfxb	
// zhub	This software is provided by the copyright holders and contributors "as is" and
// liwy	any express or implied warranties, including, but not limited to, the implied
// gzfi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kzpo	In no event shall the Prince of Songkla University or contributors be liable 
// qozc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cvwu	(including, but not limited to, procurement of substitute goods or services;
// ftwr	loss of use, data, or profits; or business interruption) however caused
// vupx	and on any theory of liability, whether in contract, strict liability,
// lhnk	or tort (including negligence or otherwise) arising in any way out of
// bcmh	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace VsWinServiceControl
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
            Application.Run(new VsWinserviceControl());
        }
    }
}
