// jkwd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vpkq	
// tvvs	 By downloading, copying, installing or using the software you agree to this license.
// yvar	 If you do not agree to this license, do not download, install,
// ovoy	 copy or use the software.
// xfgx	
// czaf	                          License Agreement
// xdjk	         For OpenVss - Open Source Video Surveillance System
// wtph	
// nsrq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// owff	
// exba	Third party copyrights are property of their respective owners.
// aete	
// zloe	Redistribution and use in source and binary forms, with or without modification,
// eybv	are permitted provided that the following conditions are met:
// ofsq	
// llwf	  * Redistribution's of source code must retain the above copyright notice,
// ftdv	    this list of conditions and the following disclaimer.
// dyjb	
// aate	  * Redistribution's in binary form must reproduce the above copyright notice,
// yaet	    this list of conditions and the following disclaimer in the documentation
// jfll	    and/or other materials provided with the distribution.
// elcp	
// rwcj	  * Neither the name of the copyright holders nor the names of its contributors 
// dous	    may not be used to endorse or promote products derived from this software 
// bwuh	    without specific prior written permission.
// byab	
// cnee	This software is provided by the copyright holders and contributors "as is" and
// fwxn	any express or implied warranties, including, but not limited to, the implied
// azgg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// alau	In no event shall the Prince of Songkla University or contributors be liable 
// qneh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wzxl	(including, but not limited to, procurement of substitute goods or services;
// fadb	loss of use, data, or profits; or business interruption) however caused
// gxsl	and on any theory of liability, whether in contract, strict liability,
// fjjr	or tort (including negligence or otherwise) arising in any way out of
// hyjv	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Stardot
{
	using System;

	/// <summary>
	/// StardotConfiguration
	/// </summary>
	public class StardotConfiguration
	{
		public string	source;
		public string	login;
		public string	password;
		public int		frameInterval = 0;

		public short	camera = 0;
	}
}
