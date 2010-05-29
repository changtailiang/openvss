// iwnb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ufkx	
// wihi	 By downloading, copying, installing or using the software you agree to this license.
// flcs	 If you do not agree to this license, do not download, install,
// ronr	 copy or use the software.
// vdei	
// tvjt	                          License Agreement
// vgqx	         For OpenVSS - Open Source Video Surveillance System
// nnkm	
// coit	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wqut	
// tdem	Third party copyrights are property of their respective owners.
// ihtc	
// ewbf	Redistribution and use in source and binary forms, with or without modification,
// sehy	are permitted provided that the following conditions are met:
// wqcq	
// sjus	  * Redistribution's of source code must retain the above copyright notice,
// aqqc	    this list of conditions and the following disclaimer.
// fuuf	
// jkpp	  * Redistribution's in binary form must reproduce the above copyright notice,
// qwln	    this list of conditions and the following disclaimer in the documentation
// mosr	    and/or other materials provided with the distribution.
// lfux	
// hjxg	  * Neither the name of the copyright holders nor the names of its contributors 
// oebk	    may not be used to endorse or promote products derived from this software 
// jmlr	    without specific prior written permission.
// qrwk	
// cvvh	This software is provided by the copyright holders and contributors "as is" and
// priz	any express or implied warranties, including, but not limited to, the implied
// foee	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qdgv	In no event shall the Prince of Songkla University or contributors be liable 
// wtvv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xorf	(including, but not limited to, procurement of substitute goods or services;
// ifge	loss of use, data, or profits; or business interruption) however caused
// ktxu	and on any theory of liability, whether in contract, strict liability,
// rioq	or tort (including negligence or otherwise) arising in any way out of
// jmhp	the use of this software, even if advised of the possibility of such damage.
// bxaz	
// axtf	Intelligent Systems Laboratory (iSys Lab)
// gquw	Faculty of Engineering, Prince of Songkla University, THAILAND
// wbmn	Project leader by Nikom SUVONVORN
// eqzk	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace Vs.Core.MediaProxyServer
{

    public abstract class HttpServer
    {
        public static string output = "";

        private int portNum = 8080;
        private TcpListener listener;
        System.Threading.Thread Thread;

        public Hashtable respStatus;

        public string Name = "newwwServer/1";

        public VsMediaCommand command;

        public bool IsAlive
        {
            get
            {
                return this.Thread.IsAlive;
            }
        }

        public HttpServer()
        {
            //
            respStatusInit();
        }

        public HttpServer(int thePort)
        {
            portNum = thePort;
            respStatusInit();
        }

        private void respStatusInit()
        {
            respStatus = new Hashtable();

            respStatus.Add(200, "200 Ok");
            respStatus.Add(201, "201 Created");
            respStatus.Add(202, "202 Accepted");
            respStatus.Add(204, "204 No Content");

            respStatus.Add(301, "301 Moved Permanently");
            respStatus.Add(302, "302 Redirection");
            respStatus.Add(304, "304 Not Modified");

            respStatus.Add(400, "400 Bad Request");
            respStatus.Add(401, "401 Unauthorized");
            respStatus.Add(403, "403 Forbidden");
            respStatus.Add(404, "404 Not Found");

            respStatus.Add(500, "500 Internal Server Error");
            respStatus.Add(501, "501 Not Implemented");
            respStatus.Add(502, "502 Bad Gateway");
            respStatus.Add(503, "503 Service Unavailable");
        }

        public void Listen()
        {

            bool done = false;

            System.Net.IPAddress localAddr = System.Net.IPAddress.Any;

            listener = new TcpListener(localAddr, portNum);

            listener.Start();

            WriteLog("Listening On: " + portNum.ToString());

            while (!done)
            {
                WriteLog("Waiting for connection...");
                TcpClient client = null;
                try
                {
                    HttpServer.output += "Waiting for connection...\r\n";
                    client = listener.AcceptTcpClient();

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);

                    return;
                }
                Thread t = new Thread(() =>
                {
                    try
                    {
                        HttpRequestParsing newRequest = new HttpRequestParsing();
                        newRequest.ProcessRequest(client, this);

                        HttpServer.output = newRequest.HTTPRequest.Method;

                        command = new VsMediaCommand(newRequest.HTTPRequest);

                        newRequest.ProcessRespont();
                    }
                    catch (Exception ex)
                    {
                        //System.Windows.Forms.MessageBox.Show("eror in Listen "+ex.Message);

                    }

                });
                t.IsBackground = true;
                t.Priority = ThreadPriority.Normal;
                t.Start();

                //Thread Thread = new Thread(new ThreadStart(newRequest.Process));
                //Thread.Name = "HTTP Request";
                //Thread.Start();
            }

        }

        public void WriteLog(string EventMessage)
        {
            Console.WriteLine(EventMessage);
        }

        public void Start()
        {
            // CsHTTPServer HTTPServer = new CsHTTPServer(portNum);
            this.Thread = new Thread(new ThreadStart(this.Listen));
            this.Thread.Start();
        }

        public void Stop()
        {
            listener.Stop();
            this.Thread.Abort();
        }

        public void Suspend()
        {
            this.Thread.Suspend();
        }

        public void Resume()
        {
            this.Thread.Resume();
        }

        public abstract bool CreateHeaderResponse(ref HTTPResponseStruct rp);
        public abstract void sendStreamResponse(NetworkStream ns, ref HTTPResponseStruct rp, int SendBufferSize);

        public abstract void OnResponse(ref HTTPRequestStruct rq, ref HTTPResponseStruct rp);

    }
}
