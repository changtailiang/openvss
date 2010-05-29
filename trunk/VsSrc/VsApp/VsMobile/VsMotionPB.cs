// bcjp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ghck	
// ignq	 By downloading, copying, installing or using the software you agree to this license.
// qwmk	 If you do not agree to this license, do not download, install,
// dgli	 copy or use the software.
// wmyy	
// ozje	                          License Agreement
// qdkn	         For OpenVSS - Open Source Video Surveillance System
// cmfw	
// yxdd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lcbb	
// zvbh	Third party copyrights are property of their respective owners.
// fogw	
// yiwo	Redistribution and use in source and binary forms, with or without modification,
// elag	are permitted provided that the following conditions are met:
// xxuf	
// vznd	  * Redistribution's of source code must retain the above copyright notice,
// qqmf	    this list of conditions and the following disclaimer.
// dhwt	
// lxyt	  * Redistribution's in binary form must reproduce the above copyright notice,
// yczb	    this list of conditions and the following disclaimer in the documentation
// xnpu	    and/or other materials provided with the distribution.
// qrsn	
// wwgo	  * Neither the name of the copyright holders nor the names of its contributors 
// iwfz	    may not be used to endorse or promote products derived from this software 
// hyqp	    without specific prior written permission.
// catq	
// lcdg	This software is provided by the copyright holders and contributors "as is" and
// mhiu	any express or implied warranties, including, but not limited to, the implied
// xshi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ktnz	In no event shall the Prince of Songkla University or contributors be liable 
// xzjg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bilo	(including, but not limited to, procurement of substitute goods or services;
// rzla	loss of use, data, or profits; or business interruption) however caused
// mjzx	and on any theory of liability, whether in contract, strict liability,
// tyin	or tort (including negligence or otherwise) arising in any way out of
// olap	the use of this software, even if advised of the possibility of such damage.
// olqp	
// oxpo	Intelligent Systems Laboratory (iSys Lab)
// kqrc	Faculty of Engineering, Prince of Songkla University, THAILAND
// qnpd	Project leader by Nikom SUVONVORN
// qopn	Project website at http://code.google.com/p/openvss/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VsMobile
{
    public partial class VsMotionPB : Form
    {
        public VsMotionPB()
        {
             InitializeComponent();
            
            listBox.Items.Clear();
            if (VsMLogin.MWireless.thread1 != null)
                VsMLogin.MWireless.thread1.Abort();
            this.pictureBox1.Image = null;
            foreach (string o in VsMLogin.MWireless.x)
            {
                listBox.Items.Add(o);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (VsMLogin.MWireless.thread1 != null)
            
                VsMLogin.MWireless.thread1.Abort();
                this.Close();
            
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (VsMLogin.MWireless.thread1 != null)
                VsMLogin.MWireless.thread1.Abort();
            VsMLogin MLogin = new VsMLogin();
            MLogin.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VsMLogin.MWireless.selectedIndex = ((ListBox)sender).SelectedIndex;
            VsMLogin.MWireless.motionSelected();

            
        }
     

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            
            this.pictureBox1.Image = VsMLogin.MWireless.bmap;
 
        }
    }
}
