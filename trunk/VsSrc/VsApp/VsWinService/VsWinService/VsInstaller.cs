// adll	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// snnb	
// ptwy	 By downloading, copying, installing or using the software you agree to this license.
// ltua	 If you do not agree to this license, do not download, install,
// gmzr	 copy or use the software.
// piue	
// cfif	                          License Agreement
// oqsa	         For OpenVSS - Open Source Video Surveillance System
// xnud	
// prln	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tugv	
// ehry	Third party copyrights are property of their respective owners.
// urzr	
// ekas	Redistribution and use in source and binary forms, with or without modification,
// jgim	are permitted provided that the following conditions are met:
// einz	
// avby	  * Redistribution's of source code must retain the above copyright notice,
// yrlo	    this list of conditions and the following disclaimer.
// bmyv	
// bzau	  * Redistribution's in binary form must reproduce the above copyright notice,
// nkkw	    this list of conditions and the following disclaimer in the documentation
// qawm	    and/or other materials provided with the distribution.
// mcui	
// jyjl	  * Neither the name of the copyright holders nor the names of its contributors 
// ghui	    may not be used to endorse or promote products derived from this software 
// gtzd	    without specific prior written permission.
// gkps	
// meqk	This software is provided by the copyright holders and contributors "as is" and
// gnyu	any express or implied warranties, including, but not limited to, the implied
// xqia	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zolw	In no event shall the Prince of Songkla University or contributors be liable 
// xcfc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cmpu	(including, but not limited to, procurement of substitute goods or services;
// ernu	loss of use, data, or profits; or business interruption) however caused
// khqg	and on any theory of liability, whether in contract, strict liability,
// kdah	or tort (including negligence or otherwise) arising in any way out of
// ljcv	the use of this software, even if advised of the possibility of such damage.
// aonq	
// yuis	Intelligent Systems Laboratory (iSys Lab)
// hdfd	Faculty of Engineering, Prince of Songkla University, THAILAND
// fnpz	Project leader by Nikom SUVONVORN
// pwfo	Project website at http://code.google.com/p/openvss/

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
