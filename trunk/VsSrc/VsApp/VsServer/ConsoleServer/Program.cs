// vmfv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tbyq	
// icdx	 By downloading, copying, installing or using the software you agree to this license.
// zfkg	 If you do not agree to this license, do not download, install,
// lsyn	 copy or use the software.
// cwsk	
// mvbb	                          License Agreement
// fhmi	         For OpenVss - Open Source Video Surveillance System
// bpmo	
// rjrm	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lbaw	
// tzku	Third party copyrights are property of their respective owners.
// dgjm	
// zedy	Redistribution and use in source and binary forms, with or without modification,
// tuiy	are permitted provided that the following conditions are met:
// zwka	
// pvwj	  * Redistribution's of source code must retain the above copyright notice,
// twpb	    this list of conditions and the following disclaimer.
// bmca	
// wvrn	  * Redistribution's in binary form must reproduce the above copyright notice,
// lgxz	    this list of conditions and the following disclaimer in the documentation
// yaiw	    and/or other materials provided with the distribution.
// mnuw	
// btmo	  * Neither the name of the copyright holders nor the names of its contributors 
// rzhy	    may not be used to endorse or promote products derived from this software 
// cabh	    without specific prior written permission.
// rhln	
// bccx	This software is provided by the copyright holders and contributors "as is" and
// dvmt	any express or implied warranties, including, but not limited to, the implied
// ylcp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// maxf	In no event shall the Prince of Songkla University or contributors be liable 
// bsah	for any direct, indirect, incidental, special, exemplary, or consequential damages
// znjw	(including, but not limited to, procurement of substitute goods or services;
// oskk	loss of use, data, or profits; or business interruption) however caused
// eqhq	and on any theory of liability, whether in contract, strict liability,
// pvuj	or tort (including negligence or otherwise) arising in any way out of
// lwsf	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;
using System.Threading;

using Vs.Core.Server;
using Vs.Core.Server.Command;
using System.Globalization;
using NLog; 

namespace Vs.Server
{
    class Program
    {       
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        /// <summary>
        /// Start the console server.
        /// </summary>
        /// <param name="args">These are optional arguments.Pass the local ip address of the server as the first argument and the local port as the second argument.</param>
        static void Main(string [] args)
        {
            int vsHour = 3;
            int vsMinute = 50;
            int vsWait = 5000;
            bool bLoop = true;

            // create new object
            Console.WriteLine(DateTime.Now.ToString() + " : Create object server");
            VsServer vsServer = new VsServer();
            logger.Log(LogLevel.Info, DateTime.Now.ToString() + " : Create object server");

            // start server
            Console.WriteLine(DateTime.Now.ToString() + " : Start server");
            vsServer.StartServer();
            logger.Log(LogLevel.Info, DateTime.Now.ToString() + " : Start server");
            Thread.Sleep(vsWait);

            while (bLoop)
            {
                bLoop = false;

                try
                {
                    // start all cameras
                    Console.WriteLine(DateTime.Now.ToString() + " : Start cameras");
                    vsServer.StartAll();
                    logger.Log(LogLevel.Info, DateTime.Now.ToString() + " : Start cameras");
                    Thread.Sleep(vsWait);

                    while (!bLoop)
                    {
                        DateTime date = DateTime.Now;

                        if (date.Hour == vsHour && date.Minute >= vsMinute && date.Minute <= vsMinute + 1) bLoop = true;

                        Thread.Sleep(vsWait);
                    }

                    // stop all cameras
                    Console.WriteLine(DateTime.Now.ToString() + " : Stop cameras");
                    vsServer.StopAll();
                    logger.Log(LogLevel.Info, DateTime.Now.ToString() + " : Stop cameras");
                    Thread.Sleep(vsWait);
                }
                catch(Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + err.StackTrace);
                }

                if (bLoop) Thread.Sleep(vsWait * (12 + 1));
            }

            // stop server
            vsServer.ShutdownServer();
            Console.WriteLine(DateTime.Now.ToString() + " : Stop server");
            logger.Log(LogLevel.Info, DateTime.Now.ToString() + " : Stop server");
            Thread.Sleep(vsWait);

            vsServer = null;
        }
    }
}
