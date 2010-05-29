// vsqt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vzme	
// dxwh	 By downloading, copying, installing or using the software you agree to this license.
// tlmz	 If you do not agree to this license, do not download, install,
// hrtr	 copy or use the software.
// gvzb	
// zxpw	                          License Agreement
// ylri	         For OpenVSS - Open Source Video Surveillance System
// lgpa	
// cclz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// irms	
// eshw	Third party copyrights are property of their respective owners.
// eubd	
// uziz	Redistribution and use in source and binary forms, with or without modification,
// spux	are permitted provided that the following conditions are met:
// kpfs	
// fnwm	  * Redistribution's of source code must retain the above copyright notice,
// vmxf	    this list of conditions and the following disclaimer.
// ftjo	
// ihwg	  * Redistribution's in binary form must reproduce the above copyright notice,
// pssd	    this list of conditions and the following disclaimer in the documentation
// jonm	    and/or other materials provided with the distribution.
// xphm	
// hnps	  * Neither the name of the copyright holders nor the names of its contributors 
// mumr	    may not be used to endorse or promote products derived from this software 
// vvbr	    without specific prior written permission.
// xwxb	
// purl	This software is provided by the copyright holders and contributors "as is" and
// snir	any express or implied warranties, including, but not limited to, the implied
// wbir	warranties of merchantability and fitness for a particular purpose are disclaimed.
// akpf	In no event shall the Prince of Songkla University or contributors be liable 
// ekxs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ercn	(including, but not limited to, procurement of substitute goods or services;
// vfku	loss of use, data, or profits; or business interruption) however caused
// ragn	and on any theory of liability, whether in contract, strict liability,
// rmwd	or tort (including negligence or otherwise) arising in any way out of
// ywtu	the use of this software, even if advised of the possibility of such damage.
// fxvk	
// muql	Intelligent Systems Laboratory (iSys Lab)
// fvnm	Faculty of Engineering, Prince of Songkla University, THAILAND
// yexy	Project leader by Nikom SUVONVORN
// reqn	Project website at http://code.google.com/p/openvss/

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
