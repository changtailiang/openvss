// kgwu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ukir	
// qhvn	 By downloading, copying, installing or using the software you agree to this license.
// vytn	 If you do not agree to this license, do not download, install,
// afdk	 copy or use the software.
// pofs	
// jcob	                          License Agreement
// zzpg	         For OpenVss - Open Source Video Surveillance System
// kzaa	
// lkmh	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xlpj	
// lfnf	Third party copyrights are property of their respective owners.
// gedx	
// tjhv	Redistribution and use in source and binary forms, with or without modification,
// bekr	are permitted provided that the following conditions are met:
// whsr	
// rodv	  * Redistribution's of source code must retain the above copyright notice,
// xtcq	    this list of conditions and the following disclaimer.
// twne	
// yvhe	  * Redistribution's in binary form must reproduce the above copyright notice,
// piuu	    this list of conditions and the following disclaimer in the documentation
// vsna	    and/or other materials provided with the distribution.
// seyh	
// zukp	  * Neither the name of the copyright holders nor the names of its contributors 
// tyrw	    may not be used to endorse or promote products derived from this software 
// crhn	    without specific prior written permission.
// bnex	
// vcwf	This software is provided by the copyright holders and contributors "as is" and
// wgcn	any express or implied warranties, including, but not limited to, the implied
// mxvz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bcds	In no event shall the Prince of Songkla University or contributors be liable 
// uvry	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lxla	(including, but not limited to, procurement of substitute goods or services;
// elbx	loss of use, data, or profits; or business interruption) however caused
// agti	and on any theory of liability, whether in contract, strict liability,
// oqeq	or tort (including negligence or otherwise) arising in any way out of
// hsks	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Vs.WinService
{
    [RunInstaller(true)]
    public partial class VsInstaller : Installer
    {
        public VsInstaller()
        {
            InitializeComponent();
        }
    }
}
