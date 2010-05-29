// dtek	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nwpg	
// eqho	 By downloading, copying, installing or using the software you agree to this license.
// ynva	 If you do not agree to this license, do not download, install,
// ehvh	 copy or use the software.
// hgvz	
// ejlf	                          License Agreement
// sjhd	         For OpenVSS - Open Source Video Surveillance System
// hyoq	
// oqct	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// npdj	
// suhb	Third party copyrights are property of their respective owners.
// hydz	
// yacw	Redistribution and use in source and binary forms, with or without modification,
// xfge	are permitted provided that the following conditions are met:
// ljov	
// jdgz	  * Redistribution's of source code must retain the above copyright notice,
// yfmo	    this list of conditions and the following disclaimer.
// ects	
// dmgj	  * Redistribution's in binary form must reproduce the above copyright notice,
// cjyu	    this list of conditions and the following disclaimer in the documentation
// fieg	    and/or other materials provided with the distribution.
// vssj	
// kyhe	  * Neither the name of the copyright holders nor the names of its contributors 
// bhao	    may not be used to endorse or promote products derived from this software 
// nhcc	    without specific prior written permission.
// lpuw	
// gksl	This software is provided by the copyright holders and contributors "as is" and
// ywbb	any express or implied warranties, including, but not limited to, the implied
// ltqb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zaeg	In no event shall the Prince of Songkla University or contributors be liable 
// mddg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// upqw	(including, but not limited to, procurement of substitute goods or services;
// lswv	loss of use, data, or profits; or business interruption) however caused
// hwip	and on any theory of liability, whether in contract, strict liability,
// nial	or tort (including negligence or otherwise) arising in any way out of
// zgkn	the use of this software, even if advised of the possibility of such damage.
// wgsi	
// rzpn	Intelligent Systems Laboratory (iSys Lab)
// dvpi	Faculty of Engineering, Prince of Songkla University, THAILAND
// mncq	Project leader by Nikom SUVONVORN
// uwzf	Project website at http://code.google.com/p/openvss/

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            VsSplasher.Show(typeof(VsSplasherView));
            Application.Run(new VsScanner());
        }
    }
}
