// yuxj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lrxz	
// kjho	 By downloading, copying, installing or using the software you agree to this license.
// uidr	 If you do not agree to this license, do not download, install,
// zbgr	 copy or use the software.
// glwy	
// oiix	                          License Agreement
// cmtl	         For OpenVss - Open Source Video Surveillance System
// otjh	
// hywg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// fkko	
// rpxe	Third party copyrights are property of their respective owners.
// lmrm	
// onxm	Redistribution and use in source and binary forms, with or without modification,
// xzvc	are permitted provided that the following conditions are met:
// izwx	
// pwzb	  * Redistribution's of source code must retain the above copyright notice,
// yvka	    this list of conditions and the following disclaimer.
// ezmw	
// bhgy	  * Redistribution's in binary form must reproduce the above copyright notice,
// lemq	    this list of conditions and the following disclaimer in the documentation
// uhwa	    and/or other materials provided with the distribution.
// wxji	
// dtxf	  * Neither the name of the copyright holders nor the names of its contributors 
// nmzv	    may not be used to endorse or promote products derived from this software 
// qwgp	    without specific prior written permission.
// bqio	
// balq	This software is provided by the copyright holders and contributors "as is" and
// sxre	any express or implied warranties, including, but not limited to, the implied
// ngdi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zyfb	In no event shall the Prince of Songkla University or contributors be liable 
// lcxk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bgio	(including, but not limited to, procurement of substitute goods or services;
// ilhp	loss of use, data, or profits; or business interruption) however caused
// xwoe	and on any theory of liability, whether in contract, strict liability,
// yhzv	or tort (including negligence or otherwise) arising in any way out of
// mtpg	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace VsSetup
{
    public partial class WMEncodeSetup : UserControl
    {
        VsInstallControl control;

        public WMEncodeSetup(VsInstallControl control)
        {
            this.control = control;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmd = "Componets\\WMEncoder.exe ";
            control.runFileExe(cmd,"",false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.nextState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.exitSetup(State.windowEndcode);
        }
    }
}
