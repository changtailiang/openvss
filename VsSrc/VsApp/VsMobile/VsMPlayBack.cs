// qfgv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// aksl	
// vpqy	 By downloading, copying, installing or using the software you agree to this license.
// gokp	 If you do not agree to this license, do not download, install,
// gcjs	 copy or use the software.
// cqjz	
// qfps	                          License Agreement
// qswi	         For OpenVSS - Open Source Video Surveillance System
// kofm	
// yidc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mhha	
// ymiw	Third party copyrights are property of their respective owners.
// fkrn	
// yxaz	Redistribution and use in source and binary forms, with or without modification,
// wheu	are permitted provided that the following conditions are met:
// vzvd	
// tior	  * Redistribution's of source code must retain the above copyright notice,
// jyqy	    this list of conditions and the following disclaimer.
// yhfv	
// iibe	  * Redistribution's in binary form must reproduce the above copyright notice,
// xsng	    this list of conditions and the following disclaimer in the documentation
// ajjm	    and/or other materials provided with the distribution.
// ofqr	
// ejgn	  * Neither the name of the copyright holders nor the names of its contributors 
// legp	    may not be used to endorse or promote products derived from this software 
// yqnh	    without specific prior written permission.
// ttor	
// sfrn	This software is provided by the copyright holders and contributors "as is" and
// gzxd	any express or implied warranties, including, but not limited to, the implied
// mpck	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zbde	In no event shall the Prince of Songkla University or contributors be liable 
// iytp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// asje	(including, but not limited to, procurement of substitute goods or services;
// clfg	loss of use, data, or profits; or business interruption) however caused
// ffmh	and on any theory of liability, whether in contract, strict liability,
// usti	or tort (including negligence or otherwise) arising in any way out of
// ncle	the use of this software, even if advised of the possibility of such damage.
// mdaw	
// cwqw	Intelligent Systems Laboratory (iSys Lab)
// njzu	Faculty of Engineering, Prince of Songkla University, THAILAND
// azra	Project leader by Nikom SUVONVORN
// wnlu	Project website at http://code.google.com/p/openvss/

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
    public partial class VsMPlayBack : Form
    {
        public VsMPlayBack()
        {
            InitializeComponent();
            VsMLogin.MWireless.getCameraList();
            int i = 1;

            //VsMLogin.MWireless.setTimePeriod(DateTime.Now, DateTime.Now);
            foreach (var v in VsMLogin.MWireless.camList)
            {
                //listBox1.Items.Add(v.cameraID + ":" + v.location);
                comboBox2.Items.Add("Camera " + i);
                i++;
            }
            //VsMLogin.MWireless.setAllCam(VsMLogin.MWireless.camList);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (VsMLogin.MWireless.thread1 != null)
            {
                VsMLogin.MWireless.thread1.Abort();
            }
            VsMLogin MLogin = new VsMLogin();
            MLogin.Show();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btOk_Click(object sender, EventArgs e)
        {

        }
        //public List<string> x;
        private void btOk_Click_1(object sender, EventArgs e)
        {
            DateTime start = DateTime.Parse(dtpDate.Value.Date.ToString().Split()[0] + " " + dtpTime.Value.ToString().Split()[1]);
            DateTime end = DateTime.Parse(dtpTime2.Value.Date.ToString().Split()[0] + " " + dtpTime2.Value.ToString().Split()[1]);

            //List<string> x = VsMLogin.MWireless.getMotionEvent(comboBox2.SelectedIndex, start, end);
            
           VsMLogin.MWireless.x = VsMLogin.MWireless.getMotionEvent(comboBox2.SelectedIndex, start, end);  

           VsMotionPB MotionPB = new VsMotionPB();
           MotionPB.Show();
            

         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                VsMLogin.MWireless.height = 240;
                VsMLogin.MWireless.width = 180;
            
                VsMLogin.MWireless.quanlity = 100;

            }
            else if (((ComboBox)sender).SelectedIndex == 1)
            {
                
                VsMLogin.MWireless.height = 200;
                VsMLogin.MWireless.width = 150;
                VsMLogin.MWireless.quanlity = 70;       

            }
            else if (((ComboBox)sender).SelectedIndex == 2)
            {
               
                VsMLogin.MWireless.height = 160;
                VsMLogin.MWireless.width = 120;
                VsMLogin.MWireless.quanlity = 30;

            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VsMPlayBack_Load(object sender, EventArgs e)
        {

        }
            
        }

      


} 
      
