// enhx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// clrk	
// vvce	 By downloading, copying, installing or using the software you agree to this license.
// buoi	 If you do not agree to this license, do not download, install,
// iknf	 copy or use the software.
// ydus	
// medb	                          License Agreement
// ehjx	         For OpenVss - Open Source Video Surveillance System
// wwtb	
// jowv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// tgkt	
// arbe	Third party copyrights are property of their respective owners.
// joad	
// kloa	Redistribution and use in source and binary forms, with or without modification,
// tpky	are permitted provided that the following conditions are met:
// iqgo	
// lfie	  * Redistribution's of source code must retain the above copyright notice,
// bmyu	    this list of conditions and the following disclaimer.
// nrlr	
// tbrv	  * Redistribution's in binary form must reproduce the above copyright notice,
// cyrq	    this list of conditions and the following disclaimer in the documentation
// ggmk	    and/or other materials provided with the distribution.
// itiu	
// dynd	  * Neither the name of the copyright holders nor the names of its contributors 
// awhv	    may not be used to endorse or promote products derived from this software 
// iwdw	    without specific prior written permission.
// pgpt	
// zwhr	This software is provided by the copyright holders and contributors "as is" and
// ypvj	any express or implied warranties, including, but not limited to, the implied
// yqhe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sxvh	In no event shall the Prince of Songkla University or contributors be liable 
// eerp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dirw	(including, but not limited to, procurement of substitute goods or services;
// twmg	loss of use, data, or profits; or business interruption) however caused
// vvaa	and on any theory of liability, whether in contract, strict liability,
// qtkm	or tort (including negligence or otherwise) arising in any way out of
// lqwn	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vs.Client
{
    public partial class frmLogin : Form
    {
        public String strServer = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            strServer = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
