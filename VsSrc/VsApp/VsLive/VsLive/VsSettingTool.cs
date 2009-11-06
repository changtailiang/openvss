// govl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bkge	
// syud	 By downloading, copying, installing or using the software you agree to this license.
// cphw	 If you do not agree to this license, do not download, install,
// txwg	 copy or use the software.
// qkaw	
// gznj	                          License Agreement
// zmmf	         For OpenVss - Open Source Video Surveillance System
// ianh	
// tbfo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// auku	
// bvhz	Third party copyrights are property of their respective owners.
// wwlr	
// eokv	Redistribution and use in source and binary forms, with or without modification,
// oyec	are permitted provided that the following conditions are met:
// xweg	
// lovc	  * Redistribution's of source code must retain the above copyright notice,
// czds	    this list of conditions and the following disclaimer.
// sifv	
// afvl	  * Redistribution's in binary form must reproduce the above copyright notice,
// rnnc	    this list of conditions and the following disclaimer in the documentation
// aubt	    and/or other materials provided with the distribution.
// qrsu	
// wdqd	  * Neither the name of the copyright holders nor the names of its contributors 
// qdim	    may not be used to endorse or promote products derived from this software 
// zfxx	    without specific prior written permission.
// ttzw	
// iovi	This software is provided by the copyright holders and contributors "as is" and
// dskj	any express or implied warranties, including, but not limited to, the implied
// jbgq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ncmk	In no event shall the Prince of Songkla University or contributors be liable 
// givp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rcfw	(including, but not limited to, procurement of substitute goods or services;
// wimm	loss of use, data, or profits; or business interruption) however caused
// qqjg	and on any theory of liability, whether in contract, strict liability,
// vekb	or tort (including negligence or otherwise) arising in any way out of
// wkrd	the use of this software, even if advised of the possibility of such damage.

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
