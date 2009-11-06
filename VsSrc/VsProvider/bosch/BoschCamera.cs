// gkoy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// swty	
// susg	 By downloading, copying, installing or using the software you agree to this license.
// kona	 If you do not agree to this license, do not download, install,
// wrlu	 copy or use the software.
// bmre	
// nroa	                          License Agreement
// aafe	         For OpenVss - Open Source Video Surveillance System
// keow	
// xwwt	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// tbgh	
// ektr	Third party copyrights are property of their respective owners.
// mfzr	
// kmcu	Redistribution and use in source and binary forms, with or without modification,
// tjka	are permitted provided that the following conditions are met:
// hsxs	
// onvg	  * Redistribution's of source code must retain the above copyright notice,
// zqcz	    this list of conditions and the following disclaimer.
// vraz	
// fjad	  * Redistribution's in binary form must reproduce the above copyright notice,
// yxov	    this list of conditions and the following disclaimer in the documentation
// bouy	    and/or other materials provided with the distribution.
// btdo	
// mvmb	  * Neither the name of the copyright holders nor the names of its contributors 
// dosq	    may not be used to endorse or promote products derived from this software 
// pmrv	    without specific prior written permission.
// czvs	
// mcpj	This software is provided by the copyright holders and contributors "as is" and
// jgbj	any express or implied warranties, including, but not limited to, the implied
// ecqa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// txef	In no event shall the Prince of Songkla University or contributors be liable 
// nonz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ezvq	(including, but not limited to, procurement of substitute goods or services;
// qjnm	loss of use, data, or profits; or business interruption) however caused
// fstc	and on any theory of liability, whether in contract, strict liability,
// sblz	or tort (including negligence or otherwise) arising in any way out of
// etef	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Bosch
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Bosch network cameras
	/// </summary>
	public class BoschCamera : MultimodeVideoSource
	{
		private string	server;
        private string resolution = "352x288";
		private string	quality = "Standard";
		private int		frameInterval;

		// Constructor
		public BoschCamera()
		{

			videoSource = new JPEGSource();
            //JPEGSource.SetAllowUnsafeHeaderParsing20();
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
		// Quality property
		public string Quality
		{
			get { return quality; }
			set
			{
				quality = value;
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
			}
		}


		// Update video source
		protected override void UpdateVideoSource()
		{
			switch (streamType)
			{
				case StreamType.Jpeg:
                    videoSource.VideoSource = "http://" + server + "/snap.jpg?JpegSize=" + resolution + "&JpegCam=1";
					break;
				case StreamType.MJpeg:
                    videoSource.VideoSource = "http://" + server + "/snap.jpg?JpegSize=" + resolution + "&JpegCam=1";
                    break;
			}
		}
	}
}
