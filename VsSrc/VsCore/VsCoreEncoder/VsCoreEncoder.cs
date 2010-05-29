// kspa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mxpl	
// fwwh	 By downloading, copying, installing or using the software you agree to this license.
// llsy	 If you do not agree to this license, do not download, install,
// flpi	 copy or use the software.
// ilez	
// efwn	                          License Agreement
// mgdi	         For OpenVSS - Open Source Video Surveillance System
// xsat	
// ziyf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jzvz	
// wnbr	Third party copyrights are property of their respective owners.
// ckll	
// knhy	Redistribution and use in source and binary forms, with or without modification,
// nqwg	are permitted provided that the following conditions are met:
// abyy	
// tnkt	  * Redistribution's of source code must retain the above copyright notice,
// lyyx	    this list of conditions and the following disclaimer.
// mkyj	
// qfcq	  * Redistribution's in binary form must reproduce the above copyright notice,
// eflc	    this list of conditions and the following disclaimer in the documentation
// vrxj	    and/or other materials provided with the distribution.
// kcfj	
// mreh	  * Neither the name of the copyright holders nor the names of its contributors 
// awfj	    may not be used to endorse or promote products derived from this software 
// digd	    without specific prior written permission.
// loyz	
// pyhi	This software is provided by the copyright holders and contributors "as is" and
// nfcu	any express or implied warranties, including, but not limited to, the implied
// qvdb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pbii	In no event shall the Prince of Songkla University or contributors be liable 
// tpku	for any direct, indirect, incidental, special, exemplary, or consequential damages
// grit	(including, but not limited to, procurement of substitute goods or services;
// ztnv	loss of use, data, or profits; or business interruption) however caused
// zhqh	and on any theory of liability, whether in contract, strict liability,
// txum	or tort (including negligence or otherwise) arising in any way out of
// uwvh	the use of this software, even if advised of the possibility of such damage.
// pjre	
// tdtc	Intelligent Systems Laboratory (iSys Lab)
// axkw	Faculty of Engineering, Prince of Songkla University, THAILAND
// ddtx	Project leader by Nikom SUVONVORN
// qoju	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Collections;
using System.Runtime.CompilerServices;
using Vs.Core.Image;
using System.Globalization;
using System.IO;
using NLog; 

namespace Vs.Core.Encoder
{
    public class VsCoreEncoder : VsICoreEncoder, IDisposable
    {
        #region definition

        static Logger logger = LogManager.GetCurrentClassLogger();

        protected string encoderName;
        protected string cameraName;
        protected string pcDirt;
        protected string pcHost;

        protected DateTime dateBegin;
        protected DateTime dateEnd;
        protected String dirName = null;
        protected String aviName = null;
        protected String xmlName = null;
        protected String recDetail = null;
        protected long syncTimer = 200;
        private DateTime syncStart;
        private TimeSpan syncSpan;

        // thumb image
        protected int thumbCount = 0;
        protected bool thumbSave = false;
        private int thumbMax = 30;
        private Bitmap thumbImage = null;

        static private int bufCount = 25;

        // Buffer
        protected Queue imgBuffer = null;

        // New frame out
        public event VsImageEventHandler FrameOut;

        // New data out
        public event VsDataEventHandler DataOut;

        // New event out
        public event VsDataEventHandler EventOut;

        // Encoder Timer
        public System.Timers.Timer encTimer = null;

        // Countdown Timer
        public System.Timers.Timer decTimer = null;

        // Maximum length
        private static float DecLength = 1F; // 1 minut long
        private int decCount = 0;

        // object synchronization
        private readonly static object syncEncoder = new object(); 

        #endregion

        #region Properties

        // CameraName
        public string CameraName
        {
            get { return cameraName; }
            set { cameraName = value; }
        }

        // Encoder name
        public string EncoderName
        {
            get { return "VsEncoder"; }
            set { encoderName = value; }
        }

        // LocalHost
        public string LocalHost
        {
            get { return pcHost; }
            set { pcHost = value; }
        }

        // Data directory
        public string LocalStorage
        {
            get { return pcDirt; }
            set { pcDirt = value; }
        } 
        #endregion

        #region Constructor/Destructor

        // Constructor
        public VsCoreEncoder(long syncTimer)
        {
            // syncronized queue
            try
            {
                imgBuffer = Queue.Synchronized(new Queue());

                this.syncTimer = syncTimer;

                thumbImage = new Bitmap(160, 120);
                thumbCount = 0;
                decCount = 0;

                // encTimer
                this.encTimer = new System.Timers.Timer();
                ((System.ComponentModel.ISupportInitialize)(this.encTimer)).BeginInit();
                this.encTimer.Interval = 1000 / bufCount;
                this.encTimer.Elapsed += new System.Timers.ElapsedEventHandler(process_NewFrame);
                ((System.ComponentModel.ISupportInitialize)(this.encTimer)).EndInit();
                this.encTimer.Start();

                // decTimer
                this.decTimer = new System.Timers.Timer();
                ((System.ComponentModel.ISupportInitialize)(this.decTimer)).BeginInit();
                this.decTimer.Interval = 1000;
                this.decTimer.Elapsed += new System.Timers.ElapsedEventHandler(CountLength);
                ((System.ComponentModel.ISupportInitialize)(this.decTimer)).EndInit();
                this.decTimer.Start();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // Dispose method
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
                    // stop counter
                    decTimer.Stop();
                    decTimer.Dispose();

                    // stop encoder
                    encTimer.Stop();
                    encTimer.Dispose();                    

                    // free buffer
                    imgBuffer.Clear();
                    imgBuffer = null;

                    thumbImage.Dispose();
                    thumbImage = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }
        #endregion

        // Start Counter
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StartCounter()
        {
            decTimer.Start();
        }

        // Stop Counter
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StopCounter()
        {
            decTimer.Stop();
        }

        // Start Encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StartEncoder()
        {
            /*
            // times span
            syncSpan = DateTime.Now.Subtract(syncStart);

            // miliseconds to sleep
            int msec = (int)syncTimer - (int)syncSpan.TotalMilliseconds;

            while (msec > 0)
            {
                // sleeping ...
                Thread.Sleep((msec < 100) ? msec : 100);
                msec -= 100;
            }
            */
            encTimer.Start();
        }

        // Stop Encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StopEncoder()
        {
            encTimer.Stop();
            //syncStart = DateTime.Now;
        }

        // initial encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InitEncoder()
        {
            decCount = 0;
            thumbCount = 0;
            thumbSave = false;
        }

        // decounter timer
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        private void CountLength(object sender, System.Timers.ElapsedEventArgs e)
        {
            // check counter
            if (++decCount > DecLength * 60)
            {
                try
                {
                    StopRecord();
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                }
            }
        }

        // On new frame ready
        //[MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public void FrameIn(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer.Count >= bufCount)
                {
                    VsImage rm = (VsImage)imgBuffer.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Encoder");
                }

                VsImage img = (VsImage)e.Image.Clone();
                imgBuffer.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // stop encoder
            StopEncoder();

            VsImage lastFrame = null;

            try
            {
                // get new one
                if (imgBuffer.Count > 0)
                {
                    lastFrame = (VsImage)imgBuffer.Dequeue();
                }

                if (lastFrame != null)
                {
                    // process
                    if(lastFrame.IsDetected)
                    if (++thumbCount > thumbMax && !thumbSave)
                    {
                        using (Graphics gp = Graphics.FromImage(thumbImage))
                        {
                            gp.DrawImage(lastFrame.Image, 0, 0, 160, 120);
                        }
                        thumbSave = true;

                        EmailAlert(lastFrame.Image);
                    }

                    // process
                    process_Frame(lastFrame);

                    // send output
                    if (FrameOut != null) FrameOut(this, new VsImageEventArgs(lastFrame));
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
            finally
            {
                // free release
                if (lastFrame != null) lastFrame.Dispose(); lastFrame = null;

                // restart encoder
                StartEncoder();
            }
        }

        // Data alert
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public virtual void DataAlert()
        {
            try
            {
                if (DataOut != null)
                {
                    dateEnd = DateTime.Now;
                    String camLat = "x";
                    String camLong = "y";

                    VsData vsData = new VsData(CameraName, 
                        camLat, camLong, 
                        pcHost, aviName, 
                        0, 
                        dirName, "Motion detector", 
                        "Windows Media Encoder", "Windows Audio and Video Codecs 7.0", 
                        dateBegin, dateEnd, recDetail, 
                        thumbImage);

                    DataOut(this, new VsDataEventArgs(vsData));
                    vsData.Dispose(); vsData = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // Email Alert
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public virtual void EmailAlert(Bitmap captureImage)
        {
            try
            {
                if (EventOut != null)
                {
                    dateEnd = DateTime.Now;
                    String camLat = "x";
                    String camLong = "y";

                    VsData vsData = new VsData(CameraName,
                        camLat, camLong,
                        pcHost, "", 0, "", "", "", "",
                        dateEnd, dateEnd, "",
                        captureImage);

                    EventOut(this, new VsDataEventArgs(vsData));
                    vsData.Dispose(); vsData = null;

                    thumbCount = 0;
                    thumbSave = false;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // process_Frame virtual method
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public virtual void process_Frame(VsImage lastFrame)
        {
            // TODO
        }

        // StartRecord virtual method
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public virtual void StartRecord()
        {
            // TODO
        }

        // DoRecord virtual method
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public virtual void DoRecord(VsImage lastFrame)
        {
            // TODO
        }

        // StopRecord virtual method
        [MethodImpl(MethodImplOptions.Synchronized)] // lock/unlock all thread from current instance object
        public virtual void StopRecord()
        {
            // TODO
        }

        /// Random password
        protected string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5, true));
            builder.Append(RandomNumber(10000, 99999));
            return builder.ToString();
        }

        /// Generates a random string with the given length
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
