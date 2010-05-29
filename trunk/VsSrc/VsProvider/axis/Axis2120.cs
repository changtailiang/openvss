// renf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vsxy	
// aiqw	 By downloading, copying, installing or using the software you agree to this license.
// javl	 If you do not agree to this license, do not download, install,
// ddbw	 copy or use the software.
// txki	
// lakm	                          License Agreement
// fauy	         For OpenVSS - Open Source Video Surveillance System
// zxaa	
// hcmv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fddi	
// caom	Third party copyrights are property of their respective owners.
// woot	
// rpeu	Redistribution and use in source and binary forms, with or without modification,
// teuv	are permitted provided that the following conditions are met:
// ilsa	
// nswl	  * Redistribution's of source code must retain the above copyright notice,
// zveb	    this list of conditions and the following disclaimer.
// rfqp	
// tbfk	  * Redistribution's in binary form must reproduce the above copyright notice,
// lyqq	    this list of conditions and the following disclaimer in the documentation
// lbgj	    and/or other materials provided with the distribution.
// sfhc	
// iqnu	  * Neither the name of the copyright holders nor the names of its contributors 
// kcuk	    may not be used to endorse or promote products derived from this software 
// dcmb	    without specific prior written permission.
// kncm	
// zoar	This software is provided by the copyright holders and contributors "as is" and
// zjjk	any express or implied warranties, including, but not limited to, the implied
// vbom	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lmtt	In no event shall the Prince of Songkla University or contributors be liable 
// obsa	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rwfq	(including, but not limited to, procurement of substitute goods or services;
// gvhj	loss of use, data, or profits; or business interruption) however caused
// logy	and on any theory of liability, whether in contract, strict liability,
// zuke	or tort (including negligence or otherwise) arising in any way out of
// fpdy	the use of this software, even if advised of the possibility of such damage.
// hdzi	
// oizq	Intelligent Systems Laboratory (iSys Lab)
// jsnj	Faculty of Engineering, Prince of Songkla University, THAILAND
// ubuc	Project leader by Nikom SUVONVORN
// jjld	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis2120 Network camera
	/// </summary>
	public class Axis2120 : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "352x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis2120()
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
