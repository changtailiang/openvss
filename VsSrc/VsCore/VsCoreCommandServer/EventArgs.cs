// vjon	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qhnn	
// jblm	 By downloading, copying, installing or using the software you agree to this license.
// hdzo	 If you do not agree to this license, do not download, install,
// zlpu	 copy or use the software.
// hqpt	
// ptlf	                          License Agreement
// msik	         For OpenVSS - Open Source Video Surveillance System
// eiij	
// vqbv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// scwa	
// tyzn	Third party copyrights are property of their respective owners.
// yejs	
// awwe	Redistribution and use in source and binary forms, with or without modification,
// tvyx	are permitted provided that the following conditions are met:
// vhaq	
// sbhy	  * Redistribution's of source code must retain the above copyright notice,
// uqti	    this list of conditions and the following disclaimer.
// ktcf	
// tozr	  * Redistribution's in binary form must reproduce the above copyright notice,
// uygi	    this list of conditions and the following disclaimer in the documentation
// jpjh	    and/or other materials provided with the distribution.
// mdpa	
// sdal	  * Neither the name of the copyright holders nor the names of its contributors 
// cfhs	    may not be used to endorse or promote products derived from this software 
// qasi	    without specific prior written permission.
// kaih	
// urke	This software is provided by the copyright holders and contributors "as is" and
// vgdw	any express or implied warranties, including, but not limited to, the implied
// arhc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rzlq	In no event shall the Prince of Songkla University or contributors be liable 
// btqh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// trcn	(including, but not limited to, procurement of substitute goods or services;
// ghat	loss of use, data, or profits; or business interruption) however caused
// gyxj	and on any theory of liability, whether in contract, strict liability,
// hcnv	or tort (including negligence or otherwise) arising in any way out of
// tkel	the use of this software, even if advised of the possibility of such damage.
// adkk	
// yfbq	Intelligent Systems Laboratory (iSys Lab)
// obhr	Faculty of Engineering, Prince of Songkla University, THAILAND
// jbnc	Project leader by Nikom SUVONVORN
// oxxn	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Vs.Core.Server.Command
{
    /// <summary>
    /// Occurs when a command received from a client.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">The received command object.</param>
    public delegate void CommandReceivedEventHandler(object sender,CommandEventArgs e);

    /// <summary>
    /// Occurs when a command had been sent to the remote client successfully.
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
    /// The class that contains information about received command.
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
    /// Occurs when a remote client had been disconnected from the server.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">The client information.</param>
    public delegate void DisconnectedEventHandler(object sender,ClientEventArgs e);
    /// <summary>
    /// Client event args.
    /// </summary>
    public class ClientEventArgs : EventArgs
    {
        private Socket socket;
        /// <summary>
        /// The ip address of remote client.
        /// </summary>
        public IPAddress IP
        {
            get { return ( (IPEndPoint)this.socket.RemoteEndPoint ).Address; }
        }
        /// <summary>
        /// The port of remote client.
        /// </summary>
        public int Port
        {
            get{return ((IPEndPoint)this.socket.RemoteEndPoint).Port;}
        }
        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public ClientEventArgs(Socket clientManagerSocket)
        {
            this.socket = clientManagerSocket;
        }
    }
}
