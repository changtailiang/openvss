using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using NetFLVScreenEncoder.AMF;

namespace NetFLVScreenEncoder
{
    class RTMPTClient : ConnectionProtocol
    {

        private Socket connectionSocket;

        private FLVStreamingParams sParams;

        private MemoryStream buffer;

        private int pollCount = 0;

        private int clientIndex;

        private byte[] reserved1 = { 0x0, 0x3f, 0xf0, 0x00, 0x00, 0x00, 0x0, 0x0, 0x0 };

        public RTMPTClient()
        {

            buffer = new MemoryStream(50000);

        }

        

        public override void call(string methodName, fMethodCallback callbackFunc, params object[] methodParameters)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public override bool connect(params string[] c_params)
        {

            rtmptConnect(c_params);

            return true;

           
        }

        public void rtmptConnect(string[] c_params)
        {

            PersistantHTTPConnection connection = new PersistantHTTPConnection(sParams.ServerURL,
                sParams.Port);

      
            
            req = (HttpWebRequest)WebRequest.Create(
                "http://" + sParams.ServerURL + ":" + sParams.Port + "/send/" + clientIndex + "/" + pollCount
            );
            req.ContentType = "application/x-fcs";
            req.Method = "POST";
            req.KeepAlive = true;

            //using the client index connect to the application
            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x3);
            header.EndPoint = 0;
            header.TimeStamp = 1;
            header.RTMPType = AMFHeader.RTMP_TYPE_FUNCTION;
            header.BodySize = 0;

            requestStream = req.GetRequestStream();
           

            //write the method name (connect);
            AMFString aString = new AMFString("connect");
            aString.write(buffer);
            buffer.Write(reserved1, 0, reserved1.Length);

            AMFObject aConnParams = new AMFObject();
            aConnParams.addParameter("app", new AMFString(sParams.ApplicationName));
            aConnParams.addParameter("flashVer", new AMFString("WIN 8,0,24,0"));
            aConnParams.addParameter("swfUrl", new AMFString("xfile://c:\\swfurl.swf"));
            aConnParams.addParameter("tcUrl", new AMFString("rtmp://" + sParams.ServerURL + "/" + sParams.ApplicationName));
            aConnParams.addParameter("fpad", new AMFBoolean(false));
            aConnParams.addParameter("name", new AMFString("ePresence"));

            aConnParams.write(buffer);

            foreach (string s in c_params)
            {
                new AMFString(s).write(buffer);
            }

            header.BodySize = (int)buffer.Position;
            Console.Write(header.BodySize);
            header.writeHeader(requestStream);
            requestStream.Write(buffer.GetBuffer(), 0, (int)buffer.Position);

 
            resp = (HttpWebResponse)req.GetResponse();
            responseReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            Console.WriteLine(responseReader.ReadToEnd());


        }

        public override FLVStreamingParams ConnectionParameters
        {
            get
            {
                return sParams;
            }
            set
            {
                sParams = value;
            }
        }

        public override bool disconnect()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(
                "http://" + sParams.ServerURL + ":" + sParams.Port + "/close/" + clientIndex + "/" + pollCount);
            req.ContentType = "application/x-fcs";
            req.Method = "POST";
            req.ContentLength = 1;
            req.KeepAlive = false;

            Stream requestStream = req.GetRequestStream();
            requestStream.WriteByte(0);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            return true;

        }

        public override string ProtocolName
        {
            get { return "RTMPT";  }
        }

        public override fRemoteCallHandler RemoteCallHandler
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override bool sendFLVTag(byte[] buffer, FLVTag tag)
        {
            //throw new Exception("The method or operation is not implemented.");
            return true;
        }

    }

    class PersistantHTTPConnection
    {
        private Socket connectionSocket;

        private string path;

        private string host;

        private int port;

        /// <summary>
        /// Constructor takes the host of the server ie: "www.abc.com"
        /// with no http
        /// </summary>
        /// <param name="host">the host to connect to</param>
        public PersistantHTTPConnection(string host, int port)
        {
            this.host = host;
            this.port = port;
            IPAddress ipAdd = null;
            if (!IPAddress.TryParse(host, out ipAdd))
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(host);
                ipAdd = addresslist[0];
            }
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, port);
            connectionSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        class HTTPResponse
        {
            public byte[] content;


        }

        

        /// <summary>
        /// The path of the resource on the server. 
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }


    }
}
