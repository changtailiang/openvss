// wlsa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// molv	
// fifd	 By downloading, copying, installing or using the software you agree to this license.
// rczb	 If you do not agree to this license, do not download, install,
// oagm	 copy or use the software.
// uaoa	
// jtpx	                          License Agreement
// nnwv	         For OpenVSS - Open Source Video Surveillance System
// orgm	
// gbjc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eeii	
// wyjm	Third party copyrights are property of their respective owners.
// mjnr	
// jpuv	Redistribution and use in source and binary forms, with or without modification,
// xsqt	are permitted provided that the following conditions are met:
// znir	
// mjpa	  * Redistribution's of source code must retain the above copyright notice,
// vnvn	    this list of conditions and the following disclaimer.
// rehq	
// sfdl	  * Redistribution's in binary form must reproduce the above copyright notice,
// kdle	    this list of conditions and the following disclaimer in the documentation
// zemz	    and/or other materials provided with the distribution.
// xlon	
// kqdq	  * Neither the name of the copyright holders nor the names of its contributors 
// vqwm	    may not be used to endorse or promote products derived from this software 
// ijqy	    without specific prior written permission.
// naaf	
// hedr	This software is provided by the copyright holders and contributors "as is" and
// ofiv	any express or implied warranties, including, but not limited to, the implied
// cesi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xpdj	In no event shall the Prince of Songkla University or contributors be liable 
// yhda	for any direct, indirect, incidental, special, exemplary, or consequential damages
// aqub	(including, but not limited to, procurement of substitute goods or services;
// jqcb	loss of use, data, or profits; or business interruption) however caused
// mmqz	and on any theory of liability, whether in contract, strict liability,
// dhst	or tort (including negligence or otherwise) arising in any way out of
// iwzf	the use of this software, even if advised of the possibility of such damage.
// hhor	
// yops	Intelligent Systems Laboratory (iSys Lab)
// fgaf	Faculty of Engineering, Prince of Songkla University, THAILAND
// xzeq	Project leader by Nikom SUVONVORN
// jbix	Project website at http://code.google.com/p/openvss/

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
