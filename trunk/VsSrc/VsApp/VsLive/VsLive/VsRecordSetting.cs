// rbud	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jgxp	
// idsu	 By downloading, copying, installing or using the software you agree to this license.
// zfec	 If you do not agree to this license, do not download, install,
// sver	 copy or use the software.
// raki	
// wicm	                          License Agreement
// svec	         For OpenVSS - Open Source Video Surveillance System
// lzdq	
// nyjj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mbcn	
// eezj	Third party copyrights are property of their respective owners.
// mbvl	
// ynxr	Redistribution and use in source and binary forms, with or without modification,
// rlga	are permitted provided that the following conditions are met:
// dkwn	
// yqiz	  * Redistribution's of source code must retain the above copyright notice,
// boou	    this list of conditions and the following disclaimer.
// mvfq	
// xxes	  * Redistribution's in binary form must reproduce the above copyright notice,
// itar	    this list of conditions and the following disclaimer in the documentation
// ztdy	    and/or other materials provided with the distribution.
// cmzc	
// sifb	  * Neither the name of the copyright holders nor the names of its contributors 
// epoo	    may not be used to endorse or promote products derived from this software 
// vahx	    without specific prior written permission.
// nbzd	
// ihtu	This software is provided by the copyright holders and contributors "as is" and
// hnsk	any express or implied warranties, including, but not limited to, the implied
// kfnf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mkxp	In no event shall the Prince of Songkla University or contributors be liable 
// pmce	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pemh	(including, but not limited to, procurement of substitute goods or services;
// ipwi	loss of use, data, or profits; or business interruption) however caused
// lcey	and on any theory of liability, whether in contract, strict liability,
// uaqv	or tort (including negligence or otherwise) arising in any way out of
// tfue	the use of this software, even if advised of the possibility of such damage.
// purz	
// cjbl	Intelligent Systems Laboratory (iSys Lab)
// csia	Faculty of Engineering, Prince of Songkla University, THAILAND
// yvnd	Project leader by Nikom SUVONVORN
// ullr	Project website at http://code.google.com/p/openvss/

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
        private VsLive vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsRecordSetting()
        {
            InitializeComponent();
        }

        public VsLive Monitor
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
