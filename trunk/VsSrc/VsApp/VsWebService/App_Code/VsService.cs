// wcwi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yrav	
// pzxx	 By downloading, copying, installing or using the software you agree to this license.
// zjro	 If you do not agree to this license, do not download, install,
// uyhp	 copy or use the software.
// ijgx	
// vfog	                          License Agreement
// dyij	         For OpenVSS - Open Source Video Surveillance System
// fkvf	
// wshj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zxwu	
// wlos	Third party copyrights are property of their respective owners.
// xlps	
// kgwm	Redistribution and use in source and binary forms, with or without modification,
// vyms	are permitted provided that the following conditions are met:
// ctsq	
// rnso	  * Redistribution's of source code must retain the above copyright notice,
// nlsb	    this list of conditions and the following disclaimer.
// qyqk	
// nmbk	  * Redistribution's in binary form must reproduce the above copyright notice,
// qwis	    this list of conditions and the following disclaimer in the documentation
// ipyy	    and/or other materials provided with the distribution.
// ojkx	
// fpgg	  * Neither the name of the copyright holders nor the names of its contributors 
// fgdi	    may not be used to endorse or promote products derived from this software 
// tael	    without specific prior written permission.
// tocm	
// qlzj	This software is provided by the copyright holders and contributors "as is" and
// xcbg	any express or implied warranties, including, but not limited to, the implied
// kzic	warranties of merchantability and fitness for a particular purpose are disclaimed.
// otze	In no event shall the Prince of Songkla University or contributors be liable 
// buvb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// skfh	(including, but not limited to, procurement of substitute goods or services;
// jsrq	loss of use, data, or profits; or business interruption) however caused
// rxzu	and on any theory of liability, whether in contract, strict liability,
// mmid	or tort (including negligence or otherwise) arising in any way out of
// jaad	the use of this software, even if advised of the possibility of such damage.
// nzvf	
// xbtz	Intelligent Systems Laboratory (iSys Lab)
// azky	Faculty of Engineering, Prince of Songkla University, THAILAND
// sbug	Project leader by Nikom SUVONVORN
// fsze	Project website at http://code.google.com/p/openvss/

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.IO;

[WebService(Namespace = "http://www.vsa-srv.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class VsService : System.Web.Services.WebService
{

    VsIDbConnect DBconn;

    public VsService()
    {

        //Uncomment the following line if using designed components 
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        WebConfigData config = new WebConfigData();
        config.LoadSettings(Server.MapPath("config\\VsWebServiceApp.config"));

        DBconn = new VsDbMysqlConnect(config.data["HostIP"], config.data["ConnectionString"]);
    }
    #region//------------------------------------------------------Testing Method-----------------------------------------------

    public static List<VsFileURL> list = new List<VsFileURL>();

    [WebMethod]
    public void add(string name, string url)
    {
        VsFileURL files = new VsFileURL();
        files.FilesName = name;
        files.FilesURL = url;
        list.Add(files);
    }

    private string urlEncode(string s)
    {
        return HttpUtility.UrlEncode(s);
    }
    [WebMethod]
    public List<VsFileURL> showFiles()
    {
        List<VsFileURL> l = new List<VsFileURL>();

        //l.Add(new VsFileURL("Ronfaure (FF XI).avi", "ftp://172.30.133.143/04%20Ronfaure%20(FF%20XI).avi"));
        //l.Add(new VsFileURL("Theme of Love (FF IV).avi", "ftp://172.30.133.143/10%20Theme%20of%20Love%20(FF%20IV).avi"));
        //return new VsDbConnect().getFiles();
        //return new VsDbConnect().getFiles();
        return l;
    }
    [WebMethod]
    public List<string> showTables()
    {
        return new VsDbConnect().getFiles();
    }
    [WebMethod]
    public VsFileURL show()
    {
        return list[0];
    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    #endregion

    #region//--------------------------------------------------------VsService Method--------------------------------------------------------
    //ﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂﬂ

    //§◊π§Ë“object°≈ÈÕß∑ÿ°µ—«∑’Ë„ÀÈ∫√‘°“√Õ¬ŸË
    [WebMethod]
    public List<VsCamera> getCamAll()
    {
        string configPath = Path.Combine(Environment.GetEnvironmentVariable("VsPath", EnvironmentVariableTarget.Machine), "cameras.config");

        CamConfigData[] camDatas = CamConfigData.LoadSettings(configPath);
        List<VsCamera> camList = new List<VsCamera>();

        foreach (CamConfigData camData in camDatas)
        {
            VsCamera c = new VsCamera();
            c.cameraID = camData.name;
            c.location = camData.name;
            camList.Add(c);
        }

        return camList;
        // return DBconn.getCamAll();
    }

    //§◊π§Ë“°≈ÈÕß∑’Ë¡’motion„π™Ë«ß‡«≈“∑’Ë°”Àπ¥
    [WebMethod]
    public List<VsCamera> getCamHasMotion(DateTime timeBegin, DateTime timeEnd)
    {
        return DBconn.getCamHasMotion(timeBegin, timeEnd);
    }

    //§◊Õ§Ë“ ∂“π–°“√¡’motion¢Õß°≈ÈÕß„π™Ë«ß‡«≈“∑’Ë°”Àπ¥
    [WebMethod]
    public bool isCamHasMotion(string cameraID, DateTime timeBegin, DateTime timeEnd)
    {
        return DBconn.isCamHasMotion(cameraID, timeBegin, timeEnd);
    }

    //------------------------------------------------------------------------------------------------------------------

    [WebMethod]
    public List<VsMotion> getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return DBconn.getMotionOfCamAsPeriod(timeBegin, timeEnd, cameraID);
    }

    [WebMethod]
    public List<VsMotion> getMotionOfAllAsPeriod(DateTime timeBegin, DateTime timeEnd)
    {
        return DBconn.getMotionOfAllAsPeriod(timeBegin, timeEnd);
    }

    [WebMethod]
    public List<VsMotion> getMotionOfCamAsDay(string cameraID)
    {
        return DBconn.getMotionOfCamAsDay(cameraID);
    }

    [WebMethod]
    public List<VsMotion> getMotionOfCamAsHour(string cameraID)
    {
        return DBconn.getMotionOfCamAsHour(cameraID);
    }

    [WebMethod]
    public VsMotion getMotionOfCamAsLast(string cameraID)
    {
        return DBconn.getMotionOfCamAsLast(cameraID);
    }

    [WebMethod]
    public DateTime getTimeOfLastMotion(string cameraId)
    {
        return DBconn.getTimeOfLastMotion(cameraId);
    }

    //-------------------------------------------------------------------------------------------------------------------

    [WebMethod]
    public VsFileURL getFileUrlOfMotion(string motionID, DateTime motionDateTime)
    {
        return DBconn.getFileUrlOfMotion(motionID, motionDateTime);
    }
    //-------------------------------------------------------------------------------------------------------------------

    [WebMethod]
    public int getNumberOfMotion(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {

        return DBconn.getNumberOfMotion(timeBegin, timeEnd, cameraID);
    }
    [WebMethod]
    public List<int> getNumberOfMotionInDay(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return DBconn.getNumberOfMotionInDay(timeBegin, timeEnd, cameraID);

    }
    [WebMethod]
    public List<int> getNumberOfMotionInMonth(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return DBconn.getNumberOfMotionInMonth(timeBegin, timeEnd, cameraID);
    }
    [WebMethod]
    public List<int> getNumberOfMotionInYear(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return DBconn.getNumberOfMotionInYear(timeBegin, timeEnd, cameraID);
    }
    #endregion //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$




    #region ---------------------------- New Method ----------------------------------------------
    [WebMethod]
    public string getCamConfigToString()
    {
        string configPath = Path.Combine(Environment.GetEnvironmentVariable("VsPath", EnvironmentVariableTarget.Machine), "cameras.config");

        //FileStream fs = null;
        //StreamReader sr = null;

        //// open file
        //fs = new FileStream(vsSettingsFile, FileMode.Open, FileAccess.Read);

        //sr = new StreamReader(fs);

        //byte[] myByteArray =  getCamConfigToByte();

        //System.Text.Encoding enc = System.Text.Encoding.UTF8;
        //string myString = enc.GetString(myByteArray);

       string text = System.IO.File.ReadAllText(configPath);

       return text;

    }
    [WebMethod]
    public byte[] getCamConfigToByte()
    {

        string configPath = Path.Combine(Environment.GetEnvironmentVariable("VsPath", EnvironmentVariableTarget.Machine), "cameras.config");

        byte[] buffer;
        FileStream fileStream = new FileStream(configPath, FileMode.Open, FileAccess.Read);
        try
        {
            int length = (int)fileStream.Length;  // get file length
            buffer = new byte[length];            // create buffer
            int count;                            // actual number of bytes read
            int sum = 0;                          // total number of bytes read

            // read until Read method returns 0 (end of the stream has been reached)
            while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                sum += count;  // sum is a buffer offset for next reading
        }
        finally
        {
            fileStream.Close();
        }
        return buffer;
    }

    #endregion
    [WebMethod]
    public string getMyHost()
    {
        string myhost = System.Net.Dns.GetHostName();//¥Ÿ™◊ËÕ‡§√◊ËÕß¢Õß‡√“ºË“π§≈“  Dns 

        System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(myhost);//°”Àπ¥ Ip¢Õß‡§√◊ËÕß∑’Ë¡’™◊ËÕ‡¥’Ë¬«°—∫ myhost

        foreach (System.Net.IPAddress a in ip.AddressList)
        {
            myhost += ":" + a.ToString();
        }
        return myhost;

    }

    public string getHostIP()
    {
        string myhost = System.Net.Dns.GetHostName();//¥Ÿ™◊ËÕ‡§√◊ËÕß¢Õß‡√“ºË“π§≈“  Dns 

        System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(myhost);//°”Àπ¥ Ip¢Õß‡§√◊ËÕß∑’Ë¡’™◊ËÕ‡¥’Ë¬«°—∫ myhost

        foreach (System.Net.IPAddress a in ip.AddressList)
        {
            return a.ToString();
        }
        return "null";
    }

    [WebMethod]
    public string getConfig()
    {

        WebConfigData config = new WebConfigData();
        config.LoadSettings(Server.MapPath("config\\VsWebServiceApp.config"));

        return config.data["HostIP"] + config.data["ConnectionString"];


    }
}
