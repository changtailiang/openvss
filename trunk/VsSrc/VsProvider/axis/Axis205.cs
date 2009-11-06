// lvae	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// efis	
// supi	 By downloading, copying, installing or using the software you agree to this license.
// hbls	 If you do not agree to this license, do not download, install,
// rfmo	 copy or use the software.
// hxra	
// rxqn	                          License Agreement
// rkgs	         For OpenVss - Open Source Video Surveillance System
// xgto	
// ggiq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wwfo	
// qhbb	Third party copyrights are property of their respective owners.
// lqqr	
// qjsn	Redistribution and use in source and binary forms, with or without modification,
// dzmh	are permitted provided that the following conditions are met:
// ovai	
// owkb	  * Redistribution's of source code must retain the above copyright notice,
// hxml	    this list of conditions and the following disclaimer.
// xvrl	
// sdjk	  * Redistribution's in binary form must reproduce the above copyright notice,
// vpba	    this list of conditions and the following disclaimer in the documentation
// uobo	    and/or other materials provided with the distribution.
// nfkg	
// tabb	  * Neither the name of the copyright holders nor the names of its contributors 
// vxzt	    may not be used to endorse or promote products derived from this software 
// xato	    without specific prior written permission.
// efuv	
// shva	This software is provided by the copyright holders and contributors "as is" and
// qclz	any express or implied warranties, including, but not limited to, the implied
// uana	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vwnc	In no event shall the Prince of Songkla University or contributors be liable 
// ngrw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tppv	(including, but not limited to, procurement of substitute goods or services;
// dpnv	loss of use, data, or profits; or business interruption) however caused
// vmwp	and on any theory of liability, whether in contract, strict liability,
// tgwg	or tort (including negligence or otherwise) arising in any way out of
// kjqq	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis205 Network camera
	/// </summary>
	public class Axis205 : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "320x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis205()
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
