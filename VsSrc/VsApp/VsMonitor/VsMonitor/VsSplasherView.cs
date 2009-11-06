// ctws	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// genz	
// lota	 By downloading, copying, installing or using the software you agree to this license.
// lywl	 If you do not agree to this license, do not download, install,
// gntq	 copy or use the software.
// klcc	
// lzsp	                          License Agreement
// fobe	         For OpenVss - Open Source Video Surveillance System
// rqph	
// ieyv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mlrp	
// iaxc	Third party copyrights are property of their respective owners.
// kihc	
// laqr	Redistribution and use in source and binary forms, with or without modification,
// ruhg	are permitted provided that the following conditions are met:
// myux	
// mojv	  * Redistribution's of source code must retain the above copyright notice,
// jodb	    this list of conditions and the following disclaimer.
// pyez	
// tnuk	  * Redistribution's in binary form must reproduce the above copyright notice,
// bpex	    this list of conditions and the following disclaimer in the documentation
// hzsr	    and/or other materials provided with the distribution.
// zxqn	
// wrjn	  * Neither the name of the copyright holders nor the names of its contributors 
// ruct	    may not be used to endorse or promote products derived from this software 
// rctw	    without specific prior written permission.
// efmn	
// vrye	This software is provided by the copyright holders and contributors "as is" and
// axew	any express or implied warranties, including, but not limited to, the implied
// uwqn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vrwl	In no event shall the Prince of Songkla University or contributors be liable 
// xqex	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pqiz	(including, but not limited to, procurement of substitute goods or services;
// kasz	loss of use, data, or profits; or business interruption) however caused
// whsb	and on any theory of liability, whether in contract, strict liability,
// mfvh	or tort (including negligence or otherwise) arising in any way out of
// zmmz	the use of this software, even if advised of the possibility of such damage.

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
