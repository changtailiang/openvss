// mxxr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mouq	
// qeax	 By downloading, copying, installing or using the software you agree to this license.
// ccpj	 If you do not agree to this license, do not download, install,
// gaij	 copy or use the software.
// jnkc	
// gjml	                          License Agreement
// muog	         For OpenVss - Open Source Video Surveillance System
// liza	
// pcqv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vegb	
// iunb	Third party copyrights are property of their respective owners.
// yeao	
// nqpy	Redistribution and use in source and binary forms, with or without modification,
// nukc	are permitted provided that the following conditions are met:
// cjev	
// qulu	  * Redistribution's of source code must retain the above copyright notice,
// doue	    this list of conditions and the following disclaimer.
// knnf	
// gium	  * Redistribution's in binary form must reproduce the above copyright notice,
// wkni	    this list of conditions and the following disclaimer in the documentation
// tasu	    and/or other materials provided with the distribution.
// sanu	
// rnsm	  * Neither the name of the copyright holders nor the names of its contributors 
// akln	    may not be used to endorse or promote products derived from this software 
// isyj	    without specific prior written permission.
// jwea	
// ckse	This software is provided by the copyright holders and contributors "as is" and
// axgs	any express or implied warranties, including, but not limited to, the implied
// vwcq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bqbc	In no event shall the Prince of Songkla University or contributors be liable 
// aamx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ubew	(including, but not limited to, procurement of substitute goods or services;
// xgde	loss of use, data, or profits; or business interruption) however caused
// mdyx	and on any theory of liability, whether in contract, strict liability,
// vrsh	or tort (including negligence or otherwise) arising in any way out of
// ijtu	the use of this software, even if advised of the possibility of such damage.

namespace VdPixord
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Pixord network cameras
	/// </summary>
	public class PixordCamera : MultimodeVideoSource
	{
		private string	server;
		private short	channel = 1;
		private string	resolution = "sif";
		private int		frameInterval;

		// Constructor
		public PixordCamera()
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
					videoSource.VideoSource = "http://" + server + "/images" + channel.ToString() + resolution;
					break;
				case StreamType.MJpeg:
				{
					string src = "http://" + server + "/getimage?camera=" + channel.ToString() + "&fmt=" + resolution;

					if (frameInterval > 0)
					{
						src += "&delay=" + ((int)(frameInterval / 10)).ToString();
					}
					videoSource.VideoSource = src;
					break;
				}
			}
		}
	}
}
