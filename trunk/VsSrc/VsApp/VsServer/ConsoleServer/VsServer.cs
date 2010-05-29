// zpvp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// okhv	
// gnog	 By downloading, copying, installing or using the software you agree to this license.
// neci	 If you do not agree to this license, do not download, install,
// tdih	 copy or use the software.
// pzjc	
// kymf	                          License Agreement
// mshz	         For OpenVSS - Open Source Video Surveillance System
// kkhz	
// vpor	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ggbf	
// jemv	Third party copyrights are property of their respective owners.
// meaz	
// vdvz	Redistribution and use in source and binary forms, with or without modification,
// fsfq	are permitted provided that the following conditions are met:
// ycin	
// fowd	  * Redistribution's of source code must retain the above copyright notice,
// xcnd	    this list of conditions and the following disclaimer.
// prbi	
// xdtf	  * Redistribution's in binary form must reproduce the above copyright notice,
// mqth	    this list of conditions and the following disclaimer in the documentation
// sieg	    and/or other materials provided with the distribution.
// ohtc	
// kxsd	  * Neither the name of the copyright holders nor the names of its contributors 
// yozv	    may not be used to endorse or promote products derived from this software 
// iiyj	    without specific prior written permission.
// rxjd	
// cnbb	This software is provided by the copyright holders and contributors "as is" and
// zzei	any express or implied warranties, including, but not limited to, the implied
// jbux	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kpop	In no event shall the Prince of Songkla University or contributors be liable 
// jlsr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yxkj	(including, but not limited to, procurement of substitute goods or services;
// dxxd	loss of use, data, or profits; or business interruption) however caused
// skqv	and on any theory of liability, whether in contract, strict liability,
// yaeb	or tort (including negligence or otherwise) arising in any way out of
// grdk	the use of this software, even if advised of the possibility of such damage.
// tkuw	
// tcls	Intelligent Systems Laboratory (iSys Lab)
// tiag	Faculty of Engineering, Prince of Songkla University, THAILAND
// esfe	Project leader by Nikom SUVONVORN
// csxb	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Reflection;
using Vs.Core.Server;
using Vs.Core.Server.Command;
using System.Globalization;
using NLog; 

namespace Vs.Server
{
    public class VsServer
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        private System.Collections.Generic.List<ClientManager> vsClients;
        private BackgroundWorker vsBackgroundListener;
        private Socket vsListenerSocket;
        private static VsCoreServer vsServer = VsCoreServer.Instance;

        private IPAddress vsServerIP;
        private String vsHostIP;
        private int vsHostPort;

        private String vsAppPath;
        private String vsSettingsFile;
        private String strMsg;

        #region Constructor/Destructor
        /// <summary>
        /// Start the console server.
        /// </summary>
        /// <param name="args">These are optional arguments.Pass the local ip address of the server as the first argument and the local port as the second argument.</param>
        public VsServer()
        {
            vsClients = new List<ClientManager>();

            vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0,8));
            vsSettingsFile = Path.Combine(vsAppPath, "server.config");
        }

        public VsServer(string path)
        {
            vsClients = new List<ClientManager>();

            vsAppPath = path;
            vsSettingsFile = Path.Combine(vsAppPath, "server.config");
        }        
        #endregion

        #region Save/Load Application Setting

        // Save application settings
        private void SaveSettings()
        {
            try
            {
                if (vsSettingsFile == null) return;
                // open file
                FileStream fs = new FileStream(vsSettingsFile, FileMode.Create);

                // create XML writer
                XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

                // use indenting for readability
                xmlOut.Formatting = Formatting.Indented;

                // start document
                xmlOut.WriteStartDocument();
                xmlOut.WriteComment("VsServer Configuration file");

                // main node
                xmlOut.WriteStartElement("Application");

                // localhost node
                xmlOut.WriteStartElement("LocalHost");
                xmlOut.WriteAttributeString("HostIP", vsHostIP);
                xmlOut.WriteAttributeString("HostPort", vsHostPort.ToString());
                xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                // close file
                xmlOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Log(LogLevel.Error, ex.Message);
            }
        }

        // Load application settings
        private bool LoadSettings()
        {
            bool ret = false;

            // check file existance
            if (File.Exists(vsSettingsFile))
            {
                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsSettingsFile, FileMode.Open);
                    // create XML reader
                    xmlIn = new XmlTextReader(fs);

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // check for main node
                    if (xmlIn.Name != "Application")
                        throw new ApplicationException("");

                    // ------------------------------------------------------------------------
                    // move to localhost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "LocalHost")
                        throw new ApplicationException("");

                    this.vsHostIP = xmlIn.GetAttribute("HostIP");
                    this.vsHostPort = Convert.ToInt32(xmlIn.GetAttribute("HostPort"));

                    ret = true;
                }
                // catch any exceptions
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.Message + " "+ vsSettingsFile);
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
            else logger.Log(LogLevel.Error, vsSettingsFile);
            return ret;
        }
        #endregion

        #region Start/Shutdown Server
        /// <summary>
        /// get mixer ip address
        /// </summary>
        private IPAddress GetServerIPAddress()
        {
            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            for (int i = 0; i < addressList.Length; i++)
            {
                if (addressList[i].ToString() == vsHostIP)
                    return addressList[i];
            }

            return null;
        }

        /// <summary>
        /// StartServer
        /// </summary>
        public bool StartServer()
        {
            try
            {
                strMsg = String.Format("Starting Server."); 
                Console.WriteLine(strMsg); SendStatus(strMsg); logger.Log(LogLevel.Info, strMsg);

                // Load VsService config
                if (!LoadSettings()) return false;
                //vsServerIP = GetServerIPAddress(); if (vsServerIP == null) return false;

                //LoadSettings();
                vsServerIP = GetServerIPAddress();

                // Start background listener
                vsBackgroundListener = new BackgroundWorker();
                vsBackgroundListener.WorkerSupportsCancellation = true;
                vsBackgroundListener.DoWork += new DoWorkEventHandler(StartToListen);
                vsBackgroundListener.RunWorkerAsync();

                strMsg = String.Format("Listening on port {0}{1}{2} started", vsHostIP, ":", vsHostPort);
                Console.WriteLine(strMsg); SendStatus(strMsg); logger.Log(LogLevel.Info, strMsg);

                // Load VsMonitor config
                vsServer.VsMonitorInitial(vsAppPath);

                strMsg = String.Format("Load VsServer Configuration");
                Console.WriteLine(strMsg); SendStatus(strMsg); logger.Log(LogLevel.Info, strMsg);

                return true;
            }
            catch (Exception err)
            {
                SendStatus(err.Message);
            }

            return false;
        }

        // ShutdownServer
        public void ShutdownServer()
        {
            try
            {
                if (this.vsClients != null)
                {
                    SaveSettings();

                    strMsg = String.Format("Shutdown VsServer.");
                    Console.WriteLine(strMsg); SendStatus(strMsg);

                    foreach (ClientManager mngr in this.vsClients) mngr.Disconnect();
                    GC.Collect();

                    this.vsBackgroundListener.CancelAsync();
                    this.vsBackgroundListener.Dispose();
                    this.vsListenerSocket.Close();

                    // mixer stop
                    vsServer.StopAll();
                    vsServer.Dispose();
                    vsServer = null;

                    Console.WriteLine("****VsServer Shutdown.**********************");
                }
            }
            catch (Exception err)
            {
                SendStatus(err.Message);
            }
        }

        // start thread for listener
        private void StartToListen(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.vsListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.vsListenerSocket.Bind(new IPEndPoint(this.vsServerIP, this.vsHostPort));
                this.vsListenerSocket.Listen(200);
                while (true)
                    this.CreateNewClientManager(this.vsListenerSocket.Accept());
            }
            catch (Exception ex)
            {
                SendStatus(ex.Message);
            }
        }

        // accepted socket
        private void CreateNewClientManager(Socket socket)
        {
            try
            {
                ClientManager vsClientManager = new ClientManager(socket);
                vsClientManager.CommandReceived += new CommandReceivedEventHandler(CommandReceived);
                vsClientManager.Disconnected += new DisconnectedEventHandler(ClientDisconnected);
                this.CheckForAbnormalDC(vsClientManager);
                this.vsClients.Add(vsClientManager);
                this.UpdateConsole("Connected.", vsClientManager.IP, vsClientManager.Port);
            }
            catch (Exception ex)
            {
                SendStatus(ex.Message);
            }
        }

        private void CheckForAbnormalDC(ClientManager mngr)
        {
            try
            {
                if (this.RemoveClientManager(mngr.IP))
                    this.UpdateConsole("Disconnected.", mngr.IP, mngr.Port);
            }
            catch (Exception ex)
            {
                SendStatus(ex.Message);
            }
        }

        void ClientDisconnected(object sender, ClientEventArgs e)
        {
            try
            {
                if (this.RemoveClientManager(e.IP))
                    this.UpdateConsole("Disconnected.", e.IP, e.Port);
            }
            catch (Exception ex)
            {
                SendStatus(ex.Message);
            }
        }

        private bool RemoveClientManager(IPAddress ip)
        {
            lock (this)
            {
                int index = this.IndexOfClient(ip);
                if (index != -1)
                {
                    string name = this.vsClients[index].ClientName;
                    this.vsClients.RemoveAt(index);
                    return true;
                }
                return false;
            }
        }

        private int IndexOfClient(IPAddress ip)
        {
            int index = -1;
            foreach (ClientManager cMngr in this.vsClients)
            {
                index++;
                if (cMngr.IP.Equals(ip))
                    return index;
            }
            return -1;
        }
        
        #endregion

        #region Command Receiver
        private void CommandReceived(object sender, CommandEventArgs e)
        {
            switch (e.Command.CommandType)
            {

                /// bool Start();

                case CommandType.VS_START:
                    Console.WriteLine("COMMAND : VS_START...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    Start(e.Command.MetaData);
                    break;

                /// bool StartFull();

                case CommandType.VS_START_ALL:
                    Console.WriteLine("COMMAND : VS_START_FULL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartAll();
                    break;

                /// bool Stop();

                case CommandType.VS_STOP:
                    Console.WriteLine("COMMAND : VS_STOP...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    Stop(e.Command.MetaData);
                    break;


                /// bool StopAll();

                case CommandType.VS_STOP_ALL:
                    Console.WriteLine("COMMAND : VS_STOP...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopAll();
                    break;

                /// bool StartConnect(String camName)

                case CommandType.VS_START_CONNECT:
                    Console.WriteLine("COMMAND : VS_START_CONNECT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartConnect(e.Command.MetaData);
                    break;

                /// bool StartConnectAll()

                case CommandType.VS_START_CONNECT_ALL:
                    Console.WriteLine("COMMAND : VS_START_CONNECT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartConnectAll();
                    break;

                /// bool StopConnect(String camName);

                case CommandType.VS_STOP_CONNECT:
                    Console.WriteLine("COMMAND : VS_STOP_CONNECT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopConnect(e.Command.MetaData);
                    break;

                /// bool StopConnectAll();

                case CommandType.VS_STOP_CONNECT_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_CONNECT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopConnectAll();
                    break;


                /// bool StartAnalyse(String camName);

                case CommandType.VS_START_ANALYSE:
                    Console.WriteLine("COMMAND : VS_START_ANALYSE...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartAnalyse(e.Command.MetaData);
                    break;

                /// bool StartAnalyseAll();

                case CommandType.VS_START_ANALYSE_ALL:
                    Console.WriteLine("COMMAND : VS_START_ANALYSE_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartAnalyseAll();
                    break;

                /// bool StopAnalyse(String camName);

                case CommandType.VS_STOP_ANALYSE:
                    Console.WriteLine("COMMAND : VS_STOP_ANALYSE...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopAnalyse(e.Command.MetaData);
                    break;

                ///  bool StopAnalyseAll();

                case CommandType.VS_STOP_ANALYSE_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_ANALYSE_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopAnalyseAll();
                    break;


                /// bool StartEventAlert(String camName);

                case CommandType.VS_START_EVENT_ALERT:
                    Console.WriteLine("COMMAND : VS_START_EVENT_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartEventAlert(e.Command.MetaData);
                    break;

                /// bool StartEventAlertAll();

                case CommandType.VS_START_EVENT_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_START_EVENT_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartEventAlertAll();
                    break;

                /// bool StopEventAlert(String camName);

                case CommandType.VS_STOP_EVENT_ALERT:
                    Console.WriteLine("COMMAND : VS_STOP_EVENT_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopEventAlert(e.Command.MetaData);
                    break;

                /// bool StopEventAlertAll();

                case CommandType.VS_STOP_EVENT_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_EVENT_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopEventAlertAll();
                    break;


                /// bool StartRecord(String camName);

                case CommandType.VS_START_RECORD:
                    Console.WriteLine("COMMAND : VS_START_RECORD...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartRecord(e.Command.MetaData);
                    break;

                /// bool StartRecordAll();

                case CommandType.VS_START_RECORD_ALL:
                    Console.WriteLine("COMMAND : VS_START_RECORD_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartRecordAll();
                    break;

                /// bool StopRecord(String camName);

                case CommandType.VS_STOP_RECORD:
                    Console.WriteLine("COMMAND : VS_STOP_RECORD...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopRecord(e.Command.MetaData);
                    break;

                /// bool StopRecordAll();

                case CommandType.VS_STOP_RECORD_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_RECORD_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopRecordAll();
                    break;


                /// bool StartDataAlert(String camName);

                case CommandType.VS_START_DATA_ALERT:
                    Console.WriteLine("COMMAND : VS_START_DATA_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartDataAlert(e.Command.MetaData);
                    break;

                /// bool StartDataAlertAll();

                case CommandType.VS_START_DATA_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_START_DATA_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StartDataAlertAll();
                    break;

                /// bool StopDataAlert(String camName);

                case CommandType.VS_STOP_DATA_ALERT:
                    Console.WriteLine("COMMAND : VS_STOP_DATA_ALERT...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopDataAlert(e.Command.MetaData);
                    break;

                /// bool StopDataAlertAll();

                case CommandType.VS_STOP_DATA_ALERT_ALL:
                    Console.WriteLine("COMMAND : VS_STOP_DATA_ALERT_ALL...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    StopDataAlertAll();
                    break;

                /// String[] ListCameras();

                case CommandType.VS_LIST_CAMERAS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCamerasDetail();
                    break;

                /// String[] ListCamerasConnect();

                case CommandType.VS_LIST_CAMERAS_CONNECT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_CONNECT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCamerasConnect();
                    break;

                /// String[] ListCamerasAnalyse();

                case CommandType.VS_LIST_CAMERAS_ANALYSE_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_ANALYSE_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCamerasAnalyse();
                    break;

                /// String[] ListCamerasEventAlert();

                case CommandType.VS_LIST_CAMERAS_EVENT_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_EVENT_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCamerasEventAlert();
                    break;

                /// String[] ListCamerasRecord();

                case CommandType.VS_LIST_CAMERAS_RECORD_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_RECORD_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCamerasRecord();
                    break;

                /// String[] ListCamerasDataAlert();

                case CommandType.VS_LIST_CAMERAS_DATA_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERAS_DATA_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCamerasDataAlert();
                    break;


                /// String ListCameraConnect(String camName);

                case CommandType.VS_LIST_CAMERA_CONNECT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_CONNECT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCameraConnect(e.Command.MetaData);
                    break;

                /// String ListCameraAnalyse(String camName);

                case CommandType.VS_LIST_CAMERA_ANALYSE_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_ANALYSE_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCameraAnalyse(e.Command.MetaData);
                    break;

                /// String ListCameraEventAlert(String camName);

                case CommandType.VS_LIST_CAMERA_EVENT_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_EVENT_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCameraEventAlert(e.Command.MetaData);
                    break;

                /// String ListCameraRecord(String camName);

                case CommandType.VS_LIST_CAMERA_RECORD_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_RECORD_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCameraRecord(e.Command.MetaData);
                    break;

                /// String ListCameraDataAlert(String camName);

                case CommandType.VS_LIST_CAMERA_DATA_ALERT_STATUS:
                    Console.WriteLine("COMMAND : VS_LIST_CAMERA_DATA_ALERT_STATUS...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListCameraDataAlert(e.Command.MetaData);
                    break;


                /// vsStatus infomation

                case CommandType.VS_INFO:
                    Console.WriteLine("COMMAND : VS_INFO...");
                    Console.WriteLine("METADA : {0}", e.Command.MetaData);
                    ListInfo(e.Command.MetaData);
                    break;
            }
        }
        
        #endregion

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="metaData"></param>
        void Start(String metaData)
        {
            try
            {
                StartConnect(metaData);

                StartAnalyse(metaData);

                StartEventAlert(metaData);

                StartRecord(metaData);

                StartDataAlert(metaData);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartFull
        /// </summary>
        /// <param name="metaData"></param>
        public void StartAll()
        {
            try
            {
                StartConnectAll();

                StartAnalyseAll();

                StartEventAlertAll();

                StartRecordAll();

                StartDataAlertAll();
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
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
                StopDataAlert(metaData);

                StopRecord(metaData);

                StopEventAlert(metaData);

                StopAnalyse(metaData);

                StopConnect(metaData);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopAll
        /// </summary>
        /// <param name="metaData"></param>
        public void StopAll()
        {
            try
            {
                StopDataAlertAll();

                StopEventAlertAll();

                StopRecordAll();

                StopAnalyseAll();

                StopConnectAll();
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartConnect
        /// </summary>
        /// <param name="metaData"></param>
        void StartConnect(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_START_CONNECT, "VS_START_CONNECT" + ";" + vsStatus);

            try
            {
                vsMsg = ";StartConnect->" + metaData + ";";
                vsStatus = "VS_START_CONNECT" + ";" + vsServer.StartConnect(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_CONNECT, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartConnectAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartConnectAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StartConnect(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_CONNECT_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopConnect
        /// </summary>
        /// <param name="metaData"></param>
        void StopConnect(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_STOP_CONNECT, "VS_STOP_CONNECT" + ";" + vsStatus);

            try
            {
                vsMsg = ";StopConnect->" + metaData + ";";
                vsStatus = "VS_STOP_CONNECT" + ";" + vsServer.StopConnect(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_CONNECT, err.Message + " " + err.Source + " " + err.StackTrace);
            }            
        }

        /// <summary>
        /// StopConnectAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopConnectAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StopConnect(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_CONNECT_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void StartAnalyse(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_START_ANALYSE, "VS_START_ANALYSE" + ";" + vsStatus);

            try
            {
                vsMsg = ";StartAnalyse->" + metaData + ";";
                vsStatus = "VS_START_ANALYSE" + ";" + vsServer.StartAnalyse(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_ANALYSE, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartAnalyseAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartAnalyseAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StartAnalyse(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_ANALYSE_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void StopAnalyse(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_STOP_ANALYSE, "VS_STOP_ANALYSE" + ";" + vsStatus);

            try
            {
                vsMsg = ";StopAnalyse->" + metaData + ";";
                vsStatus = "VS_STOP_ANALYSE" + ";" + vsServer.StopAnalyse(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_ANALYSE, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopAnalyseAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopAnalyseAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StopAnalyse(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_ANALYSE_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StartEventAlert(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_START_EVENT_ALERT, "VS_START_EVENT_ALERT" + ";" + vsStatus);

            try
            {
                vsMsg = ";StartEventAlert->" + metaData + ";";
                vsStatus = "VS_START_EVENT_ALERT" + ";" + vsServer.StartEventAlert(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_EVENT_ALERT, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartEventAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartEventAlertAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StartEventAlert(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_EVENT_ALERT_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StopEventAlert(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_STOP_EVENT_ALERT, "VS_STOP_EVENT_ALERT" + ";" + vsStatus);

            try
            {
                vsMsg = ";StartEventAlert->" + metaData + ";";
                vsStatus = "VS_STOP_EVENT_ALERT" + ";" + vsServer.StartEventAlert(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_EVENT_ALERT, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopEventAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopEventAlertAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StopEventAlert(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_EVENT_ALERT_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartRecord
        /// </summary>
        /// <param name="metaData"></param>
        void StartRecord(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_START_RECORD, "VS_START_RECORD" + ";" + vsStatus);

            try
            {
                vsMsg = ";StartRecord->" + metaData + ";";
                vsStatus = "VS_START_RECORD" + ";" + vsServer.StartRecord(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_RECORD, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartRecordAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartRecordAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StartRecord(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_RECORD_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopRecord
        /// </summary>
        /// <param name="metaData"></param>
        void StopRecord(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_STOP_RECORD, "VS_STOP_RECORD" + ";" + vsStatus);

            try
            {
                vsMsg = ";StopRecord->" + metaData + ";";
                vsStatus = "VS_STOP_RECORD" + ";" + vsServer.StopRecord(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_RECORD, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopRecordAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopRecordAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StopRecord(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_RECORD_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StartDataAlert(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_START_DATA_ALERT, "VS_START_DATA_ALERT" + ";" + vsStatus);

            try
            {
                vsMsg = ";StartDataAlert->" + metaData + ";";
                vsStatus = "VS_START_DATA_ALERT" + ";" + vsServer.StartDataAlert(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_DATA_ALERT, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StartDataAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StartDataAlertAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StartDataAlert(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_START_DATA_ALERT_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void StopDataAlert(String metaData)
        {
            String vsStatus = " ", vsMsg = " ";
            Command cmd = new Command(CommandType.VS_STOP_DATA_ALERT, "VS_STOP_DATA_ALERT" + ";" + vsStatus);

            try
            {
                vsMsg = ";StopDataAlert->" + metaData + ";";
                vsStatus = "VS_STOP_DATA_ALERT" + ";" + vsServer.StopDataAlert(metaData).ToString();
                cmd.MetaData = vsStatus; foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_DATA_ALERT, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// StopDataAlertAll
        /// </summary>
        /// <param name="metaData"></param>
        void StopDataAlertAll()
        {
            try
            {
                String[] vsList = this.ListCameras();
                foreach (String str in vsList) if (str.Length > 0) StopDataAlert(str);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_STOP_DATA_ALERT_ALL, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameras
        /// </summary>
        /// <param name="metaData"></param>
        String[] ListCameras()
        {
            try
            {
                String[] vsList = vsServer.ListCamerasName();

                return vsList;
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
            return null;
        }

        /// <summary>
        /// ListCameras
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasDetail()
        {
            String vsStatus = " ";

            try
            {
                String[] vsList = vsServer.ListCamerasDetail();
                vsStatus=""; foreach (String str in vsList) vsStatus += (";" + str);

                Command cmd = new Command(CommandType.VS_LIST_CAMERAS, "VS_LIST_CAMERAS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasConnect
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasConnect()
        {
            String vsStatus = " ";

            try
            {
                String[] vsList = vsServer.ListCamerasConnect();
                vsStatus = ""; foreach (String str in vsList) vsStatus += (";" + str);

                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_CONNECT_STATUS, "VS_LIST_CAMERAS_CONNECT_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS_CONNECT_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasAnalyse()
        {
            String vsStatus = " ";

            try
            {
                String[] vsList = vsServer.ListCamerasAnalyse();
                vsStatus = ""; foreach (String str in vsList) vsStatus += (";" + str);

                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_ANALYSE_STATUS, "VS_LIST_CAMERAS_ANALYSE_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS_ANALYSE_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasEventAlert()
        {
            String vsStatus = " ";

            try
            {
                String[] vsList = vsServer.ListCamerasEventAlert();
                vsStatus = ""; foreach (String str in vsList) vsStatus += (";" + str);

                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_EVENT_ALERT_STATUS, "VS_LIST_CAMERAS_EVENT_ALERT_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS_EVENT_ALERT_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasRecord
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasRecord()
        {
            String vsStatus = " ";

            try
            {
                String[] vsList = vsServer.ListCamerasRecord();
                vsStatus = ""; foreach (String str in vsList) vsStatus += (";" + str);

                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_RECORD_STATUS, "VS_LIST_CAMERAS_RECORD_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS_RECORD_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCamerasDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCamerasDataAlert()
        {
            String vsStatus = " ";

            try
            {
                String[] vsList = vsServer.ListCamerasDataAlert();
                vsStatus = ""; foreach (String str in vsList) vsStatus += (";" + str);

                Command cmd = new Command(CommandType.VS_LIST_CAMERAS_DATA_ALERT_STATUS, "VS_LIST_CAMERAS_DATA_ALERT_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERAS_DATA_ALERT_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraConnect
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraConnect(String metaData)
        {
            String vsStatus = " ";

            try
            {
                vsStatus = vsServer.ListCameraConnect(metaData);

                Command cmd = new Command(CommandType.VS_LIST_CAMERA_CONNECT_STATUS, "VS_LIST_CAMERA_CONNECT_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERA_CONNECT_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraAnalyse
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraAnalyse(String metaData)
        {
            String vsStatus = " ";

            try
            {
                vsStatus = vsServer.ListCameraAnalyse(metaData);

                Command cmd = new Command(CommandType.VS_LIST_CAMERA_ANALYSE_STATUS, "VS_LIST_CAMERA_ANALYSE_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERA_ANALYSE_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraEventAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraEventAlert(String metaData)
        {
            String vsStatus = " ";

            try
            {
                vsStatus = vsServer.ListCameraEventAlert(metaData);

                Command cmd = new Command(CommandType.VS_LIST_CAMERA_EVENT_ALERT_STATUS, "VS_LIST_CAMERA_EVENT_ALERT_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERA_EVENT_ALERT_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraRecord
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraRecord(String metaData)
        {
            String vsStatus = " ";

            try
            {
                vsStatus = vsServer.ListCameraRecord(metaData);

                Command cmd = new Command(CommandType.VS_LIST_CAMERA_RECORD_STATUS, "VS_LIST_CAMERA_RECORD_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERA_RECORD_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListCameraDataAlert
        /// </summary>
        /// <param name="metaData"></param>
        void ListCameraDataAlert(String metaData)
        {
            String vsStatus = " ";

            try
            {
                vsStatus = vsServer.ListCameraDataAlert(metaData);

                Command cmd = new Command(CommandType.VS_LIST_CAMERA_DATA_ALERT_STATUS, "VS_LIST_CAMERA_DATA_ALERT_STATUS" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_LIST_CAMERA_DATA_ALERT_STATUS, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        /// <summary>
        /// ListInfo
        /// </summary>
        /// <param name="metaData"></param>
        void ListInfo(String metaData)
        {
            String vsStatus = " ";

            try
            {
                vsStatus = vsServer.ListInfo();

                Command cmd = new Command(CommandType.VS_INFO, "VS_INFO" + ";" + vsStatus);
                foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
            }
            catch (Exception err)
            {
                SendError(CommandType.VS_INFO, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

  
        /// <summary>
        /// UpdateConsole
        /// </summary>
        /// <param name="vsStatus"></param>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        private void UpdateConsole(string vsStatus , IPAddress IP , int port)
        {
            strMsg = String.Format("Client {0}{1}{2} has been {3} ( {4}|{5} )", IP.ToString(), ":", port.ToString(), vsStatus, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
            Console.WriteLine(strMsg); SendStatus(strMsg);
        }

        /// <summary>
        /// SendStatus
        /// </summary>
        /// <param name="vsStatus"></param>
        private void SendStatus(string vsStatus)
        {
            Command cmd = new Command(CommandType.VS_INFO, vsStatus);
            foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
        }

        /// <summary>
        /// SendError
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="msgs"></param>
        private void SendError(CommandType cmdType, String cmdMsg)
        {
            logger.Log(LogLevel.Error, cmdMsg);

            Console.WriteLine(cmdMsg);

            Command cmd = new Command(cmdType, cmdMsg);
            foreach (ClientManager cm in vsClients) cm.SendCommand(cmd);
        }
    }
}
