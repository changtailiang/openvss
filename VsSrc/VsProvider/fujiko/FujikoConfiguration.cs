// hiuh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mjiz	
// hsvo	 By downloading, copying, installing or using the software you agree to this license.
// pyct	 If you do not agree to this license, do not download, install,
// txsl	 copy or use the software.
// otts	
// depy	                          License Agreement
// lteu	         For OpenVSS - Open Source Video Surveillance System
// vdwp	
// wwee	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wwsd	
// gwxk	Third party copyrights are property of their respective owners.
// qgqd	
// dhxo	Redistribution and use in source and binary forms, with or without modification,
// obei	are permitted provided that the following conditions are met:
// tjno	
// nbtm	  * Redistribution's of source code must retain the above copyright notice,
// cmxx	    this list of conditions and the following disclaimer.
// tnpr	
// apmg	  * Redistribution's in binary form must reproduce the above copyright notice,
// gehe	    this list of conditions and the following disclaimer in the documentation
// darn	    and/or other materials provided with the distribution.
// ghau	
// rwkm	  * Neither the name of the copyright holders nor the names of its contributors 
// ieqf	    may not be used to endorse or promote products derived from this software 
// clid	    without specific prior written permission.
// jskp	
// sfnz	This software is provided by the copyright holders and contributors "as is" and
// pxbo	any express or implied warranties, including, but not limited to, the implied
// cjlm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kfgu	In no event shall the Prince of Songkla University or contributors be liable 
// ldfw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cciv	(including, but not limited to, procurement of substitute goods or services;
// ygeu	loss of use, data, or profits; or business interruption) however caused
// wdvk	and on any theory of liability, whether in contract, strict liability,
// qbua	or tort (including negligence or otherwise) arising in any way out of
// ubfu	the use of this software, even if advised of the possibility of such damage.
// uwkz	
// tdvx	Intelligent Systems Laboratory (iSys Lab)
// fnrf	Faculty of Engineering, Prince of Songkla University, THAILAND
// nnmq	Project leader by Nikom SUVONVORN
// wrai	Project website at http://code.google.com/p/openvss/

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
