// fnsi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rvlu	
// vdht	 By downloading, copying, installing or using the software you agree to this license.
// vpnf	 If you do not agree to this license, do not download, install,
// vrft	 copy or use the software.
// hsye	
// tkhg	                          License Agreement
// erka	         For OpenVSS - Open Source Video Surveillance System
// okqi	
// nfqe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gmcl	
// shpt	Third party copyrights are property of their respective owners.
// zxcd	
// ewln	Redistribution and use in source and binary forms, with or without modification,
// onoh	are permitted provided that the following conditions are met:
// nfqe	
// tgek	  * Redistribution's of source code must retain the above copyright notice,
// yerq	    this list of conditions and the following disclaimer.
// abnv	
// qmlm	  * Redistribution's in binary form must reproduce the above copyright notice,
// ungh	    this list of conditions and the following disclaimer in the documentation
// ohws	    and/or other materials provided with the distribution.
// ydtz	
// qjqa	  * Neither the name of the copyright holders nor the names of its contributors 
// vxsm	    may not be used to endorse or promote products derived from this software 
// dfuv	    without specific prior written permission.
// flcc	
// jqwc	This software is provided by the copyright holders and contributors "as is" and
// bcnz	any express or implied warranties, including, but not limited to, the implied
// yipm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jmlv	In no event shall the Prince of Songkla University or contributors be liable 
// kszr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kmzs	(including, but not limited to, procurement of substitute goods or services;
// uzio	loss of use, data, or profits; or business interruption) however caused
// slcd	and on any theory of liability, whether in contract, strict liability,
// etii	or tort (including negligence or otherwise) arising in any way out of
// gryo	the use of this software, even if advised of the possibility of such damage.
// wrbn	
// hfcr	Intelligent Systems Laboratory (iSys Lab)
// uzkn	Faculty of Engineering, Prince of Songkla University, THAILAND
// mlsx	Project leader by Nikom SUVONVORN
// reic	Project website at http://code.google.com/p/openvss/

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
    public partial class VsGeneralSetting : UserControl
    {
        private VsLiveviewTool vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsGeneralSetting()
        {
            InitializeComponent();
            this.Load += new EventHandler(VsGeneralSetting_Load);
        }

        void VsGeneralSetting_Load(object sender, EventArgs e)
        {
        }

        public VsLiveviewTool Monitor
        {
            set { vsMonitor = value; }
        }

        public VsCoreServer CoreMonitor
        {
            set
            {
                vsCoreMonitor = value;
                this.SmtpHost.Text = vsCoreMonitor.SmtpHost;
                this.SmtpUser.Text = vsCoreMonitor.SmtpUser;
                this.SmtpPasswd.Text = vsCoreMonitor.SmtpPasswd;
                this.EmailFrom.Text = vsCoreMonitor.EmailFrom;
                this.EmailTo.Text = vsCoreMonitor.EmailTo;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            vsCoreMonitor.SmtpHost = this.SmtpHost.Text;
            vsCoreMonitor.SmtpUser = this.SmtpUser.Text;
            vsCoreMonitor.SmtpPasswd = this.SmtpPasswd.Text;
            vsCoreMonitor.EmailFrom = this.EmailFrom.Text;
            vsCoreMonitor.EmailTo = this.EmailTo.Text;
        }
    }
}
