// xxks	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fbog	
// uhdg	 By downloading, copying, installing or using the software you agree to this license.
// ohem	 If you do not agree to this license, do not download, install,
// aqcn	 copy or use the software.
// pgun	
// bmzg	                          License Agreement
// beei	         For OpenVSS - Open Source Video Surveillance System
// kiay	
// dzoa	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jmyd	
// pwvk	Third party copyrights are property of their respective owners.
// aiwi	
// zrxq	Redistribution and use in source and binary forms, with or without modification,
// cxrs	are permitted provided that the following conditions are met:
// bheq	
// cvvg	  * Redistribution's of source code must retain the above copyright notice,
// gfjb	    this list of conditions and the following disclaimer.
// cced	
// iqye	  * Redistribution's in binary form must reproduce the above copyright notice,
// rpfs	    this list of conditions and the following disclaimer in the documentation
// hwjt	    and/or other materials provided with the distribution.
// kkvg	
// hwyb	  * Neither the name of the copyright holders nor the names of its contributors 
// hhbu	    may not be used to endorse or promote products derived from this software 
// apev	    without specific prior written permission.
// zvgx	
// nuhl	This software is provided by the copyright holders and contributors "as is" and
// znbm	any express or implied warranties, including, but not limited to, the implied
// blig	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mcvv	In no event shall the Prince of Songkla University or contributors be liable 
// jdug	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dcwa	(including, but not limited to, procurement of substitute goods or services;
// pddc	loss of use, data, or profits; or business interruption) however caused
// kktm	and on any theory of liability, whether in contract, strict liability,
// plgq	or tort (including negligence or otherwise) arising in any way out of
// cjhu	the use of this software, even if advised of the possibility of such damage.
// ulzv	
// zvhy	Intelligent Systems Laboratory (iSys Lab)
// timw	Faculty of Engineering, Prince of Songkla University, THAILAND
// batk	Project leader by Nikom SUVONVORN
// yhwv	Project website at http://code.google.com/p/openvss/

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
