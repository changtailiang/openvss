// lvrm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cqmz	
// mpkf	 By downloading, copying, installing or using the software you agree to this license.
// bhti	 If you do not agree to this license, do not download, install,
// vnrm	 copy or use the software.
// hoxk	
// iptg	                          License Agreement
// rxoh	         For OpenVss - Open Source Video Surveillance System
// kzjz	
// sveg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ufxy	
// qobj	Third party copyrights are property of their respective owners.
// zonw	
// geqw	Redistribution and use in source and binary forms, with or without modification,
// xgen	are permitted provided that the following conditions are met:
// wfho	
// bcvc	  * Redistribution's of source code must retain the above copyright notice,
// ytpa	    this list of conditions and the following disclaimer.
// ilrb	
// rzuu	  * Redistribution's in binary form must reproduce the above copyright notice,
// njgc	    this list of conditions and the following disclaimer in the documentation
// ksbf	    and/or other materials provided with the distribution.
// imcm	
// qqjo	  * Neither the name of the copyright holders nor the names of its contributors 
// yjxo	    may not be used to endorse or promote products derived from this software 
// szlf	    without specific prior written permission.
// znnv	
// npfy	This software is provided by the copyright holders and contributors "as is" and
// lkan	any express or implied warranties, including, but not limited to, the implied
// yfei	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bptl	In no event shall the Prince of Songkla University or contributors be liable 
// rdjr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ccdh	(including, but not limited to, procurement of substitute goods or services;
// bgbo	loss of use, data, or profits; or business interruption) however caused
// xbdw	and on any theory of liability, whether in contract, strict liability,
// efst	or tort (including negligence or otherwise) arising in any way out of
// gdag	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Dlink
{
    using System;
    using Vs.Core.Provider;
    using Vs.Provider.Multisource;
    using Vs.Provider.Jpeg;

    /// <summary>
    /// Panasonic network cameras
    /// </summary>
    public class DLinkCamera : MultimodeVideoSource
    {
        private string server;
        private string resolution = "320x240";
        private string quality = "Standard";
        private int frameInterval;

        // Constructor
        public DLinkCamera()
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
                    ((JPEGSource)videoSource).FrameInterval = frameInterval;
                }
            }
        }


        // Update video source
        protected override void UpdateVideoSource()
        {
            switch (streamType)
            {
                case StreamType.Jpeg:
                    videoSource.VideoSource = "http://" + server + "/cgi-bin/video.jpg";
                    break;
            }
        }

        public override bool IsPanTiltZoom()
        {
            return true;
        }

        public override void GoHome()
        {
            String cmd = "http://" + server + "/cgi-bin/camctrl.cgi?move=home";
            ExecuteCommand(cmd);
        }

        public override void PanLeft()
        {
            String cmd = "http://" + server + "/cgi-bin/camctrl.cgi?move=left";
            ExecuteCommand(cmd);
        }

        public override void PanRight()
        {
            String cmd = "http://" + server + "/cgi-bin/camctrl.cgi?move=right";
            ExecuteCommand(cmd);
        }

        public override void TiltUp()
        {
            String cmd = "http://" + server + "/cgi-bin/camctrl.cgi?move=up";
            ExecuteCommand(cmd);
        }

        public override void TiltDown()
        {
            String cmd = "http://" + server + "/cgi-bin/camctrl.cgi?move=down";
            ExecuteCommand(cmd);
        }

        public override void ZoomIn()
        {
            //String cmd = "http://" + server + "/nphControlCamera?Direction=ZoomWide&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            //ExecuteCommand(cmd);
        }

        public override void ZoomOut()
        {
            //String cmd = "http://" + server + "/nphControlCamera?Direction=ZoomTele&Resolution=" + resolution + "&Quality=" + quality + "&RPeriod=0&Size=STD&PresetOperation=Move&Language=0";
            //ExecuteCommand(cmd);
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
