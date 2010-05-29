// savr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// sdfj	
// hovh	 By downloading, copying, installing or using the software you agree to this license.
// gbmi	 If you do not agree to this license, do not download, install,
// ypmd	 copy or use the software.
// mfnq	
// zsrr	                          License Agreement
// crcb	         For OpenVSS - Open Source Video Surveillance System
// glep	
// xbyh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nosl	
// fybf	Third party copyrights are property of their respective owners.
// selb	
// ydbn	Redistribution and use in source and binary forms, with or without modification,
// nfra	are permitted provided that the following conditions are met:
// lohp	
// luav	  * Redistribution's of source code must retain the above copyright notice,
// xxkx	    this list of conditions and the following disclaimer.
// qepy	
// nbkb	  * Redistribution's in binary form must reproduce the above copyright notice,
// rlyx	    this list of conditions and the following disclaimer in the documentation
// gbdc	    and/or other materials provided with the distribution.
// kqbs	
// jywz	  * Neither the name of the copyright holders nor the names of its contributors 
// hczl	    may not be used to endorse or promote products derived from this software 
// xgiv	    without specific prior written permission.
// uokt	
// odal	This software is provided by the copyright holders and contributors "as is" and
// vqjz	any express or implied warranties, including, but not limited to, the implied
// pjjk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rykg	In no event shall the Prince of Songkla University or contributors be liable 
// vsns	for any direct, indirect, incidental, special, exemplary, or consequential damages
// iqqk	(including, but not limited to, procurement of substitute goods or services;
// cydl	loss of use, data, or profits; or business interruption) however caused
// ddds	and on any theory of liability, whether in contract, strict liability,
// qjoh	or tort (including negligence or otherwise) arising in any way out of
// qpws	the use of this software, even if advised of the possibility of such damage.
// owjx	
// toty	Intelligent Systems Laboratory (iSys Lab)
// vbzb	Faculty of Engineering, Prince of Songkla University, THAILAND
// aslx	Project leader by Nikom SUVONVORN
// mpjw	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using Vs.Playback.VsService;

namespace Vs.Playback
{
   public interface VsIDataConnect
    {
        List<VsCamera> getCamAll();
    }
}
