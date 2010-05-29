// qglo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mgzk	
// ddis	 By downloading, copying, installing or using the software you agree to this license.
// xfze	 If you do not agree to this license, do not download, install,
// mlhg	 copy or use the software.
// cqyh	
// yqyf	                          License Agreement
// imtp	         For OpenVSS - Open Source Video Surveillance System
// zbhk	
// clhz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nmpy	
// ggon	Third party copyrights are property of their respective owners.
// jotz	
// suxa	Redistribution and use in source and binary forms, with or without modification,
// idpv	are permitted provided that the following conditions are met:
// hucr	
// ktsw	  * Redistribution's of source code must retain the above copyright notice,
// xobb	    this list of conditions and the following disclaimer.
// dhtq	
// bzbs	  * Redistribution's in binary form must reproduce the above copyright notice,
// blvt	    this list of conditions and the following disclaimer in the documentation
// suxe	    and/or other materials provided with the distribution.
// dhcz	
// vlss	  * Neither the name of the copyright holders nor the names of its contributors 
// kyon	    may not be used to endorse or promote products derived from this software 
// nspu	    without specific prior written permission.
// msvk	
// bgzj	This software is provided by the copyright holders and contributors "as is" and
// cxtw	any express or implied warranties, including, but not limited to, the implied
// ziyq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wnsq	In no event shall the Prince of Songkla University or contributors be liable 
// mcfr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pagc	(including, but not limited to, procurement of substitute goods or services;
// knej	loss of use, data, or profits; or business interruption) however caused
// wahz	and on any theory of liability, whether in contract, strict liability,
// yndw	or tort (including negligence or otherwise) arising in any way out of
// htwy	the use of this software, even if advised of the possibility of such damage.
// rwtb	
// zyra	Intelligent Systems Laboratory (iSys Lab)
// zyik	Faculty of Engineering, Prince of Songkla University, THAILAND
// ndub	Project leader by Nikom SUVONVORN
// awyo	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis2100 Network camera
	/// </summary>
	public class Axis2100 : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "320x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis2100()
		{
			videoSource = new JPEGSource();
			streamType = StreamType.Jpeg;
		}

		// StreamType property
		public override StreamType StreamType
		{
			get { return base.StreamType; }
			set
			{
				if ((value != StreamType.Jpeg) &&
					(value != StreamType.MJpeg))
					throw new ArgumentException("Invalid stream type");

				base.StreamType = value;
			}
		}
		// VideoSource property
		public override string VideoSource
		{
			get { return server; }
			set
			{
				server = value;
				UpdateVideoSource();
			}
		}
		// Resolution property
		public string Resolution
		{
			get { return resolution; }
			set
			{
				resolution = value;
				UpdateVideoSource();
			}
		}
		// FrameInterval property - interval between frames
		public int FrameInterval
		{
			get { return frameInterval; }
			set
			{
				frameInterval = value;

				if (streamType == StreamType.Jpeg)
				{
					((JPEGSource) videoSource).FrameInterval = frameInterval;
				}
				else
				{
					UpdateVideoSource();
				}
			}
		}

		// Update video source
		protected override void UpdateVideoSource()
		{
			switch (streamType)
			{
				case StreamType.Jpeg:
					videoSource.VideoSource = "http://" + server + "/axis-cgi/jpg/image.cgi?resolution=" + resolution;
					break;
				case StreamType.MJpeg:
				{
					string src = "http://" + server + "/axis-cgi/mjpg/video.cgi?resolution=" + resolution;

					if (frameInterval > 0)
					{
						int fps = (int)(1000 / Math.Min(frameInterval, 1000));
						src += "&des_fps=" + fps.ToString();
					}
					videoSource.VideoSource = src;
					break;
				}
			}
		}
	}
}
