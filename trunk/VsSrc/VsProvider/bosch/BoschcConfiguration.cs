// icsl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// iefb	
// vwps	 By downloading, copying, installing or using the software you agree to this license.
// wlfr	 If you do not agree to this license, do not download, install,
// ighk	 copy or use the software.
// ousd	
// zzva	                          License Agreement
// nzyd	         For OpenVSS - Open Source Video Surveillance System
// qndf	
// khlr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yzsl	
// pznb	Third party copyrights are property of their respective owners.
// lfcz	
// urao	Redistribution and use in source and binary forms, with or without modification,
// komi	are permitted provided that the following conditions are met:
// ieow	
// ymbi	  * Redistribution's of source code must retain the above copyright notice,
// haga	    this list of conditions and the following disclaimer.
// vqlo	
// cgoa	  * Redistribution's in binary form must reproduce the above copyright notice,
// muph	    this list of conditions and the following disclaimer in the documentation
// wyjz	    and/or other materials provided with the distribution.
// novv	
// vcjt	  * Neither the name of the copyright holders nor the names of its contributors 
// lwnc	    may not be used to endorse or promote products derived from this software 
// xftl	    without specific prior written permission.
// zcee	
// fmmd	This software is provided by the copyright holders and contributors "as is" and
// amwo	any express or implied warranties, including, but not limited to, the implied
// phzz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ccut	In no event shall the Prince of Songkla University or contributors be liable 
// eles	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gsdg	(including, but not limited to, procurement of substitute goods or services;
// tlcg	loss of use, data, or profits; or business interruption) however caused
// aeiu	and on any theory of liability, whether in contract, strict liability,
// uftb	or tort (including negligence or otherwise) arising in any way out of
// cruj	the use of this software, even if advised of the possibility of such damage.
// gvee	
// wnav	Intelligent Systems Laboratory (iSys Lab)
// kagn	Faculty of Engineering, Prince of Songkla University, THAILAND
// xlxn	Project leader by Nikom SUVONVORN
// jgkp	Project website at http://code.google.com/p/openvss/

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
