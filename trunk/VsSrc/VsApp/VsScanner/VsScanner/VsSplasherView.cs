// gejj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vfti	
// kbon	 By downloading, copying, installing or using the software you agree to this license.
// wpbi	 If you do not agree to this license, do not download, install,
// fzaf	 copy or use the software.
// jpcj	
// aoxo	                          License Agreement
// cbjn	         For OpenVss - Open Source Video Surveillance System
// tzsq	
// dqji	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bfcf	
// bvbb	Third party copyrights are property of their respective owners.
// vvkb	
// iehr	Redistribution and use in source and binary forms, with or without modification,
// caig	are permitted provided that the following conditions are met:
// iffi	
// rbuw	  * Redistribution's of source code must retain the above copyright notice,
// xleo	    this list of conditions and the following disclaimer.
// qree	
// mwhe	  * Redistribution's in binary form must reproduce the above copyright notice,
// nvsh	    this list of conditions and the following disclaimer in the documentation
// rifp	    and/or other materials provided with the distribution.
// rbod	
// hcaw	  * Neither the name of the copyright holders nor the names of its contributors 
// ztna	    may not be used to endorse or promote products derived from this software 
// beek	    without specific prior written permission.
// qvlq	
// adef	This software is provided by the copyright holders and contributors "as is" and
// setm	any express or implied warranties, including, but not limited to, the implied
// myrj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vefw	In no event shall the Prince of Songkla University or contributors be liable 
// wbhn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rhes	(including, but not limited to, procurement of substitute goods or services;
// igdi	loss of use, data, or profits; or business interruption) however caused
// rirv	and on any theory of liability, whether in contract, strict liability,
// wppo	or tort (including negligence or otherwise) arising in any way out of
// wikd	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vs.Core;

namespace Vs.Monitor
{
    public partial class VsSplasherView : Form, VsISplasher
    {
        public VsSplasherView()
        {
            InitializeComponent();
        }

        void VsISplasher.SetStatusInfo(string StatusInfo)
        {
            labelStatus.Text = StatusInfo;
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
