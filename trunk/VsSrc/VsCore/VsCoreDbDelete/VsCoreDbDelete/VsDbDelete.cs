// hrhb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tawt	
// wwir	 By downloading, copying, installing or using the software you agree to this license.
// gqob	 If you do not agree to this license, do not download, install,
// vnix	 copy or use the software.
// bwyo	
// yqlv	                          License Agreement
// owts	         For OpenVSS - Open Source Video Surveillance System
// mbtd	
// asfc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ehky	
// qocc	Third party copyrights are property of their respective owners.
// mpbv	
// rwhk	Redistribution and use in source and binary forms, with or without modification,
// ttcd	are permitted provided that the following conditions are met:
// obea	
// cqef	  * Redistribution's of source code must retain the above copyright notice,
// xlad	    this list of conditions and the following disclaimer.
// igst	
// mzyj	  * Redistribution's in binary form must reproduce the above copyright notice,
// njiy	    this list of conditions and the following disclaimer in the documentation
// vyaq	    and/or other materials provided with the distribution.
// tijh	
// pcnd	  * Neither the name of the copyright holders nor the names of its contributors 
// ckwa	    may not be used to endorse or promote products derived from this software 
// kxeb	    without specific prior written permission.
// pynk	
// eoxu	This software is provided by the copyright holders and contributors "as is" and
// vspf	any express or implied warranties, including, but not limited to, the implied
// sgee	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pnlo	In no event shall the Prince of Songkla University or contributors be liable 
// ctnf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// toqc	(including, but not limited to, procurement of substitute goods or services;
// dyzq	loss of use, data, or profits; or business interruption) however caused
// ehjw	and on any theory of liability, whether in contract, strict liability,
// kqmf	or tort (including negligence or otherwise) arising in any way out of
// lplw	the use of this software, even if advised of the possibility of such damage.
// milw	
// frlw	Intelligent Systems Laboratory (iSys Lab)
// lqzv	Faculty of Engineering, Prince of Songkla University, THAILAND
// lhrp	Project leader by Nikom SUVONVORN
// xvqx	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using MySql.Data.MySqlClient;

namespace Vs.Core.DbDelete
{
    public delegate void setMsg(string type, string msg);

    public class VsDbDelete
    {
        //private string mysqlServer;
        //private string mysqlServerIp;
        //private string mysqlUser;
        //private string mysqlPass;
        //private string primaryDbName;
        //private string secondaryDbName;

        //private string connString;

        private string mainDbConnString;
        private string clientDbConnString;

        FileManage fileManage;

        public static setMsg setmsg;
        public static void setDelegate(setMsg func)
        {
            setmsg = func;
        }

        //cMessageBox.Show(ex.Message);onstructor
        //public VsDbDelete(string server, string user, string pass, string Dbprima, string Dbsecon, string hostIp, string fileRootPath)
        //{
        //    mysqlServer = server;
        //    mysqlUser = user;
        //    mysqlPass = pass;
        //    primaryDbName = hostIp;
        //    primaryDbName = Dbprima;
        //    secondaryDbName = Dbsecon;

        //    connString = getConnString(server, user, pass, "", false);
        //    mainDbConnString = getConnString(server, user, pass, Dbprima, false);
        //    clientDbConnString = getConnString(server, user, pass, Dbsecon, false);



        //    VsDbConnection.setConnectionString(mainDbConnString, clientDbConnString);

        //    fileManage = new FileManage(10000, 6);//รอลบซ้ำ รอบละสิบวิ หกรอบ
        //}

        public VsDbDelete(string mainConStr, string clientConStr)
        {
            mainDbConnString = mainConStr;
            clientDbConnString = clientConStr;
            VsDbConnection.setConnectionString(mainDbConnString, clientDbConnString);

            fileManage = new FileManage(10000, 6);//รอลบซ้ำ รอบละสิบวิ หกรอบ
            // setMsg = new setText;
        }
        //สร้าง string connectionจากค่าต่างๆ
        private string getConnString(string server, string userId, string password, string database, bool pooling)
        {
            string conn = String.Format("server={0};user id={1}; password={2}; database={3}; pooling={4}", server, userId, password, database, pooling.ToString());
            return conn;
        }


        public int delete(DateTime end)
        {
            int numDelete = 0;
            try
            {
                // ลบข้อมูลใน main DB ตาราง Data และ ที่ fileข้อมูล
                int numMainDataAndFileDelete = deleteMainDataAndFile(end);

                // ลบข้อมูลใน main DB ตาราง Event
                int numMainEventDelete = deleteMainEventDelete(end);

                // ลบข้อมูลใน clientDB 
                //int numClientDeltete = deleteClientData(end);


                //deleteClientUpdateData(end);

                //ตรวจว่าข้อมูลที่ลบใน สามตารางนี้เท่ากันมั้ย
                //if ((numMainDataAndFileDelete != numMainEventDelete)
                //    || (numMainDataAndFileDelete != numClientDeltete)
                //    || (numMainEventDelete != numClientDeltete))
                //{
                //    VsDbDelete.setmsg("msg", "number dedeted don't match "
                //        + " numMainData:" + numMainDataAndFileDelete + " numMainEvent:" + numMainEventDelete + " numClient:" + numClientDeltete);
                //}

                numDelete = numMainDataAndFileDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numDelete;
        }

        public int deleteClientUpdateData(DateTime end)
        {
            return VsDbConnection.deleteClientUpdateData(end);
        }
        public int deleteClientData(DateTime end)
        {

            return VsDbConnection.deleteClientData(end);
        }
        public int deleteMainEventDelete(DateTime end)
        {
            int numDelete = 0;
            string[] tablesName = getListOfTableInPeriod("event", end);
            foreach (string table in tablesName)
            {
                try
                {
                    numDelete += VsDbConnection.deleteMainData(table, end);

                    //ถ้าไม่มีข้อมูลเหลือในตารางก็ให้ลบตารางทิ้ง
                    if (VsDbConnection.getNumDataInTable(table) == 0 && !table.Equals(VsDbConnection.DateTimeToTableName("event", DateTime.Now)))
                    {
                        VsDbConnection.deleteTable(table);
                    }
                }
                catch (Exception ex)
                {
                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("ex", "in deleteMainEventDelete  before:" + end + "table" + table + ex.Message + " " + ex.StackTrace);
                }

            }//วนทำทุก table ที่อยู่ในช่วง firstTable ถึง endTable

            return numDelete;
        }
        public int deleteMainDataAndFile(DateTime end)
        {
            int numDelete = 0;
            string[] tablesName = getListOfTableInPeriod("data", end);
            foreach (string table in tablesName)
            {
                try
                {
                    numDelete += deleteMainDataAndFileEachTable(table, end);
                }
                catch (Exception ex)
                {
                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("ex", "in deleteMainDataAndFile  before:" + end + "table" + table + ex.Message + " " + ex.StackTrace);
                }

            }//วนทำทุก table ที่อยู่ในช่วง firstTable ถึง endTable

            return numDelete;
        }

        private int deleteMainDataAndFileEachTable(string table, DateTime end)
        {
            //ดึงชื่อfile มาจาก main DB
            string[] filesName = VsDbConnection.getFiles(table, end);

            //เอาค่าจากไฟล์ config
            AppConfigData config = new AppConfigData();
            config.LoadSettings("app.config");
            string rootDir = config.localHost.Storage;//new FileInfo(filesName[0]).Directory.Parent.Parent.FullName;

            //ลบข้อมูลใน main DB
            int numMainDbDelte = VsDbConnection.deleteMainData(table, end);


            //ลบfile
            int numFileDelete = fileManage.deleteFile(filesName);

            //ถ้าไม่มีข้อมูลเหลือในตารางก็ให้ลบตารางทิ้ง
            if (VsDbConnection.getNumDataInTable(table) == 0)
            {
                if (!table.Equals(VsDbConnection.DateTimeToTableName("data", DateTime.Now)))
                {
                    VsDbConnection.deleteTable(table);
                }
                deleteDirFileOfTable(table, rootDir);
            }

            //เปลียบเที่ยบว่าลบไปเท่ากันมั้ย
            if ((numMainDbDelte != numFileDelete))
            {
                if (VsDbDelete.setmsg != null)
                VsDbDelete.setmsg("msg", "number dedeted don't match "
                        + " numMainDbDelte:" + numMainDbDelte + " numFileDelete:" + numFileDelete);
            }

            return numMainDbDelte;
        }

        private void deleteDirFileOfTable(string table, string rootDir)
        {
            DateTime dt = VsTableNameManage.VsTableName.tableNameToDateTime(table);

            int y = dt.Year;
            int m = dt.Month;

            foreach (string fullDirName in Directory.GetDirectories(rootDir))
            {
                //string dirName = info.Name;

                string dirName = Path.GetFileName(fullDirName);

                int ydir = int.Parse(dirName.Split('-')[0]);
                int mdir = int.Parse(dirName.Split('-')[1]);

                if (y == ydir && m == mdir)
                {
                    //info.Delete(true);

                    fileManage.tryDeleteDir(fullDirName);
                }
            }
        }

        //###################################################################################################
        private string[] getListOfTableInPeriod(string tableType, DateTime end)
        {
            DateTime start = VsDbConnection.getFirstTableInDateTime(tableType);

            return getListOfTableInPeriod(tableType, start, end);
        }

        private string[] getListOfTableInPeriod(string tableType, string startStr, string endStr)
        {
            DateTime start = VsDbConnection.tableNameToDateTime(startStr);
            DateTime end = VsDbConnection.tableNameToDateTime(endStr);

            return getListOfTableInPeriod(tableType, start, end);
        }

        private string[] getListOfTableInPeriod(string tableType, DateTime start, DateTime end)
        {
            List<string> dateList = new List<string>();

            int i = 0;
            while (true)
            {
                DateTime addMonths = start.AddMonths(i);
                DateTime inTime = new DateTime(addMonths.Year, addMonths.Month, 1);

                if (end.CompareTo(inTime) >= 0)
                {
                    dateList.Add(VsDbConnection.DateTimeToTableName(tableType, inTime));
                    i++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            return dateList.ToArray();
        }


        //###################################################################################################


        public string[] getAllTableName()
        {
            return VsDbConnection.getAllTableName();
        }

        public string[] getFiles(DateTime end)
        {

            List<string> files = new List<string>();
            try
            {
                string[] tablesName = getListOfTableInPeriod("data", end);
                foreach (string table in tablesName)
                {
                    try
                    {
                        files.AddRange(VsDbConnection.getFiles(table, end));
                    }
                    catch (Exception ex)
                    {
                        if (VsDbDelete.setmsg != null)
                            VsDbDelete.setmsg("ex", "in getFiles  before:" + end + ex.Message + " " + ex.StackTrace);
                    }

                }//วนทำทุก table ที่อยู่ในช่วง firstTable ถึง endTable
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return files.ToArray();
        }

        public long getSumOfFileSize(string[] files)
        {
            return fileManage.getSumOfFileSize(files);
        }

        public int getNumDataInTable(string tableName)
        {
            return VsDbConnection.getNumDataInTable(tableName);
        }

        //public  int getNumOfDateInPeriod(DateTime start, DateTime end)
        //{
        //    TimeSpan p = end - start;

        //    if (p.TotalDays % 1 == 0)
        //    {
        //        return (int)p.TotalDays;
        //    }
        //    else
        //    {
        //        int v = (int)p.TotalDays;
        //        return ++v;
        //    }
        //}
    }
}
