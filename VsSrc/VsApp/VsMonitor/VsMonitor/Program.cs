// btpw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// giqu	
// fofg	 By downloading, copying, installing or using the software you agree to this license.
// uaxo	 If you do not agree to this license, do not download, install,
// fsww	 copy or use the software.
// soeb	
// snwh	                          License Agreement
// vreg	         For OpenVSS - Open Source Video Surveillance System
// mayk	
// njxw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// rqfb	
// jfdi	Third party copyrights are property of their respective owners.
// mjis	
// xifn	Redistribution and use in source and binary forms, with or without modification,
// onet	are permitted provided that the following conditions are met:
// ljzn	
// kztu	  * Redistribution's of source code must retain the above copyright notice,
// cmaw	    this list of conditions and the following disclaimer.
// uzfb	
// idsm	  * Redistribution's in binary form must reproduce the above copyright notice,
// joum	    this list of conditions and the following disclaimer in the documentation
// jmje	    and/or other materials provided with the distribution.
// ukwa	
// feli	  * Neither the name of the copyright holders nor the names of its contributors 
// rsrj	    may not be used to endorse or promote products derived from this software 
// miga	    without specific prior written permission.
// imxx	
// deel	This software is provided by the copyright holders and contributors "as is" and
// vsjx	any express or implied warranties, including, but not limited to, the implied
// omey	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qpar	In no event shall the Prince of Songkla University or contributors be liable 
// paqq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// owjq	(including, but not limited to, procurement of substitute goods or services;
// miab	loss of use, data, or profits; or business interruption) however caused
// hudw	and on any theory of liability, whether in contract, strict liability,
// olaq	or tort (including negligence or otherwise) arising in any way out of
// glen	the use of this software, even if advised of the possibility of such damage.
// untf	
// ottw	Intelligent Systems Laboratory (iSys Lab)
// hoki	Faculty of Engineering, Prince of Songkla University, THAILAND
// vhig	Project leader by Nikom SUVONVORN
// uoyn	Project website at http://code.google.com/p/openvss/

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
