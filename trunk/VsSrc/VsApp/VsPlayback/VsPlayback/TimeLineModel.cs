// nqre	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mzdf	
// orpc	 By downloading, copying, installing or using the software you agree to this license.
// ldhw	 If you do not agree to this license, do not download, install,
// bgrl	 copy or use the software.
// evub	
// vldb	                          License Agreement
// isjd	         For OpenVSS - Open Source Video Surveillance System
// kvwf	
// aaez	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cmoh	
// xfnn	Third party copyrights are property of their respective owners.
// ccoz	
// wgfr	Redistribution and use in source and binary forms, with or without modification,
// vpia	are permitted provided that the following conditions are met:
// vcww	
// hlsq	  * Redistribution's of source code must retain the above copyright notice,
// gcwb	    this list of conditions and the following disclaimer.
// csis	
// gndp	  * Redistribution's in binary form must reproduce the above copyright notice,
// ypyg	    this list of conditions and the following disclaimer in the documentation
// ejhe	    and/or other materials provided with the distribution.
// qejk	
// rdda	  * Neither the name of the copyright holders nor the names of its contributors 
// pszm	    may not be used to endorse or promote products derived from this software 
// nwha	    without specific prior written permission.
// gnxd	
// ymli	This software is provided by the copyright holders and contributors "as is" and
// mscf	any express or implied warranties, including, but not limited to, the implied
// dqrx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dnab	In no event shall the Prince of Songkla University or contributors be liable 
// sljy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ohcn	(including, but not limited to, procurement of substitute goods or services;
// nrcb	loss of use, data, or profits; or business interruption) however caused
// iyar	and on any theory of liability, whether in contract, strict liability,
// mefd	or tort (including negligence or otherwise) arising in any way out of
// tayy	the use of this software, even if advised of the possibility of such damage.
// bxwz	
// bbiz	Intelligent Systems Laboratory (iSys Lab)
// wfhu	Faculty of Engineering, Prince of Songkla University, THAILAND
// dypq	Project leader by Nikom SUVONVORN
// jxvv	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using Vs.Playback.VsService;

namespace Vs.Playback
{
    class TimeLineModel
    {
        Dictionary<DateTime, DateTime> timeData;
        VsMotion[] motions;

        DateTime timeStart;
        DateTime timeEnd;

        string camID;
        string camName;

        public TimeLineModel()
        {
            timeData = new Dictionary<DateTime, DateTime>();
        }

        public TimeLineModel(string camName, VsMotion[] motions)
        {
            this.camName = camName;
            this.motions = motions;
            timeData = new Dictionary<DateTime, DateTime>();
        }

    }
}
