// mlvf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// szuo	
// bexv	 By downloading, copying, installing or using the software you agree to this license.
// xxrm	 If you do not agree to this license, do not download, install,
// qxna	 copy or use the software.
// qwzw	
// fldb	                          License Agreement
// okmr	         For OpenVSS - Open Source Video Surveillance System
// ggne	
// vmxp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zkck	
// idhc	Third party copyrights are property of their respective owners.
// jzuj	
// jnyp	Redistribution and use in source and binary forms, with or without modification,
// lzah	are permitted provided that the following conditions are met:
// vsaq	
// rfor	  * Redistribution's of source code must retain the above copyright notice,
// jmqe	    this list of conditions and the following disclaimer.
// zyag	
// upnc	  * Redistribution's in binary form must reproduce the above copyright notice,
// dbsp	    this list of conditions and the following disclaimer in the documentation
// qcis	    and/or other materials provided with the distribution.
// hysw	
// lquh	  * Neither the name of the copyright holders nor the names of its contributors 
// jlsd	    may not be used to endorse or promote products derived from this software 
// oqsw	    without specific prior written permission.
// iqkl	
// mrvw	This software is provided by the copyright holders and contributors "as is" and
// lydt	any express or implied warranties, including, but not limited to, the implied
// zlao	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xwjl	In no event shall the Prince of Songkla University or contributors be liable 
// uusj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// etxi	(including, but not limited to, procurement of substitute goods or services;
// wkon	loss of use, data, or profits; or business interruption) however caused
// ivgz	and on any theory of liability, whether in contract, strict liability,
// swgp	or tort (including negligence or otherwise) arising in any way out of
// cvkn	the use of this software, even if advised of the possibility of such damage.
// maix	
// ldgs	Intelligent Systems Laboratory (iSys Lab)
// ghbn	Faculty of Engineering, Prince of Songkla University, THAILAND
// yagt	Project leader by Nikom SUVONVORN
// umzb	Project website at http://code.google.com/p/openvss/

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
    }
}
