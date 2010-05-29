// ppnq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hnwn	
// blyc	 By downloading, copying, installing or using the software you agree to this license.
// fdop	 If you do not agree to this license, do not download, install,
// nkhd	 copy or use the software.
// witc	
// bsra	                          License Agreement
// tczt	         For OpenVSS - Open Source Video Surveillance System
// dyqi	
// vysz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zxhk	
// okku	Third party copyrights are property of their respective owners.
// vcyo	
// mahg	Redistribution and use in source and binary forms, with or without modification,
// wkop	are permitted provided that the following conditions are met:
// vvtz	
// leyg	  * Redistribution's of source code must retain the above copyright notice,
// mgto	    this list of conditions and the following disclaimer.
// rhdy	
// bjnr	  * Redistribution's in binary form must reproduce the above copyright notice,
// hxfr	    this list of conditions and the following disclaimer in the documentation
// dlgd	    and/or other materials provided with the distribution.
// rjml	
// jddd	  * Neither the name of the copyright holders nor the names of its contributors 
// dhyk	    may not be used to endorse or promote products derived from this software 
// ldhp	    without specific prior written permission.
// ijwf	
// wjfm	This software is provided by the copyright holders and contributors "as is" and
// wxhy	any express or implied warranties, including, but not limited to, the implied
// qcwz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xvpc	In no event shall the Prince of Songkla University or contributors be liable 
// tien	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eaut	(including, but not limited to, procurement of substitute goods or services;
// kdgd	loss of use, data, or profits; or business interruption) however caused
// pqit	and on any theory of liability, whether in contract, strict liability,
// pbgh	or tort (including negligence or otherwise) arising in any way out of
// ezom	the use of this software, even if advised of the possibility of such damage.
// wfmb	
// lzmp	Intelligent Systems Laboratory (iSys Lab)
// ofvz	Faculty of Engineering, Prince of Songkla University, THAILAND
// ejaw	Project leader by Nikom SUVONVORN
// omct	Project website at http://code.google.com/p/openvss/

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
