// efps	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nuca	
// bdwp	 By downloading, copying, installing or using the software you agree to this license.
// dkuz	 If you do not agree to this license, do not download, install,
// qhot	 copy or use the software.
// jrtr	
// qpiu	                          License Agreement
// eite	         For OpenVSS - Open Source Video Surveillance System
// zumm	
// ktal	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kjoc	
// eirs	Third party copyrights are property of their respective owners.
// qkef	
// mplm	Redistribution and use in source and binary forms, with or without modification,
// mybx	are permitted provided that the following conditions are met:
// lhws	
// ksqj	  * Redistribution's of source code must retain the above copyright notice,
// xhpx	    this list of conditions and the following disclaimer.
// gcia	
// drni	  * Redistribution's in binary form must reproduce the above copyright notice,
// xpdt	    this list of conditions and the following disclaimer in the documentation
// dnsk	    and/or other materials provided with the distribution.
// jzzm	
// rczc	  * Neither the name of the copyright holders nor the names of its contributors 
// mvrl	    may not be used to endorse or promote products derived from this software 
// siui	    without specific prior written permission.
// vhzj	
// hkiv	This software is provided by the copyright holders and contributors "as is" and
// ktaw	any express or implied warranties, including, but not limited to, the implied
// ecpx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// afax	In no event shall the Prince of Songkla University or contributors be liable 
// hcgd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dfni	(including, but not limited to, procurement of substitute goods or services;
// zcpp	loss of use, data, or profits; or business interruption) however caused
// uvxw	and on any theory of liability, whether in contract, strict liability,
// njcy	or tort (including negligence or otherwise) arising in any way out of
// qeby	the use of this software, even if advised of the possibility of such damage.
// cdyk	
// fulm	Intelligent Systems Laboratory (iSys Lab)
// hwat	Faculty of Engineering, Prince of Songkla University, THAILAND
// bwfb	Project leader by Nikom SUVONVORN
// wavi	Project website at http://code.google.com/p/openvss/

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
