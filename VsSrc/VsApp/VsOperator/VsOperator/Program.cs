// cnkx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cmyf	
// pdvx	 By downloading, copying, installing or using the software you agree to this license.
// ibbj	 If you do not agree to this license, do not download, install,
// qdsj	 copy or use the software.
// hafp	
// pcvm	                          License Agreement
// kuea	         For OpenVss - Open Source Video Surveillance System
// qrik	
// nmhk	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vvdk	
// unsn	Third party copyrights are property of their respective owners.
// tvro	
// qdhc	Redistribution and use in source and binary forms, with or without modification,
// huha	are permitted provided that the following conditions are met:
// rmvu	
// yugr	  * Redistribution's of source code must retain the above copyright notice,
// srwe	    this list of conditions and the following disclaimer.
// vhom	
// xvvc	  * Redistribution's in binary form must reproduce the above copyright notice,
// jhso	    this list of conditions and the following disclaimer in the documentation
// cqkm	    and/or other materials provided with the distribution.
// jgcs	
// ehti	  * Neither the name of the copyright holders nor the names of its contributors 
// zimz	    may not be used to endorse or promote products derived from this software 
// hauc	    without specific prior written permission.
// znti	
// puem	This software is provided by the copyright holders and contributors "as is" and
// zfqj	any express or implied warranties, including, but not limited to, the implied
// ugri	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ktim	In no event shall the Prince of Songkla University or contributors be liable 
// odzn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ngmo	(including, but not limited to, procurement of substitute goods or services;
// ivvj	loss of use, data, or profits; or business interruption) however caused
// nqpp	and on any theory of liability, whether in contract, strict liability,
// wbxp	or tort (including negligence or otherwise) arising in any way out of
// bqtz	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VsOperator
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
            Application.Run(new Vs.Operator.VsOperator());
        }
    }
}
