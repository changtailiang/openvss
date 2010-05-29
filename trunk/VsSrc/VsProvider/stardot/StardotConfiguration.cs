// yiav	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fmsn	
// lfim	 By downloading, copying, installing or using the software you agree to this license.
// gqby	 If you do not agree to this license, do not download, install,
// yvyw	 copy or use the software.
// zabd	
// iarm	                          License Agreement
// wxpc	         For OpenVSS - Open Source Video Surveillance System
// ndsq	
// fomg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hugy	
// foex	Third party copyrights are property of their respective owners.
// nmhf	
// cfny	Redistribution and use in source and binary forms, with or without modification,
// hwnf	are permitted provided that the following conditions are met:
// ufro	
// qfyd	  * Redistribution's of source code must retain the above copyright notice,
// xktk	    this list of conditions and the following disclaimer.
// isoe	
// tcxu	  * Redistribution's in binary form must reproduce the above copyright notice,
// vuyj	    this list of conditions and the following disclaimer in the documentation
// pkai	    and/or other materials provided with the distribution.
// puji	
// bhlb	  * Neither the name of the copyright holders nor the names of its contributors 
// dsia	    may not be used to endorse or promote products derived from this software 
// pbzd	    without specific prior written permission.
// sxwj	
// riee	This software is provided by the copyright holders and contributors "as is" and
// ztka	any express or implied warranties, including, but not limited to, the implied
// hhyf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// eqnd	In no event shall the Prince of Songkla University or contributors be liable 
// blib	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gnab	(including, but not limited to, procurement of substitute goods or services;
// uxeu	loss of use, data, or profits; or business interruption) however caused
// uvrs	and on any theory of liability, whether in contract, strict liability,
// oqrh	or tort (including negligence or otherwise) arising in any way out of
// qfji	the use of this software, even if advised of the possibility of such damage.
// xluw	
// tdvz	Intelligent Systems Laboratory (iSys Lab)
// nwbh	Faculty of Engineering, Prince of Songkla University, THAILAND
// ovdd	Project leader by Nikom SUVONVORN
// hdkc	Project website at http://code.google.com/p/openvss/

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
