// ubqu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zwmn	
// bioz	 By downloading, copying, installing or using the software you agree to this license.
// kofq	 If you do not agree to this license, do not download, install,
// qnhk	 copy or use the software.
// dzea	
// tqyk	                          License Agreement
// pmma	         For OpenVss - Open Source Video Surveillance System
// zfwm	
// eqnz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dzmd	
// bghj	Third party copyrights are property of their respective owners.
// dypv	
// pblu	Redistribution and use in source and binary forms, with or without modification,
// xqai	are permitted provided that the following conditions are met:
// xbyo	
// vozf	  * Redistribution's of source code must retain the above copyright notice,
// stla	    this list of conditions and the following disclaimer.
// zhhd	
// maym	  * Redistribution's in binary form must reproduce the above copyright notice,
// jpgr	    this list of conditions and the following disclaimer in the documentation
// wrky	    and/or other materials provided with the distribution.
// ubon	
// pfbb	  * Neither the name of the copyright holders nor the names of its contributors 
// bxhn	    may not be used to endorse or promote products derived from this software 
// hcrk	    without specific prior written permission.
// mpvh	
// uiiw	This software is provided by the copyright holders and contributors "as is" and
// sozi	any express or implied warranties, including, but not limited to, the implied
// vgse	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dblr	In no event shall the Prince of Songkla University or contributors be liable 
// exku	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ffbp	(including, but not limited to, procurement of substitute goods or services;
// sleg	loss of use, data, or profits; or business interruption) however caused
// xweh	and on any theory of liability, whether in contract, strict liability,
// vddl	or tort (including negligence or otherwise) arising in any way out of
// tsva	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace VsSetup
{
    public partial class Start : UserControl
    {
        private VsInstallControl control;
        public Start(VsInstallControl control)
        {
            this.control = control;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.nextState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.exitSetup(State.start);
        }
    }
}
