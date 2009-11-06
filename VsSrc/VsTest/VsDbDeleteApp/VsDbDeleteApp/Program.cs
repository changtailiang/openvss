// cvie	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vuur	
// pcgy	 By downloading, copying, installing or using the software you agree to this license.
// jdwv	 If you do not agree to this license, do not download, install,
// ozts	 copy or use the software.
// xozd	
// dsge	                          License Agreement
// tcoi	         For OpenVss - Open Source Video Surveillance System
// qcxf	
// spvx	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// spxy	
// dmkc	Third party copyrights are property of their respective owners.
// apme	
// hcnn	Redistribution and use in source and binary forms, with or without modification,
// wfac	are permitted provided that the following conditions are met:
// oqyn	
// nxhh	  * Redistribution's of source code must retain the above copyright notice,
// grcz	    this list of conditions and the following disclaimer.
// dvzi	
// rbzr	  * Redistribution's in binary form must reproduce the above copyright notice,
// idde	    this list of conditions and the following disclaimer in the documentation
// qkbo	    and/or other materials provided with the distribution.
// ojin	
// osjc	  * Neither the name of the copyright holders nor the names of its contributors 
// qjkg	    may not be used to endorse or promote products derived from this software 
// edwj	    without specific prior written permission.
// mmbm	
// cfwv	This software is provided by the copyright holders and contributors "as is" and
// fjuk	any express or implied warranties, including, but not limited to, the implied
// mtxd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vtsw	In no event shall the Prince of Songkla University or contributors be liable 
// ipkk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lxrh	(including, but not limited to, procurement of substitute goods or services;
// qtme	loss of use, data, or profits; or business interruption) however caused
// hurd	and on any theory of liability, whether in contract, strict liability,
// jpli	or tort (including negligence or otherwise) arising in any way out of
// nnhf	the use of this software, even if advised of the possibility of such damage.

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
