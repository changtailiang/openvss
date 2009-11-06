// wvhd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lkbr	
// vest	 By downloading, copying, installing or using the software you agree to this license.
// xrhd	 If you do not agree to this license, do not download, install,
// vmik	 copy or use the software.
// bwey	
// xkkh	                          License Agreement
// mykl	         For OpenVss - Open Source Video Surveillance System
// dbeo	
// bfah	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// nfwf	
// pqfx	Third party copyrights are property of their respective owners.
// qxft	
// aivz	Redistribution and use in source and binary forms, with or without modification,
// qifa	are permitted provided that the following conditions are met:
// aufx	
// uhqv	  * Redistribution's of source code must retain the above copyright notice,
// mtcp	    this list of conditions and the following disclaimer.
// lbwv	
// ayjh	  * Redistribution's in binary form must reproduce the above copyright notice,
// fmqo	    this list of conditions and the following disclaimer in the documentation
// sqku	    and/or other materials provided with the distribution.
// gexs	
// azgt	  * Neither the name of the copyright holders nor the names of its contributors 
// azli	    may not be used to endorse or promote products derived from this software 
// ajkx	    without specific prior written permission.
// vqhy	
// mzzs	This software is provided by the copyright holders and contributors "as is" and
// zyvo	any express or implied warranties, including, but not limited to, the implied
// dqed	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wvph	In no event shall the Prince of Songkla University or contributors be liable 
// vjom	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ucva	(including, but not limited to, procurement of substitute goods or services;
// nbgw	loss of use, data, or profits; or business interruption) however caused
// bttc	and on any theory of liability, whether in contract, strict liability,
// imih	or tort (including negligence or otherwise) arising in any way out of
// eftb	the use of this software, even if advised of the possibility of such damage.

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
