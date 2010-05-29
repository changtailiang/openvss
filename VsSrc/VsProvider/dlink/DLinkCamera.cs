// prmu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jtnw	
// mkxf	 By downloading, copying, installing or using the software you agree to this license.
// uphy	 If you do not agree to this license, do not download, install,
// cegj	 copy or use the software.
// dtpm	
// zsqv	                          License Agreement
// dbyr	         For OpenVSS - Open Source Video Surveillance System
// xxvd	
// eowj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ndzv	
// qgga	Third party copyrights are property of their respective owners.
// ijsg	
// nprw	Redistribution and use in source and binary forms, with or without modification,
// bzur	are permitted provided that the following conditions are met:
// crtl	
// lgiw	  * Redistribution's of source code must retain the above copyright notice,
// tdto	    this list of conditions and the following disclaimer.
// iwwa	
// uuwt	  * Redistribution's in binary form must reproduce the above copyright notice,
// mpnu	    this list of conditions and the following disclaimer in the documentation
// isdi	    and/or other materials provided with the distribution.
// gzbf	
// tegv	  * Neither the name of the copyright holders nor the names of its contributors 
// knkk	    may not be used to endorse or promote products derived from this software 
// yjge	    without specific prior written permission.
// peyq	
// tqbh	This software is provided by the copyright holders and contributors "as is" and
// dbfn	any express or implied warranties, including, but not limited to, the implied
// eycs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// caqu	In no event shall the Prince of Songkla University or contributors be liable 
// cnud	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qapg	(including, but not limited to, procurement of substitute goods or services;
// jlvd	loss of use, data, or profits; or business interruption) however caused
// iiee	and on any theory of liability, whether in contract, strict liability,
// umpp	or tort (including negligence or otherwise) arising in any way out of
// xubs	the use of this software, even if advised of the possibility of such damage.
// zsrl	
// lrhy	Intelligent Systems Laboratory (iSys Lab)
// slcb	Faculty of Engineering, Prince of Songkla University, THAILAND
// juas	Project leader by Nikom SUVONVORN
// bvxr	Project website at http://code.google.com/p/openvss/

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
