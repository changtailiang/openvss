// iewt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fdpn	
// knjj	 By downloading, copying, installing or using the software you agree to this license.
// fxvh	 If you do not agree to this license, do not download, install,
// uzod	 copy or use the software.
// nzsk	
// jkiq	                          License Agreement
// pgut	         For OpenVss - Open Source Video Surveillance System
// iaie	
// sokg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// zucm	
// uftz	Third party copyrights are property of their respective owners.
// qxeg	
// ebtj	Redistribution and use in source and binary forms, with or without modification,
// mlkv	are permitted provided that the following conditions are met:
// uzye	
// sqbf	  * Redistribution's of source code must retain the above copyright notice,
// oqpf	    this list of conditions and the following disclaimer.
// oies	
// wgpd	  * Redistribution's in binary form must reproduce the above copyright notice,
// rizr	    this list of conditions and the following disclaimer in the documentation
// boog	    and/or other materials provided with the distribution.
// hzsg	
// eplz	  * Neither the name of the copyright holders nor the names of its contributors 
// wxue	    may not be used to endorse or promote products derived from this software 
// dola	    without specific prior written permission.
// hyrw	
// wamg	This software is provided by the copyright holders and contributors "as is" and
// whdl	any express or implied warranties, including, but not limited to, the implied
// zhdd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cvyp	In no event shall the Prince of Songkla University or contributors be liable 
// xjbz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xewy	(including, but not limited to, procurement of substitute goods or services;
// mlzc	loss of use, data, or profits; or business interruption) however caused
// xzjc	and on any theory of liability, whether in contract, strict liability,
// xsjg	or tort (including negligence or otherwise) arising in any way out of
// mmjx	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections;
using System.Runtime.CompilerServices;
using Vs.Core.Image;
using System.Globalization;
using NLog;

namespace Vs.Core.EmailAlert
{
    public class VsEmailGenerator : IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        // Database host
        private string smtpHost;
        private string smtpPort;
        private string smtpUser;
        private string smtpPasswd;
        private string emailFrom;
        private string emailTo;

        private long syncTimer = 200;

        // buffer
        protected Queue dataBuffer = null;

        // timer
        private System.Threading.Timer timer = null;
        private TimerCallback tcallback = null;

        // -----------------------------------------------------------------------------------------------------------------------
        // Database host properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Database host property
        public string SmtpHost
        {
            get { return smtpHost; }
            set { smtpHost = value; }
        }

        // Database host property
        public string SmtpPort
        {
            get { return smtpPort; }
            set { smtpPort = value; }
        }

        // Data user property
        public string SmtpUser
        {
            get { return smtpUser; }
            set { smtpUser = value; }
        }

        // Data password property
        public string SmtpPasswd
        {
            get { return smtpPasswd; }
            set { smtpPasswd = value; }
        }

        // EmailFrom password property
        public string EmailFrom
        {
            get { return emailFrom; }
            set { emailFrom = value; }
        }

        // EmailTo password property
        public string EmailTo
        {
            get { return emailTo; }
            set { emailTo = value; }
        }

        // Constructor
        public VsEmailGenerator(long syncTimer, string smtpHost, string smtpUser, string smtpPasswd, string emailFrom, string emailTo)
        {
            try
            {
                this.syncTimer = syncTimer;

                // data host
                this.smtpHost = smtpHost;
                this.smtpUser = smtpUser;
                this.smtpPasswd = smtpPasswd;
                this.emailFrom = emailFrom;
                this.emailTo = emailTo;

                // synchronized queue
                dataBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);
                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
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

                    dataBuffer.Clear();
                    dataBuffer = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        // On new frame ready
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn(object sender, VsDataEventArgs e)
        {
            try
            {
                /*
                if (dataBuffer.Count > 1000 / syncTimer)
                {
                    VsData rm = (VsData)dataBuffer.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from EmailGenerator");
                }*/

                VsData img = (VsData)e.Data.Clone();
                dataBuffer.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object stateInfo)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

            VsData lastData = null;

            try
            {
                // get new one
                if (dataBuffer.Count > 0)
                {
                    lastData = (VsData)dataBuffer.Dequeue();
                }

                if (lastData != null)
                {
                    // save image
                    DateTime dNow = DateTime.Now;
                    string filename = String.Format("{0}_{1}_{2}_{3}_{4}_{5}.jpg",
                        dNow.Year.ToString(),
                        dNow.Month.ToString(),
                        dNow.Day.ToString(),
                        dNow.Hour.ToString(),
                        dNow.Minute.ToString(),
                        dNow.Second.ToString());

                    lastData.Image.Save(filename, ImageFormat.Jpeg);

                    // send image
                    SmtpClient mySmtpClient = null;
                    MailMessage myMail = null;

                    try
                    {
                        mySmtpClient = new SmtpClient(smtpHost);

                        // set smtp-client with basicAuthentication    
                        mySmtpClient.UseDefaultCredentials = false;
                        System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(smtpUser, smtpPasswd);
                        mySmtpClient.Credentials = basicAuthenticationInfo;

                        // add from,to mailaddresses   
                        MailAddress from = new MailAddress(emailFrom, "Personal Security Alert");
                        MailAddress to = new MailAddress(emailTo, "Yourself");
                        myMail = new System.Net.Mail.MailMessage(from, to);

                        // add ReplyTo   
                        MailAddress replyto = new MailAddress(emailFrom);
                        myMail.ReplyTo = replyto;

                        // set subject and encoding   myMail.Subject = "Test message";   
                        myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                        // set body-message and encoding   
                        myMail.Subject = "เตือน! เหตุผิดปกติ จาก Personal Security System";
                        myMail.Body = "<b> เหตุผิดปกติ  !!! </b><br> <b>  </b> <br> <b> เวลา " + DateTime.Now.ToString() + " ดูเอกสารแนบ </b>.";
                        myMail.BodyEncoding = System.Text.Encoding.UTF8;   // text or html   

                        // set file attachment for this e-mail message.
                        Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);

                        // Add time stamp information for the file.
                        ContentDisposition disposition = data.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(filename);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(filename);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(filename);

                        // Add the file attachment to this e-mail message.
                        myMail.Attachments.Add(data);

                        myMail.IsBodyHtml = true;

                        mySmtpClient.Send(myMail);
                    }
                    catch (SmtpException err)
                    {
                        logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                    }
                    finally
                    {    
                        if (mySmtpClient != null)
                        {
                            mySmtpClient = null;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
    }
}
