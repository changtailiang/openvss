// srmj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wtjp	
// ipnp	 By downloading, copying, installing or using the software you agree to this license.
// qyqa	 If you do not agree to this license, do not download, install,
// sqpd	 copy or use the software.
// jemq	
// zhni	                          License Agreement
// wwnl	         For OpenVSS - Open Source Video Surveillance System
// ziyw	
// aysu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// smwi	
// ousz	Third party copyrights are property of their respective owners.
// ltup	
// ydon	Redistribution and use in source and binary forms, with or without modification,
// fwko	are permitted provided that the following conditions are met:
// fbtm	
// cbqh	  * Redistribution's of source code must retain the above copyright notice,
// ztau	    this list of conditions and the following disclaimer.
// yvlx	
// idbf	  * Redistribution's in binary form must reproduce the above copyright notice,
// pnwd	    this list of conditions and the following disclaimer in the documentation
// cxnw	    and/or other materials provided with the distribution.
// tlrd	
// odor	  * Neither the name of the copyright holders nor the names of its contributors 
// tjgm	    may not be used to endorse or promote products derived from this software 
// dkar	    without specific prior written permission.
// szqc	
// rrfb	This software is provided by the copyright holders and contributors "as is" and
// uezs	any express or implied warranties, including, but not limited to, the implied
// eqke	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ouoo	In no event shall the Prince of Songkla University or contributors be liable 
// cxfv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// htey	(including, but not limited to, procurement of substitute goods or services;
// xpbe	loss of use, data, or profits; or business interruption) however caused
// mekc	and on any theory of liability, whether in contract, strict liability,
// hkec	or tort (including negligence or otherwise) arising in any way out of
// gqij	the use of this software, even if advised of the possibility of such damage.
// dvmc	
// zbxj	Intelligent Systems Laboratory (iSys Lab)
// wmpv	Faculty of Engineering, Prince of Songkla University, THAILAND
// tuvx	Project leader by Nikom SUVONVORN
// ngdf	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.RtpStream
{
	using System;

	/// <summary>
	/// StreamConfiguration
	/// </summary>
	public class RtpStreamConfiguration
	{
		public string source;
        public string dest;
        public string ssrc;
        public int video_port;
        public int audio_port;
        public string video_codec;
        public string audio_codec;
        public int video_width;
        public int video_height;
        public int video_quality;
	}
}
