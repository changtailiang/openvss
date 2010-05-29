// amfq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jdvs	
// uecu	 By downloading, copying, installing or using the software you agree to this license.
// pxuq	 If you do not agree to this license, do not download, install,
// bocv	 copy or use the software.
// bxwh	
// cuhh	                          License Agreement
// bjcj	         For OpenVSS - Open Source Video Surveillance System
// gbik	
// sopn	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xrld	
// jvjl	Third party copyrights are property of their respective owners.
// eubv	
// ukhc	Redistribution and use in source and binary forms, with or without modification,
// qyoo	are permitted provided that the following conditions are met:
// voqk	
// ctoo	  * Redistribution's of source code must retain the above copyright notice,
// okyn	    this list of conditions and the following disclaimer.
// ypyj	
// msxg	  * Redistribution's in binary form must reproduce the above copyright notice,
// lwdh	    this list of conditions and the following disclaimer in the documentation
// igow	    and/or other materials provided with the distribution.
// tftt	
// aari	  * Neither the name of the copyright holders nor the names of its contributors 
// bbbq	    may not be used to endorse or promote products derived from this software 
// huxu	    without specific prior written permission.
// wnxf	
// lxqx	This software is provided by the copyright holders and contributors "as is" and
// ahdz	any express or implied warranties, including, but not limited to, the implied
// libv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// erui	In no event shall the Prince of Songkla University or contributors be liable 
// qemx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xqhl	(including, but not limited to, procurement of substitute goods or services;
// rgzq	loss of use, data, or profits; or business interruption) however caused
// yjku	and on any theory of liability, whether in contract, strict liability,
// jjlv	or tort (including negligence or otherwise) arising in any way out of
// pwtt	the use of this software, even if advised of the possibility of such damage.
// xrxs	
// zfmp	Intelligent Systems Laboratory (iSys Lab)
// zods	Faculty of Engineering, Prince of Songkla University, THAILAND
// bzhv	Project leader by Nikom SUVONVORN
// pegt	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Collections;
using Vs.Core.Image;
using System.Globalization;
using NLog; 

namespace Vs.Core.Analyzer
{
    public class VsCoreAnalyzer : VsICoreAnalyzer, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        // despcription
        protected string analyserName;
        private string pcHost;
        private string camName;

        private int numInput;
        private int numOutput;

        static private int bufCount = 50;

        // analyzer configuration
        protected Hashtable analyzerConfiguration;

        // input buffer
        protected Queue imgBuffer1 = null, imgBuffer2 = null, imgBuffer3 = null, imgBuffer4 = null, imgBuffer5 = null;

        // frame out
        public event VsImageEventHandler FrameOut1, FrameOut2, FrameOut3, FrameOut4, FrameOut5;

        // current frame
        VsImage lastFrame1 = null, lastFrame2 = null, lastFrame3 = null, lastFrame4 = null, lastFrame5 = null;

        // motion out
        public event VsMotionEventHandler MotionOut;

        private static int interLength = 5;
        private int timeSave = 0;

        private bool lastMotion = false;
        private String lastResult = "";

        private long syncTimer = 200;
        private DateTime syncStart;
        private TimeSpan syncSpan;

        // decTimer
        private System.Timers.Timer decTimer;

        // anyTimer
        private System.Timers.Timer anyTimer;

        // Name property
        public string CameraName
        {
            get { return camName; }
            set { camName = value; }
        }

        // LocalHost property
        public string LocalHost
        {
            get { return pcHost; }
            set { pcHost = value; }
        }

        // Analyser name
        public string AnalyserName
        {
            get { return "VsAnalyzer"; }
            set { analyserName = value; }
        }

        // Parameter
        public Hashtable AnalyzerConfiguration
        {
            get { return analyzerConfiguration; }
            set { analyzerConfiguration = value; }
        }

        /// <summary> 
        // Constructor
        /// <summary> 
        public VsCoreAnalyzer(long syncTimer, int inNum, int outNum)
        {
            try
            {
                this.syncTimer = syncTimer;
                numInput = inNum;
                numOutput = outNum;

                // allocate syncronized queue
                if (numInput >= 5) imgBuffer5 = Queue.Synchronized(new Queue());
                if (numInput >= 4) imgBuffer4 = Queue.Synchronized(new Queue());
                if (numInput >= 3) imgBuffer3 = Queue.Synchronized(new Queue());
                if (numInput >= 2) imgBuffer2 = Queue.Synchronized(new Queue());
                if (numInput >= 1) imgBuffer1 = Queue.Synchronized(new Queue());

                // anyTimer
                this.anyTimer = new System.Timers.Timer();
                ((System.ComponentModel.ISupportInitialize)(this.anyTimer)).BeginInit();
                this.anyTimer.Interval = 1000 / bufCount;
                this.anyTimer.Elapsed += new System.Timers.ElapsedEventHandler(process_NewFrame);
                ((System.ComponentModel.ISupportInitialize)(this.anyTimer)).EndInit();
                this.anyTimer.Start();

                // decTimer
                this.decTimer = new System.Timers.Timer();
                ((System.ComponentModel.ISupportInitialize)(this.decTimer)).BeginInit();
                this.decTimer.Interval = 1000;
                this.decTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
                ((System.ComponentModel.ISupportInitialize)(this.decTimer)).EndInit();
                this.decTimer.Start();

                // saveTime
                timeSave = 0;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Start Encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StartAnalyzer()
        {
            /*
            // times span
            syncSpan = DateTime.Now.Subtract(syncStart);

            // miliseconds to sleep
            int msec = (int)syncTimer/4 - (int)syncSpan.TotalMilliseconds;

            while (msec > 0)
            {
                // sleeping ...
                Thread.Sleep((msec < 100) ? msec : 100);
                msec -= 100;
            }
            */
            anyTimer.Start();
        }

        // Stop Encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StopAnalyzer()
        {
            anyTimer.Stop();
            //syncStart = DateTime.Now;
        }

        /// <summary> 
        // Dispose
        /// <summary> 
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
                    // stop process
                    anyTimer.Stop();
                    anyTimer.Dispose();
                    anyTimer = null;

                    decTimer.Stop();
                    decTimer.Dispose();
                    decTimer = null;

                    // free buffer
                    if (numInput >= 5) { imgBuffer5.Clear(); imgBuffer5 = null; }
                    if (numInput >= 4) { imgBuffer4.Clear(); imgBuffer4 = null; }
                    if (numInput >= 3) { imgBuffer3.Clear(); imgBuffer3 = null; }
                    if (numInput >= 2) { imgBuffer2.Clear(); imgBuffer2 = null; }
                    if (numInput >= 1) { imgBuffer1.Clear(); imgBuffer1 = null; }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // On decTimer event - gather statistic
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (--timeSave < 0) timeSave = 0;
        }

        // Input 1
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn1(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer1.Count >= bufCount)
                {
                    VsImage rm = (VsImage)imgBuffer1.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Analyzer");
                }

                VsImage img = (VsImage)e.Image.Clone();
                img.IsDetected = false; img.IsAnalyzed = false;
                imgBuffer1.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Input 2
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn2(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer2.Count >= bufCount)
                {
                    VsImage rm = (VsImage)imgBuffer2.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Analyzer");
                }
                VsImage img = (VsImage)e.Image.Clone();
                img.IsDetected = false; img.IsAnalyzed = false;
                imgBuffer2.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Input 3
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn3(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer3.Count >= bufCount)
                {
                    VsImage rm = (VsImage)imgBuffer3.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Analyzer");
                }
                VsImage img = (VsImage)e.Image.Clone();
                img.IsDetected = false; img.IsAnalyzed = false;
                imgBuffer3.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Input 4
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn4(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer4.Count >= bufCount)
                {
                    VsImage rm = (VsImage)imgBuffer4.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Analyzer");
                }

                VsImage img = (VsImage)e.Image.Clone();
                img.IsDetected = false; img.IsAnalyzed = false;
                imgBuffer4.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Input 5
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn5(object sender, VsImageEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                if (imgBuffer5.Count >= bufCount)
                {
                    VsImage rm = (VsImage)imgBuffer5.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from Analyzer");
                }

                VsImage img = (VsImage)e.Image.Clone();
                img.IsDetected = false; img.IsAnalyzed = false;
                imgBuffer5.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // Stop analyzer
            StopAnalyzer();

            try
            {
                // input frame
                if (numInput >= 5)
                {
                    if (lastFrame5 == null && imgBuffer5.Count > 0) lastFrame5 = (VsImage)imgBuffer5.Dequeue();
                    if (lastFrame5 == null) return;
                }

                if (numInput >= 4)
                {
                    if (lastFrame4 == null && imgBuffer4.Count > 0) lastFrame4 = (VsImage)imgBuffer4.Dequeue();
                    if (lastFrame4 == null) return;
                }

                if (numInput >= 3)
                {
                    if (lastFrame3 == null && imgBuffer3.Count > 0) lastFrame3 = (VsImage)imgBuffer3.Dequeue();
                    if (lastFrame3 == null) return;
                }

                if (numInput >= 2)
                {
                    if (lastFrame2 == null && imgBuffer2.Count > 0) lastFrame2 = (VsImage)imgBuffer2.Dequeue();
                    if (lastFrame2 == null) return;
                }

                if (numInput >= 1)
                {
                    if (lastFrame1 == null && imgBuffer1.Count > 0) lastFrame1 = (VsImage)imgBuffer1.Dequeue();
                    if (lastFrame1 == null) return;
                }

                // process
                if (numInput == 5) process_Frame5(lastFrame1, lastFrame2, lastFrame3, lastFrame4, lastFrame5);
                if (numInput == 4) process_Frame4(lastFrame1, lastFrame2, lastFrame3, lastFrame4);
                if (numInput == 3) process_Frame3(lastFrame1, lastFrame2, lastFrame3);
                if (numInput == 2) process_Frame2(lastFrame1, lastFrame2);
                if (numInput == 1) process_Frame1(lastFrame1);
 
                if (lastFrame1 != null)
                {
                    if (lastFrame1.IsDetected)
                    {
                        if (!lastMotion)
                        {
                            // new motion occurs
                            // alert motion
                            EventAlert();
                        }
                        // still moving
                        timeSave = interLength;
                        lastMotion = true;
                        lastResult = lastFrame1.Result;
                    }
                    else
                    {
                        if (timeSave > 0)
                        {
                            // motion smoothing
                            lastFrame1.IsDetected = true;
                            lastFrame1.Result = lastResult;
                            lastMotion = true;
                        }
                        else
                        {
                            // motion disappear
                            lastMotion = false;
                            lastResult = "";
                        }
                    }

                    // draw image
                    DrawMotion(lastFrame1.Image, lastFrame1.IsDetected);
                }

                // send out
                if (numOutput >= 5) if (FrameOut5 != null) FrameOut5(this, new VsImageEventArgs(lastFrame5));
                if (numOutput >= 4) if (FrameOut4 != null) FrameOut4(this, new VsImageEventArgs(lastFrame4));
                if (numOutput >= 3) if (FrameOut3 != null) FrameOut3(this, new VsImageEventArgs(lastFrame3));
                if (numOutput >= 2) if (FrameOut2 != null) FrameOut2(this, new VsImageEventArgs(lastFrame2));
                if (numOutput >= 1) if (FrameOut1 != null) FrameOut1(this, new VsImageEventArgs(lastFrame1));

            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                // free buffer
                if (numInput >= 5 && lastFrame5 != null) { lastFrame5.Dispose(); lastFrame5 = null; }
                if (numInput >= 4 && lastFrame4 != null) { lastFrame4.Dispose(); lastFrame4 = null; }
                if (numInput >= 3 && lastFrame3 != null) { lastFrame3.Dispose(); lastFrame3 = null; }
                if (numInput >= 2 && lastFrame2 != null) { lastFrame2.Dispose(); lastFrame2 = null; }
                if (numInput >= 1 && lastFrame1 != null) { lastFrame1.Dispose(); lastFrame1 = null; }

                // Start analyzer
                StartAnalyzer();
            }
        }

        // process_Frame1 virtual method
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void process_Frame1(VsImage lastFrame1)
        {
        }

        // process_Frame2 virtual method
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void process_Frame2(VsImage lastFrame1, VsImage lastFrame2)
        {
        }

        // process_Frame3 virtual method
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void process_Frame3(VsImage lastFrame1, VsImage lastFrame2, VsImage lastFrame3)
        {
        }

        // process_Frame4 virtual method
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void process_Frame4(VsImage lastFrame1, VsImage lastFrame2, VsImage lastFrame3, VsImage lastFrame4)
        {
        }

        // process_Frame5 virtual method
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void process_Frame5(VsImage lastFrame1, VsImage lastFrame2, VsImage lastFrame3, VsImage lastFrame4, VsImage lastFrame5)
        {
        }

        // Draw Motion
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DrawMotion(Bitmap drawImg, bool bDetected)
        {
            try
            {
                using (Graphics gp = Graphics.FromImage(drawImg))
                {
                    SolidBrush redBox;
                    if(bDetected)
                        redBox = new SolidBrush(Color.Red);
                    else
                        redBox = new SolidBrush(Color.LightGreen);
                    gp.FillRectangle(redBox, 1, 1, 15, 15);
                    redBox.Dispose();
                    redBox = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Event alert
        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void EventAlert()
        {
            try
            {
                if (MotionOut != null)
                {
                    VsMotion vsMotion = new VsMotion(CameraName, LocalHost, DateTime.Now, analyserName);
                    MotionOut(this, new VsMotionEventArgs(vsMotion));
                    vsMotion.Dispose(); vsMotion = null;

                    logger.Log(LogLevel.Info, "Camera: " + CameraName + ", Host: " + LocalHost + ", Analyzer: " + analyserName);
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }
    }
}
