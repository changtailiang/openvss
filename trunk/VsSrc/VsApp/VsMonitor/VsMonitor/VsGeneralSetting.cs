// ftyn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mwjz	
// qlzs	 By downloading, copying, installing or using the software you agree to this license.
// nkog	 If you do not agree to this license, do not download, install,
// gnte	 copy or use the software.
// nwev	
// rhem	                          License Agreement
// edkf	         For OpenVss - Open Source Video Surveillance System
// xzjo	
// uzkg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xaga	
// hteg	Third party copyrights are property of their respective owners.
// ikfh	
// ecqj	Redistribution and use in source and binary forms, with or without modification,
// odwe	are permitted provided that the following conditions are met:
// rwvn	
// auvo	  * Redistribution's of source code must retain the above copyright notice,
// bamg	    this list of conditions and the following disclaimer.
// dnhn	
// qeox	  * Redistribution's in binary form must reproduce the above copyright notice,
// cxdt	    this list of conditions and the following disclaimer in the documentation
// ydau	    and/or other materials provided with the distribution.
// iazr	
// dfoa	  * Neither the name of the copyright holders nor the names of its contributors 
// etzm	    may not be used to endorse or promote products derived from this software 
// yqfi	    without specific prior written permission.
// yzer	
// vdsk	This software is provided by the copyright holders and contributors "as is" and
// ozct	any express or implied warranties, including, but not limited to, the implied
// tbox	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ubfb	In no event shall the Prince of Songkla University or contributors be liable 
// bucx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ygix	(including, but not limited to, procurement of substitute goods or services;
// ecym	loss of use, data, or profits; or business interruption) however caused
// svvz	and on any theory of liability, whether in contract, strict liability,
// ziyf	or tort (including negligence or otherwise) arising in any way out of
// hoce	the use of this software, even if advised of the possibility of such damage.

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
        private VsMonitor vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsGeneralSetting()
        {
            InitializeComponent();
        }

        public VsMonitor Monitor
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
