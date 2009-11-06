// rzla	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// baox	
// oyjh	 By downloading, copying, installing or using the software you agree to this license.
// milm	 If you do not agree to this license, do not download, install,
// rtio	 copy or use the software.
// atno	
// lnud	                          License Agreement
// qzvw	         For OpenVss - Open Source Video Surveillance System
// cxba	
// jkrj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dtyx	
// odjl	Third party copyrights are property of their respective owners.
// zdwd	
// iwjy	Redistribution and use in source and binary forms, with or without modification,
// mwon	are permitted provided that the following conditions are met:
// fkho	
// cneo	  * Redistribution's of source code must retain the above copyright notice,
// gldg	    this list of conditions and the following disclaimer.
// bzlg	
// vpah	  * Redistribution's in binary form must reproduce the above copyright notice,
// ejen	    this list of conditions and the following disclaimer in the documentation
// crog	    and/or other materials provided with the distribution.
// odon	
// vddt	  * Neither the name of the copyright holders nor the names of its contributors 
// mjvb	    may not be used to endorse or promote products derived from this software 
// yuen	    without specific prior written permission.
// aqcj	
// kccw	This software is provided by the copyright holders and contributors "as is" and
// whjw	any express or implied warranties, including, but not limited to, the implied
// fumk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zyad	In no event shall the Prince of Songkla University or contributors be liable 
// xqky	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vsum	(including, but not limited to, procurement of substitute goods or services;
// uyjj	loss of use, data, or profits; or business interruption) however caused
// eqnm	and on any theory of liability, whether in contract, strict liability,
// pevm	or tort (including negligence or otherwise) arising in any way out of
// arqo	the use of this software, even if advised of the possibility of such damage.

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
