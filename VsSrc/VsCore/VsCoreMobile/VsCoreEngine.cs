// npcg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dwej	
// noef	 By downloading, copying, installing or using the software you agree to this license.
// ubtm	 If you do not agree to this license, do not download, install,
// xzrj	 copy or use the software.
// wbzd	
// xbtx	                          License Agreement
// ydvu	         For OpenVSS - Open Source Video Surveillance System
// fqug	
// tulr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// urzu	
// eprs	Third party copyrights are property of their respective owners.
// uafp	
// lrhl	Redistribution and use in source and binary forms, with or without modification,
// qyjc	are permitted provided that the following conditions are met:
// dhlk	
// tkae	  * Redistribution's of source code must retain the above copyright notice,
// hmtd	    this list of conditions and the following disclaimer.
// oaof	
// bfzi	  * Redistribution's in binary form must reproduce the above copyright notice,
// kadx	    this list of conditions and the following disclaimer in the documentation
// ygjn	    and/or other materials provided with the distribution.
// iiqv	
// kjnn	  * Neither the name of the copyright holders nor the names of its contributors 
// fobu	    may not be used to endorse or promote products derived from this software 
// pmlh	    without specific prior written permission.
// hbbl	
// cbjl	This software is provided by the copyright holders and contributors "as is" and
// zard	any express or implied warranties, including, but not limited to, the implied
// enmm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bmwy	In no event shall the Prince of Songkla University or contributors be liable 
// wyse	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mbam	(including, but not limited to, procurement of substitute goods or services;
// eftx	loss of use, data, or profits; or business interruption) however caused
// pvqw	and on any theory of liability, whether in contract, strict liability,
// exlg	or tort (including negligence or otherwise) arising in any way out of
// yfwk	the use of this software, even if advised of the possibility of such damage.
// rkis	
// cosc	Intelligent Systems Laboratory (iSys Lab)
// pmlj	Faculty of Engineering, Prince of Songkla University, THAILAND
// jwyb	Project leader by Nikom SUVONVORN
// bwht	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using VsCoreMobile.VsService;
using System.Globalization;


namespace VsCoreMobile
{
    public class VsCoreEngine
    {
        //static Logger logger = LogManager.GetCurrentClassLogger();
        private VsIDataConnect dataConn;
        //public VsIPlayer player;

        public VsService.VsService service;

        public VsCoreEngine(VsIDataConnect dataConn)
        {
            this.dataConn = dataConn;
            //this.player = player;
        }

        public void connectData()
        {
            try
            {

                service = new VsService.VsService();



            }
            catch (Exception err)
            {
         //       logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public VsCoreMobile.VsService.VsCamera[] getCamAll()
        {
            try
            {
                service.getCamAllAsync();
                return service.getCamAll();
            }
            catch (Exception err)
            {
              //  logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
            //try
            //{   
            //}
            //catch (Exception ex) 
            //{ System.Windows.Forms.MessageBox.Show("can't connect Web service :" + ex);
            //return new VsCamera[0];
            //}        
        }

        internal VsCoreMobile.VsService.VsMotion[] getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string p)
        {
            connectData();
            try
            {
                return service.getMotionOfCamAsPeriod(timeBegin, timeEnd, p);
            }
            catch (Exception err)
            {
            //    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        internal VsCoreMobile.VsService.VsFileURL getFileUrlOfMotion(string p, DateTime motionDateTime)
        {
            try
            {
                return service.getFileUrlOfMotion(p, motionDateTime);
            }
            catch (Exception err)
            {
             //   logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        internal List<int> getNumberOfMotionInDay(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                List<int> data = new List<int>();
                int[] number = service.getNumberOfMotionInDay(timeBegin, timeEnd, p);
                data.AddRange(number);
                return data;
            }
            catch (Exception err)
            {
             //   logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        internal List<int> getNumberOfMotionInMonth(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                List<int> data = new List<int>();
                data.AddRange(service.getNumberOfMotionInMonth(timeBegin, timeEnd, p));
                return data;
            }
            catch (Exception err)
            {
             //   logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        internal List<int> getNumberOfMotionInYear(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                List<int> data = new List<int>();
                data.AddRange(service.getNumberOfMotionInYear(timeBegin, timeEnd, p));
                return data;
            }
            catch (Exception err)
            {
             //   logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }
    }
}
