// fmfa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gptn	
// fvwi	 By downloading, copying, installing or using the software you agree to this license.
// kflp	 If you do not agree to this license, do not download, install,
// ypkv	 copy or use the software.
// oaym	
// syst	                          License Agreement
// maqq	         For OpenVss - Open Source Video Surveillance System
// rcvi	
// encx	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rktt	
// wmqd	Third party copyrights are property of their respective owners.
// iagv	
// rqxf	Redistribution and use in source and binary forms, with or without modification,
// otii	are permitted provided that the following conditions are met:
// wzae	
// efrh	  * Redistribution's of source code must retain the above copyright notice,
// jdll	    this list of conditions and the following disclaimer.
// nnee	
// hfpf	  * Redistribution's in binary form must reproduce the above copyright notice,
// hpkl	    this list of conditions and the following disclaimer in the documentation
// uvza	    and/or other materials provided with the distribution.
// eqtk	
// fuar	  * Neither the name of the copyright holders nor the names of its contributors 
// jpoq	    may not be used to endorse or promote products derived from this software 
// vitf	    without specific prior written permission.
// ovie	
// ltxi	This software is provided by the copyright holders and contributors "as is" and
// ddah	any express or implied warranties, including, but not limited to, the implied
// ppjj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gqct	In no event shall the Prince of Songkla University or contributors be liable 
// jbgs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mnus	(including, but not limited to, procurement of substitute goods or services;
// qyky	loss of use, data, or profits; or business interruption) however caused
// vfwz	and on any theory of liability, whether in contract, strict liability,
// nvpl	or tort (including negligence or otherwise) arising in any way out of
// slgb	the use of this software, even if advised of the possibility of such damage.

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
