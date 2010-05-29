// dlmn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// npxl	
// ghgy	 By downloading, copying, installing or using the software you agree to this license.
// ajml	 If you do not agree to this license, do not download, install,
// kncz	 copy or use the software.
// vvoq	
// zacu	                          License Agreement
// snub	         For OpenVSS - Open Source Video Surveillance System
// xlum	
// czug	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// olur	
// xzzp	Third party copyrights are property of their respective owners.
// uswe	
// ytpi	Redistribution and use in source and binary forms, with or without modification,
// wwnm	are permitted provided that the following conditions are met:
// mdts	
// mfbo	  * Redistribution's of source code must retain the above copyright notice,
// pzjk	    this list of conditions and the following disclaimer.
// tvkj	
// axsa	  * Redistribution's in binary form must reproduce the above copyright notice,
// bmza	    this list of conditions and the following disclaimer in the documentation
// rqcd	    and/or other materials provided with the distribution.
// wlqf	
// lhtl	  * Neither the name of the copyright holders nor the names of its contributors 
// sbes	    may not be used to endorse or promote products derived from this software 
// ykau	    without specific prior written permission.
// illd	
// igiz	This software is provided by the copyright holders and contributors "as is" and
// dnla	any express or implied warranties, including, but not limited to, the implied
// dtbw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cxse	In no event shall the Prince of Songkla University or contributors be liable 
// jdzl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// czqy	(including, but not limited to, procurement of substitute goods or services;
// sacq	loss of use, data, or profits; or business interruption) however caused
// mfrf	and on any theory of liability, whether in contract, strict liability,
// ezup	or tort (including negligence or otherwise) arising in any way out of
// dqcy	the use of this software, even if advised of the possibility of such damage.
// vthz	
// ahpa	Intelligent Systems Laboratory (iSys Lab)
// svkf	Faculty of Engineering, Prince of Songkla University, THAILAND
// mzbi	Project leader by Nikom SUVONVORN
// pjgc	Project website at http://code.google.com/p/openvss/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VsCoreMobile;


namespace VsMobile
{
    public delegate void getAllcam();
    public delegate void setServerURL(string s);
    
    public partial class VsMLogin : Form
    {
        private getAllcam allcam;
        private setServerURL setServer;

        public bool Blocked = true;
        public bool Connected = false;

        private string configPath;
        
        public VsMLogin()
        {
            InitializeComponent();
            
        }
        
    
         public static VsMobileWireless MWireless = new VsMobileWireless();

        private void button2_Click(object sender, EventArgs e)
        {
            VsMLogin.MWireless.proxy = proxy.Text;
            VsMLogin.MWireless.user = username.Text;
            VsMLogin.MWireless.pass = password.Text;
            MWireless.VsMWlogin();

            if (VsMLogin.MWireless.login)
            {
                VsMSelect MSelect = new VsMSelect();
                MSelect.Show();
            }
            else
            {
                username.Text = "";
                password.Text = "";
            }
        }

        private void buttonTime_Click(object sender, EventArgs e)
        {
            Connected = false;
            Blocked = false;

            Application.Exit();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
