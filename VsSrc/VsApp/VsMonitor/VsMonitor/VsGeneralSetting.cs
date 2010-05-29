// fqmz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mbgp	
// unqr	 By downloading, copying, installing or using the software you agree to this license.
// ofck	 If you do not agree to this license, do not download, install,
// msxy	 copy or use the software.
// toyw	
// sfow	                          License Agreement
// nfvo	         For OpenVSS - Open Source Video Surveillance System
// foyi	
// mmdd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ejbc	
// gjlu	Third party copyrights are property of their respective owners.
// mybj	
// eddr	Redistribution and use in source and binary forms, with or without modification,
// sphg	are permitted provided that the following conditions are met:
// mjbp	
// scmz	  * Redistribution's of source code must retain the above copyright notice,
// guxa	    this list of conditions and the following disclaimer.
// ottk	
// nvqi	  * Redistribution's in binary form must reproduce the above copyright notice,
// utkp	    this list of conditions and the following disclaimer in the documentation
// eljc	    and/or other materials provided with the distribution.
// lhpx	
// fxqu	  * Neither the name of the copyright holders nor the names of its contributors 
// ilkd	    may not be used to endorse or promote products derived from this software 
// xmor	    without specific prior written permission.
// bavl	
// jtdx	This software is provided by the copyright holders and contributors "as is" and
// yymt	any express or implied warranties, including, but not limited to, the implied
// ymkh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sjnz	In no event shall the Prince of Songkla University or contributors be liable 
// ezvr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dzbb	(including, but not limited to, procurement of substitute goods or services;
// lmki	loss of use, data, or profits; or business interruption) however caused
// etnd	and on any theory of liability, whether in contract, strict liability,
// pyts	or tort (including negligence or otherwise) arising in any way out of
// esyg	the use of this software, even if advised of the possibility of such damage.
// kxvv	
// aclo	Intelligent Systems Laboratory (iSys Lab)
// ypmb	Faculty of Engineering, Prince of Songkla University, THAILAND
// fehj	Project leader by Nikom SUVONVORN
// rbmm	Project website at http://code.google.com/p/openvss/

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
