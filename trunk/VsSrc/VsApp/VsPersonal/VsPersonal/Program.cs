// mpnr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// setb	
// qhwy	 By downloading, copying, installing or using the software you agree to this license.
// lhrs	 If you do not agree to this license, do not download, install,
// posb	 copy or use the software.
// nixm	
// cejl	                          License Agreement
// stez	         For OpenVss - Open Source Video Surveillance System
// lldf	
// dxtb	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ziyd	
// fjxe	Third party copyrights are property of their respective owners.
// yhze	
// yuqe	Redistribution and use in source and binary forms, with or without modification,
// sboo	are permitted provided that the following conditions are met:
// vijw	
// dxma	  * Redistribution's of source code must retain the above copyright notice,
// dmos	    this list of conditions and the following disclaimer.
// vqce	
// jugt	  * Redistribution's in binary form must reproduce the above copyright notice,
// gemk	    this list of conditions and the following disclaimer in the documentation
// tzar	    and/or other materials provided with the distribution.
// vync	
// ifgq	  * Neither the name of the copyright holders nor the names of its contributors 
// zbzi	    may not be used to endorse or promote products derived from this software 
// wxal	    without specific prior written permission.
// shjh	
// rlux	This software is provided by the copyright holders and contributors "as is" and
// uuiq	any express or implied warranties, including, but not limited to, the implied
// wzcd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wvef	In no event shall the Prince of Songkla University or contributors be liable 
// zmkq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kmfi	(including, but not limited to, procurement of substitute goods or services;
// uywi	loss of use, data, or profits; or business interruption) however caused
// earm	and on any theory of liability, whether in contract, strict liability,
// ptzj	or tort (including negligence or otherwise) arising in any way out of
// dpin	the use of this software, even if advised of the possibility of such damage.

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
