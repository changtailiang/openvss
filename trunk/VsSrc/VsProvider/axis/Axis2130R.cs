// hyms	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// usms	
// zsjv	 By downloading, copying, installing or using the software you agree to this license.
// buvp	 If you do not agree to this license, do not download, install,
// suit	 copy or use the software.
// kqtl	
// dofa	                          License Agreement
// qfbi	         For OpenVss - Open Source Video Surveillance System
// gukx	
// kadj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// gamq	
// cjjd	Third party copyrights are property of their respective owners.
// zpva	
// zhoq	Redistribution and use in source and binary forms, with or without modification,
// fbof	are permitted provided that the following conditions are met:
// mlct	
// raph	  * Redistribution's of source code must retain the above copyright notice,
// jxfr	    this list of conditions and the following disclaimer.
// qymj	
// dcju	  * Redistribution's in binary form must reproduce the above copyright notice,
// fbbb	    this list of conditions and the following disclaimer in the documentation
// jbjy	    and/or other materials provided with the distribution.
// fusj	
// mxxu	  * Neither the name of the copyright holders nor the names of its contributors 
// ytzb	    may not be used to endorse or promote products derived from this software 
// tbub	    without specific prior written permission.
// keja	
// vfnc	This software is provided by the copyright holders and contributors "as is" and
// suak	any express or implied warranties, including, but not limited to, the implied
// kakp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rqbp	In no event shall the Prince of Songkla University or contributors be liable 
// fwfs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// brkk	(including, but not limited to, procurement of substitute goods or services;
// chad	loss of use, data, or profits; or business interruption) however caused
// harf	and on any theory of liability, whether in contract, strict liability,
// sica	or tort (including negligence or otherwise) arising in any way out of
// gpqr	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis2130R Network camera
	/// </summary>
	public class Axis2130R : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "352x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis2130R()
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
