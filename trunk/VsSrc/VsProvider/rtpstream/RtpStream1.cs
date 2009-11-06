// muxe	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// apkg	
// endp	 By downloading, copying, installing or using the software you agree to this license.
// hkqu	 If you do not agree to this license, do not download, install,
// wntx	 copy or use the software.
// epdq	
// cnts	                          License Agreement
// asvy	         For OpenVss - Open Source Video Surveillance System
// wxzp	
// zzwf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bqkh	
// gugn	Third party copyrights are property of their respective owners.
// fduu	
// mnhw	Redistribution and use in source and binary forms, with or without modification,
// qhbm	are permitted provided that the following conditions are met:
// wrfl	
// sftj	  * Redistribution's of source code must retain the above copyright notice,
// lbux	    this list of conditions and the following disclaimer.
// rnvn	
// fwjh	  * Redistribution's in binary form must reproduce the above copyright notice,
// gfnx	    this list of conditions and the following disclaimer in the documentation
// ybli	    and/or other materials provided with the distribution.
// pcyr	
// xjjk	  * Neither the name of the copyright holders nor the names of its contributors 
// lypb	    may not be used to endorse or promote products derived from this software 
// bxcd	    without specific prior written permission.
// ixcz	
// rurt	This software is provided by the copyright holders and contributors "as is" and
// xtgq	any express or implied warranties, including, but not limited to, the implied
// eimq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tkti	In no event shall the Prince of Songkla University or contributors be liable 
// cczi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// elcg	(including, but not limited to, procurement of substitute goods or services;
// higj	loss of use, data, or profits; or business interruption) however caused
// cjob	and on any theory of liability, whether in contract, strict liability,
// ymqv	or tort (including negligence or otherwise) arising in any way out of
// lftd	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.RtpStream
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;
	using System.Threading;
	using System.Runtime.InteropServices;

    // IPEndPoint
    using System.Net;

    // Add a reference to NetworkingBasics.dll: classes used - BufferChunk
    // Add a reference to LSTCommon.dll: classes used -  UnhandledExceptionHandler
    using Vs.Provider.RtpLib.MSR.LST;

    // Add a reference to MSR.LST.Net.Rtp.dll
    // Classes used - RtpSession, RtpSender, RtpParticipant, RtpStream
    using Vs.Provider.RtpLib.MSR.LST.Net.Rtp;

    // Code Flow (CF)
    // 1. Hook Rtp events:
    //   a.   RtpParticipant Added / Removed
    //   b.   RtpStream Added / Removed
    //   c.   Hook / Unhook FrameReceived event for that stream
    // 2. Join RtpSession by providing an RtpParticipant and Multicast EndPoint
    // 3. Retrieve RtpSender
    // 4. Send data over network
    // 5. Receive data from network
    // 6. Unhook events, dispose RtpSession

    using Vs.Core.Provider;
    using Vs.Core.Image;

	/// <summary>
	/// RtpStream - stream downloader
	/// </summary>
	public class RtpStream1 : VsICoreProvider
	{
        // properties
        private string source;
        private string dest;
        private string ssrc;
        private int video_port;
        private int audio_port;
        private string video_codec;
        private string audio_codec;
        private int video_width;
        private int video_height;

        // mjpeg codec parameter
        private int video_quality;

		private object	userData = null;
		private int		framesReceived;

        // TODO...
        // the offset is correct if the image ratio is 4:3
        static int offset = 623;
        byte[] JpegHeader = new byte[offset];

		// new frame event
		public event VsImageEventHandler FrameOut;

        // RTP connection
        private static IPEndPoint ep = null;  //= RtpSession.DefaultEndPoint;

        /// <summary>
        /// Manages the connection to a multicast address and all the objects related to Rtp
        /// </summary>
        private static RtpSession rtpSession;

        private static  int sessionCount = 0;
        private static RtpStream1[] vsRtpStream = new RtpStream1[25]; // max to 25 camera

        private int sessionIndex = 0;
        private bool firstFrame = true;

		// Source property
		public virtual string VideoSource
		{
            get { return source; }
            set { source = value; }
		}

        // VideoDest property
        public virtual string VideoDest
        {
            get { return dest; }
            set { dest = value; }
        }

        // SSRC property
        public virtual string SSRC
        {
            get { return ssrc; }
            set { ssrc = value; }
        }

        // VideoPort property
        public virtual int VideoPort
        {
            get { return video_port; }
            set { video_port = value; }
        }

        // AudioPort property
        public virtual int AudioPort
        {
            get { return audio_port; }
            set { audio_port = value; }
        }

        // VideoCodec property
        public virtual string VideoCodec
        {
            get { return video_codec; }
            set { video_codec = value; }
        }

        // AudioCodec property
        public virtual string AudioCodec
        {
            get { return audio_codec; }
            set { audio_codec = value; }
        }

        // VideoSizeWidth property
        public virtual int VideoSizeWidth
        {
            get { return video_width; }
            set { video_width = value; }
        }

        // VideoSizeHeight property
        public virtual int VideoSizeHeight
        {
            get { return video_height; }
            set { video_height = value; }
        }

        // VideoQuality property
        public virtual int VideoQuality
        {
            get { return video_quality; }
            set { video_quality = value; }
        }

        // Login property
		public string Login
		{
			get { return null; }
			set { }
		}
		// Password property
		public string Password
		{
			get { return null; }
			set {  }
		}
		// FramesReceived property
		public int FramesReceived
		{
			get
			{
				int frames = framesReceived;
				framesReceived = 0;
				return frames;
			}
		}
		// BytesReceived property
		public int BytesReceived
		{
			get { return 0; }
		}
		// UserData property
		public object UserData
		{
			get { return userData; }
			set { userData = value; }
		}
		// Get state of the video source thread
		public bool Running
		{
			get
			{
                return (sessionCount > 0)? true : false;
			}
		}

		// Constructor
		public RtpStream1()
		{
		}

		// Start work
		public void Start()
		{
			framesReceived = 0;
            firstFrame = true;

            // connect to rtp stream
            Connect(Dns.GetHostName(), source, video_port);
		}

        // Abort thread
        public void Stop()
        {
        }

        // Signal thread to stop work
        public void SignalToStop()
        {
            // disconnect
            Disconnect();

            // stop
            Stop();
        }

        // Wait for thread stop
        public void WaitForStop()
        {
            // TODO
        }


        // Free resources
        private void Free()
        {
            // TODO
        }

        /// <summary>
        /// Connect
        /// </summary>
        public void Connect(String sessionName, String ipNumber, int portNumber)
        {
            if (sessionCount >= 25) return; // max to 25 cameras

            if (ep == null) ep = new IPEndPoint(IPAddress.Parse(ipNumber), portNumber);

            // set session index
            sessionIndex = sessionCount;
            vsRtpStream[sessionIndex] = this;

            HookRtpEvents(); // 1

            // first session
            if(sessionCount==0)
            {
                JoinRtpSession(sessionName); // 2
            }

            // increase session number
            sessionCount++;
        }

        /// Disconnect
        public void Disconnect()
        {
            if(sessionCount>0) sessionCount--;

            UnhookRtpEvents();

            if (sessionCount == 0)
            {
                LeaveRtpSession();
                ep = null;
            }
        }

        // CF1 Hook Rtp events
        private void HookRtpEvents()
        {
            RtpEvents.RtpStreamAdded += new RtpEvents.RtpStreamAddedEventHandler(RtpStreamAdded);
            RtpEvents.RtpStreamRemoved += new RtpEvents.RtpStreamRemovedEventHandler(RtpStreamRemoved);
        }

        // CF2 Create participant, join session
        // CF3 Retrieve RtpSender
        private void JoinRtpSession(string name)
        {
            try
            {
                rtpSession = new RtpSession(ep, new RtpParticipant(name, name), true, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RtpStreamAdded(object sender, RtpEvents.RtpStreamEventArgs ea)
        {
            ea.RtpStream.FrameReceived += new RtpStream.FrameReceivedEventHandler(FrameReceived);
        }

        private void RtpStreamRemoved(object sender, RtpEvents.RtpStreamEventArgs ea)
        {
            ea.RtpStream.FrameReceived -= new RtpStream.FrameReceivedEventHandler(FrameReceived);
        }

        private void UnhookRtpEvents()
        {
            RtpEvents.RtpStreamAdded -= new RtpEvents.RtpStreamAddedEventHandler(RtpStreamAdded);
            RtpEvents.RtpStreamRemoved -= new RtpEvents.RtpStreamRemovedEventHandler(RtpStreamRemoved);
        }

        private void LeaveRtpSession()
        {
            if (rtpSession != null)
            {
                // Clean up all outstanding objects owned by the RtpSession
                rtpSession.Dispose();
                rtpSession = null;
            }
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
                if (info.FormatID == format.Guid) return info;
            return null;
        }

        private int GetIndex(string address)
        {
            for (int i = 0; i < 25; i++)
            {
                if (vsRtpStream[i]!=null && address == vsRtpStream[i].dest)
                    return i;
            }
            return -1;
        }

        private void FrameReceived(object sender, RtpStream.FrameReceivedEventArgs ea)
        {
            try
            {    
                if (firstFrame)
                {
                    Bitmap DrawImage = new Bitmap(video_width, video_height);

                    EncoderParameter epQuality = new EncoderParameter(Encoder.Quality, video_quality);
                    // Store the quality parameter in the list of encoder parameters
                    EncoderParameters epParameters = new EncoderParameters(1);
                    epParameters.Param[0] = epQuality;

                    MemoryStream ms = new MemoryStream();
                    DrawImage.Save(ms, GetImageCodecInfo(ImageFormat.Jpeg), epParameters);

                    Array.Copy(ms.GetBuffer(), 0, JpegHeader, 0, offset);
                    firstFrame = false;
                }

                byte[] data = new byte[ea.Frame.Buffer.Length + offset];
                Array.Copy(JpegHeader, data, JpegHeader.Length);
                Array.Copy(ea.Frame.Buffer, 0, data, offset, ea.Frame.Buffer.Length);
                System.IO.MemoryStream msImage = new MemoryStream(data);

                VsImage img = new VsImage((Bitmap)Image.FromStream(msImage));
                int index =  GetIndex(ea.RtpStream.IPAddress);

                if (index!= -1 && vsRtpStream[index] != null && vsRtpStream[index].FrameOut != null)
                {
                    vsRtpStream[index].FrameOut(this, new VsImageEventArgs(img));
                }
                img.Dispose();
                img = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Control Cameras Methods
        /// </summary>

        public virtual bool IsPanTiltZoom()
        {
            return false;
        }

        public virtual void PanLeft()
        {
        }

        public virtual void PanRight()
        {
        }

        public virtual void TiltUp()
        {
        }

        public virtual void TiltDown()
        {
        }

        public virtual void ZoomIn()
        {
        }

        public virtual void ZoomOut()
        {
        }

        public virtual void ZoomAt(int factor)
        {
        }

        public virtual void PanTilt(int x, int y)
        {
        }

        public virtual void GoHome()
        {
        }

	}
}
