// pqmt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ewyr	
// dges	 By downloading, copying, installing or using the software you agree to this license.
// wtxo	 If you do not agree to this license, do not download, install,
// zarc	 copy or use the software.
// qpmj	
// lror	                          License Agreement
// peyf	         For OpenVSS - Open Source Video Surveillance System
// bkog	
// qyjc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dnrv	
// ovfo	Third party copyrights are property of their respective owners.
// zsyq	
// ktoz	Redistribution and use in source and binary forms, with or without modification,
// edhm	are permitted provided that the following conditions are met:
// hgcy	
// hzql	  * Redistribution's of source code must retain the above copyright notice,
// erya	    this list of conditions and the following disclaimer.
// rpzc	
// yruq	  * Redistribution's in binary form must reproduce the above copyright notice,
// masw	    this list of conditions and the following disclaimer in the documentation
// giuh	    and/or other materials provided with the distribution.
// wpcm	
// qxux	  * Neither the name of the copyright holders nor the names of its contributors 
// lsnp	    may not be used to endorse or promote products derived from this software 
// etki	    without specific prior written permission.
// uyyv	
// ulbm	This software is provided by the copyright holders and contributors "as is" and
// jrah	any express or implied warranties, including, but not limited to, the implied
// nfsz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// eipp	In no event shall the Prince of Songkla University or contributors be liable 
// plju	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ucrf	(including, but not limited to, procurement of substitute goods or services;
// dels	loss of use, data, or profits; or business interruption) however caused
// pkci	and on any theory of liability, whether in contract, strict liability,
// jznl	or tort (including negligence or otherwise) arising in any way out of
// npdz	the use of this software, even if advised of the possibility of such damage.
// wnjf	
// aolw	Intelligent Systems Laboratory (iSys Lab)
// euti	Faculty of Engineering, Prince of Songkla University, THAILAND
// oeas	Project leader by Nikom SUVONVORN
// twje	Project website at http://code.google.com/p/openvss/

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
