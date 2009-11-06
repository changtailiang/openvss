// gvpv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mrjt	
// kedu	 By downloading, copying, installing or using the software you agree to this license.
// rtzu	 If you do not agree to this license, do not download, install,
// cutt	 copy or use the software.
// yzig	
// yfto	                          License Agreement
// mbxx	         For OpenVss - Open Source Video Surveillance System
// wats	
// syen	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mazz	
// iojx	Third party copyrights are property of their respective owners.
// lgna	
// lslg	Redistribution and use in source and binary forms, with or without modification,
// mjwg	are permitted provided that the following conditions are met:
// xuhj	
// ggyq	  * Redistribution's of source code must retain the above copyright notice,
// ahbe	    this list of conditions and the following disclaimer.
// qggx	
// zjyk	  * Redistribution's in binary form must reproduce the above copyright notice,
// vwdg	    this list of conditions and the following disclaimer in the documentation
// oxld	    and/or other materials provided with the distribution.
// pmfj	
// bxpr	  * Neither the name of the copyright holders nor the names of its contributors 
// tqtb	    may not be used to endorse or promote products derived from this software 
// psxe	    without specific prior written permission.
// eikf	
// lngd	This software is provided by the copyright holders and contributors "as is" and
// llkb	any express or implied warranties, including, but not limited to, the implied
// ravj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uubn	In no event shall the Prince of Songkla University or contributors be liable 
// brds	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qpej	(including, but not limited to, procurement of substitute goods or services;
// qwvc	loss of use, data, or profits; or business interruption) however caused
// zzbg	and on any theory of liability, whether in contract, strict liability,
// ngsb	or tort (including negligence or otherwise) arising in any way out of
// gcyp	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace VsSetup
{
    public partial class VsCopyFile : UserControl
    {
        VsInstallControl control;

        public VsCopyFile(VsInstallControl control)
        {
            this.control = control;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.setDir(labelProgramDir.Text, labelDataDir.Text);

            //control.updateAppFileLocationConfiguration();

            control.nextState();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            label6.ForeColor = Color.Black;
            control.compeatedState = 0;
            System.IO.Directory.CreateDirectory(labelDataDir.Text);

            control.setDir(labelProgramDir.Text, labelDataDir.Text);

            System.Threading.Thread t = new System.Threading.Thread(() =>
             {
                 control.deleteAllVirDir();
                 control.stopVsWinService();
                 control.UnZipFiles("Data\\VsApp.dat", labelProgramDir.Text, "", false);
             });

            t.Start();
            timer1.Start();

            pictureBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                labelProgramDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                labelDataDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (control.compeatedState == 0)
            {
                label6.Text = "Install " + control.unzipfile;
                //label6.ForeColor = Color.Yellow;
            }
            else if (control.compeatedState == 1)
            {
                button1.Enabled = true;

                label6.Text = "Install successfull";
                label6.ForeColor = Color.Green;

                pictureBox2.Visible = false;
                timer1.Stop();

                groupBox1.Enabled = true;
            }
            else if (control.compeatedState == -1)
            {
                label6.Text = "Install failed" + control.unzipfile;
                label6.ForeColor = Color.Red;

                pictureBox2.Visible = false;
                timer1.Stop();

                groupBox1.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.exitSetup(State.copyVS);
        }





    }
}
