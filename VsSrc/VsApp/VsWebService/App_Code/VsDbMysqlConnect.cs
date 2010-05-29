// uqhp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dhtd	
// nubu	 By downloading, copying, installing or using the software you agree to this license.
// hkmx	 If you do not agree to this license, do not download, install,
// swrh	 copy or use the software.
// gbab	
// suxa	                          License Agreement
// gqgg	         For OpenVSS - Open Source Video Surveillance System
// kmto	
// cehi	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bkqr	
// agdb	Third party copyrights are property of their respective owners.
// wozr	
// zods	Redistribution and use in source and binary forms, with or without modification,
// pgxi	are permitted provided that the following conditions are met:
// jtxw	
// nuju	  * Redistribution's of source code must retain the above copyright notice,
// qyvn	    this list of conditions and the following disclaimer.
// ojgv	
// ljal	  * Redistribution's in binary form must reproduce the above copyright notice,
// qwds	    this list of conditions and the following disclaimer in the documentation
// qpgw	    and/or other materials provided with the distribution.
// jbzv	
// hyyi	  * Neither the name of the copyright holders nor the names of its contributors 
// ntdf	    may not be used to endorse or promote products derived from this software 
// wiky	    without specific prior written permission.
// tmdq	
// ihgg	This software is provided by the copyright holders and contributors "as is" and
// glrn	any express or implied warranties, including, but not limited to, the implied
// pefy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nnlp	In no event shall the Prince of Songkla University or contributors be liable 
// zzgp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lxhs	(including, but not limited to, procurement of substitute goods or services;
// fuoi	loss of use, data, or profits; or business interruption) however caused
// lfye	and on any theory of liability, whether in contract, strict liability,
// lqob	or tort (including negligence or otherwise) arising in any way out of
// utpv	the use of this software, even if advised of the possibility of such damage.
// gkti	
// nfsj	Intelligent Systems Laboratory (iSys Lab)
// wuzu	Faculty of Engineering, Prince of Songkla University, THAILAND
// foek	Project leader by Nikom SUVONVORN
// zoam	Project website at http://code.google.com/p/openvss/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using VsTableNameManage;

/// <summary>
/// Summary description for VsDbMysqlConnect
/// </summary>
public class VsDbMysqlConnect : VsIDbConnect
{
    string hostIP = "172.30.3.51";
    string ConnString = "server=localhost;user id=root; password=l0o=0-85; database=vsa-main; pooling=false";
   
    public VsDbMysqlConnect(string hostip, string constr)
    {

        this.hostIP = hostip;
        this.ConnString = constr;

    }

    private MySqlConnection connecting(string connString)
    {
        MySqlConnection conn = null;
        try
        {
            conn = new MySqlConnection("");
            conn.ConnectionString = connString;
            conn.Open();
        }
        catch //(MySqlException ex)
        {
            //MessageBox.Show("Error connecting to the server: " + ex.Message);
        }
        return conn;
    }

    //ไม่ใช้แล้ว
    private List<VsCamera> getAllCam()
    {
        //MySqlConnection conn = this.connecting(ConnString);
        //MySqlCommand comm = conn.CreateCommand();
        //comm.CommandText = String.Format("SELECT `camera`.`CameraID`,`camera`.`Location` FROM `camera`");
        //MySqlDataReader aReader = comm.ExecuteReader();

        //List<VsCamera> camList = new List<VsCamera>();

        //while (aReader.Read())
        //{
        //    VsCamera c = new VsCamera();
        //    c.cameraID = aReader[0].ToString();
        //    c.location = aReader["Location"].ToString();
        //    camList.Add(c);
        //}

        //conn.Close();

        return null;
    }

    public string tConv(DateTime DT)
    {
        //DateTime DT = DateTime.Parse(time);
        //string s = "" + DT.Year + "/" + DT.Month + "/" + DT.Day + " " + DT.Hour + ":" + DT.Minute + ":" + DT.Second;
        return DT.ToString("yyyy/M/d HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
    }

    private List<VsMotion> getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {

        List<VsMotion> motionList = new List<VsMotion>();
        string[] TableNames = VsTableName.getMonthTableName("data", timeBegin, timeEnd);

        foreach (string tableName in TableNames)
        {
            MySqlConnection conn = this.connecting(ConnString);
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = String.Format(
                "SELECT  `m_id` AS `MotionID`,  `m_ip_camera` AS `CameraID`,  `m_ip_processor` AS `Processor`,  `m_date_start` AS `TimeBegin`,  `m_date_end` AS `TimeEnd`,  `m_algo_name` AS `algoName`,  `m_detail` AS `detail` "
                 + " FROM  `{3}` "
                 + " where `m_date_start` >= '{0}'  And `m_date_start` <='{1}' And  `m_ip_camera` = '{2}'  ORDER BY   `m_date_start` ", 
                 tConv(timeBegin), tConv(timeEnd), cameraID, tableName);
            try
            {
                MySqlDataReader aReader = comm.ExecuteReader();

                while (aReader.Read())
                {
                    VsMotion m = new VsMotion();

                    m.MotionID = Int32.Parse(aReader["MotionID"].ToString());
                    m.cameraID = aReader["CameraID"].ToString();
                    m.processor = aReader["Processor"].ToString();
                    m.timeBegin = DateTime.Parse(aReader["TimeBegin"].ToString());
                    m.timeEnd = DateTime.Parse(aReader["TimeEnd"].ToString());

                    m.r_algo_name = aReader["algoName"].ToString();
                    m.r_detail = aReader["detail"].ToString();

                    motionList.Add(m);
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }
        return motionList;
    }

    private VsFileURL getFileUrlOfMotion(string motionID, DateTime motionDateTime)
    {
        string tableName = VsTableName.getMonthTableName("data", motionDateTime);

        MySqlConnection conn = this.connecting(ConnString);
        MySqlCommand comm = conn.CreateCommand();
        comm.CommandText = String.Format("SELECT   `m_file_name` , `m_date_start` FROM `{0}` WHERE   `m_id` = '{1}' ;", tableName, motionID);

        try
        {
            MySqlDataReader aReader = comm.ExecuteReader();

            string fileName = "";
            VsFileURL fUrl = new VsFileURL();
            while (aReader.Read())
            {
                fileName = aReader["m_file_name"].ToString();
                fUrl.FilesName = aReader["m_date_start"].ToString();
            }


            string ftpUser = "";
            string ftpPass = "";

            fUrl.FilesID = motionID;
            string s = fileName.Split(':')[1].Replace("\\", "/");
            fUrl.FilesURL = "http://" + ftpUser + ftpPass + hostIP + s;
            return fUrl;

        }
        catch { return null; }
        finally { conn.Close(); }


    }


    private int getNumberOfMotion(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        int number = 0;

        string[] TableNames = VsTableName.getMonthTableName("data", timeBegin, timeEnd);

        foreach (string tableName in TableNames)
        {
            MySqlConnection conn = this.connecting(ConnString);
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = String.Format(
                "SELECT   COUNT(*)  as quantity"
            +" FROM  `{3}` where `m_date_start` >= '{0}'  And `m_date_start` <='{1}' And  `m_ip_camera` = '{2}'  "
            + " ORDER BY  `m_date_start` ",
            tConv(timeBegin), tConv(timeEnd), cameraID, tableName);

            try
            {
                MySqlDataReader aReader = comm.ExecuteReader();

                if (aReader.Read())
                {
                    number += Int32.Parse(aReader["quantity"].ToString());
                }
            }
            catch { }
            finally { conn.Close(); }
        }
       
        return number;
    }


    private List<int> getNumberOfMotionInDay(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        List<int> valueList = new List<int>();

        int[] values = new int[24];

        string[] TableNames = VsTableName.getMonthTableName("data", timeBegin, timeEnd);

        foreach (string tableName in TableNames)
        {
            MySqlConnection conn = this.connecting(ConnString);
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = String.Format(
                "SELECT   Hour ( `m_date_start`)  as  hour ,   COUNT(*)  as quantity"
                + " FROM  `{3}` where `m_date_start` >= '{0}'  And `m_date_start` <='{1}' And  `m_ip_camera` = '{2}'  "
                  + " group by Hour (`m_date_start` )  ",
                   tConv(timeBegin), tConv(timeEnd), cameraID,tableName);

            try
            {
                MySqlDataReader aReader = comm.ExecuteReader();

                int number = 0;
                while (aReader.Read())
                {

                    number = Int32.Parse(aReader["quantity"].ToString());
                    values[Int32.Parse(aReader["hour"].ToString())] += number;
                }
            }
            catch { }
            finally {  conn.Close();}
        }

        valueList.AddRange(values);
       
        return valueList;
    }

    private List<int> getNumberOfMotionInMonth(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {

        List<int> valueList = new List<int>();

        int[] values = new int[31];

        string[] TableNames = VsTableName.getMonthTableName("data", timeBegin, timeEnd);

        foreach (string tableName in TableNames)
        {
            MySqlConnection conn = this.connecting(ConnString);
            MySqlCommand comm = conn.CreateCommand();
    //        comm.CommandText = String.Format(
    //            "SELECT   day ( `report`.`r_date_start`)  as  day ,   COUNT(*)  as quantity"
    //            + " FROM   `report`  Where `report`.`r_date_start` >= '{0}'  And `report`.`r_date_start` <='{1}' And  `report`.`r_ip_camera` = {2} "
    //+ " group by day(`report`.`r_date_start` )  ", tConv(timeBegin), tConv(timeEnd), cameraID);

            comm.CommandText = String.Format(
               "SELECT   day ( `m_date_start`)  as  day ,   COUNT(*)  as quantity"
               + " FROM  `{3}` where `m_date_start` >= '{0}'  And `m_date_start` <='{1}' And  `m_ip_camera` = '{2}'  "
                 + " group by day (`m_date_start` )  ",
                  tConv(timeBegin), tConv(timeEnd), cameraID, tableName);
            try
            {
                MySqlDataReader aReader = comm.ExecuteReader();

                int number = 0;
                while (aReader.Read())
                {

                    number = Int32.Parse(aReader["quantity"].ToString());
                    values[Int32.Parse(aReader["day"].ToString()) - 1] += number;
                }
            }
            catch { }
            finally {conn.Close(); }
        }
        valueList.AddRange(values);
        
        return valueList;
    }

    private List<int> getNumberOfMotionInYear(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {   
        List<int> valueList = new List<int>();
        int[] values = new int[12];
           
        string[] TableNames = VsTableName.getMonthTableName("data", timeBegin, timeEnd);

        foreach (string tableName in TableNames)
        {
            MySqlConnection conn = this.connecting(ConnString);
            MySqlCommand comm = conn.CreateCommand();
    //        comm.CommandText = String.Format(
    //            "SELECT   month ( `report`.`r_date_start`)  as  month ,   COUNT(*)  as quantity"
    //            + " FROM   `report`  Where `report`.`r_date_start` >= '{0}'  And `report`.`r_date_start` <='{1}' And  `report`.`r_ip_camera` = {2} "
    //+ " group by  month(`report`.`r_date_start` )  ", tConv(timeBegin), tConv(timeEnd), cameraID);

            comm.CommandText = String.Format(
             "SELECT   month ( `m_date_start`)  as  month ,   COUNT(*)  as quantity"
             + " FROM  `{3}` where `m_date_start` >= '{0}'  And `m_date_start` <='{1}' And  `m_ip_camera` = '{2}'  "
               + " group by month (`m_date_start` )  ",
                tConv(timeBegin), tConv(timeEnd), cameraID, tableName);
            try
            {
                MySqlDataReader aReader = comm.ExecuteReader();

                int number = 0;
                while (aReader.Read())
                {

                    number = Int32.Parse(aReader["quantity"].ToString());
                    values[Int32.Parse(aReader["month"].ToString()) - 1] += number;
                }
            }
            catch { }
            finally {conn.Close(); }
        }

        valueList.AddRange(values);
        
        return valueList;
    }

    #region VsIDbConnect Members

    //implemented
    List<VsCamera> VsIDbConnect.getCamAll()
    {
        return getAllCam();
    }

    List<VsCamera> VsIDbConnect.getCamHasMotion(DateTime timeBegin, DateTime timeEnd)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    bool VsIDbConnect.isCamHasMotion(string cameraID, DateTime timeBegin, DateTime timeEnd)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    //implemented
    List<VsMotion> VsIDbConnect.getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return getMotionOfCamAsPeriod(timeBegin, timeEnd, cameraID);
    }

    List<VsMotion> VsIDbConnect.getMotionOfAllAsPeriod(DateTime timeBegin, DateTime timeEnd)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    List<VsMotion> VsIDbConnect.getMotionOfCamAsDay(string cameraID)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    List<VsMotion> VsIDbConnect.getMotionOfCamAsHour(string cameraID)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    VsMotion VsIDbConnect.getMotionOfCamAsLast(string cameraID)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    DateTime VsIDbConnect.getTimeOfLastMotion(string cameraId)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    //implemented
    VsFileURL VsIDbConnect.getFileUrlOfMotion(string motionID, DateTime motionDateTime)
    {
        return getFileUrlOfMotion(motionID, motionDateTime);
    }

    #endregion

    #region VsIDbConnect Members

    //implemented
    int VsIDbConnect.getNumberOfMotion(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return getNumberOfMotion(timeBegin, timeEnd, cameraID);
    }
    //implemented
    List<int> VsIDbConnect.getNumberOfMotionInDay(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return getNumberOfMotionInDay(timeBegin, timeEnd, cameraID);
    }
    //implemented
    List<int> VsIDbConnect.getNumberOfMotionInMonth(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return getNumberOfMotionInMonth(timeBegin, timeEnd, cameraID);
    }
    //implemented
    List<int> VsIDbConnect.getNumberOfMotionInYear(DateTime timeBegin, DateTime timeEnd, string cameraID)
    {
        return getNumberOfMotionInYear(timeBegin, timeEnd, cameraID);
    }

    #endregion
}
