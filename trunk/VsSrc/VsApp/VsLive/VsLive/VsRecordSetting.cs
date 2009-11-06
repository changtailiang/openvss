// wozl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wwuz	
// pzwi	 By downloading, copying, installing or using the software you agree to this license.
// wnwu	 If you do not agree to this license, do not download, install,
// mcwf	 copy or use the software.
// cqpp	
// miyf	                          License Agreement
// jjqn	         For OpenVss - Open Source Video Surveillance System
// jxep	
// fbad	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jfxd	
// dbiu	Third party copyrights are property of their respective owners.
// gdre	
// mdbg	Redistribution and use in source and binary forms, with or without modification,
// zkzo	are permitted provided that the following conditions are met:
// yoqf	
// iizy	  * Redistribution's of source code must retain the above copyright notice,
// igol	    this list of conditions and the following disclaimer.
// btvx	
// smmk	  * Redistribution's in binary form must reproduce the above copyright notice,
// zdyg	    this list of conditions and the following disclaimer in the documentation
// smbf	    and/or other materials provided with the distribution.
// wypv	
// cmfu	  * Neither the name of the copyright holders nor the names of its contributors 
// prvu	    may not be used to endorse or promote products derived from this software 
// bkla	    without specific prior written permission.
// ogdt	
// henn	This software is provided by the copyright holders and contributors "as is" and
// yopu	any express or implied warranties, including, but not limited to, the implied
// pknw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// huck	In no event shall the Prince of Songkla University or contributors be liable 
// qtip	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nbib	(including, but not limited to, procurement of substitute goods or services;
// qrjp	loss of use, data, or profits; or business interruption) however caused
// ryrl	and on any theory of liability, whether in contract, strict liability,
// jixs	or tort (including negligence or otherwise) arising in any way out of
// lcxo	the use of this software, even if advised of the possibility of such damage.

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
