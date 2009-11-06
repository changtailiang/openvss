// mxes	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oahh	
// ihjf	 By downloading, copying, installing or using the software you agree to this license.
// rrqs	 If you do not agree to this license, do not download, install,
// vygy	 copy or use the software.
// fobf	
// viqa	                          License Agreement
// cmqg	         For OpenVss - Open Source Video Surveillance System
// mcki	
// zxvo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ngin	
// ofnd	Third party copyrights are property of their respective owners.
// mqpl	
// pusx	Redistribution and use in source and binary forms, with or without modification,
// vzxf	are permitted provided that the following conditions are met:
// khfw	
// rdto	  * Redistribution's of source code must retain the above copyright notice,
// hisx	    this list of conditions and the following disclaimer.
// drly	
// gnqp	  * Redistribution's in binary form must reproduce the above copyright notice,
// vmnm	    this list of conditions and the following disclaimer in the documentation
// xfrr	    and/or other materials provided with the distribution.
// kmma	
// apef	  * Neither the name of the copyright holders nor the names of its contributors 
// bmwl	    may not be used to endorse or promote products derived from this software 
// mywd	    without specific prior written permission.
// yrhx	
// juri	This software is provided by the copyright holders and contributors "as is" and
// ihky	any express or implied warranties, including, but not limited to, the implied
// tsym	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lbeu	In no event shall the Prince of Songkla University or contributors be liable 
// wrxn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nfwt	(including, but not limited to, procurement of substitute goods or services;
// rfdx	loss of use, data, or profits; or business interruption) however caused
// pjnf	and on any theory of liability, whether in contract, strict liability,
// xuip	or tort (including negligence or otherwise) arising in any way out of
// vert	the use of this software, even if advised of the possibility of such damage.

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
