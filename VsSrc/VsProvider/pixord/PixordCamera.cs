// auaj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// axyp	
// kiik	 By downloading, copying, installing or using the software you agree to this license.
// ryan	 If you do not agree to this license, do not download, install,
// ntua	 copy or use the software.
// jjxq	
// oxoh	                          License Agreement
// oxec	         For OpenVSS - Open Source Video Surveillance System
// bybv	
// lovz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// focz	
// cewm	Third party copyrights are property of their respective owners.
// coxf	
// dvtq	Redistribution and use in source and binary forms, with or without modification,
// wjvc	are permitted provided that the following conditions are met:
// jrbm	
// efis	  * Redistribution's of source code must retain the above copyright notice,
// xebz	    this list of conditions and the following disclaimer.
// yvuv	
// hyok	  * Redistribution's in binary form must reproduce the above copyright notice,
// bbez	    this list of conditions and the following disclaimer in the documentation
// zzzf	    and/or other materials provided with the distribution.
// ekyc	
// tspn	  * Neither the name of the copyright holders nor the names of its contributors 
// mpvx	    may not be used to endorse or promote products derived from this software 
// veox	    without specific prior written permission.
// nygi	
// ayjy	This software is provided by the copyright holders and contributors "as is" and
// vlbh	any express or implied warranties, including, but not limited to, the implied
// mcmf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fcom	In no event shall the Prince of Songkla University or contributors be liable 
// fzfg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fhir	(including, but not limited to, procurement of substitute goods or services;
// drox	loss of use, data, or profits; or business interruption) however caused
// nhmb	and on any theory of liability, whether in contract, strict liability,
// srff	or tort (including negligence or otherwise) arising in any way out of
// bahi	the use of this software, even if advised of the possibility of such damage.
// qibk	
// cprs	Intelligent Systems Laboratory (iSys Lab)
// pbrn	Faculty of Engineering, Prince of Songkla University, THAILAND
// tact	Project leader by Nikom SUVONVORN
// prvd	Project website at http://code.google.com/p/openvss/

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
