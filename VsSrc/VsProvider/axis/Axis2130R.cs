// vpig	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dteq	
// ximu	 By downloading, copying, installing or using the software you agree to this license.
// dqur	 If you do not agree to this license, do not download, install,
// sbin	 copy or use the software.
// vgrl	
// efly	                          License Agreement
// euza	         For OpenVSS - Open Source Video Surveillance System
// tqdl	
// tzqh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lqry	
// bulx	Third party copyrights are property of their respective owners.
// nquw	
// sdto	Redistribution and use in source and binary forms, with or without modification,
// xwbx	are permitted provided that the following conditions are met:
// iglc	
// imbm	  * Redistribution's of source code must retain the above copyright notice,
// nixs	    this list of conditions and the following disclaimer.
// lbcf	
// psjj	  * Redistribution's in binary form must reproduce the above copyright notice,
// unlo	    this list of conditions and the following disclaimer in the documentation
// adhp	    and/or other materials provided with the distribution.
// xoow	
// xsye	  * Neither the name of the copyright holders nor the names of its contributors 
// eoqp	    may not be used to endorse or promote products derived from this software 
// tyke	    without specific prior written permission.
// sbkr	
// boye	This software is provided by the copyright holders and contributors "as is" and
// msdu	any express or implied warranties, including, but not limited to, the implied
// vxbf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// elpy	In no event shall the Prince of Songkla University or contributors be liable 
// ubvt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cxaa	(including, but not limited to, procurement of substitute goods or services;
// cupv	loss of use, data, or profits; or business interruption) however caused
// dgvz	and on any theory of liability, whether in contract, strict liability,
// sqoi	or tort (including negligence or otherwise) arising in any way out of
// pjjf	the use of this software, even if advised of the possibility of such damage.
// odjh	
// nlki	Intelligent Systems Laboratory (iSys Lab)
// jlkr	Faculty of Engineering, Prince of Songkla University, THAILAND
// grpd	Project leader by Nikom SUVONVORN
// oycs	Project website at http://code.google.com/p/openvss/

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
