// yuaa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// khai	
// ckzl	 By downloading, copying, installing or using the software you agree to this license.
// oykl	 If you do not agree to this license, do not download, install,
// jifz	 copy or use the software.
// jxba	
// hsxe	                          License Agreement
// uetx	         For OpenVss - Open Source Video Surveillance System
// ausp	
// bwav	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// fpen	
// axnj	Third party copyrights are property of their respective owners.
// afjo	
// oqra	Redistribution and use in source and binary forms, with or without modification,
// sztr	are permitted provided that the following conditions are met:
// jvoy	
// qblu	  * Redistribution's of source code must retain the above copyright notice,
// fvkm	    this list of conditions and the following disclaimer.
// ijut	
// toaj	  * Redistribution's in binary form must reproduce the above copyright notice,
// eneo	    this list of conditions and the following disclaimer in the documentation
// ufjj	    and/or other materials provided with the distribution.
// crwb	
// dilk	  * Neither the name of the copyright holders nor the names of its contributors 
// bfxy	    may not be used to endorse or promote products derived from this software 
// msde	    without specific prior written permission.
// vxgf	
// wxhe	This software is provided by the copyright holders and contributors "as is" and
// zjmw	any express or implied warranties, including, but not limited to, the implied
// rzek	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sbro	In no event shall the Prince of Songkla University or contributors be liable 
// yija	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xkrn	(including, but not limited to, procurement of substitute goods or services;
// qcxm	loss of use, data, or profits; or business interruption) however caused
// kztx	and on any theory of liability, whether in contract, strict liability,
// zdnf	or tort (including negligence or otherwise) arising in any way out of
// kscu	the use of this software, even if advised of the possibility of such damage.

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
