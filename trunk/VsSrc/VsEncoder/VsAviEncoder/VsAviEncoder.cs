// hyxv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wrlh	
// rrau	 By downloading, copying, installing or using the software you agree to this license.
// gtjp	 If you do not agree to this license, do not download, install,
// xoka	 copy or use the software.
// xdcd	
// xqce	                          License Agreement
// psxp	         For OpenVSS - Open Source Video Surveillance System
// pvpp	
// ellb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xzlb	
// qnfq	Third party copyrights are property of their respective owners.
// ulvd	
// whce	Redistribution and use in source and binary forms, with or without modification,
// wuxf	are permitted provided that the following conditions are met:
// phry	
// tlfk	  * Redistribution's of source code must retain the above copyright notice,
// etlm	    this list of conditions and the following disclaimer.
// djdy	
// ranj	  * Redistribution's in binary form must reproduce the above copyright notice,
// llke	    this list of conditions and the following disclaimer in the documentation
// xush	    and/or other materials provided with the distribution.
// sktk	
// nglq	  * Neither the name of the copyright holders nor the names of its contributors 
// hmie	    may not be used to endorse or promote products derived from this software 
// ivma	    without specific prior written permission.
// zian	
// eenv	This software is provided by the copyright holders and contributors "as is" and
// gnud	any express or implied warranties, including, but not limited to, the implied
// wmbz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sxst	In no event shall the Prince of Songkla University or contributors be liable 
// abzw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xnqe	(including, but not limited to, procurement of substitute goods or services;
// sibq	loss of use, data, or profits; or business interruption) however caused
// zkfo	and on any theory of liability, whether in contract, strict liability,
// ufdo	or tort (including negligence or otherwise) arising in any way out of
// xxdz	the use of this software, even if advised of the possibility of such damage.
// mitv	
// ljll	Intelligent Systems Laboratory (iSys Lab)
// cszy	Faculty of Engineering, Prince of Songkla University, THAILAND
// jdpr	Project leader by Nikom SUVONVORN
// nidx	Project website at http://code.google.com/p/openvss/

using System;
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
using NLog;

namespace Vs.Encoder.Avi
{
    public class VsAviEncoder : VsCoreEncoder, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        private int width, height;

        // Encoder
        private AviEncoder vsEncoder = null;

        // Constructor
        public VsAviEncoder(long syncTimer) : base(syncTimer)
        {
        }

        // Dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(true);

            // stop encoder
            if (vsEncoder != null)
            {
                vsEncoder.Dispose();
                vsEncoder = null;
            }
        }

        // create new viddo file
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void StartRecord()
        {
            if (vsEncoder == null)
            {
                try
                {
                    // new object
                    vsEncoder = new AviEncoder();
                }
                catch (Exception err)
                {
                    // error log
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                }
            }
            else return;

            try
            {
                // check & create directory
                process_DirName();

                // create new file
                vsEncoder.StartRecord("wmv3", aviName, (int)(1000 / syncTimer), width, height);

                // init encoder
                InitEncoder();

                // start counter
                StartCounter();
            }
            catch (Exception err)
            {
                // error log
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

                // if error stop record
                StopRecord();
            }
        }

        // ---------------------------------------------------------------
        // add image's files to video
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void DoRecord(VsImage lastFrame)
        {
            if (vsEncoder == null) return;

            try
            {
                // record frame
                vsEncoder.DoRecord(lastFrame.Image);
            }
            catch (Exception err)
            {
                // error log
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

                // if error stop record
                StopRecord();
            }
        }
        
        // ---------------------------------------------------------------
        // stop encoder
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void StopRecord()
        {
            if (vsEncoder == null) return;

            // stop counter
            StopCounter();

            // stop timer
            StopEncoder();

            try
            {
                // stop encoder
                vsEncoder.StopRecord();
                vsEncoder.Dispose();
                vsEncoder = null;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);

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
                    width = lastFrame.Image.Width;
                    height = lastFrame.Image.Height;
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
