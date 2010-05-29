// qilc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yzju	
// rlwm	 By downloading, copying, installing or using the software you agree to this license.
// lboh	 If you do not agree to this license, do not download, install,
// ahiu	 copy or use the software.
// kalx	
// ttaf	                          License Agreement
// omwr	         For OpenVSS - Open Source Video Surveillance System
// grgi	
// wfxf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qlan	
// juyk	Third party copyrights are property of their respective owners.
// bith	
// xlap	Redistribution and use in source and binary forms, with or without modification,
// woje	are permitted provided that the following conditions are met:
// zege	
// ofgu	  * Redistribution's of source code must retain the above copyright notice,
// vfku	    this list of conditions and the following disclaimer.
// jcez	
// zxoy	  * Redistribution's in binary form must reproduce the above copyright notice,
// vqdf	    this list of conditions and the following disclaimer in the documentation
// souv	    and/or other materials provided with the distribution.
// qqmi	
// wsgm	  * Neither the name of the copyright holders nor the names of its contributors 
// fwze	    may not be used to endorse or promote products derived from this software 
// oeow	    without specific prior written permission.
// xzyu	
// gbpy	This software is provided by the copyright holders and contributors "as is" and
// zljj	any express or implied warranties, including, but not limited to, the implied
// aalz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kkdf	In no event shall the Prince of Songkla University or contributors be liable 
// tcyq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wsud	(including, but not limited to, procurement of substitute goods or services;
// ykjq	loss of use, data, or profits; or business interruption) however caused
// bhht	and on any theory of liability, whether in contract, strict liability,
// qapp	or tort (including negligence or otherwise) arising in any way out of
// anil	the use of this software, even if advised of the possibility of such damage.
// jwle	
// kzte	Intelligent Systems Laboratory (iSys Lab)
// ajcv	Faculty of Engineering, Prince of Songkla University, THAILAND
// ahxn	Project leader by Nikom SUVONVORN
// hmap	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using System.IO;
using System.Reflection;

using Vs.Core.Image;
using System.Threading;
using Vs.Core.MediaProxyServer;

namespace VsMediaProxyServerApplication
{
    public partial class Form1 : Form
    {

        HttpServer httpServer;


        public Form1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            textBox1.Text = HttpServer.output;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (httpServer != null)
            {
                httpServer.Stop();
            }


            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
                string ProviderPath = appPath;//Path.Combine(appPath, "Provider");
                httpServer = new VsMediaProxyServer(int.Parse(textBox2.Text), textBox3.Text
                    , appPath, ProviderPath);
                httpServer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText("serviceData.txt", "Con service\r\n");
        }
    }
}
