// fwcn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ryav	
// jyiv	 By downloading, copying, installing or using the software you agree to this license.
// stnl	 If you do not agree to this license, do not download, install,
// jqow	 copy or use the software.
// crqf	
// yorl	                          License Agreement
// zwjd	         For OpenVss - Open Source Video Surveillance System
// ymss	
// nxnm	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// anby	
// esxv	Third party copyrights are property of their respective owners.
// kbve	
// ppfo	Redistribution and use in source and binary forms, with or without modification,
// gwpc	are permitted provided that the following conditions are met:
// gpwm	
// pfxg	  * Redistribution's of source code must retain the above copyright notice,
// auyl	    this list of conditions and the following disclaimer.
// ccwp	
// qsbf	  * Redistribution's in binary form must reproduce the above copyright notice,
// rwax	    this list of conditions and the following disclaimer in the documentation
// bfnj	    and/or other materials provided with the distribution.
// gemq	
// ikfk	  * Neither the name of the copyright holders nor the names of its contributors 
// roiy	    may not be used to endorse or promote products derived from this software 
// vrup	    without specific prior written permission.
// djbn	
// sqyo	This software is provided by the copyright holders and contributors "as is" and
// vklk	any express or implied warranties, including, but not limited to, the implied
// oylj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// snzw	In no event shall the Prince of Songkla University or contributors be liable 
// iids	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wlxb	(including, but not limited to, procurement of substitute goods or services;
// jcja	loss of use, data, or profits; or business interruption) however caused
// bktr	and on any theory of liability, whether in contract, strict liability,
// earq	or tort (including negligence or otherwise) arising in any way out of
// gxvy	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Server;

namespace Vs.Monitor
{
    public partial class VsSettingTool : UserControl
    {
        private VsScanner vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsSettingTool()
        {
            InitializeComponent();
        }

        public VsScanner Monitor
        {
            set
            {
                vsMonitor = value;
                // set reference to application control
                this.vsGeneralSetting1.Monitor = value;
                this.vsGeneralSetting1.CoreMonitor = vsCoreMonitor;

                // set reference to property control
                this.vsRecordSetting1.Monitor = value;
                this.vsRecordSetting1.CoreMonitor = vsCoreMonitor;
            }
        }

        public VsCoreServer CoreMonitor
        {
            set { vsCoreMonitor = value; }
        }

        private void buttonGeneral_Click(object sender, EventArgs e)
        {
            this.vsGeneralSetting1.Visible = true;
            this.vsRecordSetting1.Visible = false;
        }

        private void buttonRecording_Click(object sender, EventArgs e)
        {
            this.vsGeneralSetting1.Visible = false;
            this.vsRecordSetting1.Visible = true;
        }
    }
}
