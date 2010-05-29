// kxvy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cnxn	
// bpol	 By downloading, copying, installing or using the software you agree to this license.
// wzxw	 If you do not agree to this license, do not download, install,
// wawr	 copy or use the software.
// stld	
// dfho	                          License Agreement
// ekyn	         For OpenVSS - Open Source Video Surveillance System
// wfnq	
// bigr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xegm	
// fmdt	Third party copyrights are property of their respective owners.
// gpll	
// davq	Redistribution and use in source and binary forms, with or without modification,
// mrvx	are permitted provided that the following conditions are met:
// fiir	
// rbor	  * Redistribution's of source code must retain the above copyright notice,
// lgvn	    this list of conditions and the following disclaimer.
// ueto	
// nyyr	  * Redistribution's in binary form must reproduce the above copyright notice,
// cohp	    this list of conditions and the following disclaimer in the documentation
// zmjw	    and/or other materials provided with the distribution.
// jxek	
// njmp	  * Neither the name of the copyright holders nor the names of its contributors 
// vpve	    may not be used to endorse or promote products derived from this software 
// ylhz	    without specific prior written permission.
// uyry	
// hgcn	This software is provided by the copyright holders and contributors "as is" and
// sduq	any express or implied warranties, including, but not limited to, the implied
// atre	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rsho	In no event shall the Prince of Songkla University or contributors be liable 
// clzl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// setx	(including, but not limited to, procurement of substitute goods or services;
// dusq	loss of use, data, or profits; or business interruption) however caused
// ghub	and on any theory of liability, whether in contract, strict liability,
// vkod	or tort (including negligence or otherwise) arising in any way out of
// urrj	the use of this software, even if advised of the possibility of such damage.
// ovoc	
// xqmg	Intelligent Systems Laboratory (iSys Lab)
// dtxj	Faculty of Engineering, Prince of Songkla University, THAILAND
// yfgc	Project leader by Nikom SUVONVORN
// nfky	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Vs.Core.Client.Command;
using System.Globalization;
using NLog; 

namespace Vs.Client
{
    public partial class frmMain : Form
    {        
        static Logger logger = LogManager.GetCurrentClassLogger();
        bool bConnected;

        private Vs.Core.Client.Command.CommandClient client = null;

        public frmMain()
        {
            InitializeComponent();
            bConnected = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null) this.client.Disconnect();
        }

        private void LoginToServer(String serverIP)
        {
            try
            {
                if (client == null)
                {
                    this.client = new Vs.Core.Client.Command.CommandClient(IPAddress.Parse(serverIP), 8000, "None");
                    this.client.CommandReceived += new CommandReceivedEventHandler(client_CommandReceived);
                    this.client.ConnectingSuccessed += new ConnectingSuccessedEventHandler(client_ConnectingSuccessed);
                    this.client.ConnectingFailed += new ConnectingFailedEventHandler(client_ConnectingFailed);
                    this.client.NetworkName = "VsClient";
                }
                this.client.ConnectToServer();
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        private void client_ConnectingFailed(object sender, EventArgs e)
        {
            MessageBox.Show("Server Is Not Accessible !");
        }

        private void client_ConnectingSuccessed(object sender, EventArgs e)
        {
            MessageBox.Show("Connecting successed");
        }

        private void client_CommandReceived(object sender , CommandEventArgs e)
        {
            switch (e.Command.CommandType)
            {

                /// bool Start();

                case CommandType.VS_START:
                    Console.WriteLine("COMMAND : VS_START...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //Start(e.Command.MetaData);
                    break;

                /// bool StartAll();

                case CommandType.VS_START_ALL:
                    Console.WriteLine("COMMAND : VS_START_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartAll(e.Command.MetaData);
                    break;

                /// bool Stop();

                case CommandType.VS_STOP:
                    Console.WriteLine("COMMAND : VS_STOP...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //Stop(e.Command.MetaData);
                    break;

                /// bool StopAll();

                case CommandType.VS_STOP_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //Stop(e.Command.MetaData);
                    break;

                /// bool StartConnect(String camName)

                case CommandType.VS_START_CONNECT:
                    Console.WriteLine("COMMAND : VS_START_CONNECT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartConnect(e.Command.MetaData);
                    break;

                /// bool StartConnectAll()

                case CommandType.VS_START_CONNECT_ALL:
                    Console.WriteLine("COMMAND : VS_START_CONNECT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartConnectAll(e.Command.MetaData);
                    break;

                /// bool StopConnect(String camName);

                case CommandType.VS_STOP_CONNECT:
                    Console.WriteLine("COMMAND : VS_STOP_CONNECT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopConnect(e.Command.MetaData);
                    break;

                /// bool StopConnectAll();

                case CommandType.VS_STOP_CONNECT_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_CONNECT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopConnectAll(e.Command.MetaData);
                    break;


                /// bool StartAnalyse(String camName);

                case CommandType.VS_START_ANALYSE:
                    Console.WriteLine("COMMAND : VS_START_ANALYSE...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartAnalyse(e.Command.MetaData);
                    break;

                /// bool StartAnalyseAll();

                case CommandType.VS_START_ANALYSE_ALL:
                    Console.WriteLine("COMMAND : VS_START_ANALYSE_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartAnalyseAll(e.Command.MetaData);
                    break;

                /// bool StopAnalyse(String camName);

                case CommandType.VS_STOP_ANALYSE:
                    Console.WriteLine("COMMAND : VS_STOP_ANALYSE...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopAnalyse(e.Command.MetaData);
                    break;

                ///  bool StopAnalyseAll();

                case CommandType.VS_STOP_ANALYSE_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_ANALYSE_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopAnalyseAll(e.Command.MetaData);
                    break;


                /// bool StartEventAlert(String camName);

                case CommandType.VS_START_EVENT_ALERT:
                    Console.WriteLine("COMMAND : VS_START_EVENT_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartEventAlert(e.Command.MetaData);
                    break;

                /// bool StartEventAlertAll();

                case CommandType.VS_START_EVENT_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_START_EVENT_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartEventAlertAll(e.Command.MetaData);
                    break;

                /// bool StopEventAlert(String camName);

                case CommandType.VS_STOP_EVENT_ALERT:
                    Console.WriteLine("COMMAND : VS_STOP_EVENT_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopEventAlert(e.Command.MetaData);
                    break;

                /// bool StopEventAlertAll();

                case CommandType.VS_STOP_EVENT_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_EVENT_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopEventAlertAll(e.Command.MetaData);
                    break;


                /// bool StartRecord(String camName);

                case CommandType.VS_START_RECORD:
                    Console.WriteLine("COMMAND : VS_START_RECORD...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartRecord(e.Command.MetaData);
                    break;

                /// bool StartRecordAll();

                case CommandType.VS_START_RECORD_ALL:
                    Console.WriteLine("COMMAND : VS_START_RECORD_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartRecordAll(e.Command.MetaData);
                    break;

                /// bool StopRecord(String camName);

                case CommandType.VS_STOP_RECORD:
                    Console.WriteLine("COMMAND : VS_STOP_RECORD...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopRecord(e.Command.MetaData);
                    break;

                /// bool StopRecordAll();

                case CommandType.VS_STOP_RECORD_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_RECORD_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopRecordAll(e.Command.MetaData);
                    break;


                /// bool StartDataAlert(String camName);

                case CommandType.VS_START_DATA_ALERT:
                    Console.WriteLine("COMMAND : VS_START_DATA_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartDataAlert(e.Command.MetaData);
                    break;

                /// bool StartDataAlertAll();

                case CommandType.VS_START_DATA_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_START_DATA_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StartDataAlertAll(e.Command.MetaData);
                    break;

                /// bool StopDataAlert(String camName);

                case CommandType.VS_STOP_DATA_ALERT:
                    Console.WriteLine("COMMAND : VS_STOP_DATA_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopDataAlert(e.Command.MetaData);
                    break;

                /// bool StopDataAlertAll();

                case CommandType.VS_STOP_DATA_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_DATA_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); listBox1.Items.Add("=>" + e.Command.MetaData);
                    //StopDataAlertAll(e.Command.MetaData);
                    break;


                /// String[] ListCameras();

                case CommandType.VS_LIST_CAMERAS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); String[] strList = e.Command.MetaData.Split(';');  foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCameras(e.Command.MetaData);
                    break;

                /// String[] ListCamerasConnect();

                case CommandType.VS_LIST_CAMERAS_CONNECT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_CONNECT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null;  strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCamerasConnect(e.Command.MetaData);
                    break;

                /// String[] ListCamerasAnalyse();

                case CommandType.VS_LIST_CAMERAS_ANALYSE_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_ANALYSE_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCamerasAnalyse(e.Command.MetaData);
                    break;

                /// String[] ListCamerasEventAlert();

                case CommandType.VS_LIST_CAMERAS_EVENT_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_EVENT_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCamerasEventAlert(e.Command.MetaData);
                    break;

                /// String[] ListCamerasRecord();

                case CommandType.VS_LIST_CAMERAS_RECORD_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_RECORD_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCamerasRecord(e.Command.MetaData);
                    break;

                /// String[] ListCamerasDataAlert();

                case CommandType.VS_LIST_CAMERAS_DATA_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_DATA_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCamerasDataAlert(e.Command.MetaData);
                    break;


                /// String ListCameraConnect(String camName);

                case CommandType.VS_LIST_CAMERA_CONNECT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_CONNECT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCameraConnect(e.Command.MetaData);
                    break;

                /// String ListCameraAnalyse(String camName);

                case CommandType.VS_LIST_CAMERA_ANALYSE_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_ANALYSE_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCameraAnalyse(e.Command.MetaData);
                    break;

                /// String ListCameraEventAlert(String camName);

                case CommandType.VS_LIST_CAMERA_EVENT_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_EVENT_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCameraEventAlert(e.Command.MetaData);
                    break;

                /// String ListCameraRecord(String camName);

                case CommandType.VS_LIST_CAMERA_RECORD_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_RECORD_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCameraRecord(e.Command.MetaData);
                    break;

                /// String ListCameraDataAlert(String camName);

                case CommandType.VS_LIST_CAMERA_DATA_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_DATA_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListCameraDataAlert(e.Command.MetaData);
                    break;


                /// vsStatus infomation

                case CommandType.VS_INFO:
                    Console.WriteLine("COMMAND : VS_INFO...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData); strList = null; strList = e.Command.MetaData.Split(';'); foreach (String str in strList) { if(str.Length>0) listBox1.Items.Add("=>" + str); }
                    //ListInfo(e.Command.MetaData);
                    break;
            }
        }

        /// <summary>
        /// GetCameraName
        /// </summary>
        /// <returns></returns>
        String GetCameraName()
        {
            String vsList = "";

            if (listBox1.SelectedItem != null)
            {
                vsList = listBox1.SelectedItem.ToString();

                if (vsList.Length > 0)
                {
                    String []vList = vsList.Split(',');
                    return vList[0].Remove(0,2);
                }
            }

            return vsList;
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="metaData"></param>
        void Start(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START" + ";" + cmd.MetaData); 
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="metaData"></param>
        void Stop(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError(err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartConnect
        /// </summary>
        /// <param name="metaData"></param>
        void StartConnect(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_CONNECT, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_CONNECT" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartConnectAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartConnectAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_CONNECT_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_CONNECT_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopConnect
        /// </summary>
        /// <param name="metaData"></param>
        void StopConnect(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_CONNECT, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_CONNECT" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopConnectAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopConnectAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_CONNECT_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_CONNECT_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void StartAnalyse(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_ANALYSE, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_ANALYSE" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartAnalyseAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartAnalyseAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_ANALYSE_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_ANALYSE_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void StopAnalyse(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_ANALYSE, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_ANALYSE" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopAnalyseAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopAnalyseAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_ANALYSE_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_ANALYSE_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StartEventAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_EVENT_ALERT, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_EVENT_ALERT" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartEventAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartEventAlertAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_EVENT_ALERT_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_EVENT_ALERT_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StopEventAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_EVENT_ALERT, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_EVENT_ALERT" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopEventAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopEventAlertAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_EVENT_ALERT_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_EVENT_ALERT_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartRecord
        /// </summary>
        /// <param name="metaData"></param>
        void StartRecord(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_RECORD, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_RECORD" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartRecordAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartRecordAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_RECORD_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_RECORD_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopRecord
        /// </summary>
        /// <param name="metaData"></param>
        void StopRecord(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_RECORD, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_RECORD" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopRecordAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopRecordAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_RECORD_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_RECORD_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StartDataAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_DATA_ALERT, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_DATA_ALERT" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartDataAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartDataAlertAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_START_DATA_ALERT_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_START_DATA_ALERT_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StopDataAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_DATA_ALERT, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_DATA_ALERT" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopDataAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopDataAlertAll(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_STOP_DATA_ALERT_ALL, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_STOP_DATA_ALERT_ALL" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameras
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameras(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERAS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERAS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasConnect
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasConnect(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_CONNECT_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERAS_CONNECT_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasAnalyse(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_ANALYSE_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERAS_ANALYSE_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasEventAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_EVENT_ALERT_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERAS_EVENT_ALERT_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasRecord
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasRecord(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_RECORD_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERAS_RECORD_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasDataAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_DATA_ALERT_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERAS_DATA_ALERT_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraConnect
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraConnect(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERA_CONNECT_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERA_CONNECT_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraAnalyse(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERA_ANALYSE_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERA_ANALYSE_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraEventAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERA_EVENT_ALERT_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERA_EVENT_ALERT_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraRecord
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraRecord(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERA_RECORD_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERA_RECORD_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraDataAlert(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_LIST_CAMERA_DATA_ALERT_STATUS, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_LIST_CAMERA_DATA_ALERT_STATUS" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListInfo
        /// </summary>
        /// <param name="metaData"></param>
        void ListInfo(String metaData)
        {
            try
            {
                Command cmd = new Command(CommandType.VS_INFO, metaData);
                client.SendCommand(cmd); listBox1.Items.Add("<=" + "VS_INFO" + ";" + cmd.MetaData);
            }
            catch (Exception err)
            {
                SendError( err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        private void SendError(String cmdMsg)
        {
            Console.WriteLine(cmdMsg);
            logger.Log(LogLevel.Error, cmdMsg);
        }

        private void VS_START_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();
            listBox1.Items.Clear();

            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Start(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_START_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StartAll("VS_START_ALL");
        }

        private void VS_STOP_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();
            listBox1.Items.Clear();

            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Stop(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_STOP_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StopAll("VS_STOP_ALL");
        }

        private void VS_START_CONNECT_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();
            listBox1.Items.Clear();

            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StartConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_START_CONNECT_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StartConnectAll("VS_START_CONNECT_ALL");
        }

        private void VS_STOP_CONNECT_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StopConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_STOP_CONNECT_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StopConnectAll("VS_STOP_CONNECT_ALL");
        }

        private void VS_START_ANALYSE_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StartAnalyse(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_START_ANALYSE_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StartAnalyseAll("VS_START_ANALYSE_ALL");
        }

        private void VS_STOP_ANALYSE_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StopAnalyse(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_STOP_ANALYSE_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StopAnalyseAll("VS_STOP_ANALYSE_ALL");
        }

        private void VS_START_EVENT_ALERT_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StartEventAlert(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_START_EVENT_ALERT_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StartEventAlertAll("VS_START_EVENT_ALERT_ALL");
        }

        private void VS_STOP_EVENT_ALERT_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StopEventAlert(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_STOP_EVENT_ALERT_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StopEventAlertAll("VS_STOP_EVENT_ALERT_ALL");
        }

        private void VS_START_RECORD_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StartRecord(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_START_RECORD_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StartRecordAll("VS_START_RECORD_ALL");
        }

        private void VS_STOP_RECORD_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StopRecord(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_STOP_RECORD_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StopRecordAll("VS_STOP_RECORD_ALL");
        }

        private void VS_START_DATA_ALERT_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StartDataAlert(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_START_DATA_ALERT_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StartDataAlertAll("VS_START_DATA_ALERT_ALL");
        }

        private void VS_STOP_DATA_ALERT_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.StopDataAlert(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_STOP_DATA_ALERT_ALL_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.StopDataAlertAll("VS_STOP_DATA_ALERT_ALL");
        }

        private void VS_LIST_CAMERAS_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.ListCameras("VS_LIST_CAMERAS");
        }

        private void VS_LIST_CAMERAS_CONNECT_STATUS_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.ListCamerasConnect("VS_LIST_CAMERAS_CONNECT_STATUS");
        }

        private void VS_LIST_CAMERAS_ANALYSE_STATUS_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.ListCamerasAnalyse("VS_LIST_CAMERAS_ANALYSE_STATUS");
        }

        private void VS_LIST_CAMERAS_EVENT_ALERT_STATUS_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.ListCamerasEventAlert("VS_LIST_CAMERAS_EVENT_ALERT_STATUS");
        }

        private void VS_LIST_CAMERAS_RECORD_STATUS_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.ListCamerasRecord("VS_LIST_CAMERAS_RECORD_STATUS");
        }

        private void VS_LIST_CAMERAS_DATA_ALERT_STATUS_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.ListCamerasDataAlert("VS_LIST_CAMERAS_DATA_ALERT_STATUS");
        }

        private void VS_LIST_CAMERA_CONNECT_STATUS_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK) 
                this.ListCameraConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_LIST_CAMERA_ANALYSE_STATUS_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.ListCameraConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_LIST_CAMERA_EVENT_ALERT_STATUS_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.ListCameraConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_LIST_CAMERA_RECORD_STATUS_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.ListCameraConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_LIST_CAMERA_DATA_ALERT_STATUS_Click(object sender, EventArgs e)
        {
            String camName = GetCameraName();

            listBox1.Items.Clear();
            if (camName.Length > 0 && MessageBox.Show("Camera Name : " + camName, "Camera Name", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.ListCameraConnect(camName);
            else MessageBox.Show("Please select Camera");
        }

        private void VS_INFO_Click(object sender, EventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bConnected)
            {
                frmLogin frm = new frmLogin();
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.LoginToServer(frm.strServer);
                    connectToolStripMenuItem.Text = "Disconnect";
                    bConnected = true;
                }                
            }
            else
            {
                if (client != null) client.Disconnect();
                connectToolStripMenuItem.Text = "Connect";
                bConnected = false;
            }
        }
    }       
}
