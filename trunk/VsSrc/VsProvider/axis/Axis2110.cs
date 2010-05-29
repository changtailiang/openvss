// uydy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ibre	
// rvqz	 By downloading, copying, installing or using the software you agree to this license.
// fpxe	 If you do not agree to this license, do not download, install,
// ncat	 copy or use the software.
// bkpi	
// gqow	                          License Agreement
// xkfb	         For OpenVSS - Open Source Video Surveillance System
// qsol	
// fglf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ojjb	
// datv	Third party copyrights are property of their respective owners.
// nzae	
// qbfk	Redistribution and use in source and binary forms, with or without modification,
// jvss	are permitted provided that the following conditions are met:
// mvgg	
// qpin	  * Redistribution's of source code must retain the above copyright notice,
// alyg	    this list of conditions and the following disclaimer.
// rufr	
// aneg	  * Redistribution's in binary form must reproduce the above copyright notice,
// wtiy	    this list of conditions and the following disclaimer in the documentation
// jblp	    and/or other materials provided with the distribution.
// nebk	
// ostt	  * Neither the name of the copyright holders nor the names of its contributors 
// cdlo	    may not be used to endorse or promote products derived from this software 
// rfuc	    without specific prior written permission.
// atmv	
// wnjv	This software is provided by the copyright holders and contributors "as is" and
// qlvs	any express or implied warranties, including, but not limited to, the implied
// miwo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// etav	In no event shall the Prince of Songkla University or contributors be liable 
// josy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// blox	(including, but not limited to, procurement of substitute goods or services;
// cqpq	loss of use, data, or profits; or business interruption) however caused
// ygxq	and on any theory of liability, whether in contract, strict liability,
// optz	or tort (including negligence or otherwise) arising in any way out of
// vftc	the use of this software, even if advised of the possibility of such damage.
// xbhu	
// hwjx	Intelligent Systems Laboratory (iSys Lab)
// fzsm	Faculty of Engineering, Prince of Songkla University, THAILAND
// bouk	Project leader by Nikom SUVONVORN
// ymta	Project website at http://code.google.com/p/openvss/

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
