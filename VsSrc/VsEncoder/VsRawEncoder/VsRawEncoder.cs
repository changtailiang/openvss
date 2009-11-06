// qlpo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vbfq	
// lbge	 By downloading, copying, installing or using the software you agree to this license.
// qdug	 If you do not agree to this license, do not download, install,
// arbp	 copy or use the software.
// mneq	
// hhzi	                          License Agreement
// ihgq	         For OpenVss - Open Source Video Surveillance System
// opyh	
// xhwz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// uswx	
// tcrb	Third party copyrights are property of their respective owners.
// etum	
// ismc	Redistribution and use in source and binary forms, with or without modification,
// gzgo	are permitted provided that the following conditions are met:
// cwie	
// vqpb	  * Redistribution's of source code must retain the above copyright notice,
// fmis	    this list of conditions and the following disclaimer.
// vcvu	
// rhwe	  * Redistribution's in binary form must reproduce the above copyright notice,
// pxeo	    this list of conditions and the following disclaimer in the documentation
// muhv	    and/or other materials provided with the distribution.
// dvby	
// ahwx	  * Neither the name of the copyright holders nor the names of its contributors 
// krcd	    may not be used to endorse or promote products derived from this software 
// mqwr	    without specific prior written permission.
// lbqg	
// xrlz	This software is provided by the copyright holders and contributors "as is" and
// cbyf	any express or implied warranties, including, but not limited to, the implied
// rtrb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iuxj	In no event shall the Prince of Songkla University or contributors be liable 
// ljsn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fxkz	(including, but not limited to, procurement of substitute goods or services;
// etsy	loss of use, data, or profits; or business interruption) however caused
// andl	and on any theory of liability, whether in contract, strict liability,
// dbyl	or tort (including negligence or otherwise) arising in any way out of
// jbwy	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Xml;
using Vs.Core.Encoder;
using Vs.Core.Image;
using Vs.Encoder.AviLib;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.ComponentModel;
using System.Reflection;
using NLog; 

namespace Vs.Encoder.Avi
{
    public class VsEncodeConverter : IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private Thread thread = null;
        private ManualResetEvent stopEvent = null;
        private ManualResetEvent waitEvent = null;

        // buffer
        protected Queue encBuffer = null;

        // Constructor
        public VsEncodeConverter()
        {
            // synchronized queue
            encBuffer = Queue.Synchronized(new Queue());
        }

        // dispose
        public void Dispose()
        {
            Dispose(true);
        }

        // Clean up any resources being used.
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    encBuffer.Clear();
                    encBuffer = null;

                    SignalToStop();
                    Stop();
                    
                    Free();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // On new frame ready
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn(object sender, VsEncodeEventArgs e)
        {
            try
            {
                VsEncode enc = (VsEncode)e.Encode.Clone();
                encBuffer.Enqueue(enc);
                waitEvent.Set();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

		// Start work
		public void Start()
		{
			if (thread == null)
			{
				// create events                
                waitEvent = new AutoResetEvent(false);
                stopEvent = new ManualResetEvent(false); // if true, a Set method is is called automatically, immediately after construction
				
				// create and start new thread
				thread = new Thread(new ThreadStart(ConverterThread));
                thread.IsBackground = false;
                thread.Name = "VsEncodeConverter";
                thread.Priority = ThreadPriority.AboveNormal;
				thread.Start();
			}
		}

        // Get state of the video source thread
        public bool Running
        {
            get
            {
                if (thread != null)
                {
                    if (thread.Join(0) == false)
                        return true;

                    // the thread is not running, so free resources
                    Free();
                }
                return false;
            }
        }

		// Signal thread to stop work
		public void SignalToStop()
		{
			// stop thread
			if (thread != null)
			{
				// signal to stop
				stopEvent.Set();
                waitEvent.Set();
			}
		}

		// Wait for thread stop
		public void WaitForStop()
		{
			if (thread != null)
			{
				// wait for thread stop
				thread.Join();

				Free();
			}
		}

		// Abort thread
		public void Stop()
		{
			if (this.Running)
			{
				thread.Abort();
				WaitForStop();
			}
		}

		// Free resources
		private void Free()
		{
			thread = null;

			// release events
			stopEvent.Close();
			stopEvent = null;

            // release events
            waitEvent.Close();
            waitEvent = null;
		}

		// Thread entry point
        public void ConverterThread()
        {
            VsEncode lastEnc = null;

            while (true)
            {
                // free memory
                if (lastEnc != null) { lastEnc.Dispose(); lastEnc = null; }

                // get new conversion if there is
                // or waiting if not
                if (encBuffer.Count > 0) lastEnc = (VsEncode)encBuffer.Dequeue();
                else waitEvent.WaitOne();

                if (lastEnc != null)
                {
                    string fileInput = lastEnc.FileFrom; string fileOutput = lastEnc.FileTo;

                    try
                    {
                        // check file input
                        FileInfo fileIn = new FileInfo(fileInput);

                        if (fileIn.Length > 0)
                        {
                            // convert to wmv
                            AviConverter aviConvert = new AviConverter(fileInput, fileOutput, "wmv3");

                            try
                            {
                                // convert
                                aviConvert.StartConvert();
                            }
                            catch (Exception err)
                            {
                                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                            }
                            finally
                            {
                                aviConvert.Dispose();
                                aviConvert = null;
                            }

                            // check file output and delete file input
                            FileInfo fileOut = new FileInfo(fileOutput);

                            if (fileOut.Length > 0) fileIn.Delete();
                        }
                    }
                    catch(Exception err)
                    {
                        logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                    }
                }

                // need to stop ?
                if (stopEvent.WaitOne(0, true)) break;
                
                Thread.Sleep(100);
            }
        }
    }

    // Raw recorder
    // -----------------------------------------------------------
    public class VsRawEncoder : VsCoreEncoder, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private string rawName;
        // local timer
        private System.Timers.Timer stimer;
        private long syncTimer = 200;

        // Maximum length
        private static float MaxLength = 0.25F; // one minuts max
        private int timeMaxLength = 0;

        private int width, height;

        // vsEncoder
        private AviEncoder vsEncoder = null;
        readonly private object lockEncoder = new object();

        // Converter
        VsEncodeConverter vsConvert = null;
        public event VsEncodeEventHandler EncodeOut;

        // Constructor
        public VsRawEncoder(long syncTimer):base(syncTimer)
        {
            timeMaxLength = 0;
            this.syncTimer = syncTimer;
            // 
            // timer defines the time interval between two motions. 
            // 
            this.stimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.stimer)).BeginInit();
            this.stimer.Interval = 1000;
            this.stimer.Elapsed += new System.Timers.ElapsedEventHandler(this.process_MaxlengthStop);
            ((System.ComponentModel.ISupportInitialize)(this.stimer)).EndInit();
            this.stimer.Start();

            // convertor
            vsConvert = new VsEncodeConverter();
            vsConvert.Start();
            EncodeOut += new VsEncodeEventHandler(vsConvert.FrameIn);
        }

        protected override void Dispose(bool disposing)
        {
            // stop timer
            timer.Stop();
            stimer.Stop();

            // stop convertor
            if (vsConvert != null)
            {
                vsConvert.Dispose();
                vsConvert = null;
            }

            // stop encoder
            if (vsEncoder != null)
            {
                vsEncoder.Dispose();
                vsEncoder = null;
            }

            base.Dispose(true);
        }

        // ---------------------------------------------------------------
        // create new viddo file
        public override void StartRecord()
        {
            if (vsEncoder == null)
            {
                try
                {
                    vsEncoder = new AviEncoder();
                }
                catch (Exception err)
                {
                    if (vsEncoder != null)
                    {
                        vsEncoder.Dispose();
                        vsEncoder = null;
                    }
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
                }
            }

            if (vsEncoder != null && !vsEncoder.Recording)
            {
                // check & create directory
                process_DirName();

                try
                {
                    // create new file
                    vsEncoder.StartRecord(rawName, (int)(1000/syncTimer), width, height);

                    // initial parameters
                    timeMaxLength = 0;
                    thumbCount = 0;
                    thumbSave = false;
                    stimer.Start();
                }
                catch (Exception err)
                {
                    // error log
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;

                    // stop encoder
                    StopRecord(false);
                }
            }
        }

        // ---------------------------------------------------------------
        // add image's files to video
        public override void DoRecord(VsImage lastFrame)
        {
            if (vsEncoder != null &&  vsEncoder.Recording)
            {
                try
                {
                    // record frame
                    vsEncoder.DoRecord(lastFrame.Image);
                }
                catch (Exception err)
                {
                    // error log
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;

                    // stop encoder
                    StopRecord(false);
                }
            }
        }
        
        // ---------------------------------------------------------------
        // stop encoder
        public override void StopRecord()
        {
            if (vsEncoder != null && vsEncoder.Recording)
            {
                // stop timer
                timer.Stop();
                stimer.Stop();

                try
                {
                    // stop encoder
                    vsEncoder.StopRecord();

                    // already write and can be accessed by another?
                    // convert avi file to wmv
                    VsEncode vsEnc = new VsEncode(rawName, aviName);
                    EncodeOut(this, new VsEncodeEventArgs(vsEnc));
                    vsEnc.Dispose(); vsEnc = null;

                    // send data to database server
                    DataAlert();
                }
                catch (Exception err)
                {
                    // error log
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;

                    // if can't stop 
                    // try to free memory
                    if (vsEncoder != null) 
                    {
                        vsEncoder.Dispose();
                        vsEncoder = null;
                    }

                    // and create new encoder
                    if (vsEncoder == null)
                    {
                        try
                        {
                            vsEncoder = new AviEncoder();
                        }
                        catch (Exception err1)
                        {
                            if (vsEncoder != null)
                            {
                                vsEncoder.Dispose();
                                vsEncoder = null;
                            }
                            logger.Log(LogLevel.Error, err1.Message + " " + err1.Source + " " + err1.StackTrace); ;
                        }
                    }                   
                }

                // start timer
                timer.Start();
            }
        }

        // ---------------------------------------------------------------
        // on timer
        private void process_MaxlengthStop(object sender, System.Timers.ElapsedEventArgs e)
        {
            // increase max length counter
            timeMaxLength++;
            if (timeMaxLength > MaxLength*60)
            {
                stimer.Stop();

                Monitor.Enter(lockEncoder);

                try
                {
                    StopRecord(true);
                }
                finally
                {
                    Monitor.Exit(lockEncoder);
                }
                stimer.Start();
            }
        }

        // ---------------------------------------------------------------
        // Process new frame
        public override void process_Frame(VsImage lastFrame)
        {
            Monitor.Enter(lockEncoder);

            try
            {
                if (lastFrame.IsDetected)
                {
                    width = lastFrame.Image.Width;
                    height = lastFrame.Image.Height;
                    StartRecord();
                    DoRecord(lastFrame);
                }
                else
                {
                    StopRecord(true);
                }
            }
            finally
            {
                Monitor.Exit(lockEncoder);
            }
        }

        /*
        // Flv encoder
        private void EncodeFlv(object sender, DoWorkEventArgs e)
        {
            string fileInput = rawName;
            string fileOutput = aviName;
            fileOutput = fileOutput + ".flv";

            // Flv
            //string encodeString = string.Format("ffmpeg.exe -i \"{0}\" -f flv -b 5000 -s " + width.ToString() + "x" + height.ToString() + " \"{1}\"", fileInput, fileOutput);
            // -deinterlace 
            string encodeString = string.Format("ffmpeg.exe -i \"{0}\" -acodec mp3 -ab 64k -ac 2 -ar 44100 -f flv -nr 500 -s 640x480 -aspect 4:3 -r 25 -b 650k -me_range 25 -i_qfactor 0.71 -g 500 \"{1}\"", fileInput, fileOutput);
            // mp4
            //string encodeString = string.Format("ffmpeg.exe -i \"{0}\" -target film-dvd \"{1}\"", fileInput, fileOutput);
            

            System.Diagnostics.Process vsProcess;
            vsProcess = new System.Diagnostics.Process();

            string sysFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8)); ;
            vsProcess.StartInfo.FileName = "cmd.exe";
            vsProcess.StartInfo.Arguments = "/C cd " + sysFolder + " && " + encodeString + " && exit";
            vsProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            vsProcess.StartInfo.CreateNoWindow = true;
            vsProcess.Start();
            vsProcess.WaitForExit();
            vsProcess.Close();
            vsProcess.Dispose();
            vsProcess = null;

            FileInfo file = new FileInfo(fileOutput);

            if (file.Length > 0)
            {
                FileInfo fileIn = new FileInfo(fileInput);
                fileIn.Delete();
            }
        }

        // encode complete
        void EncodeCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            vsWorkerList.DeleteWorker(sender);
        }
        */

        // create new directory
        private void process_DirName()
        {
            dateBegin = DateTime.Now;

            // create date directory
            dirName = String.Format("{0}\\{1}-{2}-{3}", LocalStorage, dateBegin.Year, dateBegin.Month, dateBegin.Day);
            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

            // crate camera directory
            dirName = String.Format("{0}\\{1}", dirName, CameraName);
            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

            // file name
            rawName = String.Format("{0}\\{1}-{2}-{3}-{4}-.avi", dirName, dateBegin.Hour, dateBegin.Minute, dateBegin.Second, dateBegin.Millisecond);
            aviName = String.Format("{0}\\{1}-{2}-{3}-{4}.avi", dirName, dateBegin.Hour, dateBegin.Minute, dateBegin.Second, dateBegin.Millisecond);
        }
    }
}
