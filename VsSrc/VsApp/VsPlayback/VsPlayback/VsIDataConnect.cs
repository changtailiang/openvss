// qbde	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rmrd	
// qsfs	 By downloading, copying, installing or using the software you agree to this license.
// iagd	 If you do not agree to this license, do not download, install,
// odvf	 copy or use the software.
// jicw	
// mzwp	                          License Agreement
// hqlo	         For OpenVss - Open Source Video Surveillance System
// buom	
// vdgy	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xodt	
// ybbi	Third party copyrights are property of their respective owners.
// jqtv	
// uzti	Redistribution and use in source and binary forms, with or without modification,
// zhss	are permitted provided that the following conditions are met:
// qcwa	
// grro	  * Redistribution's of source code must retain the above copyright notice,
// luik	    this list of conditions and the following disclaimer.
// xxhv	
// eiyk	  * Redistribution's in binary form must reproduce the above copyright notice,
// yngq	    this list of conditions and the following disclaimer in the documentation
// wqtb	    and/or other materials provided with the distribution.
// afmo	
// lniv	  * Neither the name of the copyright holders nor the names of its contributors 
// rdnh	    may not be used to endorse or promote products derived from this software 
// kmwo	    without specific prior written permission.
// ijxx	
// rxeq	This software is provided by the copyright holders and contributors "as is" and
// ihuc	any express or implied warranties, including, but not limited to, the implied
// vgdq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xpng	In no event shall the Prince of Songkla University or contributors be liable 
// huyj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oleb	(including, but not limited to, procurement of substitute goods or services;
// vrzl	loss of use, data, or profits; or business interruption) however caused
// qshn	and on any theory of liability, whether in contract, strict liability,
// swkd	or tort (including negligence or otherwise) arising in any way out of
// bvfe	the use of this software, even if advised of the possibility of such damage.

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
