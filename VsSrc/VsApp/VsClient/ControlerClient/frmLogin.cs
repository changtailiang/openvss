// dmru	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zosb	
// tnuc	 By downloading, copying, installing or using the software you agree to this license.
// guqc	 If you do not agree to this license, do not download, install,
// hqmi	 copy or use the software.
// gthk	
// dbyq	                          License Agreement
// bhhp	         For OpenVSS - Open Source Video Surveillance System
// zzax	
// bmxx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ngou	
// dkzm	Third party copyrights are property of their respective owners.
// zcep	
// umlj	Redistribution and use in source and binary forms, with or without modification,
// fhrx	are permitted provided that the following conditions are met:
// pbzm	
// ffcg	  * Redistribution's of source code must retain the above copyright notice,
// utau	    this list of conditions and the following disclaimer.
// sova	
// fmhs	  * Redistribution's in binary form must reproduce the above copyright notice,
// cmrz	    this list of conditions and the following disclaimer in the documentation
// csvm	    and/or other materials provided with the distribution.
// orru	
// vail	  * Neither the name of the copyright holders nor the names of its contributors 
// gcoy	    may not be used to endorse or promote products derived from this software 
// issf	    without specific prior written permission.
// bkwf	
// rkds	This software is provided by the copyright holders and contributors "as is" and
// zyvd	any express or implied warranties, including, but not limited to, the implied
// kajn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kpsd	In no event shall the Prince of Songkla University or contributors be liable 
// bgys	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gktd	(including, but not limited to, procurement of substitute goods or services;
// xikk	loss of use, data, or profits; or business interruption) however caused
// ulxs	and on any theory of liability, whether in contract, strict liability,
// vpve	or tort (including negligence or otherwise) arising in any way out of
// nzux	the use of this software, even if advised of the possibility of such damage.
// feaf	
// sbos	Intelligent Systems Laboratory (iSys Lab)
// aoev	Faculty of Engineering, Prince of Songkla University, THAILAND
// meyg	Project leader by Nikom SUVONVORN
// qavr	Project website at http://code.google.com/p/openvss/

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
