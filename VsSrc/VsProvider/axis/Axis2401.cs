// ygyi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hqoi	
// pjdj	 By downloading, copying, installing or using the software you agree to this license.
// cpkp	 If you do not agree to this license, do not download, install,
// vsoe	 copy or use the software.
// zjhf	
// ssaw	                          License Agreement
// oejh	         For OpenVSS - Open Source Video Surveillance System
// ilbk	
// dvga	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// elgp	
// qxgq	Third party copyrights are property of their respective owners.
// gbzl	
// bdkp	Redistribution and use in source and binary forms, with or without modification,
// ytqp	are permitted provided that the following conditions are met:
// qstl	
// zvbq	  * Redistribution's of source code must retain the above copyright notice,
// namz	    this list of conditions and the following disclaimer.
// lozn	
// csov	  * Redistribution's in binary form must reproduce the above copyright notice,
// ljpn	    this list of conditions and the following disclaimer in the documentation
// eyge	    and/or other materials provided with the distribution.
// bmmk	
// frkm	  * Neither the name of the copyright holders nor the names of its contributors 
// svpu	    may not be used to endorse or promote products derived from this software 
// vqdg	    without specific prior written permission.
// pazm	
// ewmg	This software is provided by the copyright holders and contributors "as is" and
// eveg	any express or implied warranties, including, but not limited to, the implied
// cgga	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pwoa	In no event shall the Prince of Songkla University or contributors be liable 
// obuu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dmvh	(including, but not limited to, procurement of substitute goods or services;
// ctzu	loss of use, data, or profits; or business interruption) however caused
// gjxd	and on any theory of liability, whether in contract, strict liability,
// ztzf	or tort (including negligence or otherwise) arising in any way out of
// affk	the use of this software, even if advised of the possibility of such damage.
// mdkl	
// opfy	Intelligent Systems Laboratory (iSys Lab)
// cdsn	Faculty of Engineering, Prince of Songkla University, THAILAND
// geis	Project leader by Nikom SUVONVORN
// bfdl	Project website at http://code.google.com/p/openvss/

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
