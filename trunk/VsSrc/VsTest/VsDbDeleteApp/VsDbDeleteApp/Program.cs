// wlwn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hbps	
// ddni	 By downloading, copying, installing or using the software you agree to this license.
// lfru	 If you do not agree to this license, do not download, install,
// tpmt	 copy or use the software.
// cnai	
// kkql	                          License Agreement
// nmai	         For OpenVSS - Open Source Video Surveillance System
// euox	
// vmio	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gosr	
// fzmm	Third party copyrights are property of their respective owners.
// rpeq	
// ghtj	Redistribution and use in source and binary forms, with or without modification,
// lodx	are permitted provided that the following conditions are met:
// kdeq	
// deeq	  * Redistribution's of source code must retain the above copyright notice,
// quzh	    this list of conditions and the following disclaimer.
// hymo	
// uick	  * Redistribution's in binary form must reproduce the above copyright notice,
// xduy	    this list of conditions and the following disclaimer in the documentation
// ijbx	    and/or other materials provided with the distribution.
// afmh	
// jled	  * Neither the name of the copyright holders nor the names of its contributors 
// jcob	    may not be used to endorse or promote products derived from this software 
// vvvx	    without specific prior written permission.
// qxji	
// ueoc	This software is provided by the copyright holders and contributors "as is" and
// mszg	any express or implied warranties, including, but not limited to, the implied
// jght	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cgql	In no event shall the Prince of Songkla University or contributors be liable 
// hrxv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tjfs	(including, but not limited to, procurement of substitute goods or services;
// tapc	loss of use, data, or profits; or business interruption) however caused
// iwil	and on any theory of liability, whether in contract, strict liability,
// ztdv	or tort (including negligence or otherwise) arising in any way out of
// rjvr	the use of this software, even if advised of the possibility of such damage.
// lxtc	
// uuyo	Intelligent Systems Laboratory (iSys Lab)
// fkpy	Faculty of Engineering, Prince of Songkla University, THAILAND
// aook	Project leader by Nikom SUVONVORN
// zvil	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace VsDbDeleteApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //ErrorLogWriter Err = new ErrorLogWriter(System.IO.Directory.GetCurrentDirectory());
            //Console.SetError(Err);





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            Application.Run(new Form1());
 
        }
       
    }
}
