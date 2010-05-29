// gkiq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// laoj	
// lzde	 By downloading, copying, installing or using the software you agree to this license.
// reof	 If you do not agree to this license, do not download, install,
// fozm	 copy or use the software.
// pnft	
// krjl	                          License Agreement
// edgl	         For OpenVSS - Open Source Video Surveillance System
// wwoc	
// vpwk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bxqu	
// sjnz	Third party copyrights are property of their respective owners.
// mxiz	
// ugms	Redistribution and use in source and binary forms, with or without modification,
// epgu	are permitted provided that the following conditions are met:
// rceh	
// srhv	  * Redistribution's of source code must retain the above copyright notice,
// pmkp	    this list of conditions and the following disclaimer.
// rokr	
// xlaa	  * Redistribution's in binary form must reproduce the above copyright notice,
// djyh	    this list of conditions and the following disclaimer in the documentation
// uhqq	    and/or other materials provided with the distribution.
// jvxg	
// jcty	  * Neither the name of the copyright holders nor the names of its contributors 
// sibb	    may not be used to endorse or promote products derived from this software 
// brja	    without specific prior written permission.
// nthg	
// vuvt	This software is provided by the copyright holders and contributors "as is" and
// ofqh	any express or implied warranties, including, but not limited to, the implied
// dxml	warranties of merchantability and fitness for a particular purpose are disclaimed.
// aqlu	In no event shall the Prince of Songkla University or contributors be liable 
// odgo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// umyo	(including, but not limited to, procurement of substitute goods or services;
// jzyl	loss of use, data, or profits; or business interruption) however caused
// zytb	and on any theory of liability, whether in contract, strict liability,
// akvp	or tort (including negligence or otherwise) arising in any way out of
// aerd	the use of this software, even if advised of the possibility of such damage.
// mlvv	
// wpal	Intelligent Systems Laboratory (iSys Lab)
// fpmj	Faculty of Engineering, Prince of Songkla University, THAILAND
// mslj	Project leader by Nikom SUVONVORN
// vgjp	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Panasonic
{
	using System;
    using Vs.Core.Provider;

	/// <summary>
	/// PixordConfiguration
	/// </summary>
	public class PanasonicConfiguration
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
