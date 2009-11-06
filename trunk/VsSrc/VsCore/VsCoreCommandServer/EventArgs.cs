// ifdt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kshj	
// wgtg	 By downloading, copying, installing or using the software you agree to this license.
// ykdl	 If you do not agree to this license, do not download, install,
// inpd	 copy or use the software.
// gjjs	
// ydhp	                          License Agreement
// qmty	         For OpenVss - Open Source Video Surveillance System
// hjib	
// ltjc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// eztx	
// htla	Third party copyrights are property of their respective owners.
// suuq	
// yuhy	Redistribution and use in source and binary forms, with or without modification,
// wlvg	are permitted provided that the following conditions are met:
// lrtj	
// nuzo	  * Redistribution's of source code must retain the above copyright notice,
// bbzo	    this list of conditions and the following disclaimer.
// enzg	
// qlkf	  * Redistribution's in binary form must reproduce the above copyright notice,
// shwv	    this list of conditions and the following disclaimer in the documentation
// scam	    and/or other materials provided with the distribution.
// bkfa	
// ycqm	  * Neither the name of the copyright holders nor the names of its contributors 
// gjkn	    may not be used to endorse or promote products derived from this software 
// uwyr	    without specific prior written permission.
// uflk	
// vbhk	This software is provided by the copyright holders and contributors "as is" and
// apoe	any express or implied warranties, including, but not limited to, the implied
// vxqk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tmmr	In no event shall the Prince of Songkla University or contributors be liable 
// wzqc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wnzg	(including, but not limited to, procurement of substitute goods or services;
// bxlw	loss of use, data, or profits; or business interruption) however caused
// jebn	and on any theory of liability, whether in contract, strict liability,
// qqra	or tort (including negligence or otherwise) arising in any way out of
// cuai	the use of this software, even if advised of the possibility of such damage.

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
