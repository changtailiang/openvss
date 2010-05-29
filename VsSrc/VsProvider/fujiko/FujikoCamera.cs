// qwet	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jvtm	
// wxuv	 By downloading, copying, installing or using the software you agree to this license.
// orbk	 If you do not agree to this license, do not download, install,
// yxkm	 copy or use the software.
// yvvr	
// mzrd	                          License Agreement
// briw	         For OpenVSS - Open Source Video Surveillance System
// zwfc	
// zhes	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kgqi	
// emqm	Third party copyrights are property of their respective owners.
// vjxk	
// obbv	Redistribution and use in source and binary forms, with or without modification,
// bnhj	are permitted provided that the following conditions are met:
// dqle	
// oyws	  * Redistribution's of source code must retain the above copyright notice,
// mzlr	    this list of conditions and the following disclaimer.
// srbs	
// fmnz	  * Redistribution's in binary form must reproduce the above copyright notice,
// jfhr	    this list of conditions and the following disclaimer in the documentation
// uyhx	    and/or other materials provided with the distribution.
// vjam	
// auot	  * Neither the name of the copyright holders nor the names of its contributors 
// ultf	    may not be used to endorse or promote products derived from this software 
// pxav	    without specific prior written permission.
// ygrw	
// zjpo	This software is provided by the copyright holders and contributors "as is" and
// zhay	any express or implied warranties, including, but not limited to, the implied
// itkq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qyxc	In no event shall the Prince of Songkla University or contributors be liable 
// zzry	for any direct, indirect, incidental, special, exemplary, or consequential damages
// chxu	(including, but not limited to, procurement of substitute goods or services;
// thkl	loss of use, data, or profits; or business interruption) however caused
// eltn	and on any theory of liability, whether in contract, strict liability,
// hlym	or tort (including negligence or otherwise) arising in any way out of
// ulms	the use of this software, even if advised of the possibility of such damage.
// tqlb	
// ador	Intelligent Systems Laboratory (iSys Lab)
// axwy	Faculty of Engineering, Prince of Songkla University, THAILAND
// ostr	Project leader by Nikom SUVONVORN
// lvvs	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Fujiko
{
    using System;
    using Vs.Core.Provider;
    using Vs.Provider.Multisource;
    using Vs.Provider.Jpeg;
    using Vs.Provider.Mjpeg;

    /// <summary>
    /// Panasonic network cameras
    /// </summary>
    public class FujikoCamera : MultimodeVideoSource
    {
        private string server;
        private string resolution = "640x480";
        private string quality = "Standard";
        private int frameInterval;

        // Constructor
        public FujikoCamera()
        {

            videoSource = new MJPEGSource();
            JPEGSource.SetAllowUnsafeHeaderParsing20();
            streamType = StreamType.MJpeg;
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
                    videoSource.VideoSource = "http://" + server + "/cgi-bin/sf.cgi";
                    break;
                case StreamType.MJpeg:
                    videoSource.VideoSource = "http://" + server + "/cgi-bin/sf.cgi";
                    break;                    
            }
        }

        public override bool IsPanTiltZoom()
        {
            return true;
        }

        public override void GoHome()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=cam_mv&diretion=cam_home&lang=eng";
            ExecuteCommand(cmd);

            cmd = "http://" + server + "/cgi-bin/action?action=zoom_chg&CamInfo_Zoom=1&lang=eng";
            ExecuteCommand(cmd);
        }

        public override void PanLeft()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=cam_mv&diretion=cam_left&lang=eng";
            ExecuteCommand(cmd);
        }

        public override void PanRight()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=cam_mv&diretion=cam_right&lang=eng";
            ExecuteCommand(cmd);
        }

        public override void TiltUp()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=cam_mv&diretion=cam_up&lang=eng";
            ExecuteCommand(cmd);
        }

        public override void TiltDown()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=cam_mv&diretion=cam_down&lang=eng";
            ExecuteCommand(cmd);
        }

        public override void ZoomIn()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=zoom_chg&CamInfo_Zoom=2&lang=eng";
            ExecuteCommand(cmd);
        }

        public override void ZoomOut()
        {
            String cmd = "http://" + server + "/cgi-bin/action?action=zoom_chg&CamInfo_Zoom=0.5&lang=eng";
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
