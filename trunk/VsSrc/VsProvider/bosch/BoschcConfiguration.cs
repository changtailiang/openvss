// ymdx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lrbf	
// cpvv	 By downloading, copying, installing or using the software you agree to this license.
// ueag	 If you do not agree to this license, do not download, install,
// jike	 copy or use the software.
// nxwa	
// uiwj	                          License Agreement
// fejp	         For OpenVss - Open Source Video Surveillance System
// kywu	
// fjzl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dwko	
// gdmo	Third party copyrights are property of their respective owners.
// lkwy	
// gdyb	Redistribution and use in source and binary forms, with or without modification,
// pdcc	are permitted provided that the following conditions are met:
// urzy	
// gfkv	  * Redistribution's of source code must retain the above copyright notice,
// ifbz	    this list of conditions and the following disclaimer.
// jyar	
// miur	  * Redistribution's in binary form must reproduce the above copyright notice,
// vhyv	    this list of conditions and the following disclaimer in the documentation
// hlih	    and/or other materials provided with the distribution.
// zvfb	
// gwrm	  * Neither the name of the copyright holders nor the names of its contributors 
// wmha	    may not be used to endorse or promote products derived from this software 
// srgg	    without specific prior written permission.
// jwoi	
// dhog	This software is provided by the copyright holders and contributors "as is" and
// jlgm	any express or implied warranties, including, but not limited to, the implied
// teqv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wdvm	In no event shall the Prince of Songkla University or contributors be liable 
// zzsn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gnua	(including, but not limited to, procurement of substitute goods or services;
// btye	loss of use, data, or profits; or business interruption) however caused
// asll	and on any theory of liability, whether in contract, strict liability,
// xads	or tort (including negligence or otherwise) arising in any way out of
// hzsv	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Bosch
{
	using System;
    using Vs.Core.Provider;

	/// <summary>
	/// PixordConfiguration
	/// </summary>
	public class BoschConfiguration
	{
		public string	source;
		public string	login;
		public string	password;
		public int		frameInterval = 0;
		public StreamType	stremType = StreamType.Jpeg;
		public string	resolution;
		public string	quality;
	}
}
