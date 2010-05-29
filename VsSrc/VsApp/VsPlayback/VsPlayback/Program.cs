// qxjr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cgba	
// sxwi	 By downloading, copying, installing or using the software you agree to this license.
// qtud	 If you do not agree to this license, do not download, install,
// bjdo	 copy or use the software.
// jzmd	
// csfm	                          License Agreement
// qbsf	         For OpenVSS - Open Source Video Surveillance System
// vgfv	
// exeh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tuga	
// arrp	Third party copyrights are property of their respective owners.
// uppe	
// dzpq	Redistribution and use in source and binary forms, with or without modification,
// lfpj	are permitted provided that the following conditions are met:
// aokr	
// eqmj	  * Redistribution's of source code must retain the above copyright notice,
// ozye	    this list of conditions and the following disclaimer.
// fvvo	
// sldl	  * Redistribution's in binary form must reproduce the above copyright notice,
// bqrb	    this list of conditions and the following disclaimer in the documentation
// locv	    and/or other materials provided with the distribution.
// qoky	
// huge	  * Neither the name of the copyright holders nor the names of its contributors 
// kpwk	    may not be used to endorse or promote products derived from this software 
// ehav	    without specific prior written permission.
// qlzh	
// ebyz	This software is provided by the copyright holders and contributors "as is" and
// ceik	any express or implied warranties, including, but not limited to, the implied
// xifp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nrsa	In no event shall the Prince of Songkla University or contributors be liable 
// pzwk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oqdd	(including, but not limited to, procurement of substitute goods or services;
// ptgt	loss of use, data, or profits; or business interruption) however caused
// pwka	and on any theory of liability, whether in contract, strict liability,
// pvqp	or tort (including negligence or otherwise) arising in any way out of
// pkwd	the use of this software, even if advised of the possibility of such damage.
// lwgc	
// jgwn	Intelligent Systems Laboratory (iSys Lab)
// oagq	Faculty of Engineering, Prince of Songkla University, THAILAND
// oosn	Project leader by Nikom SUVONVORN
// xvki	Project website at http://code.google.com/p/openvss/

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
            Application.Run(new VsPlayback());
            //Application.Run(new test());
        }
    }
}
