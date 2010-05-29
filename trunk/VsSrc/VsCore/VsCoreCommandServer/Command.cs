// xzbc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gffm	
// bhng	 By downloading, copying, installing or using the software you agree to this license.
// kuri	 If you do not agree to this license, do not download, install,
// axtb	 copy or use the software.
// slle	
// roqi	                          License Agreement
// qowt	         For OpenVSS - Open Source Video Surveillance System
// sfrb	
// erif	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vbka	
// uzle	Third party copyrights are property of their respective owners.
// fdtf	
// dmsl	Redistribution and use in source and binary forms, with or without modification,
// owls	are permitted provided that the following conditions are met:
// owvm	
// ltne	  * Redistribution's of source code must retain the above copyright notice,
// dqdj	    this list of conditions and the following disclaimer.
// pofr	
// akjr	  * Redistribution's in binary form must reproduce the above copyright notice,
// cmcn	    this list of conditions and the following disclaimer in the documentation
// urqf	    and/or other materials provided with the distribution.
// mfmh	
// fprz	  * Neither the name of the copyright holders nor the names of its contributors 
// fypb	    may not be used to endorse or promote products derived from this software 
// lhbp	    without specific prior written permission.
// zkqo	
// gble	This software is provided by the copyright holders and contributors "as is" and
// nuqc	any express or implied warranties, including, but not limited to, the implied
// tiru	warranties of merchantability and fitness for a particular purpose are disclaimed.
// chsx	In no event shall the Prince of Songkla University or contributors be liable 
// ewez	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xglc	(including, but not limited to, procurement of substitute goods or services;
// uifv	loss of use, data, or profits; or business interruption) however caused
// lnnk	and on any theory of liability, whether in contract, strict liability,
// abzl	or tort (including negligence or otherwise) arising in any way out of
// uhul	the use of this software, even if advised of the possibility of such damage.
// zpfx	
// gvye	Intelligent Systems Laboratory (iSys Lab)
// pdld	Faculty of Engineering, Prince of Songkla University, THAILAND
// gqra	Project leader by Nikom SUVONVORN
// pije	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Vs.Core.Server.Command
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

        private string commandBody;
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
        /// </summary>
        /// <param name="type"></param>
        /// <param name="metaData"></param>
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
