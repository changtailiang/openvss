// ftgk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xefl	
// sbhn	 By downloading, copying, installing or using the software you agree to this license.
// gduh	 If you do not agree to this license, do not download, install,
// mqcn	 copy or use the software.
// cwnr	
// wxcq	                          License Agreement
// evuv	         For OpenVSS - Open Source Video Surveillance System
// tygy	
// syuy	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// aucp	
// nytw	Third party copyrights are property of their respective owners.
// imlu	
// flni	Redistribution and use in source and binary forms, with or without modification,
// gpoa	are permitted provided that the following conditions are met:
// cpgw	
// gmuh	  * Redistribution's of source code must retain the above copyright notice,
// wwon	    this list of conditions and the following disclaimer.
// wdmi	
// uydx	  * Redistribution's in binary form must reproduce the above copyright notice,
// eghs	    this list of conditions and the following disclaimer in the documentation
// kaph	    and/or other materials provided with the distribution.
// lxsd	
// ktwl	  * Neither the name of the copyright holders nor the names of its contributors 
// nfib	    may not be used to endorse or promote products derived from this software 
// dlzm	    without specific prior written permission.
// yxxb	
// yfoh	This software is provided by the copyright holders and contributors "as is" and
// mrvv	any express or implied warranties, including, but not limited to, the implied
// holg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wmwy	In no event shall the Prince of Songkla University or contributors be liable 
// dkdc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hbuo	(including, but not limited to, procurement of substitute goods or services;
// qbts	loss of use, data, or profits; or business interruption) however caused
// hvum	and on any theory of liability, whether in contract, strict liability,
// cnjf	or tort (including negligence or otherwise) arising in any way out of
// jkrs	the use of this software, even if advised of the possibility of such damage.
// yady	
// ubfr	Intelligent Systems Laboratory (iSys Lab)
// pain	Faculty of Engineering, Prince of Songkla University, THAILAND
// uuux	Project leader by Nikom SUVONVORN
// lzrk	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.IO;
using Vs.Core.Image;
using System.Net;
using System.Globalization;
using NLog; 
// Add a reference to NetworkingBasics.dll: classes used - BufferChunk
// Add a reference to LSTCommon.dll: classes used -  UnhandledExceptionHandler
using Vs.Provider.RtpLib.MSR.LST;

// Add a reference to MSR.LST.Net.Rtp.dll
// Classes used - RtpSession, RtpSender, RtpParticipant, RtpStream
using Vs.Provider.RtpLib.MSR.LST.Net.Rtp;  

namespace Vs.Core
{
    public class VsStreamer : IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        // buffer
        protected Queue imgBuffer = null;

        // timer
        private System.Threading.Timer timer = null;
        TimerCallback tcallback = null;

        private IPEndPoint ep = null;  //= RtpSession.DefaultEndPoint;

        /// <summary>
        /// Manages the connection to a multicast address and all the objects related to Rtp
        /// </summary>
        private RtpSession rtpSession;

        /// <summary>
        /// Sends the data across the network
        /// </summary>
        private RtpSender rtpSender;

        private bool vsReadyToStream = false;

        private byte[] data;

        private Bitmap vsImageStream;

        private int Width=320, Height=240;
        private int Quality = 90;

        private long syncTimer = 200;

        /// <summary>
        /// Is Streamming
        /// </summary>
        public bool Streaming
        {
            get {return vsReadyToStream; }
        }

        // Constructor
        public VsStreamer(long syncTimer, int width, int height, int quality)
        {
            try
            {
                this.syncTimer = syncTimer;

                // synchronized queue
                imgBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);
                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 

                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);

                vsReadyToStream = false;

                Width = width; Height = height;
                Quality = quality;

                vsImageStream = new Bitmap(width, height);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // Constructor
        public VsStreamer(long syncTimer)
        {
            try
            {
                this.syncTimer = syncTimer;

                // synchronized queue
                imgBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);
                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 

                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);

                vsReadyToStream = false;

                vsImageStream = new Bitmap(Width, Height);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    timer.Dispose();
                    timer = null;

                    imgBuffer.Clear();
                    imgBuffer = null;

                    Disconnect();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // On new frame ready
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn(object sender, VsImageEventArgs e)
        {
            try
            {
                if (imgBuffer.Count > 1000 / syncTimer)
                {
                    VsImage rm = (VsImage)imgBuffer.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Streamer");
                }

                VsImage img = (VsImage)e.Image.Clone();
                imgBuffer.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        private int search_jpegoffset(MemoryStream ms)
        {
            int offset = 1;
            byte oldbyte = 0, newbyte = 0;
            ms.Seek(0, SeekOrigin.Begin);
            while (offset < ms.Length)
            {
                oldbyte = newbyte;
                newbyte = Convert.ToByte(ms.ReadByte());

                if (oldbyte == 0xFF && newbyte == 0xDA)
                {
                    return offset++;
                }

                offset++;
            }

            return -1;
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object stateInfo)
        {
            try
            {
                VsImage lastImage = null;

                // get new one
                if (imgBuffer.Count > 0)
                {
                    lastImage = (VsImage)imgBuffer.Dequeue();
                }

                if (vsReadyToStream && lastImage != null)
                {
                    EncoderParameter epQuality = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
                    // Store the quality parameter in the list of encoder parameters
                    EncoderParameters epParameters = new EncoderParameters(1);
                    epParameters.Param[0] = epQuality;

                    using(Graphics g =  Graphics.FromImage(vsImageStream))
                    {
                        g.DrawImage(lastImage.Image, 0, 0, Width, Height);
                    }

                    MemoryStream ms = new MemoryStream();
                    vsImageStream.Save(ms, GetImageCodecInfo(ImageFormat.Jpeg), epParameters);

                    int offset = search_jpegoffset(ms);
                    data = new byte[(int)ms.Length - offset];
                    Array.Copy(ms.GetBuffer(), offset, data, 0, (int)ms.Length - offset);
                    rtpSender.Send(data);     
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
                if (info.FormatID == format.Guid) return info;
            return null;
        }

        /// <summary>
        /// Connect
        /// </summary>
        public void Connect(String sessionName, String ipNumber, int portNumber)
        {
            try
            {
                if (ep == null) ep = new IPEndPoint(IPAddress.Parse(ipNumber), portNumber);

                if (!vsReadyToStream)
                {
                    HookRtpEvents(); // 1
                    JoinRtpSession(sessionName); // 2
                    vsReadyToStream = true;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// Disconnect
        public void Disconnect()
        {
            try
            {
                vsReadyToStream = false;
                UnhookRtpEvents();
                LeaveRtpSession();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // CF1 Hook Rtp events
        private void HookRtpEvents()
        {
            try
            {
                RtpEvents.RtpParticipantAdded += new RtpEvents.RtpParticipantAddedEventHandler(RtpParticipantAdded);
                RtpEvents.RtpParticipantRemoved += new RtpEvents.RtpParticipantRemovedEventHandler(RtpParticipantRemoved);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }            
        }

        // CF2 Create participant, join session
        // CF3 Retrieve RtpSender
        private void JoinRtpSession(string name)
        {
            try
            {
                Hashtable payloadPara = new Hashtable();
                payloadPara.Add("Width", Width);
                payloadPara.Add("Height", Height);
                payloadPara.Add("Quality", Quality);

                rtpSession = new RtpSession(ep, new RtpParticipant(name, name), true, true);
                rtpSender = rtpSession.CreateRtpSender(name, PayloadType.JPEG, null, payloadPara);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }
        // CF5 Receive data from network
        private void RtpParticipantAdded(object sender, RtpEvents.RtpParticipantEventArgs ea)
        {
            //ShowMessage(string.Format("{0} has joined", ea.RtpParticipant.Name));
        }

        private void RtpParticipantRemoved(object sender, RtpEvents.RtpParticipantEventArgs ea)
        {
            //ShowMessage(string.Format("{0} has left", ea.RtpParticipant.Name));
        }

        private void UnhookRtpEvents()
        {
            try
            {
                RtpEvents.RtpParticipantAdded -= new RtpEvents.RtpParticipantAddedEventHandler(RtpParticipantAdded);
                RtpEvents.RtpParticipantRemoved -= new RtpEvents.RtpParticipantRemovedEventHandler(RtpParticipantRemoved);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        private void LeaveRtpSession()
        {
            try
            {
                if (rtpSession != null)
                {
                    // Clean up all outstanding objects owned by the RtpSession
                    rtpSession.Dispose();
                    rtpSession = null;
                    rtpSender = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }
    }
}
