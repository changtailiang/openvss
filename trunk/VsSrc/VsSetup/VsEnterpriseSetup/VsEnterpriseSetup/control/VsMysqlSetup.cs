// oqyl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xfbi	
// ivgk	 By downloading, copying, installing or using the software you agree to this license.
// unvx	 If you do not agree to this license, do not download, install,
// nmbh	 copy or use the software.
// sqcn	
// jxdj	                          License Agreement
// nhji	         For OpenVss - Open Source Video Surveillance System
// dmpm	
// bryk	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vyzb	
// ffsn	Third party copyrights are property of their respective owners.
// wmcl	
// lwyx	Redistribution and use in source and binary forms, with or without modification,
// nlca	are permitted provided that the following conditions are met:
// csub	
// mxgh	  * Redistribution's of source code must retain the above copyright notice,
// xivv	    this list of conditions and the following disclaimer.
// nrlu	
// rbid	  * Redistribution's in binary form must reproduce the above copyright notice,
// eqmb	    this list of conditions and the following disclaimer in the documentation
// eywg	    and/or other materials provided with the distribution.
// nsyq	
// pxic	  * Neither the name of the copyright holders nor the names of its contributors 
// dxph	    may not be used to endorse or promote products derived from this software 
// ykpo	    without specific prior written permission.
// qhxu	
// kdgm	This software is provided by the copyright holders and contributors "as is" and
// dyvl	any express or implied warranties, including, but not limited to, the implied
// gsxn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bztf	In no event shall the Prince of Songkla University or contributors be liable 
// jffq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// iirt	(including, but not limited to, procurement of substitute goods or services;
// mafu	loss of use, data, or profits; or business interruption) however caused
// axkw	and on any theory of liability, whether in contract, strict liability,
// bbwk	or tort (including negligence or otherwise) arising in any way out of
// lmmq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VsSetup
{
    public partial class MySqlSetup : UserControl
    {
        private VsInstallControl control;
        public MySqlSetup(VsInstallControl control)
        {
            this.control = control;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (control.testMysqlConnection(textBox3.Text, textBox4.Text, textBox1.Text, textBox2.Text))
                {
                    //MessageBox.Show("Connection Successful");

                    button4.Enabled = true;
                    label6.Text = "MySQL installed successful.";
                    label6.ForeColor = Color.Green;

                    groupBox1.Enabled = false;
                    control.setDBconnectionProp(textBox3.Text, textBox4.Text, textBox1.Text, textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Access denied for user '" + textBox1.Text + "'@'" + textBox3.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // control.updateAppDBConfiguration(); 
            control.nextState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string cmd = "Component\\MySqlSetup.exe ";
             control.runFileExe(cmd,"",false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            control.exitSetup(State.mysql);
        }
    }
}
