// tgpt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xjmo	
// aihj	 By downloading, copying, installing or using the software you agree to this license.
// kaov	 If you do not agree to this license, do not download, install,
// zttp	 copy or use the software.
// ohbv	
// houz	                          License Agreement
// yknc	         For OpenVSS - Open Source Video Surveillance System
// tjep	
// zdbx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zsxv	
// tsmf	Third party copyrights are property of their respective owners.
// wqjt	
// bnvm	Redistribution and use in source and binary forms, with or without modification,
// eumi	are permitted provided that the following conditions are met:
// pmqp	
// ufqa	  * Redistribution's of source code must retain the above copyright notice,
// wywv	    this list of conditions and the following disclaimer.
// rvqw	
// jfbp	  * Redistribution's in binary form must reproduce the above copyright notice,
// bpdh	    this list of conditions and the following disclaimer in the documentation
// buaf	    and/or other materials provided with the distribution.
// oske	
// rtim	  * Neither the name of the copyright holders nor the names of its contributors 
// chbo	    may not be used to endorse or promote products derived from this software 
// cmix	    without specific prior written permission.
// unbg	
// xzcz	This software is provided by the copyright holders and contributors "as is" and
// sxhz	any express or implied warranties, including, but not limited to, the implied
// iioa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ekld	In no event shall the Prince of Songkla University or contributors be liable 
// ordy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mdtb	(including, but not limited to, procurement of substitute goods or services;
// enmp	loss of use, data, or profits; or business interruption) however caused
// ggnn	and on any theory of liability, whether in contract, strict liability,
// suhp	or tort (including negligence or otherwise) arising in any way out of
// pkmu	the use of this software, even if advised of the possibility of such damage.
// liet	
// takr	Intelligent Systems Laboratory (iSys Lab)
// afjd	Faculty of Engineering, Prince of Songkla University, THAILAND
// jdtu	Project leader by Nikom SUVONVORN
// favf	Project website at http://code.google.com/p/openvss/

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
        private VsScanner vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsGeneralSetting()
        {
            InitializeComponent();
        }

        public VsScanner Monitor
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
