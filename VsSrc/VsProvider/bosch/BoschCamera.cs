// tmda	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ptzx	
// dciv	 By downloading, copying, installing or using the software you agree to this license.
// gcmv	 If you do not agree to this license, do not download, install,
// lsyc	 copy or use the software.
// puzf	
// abdc	                          License Agreement
// vhps	         For OpenVSS - Open Source Video Surveillance System
// nfpv	
// cotu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vqub	
// vrko	Third party copyrights are property of their respective owners.
// odxd	
// ouuz	Redistribution and use in source and binary forms, with or without modification,
// nyzo	are permitted provided that the following conditions are met:
// pxcv	
// mqha	  * Redistribution's of source code must retain the above copyright notice,
// mqsw	    this list of conditions and the following disclaimer.
// yehy	
// zxki	  * Redistribution's in binary form must reproduce the above copyright notice,
// qpns	    this list of conditions and the following disclaimer in the documentation
// kmdt	    and/or other materials provided with the distribution.
// lqie	
// ofex	  * Neither the name of the copyright holders nor the names of its contributors 
// ozof	    may not be used to endorse or promote products derived from this software 
// kkcx	    without specific prior written permission.
// kafk	
// nvzp	This software is provided by the copyright holders and contributors "as is" and
// nrxa	any express or implied warranties, including, but not limited to, the implied
// jjka	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mnpv	In no event shall the Prince of Songkla University or contributors be liable 
// init	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zjjz	(including, but not limited to, procurement of substitute goods or services;
// ifxg	loss of use, data, or profits; or business interruption) however caused
// mphj	and on any theory of liability, whether in contract, strict liability,
// gsgq	or tort (including negligence or otherwise) arising in any way out of
// qsqx	the use of this software, even if advised of the possibility of such damage.
// hdof	
// oosw	Intelligent Systems Laboratory (iSys Lab)
// vgpw	Faculty of Engineering, Prince of Songkla University, THAILAND
// slke	Project leader by Nikom SUVONVORN
// lahi	Project website at http://code.google.com/p/openvss/

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
