// swof	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// imcu	
// ombq	 By downloading, copying, installing or using the software you agree to this license.
// solo	 If you do not agree to this license, do not download, install,
// cwov	 copy or use the software.
// rddh	
// qoiz	                          License Agreement
// cryd	         For OpenVSS - Open Source Video Surveillance System
// taaj	
// hhvf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kkar	
// ybci	Third party copyrights are property of their respective owners.
// hbwd	
// pocp	Redistribution and use in source and binary forms, with or without modification,
// thpu	are permitted provided that the following conditions are met:
// dcsw	
// oyxs	  * Redistribution's of source code must retain the above copyright notice,
// obhv	    this list of conditions and the following disclaimer.
// ajlg	
// cmjo	  * Redistribution's in binary form must reproduce the above copyright notice,
// lzsa	    this list of conditions and the following disclaimer in the documentation
// uune	    and/or other materials provided with the distribution.
// xlqz	
// rbbh	  * Neither the name of the copyright holders nor the names of its contributors 
// sdcz	    may not be used to endorse or promote products derived from this software 
// ejug	    without specific prior written permission.
// uadg	
// dwmh	This software is provided by the copyright holders and contributors "as is" and
// ybie	any express or implied warranties, including, but not limited to, the implied
// krct	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ksvc	In no event shall the Prince of Songkla University or contributors be liable 
// lhey	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hdoy	(including, but not limited to, procurement of substitute goods or services;
// jjjb	loss of use, data, or profits; or business interruption) however caused
// flgt	and on any theory of liability, whether in contract, strict liability,
// rgab	or tort (including negligence or otherwise) arising in any way out of
// yibq	the use of this software, even if advised of the possibility of such damage.
// txxa	
// bjpl	Intelligent Systems Laboratory (iSys Lab)
// orvm	Faculty of Engineering, Prince of Songkla University, THAILAND
// weza	Project leader by Nikom SUVONVORN
// hnyp	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;

using System.Globalization;
using System.Threading;
using System.Reflection;
using Vs.Core.MediaProxyServer;


namespace VsMediaProxyServerWinService
{
    public partial class VsMediaProxyServerWinService : ServiceBase
    {

        private BackgroundWorker vsWorker = null;

        bool control;
        string appPath;
        public VsMediaProxyServerWinService()
        {
            InitializeComponent();

           // Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable("VsPath", EnvironmentVariableTarget.Machine));
              
            appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
           // File.AppendAllText(Path.Combine(appPath, "serviceMsg.txt"), appPath + "appPath\r\n");
            //Directory.SetCurrentDirectory(appPath);

            
           // File.AppendAllText("c:\\serviceMsg.txt", Directory.GetCurrentDirectory() + "curdir\r\n");

            vsWorker = new BackgroundWorker();
            vsWorker.WorkerSupportsCancellation = true;
            vsWorker.DoWork += new DoWorkEventHandler(vsWorker_DoWork);
            vsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vsWorker_RunWorkerCompleted);

            File.AppendAllText(Path.Combine(appPath, "MediaProxyServiceMsg.txt"),DateTime.Now.ToString()+" Con service\r\n");

        }

        //(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath));
        HttpServer httpServer;
        void vsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            File.AppendAllText(Path.Combine(appPath, "MediaProxyServiceMsg.txt"), DateTime.Now.ToString() + "DoWork\r\n");
           // string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
            //File.AppendAllText("c:\\serviceMsg.txt", appPath + "appPath\r\n");


            try
            {
                string ProviderPath = Path.Combine(appPath, "Provider");
                httpServer = new VsMediaProxyServer(8080, "C:\\VsData"
                    , appPath, ProviderPath);

            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(appPath, "MediaProxyServiceMsg.txt"), DateTime.Now.ToString() + ex.Message + "\r\n");
                return;
            }
            httpServer.Start();

            control = true;
          
            while (control)//(!vsWorker.CancellationPending && !bLoop)
            {
                // DateTime date = DateTime.Now;

                // if (date.Hour == vsHour && date.Minute >= vsMinute && date.Minute <= vsMinute + 1) bLoop = true;
               // File.AppendAllText("c:\\serviceMsg.txt", HttpServer.output + "output\r\n");
                Thread.Sleep(5000);
            }
           // File.AppendAllText("c:\\serviceMsg.txt", "out loop\r\n");
        }


        void vsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("WorkerCompleted");
            //eventLog.WriteEntry("VsService completed");
        }
        protected override void OnStart(string[] args)
        {
            //  System.Windows.Forms.MessageBox.Show("OnStart");
            File.AppendAllText(Path.Combine(appPath, "MediaProxyServiceMsg.txt"), DateTime.Now.ToString() + "OnStart\r\n");
            control = true;
            vsWorker.RunWorkerAsync(args);
        }

        protected override void OnStop()
        {
            //System.Windows.Forms.MessageBox.Show("OnStop");
            File.AppendAllText(Path.Combine(appPath, "MediaProxyServiceMsg.txt"), DateTime.Now.ToString() + "OnStop\r\n");
            control = false;
            while (vsWorker.IsBusy) Thread.Sleep(1000);

            if (httpServer != null)
            {
                httpServer.Stop();
            }

            Environment.Exit(10);
        }

    }
}
