// wcdn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zecu	
// egdt	 By downloading, copying, installing or using the software you agree to this license.
// wilj	 If you do not agree to this license, do not download, install,
// fsnw	 copy or use the software.
// gnhz	
// xchq	                          License Agreement
// zrkm	         For OpenVSS - Open Source Video Surveillance System
// rlqd	
// iznc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// amap	
// dmlj	Third party copyrights are property of their respective owners.
// eiuf	
// wmni	Redistribution and use in source and binary forms, with or without modification,
// vdqw	are permitted provided that the following conditions are met:
// xmum	
// wrck	  * Redistribution's of source code must retain the above copyright notice,
// sibg	    this list of conditions and the following disclaimer.
// ekvu	
// mrwl	  * Redistribution's in binary form must reproduce the above copyright notice,
// rxmq	    this list of conditions and the following disclaimer in the documentation
// wfqe	    and/or other materials provided with the distribution.
// yhie	
// irfo	  * Neither the name of the copyright holders nor the names of its contributors 
// rnsl	    may not be used to endorse or promote products derived from this software 
// kbqw	    without specific prior written permission.
// hoal	
// qsvd	This software is provided by the copyright holders and contributors "as is" and
// hefz	any express or implied warranties, including, but not limited to, the implied
// zepr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bxmk	In no event shall the Prince of Songkla University or contributors be liable 
// awxn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fhdz	(including, but not limited to, procurement of substitute goods or services;
// ykbq	loss of use, data, or profits; or business interruption) however caused
// gqji	and on any theory of liability, whether in contract, strict liability,
// eeof	or tort (including negligence or otherwise) arising in any way out of
// lexd	the use of this software, even if advised of the possibility of such damage.
// mfon	
// ybkm	Intelligent Systems Laboratory (iSys Lab)
// pgvk	Faculty of Engineering, Prince of Songkla University, THAILAND
// rngi	Project leader by Nikom SUVONVORN
// pwew	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Panasonic
{
	using System;
    using Vs.Core.Provider;
	using Vs.Provider.Multisource;
	using Vs.Provider.Jpeg;

	/// <summary>
	/// Panasonic network cameras
	/// </summary>
	public class PanasonicCamera : MultimodeVideoSource
	{
		private string	server;
		private string	resolution = "320x240";
		private string	quality = "Standard";
		private int		frameInterval;

		// Constructor
		public PanasonicCamera()
		{

			videoSource = new JPEGSource();
            JPEGSource.SetAllowUnsafeHeaderParsing20();
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
					videoSource.VideoSource = "http://" + server + "/SnapshotJPEG?Resolution=" + resolution + "&Quality=" + quality;
					break;
				case StreamType.MJpeg:
					videoSource.VideoSource = "http://" + server + "/nphMotionJpeg?Resolution=" + resolution + "&Quality=" + quality;
					break;
			}
		}

        public override bool IsPanTiltZoom()
        {
            return true;
        }

        public override void GoHome()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=HomePosition&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void PanLeft()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=PanLeft&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void PanRight()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=PanRight&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void TiltUp()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=TiltUp&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void TiltDown()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=TiltDown&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void ZoomIn()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=ZoomWide&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void ZoomOut()
        {
            String cmd = "http://" + server + "/nphControlCamera?Direction=ZoomTele&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            ExecuteCommand(cmd);
        }

        public override void ZoomAt(int factor)
        {
            //String cmd = "http://" + server + "/nphControlCamera?Direction=HomePosition&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            //ExecuteCommand(cmd);
        }

        public override void PanTilt(int x, int y)
        {
            //String cmd = "http://" + server + "/nphControlCamera?Direction=HomePosition&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            //ExecuteCommand(cmd);
        }
	}
}
