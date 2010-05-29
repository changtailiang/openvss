// hvpi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bzsp	
// adjk	 By downloading, copying, installing or using the software you agree to this license.
// gfks	 If you do not agree to this license, do not download, install,
// seue	 copy or use the software.
// dkrw	
// kdjk	                          License Agreement
// wmfm	         For OpenVSS - Open Source Video Surveillance System
// umij	
// cynb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// oyfr	
// qlaf	Third party copyrights are property of their respective owners.
// rgha	
// awkx	Redistribution and use in source and binary forms, with or without modification,
// esyx	are permitted provided that the following conditions are met:
// qhso	
// xwpu	  * Redistribution's of source code must retain the above copyright notice,
// wapu	    this list of conditions and the following disclaimer.
// qtqe	
// ezgy	  * Redistribution's in binary form must reproduce the above copyright notice,
// ddtq	    this list of conditions and the following disclaimer in the documentation
// efmy	    and/or other materials provided with the distribution.
// blfj	
// zqlg	  * Neither the name of the copyright holders nor the names of its contributors 
// grtt	    may not be used to endorse or promote products derived from this software 
// vgjq	    without specific prior written permission.
// qnkg	
// fgse	This software is provided by the copyright holders and contributors "as is" and
// matm	any express or implied warranties, including, but not limited to, the implied
// ocjs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// krtk	In no event shall the Prince of Songkla University or contributors be liable 
// vguz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ikxn	(including, but not limited to, procurement of substitute goods or services;
// gmcx	loss of use, data, or profits; or business interruption) however caused
// ucar	and on any theory of liability, whether in contract, strict liability,
// ufsu	or tort (including negligence or otherwise) arising in any way out of
// sbwz	the use of this software, even if advised of the possibility of such damage.
// wyre	
// haje	Intelligent Systems Laboratory (iSys Lab)
// myvj	Faculty of Engineering, Prince of Songkla University, THAILAND
// skyv	Project leader by Nikom SUVONVORN
// jfya	Project website at http://code.google.com/p/openvss/

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
using System.IO; 

namespace Vs.Playback
{
    

    public partial class VsLogin : Form, VsISplasher
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private getAllcam allcam;
        private setServerURL setServer;

        public bool Blocked = true;
        public bool Connected = false;

        private string configPath;

        public VsLogin()
        {
            InitializeComponent();
            ConfigData config = new ConfigData();

            configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenVss\\VsPlayback");
            try
            {
                config.LoadSettings(Path.Combine(configPath, "ServerConn.config"));

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

                config.saveSetting(Path.Combine(configPath, "ServerConn.config"));

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
