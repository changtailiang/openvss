// dfgx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ceic	
// swgc	 By downloading, copying, installing or using the software you agree to this license.
// zdsl	 If you do not agree to this license, do not download, install,
// ptpu	 copy or use the software.
// wqsx	
// erdx	                          License Agreement
// rosx	         For OpenVSS - Open Source Video Surveillance System
// qqbq	
// bxkr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fqej	
// fnkb	Third party copyrights are property of their respective owners.
// ljnf	
// jtvm	Redistribution and use in source and binary forms, with or without modification,
// njtk	are permitted provided that the following conditions are met:
// bkkd	
// djmj	  * Redistribution's of source code must retain the above copyright notice,
// cbkr	    this list of conditions and the following disclaimer.
// jyof	
// mirq	  * Redistribution's in binary form must reproduce the above copyright notice,
// hbmi	    this list of conditions and the following disclaimer in the documentation
// bnnw	    and/or other materials provided with the distribution.
// uodr	
// ezqv	  * Neither the name of the copyright holders nor the names of its contributors 
// gagv	    may not be used to endorse or promote products derived from this software 
// bazj	    without specific prior written permission.
// yvwl	
// eqaf	This software is provided by the copyright holders and contributors "as is" and
// rcdz	any express or implied warranties, including, but not limited to, the implied
// yccq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wppn	In no event shall the Prince of Songkla University or contributors be liable 
// ytnj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// htzl	(including, but not limited to, procurement of substitute goods or services;
// cwpg	loss of use, data, or profits; or business interruption) however caused
// bcjf	and on any theory of liability, whether in contract, strict liability,
// qcsd	or tort (including negligence or otherwise) arising in any way out of
// oxzb	the use of this software, even if advised of the possibility of such damage.
// wqwd	
// ypzl	Intelligent Systems Laboratory (iSys Lab)
// lllf	Faculty of Engineering, Prince of Songkla University, THAILAND
// indk	Project leader by Nikom SUVONVORN
// qodv	Project website at http://code.google.com/p/openvss/

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
        private VsLive vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsSettingTool()
        {
            InitializeComponent();
        }

        public VsLive Monitor
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
