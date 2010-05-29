// yivd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nzfs	
// uavx	 By downloading, copying, installing or using the software you agree to this license.
// blmh	 If you do not agree to this license, do not download, install,
// tqvb	 copy or use the software.
// kmtl	
// thoq	                          License Agreement
// bphc	         For OpenVSS - Open Source Video Surveillance System
// lhni	
// lhoa	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lyhh	
// wqds	Third party copyrights are property of their respective owners.
// dmyn	
// rlul	Redistribution and use in source and binary forms, with or without modification,
// pkkf	are permitted provided that the following conditions are met:
// lore	
// ttmt	  * Redistribution's of source code must retain the above copyright notice,
// ydwm	    this list of conditions and the following disclaimer.
// bupm	
// floc	  * Redistribution's in binary form must reproduce the above copyright notice,
// ewno	    this list of conditions and the following disclaimer in the documentation
// rtkz	    and/or other materials provided with the distribution.
// mbta	
// xiox	  * Neither the name of the copyright holders nor the names of its contributors 
// gcoc	    may not be used to endorse or promote products derived from this software 
// ektz	    without specific prior written permission.
// qmlx	
// vifd	This software is provided by the copyright holders and contributors "as is" and
// vhbp	any express or implied warranties, including, but not limited to, the implied
// bdnz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jmgx	In no event shall the Prince of Songkla University or contributors be liable 
// kvpt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fsfd	(including, but not limited to, procurement of substitute goods or services;
// xlyt	loss of use, data, or profits; or business interruption) however caused
// cnxe	and on any theory of liability, whether in contract, strict liability,
// inde	or tort (including negligence or otherwise) arising in any way out of
// vpep	the use of this software, even if advised of the possibility of such damage.
// gzwd	
// pots	Intelligent Systems Laboratory (iSys Lab)
// dwpu	Faculty of Engineering, Prince of Songkla University, THAILAND
// xsrd	Project leader by Nikom SUVONVORN
// ccgj	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Net.Sockets;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections;
using Vs.Core.Provider;
using Vs.Core.Image;
using System.Reflection;

namespace Vs.Core.MediaProxyServer
{
    public class VsMediaProxyServer : HttpServer
    {
        public string DataFolder;
        string vsAppPath;
        private Dictionary<string, VsProviderManager> VsProviderManagerDic;

        public VsMediaProxyServer()
            : base()
        {
            this.DataFolder = "c:\\";
            this.vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
            InitializeProviderManager(vsAppPath, vsAppPath);
        }

        public VsMediaProxyServer(int thePort, string dataFolder, string vsAppPath, string providerPath)
            : base(thePort)
        {
            this.DataFolder = dataFolder;
            this.vsAppPath = vsAppPath;
            InitializeProviderManager(vsAppPath, providerPath);
        }

        public VsMediaProxyServer(int thePort, string theFolder, string vsAppPath)
            : this(thePort, theFolder, vsAppPath, vsAppPath)
        {

        }

        private void InitializeProviderManager(string vsAppPath, string providerPath)
        {

            VsProviderCollection vsProviders = new VsProviderCollection();
            vsProviders.Load(providerPath);

            string fullFileName = Path.Combine(vsAppPath, "cameras.config");

            Hashtable[] data = ConfigData.loadCamConfig(fullFileName);


            VsProviderManagerDic = new Dictionary<string, VsProviderManager>();
            foreach (var v in data)
            {

                string camId = v["name"].ToString();
                //// string source = v[""]; 

                string ProviderName = v["provider"].ToString();
                // // string ProviderName = "Vs.Provider.Axis.Axis2110Description";

                // Hashtable reader = new Hashtable();
                // reader["source"] = v["source"];//source;
                // reader["login"] = v["login"]; ;
                // reader["password"] = v["password"];

                // reader["size"] = "640x480";
                // reader["stype"] = "1";
                // reader["interval"] = "250";

                //if (coreProvider != null)
                //{
                //    coreProvider.Stop();
                //}  

                VsProvider provider = vsProviders.GetProviderByName(ProviderName);

                VsProviderManagerDic.Add(camId, new VsProviderManager(v, provider));
            }
            //{
            //    string camId = "cam1";
            //    string source = "@device:pnp:\\\\?\\usb#vid_eb1a&pid_2761&mi_00#6&30952a2b&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\\global";

            //    string ProviderName = "Vs.Provider.Local.CaptureDeviceDescription";
            //    // string ProviderName = "Vs.Provider.Axis.Axis2110Description";

            //    Hashtable reader = new Hashtable();
            //    reader["source"] = source;//source;
            //    reader["login"] = "root";
            //    reader["password"] = "l0o=0-85";

            //    reader["size"] = "640x480";
            //    reader["stype"] = "1";
            //    reader["interval"] = "250";

            //    //if (coreProvider != null)
            //    //{
            //    //    coreProvider.Stop();
            //    //}  

            //    VsProvider provider = vsProviders.GetProviderByName(ProviderName);

            //    VsProviderManagerDic.Add(camId, new VsProviderManager(reader, provider));
            //}
            //{
            //    string camId = "cam2";
            //    string source = "camera-210-01.coe.psu.ac.th";


            //    string ProviderName = "Vs.Provider.Axis.Axis2110Description";

            //    Hashtable reader = new Hashtable();
            //    reader["source"] = source;//source;
            //    reader["login"] = "root";
            //    reader["password"] = "l0o=0-85";

            //    reader["size"] = "640x480";
            //    reader["stype"] = "1";
            //    reader["interval"] = "250";

            //    //if (coreProvider != null)
            //    //{
            //    //    coreProvider.Stop();
            //    //}  

            //    VsProvider provider = vsProviders.GetProviderByName(ProviderName);

            //    VsProviderManagerDic.Add(camId, new VsProviderManager(reader, provider));
            //}

            //coreProvider = provider.CreateVideoSource(provider.LoadConfiguration(reader));
        }


        public override bool CreateHeaderResponse(ref HTTPResponseStruct rp)
        {
            string bodyStr = "";

            if (command.streamType == StreamType.File && command.sourceType == SourceType.File)
            {
                string path = Path.Combine(this.DataFolder, command.urlSource.Replace("/", "\\"));

                if (File.Exists(path))
                {
                    RegistryKey rk = Registry.ClassesRoot.OpenSubKey(Path.GetExtension(path), false);

                    // Get the data from a specified item in the key.
                    String s = (String)rk.GetValue("Content Type");

                    // Open the stream and read it back.
                    rp.fs = File.OpenRead(path);
                    if (s != "")
                    {
                        rp.Headers["Content-Type"] = s;
                        rp.Headers["Content-Length"] = rp.fs.Length;
                    }
                    return true;
                }
            }
            else if (command.streamType == StreamType.MJpeg)
            {
                //rp.Headers["Content-Length"] = "-1";

                //rp.Headers["Cache-Control"] = "no-cache";
                // rp.Headers["Pragma"] = "no-cache";
                //rp.Headers["Connection"] = "close";
                rp.Headers["Content-Type"] = "multipart/x-mixed-replace; boundary=--myboundary";
                return true;
            }
            else if (command.streamType == StreamType.Jpeg)
            {
                rp.Headers["Content-type"] = "image/jpeg";
                return true;
            }

            {
                bodyStr = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\n";
                bodyStr += "<HTML><HEAD>\n";
                bodyStr += "<META http-equiv=Content-Type content=\"text/html; charset=windows-1252\">\n";
                bodyStr += "</HEAD>\n";
                bodyStr += "<BODY>File not found!!</BODY></HTML>\n";
                rp.BodyData = Encoding.ASCII.GetBytes(bodyStr);
            }

            return false;
        }

        public override void sendStreamResponse(NetworkStream ns, ref HTTPResponseStruct rp, int SendBufferSize)
        {
            if (command.sourceType == SourceType.File)
            {

                if (command.streamType == StreamType.File)
                {
                    if (rp.fs != null)
                        using (rp.fs)
                        {
                            if (command.HTTPRequest.Args == null || command.HTTPRequest.Args.Count == 0)
                            {
                                sendStream(ns, SendBufferSize, LoadMemoryStreamFromFile(rp.fs));
                            }
                            else
                            {
                                MemoryStream ms = new ffMpegFileConvert(this.vsAppPath).ConvertToWmv(rp.fs.Name, command.videoSize).VideoStream;
                                sendStream(ns, SendBufferSize, ms);//
                                rp.fs.Close();
                                // sendStream(ns, SendBufferSize, rp.fs);//

                            }
                        }

                }
                else if (command.streamType == StreamType.MJpeg)
                {
                    string fileName = Path.Combine(this.DataFolder, command.urlSource.Replace("/", "\\"));//command.urlSource;
                    int framRate = command.framRate;
                    Size videoSize = command.videoSize;
                    int videoQuanlity = command.videoQuanlity;

                    sendStreamMjpegFromFile(fileName, ns, SendBufferSize, framRate, videoSize, videoQuanlity);
                }
            }
            if (command.sourceType == SourceType.Live)
            {
                if (command.streamType == StreamType.Jpeg)
                {

                }
                else if (command.streamType == StreamType.MJpeg)
                {
                    //  string fileName = "data\\42.wmv";
                    string camID = command.urlSource;
                    int framRate = command.framRate;
                    Size videoSize = command.videoSize;
                    int videoQuanlity = command.videoQuanlity;
                    //sendStreamMjpegFromFile(ns, SendBufferSize, fileName, framRate, videoSize, videoQuanlity);

                    sendStreamMjpegFromProvider(getProvider(camID), ns, SendBufferSize, framRate, videoSize, videoQuanlity);
                    //sendStreamMjpegFromProvider(getProvider("camera-210-01.coe.psu.ac.th"), ns, SendBufferSize, framRate, videoSize, videoQuanlity);
                }
            }
        }

        private void sendStreamMjpegFromFile(string fileName, NetworkStream ns, int SendBufferSize, int framRate, Size videoSize, int videoQuality)
        {
            DateTime start;
            TimeSpan span;

            int frameInterval = 1000 / framRate;

            VsDexterLibVideoReader fe = new VsDexterLibVideoReader(fileName, videoSize,frameInterval);
           // VeWmvLibVideoReader fe = new VeWmvLibVideoReader(fileName, frameInterval,videoSize);
            #region setImageEncoder
            // Get a bitmap.
            // Bitmap bmp1 = new Bitmap(@"c:\TestPhoto.jpg");

            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters();

            // Save the bitmap as a JPG file with zero quality level compression.
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)videoQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            #endregion

            MemoryStream stream;
            Bitmap bmp;
            //double i = 0;
            while (fe.getNextFrameAsInterval(out bmp))
            {
                stream = new MemoryStream();
                start = DateTime.Now;

                // bmp = fe.GetFrameFromVideoPosition(i);
                //Form1.bmp = new Bitmap(bmp);
                // = new Bitmap(bmp videoSize)
               
                //bmp.SetResolution(videoSize.Width, videoSize.Height);
                bmp.Save(stream, jgpEncoder, myEncoderParameters);
                sendMjpegHead(ns, stream.Length);
                //bmp.Save(ns, jgpEncoder, myEncoderParameters);
                //Bitmap.FromStream(stream).Save(ns,ImageFormat.Jpeg);

                sendStream(ns, SendBufferSize, stream);

                byte[] bHeadersString = Encoding.ASCII.GetBytes("\r\n");
                // Send headers	
                ns.Write(bHeadersString, 0, bHeadersString.Length);

                stream.Close();
                // ;
                //i += 1.0 / framRate;
                //if (i > fe.streamLength)
                //{
                //    break;
                //}

                span = DateTime.Now.Subtract(start);
                // miliseconds to sleep
                int msec = fe.outputFrameInterval - (int)span.TotalMilliseconds;

                while ((msec > 0))
                {
                    // sleeping ...
                    Thread.Sleep((msec < 100) ? msec : 100);
                    msec -= 100;
                }
            }
            fe.Close();

        }

        private VsProviderManager getProvider(string camId)
        {
            // VsICoreProvider coreProvider;

            // VsProviderCollection vsProviders = new VsProviderCollection();

            // string vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
            // vsProviders.Load(vsAppPath);

            // camId = "@device:pnp:\\\\?\\usb#vid_eb1a&pid_2761&mi_00#6&30952a2b&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\\global";

            // string ProviderName = "Vs.Provider.Local.CaptureDeviceDescription";
            //// string ProviderName = "Vs.Provider.Axis.Axis2110Description";

            // Hashtable reader = new Hashtable();
            // reader["source"] = camId;//source;
            // reader["login"] = "root";
            // reader["password"] = "l0o=0-85";

            // reader["size"] = "640x480";
            // reader["stype"] = "1";
            // reader["interval"] = "250";

            // //if (coreProvider != null)
            // //{
            // //    coreProvider.Stop();
            // //}

            // VsProvider provider = vsProviders.GetProviderByName(ProviderName);
            // coreProvider = provider.CreateVideoSource(provider.LoadConfiguration(reader));


            return VsProviderManagerDic[camId];
        }

        private void sendStreamMjpegFromProvider(VsProviderManager providerManager, NetworkStream ns, int SendBufferSize, int framRate, Size videoSize, int videoQuality)
        {
            //
            //     BlockingQueue<VsImage> BQueue = new BlockingQueue<VsImage>();

            //    // coreProvider.FrameOut += new VsImageEventHandler(coreProvider_FrameOut);
            //     coreProvider.FrameOut += new VsImageEventHandler (
            //        (object sender, VsImageEventArgs e) =>
            //    {

            //        if (BQueue != null)
            //        {
            //            VsImage img = (VsImage)e.Image.Clone();
            //            BQueue.Enqueue(img);
            //        }

            //    });


            //    coreProvider.Start();
            try
            {
                DateTime start;
                TimeSpan span;

                int frameInterval = 1000 / framRate;

                #region setImageEncoder
                // Get a bitmap.
                // Bitmap bmp1 = new Bitmap(@"c:\TestPhoto.jpg");

                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID
                // for the Quality parameter category.
                System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters();

                // Save the bitmap as a JPG file with zero quality level compression.
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)videoQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                #endregion

                MemoryStream stream;
                Bitmap bmp;
                //double i = 0;
                while (true)
                {
                    stream = new MemoryStream();
                    start = DateTime.Now;

                    VsImage image = providerManager.getResultImage();

                    bmp = new Bitmap(image.Image, videoSize);

                    //Form1.bmp = new Bitmap(bmp);
                    //bmp.SetResolution(videoSize.Width, videoSize.Height);

                    bmp.Save(stream, jgpEncoder, myEncoderParameters);
                    sendMjpegHead(ns, stream.Length);
                    //bmp.Save(ns, jgpEncoder, myEncoderParameters);
                    //Bitmap.FromStream(stream).Save(ns,ImageFormat.Jpeg);

                    sendStream(ns, SendBufferSize, stream);

                    byte[] bHeadersString = Encoding.ASCII.GetBytes("\r\n");
                    // Send headers	
                    ns.Write(bHeadersString, 0, bHeadersString.Length);

                    stream.Close();

                    // ;
                    // i += 1.0 / framRate;
                    //if (i > fe.streamLength)
                    //{
                    //    break;
                    //}


                    span = DateTime.Now.Subtract(start);
                    // miliseconds to sleep
                    int msec = frameInterval - (int)span.TotalMilliseconds;

                    while (msec > 0)
                    {
                        // sleeping ...
                        Thread.Sleep((msec < 100) ? msec : 100);
                        msec -= 100;
                        //span = DateTime.Now.Subtract(start);
                        //msec = frameInterval - (int)span.TotalMilliseconds;
                    }
                }
            }
            finally
            {

                //coreProvider.FrameOut -= new VsImageEventHandler(framedOut);
                //coreProvider.Stop();
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public void sendMjpegHead(NetworkStream ns, long length)
        {
            string HeadersString;//= "--myboundary\r\nContent-Type: image/jpeg\r\nContent-Length: " + length + "\r\n\r\n";
            HeadersString = "--myboundary\r\n";
            HeadersString += "Content-Type: image/jpeg\r\n";
            HeadersString += "Content-Length: " + length + "\r\n";

            HeadersString += "\r\n";
            byte[] bHeadersString = Encoding.ASCII.GetBytes(HeadersString);

            // Send headers	
            ns.Write(bHeadersString, 0, bHeadersString.Length);

            //sendStream(ns, SendBufferSize, st);
        }

        //public void sendMjpeg(NetworkStream ns, int SendBufferSize, Stream st, long length)
        //{
        //    string HeadersString;
        //    HeadersString = "\n--myboundary\n";
        //    HeadersString += "Content-Type: image/jpeg\n";
        //    HeadersString += "Content-length: " + length + "\n";

        //    HeadersString += "\n";
        //    byte[] bHeadersString = Encoding.ASCII.GetBytes(HeadersString);

        //    // Send headers	
        //    ns.Write(bHeadersString, 0, bHeadersString.Length);

        //    sendStream(ns, SendBufferSize, st);
        //}

        public void sendStream(NetworkStream ns, int SendBufferSize, Stream st)
        {
            if (st != null)
                using (st)
                {
                    // if (command.streamType == StreamType.File)
                    {
                        byte[] b = new byte[SendBufferSize];
                        int bytesRead;
                        long bytecount = 0;

                        try
                        {
                            while ((bytesRead = st.Read(b, 0, b.Length)) > 0)
                            {
                                ns.Write(b, 0, bytesRead);
                                bytecount += bytesRead;
                                HttpServer.output = "progress: " + ((bytecount * 100) / st.Length) + "%";
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            st.Close();
                        }
                    }
                }
        }
        public void sendStream(NetworkStream ns, int SendBufferSize, MemoryStream st)
        {
            if (st != null)
                using (st)
                {
                    // if (command.streamType == StreamType.File)
                    {
                        byte[] b = st.ToArray();
                        int numRead = SendBufferSize / b.Length;
                        int bytesRead = SendBufferSize;

                        if (SendBufferSize > b.Length)
                        {
                            bytesRead = b.Length;
                        }
                        int bytecount = 0;

                        try
                        {
                            while (bytecount < b.Length)
                            {
                                if (bytecount + bytesRead > b.Length)
                                    bytesRead = b.Length - bytecount;
                                ns.Write(b, bytecount, bytesRead);
                                bytecount += bytesRead;
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            GC.Collect();
                            st.Close();

                        }
                    }
                }
        }

        public static MemoryStream LoadMemoryStreamFromFile(string fileName)
        {
            MemoryStream ms = null;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open,
            FileAccess.Read))
            {
                byte[] fil;
                fil = new byte[fileStream.Length];
                fileStream.Read(fil, 0, fil.Length);
                fileStream.Close();
                ms = new MemoryStream(fil);
            }
            GC.Collect();
            return ms;
        }
        public static MemoryStream LoadMemoryStreamFromFile(FileStream fs)
        {
            MemoryStream ms = null;
            using (FileStream fileStream = fs)
            {
                byte[] fil;
                fil = new byte[fileStream.Length];
                fileStream.Read(fil, 0, fil.Length);
                fileStream.Close();
                ms = new MemoryStream(fil);
            }
            GC.Collect();
            return ms;
        }

        //#region Run the process
        //private string RunProcess(string Parameters)
        //{
        //    //create a process info
        //    ProcessStartInfo oInfo = new ProcessStartInfo(this._ffExe, Parameters);
        //    oInfo.UseShellExecute = false;
        //    oInfo.CreateNoWindow = true;
        //    oInfo.RedirectStandardOutput = true;
        //    oInfo.RedirectStandardError = true;

        //    //Create the output and streamreader to get the output
        //    string output = null; StreamReader srOutput = null;

        //    //try the process
        //    try
        //    {
        //        //run the process
        //        Process proc = System.Diagnostics.Process.Start(oInfo);

        //        proc.WaitForExit();

        //        //get the output
        //        srOutput = proc.StandardError;

        //        //now put it in a string
        //        output = srOutput.ReadToEnd();

        //        proc.Close();
        //    }
        //    catch (Exception)
        //    {
        //        output = string.Empty;
        //    }
        //    finally
        //    {
        //        //now, if we succeded, close out the streamreader
        //        if (srOutput != null)
        //        {
        //            srOutput.Close();
        //            srOutput.Dispose();
        //        }
        //    }
        //    return output;
        //}
        //#endregion

        public override void OnResponse(ref HTTPRequestStruct rq, ref HTTPResponseStruct rp)
        {
            throw new NotImplementedException();
        }
    }

}
