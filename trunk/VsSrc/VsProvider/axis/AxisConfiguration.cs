// qser	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rizp	
// vhtp	 By downloading, copying, installing or using the software you agree to this license.
// obro	 If you do not agree to this license, do not download, install,
// heyn	 copy or use the software.
// zzro	
// ulhp	                          License Agreement
// xcmg	         For OpenVSS - Open Source Video Surveillance System
// wxoh	
// perf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ylps	
// itkq	Third party copyrights are property of their respective owners.
// dguy	
// pver	Redistribution and use in source and binary forms, with or without modification,
// apxf	are permitted provided that the following conditions are met:
// akrs	
// vmsr	  * Redistribution's of source code must retain the above copyright notice,
// mjzc	    this list of conditions and the following disclaimer.
// mtoo	
// jzga	  * Redistribution's in binary form must reproduce the above copyright notice,
// bqmr	    this list of conditions and the following disclaimer in the documentation
// hnrb	    and/or other materials provided with the distribution.
// sxgz	
// hmen	  * Neither the name of the copyright holders nor the names of its contributors 
// twxv	    may not be used to endorse or promote products derived from this software 
// btdt	    without specific prior written permission.
// hrlw	
// gqhb	This software is provided by the copyright holders and contributors "as is" and
// jwek	any express or implied warranties, including, but not limited to, the implied
// yakh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vqyp	In no event shall the Prince of Songkla University or contributors be liable 
// czva	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pbvn	(including, but not limited to, procurement of substitute goods or services;
// clzh	loss of use, data, or profits; or business interruption) however caused
// mskq	and on any theory of liability, whether in contract, strict liability,
// cuvb	or tort (including negligence or otherwise) arising in any way out of
// pfqk	the use of this software, even if advised of the possibility of such damage.
// htpt	
// lpzk	Intelligent Systems Laboratory (iSys Lab)
// uorh	Faculty of Engineering, Prince of Songkla University, THAILAND
// wkge	Project leader by Nikom SUVONVORN
// uuzx	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;

	/// <summary>
	/// AxisConfiguration
	/// </summary>
	public class AxisConfiguration
	{
		public string	source;
		public string	login;
		public string	password;
		public int		frameInterval = 0;
		public StreamType	stremType = StreamType.Jpeg;

		public short	camera = 1;
		public string	resolution;
	}
}
