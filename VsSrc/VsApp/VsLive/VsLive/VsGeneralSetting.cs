// phkr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bysm	
// oegy	 By downloading, copying, installing or using the software you agree to this license.
// edxg	 If you do not agree to this license, do not download, install,
// bvhm	 copy or use the software.
// ixxh	
// voax	                          License Agreement
// zbyz	         For OpenVSS - Open Source Video Surveillance System
// rysu	
// qyzx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xmei	
// drne	Third party copyrights are property of their respective owners.
// nenn	
// lcrs	Redistribution and use in source and binary forms, with or without modification,
// kcwn	are permitted provided that the following conditions are met:
// yumn	
// ghgg	  * Redistribution's of source code must retain the above copyright notice,
// kdpd	    this list of conditions and the following disclaimer.
// vjpw	
// sped	  * Redistribution's in binary form must reproduce the above copyright notice,
// avju	    this list of conditions and the following disclaimer in the documentation
// nknp	    and/or other materials provided with the distribution.
// gako	
// bmzc	  * Neither the name of the copyright holders nor the names of its contributors 
// zrbw	    may not be used to endorse or promote products derived from this software 
// khtk	    without specific prior written permission.
// pkrc	
// nvzu	This software is provided by the copyright holders and contributors "as is" and
// ysmc	any express or implied warranties, including, but not limited to, the implied
// krzv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// trak	In no event shall the Prince of Songkla University or contributors be liable 
// tbbj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// knwb	(including, but not limited to, procurement of substitute goods or services;
// nist	loss of use, data, or profits; or business interruption) however caused
// czfd	and on any theory of liability, whether in contract, strict liability,
// tlbk	or tort (including negligence or otherwise) arising in any way out of
// bppi	the use of this software, even if advised of the possibility of such damage.
// awsi	
// rfct	Intelligent Systems Laboratory (iSys Lab)
// hjqn	Faculty of Engineering, Prince of Songkla University, THAILAND
// jira	Project leader by Nikom SUVONVORN
// zyhq	Project website at http://code.google.com/p/openvss/

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
        private VsLive vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsGeneralSetting()
        {
            InitializeComponent();
        }

        public VsLive Monitor
        {
            set { vsMonitor = value; }
        }

        public VsCoreServer CoreMonitor
        {
            set
            {
                vsCoreMonitor = value;
                this.textBoxClock.Text = vsCoreMonitor.SyncTimer.ToString();
                this.textBoxHostnameDatabase.Text = vsCoreMonitor.DataHost;
                this.textBoxUser.Text = vsCoreMonitor.DataUser;
                this.textBoxPassword.Text = vsCoreMonitor.DataPasswd;
                this.textBoxDatabase.Text = vsCoreMonitor.DataDatabase;
                this.textBoxStorageHostName.Text = vsCoreMonitor.LocalHost;
                this.textBoxStorageDirectory.Text = vsCoreMonitor.LocalStorage;                
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            vsCoreMonitor.SyncTimer = long.Parse(this.textBoxClock.Text);
            vsCoreMonitor.DataHost = this.textBoxHostnameDatabase.Text;
            vsCoreMonitor.DataUser = this.textBoxUser.Text;
            vsCoreMonitor.DataPasswd = this.textBoxPassword.Text;
            vsCoreMonitor.DataDatabase = this.textBoxDatabase.Text;
            vsCoreMonitor.LocalHost = this.textBoxStorageHostName.Text;
            vsCoreMonitor.LocalStorage = this.textBoxStorageDirectory.Text;
        }

    }
}
