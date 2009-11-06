// kukj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// iyil	
// rfpc	 By downloading, copying, installing or using the software you agree to this license.
// mbef	 If you do not agree to this license, do not download, install,
// gyrk	 copy or use the software.
// zsht	
// xxsr	                          License Agreement
// diok	         For OpenVss - Open Source Video Surveillance System
// emvd	
// nemv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// duie	
// ftjl	Third party copyrights are property of their respective owners.
// vxpf	
// aibr	Redistribution and use in source and binary forms, with or without modification,
// nqml	are permitted provided that the following conditions are met:
// frhi	
// qeyz	  * Redistribution's of source code must retain the above copyright notice,
// fasb	    this list of conditions and the following disclaimer.
// lvhf	
// kdoe	  * Redistribution's in binary form must reproduce the above copyright notice,
// ngvf	    this list of conditions and the following disclaimer in the documentation
// tjkv	    and/or other materials provided with the distribution.
// keqw	
// sapl	  * Neither the name of the copyright holders nor the names of its contributors 
// mzna	    may not be used to endorse or promote products derived from this software 
// ukgv	    without specific prior written permission.
// fntf	
// bwhj	This software is provided by the copyright holders and contributors "as is" and
// cixz	any express or implied warranties, including, but not limited to, the implied
// wbpg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tcob	In no event shall the Prince of Songkla University or contributors be liable 
// kvjl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fvsk	(including, but not limited to, procurement of substitute goods or services;
// pnjd	loss of use, data, or profits; or business interruption) however caused
// azaf	and on any theory of liability, whether in contract, strict liability,
// qfuo	or tort (including negligence or otherwise) arising in any way out of
// wguj	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vs.Core.Client.Command
{
    /// <summary>
    /// The command client command class.
    /// </summary>
    public class CommandClient
    {
        private Socket clientSocket;
        private NetworkStream networkStream;
        private BackgroundWorker bwReceiver;
        private IPEndPoint serverEP;
        private string networkName;

        /// <summary>
        /// [Gets] The value that specifies the current client is connected or not.
        /// </summary>
        public bool Connected
        {
            get
            {
                if ( this.clientSocket != null )
                    return this.clientSocket.Connected;
                else
                    return false;
            }
        }
        /// <summary>
        /// [Gets] The IP address of the remote server.If this client is disconnected,this property returns IPAddress.None.
        /// </summary>
        public IPAddress ServerIP
        {
            get
            {
                if ( this.Connected )
                    return this.serverEP.Address;
                else
                    return IPAddress.None;
            }
        }

        /// <summary>
        /// [Gets] The comunication port of the remote server.If this client is disconnected,this property returns -1.
        /// </summary>
        public int ServerPort
        {
            get
            {
                if ( this.Connected )
                    return this.serverEP.Port;
                else
                    return -1;
            }
        }
        /// <summary>
        /// [Gets] The IP address of this client.If this client is disconnected,this property returns IPAddress.None.
        /// </summary>
        public IPAddress IP
        {
            get
            {
                if ( this.Connected )
                    return ( (IPEndPoint)this.clientSocket.LocalEndPoint ).Address;
                else
                    return IPAddress.None;
            }
        }
        /// <summary>
        /// [Gets] The comunication port of this client.If this client is disconnected,this property returns -1.
        /// </summary>
        public int Port
        {
            get
            {
                if ( this.Connected )
                    return ( (IPEndPoint)this.clientSocket.LocalEndPoint ).Port;
                else
                    return -1;
            }
        }
        /// <summary>
        /// [Gets/Sets] The string that will sent to the server and then to other clients, to identify this client to them.
        /// </summary>
        public string NetworkName
        {
            get { return networkName; }
            set { networkName = value; }
        }

        #region Contsructors
        /// <summary>
        /// Cretaes a command client instance.
        /// </summary>
        /// <param name="server">The remote server to connect.</param>
        /// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
        public CommandClient(IPEndPoint server,string netName)
        {
            this.serverEP = server;
            this.networkName = netName;
            System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
        }

        /// <summary>
        /// Cretaes a command client instance.
        /// </summary>
        ///<param name="serverIP">The IP of remote server.</param>
        ///<param name="port">The port of remote server.</param>
        /// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
        public CommandClient(IPAddress serverIP , int port,string netName)
        {
            this.serverEP = new IPEndPoint(serverIP , port);
            this.networkName = netName;
            System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
        }

        #endregion

        #region Private Methods

        private void NetworkChange_NetworkAvailabilityChanged(object sender , System.Net.NetworkInformation.NetworkAvailabilityEventArgs e)
        {
            if ( !e.IsAvailable )
            {
                this.OnNetworkDead(new EventArgs());
                this.OnDisconnectedFromServer(new EventArgs());
            }
            else
                this.OnNetworkAlived(new EventArgs());
        }

       private void StartReceive(object sender , DoWorkEventArgs e)
        {
            StreamReader streamReader = new StreamReader(this.networkStream);

            while ( this.clientSocket.Connected )
            {
                try
                {
                    // Read the command's Type.
                    String strType = streamReader.ReadLine();
                    CommandType cmdType = (CommandType)int.Parse(strType);

                    // Read the MetaData size.
                    String strSize = streamReader.ReadLine();
                    int metaSize = int.Parse(strSize);

                    // Read the MetaData.
                    String strMeta = streamReader.ReadLine();

                    // create command
                    Command cmd = new Command(cmdType, strMeta);

                    // send command
                    this.OnCommandReceived(new CommandEventArgs(cmd));

                    /*
                    //Read the command's Type.
                    byte[] buffer = new byte[4];
                    int readBytes = this.networkStream.Read(buffer, 0, 4);
                    if (readBytes == 0)
                        break;
                    CommandType cmdType = (CommandType)(BitConverter.ToInt32(buffer, 0));

                    //Read the command's MetaData size.
                    string cmdMetaData = "";
                    buffer = new byte[4];
                    readBytes = this.networkStream.Read(buffer, 0, 4);
                    if (readBytes == 0)
                        break;
                    int metaDataSize = BitConverter.ToInt32(buffer, 0);

                    //Read the command's Meta data.
                    buffer = new byte[metaDataSize];
                    readBytes = this.networkStream.Read(buffer, 0, metaDataSize);
                    if (readBytes == 0)
                        break;
                    cmdMetaData = System.Text.Encoding.Unicode.GetString(buffer);

                    Command cmd = new Command(cmdType, cmdMetaData);
                    this.OnCommandReceived(new CommandEventArgs(cmd));
                    */
                }
                catch { }
            }
            this.OnServerDisconnected(new ServerEventArgs(this.clientSocket));
            this.Disconnect();
        }

        private void bwSender_RunWorkerCompleted(object sender , RunWorkerCompletedEventArgs e)
        {
            if ( !e.Cancelled && e.Error == null && ( (bool)e.Result ) )
                this.OnCommandSent(new EventArgs());
            else
                this.OnCommandFailed(new EventArgs());

            ( (BackgroundWorker)sender ).Dispose();
            GC.Collect();
        }

        private void bwSender_DoWork(object sender , DoWorkEventArgs e)
        {
            Command cmd = (Command)e.Argument;
            e.Result = this.SendCommandToServer(cmd);
        }

        //This Semaphor is to protect the critical section from concurrent access of sender threads.
        System.Threading.Semaphore semaphor = new System.Threading.Semaphore(1 , 1);
        private bool SendCommandToServer(Command cmd)
        {
            StreamWriter streamWriter = new StreamWriter(this.networkStream);
            if (cmd.MetaData.Length == 0) return false;

            try
            {
                semaphor.WaitOne();

                try
                {
                    // Send command type
                    int intType = (int)cmd.CommandType;
                    String strType = intType.ToString();
                    streamWriter.WriteLine(strType);
                    streamWriter.Flush();

                    // Send metadata size
                    String strSize = cmd.MetaData.Length.ToString();
                    streamWriter.WriteLine(strSize);
                    streamWriter.Flush();

                    // Send metadata
                    String strMeta = cmd.MetaData;
                    streamWriter.WriteLine(strMeta);
                    streamWriter.Flush();

                    /*
                    //CommandType
                    byte[] buffer = new byte[4];
                    buffer = BitConverter.GetBytes((int)cmd.CommandType);
                    this.networkStream.Write(buffer, 0, 4);
                    this.networkStream.Flush();

                    //Command MetaData
                    byte[] metaBuffer = Encoding.Unicode.GetBytes(cmd.MetaData);
                    buffer = new byte[4];
                    buffer = BitConverter.GetBytes(metaBuffer.Length);
                    this.networkStream.Write(buffer, 0, 4);
                    this.networkStream.Flush();
                    this.networkStream.Write(metaBuffer, 0, metaBuffer.Length);
                    this.networkStream.Flush();
                    */
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                }
                
                semaphor.Release();
                return true;
            }
            catch
            {
                semaphor.Release();
                return false;
            }

        }
 
        #endregion

        #region Public Methods
        /// <summary>
        /// Connect the current instance of command client to the server.This method throws ServerNotFoundException on failur.Run this method and handle the 'ConnectingSuccessed' and 'ConnectingFailed' to get the connection state.
        /// </summary>
        public void ConnectToServer()
        {
            BackgroundWorker bwConnector = new BackgroundWorker();
            bwConnector.DoWork += new DoWorkEventHandler(bwConnector_DoWork);
            bwConnector.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwConnector_RunWorkerCompleted);
            bwConnector.RunWorkerAsync();
        }

        private void bwConnector_RunWorkerCompleted(object sender , RunWorkerCompletedEventArgs e)
        {
            if(!((bool)e.Result))
                this.OnConnectingFailed(new EventArgs());
            else
                this.OnConnectingSuccessed(new EventArgs());

            ( (BackgroundWorker)sender ).Dispose();
        }

        private void bwConnector_DoWork(object sender , DoWorkEventArgs e)
        {
            try
            {
                this.clientSocket = new Socket(AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp);
                this.clientSocket.Connect(this.serverEP);
                e.Result = true;
                this.networkStream = new NetworkStream(this.clientSocket);
                this.bwReceiver = new BackgroundWorker();
                this.bwReceiver.WorkerSupportsCancellation = true;
                this.bwReceiver.DoWork += new DoWorkEventHandler(StartReceive);
                this.bwReceiver.RunWorkerAsync();                
            }
            catch
            {
                e.Result = false;
            }
        }
        /// <summary>
        /// Sends a command to the server if the connection is alive.
        /// </summary>
        /// <param name="cmd">The command to send.</param>
        public void SendCommand(Command cmd)
        {
            if ( this.clientSocket != null && this.clientSocket.Connected )
            {
                BackgroundWorker bwSender = new BackgroundWorker();
                bwSender.DoWork += new DoWorkEventHandler(bwSender_DoWork);
                bwSender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSender_RunWorkerCompleted);
                bwSender.WorkerSupportsCancellation = true;
                bwSender.RunWorkerAsync(cmd);
            }
            else
                this.OnCommandFailed(new EventArgs());
        }
        
        /// <summary>
        /// Disconnect the client from the server and returns true if the client had been disconnected from the server.
        /// </summary>
        /// <returns>True if the client had been disconnected from the server,otherwise false.</returns>
        public bool Disconnect()
        {
            if (this.clientSocket != null && this.clientSocket.Connected )
            {
                try
                {
                    this.clientSocket.Shutdown(SocketShutdown.Both);
                    this.clientSocket.Close();
                    this.bwReceiver.CancelAsync();
                    this.OnDisconnectedFromServer(new EventArgs());
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
                return true;
        } 
        #endregion

        #region Events
        /// <summary>
        /// Occurs when a command received from a remote client.
        /// </summary>
        public event CommandReceivedEventHandler CommandReceived;
        /// <summary>
        /// Occurs when a command received from a remote client.
        /// </summary>
        /// <param name="e">The received command.</param>
        protected virtual void OnCommandReceived(CommandEventArgs e)
        {
            if ( CommandReceived != null )
            {
                Control target = CommandReceived.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(CommandReceived , new object [] { this , e });
                else
                    CommandReceived(this , e);
            }
        }

        /// <summary>
        /// Occurs when a command had been sent to the the remote server Successfully.
        /// </summary>
        public event CommandSentEventHandler CommandSent;
        /// <summary>
        /// Occurs when a command had been sent to the the remote server Successfully.
        /// </summary>
        /// <param name="e">The sent command.</param>
        protected virtual void OnCommandSent(EventArgs e)
        {
            if ( CommandSent != null )
            {
                Control target = CommandSent.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(CommandSent , new object [] { this , e });
                else
                    CommandSent(this , e);
            }
        }

        /// <summary>
        /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
        /// </summary>
        public event CommandSendingFailedEventHandler CommandFailed;
        /// <summary>
        /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
        /// </summary>
        /// <param name="e">The sent command.</param>
        protected virtual void OnCommandFailed(EventArgs e)
        {
            if ( CommandFailed != null )
            {
                Control target = CommandFailed.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(CommandFailed , new object [] { this , e });
                else
                    CommandFailed(this , e);
            }
        }

        /// <summary>
        /// Occurs when the client disconnected.
        /// </summary>
        public event ServerDisconnectedEventHandler ServerDisconnected;
        /// <summary>
        /// Occurs when the server disconnected.
        /// </summary>
        /// <param name="e">Server information.</param>
        protected virtual void OnServerDisconnected(ServerEventArgs e)
        {
            if ( ServerDisconnected != null )
            {
                Control target = ServerDisconnected.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(ServerDisconnected , new object [] { this , e });
                else
                    ServerDisconnected(this , e);
            }
        }

        /// <summary>
        /// Occurs when this client disconnected from the remote server.
        /// </summary>
        public event DisconnectedEventHandler DisconnectedFromServer;
        /// <summary>
        /// Occurs when this client disconnected from the remote server.
        /// </summary>
        /// <param name="e">EventArgs.</param>
        protected virtual void OnDisconnectedFromServer(EventArgs e)
        {
            if ( DisconnectedFromServer != null )
            {
                Control target = DisconnectedFromServer.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(DisconnectedFromServer , new object [] { this , e });
                else
                    DisconnectedFromServer(this , e);
            }
        }

        /// <summary>
        /// Occurs when this client connected to the remote server Successfully.
        /// </summary>
        public event ConnectingSuccessedEventHandler ConnectingSuccessed;
        /// <summary>
        /// Occurs when this client connected to the remote server Successfully.
        /// </summary>
        /// <param name="e">EventArgs.</param>
        protected virtual void OnConnectingSuccessed(EventArgs e)
        {
            if ( ConnectingSuccessed != null )
            {
                Control target = ConnectingSuccessed.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(ConnectingSuccessed , new object [] { this , e });
                else
                    ConnectingSuccessed(this , e);
            }
        }

        /// <summary>
        /// Occurs when this client failed on connecting to server.
        /// </summary>
        public event ConnectingFailedEventHandler ConnectingFailed;
        /// <summary>
        /// Occurs when this client failed on connecting to server.
        /// </summary>
        /// <param name="e">EventArgs.</param>
        protected virtual void OnConnectingFailed(EventArgs e)
        {
            if ( ConnectingFailed != null )
            {
                Control target = ConnectingFailed.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(ConnectingFailed , new object [] { this , e });
                else
                    ConnectingFailed(this , e);
            }
        }

        /// <summary>
        /// Occurs when the network had been failed.
        /// </summary>
        public event NetworkDeadEventHandler NetworkDead;
        /// <summary>
        /// Occurs when the network had been failed.
        /// </summary>
        /// <param name="e">EventArgs.</param>
        protected virtual void OnNetworkDead(EventArgs e)
        {
            if ( NetworkDead != null )
            {
                Control target = NetworkDead.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(NetworkDead , new object [] { this , e });
                else
                    NetworkDead(this , e);
            }
        }

        /// <summary>
        /// Occurs when the network had been started to work.
        /// </summary>
        public event NetworkAlivedEventHandler NetworkAlived;
        /// <summary>
        /// Occurs when the network had been started to work.
        /// </summary>
        /// <param name="e">EventArgs.</param>
        protected virtual void OnNetworkAlived(EventArgs e)
        {
            if ( NetworkAlived != null )
            {
                Control target = NetworkAlived.Target as Control;
                if ( target != null && target.InvokeRequired )
                    target.Invoke(NetworkAlived , new object [] { this , e });
                else
                    NetworkAlived(this , e);
            }
        }

        #endregion
    }
}
