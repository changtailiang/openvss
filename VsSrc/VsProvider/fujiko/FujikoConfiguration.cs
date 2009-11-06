// feui	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uaru	
// twlk	 By downloading, copying, installing or using the software you agree to this license.
// vgwi	 If you do not agree to this license, do not download, install,
// zerh	 copy or use the software.
// jfoi	
// hiys	                          License Agreement
// pwob	         For OpenVss - Open Source Video Surveillance System
// hgqf	
// dkhz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// etyn	
// edfk	Third party copyrights are property of their respective owners.
// ihyc	
// vgwa	Redistribution and use in source and binary forms, with or without modification,
// pmam	are permitted provided that the following conditions are met:
// bzex	
// ikco	  * Redistribution's of source code must retain the above copyright notice,
// qqeo	    this list of conditions and the following disclaimer.
// wrcq	
// gbee	  * Redistribution's in binary form must reproduce the above copyright notice,
// cnjh	    this list of conditions and the following disclaimer in the documentation
// ylfb	    and/or other materials provided with the distribution.
// jppr	
// jvyf	  * Neither the name of the copyright holders nor the names of its contributors 
// obet	    may not be used to endorse or promote products derived from this software 
// arus	    without specific prior written permission.
// djge	
// dgto	This software is provided by the copyright holders and contributors "as is" and
// hwko	any express or implied warranties, including, but not limited to, the implied
// pwyw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ebfa	In no event shall the Prince of Songkla University or contributors be liable 
// amfb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// sxcf	(including, but not limited to, procurement of substitute goods or services;
// wldl	loss of use, data, or profits; or business interruption) however caused
// tqeo	and on any theory of liability, whether in contract, strict liability,
// faxd	or tort (including negligence or otherwise) arising in any way out of
// wbkm	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Fujiko
{
	using System;

	/// <summary>
	/// DLinkConfiguration
	/// </summary>
	public class DLinkConfiguration
	{
		public string	source;
		public string	login;
		public string	password;
		public int		frameInterval = 0;
        public int type;
	}
}
