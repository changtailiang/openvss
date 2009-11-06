// ajbi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cqmm	
// hgnk	 By downloading, copying, installing or using the software you agree to this license.
// xxmh	 If you do not agree to this license, do not download, install,
// vhdh	 copy or use the software.
// bcmp	
// lukw	                          License Agreement
// reqq	         For OpenVss - Open Source Video Surveillance System
// fvaf	
// iilx	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// volc	
// kqya	Third party copyrights are property of their respective owners.
// czyb	
// dcnx	Redistribution and use in source and binary forms, with or without modification,
// xlxh	are permitted provided that the following conditions are met:
// fpuc	
// pwfb	  * Redistribution's of source code must retain the above copyright notice,
// whzm	    this list of conditions and the following disclaimer.
// vgmn	
// qjeu	  * Redistribution's in binary form must reproduce the above copyright notice,
// vkur	    this list of conditions and the following disclaimer in the documentation
// fpmc	    and/or other materials provided with the distribution.
// hciw	
// lerf	  * Neither the name of the copyright holders nor the names of its contributors 
// tjmo	    may not be used to endorse or promote products derived from this software 
// lxdv	    without specific prior written permission.
// zlfw	
// qzhn	This software is provided by the copyright holders and contributors "as is" and
// gcmv	any express or implied warranties, including, but not limited to, the implied
// vdwa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kctu	In no event shall the Prince of Songkla University or contributors be liable 
// zcbr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pguh	(including, but not limited to, procurement of substitute goods or services;
// wqiy	loss of use, data, or profits; or business interruption) however caused
// hzrt	and on any theory of liability, whether in contract, strict liability,
// jpli	or tort (including negligence or otherwise) arising in any way out of
// vupi	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;
	using Vs.Provider.Mjpeg;

	/// <summary>
	/// Axis2401 video server
	/// </summary>
	public class Axis2401 : MultimodeVideoSource
	{
		private string	server;
		private int		frameInterval = 0;

		// Constructor
		public Axis2401()
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
					videoSource.VideoSource = "http://" + server + "/axis-cgi/jpg/image.cgi";
					break;
				case StreamType.MJpeg:
				{
					string src = "http://" + server + "/axis-cgi/mjpg/video.cgi";

					if (frameInterval > 0)
					{
						int fps = (int)(1000 / Math.Min(frameInterval, 1000));
						src += "?des_fps=" + fps.ToString();
					}
					videoSource.VideoSource = src;
					break;
				}
			}
		}
	}
}
