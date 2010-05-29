// omwl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zuuk	
// cbpe	 By downloading, copying, installing or using the software you agree to this license.
// imer	 If you do not agree to this license, do not download, install,
// amop	 copy or use the software.
// vjdg	
// sfpv	                          License Agreement
// oeij	         For OpenVSS - Open Source Video Surveillance System
// ceru	
// cpbc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ponw	
// helh	Third party copyrights are property of their respective owners.
// jtbw	
// buef	Redistribution and use in source and binary forms, with or without modification,
// jptt	are permitted provided that the following conditions are met:
// fyvx	
// sgbd	  * Redistribution's of source code must retain the above copyright notice,
// vjok	    this list of conditions and the following disclaimer.
// lmzh	
// wgzn	  * Redistribution's in binary form must reproduce the above copyright notice,
// thlv	    this list of conditions and the following disclaimer in the documentation
// dmii	    and/or other materials provided with the distribution.
// alln	
// whxq	  * Neither the name of the copyright holders nor the names of its contributors 
// tpdb	    may not be used to endorse or promote products derived from this software 
// cilz	    without specific prior written permission.
// fqlp	
// uxjd	This software is provided by the copyright holders and contributors "as is" and
// pfax	any express or implied warranties, including, but not limited to, the implied
// matg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xtdk	In no event shall the Prince of Songkla University or contributors be liable 
// ybod	for any direct, indirect, incidental, special, exemplary, or consequential damages
// piog	(including, but not limited to, procurement of substitute goods or services;
// cyll	loss of use, data, or profits; or business interruption) however caused
// wmqn	and on any theory of liability, whether in contract, strict liability,
// btnc	or tort (including negligence or otherwise) arising in any way out of
// chxq	the use of this software, even if advised of the possibility of such damage.
// hzds	
// vxdi	Intelligent Systems Laboratory (iSys Lab)
// ebbd	Faculty of Engineering, Prince of Songkla University, THAILAND
// bhal	Project leader by Nikom SUVONVORN
// jdbr	Project website at http://code.google.com/p/openvss/

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
        private VsMonitor vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsSettingTool()
        {
            InitializeComponent();
        }

        public VsMonitor Monitor
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
