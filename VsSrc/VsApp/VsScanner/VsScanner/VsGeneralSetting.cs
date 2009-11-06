// ihxw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hvhj	
// widx	 By downloading, copying, installing or using the software you agree to this license.
// arnr	 If you do not agree to this license, do not download, install,
// oqdo	 copy or use the software.
// xnuh	
// hwaa	                          License Agreement
// iutx	         For OpenVss - Open Source Video Surveillance System
// pkqu	
// bnhq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// etlk	
// iwoo	Third party copyrights are property of their respective owners.
// wphe	
// jwbv	Redistribution and use in source and binary forms, with or without modification,
// nqpk	are permitted provided that the following conditions are met:
// vhac	
// oghq	  * Redistribution's of source code must retain the above copyright notice,
// bspb	    this list of conditions and the following disclaimer.
// jmke	
// cjyk	  * Redistribution's in binary form must reproduce the above copyright notice,
// ildt	    this list of conditions and the following disclaimer in the documentation
// npot	    and/or other materials provided with the distribution.
// ivhl	
// xwux	  * Neither the name of the copyright holders nor the names of its contributors 
// sjwc	    may not be used to endorse or promote products derived from this software 
// oxne	    without specific prior written permission.
// zfvw	
// mxsd	This software is provided by the copyright holders and contributors "as is" and
// reck	any express or implied warranties, including, but not limited to, the implied
// dhoz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// soig	In no event shall the Prince of Songkla University or contributors be liable 
// ledm	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rmlt	(including, but not limited to, procurement of substitute goods or services;
// nwvk	loss of use, data, or profits; or business interruption) however caused
// xyth	and on any theory of liability, whether in contract, strict liability,
// trhk	or tort (including negligence or otherwise) arising in any way out of
// cdtt	the use of this software, even if advised of the possibility of such damage.

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
