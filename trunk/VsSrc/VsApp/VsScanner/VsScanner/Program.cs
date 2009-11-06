// poea	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yiay	
// aigv	 By downloading, copying, installing or using the software you agree to this license.
// ivim	 If you do not agree to this license, do not download, install,
// hjqn	 copy or use the software.
// ifkv	
// vdlh	                          License Agreement
// lyjp	         For OpenVss - Open Source Video Surveillance System
// sydr	
// awkd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ftmy	
// fakj	Third party copyrights are property of their respective owners.
// kuua	
// jwzk	Redistribution and use in source and binary forms, with or without modification,
// ejfv	are permitted provided that the following conditions are met:
// xtnc	
// zrcj	  * Redistribution's of source code must retain the above copyright notice,
// sqll	    this list of conditions and the following disclaimer.
// zmip	
// tlpu	  * Redistribution's in binary form must reproduce the above copyright notice,
// sbxq	    this list of conditions and the following disclaimer in the documentation
// difw	    and/or other materials provided with the distribution.
// ztnr	
// qogm	  * Neither the name of the copyright holders nor the names of its contributors 
// gjyo	    may not be used to endorse or promote products derived from this software 
// xbrt	    without specific prior written permission.
// iiaw	
// njqs	This software is provided by the copyright holders and contributors "as is" and
// tlcv	any express or implied warranties, including, but not limited to, the implied
// vwyq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lgjz	In no event shall the Prince of Songkla University or contributors be liable 
// duvk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gvij	(including, but not limited to, procurement of substitute goods or services;
// mawq	loss of use, data, or profits; or business interruption) however caused
// jdhv	and on any theory of liability, whether in contract, strict liability,
// hjip	or tort (including negligence or otherwise) arising in any way out of
// cvxf	the use of this software, even if advised of the possibility of such damage.

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
