// dvsj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cwzk	
// bexf	 By downloading, copying, installing or using the software you agree to this license.
// ynhw	 If you do not agree to this license, do not download, install,
// crxf	 copy or use the software.
// tylf	
// wfpj	                          License Agreement
// pfft	         For OpenVSS - Open Source Video Surveillance System
// iaij	
// jzdj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pnes	
// dusd	Third party copyrights are property of their respective owners.
// booz	
// nbbe	Redistribution and use in source and binary forms, with or without modification,
// knnx	are permitted provided that the following conditions are met:
// gpuw	
// zexy	  * Redistribution's of source code must retain the above copyright notice,
// exnd	    this list of conditions and the following disclaimer.
// onpf	
// tsbb	  * Redistribution's in binary form must reproduce the above copyright notice,
// mmib	    this list of conditions and the following disclaimer in the documentation
// qgfg	    and/or other materials provided with the distribution.
// ydzw	
// mfda	  * Neither the name of the copyright holders nor the names of its contributors 
// sitz	    may not be used to endorse or promote products derived from this software 
// xuzd	    without specific prior written permission.
// blka	
// mvls	This software is provided by the copyright holders and contributors "as is" and
// llku	any express or implied warranties, including, but not limited to, the implied
// gtfs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yqza	In no event shall the Prince of Songkla University or contributors be liable 
// xrrj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jpml	(including, but not limited to, procurement of substitute goods or services;
// ycds	loss of use, data, or profits; or business interruption) however caused
// meaf	and on any theory of liability, whether in contract, strict liability,
// wftd	or tort (including negligence or otherwise) arising in any way out of
// sgka	the use of this software, even if advised of the possibility of such damage.
// uitz	
// cbah	Intelligent Systems Laboratory (iSys Lab)
// uygj	Faculty of Engineering, Prince of Songkla University, THAILAND
// tbqx	Project leader by Nikom SUVONVORN
// jatj	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using VsTableNameManage;

namespace Vs.Core.DbDelete
{
    class VsDbConnection
    {
        static private string mainDbConnStr;//= "server=localhost ;user id=root; password=; database=vsa-main; pooling=false; charset=utf8 ";
        static private string clientDbConnStr;//= "server=localhost ;user id=root; password=; database=vsa-client; pooling=false; charset=utf8 ";

        public VsDbConnection(string mainDbConnStr, string clientDbConnStr)
        {
            // this.mainDbConnStr = mainDbConnStr;
            // this.clientDbConnStr = clientDbConnStr;
        }


        public static void setConnectionString(string mainDbCStr, string clientDbConnStr)
        {
            VsDbConnection.mainDbConnStr = mainDbCStr;
            VsDbConnection.clientDbConnStr = clientDbConnStr;
        }

        //แปลงค่า string connection ให้เป็น connectionจริง
        public static MySqlConnection Connecting(string connString)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection("");
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in Connecting to " + clientDbConnStr + " " + ex.Message + " " + ex.StackTrace);
                
                throw ex;
                // logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return conn;
        }


        //ใช้ได้ทั้ง data และ event
        public static int deleteMainData(string tableName, DateTime TimeEnd)
        {
            MySqlConnection conn = null;
            try
            {
                string stringSQL = string.Format(
            "DELETE   from {0} where `m_date_start` < '{1}' ", tableName
                , TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

                conn = Connecting(mainDbConnStr);

                MySqlCommand command = new MySqlCommand(stringSQL, conn);

                // command.Parameters.AddWithValue("?tableName", tableName);
                //command.Parameters.AddWithValue("?TimeEnd", TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

                int val = command.ExecuteNonQuery();

                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("msg", "deleted from: " + tableName + " before: " + TimeEnd + " numDelete: " + val);
               
                return val;

            }
            catch (MySqlException ex)
            {
                if (conn != null)
                {
                    try
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    catch { }
                }


                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in delete " + tableName + "  before:" + TimeEnd + ex.Message + " " + ex.StackTrace);
               
                return 0;

            }

        }

        public static int deleteClientData(DateTime TimeEnd)
        {
            MySqlConnection conn = null;
            try
            {
                string stringSQL = string.Format(
            "DELETE   from report where `r_date_start` < '{0}' "
                , TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

                conn = Connecting(clientDbConnStr);

                MySqlCommand command = new MySqlCommand(stringSQL, conn);

                // command.Parameters.AddWithValue("?tableName", tableName);
                //command.Parameters.AddWithValue("?TimeEnd", TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

                int val = 0; ;

                val = command.ExecuteNonQuery();
                conn.Close();

                if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("msg", "deleted from: report before: " + TimeEnd + " numDelete: " + val);
                return val;

            }
            catch (MySqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }

                if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("ex", "in delete ClientData  before:" + TimeEnd + ex.Message + " " + ex.StackTrace);
              
                return 0;

            }

        }
        public static int deleteClientUpdateData(DateTime TimeEnd)
        {
            MySqlConnection conn = null;
            try
            {
                string stringSQL = string.Format(
            "DELETE   from `update` where `update_date_time` < '{0}' "
                , TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

                conn = Connecting(clientDbConnStr);

                MySqlCommand command = new MySqlCommand(stringSQL, conn);

                // command.Parameters.AddWithValue("?tableName", tableName);
                //command.Parameters.AddWithValue("?TimeEnd", TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

                int val = 0; ;

                val = command.ExecuteNonQuery();
                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("msg", "deleted from: `update`  before: " + TimeEnd + " numDelete: " + val);
                
                return val;

            }
            catch (MySqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in delete ClientUpdate  before:" + TimeEnd + ex.Message + " " + ex.StackTrace);
                
                return 0;

            }

        }

        //#############################################################################################################
        //รับ arr ของชื่อไฟล์ของแต่ละ Table (ใช้ได้เฉพาะ table ประเภทData เท่านั้น!!!)
        //โดยเรียกใช้ getDataInMainDB และทำการแปลงเป็น string[] ด้วย getFiles(DataTable data)
        //ช่วงเวลา (ทั้งตาราง)
        public static string[] getFiles(string tableName)
        {
            DataTable data = getDataInMainDB(tableName);

            return getFiles(data);
        }
        //ตั้งแต่ไฟล์แรกถึงไฟล์ที่ timeEnd (ใช้เวลา date start)
        public static string[] getFiles(string tableName, DateTime TimeEnd)
        {
            DataTable data = getDataInMainDB(tableName, TimeEnd);

            return getFiles(data);
        }
        //ตั้งแต่ไฟล์ที่ timeStart ถึงไฟล์ที่ timeEnd
        public static string[] getFiles(string tableName, DateTime TimeStart, DateTime TimeEnd)
        {
            DataTable data = getDataInMainDB(tableName, TimeStart, TimeEnd);

            return getFiles(data);
        }

        //แปลงจาก dataTable ให้เป็น string[] of file
        public static string[] getFiles(DataTable data)
        {


            List<string> fileUrlList = new List<string>();

            foreach (DataRow row in data.Rows)
            {
                string fileName = row["m_file_name"].ToString().Replace(@"\\", @"\");
                fileUrlList.Add(fileName);
            }
            return fileUrlList.ToArray();
        }

        //#########################################################################################################
        public static DataTable getDataInMainDB(string tableName)
        {

            string stringSQL = String.Format("SELECT * FROM {0} ", tableName);

            DataTable data = new DataTable();

            MySqlConnection conn = Connecting(mainDbConnStr);

            MySqlDataAdapter da = new MySqlDataAdapter(stringSQL, conn);



            // MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            try
            {
                da.Fill(data);
            }
            catch (Exception ex)
            {
                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in getDataInMainDB " + " " + ex.Message + " " + ex.StackTrace);
               
                throw ex;
            }


            conn.Close();

            return data;
        }

        public static DataTable getDataInMainDB(string tableName, DateTime TimeEnd)
        {
            string stringSQL = String.Format("SELECT * from {0} where `m_date_start` < '{1}' ", tableName
                , TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

            DataTable data = new DataTable();

            MySqlConnection conn = Connecting(mainDbConnStr);

            MySqlDataAdapter da = new MySqlDataAdapter(stringSQL, conn);

            //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            try
            {
                da.Fill(data);
            }
            catch (Exception ex)
            {
                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in getDataInMainDB " + tableName + " " + TimeEnd + " " + ex.Message + " " + ex.StackTrace);
                
                throw ex;
            }



            conn.Close();

            return data;
        }

        public static DataTable getDataInMainDB(string tableName, DateTime TimeStart, DateTime TimeEnd)
        {
            string stringSQL = String.Format("SELECT * from {0} where `m_date_start`>='{1}' And `m_date_start`<'{2}'", tableName,
                TimeStart.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")), TimeEnd.ToString("yyyy/M/d HH:mm:ss", new CultureInfo("en-US")));

            DataTable data = new DataTable();

            MySqlConnection conn = Connecting(mainDbConnStr);

            MySqlDataAdapter da = new MySqlDataAdapter(stringSQL, conn);

            //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            try
            {
                da.Fill(data);
            }
            catch (Exception ex)
            {
                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in getDataInMainDB " + tableName + " " + TimeStart + " " + TimeEnd + " " + ex.Message + " " + ex.StackTrace);
                
                throw ex;
            }
            conn.Close();

            return data;
        }


        //*******************************************************************************
        //รับตารางที่มีทั้งหมดใน main DB
        public static DataTable getAllTable()
        {
            MySqlConnection conn = Connecting(mainDbConnStr);

            string stringSQL = "show tables;";

            DataTable data = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(stringSQL, conn);

            //  MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            try
            {
                da.Fill(data);
            }
            catch (Exception ex)
            {
                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in getAllTable " + " " + ex.Message + " " + ex.StackTrace);
                
                throw ex;
            }

            conn.Close();

            return data;
        }

        public static string[] getAllTableName()
        {
            List<string> stringTable = new List<string>();

            foreach (DataRow row in getAllTable().Rows)
            {
                stringTable.Add(row[0].ToString());
            }

            return stringTable.ToArray();
        }
        //************************************************************************** 
        //function นี้ทำต่อเนื่องกันครับ 
        //getFirstDataTableInDateTime->getFirstDataTable->getStringDataTable->getAllTable

        //รับ arr string ชื่อของตารางทั้งหมด
        private static string[] getStringTable(string tableType)//table type = data or event
        {
            List<string> stringTable = new List<string>();

            string str;
            foreach (DataRow row in getAllTable().Rows)
            {
                str = row[0].ToString();
                if (tableType.Equals(str.Split('_')[0]))
                {
                    stringTable.Add(str);
                }
            }
            return stringTable.ToArray();
        }
        //รับ string  ชื่อของตารางที่เก่าที่สุด
        private static string getFirstTable(string[] strDataTable)
        {
            return VsTableName.getOldestTimeTable(strDataTable, DateTime.Now);
            //// string[] strDataTable = getStringDataTable();
            //string firstTable = "";
            //int firstY = 3000;
            //int firstM = 32;

            //foreach (string str in strDataTable)
            //{
            //    int m = int.Parse(str.Split('_')[1]);
            //    int y = int.Parse(str.Split('_')[2]);

            //    if (firstY > y)
            //    {
            //        firstY = y;
            //        firstM = m;
            //        firstTable = str;
            //    }
            //    else if (firstY == y)
            //    {

            //        if (firstM > m)
            //        {
            //            firstM = m;
            //            firstTable = str;
            //        }
            //    }
            //}

            //return firstTable;
        }
        //รับ DateTime ของตารางที่เก่าที่สุด
        public static DateTime getFirstTableInDateTime(string tableType)
        {
            return tableNameToDateTime(getFirstTable(getStringTable(tableType)));
        }

        //แปลงจาก DateTime เป็นชื่อตาราง
        public static string DateTimeToTableName(string tableType, DateTime date)
        {
            return VsTableName.dateTimeToTableName(tableType, date);//String.Format("{0}_{1}_{2}", tableType, date.Month, date.Year);
        }
        //*****************************************************************************************


        //แปรงจากชื่อตารางเป็น DateTime
        public static DateTime tableNameToDateTime(string tableName)
        {
            return VsTableName.tableNameToDateTime(tableName);
            //if (tableName != "" && tableName != null)
            //{
            //    int m = int.Parse(tableName.Split('_')[1]);
            //    int y = int.Parse(tableName.Split('_')[2]);

            //    return new DateTime(y, m, 1);
            //}
            //else
            //{
            //    return DateTime.Now;
            //}
        }

        //เปลียบเทียบ ชื่อของตารางประเภท data { -1 is < ; 0 is == ; 1is > }
        public static int compareTable(string t1, string t2)
        {
            return VsTableName.compareTable(t1, t2);

            //int m1 = int.Parse(t1.Split('_')[1]);
            //int y1 = int.Parse(t1.Split('_')[2]);

            //int m2 = int.Parse(t2.Split('_')[1]);
            //int y2 = int.Parse(t2.Split('_')[2]);

            //if (y1 > y2)
            //{
            //    return 1;
            //}
            //else if (y1 == y2)
            //{
            //    if (m1 > m2)
            //    {
            //        return 1;
            //    }
            //    else if (m1 == m2)
            //    {
            //        return 0;
            //    }
            //}
            //return -1;
        }


        //ทั้งหมดนี้ใช้กับ Vs-main เท่านั้น
        //******************************************************************************************************

        //สำหรับ MainDB
        public static int getNumDataInTable(string tableName)
        {

            string stringSQL = String.Format("SELECT count(*) from {0}", tableName);

            DataTable data = new DataTable();

            MySqlConnection conn = Connecting(mainDbConnStr);

            MySqlDataAdapter da = new MySqlDataAdapter(stringSQL, conn);

            //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            try
            {
                da.Fill(data);
            }
            catch (Exception ex)
            {
                conn.Close();

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in getNumDataInTable " + " " + tableName + " " + ex.Message + " " + ex.StackTrace);
                
                throw ex;
            }

            conn.Close();

            int numOfData = int.Parse(data.Rows[0][0].ToString());

            return numOfData;
        }

        public static bool deleteTable(string tableName)
        {
            MySqlConnection conn = null;
            try
            {
                string stringSQL = string.Format("DROP TABLE  {0}", tableName);
                conn = Connecting(mainDbConnStr);

                MySqlCommand command = new MySqlCommand(stringSQL, conn);

                bool res = false;
                if (command.ExecuteNonQuery() > 0)
                {
                    res = true;
                }

                conn.Close();
                return res;
            }
            catch (MySqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }

                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("ex", "in deleteTable " + " " + tableName + " " + ex.Message + " " + ex.StackTrace);
                
                return false;
            }

        }
    }
}
