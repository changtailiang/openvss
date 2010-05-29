// agxd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// znlt	
// eapk	 By downloading, copying, installing or using the software you agree to this license.
// jenr	 If you do not agree to this license, do not download, install,
// osbi	 copy or use the software.
// drmd	
// inrr	                          License Agreement
// hbok	         For OpenVSS - Open Source Video Surveillance System
// ywcx	
// jasg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ywip	
// gctg	Third party copyrights are property of their respective owners.
// uoti	
// acxi	Redistribution and use in source and binary forms, with or without modification,
// tuvl	are permitted provided that the following conditions are met:
// vumc	
// lflm	  * Redistribution's of source code must retain the above copyright notice,
// cqhn	    this list of conditions and the following disclaimer.
// aukg	
// jxxf	  * Redistribution's in binary form must reproduce the above copyright notice,
// ulws	    this list of conditions and the following disclaimer in the documentation
// hgjw	    and/or other materials provided with the distribution.
// ytep	
// fgke	  * Neither the name of the copyright holders nor the names of its contributors 
// kfdb	    may not be used to endorse or promote products derived from this software 
// qgde	    without specific prior written permission.
// gfig	
// rrzv	This software is provided by the copyright holders and contributors "as is" and
// xpqk	any express or implied warranties, including, but not limited to, the implied
// xtvf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vpnj	In no event shall the Prince of Songkla University or contributors be liable 
// lsit	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jfwd	(including, but not limited to, procurement of substitute goods or services;
// uwoo	loss of use, data, or profits; or business interruption) however caused
// hsmb	and on any theory of liability, whether in contract, strict liability,
// xdeh	or tort (including negligence or otherwise) arising in any way out of
// tisp	the use of this software, even if advised of the possibility of such damage.
// pzgq	
// kxfb	Intelligent Systems Laboratory (iSys Lab)
// suso	Faculty of Engineering, Prince of Songkla University, THAILAND
// xowm	Project leader by Nikom SUVONVORN
// vwba	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Axis
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Axis205 Network camera
	/// </summary>
	public class Axis205 : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "320x240";
		private int		frameInterval = 0;

		// Constructor
		public Axis205()
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
