// brfz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kiiv	
// pkcd	 By downloading, copying, installing or using the software you agree to this license.
// tscs	 If you do not agree to this license, do not download, install,
// eple	 copy or use the software.
// uort	
// xxyz	                          License Agreement
// bree	         For OpenVss - Open Source Video Surveillance System
// wqeh	
// fpop	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// sqpe	
// xnwo	Third party copyrights are property of their respective owners.
// geza	
// uegm	Redistribution and use in source and binary forms, with or without modification,
// zlbm	are permitted provided that the following conditions are met:
// jity	
// fyhd	  * Redistribution's of source code must retain the above copyright notice,
// nvno	    this list of conditions and the following disclaimer.
// bwme	
// ynvk	  * Redistribution's in binary form must reproduce the above copyright notice,
// aktw	    this list of conditions and the following disclaimer in the documentation
// sejs	    and/or other materials provided with the distribution.
// jshu	
// obfk	  * Neither the name of the copyright holders nor the names of its contributors 
// wryz	    may not be used to endorse or promote products derived from this software 
// gtal	    without specific prior written permission.
// rkyy	
// scom	This software is provided by the copyright holders and contributors "as is" and
// prmy	any express or implied warranties, including, but not limited to, the implied
// pxga	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ootv	In no event shall the Prince of Songkla University or contributors be liable 
// nszz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qchh	(including, but not limited to, procurement of substitute goods or services;
// oweh	loss of use, data, or profits; or business interruption) however caused
// jhfh	and on any theory of liability, whether in contract, strict liability,
// flah	or tort (including negligence or otherwise) arising in any way out of
// dvfx	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using NLog;
using System.Configuration; 

namespace Vs.Playback
{
    

    public partial class VsLogin : Form, VsISplasher
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private getAllcam allcam;
        private setServerURL setServer;

        public bool Blocked = true;
        public bool Connected = false;

        public VsLogin()
        {
            InitializeComponent();
            ConfigData config = new ConfigData();

            try
            {
                config.LoadSettings("ServerConn.config");

                textBox1.Text = config.data["server"];
                textBox2.Text = config.data["user"];
                textBox3.Text = config.data["pass"];
            }
            catch { }
        }
        
        public void LoginSerivce(getAllcam allcam, setServerURL setServer)     
        {
            try
            {
                this.allcam = allcam;
                this.setServer = setServer;
                labelStatus.Invoke(new MethodInvoker(labelStatus.Hide));
                panelLogin.Invoke(new MethodInvoker(panelLogin.Show));
                //labelStatus.Visible = false;
                //panelLogin.Visible = true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }


        void VsISplasher.SetStatusInfo(string StatusInfo)
        {
            labelStatus.Text = StatusInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            try
            { 
                panelLogin.Hide();
                labelStatus.Show();
                labelStatus.Text = "Logging...";
                System.Threading.Thread.Sleep(10);
                setServer("http://" + textBox1.Text + "/vsservice/service.asmx");
                allcam();
                Connected = true;
                Blocked = false;

                ConfigData config = new ConfigData();

                config.data["server"] = textBox1.Text;
                config.data["user"] = textBox2.Text;
                config.data["pass"] = textBox3.Text;

                config.saveSetting("ServerConn.config");

            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void buttonTime_Click(object sender, EventArgs e)
        {
            Connected = false;            
            Blocked = false;
        }    
    }
}
