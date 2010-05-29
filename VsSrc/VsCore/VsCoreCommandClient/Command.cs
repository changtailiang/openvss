// rrib	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qomu	
// tpdx	 By downloading, copying, installing or using the software you agree to this license.
// fgbw	 If you do not agree to this license, do not download, install,
// ntlk	 copy or use the software.
// xips	
// eoek	                          License Agreement
// dmrr	         For OpenVSS - Open Source Video Surveillance System
// zitm	
// yjyi	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fgcw	
// nwhp	Third party copyrights are property of their respective owners.
// rwdu	
// acwi	Redistribution and use in source and binary forms, with or without modification,
// bpwb	are permitted provided that the following conditions are met:
// kcrh	
// ymxx	  * Redistribution's of source code must retain the above copyright notice,
// mpye	    this list of conditions and the following disclaimer.
// vder	
// gsfh	  * Redistribution's in binary form must reproduce the above copyright notice,
// hosg	    this list of conditions and the following disclaimer in the documentation
// jwrx	    and/or other materials provided with the distribution.
// lkli	
// mwyd	  * Neither the name of the copyright holders nor the names of its contributors 
// puyb	    may not be used to endorse or promote products derived from this software 
// zkdb	    without specific prior written permission.
// yyzx	
// yfci	This software is provided by the copyright holders and contributors "as is" and
// kpuv	any express or implied warranties, including, but not limited to, the implied
// jkxb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ualb	In no event shall the Prince of Songkla University or contributors be liable 
// epsy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eabl	(including, but not limited to, procurement of substitute goods or services;
// tdiw	loss of use, data, or profits; or business interruption) however caused
// lqik	and on any theory of liability, whether in contract, strict liability,
// wtzf	or tort (including negligence or otherwise) arising in any way out of
// icyx	the use of this software, even if advised of the possibility of such damage.
// ccuf	
// xwgz	Intelligent Systems Laboratory (iSys Lab)
// ybxj	Faculty of Engineering, Prince of Songkla University, THAILAND
// gbsx	Project leader by Nikom SUVONVORN
// erog	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Vs.Core.Client.Command
{
    /// <summary>
    /// The command class.
    /// </summary>
    public class Command
    {
        private CommandType cmdType;
        /// <summary>
        /// The type of command to send.If you wanna use the Message command type,create a Message class instead of command.
        /// </summary>
        public CommandType CommandType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }

        private IPAddress senderIP;
        /// <summary>
        /// [Gets/Sets] The IP address of command sender.
        /// </summary>
        public IPAddress SenderIP
        {
            get { return senderIP; }
            set { senderIP = value; }
        }

        private string senderName;
        /// <summary>
        /// [Gets/Sets] The name of command sender.
        /// </summary>
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        private string commandBody = "\n";
        /// <summary>
        /// The body of the command.This string is different in various commands.
        /// </summary>
        public string MetaData
        {
            get { return commandBody; }
            set { commandBody = value; }
        }
        /// <summary>
        /// Creates an instance of command object to send over the network.
        /// <summary>
        public Command(CommandType type, string metaData)
        {
            this.cmdType = type;
            this.commandBody = metaData;
        }

        /// <summary>
        /// Creates an instance of command object to send over the network.
        /// </summary>
        public Command(CommandType type)
        {
            this.cmdType = type;
            this.commandBody = "";
        }
    }
}
