// gtki	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// sfnc	
// yugj	 By downloading, copying, installing or using the software you agree to this license.
// xptf	 If you do not agree to this license, do not download, install,
// oqhv	 copy or use the software.
// iyiy	
// cbxj	                          License Agreement
// spbw	         For OpenVss - Open Source Video Surveillance System
// kpjc	
// zmql	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bdew	
// wirn	Third party copyrights are property of their respective owners.
// oxxk	
// uqli	Redistribution and use in source and binary forms, with or without modification,
// kmgr	are permitted provided that the following conditions are met:
// hekj	
// sjyi	  * Redistribution's of source code must retain the above copyright notice,
// gqgc	    this list of conditions and the following disclaimer.
// zvue	
// ulbt	  * Redistribution's in binary form must reproduce the above copyright notice,
// kjvv	    this list of conditions and the following disclaimer in the documentation
// rqcu	    and/or other materials provided with the distribution.
// darn	
// gzdw	  * Neither the name of the copyright holders nor the names of its contributors 
// tvem	    may not be used to endorse or promote products derived from this software 
// jihx	    without specific prior written permission.
// qvly	
// vgnz	This software is provided by the copyright holders and contributors "as is" and
// kmhx	any express or implied warranties, including, but not limited to, the implied
// jprb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// heef	In no event shall the Prince of Songkla University or contributors be liable 
// ztwa	for any direct, indirect, incidental, special, exemplary, or consequential damages
// sxlz	(including, but not limited to, procurement of substitute goods or services;
// hokb	loss of use, data, or profits; or business interruption) however caused
// cxew	and on any theory of liability, whether in contract, strict liability,
// fdyx	or tort (including negligence or otherwise) arising in any way out of
// nsct	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Stardot
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// StarDot NetCam network camera
	/// </summary>
	public class StardotNetCam : JPEGSource
	{
		private string	server;

		// Constructor
		public StardotNetCam()
		{
		}

		// VideoSource property
		public override string VideoSource
		{
			get { return server; }
			set
			{
				if ((value != null) && (value != ""))
				{
					server = value;
					base.VideoSource = "http://" + server + "/netcam.jpg";
				}
			}
		}
	}
}
