// oxbm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wbsk	
// beox	 By downloading, copying, installing or using the software you agree to this license.
// trnm	 If you do not agree to this license, do not download, install,
// ffmk	 copy or use the software.
// bgmg	
// zvqs	                          License Agreement
// xndv	         For OpenVss - Open Source Video Surveillance System
// ogfp	
// psqt	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// cojn	
// joyw	Third party copyrights are property of their respective owners.
// yxuw	
// khwh	Redistribution and use in source and binary forms, with or without modification,
// luma	are permitted provided that the following conditions are met:
// kzno	
// btjn	  * Redistribution's of source code must retain the above copyright notice,
// lyxn	    this list of conditions and the following disclaimer.
// ptin	
// xzwk	  * Redistribution's in binary form must reproduce the above copyright notice,
// wuuz	    this list of conditions and the following disclaimer in the documentation
// tglh	    and/or other materials provided with the distribution.
// jydu	
// gpic	  * Neither the name of the copyright holders nor the names of its contributors 
// aulq	    may not be used to endorse or promote products derived from this software 
// flla	    without specific prior written permission.
// ahgq	
// yjjl	This software is provided by the copyright holders and contributors "as is" and
// ybdq	any express or implied warranties, including, but not limited to, the implied
// fouu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hbdn	In no event shall the Prince of Songkla University or contributors be liable 
// udgz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kfmc	(including, but not limited to, procurement of substitute goods or services;
// ngfl	loss of use, data, or profits; or business interruption) however caused
// itzm	and on any theory of liability, whether in contract, strict liability,
// zuiz	or tort (including negligence or otherwise) arising in any way out of
// oswe	the use of this software, even if advised of the possibility of such damage.

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
