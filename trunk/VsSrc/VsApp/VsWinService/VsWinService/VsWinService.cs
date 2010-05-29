// ckva	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// amtv	
// dgsd	 By downloading, copying, installing or using the software you agree to this license.
// xmbd	 If you do not agree to this license, do not download, install,
// piym	 copy or use the software.
// zrfq	
// blum	                          License Agreement
// mbgt	         For OpenVSS - Open Source Video Surveillance System
// gkdq	
// eeiq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lugg	
// qblv	Third party copyrights are property of their respective owners.
// dvej	
// mdbl	Redistribution and use in source and binary forms, with or without modification,
// ffzp	are permitted provided that the following conditions are met:
// rgjb	
// zzwn	  * Redistribution's of source code must retain the above copyright notice,
// ilzk	    this list of conditions and the following disclaimer.
// ziae	
// kyzz	  * Redistribution's in binary form must reproduce the above copyright notice,
// zzjr	    this list of conditions and the following disclaimer in the documentation
// xxgd	    and/or other materials provided with the distribution.
// isly	
// ftye	  * Neither the name of the copyright holders nor the names of its contributors 
// kfhr	    may not be used to endorse or promote products derived from this software 
// eyms	    without specific prior written permission.
// vuje	
// cwah	This software is provided by the copyright holders and contributors "as is" and
// fzqs	any express or implied warranties, including, but not limited to, the implied
// xseb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sseq	In no event shall the Prince of Songkla University or contributors be liable 
// zaeg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jvtf	(including, but not limited to, procurement of substitute goods or services;
// qhua	loss of use, data, or profits; or business interruption) however caused
// nqvc	and on any theory of liability, whether in contract, strict liability,
// ncam	or tort (including negligence or otherwise) arising in any way out of
// resf	the use of this software, even if advised of the possibility of such damage.
// dghs	
// bgzl	Intelligent Systems Laboratory (iSys Lab)
// tvsu	Faculty of Engineering, Prince of Songkla University, THAILAND
// pdvh	Project leader by Nikom SUVONVORN
// cvqy	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using Vs.Server;
using System.Globalization;
using System.Threading;
using System.Reflection;
using NLog;

namespace Vs.WinService
{
    public partial class VsWinService : ServiceBase
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private BackgroundWorker vsWorker = null;

        bool control;

        public VsWinService()
        {
            InitializeComponent();

            Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable("VsPath", EnvironmentVariableTarget.Machine));

            // Initialize eventLogSimple 
            if (!System.Diagnostics.EventLog.SourceExists("VsSource"))
                System.Diagnostics.EventLog.CreateEventSource("VsSource", "VsLog");
            eventLog.Source = "VsSource";
            eventLog.Log = "VsLog";

            // start worker thread
            vsWorker = new BackgroundWorker();
            vsWorker.WorkerSupportsCancellation = true;
            vsWorker.DoWork += new DoWorkEventHandler(vsWorker_DoWork);
            vsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vsWorker_RunWorkerCompleted);
        }

        //(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath));

        void vsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            eventLog.WriteEntry("VsService completed");
        }
        bool bLoop;

        void vsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //int vsHour = 3;
            //int vsMinute = 30;
            int vsWait = 5000;
            //

            //while (bLoop)
            //{
            //    bLoop = false;

            // create server object
            VsServer vsServer = new VsServer();

            // start server
            bool bStarted = vsServer.StartServer();
            eventLog.WriteEntry("StartServer->" + bStarted.ToString());
            Thread.Sleep(vsWait);

            // start camera
            vsServer.StartAll();
            eventLog.WriteEntry("StartCameras");
            Thread.Sleep(vsWait);

            while (control)//(!vsWorker.CancellationPending && !bLoop)
            {
                // DateTime date = DateTime.Now;

                // if (date.Hour == vsHour && date.Minute >= vsMinute && date.Minute <= vsMinute + 1) bLoop = true;

                Thread.Sleep(vsWait);
            }

            // stop camera
            vsServer.StopAll();
            eventLog.WriteEntry("StopCameras");
            Thread.Sleep(vsWait);

            // stop server
            vsServer.ShutdownServer();
            eventLog.WriteEntry("ShutdownServer");
            Thread.Sleep(vsWait);

            vsServer = null;

            // sleep for five minutes
            // if (bLoop) Thread.Sleep(vsWait * 12);
            // }
        }

        protected override void OnStart(string[] args)
        {

            control = true;
            vsWorker.RunWorkerAsync(args);
        }

        protected override void OnStop()
        {
            control = false;
            //vsWorker.CancelAsync();
            while (vsWorker.IsBusy) Thread.Sleep(1000);

            eventLog.WriteEntry("VsService stoped!");
            
            Environment.Exit(10);
        }

        private void SendError(String msgErr)
        {
            logger.Log(LogLevel.Error, msgErr);
            eventLog.WriteEntry(msgErr);
        }
    }
}
