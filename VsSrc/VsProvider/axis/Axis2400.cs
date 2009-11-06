// oosj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// arul	
// zgyl	 By downloading, copying, installing or using the software you agree to this license.
// mtib	 If you do not agree to this license, do not download, install,
// orqr	 copy or use the software.
// yfce	
// mglo	                          License Agreement
// cinf	         For OpenVss - Open Source Video Surveillance System
// gwsl	
// yepb	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// kzbi	
// abkk	Third party copyrights are property of their respective owners.
// jfyv	
// hspi	Redistribution and use in source and binary forms, with or without modification,
// mnwt	are permitted provided that the following conditions are met:
// ffir	
// ttfp	  * Redistribution's of source code must retain the above copyright notice,
// bwck	    this list of conditions and the following disclaimer.
// cpgz	
// euel	  * Redistribution's in binary form must reproduce the above copyright notice,
// wafx	    this list of conditions and the following disclaimer in the documentation
// krxn	    and/or other materials provided with the distribution.
// hjzk	
// hwvf	  * Neither the name of the copyright holders nor the names of its contributors 
// qkph	    may not be used to endorse or promote products derived from this software 
// wujm	    without specific prior written permission.
// dnts	
// mper	This software is provided by the copyright holders and contributors "as is" and
// jlxe	any express or implied warranties, including, but not limited to, the implied
// algb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vris	In no event shall the Prince of Songkla University or contributors be liable 
// wrcg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tait	(including, but not limited to, procurement of substitute goods or services;
// fxob	loss of use, data, or profits; or business interruption) however caused
// rstw	and on any theory of liability, whether in contract, strict liability,
// yfar	or tort (including negligence or otherwise) arising in any way out of
// eibw	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;
	using Vs.Provider.Mjpeg;

	/// <summary>
	/// Axis2400 video server
	/// </summary>
	public class Axis2400 : MultimodeVideoSource
	{
		private string	server;
		private short	camera = 1;
		private int		frameInterval = 0;

		// Constructor
		public Axis2400()
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
		// Camera property
		public short Camera
		{
			get { return camera; }
			set
			{
				if ((value >= 1) && (value <= 4))
				{
					camera = value;
					UpdateVideoSource();
				}
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
		// SeparateConnectioGroup property
		// indicates to open WebRequest in separate connection group
		public bool	SeparateConnectionGroup
		{
			get
			{
				return (streamType != StreamType.MJpeg) ? false : (((MJPEGSource) videoSource).SeparateConnectionGroup);
			}
			set
			{
				if (streamType == StreamType.MJpeg)
				{
					((MJPEGSource) videoSource).SeparateConnectionGroup = value;
				}
			}
		}


		// Update video source
		protected override void UpdateVideoSource()
		{
			switch (streamType)
			{
				case StreamType.Jpeg:
					videoSource.VideoSource = "http://" + server + "/axis-cgi/jpg/image.cgi?camera=" + camera.ToString();
					break;
				case StreamType.MJpeg:
				{
					string src = "http://" + server + "/axis-cgi/mjpg/video.cgi?camera=" + camera.ToString();

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
