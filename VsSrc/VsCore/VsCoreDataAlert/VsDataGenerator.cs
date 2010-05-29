// gjqc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tyvo	
// lqxq	 By downloading, copying, installing or using the software you agree to this license.
// oegp	 If you do not agree to this license, do not download, install,
// grpb	 copy or use the software.
// gjee	
// qgzg	                          License Agreement
// plgv	         For OpenVSS - Open Source Video Surveillance System
// mrfr	
// nira	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jmey	
// eqdf	Third party copyrights are property of their respective owners.
// uyww	
// hwhw	Redistribution and use in source and binary forms, with or without modification,
// emln	are permitted provided that the following conditions are met:
// yoza	
// jbex	  * Redistribution's of source code must retain the above copyright notice,
// zpcy	    this list of conditions and the following disclaimer.
// aort	
// egzz	  * Redistribution's in binary form must reproduce the above copyright notice,
// dumq	    this list of conditions and the following disclaimer in the documentation
// oknq	    and/or other materials provided with the distribution.
// jima	
// wdbv	  * Neither the name of the copyright holders nor the names of its contributors 
// ndoc	    may not be used to endorse or promote products derived from this software 
// mfff	    without specific prior written permission.
// vxvt	
// enry	This software is provided by the copyright holders and contributors "as is" and
// mmke	any express or implied warranties, including, but not limited to, the implied
// cilz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nnnq	In no event shall the Prince of Songkla University or contributors be liable 
// dbbx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nwfa	(including, but not limited to, procurement of substitute goods or services;
// rxnx	loss of use, data, or profits; or business interruption) however caused
// ohvr	and on any theory of liability, whether in contract, strict liability,
// oumv	or tort (including negligence or otherwise) arising in any way out of
// rook	the use of this software, even if advised of the possibility of such damage.
// swtf	
// spoy	Intelligent Systems Laboratory (iSys Lab)
// spbu	Faculty of Engineering, Prince of Songkla University, THAILAND
// vyfh	Project leader by Nikom SUVONVORN
// iqgp	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.CompilerServices;
using Vs.Core.Image;
using System.Globalization;
using NLog; 

namespace Vs.Core.DataAlert
{
    public class VsDataGenerator : IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        // database
        private string strConnect = null;
        private string tableName;

        // Database host
        private string dbHost;
        private string dbUser;
        private string dbPasswd;
        private string dbDatabase;
        MySqlConnection connectSQL = null; 

        // buffer
        protected Queue dataBuffer = null;

        // timer
        private System.Threading.Timer timer = null;
        private TimerCallback tcallback = null;

        private long syncTimer = 200;

        // -----------------------------------------------------------------------------------------------------------------------
        // Database host properties
        // -----------------------------------------------------------------------------------------------------------------------
        // Database host property
        public string DataHost
        {
            get { return dbHost; }
            set { dbHost = value; }
        }

        // Data user property
        public string DataUser
        {
            get { return dbUser; }
            set { dbUser = value; }
        }

        // Data password property
        public string DataPasswd
        {
            get { return dbPasswd; }
            set { dbPasswd = value; }
        }

        // Data database property
        public string DataDatabase
        {
            get { return dbDatabase; }
            set { dbDatabase = value; }
        }

        // TableName property
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        // Constructor
        public VsDataGenerator(long syncTimer, string dbHost, string dbUser, string dbPasswd, string dbDatabase)
        {
            try
            {
                this.syncTimer = syncTimer;

                // data host
                this.dbHost = dbHost;
                this.dbUser = dbUser;
                this.dbPasswd = dbPasswd;
                this.dbDatabase = dbDatabase;

                // synchronized queue
                dataBuffer = Queue.Synchronized(new Queue());

                // timer
                tcallback = new TimerCallback(process_NewFrame);
                // define the dueTime and period 
                long dTime = 1000;           // wait before the first tick (in ms) 
                // instantiate the Timer object 
                timer = new Timer(tcallback, null, dTime, syncTimer);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    timer.Dispose();
                    timer = null;

                    dataBuffer.Clear();
                    dataBuffer = null;

                    if (connectSQL != null)
                    {
                        connectSQL.Dispose();
                        connectSQL = null;
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // On new frame ready
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn(object sender, VsDataEventArgs e)
        {
            try
            {
                /*
                if (dataBuffer.Count > 1000/syncTimer)
                {
                    VsData rm = (VsData)dataBuffer.Dequeue();
                    rm.Dispose(); rm = null;
                    logger.Log(LogLevel.Warn, DateTime.Now.ToString() + "; frame removed from DataGenerator");
                }
                */
                VsData img = (VsData)e.Data.Clone();
                dataBuffer.Enqueue(img);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        // Process new frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void process_NewFrame(object stateInfo)
        {
            VsData lastData = null;

            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

            try
            {
                // get new one
                if (dataBuffer.Count > 0)
                {
                    lastData = (VsData)dataBuffer.Dequeue();
                }

                if (lastData != null)
                {                    
                    try
                    {
                        strConnect = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                            DataHost, DataUser, DataPasswd, DataDatabase);

                        connectSQL = new MySqlConnection(strConnect);
                        connectSQL.Open();
                    }
                    catch (MySqlException err)
                    {
                        logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;

                        if (connectSQL != null)
                        {
                            connectSQL.Dispose();
                            connectSQL = null;
                        }
                    }

                    if (connectSQL != null)
                    {
                        /*
                        // Add image to database
                        // process
                        MemoryStream ms = new MemoryStream();
                        lastData.Image.Save(ms, ImageFormat.Jpeg);

                        byte[] imageIn = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(imageIn, 0, (int)ms.Length);
                        ms.Close();
                        ms.Dispose();
                        ms = null;
                        */

                        // inogr image
                        byte[] imageIn = new byte[1];

                        TableCheck(connectSQL);
                        lastData.TableName = TableName;

                        MySqlCommand cmdSQL = new MySqlCommand(lastData.Sql, connectSQL);
                        try
                        {
                            cmdSQL.Parameters.Add(new MySqlParameter("?image", imageIn));
                            cmdSQL.Parameters.Add(new MySqlParameter("?imagesize", imageIn.Length));
                            cmdSQL.ExecuteNonQuery();
                        }
                        catch (MySqlException err)
                        {
                            logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                        }
                        cmdSQL.Dispose();                        
                    }

                    if (connectSQL != null)
                    {
                        try
                        {
                            connectSQL.Close();
                            connectSQL.Dispose();
                            connectSQL = null;
                        }
                        catch(Exception err)
                        {
                            logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                if (connectSQL != null)
                {
                    connectSQL.Dispose();
                    connectSQL = null;
                }

                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
        }

        private void TableCheck(MySqlConnection connectSQL)
        {
            string tableName;
            DateTime dateNow = DateTime.Now;

            tableName = string.Format("data_{0}_{1}", 
                dateNow.Month.ToString(),
                dateNow.Year.ToString());

            if (tableName != this.tableName)
            {
                this.tableName = tableName;
                TableCreate(connectSQL);
            }
        }

        private void TableCreate(MySqlConnection connectSQL)
        {
            MySqlCommand cmdSQL;

            string strSQL = "CREATE TABLE IF NOT EXISTS  `vsa-main`.`" +TableName + "` (" +
                "  `m_id` int(10) unsigned NOT NULL auto_increment," +
                "  `m_ip_camera` varchar(45) NOT NULL," +
                "  `m_ip_camera_lati` varchar(45) NOT NULL," +
                "  `m_ip_camera_long` varchar(45) NOT NULL," +
                "  `m_ip_processor` varchar(45) NOT NULL," +
                "  `m_file_name` varchar(90) NOT NULL," +
                "  `m_file_size` int(10) unsigned NOT NULL," +
                "  `m_file_location` varchar(90) NOT NULL," +
                "  `m_algo_name` varchar(45) NOT NULL," +
                "  `m_enc_name` varchar(45) NOT NULL," +
                "  `m_enc_codecs` varchar(45) NOT NULL," +
                "  `m_date_start` datetime NOT NULL," +
                "  `m_date_end` datetime NOT NULL," +
                "  `m_detail` varchar(45)," +
                "  `m_image` longblob," +
                "  `m_image_size` int unsigned," +
                "  PRIMARY KEY  (`m_id`)" +
                "  ) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;";

            cmdSQL = new MySqlCommand(strSQL, connectSQL);
            try
            {
                cmdSQL.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmdSQL.Dispose();
            }
        }
    }
}
