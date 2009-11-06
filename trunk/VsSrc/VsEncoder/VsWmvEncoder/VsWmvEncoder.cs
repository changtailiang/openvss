// move	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lsdb	
// ybce	 By downloading, copying, installing or using the software you agree to this license.
// itew	 If you do not agree to this license, do not download, install,
// cnrt	 copy or use the software.
// gdfx	
// cntm	                          License Agreement
// rdsi	         For OpenVss - Open Source Video Surveillance System
// bwwa	
// ltbl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// sika	
// azod	Third party copyrights are property of their respective owners.
// mwnl	
// itoi	Redistribution and use in source and binary forms, with or without modification,
// jxcx	are permitted provided that the following conditions are met:
// zqku	
// iudl	  * Redistribution's of source code must retain the above copyright notice,
// xekj	    this list of conditions and the following disclaimer.
// mgay	
// texc	  * Redistribution's in binary form must reproduce the above copyright notice,
// zpzu	    this list of conditions and the following disclaimer in the documentation
// qhzh	    and/or other materials provided with the distribution.
// ioqn	
// qemb	  * Neither the name of the copyright holders nor the names of its contributors 
// xqsf	    may not be used to endorse or promote products derived from this software 
// vcgi	    without specific prior written permission.
// lezc	
// tppf	This software is provided by the copyright holders and contributors "as is" and
// azyj	any express or implied warranties, including, but not limited to, the implied
// rpeb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uwdi	In no event shall the Prince of Songkla University or contributors be liable 
// oxsi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uzbd	(including, but not limited to, procurement of substitute goods or services;
// mrgw	loss of use, data, or profits; or business interruption) however caused
// irim	and on any theory of liability, whether in contract, strict liability,
// ixos	or tort (including negligence or otherwise) arising in any way out of
// zlnr	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Xml;
using Vs.Core.Encoder;
using Vs.Core.Image;
using Vs.Encoder.WmvLib;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Reflection;
using NLog; 

namespace Vs.Encoder.Wmv
{
    public class VsWmvEncoder : VsCoreEncoder, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        // Encoder
        private WmvEncoder vsEncoder = null;

        // Record
        private bool bRecord = false;

        // Constructor
        public VsWmvEncoder(long syncTimer)
            : base(syncTimer)
        {
            try
            {
                String vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
                vsEncoder = new WmvEncoder(Path.Combine(vsAppPath, "640x480.prx"), (ulong)(1000 / syncTimer));
            }
            catch (Exception err)
            {
                // error log
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // Dispose
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected override void Dispose(bool disposing)
        {
            base.Dispose(true);

            // stop encoder
            if (vsEncoder != null)
            {
                DisposeEncoder();
            }
        }

        // dispose encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DisposeEncoder()
        {
            bRecord = false;

            // stop encoder
            StopEncoder();

            try
            {
                // trace log
                logger.Log(LogLevel.Info, "DisposeEncoder : Before StopRecord/Dispose.");

                vsEncoder.StopRecord();
                vsEncoder.Dispose();
                vsEncoder = null;

                // trace log
                logger.Log(LogLevel.Info, "DisposeEncoder : After StopRecord/Dispose..");
            }
            catch (Exception err)
            {
                // error log
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
            finally
            {
                // start encoder
                StartEncoder();
            }
        }

        // create new viddo file
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void StartRecord()
        {
            // check if recording
            if (bRecord) return;

            if (vsEncoder == null)
            {
                try
                {
                    String vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
                    vsEncoder = new WmvEncoder(Path.Combine(vsAppPath, "640x480.prx"), (ulong)(1000 / syncTimer));
                }
                catch (Exception err)
                {
                    // error log
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

                    // dispose encoder
                    DisposeEncoder();
                }
            }

            try
            {
                // check & create directory
                process_DirName();

                // create new file
                vsEncoder.StartRecord(aviName);

                // init encoder
                InitEncoder();

                // start counter
                StartCounter();

                // start record
                bRecord = true;
            }
            catch (Exception err)
            {
                // error log
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

                // dispose encoder
                DisposeEncoder();
            }
        }

        // ---------------------------------------------------------------
        // add image's files to video
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void DoRecord(VsImage lastFrame)
        {
            // check if not recording
            if (!bRecord) return;
            if (vsEncoder == null) { bRecord = false; return; }

            try
            {
                // record frame
                vsEncoder.DoRecord(lastFrame.Image);
            }
            catch (Exception err)
            {
                // error log
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

                // dispose encoder
                DisposeEncoder();
            }
        }
        
        // ---------------------------------------------------------------
        // stop encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void StopRecord()
        {
            // check if not recording
            if (!bRecord) return;
            if (vsEncoder == null) { bRecord = false; return; }

            // stop counter
            StopCounter();

            // stop timer
            StopEncoder();

            try
            {
                // stop encoder
                vsEncoder.StopRecord();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

                // dispose encoder
                DisposeEncoder();
            }
            finally
            {
                bRecord = false;
            }

            // send data to database server
            DataAlert();

            // start timer
            StartEncoder();
        }

        // ---------------------------------------------------------------
        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void process_Frame(VsImage lastFrame)
        {
            try
            {
                if (lastFrame.IsDetected)
                {
                    StartRecord();
                    DoRecord(lastFrame);
                }
                else
                {
                    StopRecord();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // create new directory
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_DirName()
        {
            // create file name
            dateBegin = DateTime.Now;

            dirName = String.Format("{0}\\{1}-{2}-{3}", LocalStorage, dateBegin.Year, dateBegin.Month, dateBegin.Day);

            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

            dirName = String.Format("{0}\\{1}", dirName, CameraName);

            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

            // file name
            aviName = String.Format("{0}\\{1}-{2}-{3}-{4}-{5}.wmv", dirName, dateBegin.Hour, dateBegin.Minute, dateBegin.Second, dateBegin.Millisecond, GetRandomString());
        }
    }
}
