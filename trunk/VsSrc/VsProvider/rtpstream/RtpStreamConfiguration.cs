// qdac	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ipyc	
// anag	 By downloading, copying, installing or using the software you agree to this license.
// cosl	 If you do not agree to this license, do not download, install,
// ixhp	 copy or use the software.
// ivvg	
// mahv	                          License Agreement
// xaip	         For OpenVss - Open Source Video Surveillance System
// cdgz	
// orif	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wnwj	
// lwqu	Third party copyrights are property of their respective owners.
// gmlx	
// sqnv	Redistribution and use in source and binary forms, with or without modification,
// hupi	are permitted provided that the following conditions are met:
// hcfz	
// fkdz	  * Redistribution's of source code must retain the above copyright notice,
// iswr	    this list of conditions and the following disclaimer.
// pbtv	
// zmuq	  * Redistribution's in binary form must reproduce the above copyright notice,
// kmok	    this list of conditions and the following disclaimer in the documentation
// okxm	    and/or other materials provided with the distribution.
// pkst	
// baxt	  * Neither the name of the copyright holders nor the names of its contributors 
// hwdb	    may not be used to endorse or promote products derived from this software 
// sqmo	    without specific prior written permission.
// puiq	
// wswu	This software is provided by the copyright holders and contributors "as is" and
// azyu	any express or implied warranties, including, but not limited to, the implied
// oulu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nqjx	In no event shall the Prince of Songkla University or contributors be liable 
// adqp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eznc	(including, but not limited to, procurement of substitute goods or services;
// jsxt	loss of use, data, or profits; or business interruption) however caused
// azvu	and on any theory of liability, whether in contract, strict liability,
// cgpw	or tort (including negligence or otherwise) arising in any way out of
// oxsb	the use of this software, even if advised of the possibility of such damage.

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
