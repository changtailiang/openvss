// huni	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xqid	
// bqzq	 By downloading, copying, installing or using the software you agree to this license.
// binc	 If you do not agree to this license, do not download, install,
// shkp	 copy or use the software.
// mqid	
// jgmi	                          License Agreement
// zkec	         For OpenVSS - Open Source Video Surveillance System
// xccx	
// waul	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fpbz	
// muhb	Third party copyrights are property of their respective owners.
// iwiu	
// lrhr	Redistribution and use in source and binary forms, with or without modification,
// lkzq	are permitted provided that the following conditions are met:
// eaer	
// lxtz	  * Redistribution's of source code must retain the above copyright notice,
// gqfs	    this list of conditions and the following disclaimer.
// nzkw	
// piqp	  * Redistribution's in binary form must reproduce the above copyright notice,
// zkzc	    this list of conditions and the following disclaimer in the documentation
// bkqg	    and/or other materials provided with the distribution.
// vkll	
// adgf	  * Neither the name of the copyright holders nor the names of its contributors 
// ljoo	    may not be used to endorse or promote products derived from this software 
// bhvs	    without specific prior written permission.
// qphm	
// hkcd	This software is provided by the copyright holders and contributors "as is" and
// ujrt	any express or implied warranties, including, but not limited to, the implied
// abpa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hmev	In no event shall the Prince of Songkla University or contributors be liable 
// furj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// self	(including, but not limited to, procurement of substitute goods or services;
// ucnr	loss of use, data, or profits; or business interruption) however caused
// ohml	and on any theory of liability, whether in contract, strict liability,
// ddzk	or tort (including negligence or otherwise) arising in any way out of
// ihqq	the use of this software, even if advised of the possibility of such damage.
// mnfk	
// ungo	Intelligent Systems Laboratory (iSys Lab)
// danv	Faculty of Engineering, Prince of Songkla University, THAILAND
// yxtc	Project leader by Nikom SUVONVORN
// zwjs	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using VsCoreMobile.VsService;

namespace VsCoreMobile
{
    public interface VsIDataConnect
    {
        List<VsCamera> getCamAll();
    }
}
