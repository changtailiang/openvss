// pmfr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rpko	
// odbn	 By downloading, copying, installing or using the software you agree to this license.
// qyox	 If you do not agree to this license, do not download, install,
// sgjx	 copy or use the software.
// xfhd	
// bqfu	                          License Agreement
// qxxj	         For OpenVSS - Open Source Video Surveillance System
// dwcd	
// lzuc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jevs	
// uhih	Third party copyrights are property of their respective owners.
// eiab	
// geik	Redistribution and use in source and binary forms, with or without modification,
// fbpa	are permitted provided that the following conditions are met:
// kpyq	
// grku	  * Redistribution's of source code must retain the above copyright notice,
// wlls	    this list of conditions and the following disclaimer.
// mgos	
// joju	  * Redistribution's in binary form must reproduce the above copyright notice,
// hxph	    this list of conditions and the following disclaimer in the documentation
// wvcz	    and/or other materials provided with the distribution.
// osyj	
// jtst	  * Neither the name of the copyright holders nor the names of its contributors 
// gemc	    may not be used to endorse or promote products derived from this software 
// wolt	    without specific prior written permission.
// xhpa	
// ppbq	This software is provided by the copyright holders and contributors "as is" and
// svtm	any express or implied warranties, including, but not limited to, the implied
// zqul	warranties of merchantability and fitness for a particular purpose are disclaimed.
// okge	In no event shall the Prince of Songkla University or contributors be liable 
// nbjs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oume	(including, but not limited to, procurement of substitute goods or services;
// cgxt	loss of use, data, or profits; or business interruption) however caused
// lwkp	and on any theory of liability, whether in contract, strict liability,
// gcjy	or tort (including negligence or otherwise) arising in any way out of
// qhro	the use of this software, even if advised of the possibility of such damage.
// afup	
// kanm	Intelligent Systems Laboratory (iSys Lab)
// ihfv	Faculty of Engineering, Prince of Songkla University, THAILAND
// yxlu	Project leader by Nikom SUVONVORN
// cwol	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;

namespace Vs.Core.Server.Command
{
    /// <summary>
    /// The class that contains some methods and properties to manage the remote clients.
    /// </summary>
    public class ClientManager
    {
        /// <summary>
        /// Gets the IP address of connected remote client.This is 'IPAddress.None' if the client is not connected.
        /// </summary>
        public IPAddress IP
        {
            get
            {
                if ( this.socket != null)
                    return ( (IPEndPoint)this.socket.RemoteEndPoint ).Address;
                else
                    return IPAddress.None;
            }
        }
        /// <summary>
        /// Gets the port number of connected remote client.This is -1 if the client is not connected.
        /// </summary>
        public int Port
        {
            get
            {
                if ( this.socket != null)
                    return ( (IPEndPoint)this.socket.RemoteEndPoint ).Port;
                else
                    return -1;
            }
        }
        /// <summary>
        /// [Gets] The value that specifies the remote client is connected to this server or not.
        /// </summary>
        public bool Connected
        {
            get
            {
                if ( this.socket != null )
                    return this.socket.Connected;
                else
                    return false;
            }
        }

        private Socket socket;
        private string clientName;
        /// <summary>
        /// The name of remote client.
        /// </summary>
        public string ClientName
        {
            get { return this.clientName; }
            set { this.clientName = value; }
        }
        NetworkStream networkStream;
        private BackgroundWorker bwReceiver;

        #region Constructor
        /// <summary>
        /// Creates an instance of ClientManager class to comunicate with remote clients.
        /// </summary>
        /// <param name="clientSocket">The socket of ClientManager.</param>
        public ClientManager(Socket clientSocket)
        {
            this.socket = clientSocket;
            this.networkStream = new NetworkStream(this.socket);
            this.bwReceiver = new BackgroundWorker();
            this.bwReceiver.DoWork += new DoWorkEventHandler(StartReceive);
            this.bwReceiver.RunWorkerAsync();
        } 
        #endregion

        #region Private Methods
        private void StartReceive(object sender , DoWorkEventArgs e)
        {
            StreamReader streamReader = new StreamReader(this.networkStream);

            while ( this.socket.Connected )
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
            this.OnDisconnected(new ClientEventArgs(this.socket));
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
            e.Result = this.SendCommandToClient(cmd);
        }

        //This Semaphor is to protect the critical section from concurrent access of sender threads.
        System.Threading.Semaphore semaphor = new System.Threading.Semaphore(1 , 1);
        private bool SendCommandToClient(Command cmd)
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
        /// Sends a command to the remote client if the connection is alive.
        /// </summary>
        /// <param name="cmd">The command to send.</param>
        public void SendCommand(Command cmd)
        {
            if ( this.socket != null && this.socket.Connected )
            {
                BackgroundWorker bwSender = new BackgroundWorker();
                bwSender.DoWork += new DoWorkEventHandler(bwSender_DoWork);
                bwSender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSender_RunWorkerCompleted);
                bwSender.RunWorkerAsync(cmd);
            }
            else
                this.OnCommandFailed(new EventArgs());
        }

        

        /// <summary>
        /// Disconnect the current client manager from the remote client and returns true if the client had been disconnected from the server.
        /// </summary>
        /// <returns>True if the remote client had been disconnected from the server,otherwise false.</returns>
        public bool Disconnect()
        {
            if (this.socket != null && this.socket.Connected )
            {
                try
                {
                    this.socket.Shutdown(SocketShutdown.Both);
                    this.socket.Close();
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
        /// <param name="e">Received command.</param>
        protected virtual void OnCommandReceived(CommandEventArgs e)
        {
            if ( CommandReceived != null )
                CommandReceived(this , e);
        }

        /// <summary>
        /// Occurs when a command had been sent to the remote client successfully.
        /// </summary>
        public event CommandSentEventHandler CommandSent;
        /// <summary>
        /// Occurs when a command had been sent to the remote client successfully.
        /// </summary>
        /// <param name="e">The sent command.</param>
        protected virtual void OnCommandSent(EventArgs e)
        {
            if ( CommandSent != null )
                CommandSent(this , e);
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
                CommandFailed(this , e);
        }

        /// <summary>
        /// Occurs when a client disconnected from this server.
        /// </summary>
        public event DisconnectedEventHandler Disconnected;
        /// <summary>
        /// Occurs when a client disconnected from this server.
        /// </summary>
        /// <param name="e">Client information.</param>
        protected virtual void OnDisconnected(ClientEventArgs e)
        {
            if ( Disconnected != null )
                Disconnected(this , e);
        }

        #endregion
    }
}
