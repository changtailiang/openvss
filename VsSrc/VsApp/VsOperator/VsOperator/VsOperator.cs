// jzcr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// svqa	
// wetz	 By downloading, copying, installing or using the software you agree to this license.
// wzls	 If you do not agree to this license, do not download, install,
// cabu	 copy or use the software.
// weic	
// yxlo	                          License Agreement
// svsv	         For OpenVSS - Open Source Video Surveillance System
// nllv	
// jidd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ehco	
// pmab	Third party copyrights are property of their respective owners.
// paix	
// fbze	Redistribution and use in source and binary forms, with or without modification,
// qztu	are permitted provided that the following conditions are met:
// kcia	
// mxlk	  * Redistribution's of source code must retain the above copyright notice,
// opju	    this list of conditions and the following disclaimer.
// xxqo	
// ctnl	  * Redistribution's in binary form must reproduce the above copyright notice,
// xkzr	    this list of conditions and the following disclaimer in the documentation
// nvpm	    and/or other materials provided with the distribution.
// mgfj	
// pitb	  * Neither the name of the copyright holders nor the names of its contributors 
// zccr	    may not be used to endorse or promote products derived from this software 
// apmz	    without specific prior written permission.
// rnzi	
// lkcw	This software is provided by the copyright holders and contributors "as is" and
// mhxa	any express or implied warranties, including, but not limited to, the implied
// dqnr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// izxi	In no event shall the Prince of Songkla University or contributors be liable 
// kzep	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eopa	(including, but not limited to, procurement of substitute goods or services;
// rwkh	loss of use, data, or profits; or business interruption) however caused
// xzzz	and on any theory of liability, whether in contract, strict liability,
// vhbc	or tort (including negligence or otherwise) arising in any way out of
// eixi	the use of this software, even if advised of the possibility of such damage.
// ktyi	
// oljb	Intelligent Systems Laboratory (iSys Lab)
// sepr	Faculty of Engineering, Prince of Songkla University, THAILAND
// jkew	Project leader by Nikom SUVONVORN
// vcfq	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
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

namespace Vs.Operator
{
    public partial class VsOperator : Form
    {
        private int ImgWidth = 320, ImgHeight = 240;
        private int Quality = 90;

        // the offset is correct if the image ratio is 4:3
        static int offset; // = 611;
        byte[] JpegHeader; // = new byte[offset];

        bool firstFrame = true;

        private IPEndPoint ep = null;  //= RtpSession.DefaultEndPoint;

        /// <summary>
        /// Manages the connection to a multicast address and all the objects related to Rtp
        /// </summary>
        private RtpSession rtpSession;

        public VsOperator()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(VsOperator_Load);
            this.KeyDown += new KeyEventHandler(VsOperator_KeyDown);

            Console.WriteLine("VsOperator");
        }

        void VsOperator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public String GetLocalIpAddress()
        {
            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            for (int i = 0; i < addressList.Length; i++)
            {
                String[] sp = addressList[i].ToString().Split('.');
                if (sp[0].Length == 3) return addressList[i].ToString();
            }

            return "";
        }

        void VsOperator_Load(object sender, EventArgs e)
        {
            Console.WriteLine("VsOperator_Load");
            Cursor.Hide();
            Connect("Operator", GetLocalIpAddress(), 5000);
            //Connect("Operator", "224.0.0.1", 5000);
        }


        void VsOperator_Close()
        {
            Console.WriteLine("VsOperator_Close");
            Disconnect();
        }

        /// <summary>
        /// Connect
        /// </summary>
        public void Connect(String sessionName, String ipNumber, int portNumber)
        {
            Console.WriteLine("Connecting");
            if (ep == null) ep = new IPEndPoint(IPAddress.Parse(ipNumber), portNumber);

            HookRtpEvents(); // 1
            JoinRtpSession(sessionName); // 2
            Console.WriteLine("Connected");

            Bitmap image = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                Font drawFont = new Font("Tahoma", 20, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.White);

                g.DrawString(ipNumber + ":" + portNumber.ToString(), drawFont, drawBrush, new PointF(20, 20));

                drawBrush.Dispose();
                drawFont.Dispose();
            }
            this.pictureBox1.Image = image;
        }

        /// Disconnect
        public void Disconnect()
        {
            UnhookRtpEvents();
            LeaveRtpSession();
            Console.WriteLine("Disconnected");
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
                if (info.FormatID == format.Guid) return info;
            return null;
        }

        // CF1 Hook Rtp events
        private void HookRtpEvents()
        {
            RtpEvents.RtpParticipantAdded += new RtpEvents.RtpParticipantAddedEventHandler(RtpParticipantAdded);
            RtpEvents.RtpParticipantRemoved += new RtpEvents.RtpParticipantRemovedEventHandler(RtpParticipantRemoved);
            RtpEvents.RtpStreamAdded += new RtpEvents.RtpStreamAddedEventHandler(RtpStreamAdded);
            RtpEvents.RtpStreamRemoved += new RtpEvents.RtpStreamRemovedEventHandler(RtpStreamRemoved);
            Console.WriteLine("HookedRtpEvents");
        }

        // CF2 Create participant, join session
        // CF3 Retrieve RtpSender
        private void JoinRtpSession(string name)
        {
            try
            {
                rtpSession = new RtpSession(ep, new RtpParticipant(name, name), true, true);
                Console.WriteLine("JoinedRtpSession");
            }
            catch (Exception ex)
            {
                Console.WriteLine("JoinedRtpSession Error : " + ex.Message);
                //MessageBox.Show("Please make sure that you are connceted with the network so " + ex.Message); 
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
            RtpEvents.RtpParticipantAdded -= new RtpEvents.RtpParticipantAddedEventHandler(RtpParticipantAdded);
            RtpEvents.RtpParticipantRemoved -= new RtpEvents.RtpParticipantRemovedEventHandler(RtpParticipantRemoved);
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

        private void FrameReceived(object sender, RtpStream.FrameReceivedEventArgs ea)
        {
            try
            {
                if (firstFrame)
                {
                    Console.WriteLine("First Frame");
                    Bitmap DrawImage = new Bitmap(ImgWidth, ImgHeight);

                    EncoderParameter epQuality = new EncoderParameter(Encoder.Quality, Quality);
                    // Store the quality parameter in the list of encoder parameters
                    EncoderParameters epParameters = new EncoderParameters(1);
                    epParameters.Param[0] = epQuality;

                    MemoryStream ms = new MemoryStream();
                    DrawImage.Save(ms, GetImageCodecInfo(ImageFormat.Jpeg), epParameters);

                    offset = search_jpegoffset(ms);
                    JpegHeader = new byte[offset];
                    Array.Copy(ms.GetBuffer(), 0, JpegHeader, 0, offset);
                    firstFrame = false;
                }

                byte[] data = new byte[ea.Frame.Buffer.Length + offset];
                Array.Copy(JpegHeader, data, JpegHeader.Length);
                Array.Copy(ea.Frame.Buffer, 0, data, offset, ea.Frame.Buffer.Length);
                System.IO.MemoryStream msImage = new MemoryStream(data);

                Console.WriteLine("Received New Frame");

                pictureBox1.Image = Image.FromStream(msImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Received Error :" + ex.Message);
            }
        }
    }
}
