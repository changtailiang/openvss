// jwnw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pjbo	
// iuxm	 By downloading, copying, installing or using the software you agree to this license.
// fqxi	 If you do not agree to this license, do not download, install,
// wcxj	 copy or use the software.
// xfer	
// wbwl	                          License Agreement
// pnbr	         For OpenVSS - Open Source Video Surveillance System
// aftu	
// ndge	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// itrk	
// ffah	Third party copyrights are property of their respective owners.
// qjja	
// qlad	Redistribution and use in source and binary forms, with or without modification,
// swzn	are permitted provided that the following conditions are met:
// npyv	
// tfmz	  * Redistribution's of source code must retain the above copyright notice,
// wdvt	    this list of conditions and the following disclaimer.
// vsae	
// ntlr	  * Redistribution's in binary form must reproduce the above copyright notice,
// bpvf	    this list of conditions and the following disclaimer in the documentation
// dabo	    and/or other materials provided with the distribution.
// eqbq	
// dtrt	  * Neither the name of the copyright holders nor the names of its contributors 
// vwrz	    may not be used to endorse or promote products derived from this software 
// sakm	    without specific prior written permission.
// opfx	
// lwqy	This software is provided by the copyright holders and contributors "as is" and
// kimy	any express or implied warranties, including, but not limited to, the implied
// tsrs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// exug	In no event shall the Prince of Songkla University or contributors be liable 
// beqc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bhjr	(including, but not limited to, procurement of substitute goods or services;
// cmya	loss of use, data, or profits; or business interruption) however caused
// eiro	and on any theory of liability, whether in contract, strict liability,
// vddi	or tort (including negligence or otherwise) arising in any way out of
// zdgv	the use of this software, even if advised of the possibility of such damage.
// gtzc	
// fzvv	Intelligent Systems Laboratory (iSys Lab)
// fdlk	Faculty of Engineering, Prince of Songkla University, THAILAND
// zcwe	Project leader by Nikom SUVONVORN
// mywy	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;
using NLog; 

namespace Vs.Core.Image
{
    public class VsData : IComparable, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        private String m_ip_camera;
        private String m_ip_camera_lati;
        private String m_ip_camera_long;
        private String m_ip_processor;
        private String m_file_name;
        private long m_file_size;
        private String m_file_location;
        private String m_algo_name;
        private String m_enc_name;
        private String m_enc_codecs;
        private DateTime m_date_start;
        private DateTime m_date_end;
        private String m_detail;
        private Bitmap m_image;
        private string m_table_name;

        /// <summary>
        /// Image property
        /// </summary>
        public Bitmap Image
        {
            get { return m_image; }
        }

        /// <summary>
        /// TableName property
        /// </summary>
        public string TableName
        {
            get { return m_table_name; }
            set { m_table_name = value;  }
        }

        /// <summary>
        /// constructor
        /// </summary> 
        public VsData()
        {

        }

        public VsData(String ipcamera, String m_ip_camera_latitude, String m_ip_camera_longtitude, String ipprocessor, String filename,
            long filesize, String filelocation, String algoname, String encname,
            String enccodecs, DateTime datestart, DateTime dateend, String detail, Bitmap image)
        {
            m_ip_camera = ipcamera;
            m_ip_camera_lati = m_ip_camera_latitude;
            m_ip_camera_long = m_ip_camera_longtitude;
            m_ip_processor = ipprocessor;
            m_file_name = filename.Replace("\\", "\\\\");
            m_file_size = filesize;
            m_file_location = filelocation.Replace("\\", "\\\\");
            m_algo_name = algoname;
            m_enc_name = encname;
            m_enc_codecs = enccodecs;
            m_date_start = datestart;
            m_date_end = dateend;
            m_detail = detail;
            m_image = image;
        }

        // disposable object
        public void Dispose()
        {

        }

        public string mysqldate(DateTime date)
        {
            string sql = "";
            try
            {
                sql = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString() + " " + date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return sql;
        } 

        // Sql property
        public String Sql
        {
            get
            {
                String strSql="";

                try
                {
                    strSql = String.Format("INSERT INTO {0}(m_ip_camera,m_ip_camera_lati,m_ip_camera_long,m_ip_processor,m_file_name,m_file_size,m_file_location,m_algo_name,m_enc_name,m_enc_codecs,m_date_start,m_date_end,m_detail,m_image,m_image_size) VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',?image,?imagesize);",
                        m_table_name,
                        m_ip_camera,
                        m_ip_camera_lati,
                        m_ip_camera_long,
                        m_ip_processor,
                        m_file_name,
                        m_file_size,
                        m_file_location,
                        m_algo_name,
                        m_enc_name,
                        m_enc_codecs,
                        mysqldate(m_date_start),
                        mysqldate(m_date_end),
                        m_detail);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
                }

                return strSql;
            }
        }

        // Compares objects of the type
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            VsData p = (VsData)obj;
            return (this.m_ip_camera.CompareTo(p.m_ip_camera));
        }

        // methodes
        public VsData Clone()
        {
            VsData data = null;
            try
            {
                data = new VsData(m_ip_camera, 
                    m_ip_camera_lati,
                    m_ip_camera_long,
                    m_ip_processor, 
                    m_file_name, 
                    m_file_size, 
                    m_file_location, 
                    m_algo_name,
                    m_enc_name, 
                    m_enc_codecs, 
                    m_date_start, 
                    m_date_end, 
                    m_detail, 
                    m_image);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return data;
        }
    }
}
