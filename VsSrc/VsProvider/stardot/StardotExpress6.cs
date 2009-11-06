// zoje	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// insp	
// warn	 By downloading, copying, installing or using the software you agree to this license.
// usfc	 If you do not agree to this license, do not download, install,
// psye	 copy or use the software.
// tvhd	
// gvbq	                          License Agreement
// cimr	         For OpenVss - Open Source Video Surveillance System
// djih	
// pscr	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// inff	
// ffrm	Third party copyrights are property of their respective owners.
// egbo	
// afbd	Redistribution and use in source and binary forms, with or without modification,
// ggxn	are permitted provided that the following conditions are met:
// mbnn	
// najk	  * Redistribution's of source code must retain the above copyright notice,
// kxmx	    this list of conditions and the following disclaimer.
// pgwg	
// qcxb	  * Redistribution's in binary form must reproduce the above copyright notice,
// dolv	    this list of conditions and the following disclaimer in the documentation
// hyqy	    and/or other materials provided with the distribution.
// hebj	
// vpfg	  * Neither the name of the copyright holders nor the names of its contributors 
// zrsf	    may not be used to endorse or promote products derived from this software 
// wgch	    without specific prior written permission.
// teyu	
// ivme	This software is provided by the copyright holders and contributors "as is" and
// iwjy	any express or implied warranties, including, but not limited to, the implied
// qsgp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jkdf	In no event shall the Prince of Songkla University or contributors be liable 
// vdca	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bqgz	(including, but not limited to, procurement of substitute goods or services;
// jsfw	loss of use, data, or profits; or business interruption) however caused
// mecc	and on any theory of liability, whether in contract, strict liability,
// zwpl	or tort (including negligence or otherwise) arising in any way out of
// sxay	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Stardot
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// StardotExpress6 video server
	/// </summary>
	public class StardotExpress6 : JPEGSource
	{
		private string	server;
		private short	camera = 0;

		// Constructor
		public StardotExpress6()
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
					UpdateVideoSource();
				}
			}
		}
		// Camera property
		public short Camera
		{
			get { return camera; }
			set
			{
				if ((value >= 0) && (value <= 5))
				{
					camera = value;
					UpdateVideoSource();
				}
			}
		}

		// Update video source
		protected void UpdateVideoSource()
		{
			base.VideoSource = "http://" + server + "/jpeg.cgi?" + camera.ToString();
		}
	}
}
