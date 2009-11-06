// xnes	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vcgn	
// yidd	 By downloading, copying, installing or using the software you agree to this license.
// jqfd	 If you do not agree to this license, do not download, install,
// gryk	 copy or use the software.
// vpws	
// frun	                          License Agreement
// mwxt	         For OpenVss - Open Source Video Surveillance System
// cfdm	
// rpxl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// fkqf	
// oluq	Third party copyrights are property of their respective owners.
// ldop	
// zcpi	Redistribution and use in source and binary forms, with or without modification,
// qmne	are permitted provided that the following conditions are met:
// htbc	
// kjad	  * Redistribution's of source code must retain the above copyright notice,
// ntlr	    this list of conditions and the following disclaimer.
// umel	
// yrdt	  * Redistribution's in binary form must reproduce the above copyright notice,
// xebi	    this list of conditions and the following disclaimer in the documentation
// hhua	    and/or other materials provided with the distribution.
// qvwf	
// bsem	  * Neither the name of the copyright holders nor the names of its contributors 
// jouf	    may not be used to endorse or promote products derived from this software 
// lqcs	    without specific prior written permission.
// sxum	
// xdjz	This software is provided by the copyright holders and contributors "as is" and
// iugc	any express or implied warranties, including, but not limited to, the implied
// ssvd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pans	In no event shall the Prince of Songkla University or contributors be liable 
// xgpb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// isbk	(including, but not limited to, procurement of substitute goods or services;
// wyhg	loss of use, data, or profits; or business interruption) however caused
// biqk	and on any theory of liability, whether in contract, strict liability,
// mhcm	or tort (including negligence or otherwise) arising in any way out of
// lxwh	the use of this software, even if advised of the possibility of such damage.

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
