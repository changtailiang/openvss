// pnux	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// deai	
// zovh	 By downloading, copying, installing or using the software you agree to this license.
// zuod	 If you do not agree to this license, do not download, install,
// qyjw	 copy or use the software.
// iobl	
// fyde	                          License Agreement
// lzai	         For OpenVSS - Open Source Video Surveillance System
// komf	
// lzsk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nbtl	
// twms	Third party copyrights are property of their respective owners.
// crff	
// zdrb	Redistribution and use in source and binary forms, with or without modification,
// misf	are permitted provided that the following conditions are met:
// avxz	
// nmwk	  * Redistribution's of source code must retain the above copyright notice,
// hisq	    this list of conditions and the following disclaimer.
// gyjg	
// uqsi	  * Redistribution's in binary form must reproduce the above copyright notice,
// mlct	    this list of conditions and the following disclaimer in the documentation
// uujh	    and/or other materials provided with the distribution.
// wltc	
// hmjr	  * Neither the name of the copyright holders nor the names of its contributors 
// euxh	    may not be used to endorse or promote products derived from this software 
// zbkt	    without specific prior written permission.
// zoza	
// ukhv	This software is provided by the copyright holders and contributors "as is" and
// qktp	any express or implied warranties, including, but not limited to, the implied
// sdft	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dpow	In no event shall the Prince of Songkla University or contributors be liable 
// ppjt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// prca	(including, but not limited to, procurement of substitute goods or services;
// tlik	loss of use, data, or profits; or business interruption) however caused
// aiuf	and on any theory of liability, whether in contract, strict liability,
// viml	or tort (including negligence or otherwise) arising in any way out of
// exmw	the use of this software, even if advised of the possibility of such damage.
// ttya	
// pdek	Intelligent Systems Laboratory (iSys Lab)
// noek	Faculty of Engineering, Prince of Songkla University, THAILAND
// fglc	Project leader by Nikom SUVONVORN
// hgcf	Project website at http://code.google.com/p/openvss/

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
            Application.Run(new VsPersonal());
        }
    }
}
