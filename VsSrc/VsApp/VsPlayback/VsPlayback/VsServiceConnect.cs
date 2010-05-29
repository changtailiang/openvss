// phym	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// htlr	
// kbtj	 By downloading, copying, installing or using the software you agree to this license.
// idtf	 If you do not agree to this license, do not download, install,
// zumj	 copy or use the software.
// swnh	
// mpyv	                          License Agreement
// cyru	         For OpenVSS - Open Source Video Surveillance System
// rkea	
// xccc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// obov	
// wvnv	Third party copyrights are property of their respective owners.
// voqq	
// sfbs	Redistribution and use in source and binary forms, with or without modification,
// uras	are permitted provided that the following conditions are met:
// upol	
// kysy	  * Redistribution's of source code must retain the above copyright notice,
// ztix	    this list of conditions and the following disclaimer.
// skur	
// irkq	  * Redistribution's in binary form must reproduce the above copyright notice,
// bdao	    this list of conditions and the following disclaimer in the documentation
// habm	    and/or other materials provided with the distribution.
// imgf	
// ckhy	  * Neither the name of the copyright holders nor the names of its contributors 
// mcly	    may not be used to endorse or promote products derived from this software 
// dpvb	    without specific prior written permission.
// ftyi	
// kkjd	This software is provided by the copyright holders and contributors "as is" and
// gjqr	any express or implied warranties, including, but not limited to, the implied
// paej	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wfpn	In no event shall the Prince of Songkla University or contributors be liable 
// ndui	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cwef	(including, but not limited to, procurement of substitute goods or services;
// fmnm	loss of use, data, or profits; or business interruption) however caused
// iyjo	and on any theory of liability, whether in contract, strict liability,
// ctcy	or tort (including negligence or otherwise) arising in any way out of
// cdyt	the use of this software, even if advised of the possibility of such damage.
// tqil	
// ybbx	Intelligent Systems Laboratory (iSys Lab)
// ziob	Faculty of Engineering, Prince of Songkla University, THAILAND
// zqfn	Project leader by Nikom SUVONVORN
// fexu	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;

namespace Vs.Playback
{
    class VsServiceConnect:VsIDataConnect
    {
        #region IDataConnect Members

        public List<VsService.VsCamera> getCamAll()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
