// hnmc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zbht	
// hmcd	 By downloading, copying, installing or using the software you agree to this license.
// uttv	 If you do not agree to this license, do not download, install,
// aljk	 copy or use the software.
// adhq	
// awyy	                          License Agreement
// omvg	         For OpenVSS - Open Source Video Surveillance System
// gpzu	
// nzoo	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ghgm	
// bbxr	Third party copyrights are property of their respective owners.
// vidt	
// cwad	Redistribution and use in source and binary forms, with or without modification,
// gvcc	are permitted provided that the following conditions are met:
// djfv	
// qvxe	  * Redistribution's of source code must retain the above copyright notice,
// tyhb	    this list of conditions and the following disclaimer.
// xuet	
// xupy	  * Redistribution's in binary form must reproduce the above copyright notice,
// zgcf	    this list of conditions and the following disclaimer in the documentation
// ibdj	    and/or other materials provided with the distribution.
// owor	
// wllw	  * Neither the name of the copyright holders nor the names of its contributors 
// clwf	    may not be used to endorse or promote products derived from this software 
// esyw	    without specific prior written permission.
// abwi	
// shfm	This software is provided by the copyright holders and contributors "as is" and
// gddw	any express or implied warranties, including, but not limited to, the implied
// hzmp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// snpx	In no event shall the Prince of Songkla University or contributors be liable 
// kqel	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ihrm	(including, but not limited to, procurement of substitute goods or services;
// yjug	loss of use, data, or profits; or business interruption) however caused
// iffg	and on any theory of liability, whether in contract, strict liability,
// evrh	or tort (including negligence or otherwise) arising in any way out of
// qckt	the use of this software, even if advised of the possibility of such damage.
// ippc	
// ygnq	Intelligent Systems Laboratory (iSys Lab)
// camk	Faculty of Engineering, Prince of Songkla University, THAILAND
// xlal	Project leader by Nikom SUVONVORN
// qsox	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.Net.Sockets;
using System.Collections;
using System.Web;
using System.Threading;

namespace Vs.Core.MediaProxyServer
{
    enum RState
    {
        METHOD, URL, URLPARM, URLVALUE, VERSION,
        HEADERKEY, HEADERVALUE, BODY, OK
    };

    enum RespState
    {
        OK = 200,
        BAD_REQUEST = 400,
        NOT_FOUND = 404
    }

    public struct HTTPRequestStruct
    {
        public string Method;
        public string URL;
        public string Version;
        public Hashtable Args;
        public bool Execute;
        public Hashtable Headers;
        public int BodySize;
        public byte[] BodyData;
    }

    public struct HTTPResponseStruct
    {
        public int status;
        public string version;
        public Hashtable Headers;
        public int BodySize;
        public byte[] BodyData;
        public System.IO.FileStream fs;
    }

    public class HttpRequestParsing
    {
        private TcpClient client;

        private RState ParserState;

        public HTTPRequestStruct HTTPRequest;
        public HTTPResponseStruct HTTPResponse;

        // byte[] myReadBuffer;

        HttpServer Parent;

        NetworkStream ns;

        public HttpRequestParsing()//, CsHTTPServer Parent)
        {
            // this.Parent = Parent;

            this.HTTPResponse.BodySize = 0;
        }

        string hValue = "";
        string hKey = "";

        // binary data buffer index
        int bfndx = 0;

        private void strParsing(string str, byte[] myReadBuffer, int numberOfBytesRead)
        {
            // read buffer index
            int ndx = 0;
            do
            {
                switch (ParserState)
                {
                    case RState.METHOD:
                        if (myReadBuffer[ndx] != ' ')
                            HTTPRequest.Method += (char)myReadBuffer[ndx++];
                        else
                        {
                            ndx++;
                            ParserState = RState.URL;
                        }
                        break;
                    case RState.URL:
                        if (myReadBuffer[ndx] == '?')
                        {
                            ndx++;
                            hKey = "";
                            HTTPRequest.Execute = true;
                            HTTPRequest.Args = new Hashtable();
                            ParserState = RState.URLPARM;
                        }
                        else if (myReadBuffer[ndx] != ' ')
                            HTTPRequest.URL += (char)myReadBuffer[ndx++];
                        else
                        {
                            ndx++;
                            HTTPRequest.URL = HttpUtility.UrlDecode(HTTPRequest.URL);
                            ParserState = RState.VERSION;
                        }
                        break;
                    case RState.URLPARM:
                        if (myReadBuffer[ndx] == '=')
                        {
                            ndx++;
                            hValue = "";
                            ParserState = RState.URLVALUE;
                        }
                        else if (myReadBuffer[ndx] == ' ')
                        {
                            ndx++;

                            HTTPRequest.URL = HttpUtility.UrlDecode(HTTPRequest.URL);
                            ParserState = RState.VERSION;
                        }
                        else
                        {
                            hKey += (char)myReadBuffer[ndx++];
                        }
                        break;
                    case RState.URLVALUE:
                        if (myReadBuffer[ndx] == '&')
                        {
                            ndx++;
                            hKey = HttpUtility.UrlDecode(hKey);
                            hValue = HttpUtility.UrlDecode(hValue);
                            HTTPRequest.Args[hKey] = HTTPRequest.Args[hKey] != null ? HTTPRequest.Args[hKey] + ", " + hValue : hValue;
                            hKey = "";
                            ParserState = RState.URLPARM;
                        }
                        else if (myReadBuffer[ndx] == ' ')
                        {
                            ndx++;
                            hKey = HttpUtility.UrlDecode(hKey);
                            hValue = HttpUtility.UrlDecode(hValue);
                            HTTPRequest.Args[hKey] = HTTPRequest.Args[hKey] != null ? HTTPRequest.Args[hKey] + ", " + hValue : hValue;

                            HTTPRequest.URL = HttpUtility.UrlDecode(HTTPRequest.URL);
                            ParserState = RState.VERSION;
                        }
                        else
                        {
                            hValue += (char)myReadBuffer[ndx++];
                        }
                        break;
                    case RState.VERSION:
                        if (myReadBuffer[ndx] == '\r')
                            ndx++;
                        else if (myReadBuffer[ndx] != '\n')
                            HTTPRequest.Version += (char)myReadBuffer[ndx++];
                        else
                        {
                            ndx++;
                            hKey = "";
                            HTTPRequest.Headers = new Hashtable();
                            ParserState = RState.HEADERKEY;
                        }
                        break;
                    case RState.HEADERKEY:
                        if (myReadBuffer[ndx] == '\r')
                            ndx++;
                        else if (myReadBuffer[ndx] == '\n')
                        {
                            ndx++;
                            if (HTTPRequest.Headers["Content-Length"] != null)
                            {
                                HTTPRequest.BodySize = Convert.ToInt32(HTTPRequest.Headers["Content-Length"]);
                                this.HTTPRequest.BodyData = new byte[this.HTTPRequest.BodySize];
                                ParserState = RState.BODY;
                            }
                            else
                                ParserState = RState.OK;

                        }
                        else if (myReadBuffer[ndx] == ':')
                            ndx++;
                        else if (myReadBuffer[ndx] != ' ')
                            hKey += (char)myReadBuffer[ndx++];
                        else
                        {
                            ndx++;
                            hValue = "";
                            ParserState = RState.HEADERVALUE;
                        }
                        break;
                    case RState.HEADERVALUE:
                        if (myReadBuffer[ndx] == '\r')
                            ndx++;
                        else if (myReadBuffer[ndx] != '\n')
                            hValue += (char)myReadBuffer[ndx++];
                        else
                        {
                            ndx++;
                            if (!HTTPRequest.Headers.Contains(hKey))
                                HTTPRequest.Headers.Add(hKey, hValue);
                            hKey = "";
                            ParserState = RState.HEADERKEY;
                        }
                        break;
                    case RState.BODY:
                        // Append to request BodyData
                        Array.Copy(myReadBuffer, ndx, this.HTTPRequest.BodyData, bfndx, numberOfBytesRead - ndx);
                        bfndx += numberOfBytesRead - ndx;
                        ndx = numberOfBytesRead;
                        if (this.HTTPRequest.BodySize <= bfndx)
                        {
                            ParserState = RState.OK;
                        }
                        break;
                    //default:
                    //	ndx++;
                    //	break;

                }
            }
            while (ndx < numberOfBytesRead);
        }

        public void ProcessRequest(TcpClient client, HttpServer Parent)
        {
            this.Parent = Parent;
            this.client = client;

            byte[] myReadBuffer = new byte[client.ReceiveBufferSize];
            String myCompleteMessage = "";
            int numberOfBytesRead = 0;


            ns = client.GetStream();

        
            /// Incoming message may be larger than the buffer size.
            do
            {
                numberOfBytesRead = ns.Read(myReadBuffer, 0, myReadBuffer.Length);

                myCompleteMessage =
                    String.Concat(myCompleteMessage, Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

                strParsing(myCompleteMessage, myReadBuffer, numberOfBytesRead);

                if (ParserState != RState.OK)
                {
                    numberOfBytesRead = 0;
                    numberOfBytesRead = ns.Read(myReadBuffer, 0, myReadBuffer.Length);

                    if (numberOfBytesRead > 0)
                    {
                        myCompleteMessage = Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead);

                        strParsing(myCompleteMessage, myReadBuffer, numberOfBytesRead);
                    }
                    //String.Concat(myCompleteMessage, );
                }
             
            }
            while (ns.DataAvailable);



            //HTTPResponse.status = (int)RespState.BAD_REQUEST;
        }

        public void ProcessRespont()
        {
            try
            {
                if (ns == null)
                {
                    return;
                }

                HTTPResponse.version = "HTTP/1.0";

                if (ParserState != RState.OK)
                    HTTPResponse.status = (int)RespState.BAD_REQUEST;
                else
                    HTTPResponse.status = (int)RespState.OK;

                this.HTTPResponse.Headers = new Hashtable();

                this.HTTPResponse.Headers.Add("Expires", DateTime.Now.ToString("r"));
                //this.HTTPResponse.Headers.Add("Server", Parent.Name);

                bool hasData = false;
                //createHeader
                if (HTTPResponse.status == (int)RespState.OK)
                    hasData = this.Parent.CreateHeaderResponse(ref this.HTTPResponse);

                string HeadersString = this.HTTPResponse.version + " " + this.Parent.respStatus[this.HTTPResponse.status] + "\r\n";

                foreach (DictionaryEntry Header in this.HTTPResponse.Headers)
                {
                    HeadersString += Header.Key + ": " + Header.Value + "\r\n";
                }

                HeadersString += "\r\n";
                byte[] bHeadersString = Encoding.ASCII.GetBytes(HeadersString);

                // Send headers	
                ns.Write(bHeadersString, 0, bHeadersString.Length);
                HttpServer.output = "start Sent headers" + HeadersString;

                // Send body
                if (this.HTTPResponse.BodyData != null)
                {
                    ns.Write(this.HTTPResponse.BodyData, 0, this.HTTPResponse.BodyData.Length);
                    HttpServer.output = "start Sent body" + this.HTTPResponse.BodyData + "\r\n" + HttpServer.output;
                }

                if (hasData)
                {
                    this.Parent.sendStreamResponse(ns, ref this.HTTPResponse, client.SendBufferSize);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ns.Close();
                client.Close();
                if (this.HTTPResponse.fs != null)
                    this.HTTPResponse.fs.Close();
                Thread.CurrentThread.Abort();

            }

        }

    }
}
