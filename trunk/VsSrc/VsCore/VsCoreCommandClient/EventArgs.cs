// jjep	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ezrv	
// lgha	 By downloading, copying, installing or using the software you agree to this license.
// rkia	 If you do not agree to this license, do not download, install,
// avdl	 copy or use the software.
// xiit	
// mjwz	                          License Agreement
// mzzb	         For OpenVss - Open Source Video Surveillance System
// nakj	
// rmwj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jgyt	
// hdgo	Third party copyrights are property of their respective owners.
// hzng	
// hoaa	Redistribution and use in source and binary forms, with or without modification,
// akcv	are permitted provided that the following conditions are met:
// dril	
// hfnr	  * Redistribution's of source code must retain the above copyright notice,
// ayjn	    this list of conditions and the following disclaimer.
// zucq	
// kpmi	  * Redistribution's in binary form must reproduce the above copyright notice,
// chrn	    this list of conditions and the following disclaimer in the documentation
// lsuy	    and/or other materials provided with the distribution.
// zjjg	
// kbgr	  * Neither the name of the copyright holders nor the names of its contributors 
// ymmc	    may not be used to endorse or promote products derived from this software 
// ppoj	    without specific prior written permission.
// qagm	
// mkpl	This software is provided by the copyright holders and contributors "as is" and
// ytsw	any express or implied warranties, including, but not limited to, the implied
// zvzo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lprq	In no event shall the Prince of Songkla University or contributors be liable 
// pddy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oksy	(including, but not limited to, procurement of substitute goods or services;
// cksn	loss of use, data, or profits; or business interruption) however caused
// tixl	and on any theory of liability, whether in contract, strict liability,
// mhlp	or tort (including negligence or otherwise) arising in any way out of
// uxhq	the use of this software, even if advised of the possibility of such damage.

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
