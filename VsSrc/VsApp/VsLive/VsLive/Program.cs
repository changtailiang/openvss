// yzgh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ovcb	
// xfyg	 By downloading, copying, installing or using the software you agree to this license.
// ptqo	 If you do not agree to this license, do not download, install,
// fqzg	 copy or use the software.
// ammn	
// shqz	                          License Agreement
// chdi	         For OpenVss - Open Source Video Surveillance System
// gsao	
// ffnw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// juao	
// yqzy	Third party copyrights are property of their respective owners.
// zaxe	
// ejxm	Redistribution and use in source and binary forms, with or without modification,
// mspg	are permitted provided that the following conditions are met:
// edyq	
// cpax	  * Redistribution's of source code must retain the above copyright notice,
// sbiz	    this list of conditions and the following disclaimer.
// ccxg	
// lxpb	  * Redistribution's in binary form must reproduce the above copyright notice,
// irac	    this list of conditions and the following disclaimer in the documentation
// jyew	    and/or other materials provided with the distribution.
// vncn	
// qgrg	  * Neither the name of the copyright holders nor the names of its contributors 
// vkmj	    may not be used to endorse or promote products derived from this software 
// qbfx	    without specific prior written permission.
// rybb	
// mrap	This software is provided by the copyright holders and contributors "as is" and
// dnxm	any express or implied warranties, including, but not limited to, the implied
// dwgd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ldcf	In no event shall the Prince of Songkla University or contributors be liable 
// zvjw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lrkb	(including, but not limited to, procurement of substitute goods or services;
// kglh	loss of use, data, or profits; or business interruption) however caused
// mcll	and on any theory of liability, whether in contract, strict liability,
// xckd	or tort (including negligence or otherwise) arising in any way out of
// nmkc	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;

using System.Windows.Forms;
//using Vs.Core;

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
         
            Application.Run(new VsLive());
        }
    }
}
