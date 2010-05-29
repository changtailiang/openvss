// jfce	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// brya	
// pfgz	 By downloading, copying, installing or using the software you agree to this license.
// tlua	 If you do not agree to this license, do not download, install,
// nfrz	 copy or use the software.
// sfwc	
// cerq	                          License Agreement
// nfto	         For OpenVSS - Open Source Video Surveillance System
// kmav	
// jryr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// uffi	
// pjzw	Third party copyrights are property of their respective owners.
// mjjo	
// gwge	Redistribution and use in source and binary forms, with or without modification,
// jabx	are permitted provided that the following conditions are met:
// zhnk	
// lrpg	  * Redistribution's of source code must retain the above copyright notice,
// lzqv	    this list of conditions and the following disclaimer.
// hzfn	
// anms	  * Redistribution's in binary form must reproduce the above copyright notice,
// fved	    this list of conditions and the following disclaimer in the documentation
// vfio	    and/or other materials provided with the distribution.
// gvmj	
// pbsn	  * Neither the name of the copyright holders nor the names of its contributors 
// suxx	    may not be used to endorse or promote products derived from this software 
// tsln	    without specific prior written permission.
// togh	
// qtev	This software is provided by the copyright holders and contributors "as is" and
// njre	any express or implied warranties, including, but not limited to, the implied
// cjog	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jbap	In no event shall the Prince of Songkla University or contributors be liable 
// mgfg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gsuf	(including, but not limited to, procurement of substitute goods or services;
// qoyn	loss of use, data, or profits; or business interruption) however caused
// jqkh	and on any theory of liability, whether in contract, strict liability,
// yaxn	or tort (including negligence or otherwise) arising in any way out of
// rqwg	the use of this software, even if advised of the possibility of such damage.
// joki	
// gqns	Intelligent Systems Laboratory (iSys Lab)
// svam	Faculty of Engineering, Prince of Songkla University, THAILAND
// iaax	Project leader by Nikom SUVONVORN
// yzfy	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace VsMediaProxyServerWinService
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
