// gjiv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// apwk	
// voww	 By downloading, copying, installing or using the software you agree to this license.
// pfbe	 If you do not agree to this license, do not download, install,
// jdzd	 copy or use the software.
// qnnq	
// uoow	                          License Agreement
// rsnt	         For OpenVss - Open Source Video Surveillance System
// kich	
// aaad	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ztku	
// zytg	Third party copyrights are property of their respective owners.
// osno	
// pjzs	Redistribution and use in source and binary forms, with or without modification,
// wrbl	are permitted provided that the following conditions are met:
// basc	
// acmh	  * Redistribution's of source code must retain the above copyright notice,
// dudi	    this list of conditions and the following disclaimer.
// cwdw	
// dsrv	  * Redistribution's in binary form must reproduce the above copyright notice,
// uhiy	    this list of conditions and the following disclaimer in the documentation
// eyea	    and/or other materials provided with the distribution.
// ijli	
// zpbz	  * Neither the name of the copyright holders nor the names of its contributors 
// ahuw	    may not be used to endorse or promote products derived from this software 
// mmdt	    without specific prior written permission.
// oelt	
// fcpe	This software is provided by the copyright holders and contributors "as is" and
// afqt	any express or implied warranties, including, but not limited to, the implied
// rtxc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ylyt	In no event shall the Prince of Songkla University or contributors be liable 
// jujn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uewv	(including, but not limited to, procurement of substitute goods or services;
// yvji	loss of use, data, or profits; or business interruption) however caused
// eoka	and on any theory of liability, whether in contract, strict liability,
// mlug	or tort (including negligence or otherwise) arising in any way out of
// uhit	the use of this software, even if advised of the possibility of such damage.

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
