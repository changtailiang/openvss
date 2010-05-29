// wzyq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oguj	
// kkke	 By downloading, copying, installing or using the software you agree to this license.
// gjhq	 If you do not agree to this license, do not download, install,
// nylo	 copy or use the software.
// gtgv	
// elcd	                          License Agreement
// ndde	         For OpenVSS - Open Source Video Surveillance System
// yqri	
// epoh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// oqjt	
// cmag	Third party copyrights are property of their respective owners.
// naxn	
// fbbd	Redistribution and use in source and binary forms, with or without modification,
// scmd	are permitted provided that the following conditions are met:
// eqvg	
// hgfp	  * Redistribution's of source code must retain the above copyright notice,
// rymy	    this list of conditions and the following disclaimer.
// jdap	
// knts	  * Redistribution's in binary form must reproduce the above copyright notice,
// kvqn	    this list of conditions and the following disclaimer in the documentation
// gpyw	    and/or other materials provided with the distribution.
// oopb	
// dldx	  * Neither the name of the copyright holders nor the names of its contributors 
// vclw	    may not be used to endorse or promote products derived from this software 
// gkpo	    without specific prior written permission.
// oyeb	
// bmtf	This software is provided by the copyright holders and contributors "as is" and
// itsi	any express or implied warranties, including, but not limited to, the implied
// ziar	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hibc	In no event shall the Prince of Songkla University or contributors be liable 
// ikvx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// acuh	(including, but not limited to, procurement of substitute goods or services;
// bxla	loss of use, data, or profits; or business interruption) however caused
// fczh	and on any theory of liability, whether in contract, strict liability,
// lwvc	or tort (including negligence or otherwise) arising in any way out of
// vksj	the use of this software, even if advised of the possibility of such damage.
// tuym	
// btpx	Intelligent Systems Laboratory (iSys Lab)
// imfd	Faculty of Engineering, Prince of Songkla University, THAILAND
// dgby	Project leader by Nikom SUVONVORN
// rldl	Project website at http://code.google.com/p/openvss/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using VsCoreMobile.VsService;
using System.Threading;
using System.Net;
using System.IO;
using System.Drawing;
using System.Windows.Forms;



namespace VsCoreMobile
{
    public class VsMobileWireless : VsInterface
    {

        public VsService.VsService service;
        public VsCamera[] camList;
   
        public int bufSize = 512 * 1024;	// buffer size
        public int readSize = 1024;		// portion size to read
        public int bytesReceived;

        public int height = 240;
        public int width = 180;
        public int quanlity = 100;
        public int fps = 25;
        public Thread thread1 = null;

        public List<string> x;

        public int framesReceived;
       
        //public ASCIIEncoding encoding;
        public string user, pass , proxy;
        public bool login;
        public void VsMWlogin()
        {

            //Session["UserName"] = Login1.UserName;
            //Session["Pass"] = Login1.Password;

            //if ("coe".Equals(Session["UserName"]) && "coe".Equals(Session["Pass"]))
            //{
            //  setA(true);
            // Login1.Visible = false;
            //   MultiView1.ActiveViewIndex = 1;

            //if (Session["VsServiceURL"] == null)
            //{
            //    //Session["VsServiceURL"] = string.Format("{0}/vsservice/service.asmx", getHostIP());
            //    Session["VsServiceURL"] = "http://172.30.0.48/vsservice/service.asmx";
            //}
            //  Label3.Text = "VsServer URL:" + Session["VsServiceURL"].ToString();
            // TextBox1.Text = Session["VsServiceURL"].ToString();

            //   Panel1.Visible = true;

            //   Label2.Text = "??????????????????? VS Web Application";

            //   Response.Redirect("VsLive.aspx");
            //}
            // else
            // {
            //     MultiView1.ActiveViewIndex = 0;
            //     Label2.Text = "????? Login ????????????????";
            //     setA(false);
            // }
            service = new VsService.VsService();
            if ("coe".Equals(user) && "coe".Equals(pass))
                login = true;
            else
                login = false;
           
        }

        public void getCameraList()
        {
          
            camList = service.getCamAll();
        }
        public string IP;
        string URL;
        public string type;

        public void VsMWgenURL()
        {
            if(type == "LMjpg")
                URL = "http://"+proxy+":8080/vs-live/mjpg/" + IP + "?size=" + height + "x" + width + "&quanlity=" + quanlity + "&fps=" + fps;
            if (type == "Ljpg")
               URL = "http://" + IP + "/axis-cgi/jpg/image.cgi";
            if (type == "PBMjpeg")
            {
                //URL = "http://172.30.142.128:8080/vs-live/mjpg/camera-210-01.coe.psu.ac.th?size="+size+"&quanlity="+quanlity+"&fps="+fps;
                URL = url.FilesURL;//+"?size="+size+"&quanlity="+quanlity+"&fps="+fps;
               // URL = "http://172.30.142.128:8080/vs-file/mjpg/data/42.wmv?size="+size+"&quanlity="+quanlity+"&fps="+fps;
            }
        }

            public class ByteArrayUtils
            {
                // Check if the array contains needle on specified position
                public static bool Compare(byte[] array, byte[] needle, int startIndex)
                {
                    int needleLen = needle.Length;
                    // compare
                    for (int i = 0, p = startIndex; i < needleLen; i++, p++)
                    {
                        if (array[p] != needle[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }

                // Find subarray in array
                public static int Find(byte[] array, byte[] needle, int startIndex, int count)
                {
                    int needleLen = needle.Length;
                    int index;

                    while (count >= needleLen)
                    {
                        index = Array.IndexOf(array, needle[0], startIndex, count - needleLen + 1);

                        if (index == -1)
                            return -1;

                        int i, p;
                        // check for needle
                        for (i = 0, p = index; i < needleLen; i++, p++)
                        {
                            if (array[p] != needle[i])
                            {
                                break;
                            }
                        }

                        if (i == needleLen)
                        {
                            // found needle
                            return index;
                        }

                        count -= (index - startIndex + 1);
                        startIndex = index + 1;
                    }
                    return -1;
                }

            }
            public void LiveJpeg()
            {
                
                HttpWebRequest req = null;
                WebResponse resp = null;
                byte[] buffer = new byte[bufSize];

                int read, total = 0;
                Stream stream = null;

               VsMWgenURL();
                req = (HttpWebRequest)WebRequest.Create(URL); 
                //req = (HttpWebRequest)WebRequest.Create("http://" + IP + "/axis-cgi/jpg/image.cgi");

                //req = (HttpWebRequest)WebRequest.Create("http://rookery2.viary.com/storagev12/664500/664539_5299_625x625.jpg");


                // MessageBox.Show("0k");
                resp = req.GetResponse();
                stream = resp.GetResponseStream();

                //thread1.Abort();
                while (true)
                {
                    // check total read
                    if (total > bufSize - readSize)
                    {
                        total = 0;
                    }

                    // read next portion from stream
                    if ((read = stream.Read(buffer, total, readSize)) == 0)
                        break;

                    total += read;

                    // increment received bytes counter
                    bytesReceived += read;
                }

                bmap= new Bitmap(new MemoryStream(buffer, 0, total));

                stream.Close();
                resp.Close();


            }
            public void Live()
            {
                if (thread1 != null)
                {
                    // signal to stop
                    thread1.Abort();
                }

                //thread1 = null;
                thread1 = new Thread(new ThreadStart(WorkerThread));
                
                thread1.Start();
                
            }
        public Bitmap bmap;
        public void WorkerThread()
        {
                byte[] buffer = new byte[bufSize];	// buffer to read stream

                while (true)
                {
                    // reset reload event
                    //      reloadEvent.Reset();

                    HttpWebRequest req = null;
                    WebResponse resp = null;
                    Stream stream = null;
                    byte[] delimiter = null;
                    byte[] delimiter2 = null;
                    byte[] boundary = null;
                    int boundaryLen, delimiterLen = 0, delimiter2Len = 0;
                    int read, todo = 0, total = 0, pos = 0, align = 1;
                    int start = 0, stop = 0;

                    // align
                    //  1 = searching for image start
                    //  2 = searching for image end
                    try
                    {
                        // create request
                        VsMWgenURL();
                        req = (HttpWebRequest)WebRequest.Create(URL);
                        //req = (HttpWebRequest)WebRequest.Create("http://" + IP + "/axis-cgi/mjpg/video.cgi");
                        // req = (HttpWebRequest)WebRequest.Create("http://172.30.142.128:8080" + "/vs-file/mjpg/data/star.avi");
                       
                        resp = req.GetResponse();

                        // check content type
                        string ct = resp.ContentType;
                        if (ct.IndexOf("multipart/x-mixed-replace") == -1)
                            throw new ApplicationException("Invalid URL");

                        // get boundary
                        ASCIIEncoding encoding = new ASCIIEncoding();
                        boundary = encoding.GetBytes(ct.Substring(ct.IndexOf("boundary=", 0) + 9));
                        boundaryLen = boundary.Length;

                        // get response stream
                        stream = resp.GetResponseStream();

                        // loop
                        while (true)
                        {
                            // check total read
                            if (total > bufSize - readSize)
                            {
                                total = pos = todo = 0;
                            }

                            // read next portion from stream
                            if ((read = stream.Read(buffer, total, readSize)) == 0)
                                throw new ApplicationException();

                            string s = Encoding.ASCII.GetString(buffer, 0, read);

                            //MessageBox.Show(s);

                            total += read;
                            todo += read;

                            // increment received bytes counter
                            bytesReceived += read;

                            // does we know the delimiter ?
                            if (delimiter == null)
                            {
                                // find boundary
                                pos = VsCoreMobile.VsMobileWireless.ByteArrayUtils.Find(buffer, boundary, pos, todo);

                                if (pos == -1)
                                {
                                    // was not found
                                    todo = boundaryLen - 1;
                                    pos = total - todo;
                                    continue;
                                }

                                todo = total - pos;

                                if (todo < 2)
                                    continue;

                                // check new line delimiter type
                                if (buffer[pos + boundaryLen] == 10)
                                {
                                    delimiterLen = 2;
                                    delimiter = new byte[2] { 10, 10 };
                                    delimiter2Len = 1;
                                    delimiter2 = new byte[1] { 10 };
                                }
                                else
                                {
                                    delimiterLen = 4;
                                    delimiter = new byte[4] { 13, 10, 13, 10 };
                                    delimiter2Len = 2;
                                    delimiter2 = new byte[2] { 13, 10 };
                                }

                                pos += boundaryLen + delimiter2Len;
                                todo = total - pos;
                            }

                            // search for image
                            if (align == 1)
                            {
                                start = VsCoreMobile.VsMobileWireless.ByteArrayUtils.Find(buffer, delimiter, pos, todo);
                                if (start != -1)
                                {
                                    // found delimiter
                                    start += delimiterLen;
                                    pos = start;
                                    todo = total - pos;
                                    align = 2;
                                }
                                else
                                {
                                    // delimiter not found
                                    todo = delimiterLen - 1;
                                    pos = total - todo;
                                }
                            }

                            // search for image end
                            while ((align == 2) && (todo >= boundaryLen))
                            {
                                stop = VsCoreMobile.VsMobileWireless.ByteArrayUtils.Find(buffer, boundary, pos, todo);
                                if (stop != -1)
                                {
                                    pos = stop;
                                    todo = total - pos;

                                    // increment frames counter
                                    framesReceived++;

                                    // image at stop
                                    // if (FrameOut != null)
                                    {
                                        Bitmap bmp = new Bitmap(new MemoryStream(buffer, start, stop - start));
                                        // VsImage img = new VsImage(bmp);

                                        bmap = bmp;
                                        // notify client
                                        //  FrameOut(this, new VsImageEventArgs(img));
                                        // release the image
                                        // img.Dispose();
                                        //img = null;
                                    }

                                    // shift array
                                    pos = stop + boundaryLen;
                                    todo = total - pos;
                                    Array.Copy(buffer, pos, buffer, 0, todo);

                                    total = todo;
                                    pos = 0;
                                    align = 1;
                                }
                                else
                                {
                                    // delimiter not found
                                    todo = boundaryLen - 1;
                                    pos = total - todo;
                                }
                            }
                        }
                    }


                    catch (WebException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                        // wait for a while before the next try
                        Thread.Sleep(250);
                    }
                    catch (ApplicationException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                        // wait for a while before the next try
                        Thread.Sleep(250);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
                    }
                    finally
                    {
                        // abort request
                        if (req != null)
                        {
                            req.Abort();
                            req = null;
                        }
                        // close response stream
                        if (stream != null)
                        {
                            stream.Close();
                            stream = null;
                        }
                        // close response
                        if (resp != null)
                        {
                            resp.Close();
                            resp = null;
                        }
                    }
                }
            }

        List<int> camSelect = new List<int>();
       // ListBox listSelectedCameras;
        public ComboBox listCameras;

        VsMotion[] motionList;
        List<VsMotion> motions = new List<VsMotion>();

        public DateTime timeBegin;
        public DateTime timeEnd;

        VsCoreEngine engine;

        public VsMobileWireless()
        {

            engine = new VsCoreEngine(new VsServiceConnect());
        }

        public void setAllCam(VsCamera[] camLit)
        {
            try
            {
                if (camList != null)
                {
                    this.camList = camLit;

                   // listCameras.Items.Clear();
                    foreach (VsCamera c in camList)
                    {
                        listCameras.Items.Add("" + c.location);
                    }
                }

               // setVsTimeLine();
            }
            catch (Exception err)
            {
            //    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTraiuce); ;
            }
        }
     
        public ListBox listSelectedCameras;
        public void camSelected()
        {
            
            try
            {


            }
            catch (Exception err)
            {
             //////   logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
       
        public List<string> getMotionEvent(int camID, DateTime timeBegin, DateTime timeEnd)
        {
            List<string> listEvents = new List<string>();
            try
            {
                motions.Clear();

                motionList = engine.getMotionOfCamAsPeriod(timeBegin, timeEnd, camList[camID].cameraID.ToString());

                foreach (VsMotion m in motionList)
                {
                    listEvents.Add(m.timeBegin.ToString());
                }

                motions.AddRange(motionList);


            }
            catch (Exception err)
            {
           //     logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return listEvents;
        }

        public int selectedIndex;

        VsFileURL url;
        public void motionSelected()
        {
            try
            {

                int index = selectedIndex;
                VsMotion m = motions[index];
                url = service.getMjpegProxyUrlOfMotionParameter(m.MotionID.ToString(), m.timeBegin, height, width,fps,quanlity);
               
                Live();
            //    textBox3.Text = "" + m.timeBegin + " To " + m.timeEnd;
            //    vlCplayer1.playFileUrl(url.FilesURL);
            }
            catch (Exception err)
            {
                //logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
    }
}


