// ndtd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// buyt	
// ynkh	 By downloading, copying, installing or using the software you agree to this license.
// ppwk	 If you do not agree to this license, do not download, install,
// dacc	 copy or use the software.
// flvf	
// ecaz	                          License Agreement
// twis	         For OpenVSS - Open Source Video Surveillance System
// elqh	
// jogx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ralx	
// ppqs	Third party copyrights are property of their respective owners.
// ugxg	
// dhkc	Redistribution and use in source and binary forms, with or without modification,
// inyz	are permitted provided that the following conditions are met:
// tyab	
// frcd	  * Redistribution's of source code must retain the above copyright notice,
// zpap	    this list of conditions and the following disclaimer.
// tflf	
// zxpp	  * Redistribution's in binary form must reproduce the above copyright notice,
// lhem	    this list of conditions and the following disclaimer in the documentation
// zcox	    and/or other materials provided with the distribution.
// bnyw	
// pgdt	  * Neither the name of the copyright holders nor the names of its contributors 
// aksy	    may not be used to endorse or promote products derived from this software 
// mnte	    without specific prior written permission.
// fhmy	
// wfdk	This software is provided by the copyright holders and contributors "as is" and
// yiom	any express or implied warranties, including, but not limited to, the implied
// uncd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cfcl	In no event shall the Prince of Songkla University or contributors be liable 
// ream	for any direct, indirect, incidental, special, exemplary, or consequential damages
// crep	(including, but not limited to, procurement of substitute goods or services;
// frcy	loss of use, data, or profits; or business interruption) however caused
// nzgr	and on any theory of liability, whether in contract, strict liability,
// pqav	or tort (including negligence or otherwise) arising in any way out of
// knyh	the use of this software, even if advised of the possibility of such damage.
// sryn	
// hpvh	Intelligent Systems Laboratory (iSys Lab)
// kinb	Faculty of Engineering, Prince of Songkla University, THAILAND
// hzwe	Project leader by Nikom SUVONVORN
// anfg	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Vs.Core.Client.Command
{
    /// <summary>
    /// Occurs when a command received from the server.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">The information about the received command.</param>
    public delegate void CommandReceivedEventHandler(object sender , CommandEventArgs e);

    /// <summary>
    /// Occurs when a command had been sent to the the remote server Successfully.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void CommandSentEventHandler(object sender , EventArgs e);

    /// <summary>
    /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void CommandSendingFailedEventHandler(object sender , EventArgs e);

    /// <summary>
    /// The class that contains information about a command.
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        private Command command;
        /// <summary>
        /// The received command.
        /// </summary>
        public Command Command
        {
            get { return command; }
        }
        /// <summary>
        /// Creates an instance of CommandEventArgs class.
        /// </summary>
        /// <param name="cmd">The received command.</param>
        public CommandEventArgs(Command cmd)
        {
            this.command = cmd;
        }
    }
    /// <summary>
    /// Occurs when the server had been disconnected from this client.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">The server information.</param>
    public delegate void ServerDisconnectedEventHandler(object sender , ServerEventArgs e);
    /// <summary>
    /// The class that contains information about the server.
    /// </summary>
    public class ServerEventArgs : EventArgs
    {
        private Socket socket;
        /// <summary>
        /// The IP address of server.
        /// </summary>
        public IPAddress IP
        {
            get { return ( (IPEndPoint)this.socket.RemoteEndPoint ).Address; }
        }
        /// <summary>
        /// The port of server.
        /// </summary>
        public int Port
        {
            get { return ( (IPEndPoint)this.socket.RemoteEndPoint ).Port; }
        }
        /// <summary>
        /// Creates an instance of ServerEventArgs class.
        /// </summary>
        /// <param name="clientSocket">The client socket of current CommandClient instance.</param>
        public ServerEventArgs(Socket clientSocket)
        {
            this.socket = clientSocket;
        }
    }

    /// <summary>
    /// Occurs when this client disconnected from the server.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void DisconnectedEventHandler(object sender , EventArgs e);

    /// <summary>
    /// Occurs when this client connected to the remote server Successfully.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void ConnectingSuccessedEventHandler(object sender , EventArgs e);

    /// <summary>
    /// Occurs when this client failed on connecting to server.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void ConnectingFailedEventHandler(object sender , EventArgs e);

    /// <summary>
    /// Occurs when the network had been failed.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void NetworkDeadEventHandler(object sender , EventArgs e);

    /// <summary>
    /// Occurs when the network had been started to work.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void NetworkAlivedEventHandler(object sender , EventArgs e);

}
