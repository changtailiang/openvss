// zvxe	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vxha	
// zoyu	 By downloading, copying, installing or using the software you agree to this license.
// cjis	 If you do not agree to this license, do not download, install,
// baeq	 copy or use the software.
// hzso	
// yybm	                          License Agreement
// snrz	         For OpenVSS - Open Source Video Surveillance System
// wjto	
// ampt	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vnow	
// vwbz	Third party copyrights are property of their respective owners.
// idhb	
// oogz	Redistribution and use in source and binary forms, with or without modification,
// difx	are permitted provided that the following conditions are met:
// vvil	
// xyxs	  * Redistribution's of source code must retain the above copyright notice,
// ptrp	    this list of conditions and the following disclaimer.
// lkvu	
// lvtc	  * Redistribution's in binary form must reproduce the above copyright notice,
// wcep	    this list of conditions and the following disclaimer in the documentation
// gpli	    and/or other materials provided with the distribution.
// dtls	
// gsya	  * Neither the name of the copyright holders nor the names of its contributors 
// eczw	    may not be used to endorse or promote products derived from this software 
// yjjo	    without specific prior written permission.
// lsqd	
// tmnh	This software is provided by the copyright holders and contributors "as is" and
// pdas	any express or implied warranties, including, but not limited to, the implied
// qteh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// npov	In no event shall the Prince of Songkla University or contributors be liable 
// izis	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mupj	(including, but not limited to, procurement of substitute goods or services;
// vwdn	loss of use, data, or profits; or business interruption) however caused
// spdo	and on any theory of liability, whether in contract, strict liability,
// zipq	or tort (including negligence or otherwise) arising in any way out of
// gecd	the use of this software, even if advised of the possibility of such damage.
// sfkk	
// xsjj	Intelligent Systems Laboratory (iSys Lab)
// ungl	Faculty of Engineering, Prince of Songkla University, THAILAND
// jxqz	Project leader by Nikom SUVONVORN
// wels	Project website at http://code.google.com/p/openvss/

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
        private VsScanner vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public VsRecordSetting()
        {
            InitializeComponent();
        }

        public VsScanner Monitor
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
