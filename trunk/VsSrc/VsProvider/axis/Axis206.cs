// lcgo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// plji	
// btfs	 By downloading, copying, installing or using the software you agree to this license.
// yhic	 If you do not agree to this license, do not download, install,
// epcw	 copy or use the software.
// tgbl	
// smie	                          License Agreement
// mlwt	         For OpenVss - Open Source Video Surveillance System
// dzch	
// weok	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wihm	
// jlcc	Third party copyrights are property of their respective owners.
// ssxy	
// ujaf	Redistribution and use in source and binary forms, with or without modification,
// avwc	are permitted provided that the following conditions are met:
// dfvp	
// xmoz	  * Redistribution's of source code must retain the above copyright notice,
// faga	    this list of conditions and the following disclaimer.
// brzk	
// zobg	  * Redistribution's in binary form must reproduce the above copyright notice,
// kflu	    this list of conditions and the following disclaimer in the documentation
// oyyu	    and/or other materials provided with the distribution.
// ywga	
// hlhr	  * Neither the name of the copyright holders nor the names of its contributors 
// nrpx	    may not be used to endorse or promote products derived from this software 
// wcxr	    without specific prior written permission.
// lwxc	
// jqgm	This software is provided by the copyright holders and contributors "as is" and
// uprx	any express or implied warranties, including, but not limited to, the implied
// uaby	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nuai	In no event shall the Prince of Songkla University or contributors be liable 
// ugtp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kiwh	(including, but not limited to, procurement of substitute goods or services;
// yekh	loss of use, data, or profits; or business interruption) however caused
// itjr	and on any theory of liability, whether in contract, strict liability,
// bwki	or tort (including negligence or otherwise) arising in any way out of
// ptgs	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis205 Network camera
	/// </summary>
	public class Axis206 : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "320x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis206()
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
