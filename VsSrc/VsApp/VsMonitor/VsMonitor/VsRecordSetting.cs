// qmsg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wueb	
// orpp	 By downloading, copying, installing or using the software you agree to this license.
// bszi	 If you do not agree to this license, do not download, install,
// kygr	 copy or use the software.
// syiu	
// gayz	                          License Agreement
// nlbv	         For OpenVss - Open Source Video Surveillance System
// yklz	
// uljv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lssz	
// iono	Third party copyrights are property of their respective owners.
// tivz	
// qrgr	Redistribution and use in source and binary forms, with or without modification,
// eyav	are permitted provided that the following conditions are met:
// wenc	
// ptrq	  * Redistribution's of source code must retain the above copyright notice,
// gzoz	    this list of conditions and the following disclaimer.
// plgz	
// gils	  * Redistribution's in binary form must reproduce the above copyright notice,
// njgf	    this list of conditions and the following disclaimer in the documentation
// pcfg	    and/or other materials provided with the distribution.
// euvv	
// lnyh	  * Neither the name of the copyright holders nor the names of its contributors 
// epko	    may not be used to endorse or promote products derived from this software 
// wxhu	    without specific prior written permission.
// uwkf	
// lglv	This software is provided by the copyright holders and contributors "as is" and
// miim	any express or implied warranties, including, but not limited to, the implied
// xinn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ollm	In no event shall the Prince of Songkla University or contributors be liable 
// dsnb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mzuq	(including, but not limited to, procurement of substitute goods or services;
// ywvp	loss of use, data, or profits; or business interruption) however caused
// cllt	and on any theory of liability, whether in contract, strict liability,
// rzuy	or tort (including negligence or otherwise) arising in any way out of
// iajd	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Server;

namespace Vs.Monitor
{
    public partial class VsRecordSetting : UserControl
    {
        private VsMonitor vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsRecordSetting()
        {
            InitializeComponent();
        }

        public VsMonitor Monitor
        {
            set
            {
                vsMonitor = value;
            }
        }

        public VsCoreServer CoreMonitor
        {
            set { vsCoreMonitor = value; }
        }
    }
}
