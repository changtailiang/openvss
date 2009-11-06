// zbvx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pkss	
// obnq	 By downloading, copying, installing or using the software you agree to this license.
// djwt	 If you do not agree to this license, do not download, install,
// vdxb	 copy or use the software.
// uhyn	
// lrtn	                          License Agreement
// svus	         For OpenVss - Open Source Video Surveillance System
// joqp	
// ozmz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hkis	
// ggtg	Third party copyrights are property of their respective owners.
// wade	
// axus	Redistribution and use in source and binary forms, with or without modification,
// dhmx	are permitted provided that the following conditions are met:
// rfzs	
// gvgp	  * Redistribution's of source code must retain the above copyright notice,
// shew	    this list of conditions and the following disclaimer.
// rxtj	
// yghe	  * Redistribution's in binary form must reproduce the above copyright notice,
// ynqs	    this list of conditions and the following disclaimer in the documentation
// sqrm	    and/or other materials provided with the distribution.
// tymh	
// mohb	  * Neither the name of the copyright holders nor the names of its contributors 
// lpll	    may not be used to endorse or promote products derived from this software 
// zdno	    without specific prior written permission.
// vgnc	
// dkuw	This software is provided by the copyright holders and contributors "as is" and
// zize	any express or implied warranties, including, but not limited to, the implied
// ohaq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// duvu	In no event shall the Prince of Songkla University or contributors be liable 
// vxkd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// psyi	(including, but not limited to, procurement of substitute goods or services;
// vwfu	loss of use, data, or profits; or business interruption) however caused
// zcxl	and on any theory of liability, whether in contract, strict liability,
// doii	or tort (including negligence or otherwise) arising in any way out of
// dphe	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vs.Playback
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

            VsSplasher.Show(typeof(VsLogin));
            Application.Run(new VsClient());
        }
    }
}
