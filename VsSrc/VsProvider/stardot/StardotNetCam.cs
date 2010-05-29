// nvbw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tfiz	
// mcri	 By downloading, copying, installing or using the software you agree to this license.
// qdng	 If you do not agree to this license, do not download, install,
// tdbk	 copy or use the software.
// ykum	
// iocg	                          License Agreement
// gapc	         For OpenVSS - Open Source Video Surveillance System
// tvly	
// ltkm	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ujnz	
// gdlq	Third party copyrights are property of their respective owners.
// ikmk	
// efjc	Redistribution and use in source and binary forms, with or without modification,
// apne	are permitted provided that the following conditions are met:
// dbsm	
// moou	  * Redistribution's of source code must retain the above copyright notice,
// rovz	    this list of conditions and the following disclaimer.
// toqp	
// xvfe	  * Redistribution's in binary form must reproduce the above copyright notice,
// dlxv	    this list of conditions and the following disclaimer in the documentation
// nfyn	    and/or other materials provided with the distribution.
// ljyv	
// ffjs	  * Neither the name of the copyright holders nor the names of its contributors 
// qbnr	    may not be used to endorse or promote products derived from this software 
// oqzt	    without specific prior written permission.
// pnqq	
// puff	This software is provided by the copyright holders and contributors "as is" and
// jjbr	any express or implied warranties, including, but not limited to, the implied
// exyg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qbii	In no event shall the Prince of Songkla University or contributors be liable 
// qzto	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fxyw	(including, but not limited to, procurement of substitute goods or services;
// inpm	loss of use, data, or profits; or business interruption) however caused
// mega	and on any theory of liability, whether in contract, strict liability,
// ohxr	or tort (including negligence or otherwise) arising in any way out of
// eslw	the use of this software, even if advised of the possibility of such damage.
// drot	
// cgbn	Intelligent Systems Laboratory (iSys Lab)
// hqcp	Faculty of Engineering, Prince of Songkla University, THAILAND
// tckr	Project leader by Nikom SUVONVORN
// wiww	Project website at http://code.google.com/p/openvss/

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
