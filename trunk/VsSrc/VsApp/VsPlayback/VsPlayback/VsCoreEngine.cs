// uswv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mzvp	
// ktns	 By downloading, copying, installing or using the software you agree to this license.
// jlej	 If you do not agree to this license, do not download, install,
// crfw	 copy or use the software.
// mcto	
// idkt	                          License Agreement
// hepg	         For OpenVSS - Open Source Video Surveillance System
// hilr	
// filv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qtsa	
// ftij	Third party copyrights are property of their respective owners.
// osam	
// zfqr	Redistribution and use in source and binary forms, with or without modification,
// yhmi	are permitted provided that the following conditions are met:
// obif	
// egka	  * Redistribution's of source code must retain the above copyright notice,
// andu	    this list of conditions and the following disclaimer.
// fjfs	
// ktjo	  * Redistribution's in binary form must reproduce the above copyright notice,
// vbfp	    this list of conditions and the following disclaimer in the documentation
// ecgb	    and/or other materials provided with the distribution.
// stsx	
// vdho	  * Neither the name of the copyright holders nor the names of its contributors 
// lmvy	    may not be used to endorse or promote products derived from this software 
// jija	    without specific prior written permission.
// ofgq	
// ayhf	This software is provided by the copyright holders and contributors "as is" and
// yynn	any express or implied warranties, including, but not limited to, the implied
// wtbb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ajih	In no event shall the Prince of Songkla University or contributors be liable 
// ugyc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cqhx	(including, but not limited to, procurement of substitute goods or services;
// xkfm	loss of use, data, or profits; or business interruption) however caused
// reay	and on any theory of liability, whether in contract, strict liability,
// wqbt	or tort (including negligence or otherwise) arising in any way out of
// lnzx	the use of this software, even if advised of the possibility of such damage.
// ptsr	
// ltyz	Intelligent Systems Laboratory (iSys Lab)
// zbfi	Faculty of Engineering, Prince of Songkla University, THAILAND
// henj	Project leader by Nikom SUVONVORN
// rkhn	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using Vs.Playback.VsService;
using System.Globalization;
using NLog; 

namespace Vs.Playback
{
   public class VsCoreEngine
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private VsIDataConnect dataConn;
        public VsIPlayer player;

        public VsService.VsService service;

        public VsCoreEngine(VsIDataConnect dataConn, VsIPlayer player)
        {
            this.dataConn = dataConn;
            this.player = player;
        }

        public void connectData()
        {
            try
            {
             
                service = new VsService.VsService();    
      
              
                
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public VsCamera[] getCamAll()
        {
            try
            {
                service.getCamAllAsync();
                return service.getCamAll();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
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

        internal VsMotion[] getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                return service.getMotionOfCamAsPeriod(timeBegin, timeEnd, p);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        internal VsFileURL getFileUrlOfMotion(string p,DateTime motionDateTime)
        {
            try
            {
                return service.getFileUrlOfMotion(p, motionDateTime);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
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
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
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
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
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
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }
    }
}
