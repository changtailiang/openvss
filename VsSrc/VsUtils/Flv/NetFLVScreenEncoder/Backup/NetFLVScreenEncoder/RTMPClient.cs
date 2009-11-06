using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using NetFLVScreenEncoder.AMF;
using System.Threading;
namespace NetFLVScreenEncoder
{
    /// <summary>
    /// Handles basic RTMP protocl (handhsake, connect , creating a stream and publishing a video to the server
    /// for flash clients to watch.
    /// </summary>
    class RTMPClient : ConnectionProtocol
    {

        // holds in construction data to be sent to the server
        private byte[] dataBuffer = new byte[9999];

        // handles a chunk buffer (128 byte chunks + 12 for max header size)
        private byte[] chunk_buffer = new byte[128 + 12];

        private byte[] reserved1 = { 0x0, 0x3f, 0xf0, 0x00, 0x00, 0x00, 0x0, 0x0, 0x0 };
        private byte[] c_reserved = { 0x0, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        /// <summary>
        /// The streaming parameters
        /// </summary>
        private FLVStreamingParams sParams;

        /// <summary>
        /// The output buffer mapping to the dataBuffer as the backing array
        /// </summary>
        private MemoryStream outputBuff;

        /// <summary>
        /// Maps to teh chunk buffer as the backing array.
        /// </summary>
        private MemoryStream chunkBuff;

        /// <summary>
        /// The socket connection to the server.
        /// </summary>
        private Socket connectionSocket;

        private fRemoteCallHandler rcHandler;

        public override ConnectionProtocol.fRemoteCallHandler RemoteCallHandler
        {
            get
            {
                return rcHandler;
            }
            set
            {
                rcHandler = value;
            }
        }

        /// <summary>
        /// Initializes this RTMP client
        /// </summary>
        /// <param name="streamingParams">The parameters to use when connecting to the server.</param>
        public RTMPClient()
        {
            outputBuff = new MemoryStream(dataBuffer);
            chunkBuff = new MemoryStream(chunk_buffer);
        }

        public override string ProtocolName
        {
            get
            {
                return "RTMP";
            }
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

        private bool isConnected = false;
        /// <summary>
        /// Connects to the server both in the TCP stage and RTMP / RTMPT stage.
        /// </summary>
        public override bool connect(params string[] c_params)
        {
            IPAddress ipAdd = null;
            if(!IPAddress.TryParse(sParams.ServerURL, out ipAdd))
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(sParams.ServerURL);
                ipAdd = addresslist[0];
            }
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, sParams.Port);
            connectionSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           
            try
            {
                connectionSocket.Connect(remoteEP);
       
                //handshake with server
                rtmpHandshake();
              

                //connect (RTMP)
                rtmpConnect(c_params);
              

                //create a stream on the server
                rtmpCreateStream();
    

                //publish the stream
                rtmpPublish();
              
            }
            catch
            {
                return false;
            }
            isConnected = true;

            return true;

            
        }

        public void receiveData()
        {
            byte[] data = new byte[300];
            while (connectionSocket.Connected)
            {
                try
                {
                    int l = connectionSocket.Receive(data);
                    //check if its on channel 2 and send it back
                    if (data[0] == 0xC2)
                    {
                        connectionSocket.Send(data, l, SocketFlags.None);
                    }

                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
                

            }
            
        }

        public override bool disconnect()
        {
            isConnected = false;
            outputBuff.Position = 0;
            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x8);
            header.EndPoint = 0x00000001;
            header.TimeStamp = 0;
            header.RTMPType = AMFHeader.RTMP_TYPE_FUNCTION;
            header.BodySize = 0;


            AMFString func = new AMFString("publish");
            func.write(outputBuff);
            byte[] n_reserved = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputBuff.Write(n_reserved, 0, n_reserved.Length);
            new AMFNull().write(outputBuff);
            new AMFString(sParams.PublishName).write(outputBuff);
            new AMFBoolean(false).write(outputBuff);
            header.BodySize = (int)outputBuff.Position;

            //send the information
            chunkBufferAndSend(header);

            connectionSocket.Disconnect(true);

            return true;
        }

        /// <summary>
        /// Handshakes with the server (required for initial RTMP connection).
        /// </summary>
        private void rtmpHandshake()
        {
            //make a response buffer
            byte[] data = new byte[1537];

            //the handshake "number"
            data[0] = 0x3;

            //send the data
            connectionSocket.Send(data); //send data

            //set up resposne buffer
            data = new byte[3073];

            //receive the handshake response
            connectionSocket.Receive(data);

            //send back the first part of the response
            connectionSocket.Send(data, 1,
                1536, SocketFlags.None);
        }

        /// <summary>
        /// Performs the "connect" method on the server.
        /// </summary>
        private void rtmpConnect(string[] c_params)
        {
            //reset the output buffer position
            outputBuff.Position = 0;


            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x3);
            header.EndPoint = 0;
            header.TimeStamp = 1;
            header.RTMPType = AMFHeader.RTMP_TYPE_FUNCTION;
            header.BodySize = 0;


            //write the method name (connect);
            AMFString aString = new AMFString("connect");
            aString.write(outputBuff);
            outputBuff.Write(reserved1, 0, reserved1.Length);

            AMFObject aConnParams = new AMFObject();
            aConnParams.addParameter("app", new AMFString(sParams.ApplicationName));
            aConnParams.addParameter("flashVer", new AMFString("WIN 8,0,24,0"));
            aConnParams.addParameter("swfUrl", new AMFString("xfile://c:\\swfurl.swf"));
            aConnParams.addParameter("tcUrl", new AMFString("rtmp://" + sParams.ServerURL +"/" + sParams.ApplicationName));
            aConnParams.addParameter("fpad", new AMFBoolean(false));
            aConnParams.addParameter("name", new AMFString("ePresence"));

            aConnParams.write(outputBuff);

            foreach (string s in c_params)
            {
                new AMFString(s).write(outputBuff);
            }

            //since we only wrote the body, the body size is the positiin
            //in the buffer
            header.BodySize = (int)outputBuff.Position;

            //send the information
            chunkBufferAndSend(header);

            //receive the connection information
            int l =connectionSocket.Receive(dataBuffer);


            //receive the connection information
            l = connectionSocket.Receive(dataBuffer);
            

        }

        /// <summary>
        /// Create a Live Stream on the server
        /// </summary>
        private void rtmpCreateStream()
        {
            outputBuff.Position = 0;

            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x3);
            header.EndPoint = 0;
            header.TimeStamp = 1;
            header.RTMPType = AMFHeader.RTMP_TYPE_FUNCTION;
            header.BodySize = 0;


            AMFString func = new AMFString("createStream");
            func.write(outputBuff);

            outputBuff.Write(c_reserved, 0, c_reserved.Length);

            new AMFNull().write(outputBuff);

            header.BodySize = (int)outputBuff.Position;

            //send the information
            chunkBufferAndSend(header);


            int l = connectionSocket.Receive(dataBuffer);


        }

        public override void call(string methodName, fMethodCallback callbackFunc, params object[] pobject)
        {
            outputBuff.Position = 0;
            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x3);
            header.EndPoint = 0;
            header.TimeStamp = 1;
            header.RTMPType = AMFHeader.RTMP_TYPE_FUNCTION;
            header.BodySize = 0;

            AMFString func = new AMFString(methodName);
            func.write(outputBuff);

            outputBuff.Write(c_reserved, 0, c_reserved.Length);

            new AMFNull().write(outputBuff);

            foreach (object o in pobject)
            {
               AMFDataType dObj = AMFDataType.findDataHandler(o);
               dObj.write(outputBuff);

            }
            header.BodySize = (int)outputBuff.Position;
            chunkBufferAndSend(header);
        }

        /// <summary>
        /// Publish a stream on the server.
        /// </summary>
        private void rtmpPublish()
        {
            outputBuff.Position = 0;

            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x8);
            header.EndPoint = 0x1;
            header.TimeStamp = 0x25;
            header.RTMPType = AMFHeader.RTMP_TYPE_FUNCTION;
            header.BodySize = 0;


            AMFString func = new AMFString("publish");
            func.write(outputBuff);
            byte[] n_reserved = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputBuff.Write(n_reserved, 0, n_reserved.Length);
            new AMFNull().write(outputBuff);
            new AMFString(sParams.PublishName).write(outputBuff);
            AMFString live = new AMFString(sParams.Record ? "record" : "live");
            live.write(outputBuff);
            header.BodySize = (int)outputBuff.Position;

            //send the information
            chunkBufferAndSend(header);

            int l = connectionSocket.Receive(dataBuffer);


        }

        /// <summary>
        /// Sends the flv tag to the RTMP server.
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="tag"></param>
        public override bool sendFLVTag(byte[] tagData, FLVTag tag)
        {
      
            if (!isConnected)
                return false;
            outputBuff.Position = 0;
            chunkBuff.Position = 0;

            AMFHeader header = new AMFHeader(AMFHeader.HEADER_12, 0x8);
            header.RTMPType = AMFHeader.RTMP_TYPE_VIDEO;
            header.TimeStamp = tag.TimeStamp;
            header.EndPoint = 0x00000001;
            header.BodySize = tag.getTagSizeInBytes() - 11;

            //write the header to teh chunkbuffer
            header.writeHeader(chunkBuff);

            //the size remaining in the data buffer
            int size = tag.getTagSizeInBytes() - 11;

            //the position in the data buffer (from which to start sending bytes)
            int position = 0;

            //write the header to the chunk buffer
            header.writeHeader(chunkBuff);

            //copy <= 128 bytes from the tagData into the chunk buffer to send.
            Array.Copy(tagData, 11, chunk_buffer, header.getHeaderSize(),
                size > 128 ? 128 : size);
            //send the first packet of information
            connectionSocket.Send(chunk_buffer,
                (header.getHeaderSize() + (size > 128 ? 128 : size)),
                SocketFlags.None);

            size -= 128;
            position += 128 + 11;

            //while there is still bytes
            while (size > 0)
            {

                //add a header byte
                byte t = tagData[position - 1];
                tagData[position - 1] = header.get_1_HeaderByte();

                //send out the data
                connectionSocket.Send(tagData, position - 1,
                    size > 128 ? 129 : size + 1, SocketFlags.None);
                

                //restore where the header was
                tagData[position - 1] = t;
                position += 128;
                size -= 128;

            }

            return true;

        }

        /// <summary>
        /// Dumps the data from a given byte array of information.
        /// </summary>
        /// <param name="data">The data to dump</param>
        /// <param name="length">How many bytes to look at</param>
        /// <param name="start">The start index in the array.</param>
        private void dumpData(byte[] data, int length, int start)
        {
            for (int i = start; i < length; i++)
            {
                byte b = data[i];
                if (i % 30 == 0)
                    Console.WriteLine();

                Console.Write(data[i].ToString("x") + " ");
            }
        }


        /// <summary>
        /// Sends the current buffer using data_buffer as the source of data. The size
        /// is determined from the position in outputBuff.
        /// </summary>
        /// <param name="header">The header to prepend to the amf packet.</param>
        private void chunkBufferAndSend(AMFHeader header)
        {
            //the size remaining in the data buffer
            int size = (int)outputBuff.Position;

            //the position in the data buffer (from which to start sending bytes)
            int position = 0;

            //reset the chunkBuff position
            chunkBuff.Position = 0;

            //write the header to the chunk buffer
            header.writeHeader(chunkBuff);

            //copy <= 128 bytes from the data buffer into the chunk buffer to send.
            Array.Copy(dataBuffer, 0, chunk_buffer, header.getHeaderSize(),
                size > 128 ? 128 : size);
            //send the first packet of information
            connectionSocket.Send(chunk_buffer,
                (header.getHeaderSize() + (size > 128 ? 128 : size)),
                SocketFlags.None);

            size -= 128;
            position += 128;


            while (size > 0)
            {
                //add a header byte
                dataBuffer[position - 1] = header.get_1_HeaderByte();

                //send out the data
                connectionSocket.Send(dataBuffer, position - 1,
                    size > 128 ? 129 : size + 1, SocketFlags.None);

                

                position += 128;
                size -= 128;
            }
        }

        public LinkedList<AMFDataType> getParameters(byte[] data, int length)
        {
            AMFHeader headerResponse = AMFHeader.readHeader(0, data);
            MemoryStream inStream = new MemoryStream(data);
            inStream.Position = headerResponse.getHeaderSize();

            //since we are only dealing with function calls...
            //the first information is going to be A Function name. (AMF String)

            AMFString function = new AMFString("");
            function.read(inStream);

            inStream.Close();


            return null;
        }

    }
}