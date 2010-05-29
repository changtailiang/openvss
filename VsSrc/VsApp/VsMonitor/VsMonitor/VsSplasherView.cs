// agah	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zwrj	
// bveb	 By downloading, copying, installing or using the software you agree to this license.
// glxn	 If you do not agree to this license, do not download, install,
// whoi	 copy or use the software.
// uehn	
// sgwl	                          License Agreement
// htsy	         For OpenVSS - Open Source Video Surveillance System
// lmbt	
// kavq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fuqt	
// cvcr	Third party copyrights are property of their respective owners.
// hqhg	
// quyw	Redistribution and use in source and binary forms, with or without modification,
// ympt	are permitted provided that the following conditions are met:
// agci	
// dgpt	  * Redistribution's of source code must retain the above copyright notice,
// kdcv	    this list of conditions and the following disclaimer.
// mycz	
// oolw	  * Redistribution's in binary form must reproduce the above copyright notice,
// eedq	    this list of conditions and the following disclaimer in the documentation
// mmhr	    and/or other materials provided with the distribution.
// oeuy	
// lbqz	  * Neither the name of the copyright holders nor the names of its contributors 
// shqv	    may not be used to endorse or promote products derived from this software 
// gigd	    without specific prior written permission.
// nlur	
// syik	This software is provided by the copyright holders and contributors "as is" and
// bspv	any express or implied warranties, including, but not limited to, the implied
// clwq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zyff	In no event shall the Prince of Songkla University or contributors be liable 
// jekk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ichg	(including, but not limited to, procurement of substitute goods or services;
// xqqv	loss of use, data, or profits; or business interruption) however caused
// yzda	and on any theory of liability, whether in contract, strict liability,
// rpzp	or tort (including negligence or otherwise) arising in any way out of
// wkxs	the use of this software, even if advised of the possibility of such damage.
// mvxg	
// lzwi	Intelligent Systems Laboratory (iSys Lab)
// cbuj	Faculty of Engineering, Prince of Songkla University, THAILAND
// bkjp	Project leader by Nikom SUVONVORN
// rcml	Project website at http://code.google.com/p/openvss/

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
