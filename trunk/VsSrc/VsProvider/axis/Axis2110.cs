// pgzw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// durn	
// epbv	 By downloading, copying, installing or using the software you agree to this license.
// wqgp	 If you do not agree to this license, do not download, install,
// ohzq	 copy or use the software.
// abqb	
// zeaf	                          License Agreement
// gktv	         For OpenVss - Open Source Video Surveillance System
// pdmp	
// pnya	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// acok	
// bevz	Third party copyrights are property of their respective owners.
// eckw	
// jcho	Redistribution and use in source and binary forms, with or without modification,
// qyxz	are permitted provided that the following conditions are met:
// tlht	
// vfft	  * Redistribution's of source code must retain the above copyright notice,
// dqaa	    this list of conditions and the following disclaimer.
// iyqy	
// mgzu	  * Redistribution's in binary form must reproduce the above copyright notice,
// iabd	    this list of conditions and the following disclaimer in the documentation
// axln	    and/or other materials provided with the distribution.
// vyzq	
// qzgo	  * Neither the name of the copyright holders nor the names of its contributors 
// vuow	    may not be used to endorse or promote products derived from this software 
// zcwn	    without specific prior written permission.
// bjnk	
// ljbk	This software is provided by the copyright holders and contributors "as is" and
// zcqs	any express or implied warranties, including, but not limited to, the implied
// kdsy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// trxf	In no event shall the Prince of Songkla University or contributors be liable 
// rjjj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// scdr	(including, but not limited to, procurement of substitute goods or services;
// rdvg	loss of use, data, or profits; or business interruption) however caused
// eocq	and on any theory of liability, whether in contract, strict liability,
// jbcm	or tort (including negligence or otherwise) arising in any way out of
// wpro	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis2110 Network camera
	/// </summary>
	public class Axis2110 : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "320x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis2110()
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
