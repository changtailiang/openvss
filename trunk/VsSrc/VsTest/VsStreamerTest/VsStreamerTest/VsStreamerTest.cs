// dyoy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tzzn	
// lejh	 By downloading, copying, installing or using the software you agree to this license.
// pbzh	 If you do not agree to this license, do not download, install,
// punv	 copy or use the software.
// hoxr	
// lfrq	                          License Agreement
// kbcz	         For OpenVSS - Open Source Video Surveillance System
// cokw	
// momu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xzul	
// xdwz	Third party copyrights are property of their respective owners.
// dcgr	
// edxp	Redistribution and use in source and binary forms, with or without modification,
// bxnn	are permitted provided that the following conditions are met:
// hidk	
// bkfa	  * Redistribution's of source code must retain the above copyright notice,
// rdva	    this list of conditions and the following disclaimer.
// hsxh	
// tluh	  * Redistribution's in binary form must reproduce the above copyright notice,
// jrnh	    this list of conditions and the following disclaimer in the documentation
// vluy	    and/or other materials provided with the distribution.
// quvp	
// bzmp	  * Neither the name of the copyright holders nor the names of its contributors 
// wkkn	    may not be used to endorse or promote products derived from this software 
// yvia	    without specific prior written permission.
// hfkm	
// fqvp	This software is provided by the copyright holders and contributors "as is" and
// dfeq	any express or implied warranties, including, but not limited to, the implied
// vvoq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pgjw	In no event shall the Prince of Songkla University or contributors be liable 
// hgzh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gilj	(including, but not limited to, procurement of substitute goods or services;
// bgin	loss of use, data, or profits; or business interruption) however caused
// inap	and on any theory of liability, whether in contract, strict liability,
// aita	or tort (including negligence or otherwise) arising in any way out of
// zflv	the use of this software, even if advised of the possibility of such damage.
// uwta	
// vtxs	Intelligent Systems Laboratory (iSys Lab)
// mmsa	Faculty of Engineering, Prince of Songkla University, THAILAND
// gcfw	Project leader by Nikom SUVONVORN
// elow	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.IO;
using System.Net;
using System.Windows.Forms;

// Add a reference to NetworkingBasics.dll: classes used - BufferChunk
// Add a reference to LSTCommon.dll: classes used -  UnhandledExceptionHandler
using Vs.Provider.RtpLib.MSR.LST;

// Add a reference to MSR.LST.Net.Rtp.dll
// Classes used - RtpSession, RtpSender, RtpParticipant, RtpStream
using Vs.Provider.RtpLib.MSR.LST.Net.Rtp;

namespace VsStreamerTest
{
    public partial class VsStreamerTest : Form
    {
        private int ImgWidth = 640, ImgHeight = 480;
        private int Quality = 74;

        // lock object
        readonly private object lockBuffer = new object();

        private IPEndPoint ep = null;  //= RtpSession.DefaultEndPoint;

        /// <summary>
        /// Manages the connection to a multicast address and all the objects related to Rtp
        /// </summary>
        private RtpSession rtpSession;

        /// <summary>
        /// Sends the data across the network
        /// </summary>
        private RtpSender rtpSender;

        // timer
        private System.Threading.Timer timer = null;
        TimerCallback tcallback = null;

        private byte[] data;

        Bitmap vsImageStream;

        public VsStreamerTest()
        {
            InitializeComponent();

            // timer
            tcallback = new TimerCallback(process_NewFrame);
            // define the dueTime and period 
            long dTime = 1000; long syncTimer = 100;   // wait before the first tick (in ms) 

            // instantiate the Timer object 
            timer = new System.Threading.Timer(tcallback, null, dTime, syncTimer);

            vsImageStream = new Bitmap(ImgWidth, ImgHeight);
        }

        /// <summary>
        /// Connect
        /// </summary>
        public void Connect(String sessionName, String ipNumber, int portNumber)
        {
            if (ep == null) ep = new IPEndPoint(IPAddress.Parse(ipNumber), portNumber);

            HookRtpEvents(); // 1
            JoinRtpSession(sessionName); // 2
        }

        /// Disconnect
        public void Disconnect()
        {
            UnhookRtpEvents();
            LeaveRtpSession();
        }

        // CF1 Hook Rtp events
        private void HookRtpEvents()
        {
            RtpEvents.RtpParticipantAdded += new RtpEvents.RtpParticipantAddedEventHandler(RtpParticipantAdded);
            RtpEvents.RtpParticipantRemoved += new RtpEvents.RtpParticipantRemovedEventHandler(RtpParticipantRemoved);
        }

        // CF2 Create participant, join session
        // CF3 Retrieve RtpSender
        private void JoinRtpSession(string name)
        {
            try
            {
                Hashtable payloadPara = new Hashtable();
                payloadPara.Add("Width", ImgWidth);
                payloadPara.Add("Height", ImgHeight);
                payloadPara.Add("Quality", Quality);

                rtpSession = new RtpSession(ep, new RtpParticipant(name, name), true, true);
                rtpSender = rtpSession.CreateRtpSender(name, PayloadType.JPEG, null, payloadPara);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show("Please make sure that you are connceted with the network so " + ex.Message); 
            }
        }
        // CF5 Receive data from network
        private void RtpParticipantAdded(object sender, RtpEvents.RtpParticipantEventArgs ea)
        {
            listBox1.Items.Add(String.Format("{0} has joined", ea.RtpParticipant.Name));
        }

        private void RtpParticipantRemoved(object sender, RtpEvents.RtpParticipantEventArgs ea)
        {
            //ShowMessage(string.Format("{0} has left", ea.RtpParticipant.Name));
        }

        private void UnhookRtpEvents()
        {
            RtpEvents.RtpParticipantAdded -= new RtpEvents.RtpParticipantAddedEventHandler(RtpParticipantAdded);
            RtpEvents.RtpParticipantRemoved -= new RtpEvents.RtpParticipantRemovedEventHandler(RtpParticipantRemoved);
        }

        private void LeaveRtpSession()
        {
            if (rtpSession != null)
            {
                // Clean up all outstanding objects owned by the RtpSession
                rtpSession.Dispose();
                rtpSession = null;
                rtpSender = null;
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
        private void process_NewFrame(object stateInfo)
        {
            Monitor.Enter(lockBuffer);

            try
            {
                // get windows frame

                if (vsImageStream != null)
                {
                    EncoderParameter epQuality = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
                    // Store the quality parameter in the list of encoder parameters
                    EncoderParameters epParameters = new EncoderParameters(1);
                    epParameters.Param[0] = epQuality;

                    using (Graphics g = Graphics.FromImage(vsImageStream))
                    {
                        g.DrawImage(VsScreenCapture.GetDesktopBitmap(), 0, 0, ImgWidth, ImgHeight);
                    }

                    MemoryStream ms = new MemoryStream();
                    vsImageStream.Save(ms, GetImageCodecInfo(ImageFormat.Jpeg), epParameters);

                    int offset = search_jpegoffset(ms);
                    data = new byte[(int)ms.Length - offset];
                    Array.Copy(ms.GetBuffer(), offset, data, 0, (int)ms.Length - offset);
                    rtpSender.Send(data);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Monitor.Exit(lockBuffer);
            }
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
                if (info.FormatID == format.Guid) return info;
            return null;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connect("StreamerTest", textBox1.Text, 5000);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Disconnect();
            this.Close();
        }
    }
}
