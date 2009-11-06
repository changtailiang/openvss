// bnrk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gyhl	
// xdkg	 By downloading, copying, installing or using the software you agree to this license.
// oiqt	 If you do not agree to this license, do not download, install,
// kwbk	 copy or use the software.
// pmal	
// djxo	                          License Agreement
// tvuv	         For OpenVss - Open Source Video Surveillance System
// pzst	
// xxgl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hldi	
// foip	Third party copyrights are property of their respective owners.
// rtkn	
// vgyo	Redistribution and use in source and binary forms, with or without modification,
// mggx	are permitted provided that the following conditions are met:
// atsc	
// iorp	  * Redistribution's of source code must retain the above copyright notice,
// qwwn	    this list of conditions and the following disclaimer.
// qpdd	
// jrfp	  * Redistribution's in binary form must reproduce the above copyright notice,
// ahwz	    this list of conditions and the following disclaimer in the documentation
// kgzi	    and/or other materials provided with the distribution.
// adgr	
// riln	  * Neither the name of the copyright holders nor the names of its contributors 
// tbzr	    may not be used to endorse or promote products derived from this software 
// xtzu	    without specific prior written permission.
// xxxg	
// dvfu	This software is provided by the copyright holders and contributors "as is" and
// aqws	any express or implied warranties, including, but not limited to, the implied
// wsrc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// oiom	In no event shall the Prince of Songkla University or contributors be liable 
// qevh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// epji	(including, but not limited to, procurement of substitute goods or services;
// snsh	loss of use, data, or profits; or business interruption) however caused
// iccn	and on any theory of liability, whether in contract, strict liability,
// jtff	or tort (including negligence or otherwise) arising in any way out of
// ylqa	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;
using NLog; 

namespace Vs.Core.Image
{
    public class VsMotion : IComparable, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private String m_ip_camera;
        private String m_ip_processor;
        private DateTime m_date_start;
        private String m_event;
        private string m_table_name;

        /// <summary>
        /// TableName property
        /// </summary>
        public string TableName
        {
            get { return m_table_name; }
            set { m_table_name = value; }
        }

        public String CameraName
        {
            get { return m_ip_camera; }
        }

        public String ProcessorName
        {
            get { return m_ip_processor; }
        }

        public DateTime DateStart
        {
            get { return m_date_start; }
        }

        public String EventName
        {
            get { return m_event; }
        }

        // constructor
        public VsMotion()
        {

        }

        public VsMotion(String ipcam, String ipproc, DateTime start, String mevent)
        {
            m_ip_camera = ipcam;
            m_ip_processor = ipproc;
            m_date_start = start;
            m_event = mevent;
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
                String strSql = "";
                try
                {

                    strSql = String.Format("INSERT INTO {0}(m_ip_camera,m_ip_processor,m_date_start,m_event) VALUES('{1}','{2}','{3}','{4}');",
                        m_table_name,
                        m_ip_camera,
                        m_ip_processor,
                        mysqldate(m_date_start),
                        m_event);
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

            VsMotion p = (VsMotion)obj;
            return (this.m_ip_camera.CompareTo(p.m_ip_camera));
        }

        // methodes
        public VsMotion Clone()
        {
            VsMotion motion = null;
            try
            {
                motion = new VsMotion(m_ip_camera, m_ip_processor, m_date_start, m_event);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return motion;
        }
    }
}
