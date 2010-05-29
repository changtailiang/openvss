// jsxb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// shng	
// snec	 By downloading, copying, installing or using the software you agree to this license.
// dwvz	 If you do not agree to this license, do not download, install,
// qtfu	 copy or use the software.
// lvjl	
// bzkj	                          License Agreement
// huep	         For OpenVSS - Open Source Video Surveillance System
// wgso	
// qmld	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fksh	
// veyy	Third party copyrights are property of their respective owners.
// ypih	
// datn	Redistribution and use in source and binary forms, with or without modification,
// jlat	are permitted provided that the following conditions are met:
// xdzy	
// iogw	  * Redistribution's of source code must retain the above copyright notice,
// egjd	    this list of conditions and the following disclaimer.
// ibpb	
// dcqw	  * Redistribution's in binary form must reproduce the above copyright notice,
// amls	    this list of conditions and the following disclaimer in the documentation
// lwmv	    and/or other materials provided with the distribution.
// nffe	
// lsgb	  * Neither the name of the copyright holders nor the names of its contributors 
// kuyh	    may not be used to endorse or promote products derived from this software 
// xctr	    without specific prior written permission.
// gezc	
// lrjg	This software is provided by the copyright holders and contributors "as is" and
// udsk	any express or implied warranties, including, but not limited to, the implied
// sgmm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cljz	In no event shall the Prince of Songkla University or contributors be liable 
// aesp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// unrj	(including, but not limited to, procurement of substitute goods or services;
// ejyy	loss of use, data, or profits; or business interruption) however caused
// stmh	and on any theory of liability, whether in contract, strict liability,
// xjkw	or tort (including negligence or otherwise) arising in any way out of
// vzkh	the use of this software, even if advised of the possibility of such damage.
// zvje	
// imem	Intelligent Systems Laboratory (iSys Lab)
// ttqc	Faculty of Engineering, Prince of Songkla University, THAILAND
// mjhy	Project leader by Nikom SUVONVORN
// aack	Project website at http://code.google.com/p/openvss/

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
    public partial class VsSettingTool : UserControl
    {
        private VsScanner vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsSettingTool()
        {
            InitializeComponent();
        }

        public VsScanner Monitor
        {
            set
            {
                vsMonitor = value;
                // set reference to application control
                this.vsGeneralSetting1.Monitor = value;
                this.vsGeneralSetting1.CoreMonitor = vsCoreMonitor;

                // set reference to property control
                this.vsRecordSetting1.Monitor = value;
                this.vsRecordSetting1.CoreMonitor = vsCoreMonitor;
            }
        }

        public VsCoreServer CoreMonitor
        {
            set { vsCoreMonitor = value; }
        }

        private void buttonGeneral_Click(object sender, EventArgs e)
        {
            this.vsGeneralSetting1.Visible = true;
            this.vsRecordSetting1.Visible = false;
        }

        private void buttonRecording_Click(object sender, EventArgs e)
        {
            this.vsGeneralSetting1.Visible = false;
            this.vsRecordSetting1.Visible = true;
        }
    }
}
