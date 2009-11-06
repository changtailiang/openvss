// xtie	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// krgl	
// kahz	 By downloading, copying, installing or using the software you agree to this license.
// gdyl	 If you do not agree to this license, do not download, install,
// qjtu	 copy or use the software.
// ndvm	
// dmzt	                          License Agreement
// necc	         For OpenVss - Open Source Video Surveillance System
// xgis	
// cuva	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// naho	
// nndq	Third party copyrights are property of their respective owners.
// esqy	
// tkeu	Redistribution and use in source and binary forms, with or without modification,
// yvay	are permitted provided that the following conditions are met:
// rnyf	
// xfba	  * Redistribution's of source code must retain the above copyright notice,
// vfjv	    this list of conditions and the following disclaimer.
// otgm	
// wgyq	  * Redistribution's in binary form must reproduce the above copyright notice,
// iipu	    this list of conditions and the following disclaimer in the documentation
// oein	    and/or other materials provided with the distribution.
// coug	
// uwia	  * Neither the name of the copyright holders nor the names of its contributors 
// cbqh	    may not be used to endorse or promote products derived from this software 
// mdvy	    without specific prior written permission.
// jvja	
// dryr	This software is provided by the copyright holders and contributors "as is" and
// wkpi	any express or implied warranties, including, but not limited to, the implied
// ydrt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xnxg	In no event shall the Prince of Songkla University or contributors be liable 
// lcbr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kgku	(including, but not limited to, procurement of substitute goods or services;
// pqef	loss of use, data, or profits; or business interruption) however caused
// nqls	and on any theory of liability, whether in contract, strict liability,
// vhkl	or tort (including negligence or otherwise) arising in any way out of
// pdjj	the use of this software, even if advised of the possibility of such damage.

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
