// oktn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// znok	
// zlse	 By downloading, copying, installing or using the software you agree to this license.
// lyiy	 If you do not agree to this license, do not download, install,
// fuyo	 copy or use the software.
// bykh	
// aqrf	                          License Agreement
// totk	         For OpenVSS - Open Source Video Surveillance System
// ufzs	
// wgws	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ehjy	
// krth	Third party copyrights are property of their respective owners.
// eywp	
// flcp	Redistribution and use in source and binary forms, with or without modification,
// alni	are permitted provided that the following conditions are met:
// viqk	
// rhkg	  * Redistribution's of source code must retain the above copyright notice,
// zpbz	    this list of conditions and the following disclaimer.
// ygku	
// plwi	  * Redistribution's in binary form must reproduce the above copyright notice,
// wjbv	    this list of conditions and the following disclaimer in the documentation
// seei	    and/or other materials provided with the distribution.
// djsk	
// snwv	  * Neither the name of the copyright holders nor the names of its contributors 
// rzgd	    may not be used to endorse or promote products derived from this software 
// hnio	    without specific prior written permission.
// wwrz	
// bhao	This software is provided by the copyright holders and contributors "as is" and
// ofml	any express or implied warranties, including, but not limited to, the implied
// gurn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cbdq	In no event shall the Prince of Songkla University or contributors be liable 
// wqgk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jodq	(including, but not limited to, procurement of substitute goods or services;
// etbj	loss of use, data, or profits; or business interruption) however caused
// bnyv	and on any theory of liability, whether in contract, strict liability,
// mfhv	or tort (including negligence or otherwise) arising in any way out of
// jewn	the use of this software, even if advised of the possibility of such damage.
// blow	
// hsaf	Intelligent Systems Laboratory (iSys Lab)
// ksrg	Faculty of Engineering, Prince of Songkla University, THAILAND
// qgqm	Project leader by Nikom SUVONVORN
// ejjv	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using VsCoreMobile;



namespace VsMobile
{
    public partial class VsMLive : Form
    {
        
        public VsMLive()
        {
            InitializeComponent();


            VsMLogin.MWireless.getCameraList();
            int i=1;
            
            
            foreach (var v in VsMLogin.MWireless.camList)
            {
                //listBox1.Items.Add(v.cameraID + ":" + v.location);

                comboBox2.Items.Add("Camera " + i);
                i++;
  
            }
          
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

             
        private void timer1_Tick(object sender, EventArgs e)
        {

            //VsMLogin.MWireless.bmap = null;
            pictureBox1.Image = VsMLogin.MWireless.bmap;
            
            
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
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                VsMLogin.MWireless.height = 240;
                VsMLogin.MWireless.width = 180;
                VsMLogin.MWireless.quanlity = 100;

                if (VsMLogin.MWireless.type == "LMjpg")
                {
                    VsMLogin.MWireless.Live();
                }
                else if (VsMLogin.MWireless.type == "Ljpg")
                {
                    VsMLogin.MWireless.LiveJpeg();
                    
                }
               
           }
            else if (((ComboBox)sender).SelectedIndex == 1)
            {
                VsMLogin.MWireless.height = 200;
                VsMLogin.MWireless.width = 150;
                VsMLogin.MWireless.quanlity = 70;
                    if (VsMLogin.MWireless.type == "LMjpg")
                    {
                        VsMLogin.MWireless.Live();
                    }
                    else if (VsMLogin.MWireless.type == "Ljpg")
                    {
                        VsMLogin.MWireless.LiveJpeg();
                    }

                   
            }
            else if (((ComboBox)sender).SelectedIndex == 2)
            {
                VsMLogin.MWireless.height = 160;
                VsMLogin.MWireless.width = 120;
                VsMLogin.MWireless.quanlity = 30;
                    if (VsMLogin.MWireless.type == "LMjpg")
                    {
                        VsMLogin.MWireless.Live();
                    }
                    else if (VsMLogin.MWireless.type == "Ljpg")
                    {
                        VsMLogin.MWireless.LiveJpeg();
                    }

                   
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            VsMLogin.MWireless.IP = VsMLogin.MWireless.camList[((ComboBox)sender).SelectedIndex].location;

            if (VsMLogin.MWireless.type == "LMjpg") 
                VsMLogin.MWireless.Live();
            else if (VsMLogin.MWireless.type == "Ljpg") 
                VsMLogin.MWireless.LiveJpeg();
        }
    }
}
