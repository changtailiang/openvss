// opfl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qgrn	
// zgmw	 By downloading, copying, installing or using the software you agree to this license.
// caev	 If you do not agree to this license, do not download, install,
// sehq	 copy or use the software.
// begx	
// tjds	                          License Agreement
// nnzm	         For OpenVSS - Open Source Video Surveillance System
// ugth	
// fjgn	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mhah	
// jffn	Third party copyrights are property of their respective owners.
// rhld	
// vtak	Redistribution and use in source and binary forms, with or without modification,
// jirg	are permitted provided that the following conditions are met:
// cyam	
// hzbv	  * Redistribution's of source code must retain the above copyright notice,
// hwpj	    this list of conditions and the following disclaimer.
// xtet	
// eyno	  * Redistribution's in binary form must reproduce the above copyright notice,
// epbf	    this list of conditions and the following disclaimer in the documentation
// bvrb	    and/or other materials provided with the distribution.
// fjxx	
// raln	  * Neither the name of the copyright holders nor the names of its contributors 
// hoaj	    may not be used to endorse or promote products derived from this software 
// ejgu	    without specific prior written permission.
// sbfb	
// ohfl	This software is provided by the copyright holders and contributors "as is" and
// udbm	any express or implied warranties, including, but not limited to, the implied
// wukl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// izpy	In no event shall the Prince of Songkla University or contributors be liable 
// zsrx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// irlq	(including, but not limited to, procurement of substitute goods or services;
// ydkv	loss of use, data, or profits; or business interruption) however caused
// jhnz	and on any theory of liability, whether in contract, strict liability,
// ppny	or tort (including negligence or otherwise) arising in any way out of
// dmco	the use of this software, even if advised of the possibility of such damage.
// yzqm	
// epbe	Intelligent Systems Laboratory (iSys Lab)
// tiua	Faculty of Engineering, Prince of Songkla University, THAILAND
// kitx	Project leader by Nikom SUVONVORN
// vpnq	Project website at http://code.google.com/p/openvss/

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
