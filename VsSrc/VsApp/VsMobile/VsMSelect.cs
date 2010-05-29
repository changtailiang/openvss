// fxco	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xgue	
// wetk	 By downloading, copying, installing or using the software you agree to this license.
// jwwv	 If you do not agree to this license, do not download, install,
// aech	 copy or use the software.
// xfyk	
// cmqa	                          License Agreement
// dpwq	         For OpenVSS - Open Source Video Surveillance System
// ofbn	
// aagn	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// myfy	
// kvhm	Third party copyrights are property of their respective owners.
// oxqc	
// rcba	Redistribution and use in source and binary forms, with or without modification,
// zsll	are permitted provided that the following conditions are met:
// qtag	
// icvd	  * Redistribution's of source code must retain the above copyright notice,
// ujvz	    this list of conditions and the following disclaimer.
// xpvz	
// zaag	  * Redistribution's in binary form must reproduce the above copyright notice,
// femf	    this list of conditions and the following disclaimer in the documentation
// ztzm	    and/or other materials provided with the distribution.
// dbnh	
// ovws	  * Neither the name of the copyright holders nor the names of its contributors 
// xzqh	    may not be used to endorse or promote products derived from this software 
// adre	    without specific prior written permission.
// brec	
// hcaz	This software is provided by the copyright holders and contributors "as is" and
// sfgm	any express or implied warranties, including, but not limited to, the implied
// huho	warranties of merchantability and fitness for a particular purpose are disclaimed.
// djas	In no event shall the Prince of Songkla University or contributors be liable 
// vnkc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// scba	(including, but not limited to, procurement of substitute goods or services;
// ksgb	loss of use, data, or profits; or business interruption) however caused
// mhdi	and on any theory of liability, whether in contract, strict liability,
// pxeb	or tort (including negligence or otherwise) arising in any way out of
// bopj	the use of this software, even if advised of the possibility of such damage.
// okkd	
// rbdq	Intelligent Systems Laboratory (iSys Lab)
// czio	Faculty of Engineering, Prince of Songkla University, THAILAND
// gbjf	Project leader by Nikom SUVONVORN
// aaoz	Project website at http://code.google.com/p/openvss/

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
    public partial class VsMSelect : Form
    {
        public VsMSelect()
        {
            InitializeComponent();
            
        }
        
        private void btOk_Click(object sender, EventArgs e)
        {
            VsMLogin.MWireless.bmap = null;
            if (rbLMjpeg.Checked == true)
            {
                VsMLogin.MWireless.type = "LMjpg";
                VsMLive MLive = new VsMLive();
                MLive.Show();
            }
            else if (rbLJpeg.Checked == true)
            {
                VsMLogin.MWireless.type = "Ljpg";
                VsMLive MLive = new VsMLive();
                MLive.Show();
            }
            else if (rbPBWmv.Checked == true)
            {
                VsMLogin.MWireless.type = "PBWmv";
                VsMPlayBack MPlayBack = new VsMPlayBack();
                MPlayBack.Show();
            }
            else if (rbPBMjpeg.Checked == true)
            {
                VsMLogin.MWireless.type = "PBMjpeg";
                VsMPlayBack MPlayBack = new VsMPlayBack();
                MPlayBack.Show();
            }    
        }
               
       private void button3_Click(object sender, EventArgs e)
        {
            VsMLogin MLogin = new VsMLogin();
            MLogin.Show();
        }

       private void rbLJpeg_CheckedChanged(object sender, EventArgs e)
       {

       }

       private void rbLMjpeg_CheckedChanged(object sender, EventArgs e)
       {

       }

      

    
    }
}
