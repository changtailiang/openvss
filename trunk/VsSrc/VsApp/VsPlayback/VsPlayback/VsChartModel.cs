// oand	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wmnf	
// jslc	 By downloading, copying, installing or using the software you agree to this license.
// gbxa	 If you do not agree to this license, do not download, install,
// aymd	 copy or use the software.
// dpmf	
// gvrr	                          License Agreement
// sybc	         For OpenVSS - Open Source Video Surveillance System
// ffah	
// yrbw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fogi	
// mqvy	Third party copyrights are property of their respective owners.
// gwwf	
// kwwy	Redistribution and use in source and binary forms, with or without modification,
// ohxb	are permitted provided that the following conditions are met:
// uvmk	
// qixa	  * Redistribution's of source code must retain the above copyright notice,
// bpci	    this list of conditions and the following disclaimer.
// wqyo	
// jesp	  * Redistribution's in binary form must reproduce the above copyright notice,
// atkv	    this list of conditions and the following disclaimer in the documentation
// bvsi	    and/or other materials provided with the distribution.
// jbtq	
// uabk	  * Neither the name of the copyright holders nor the names of its contributors 
// bvrd	    may not be used to endorse or promote products derived from this software 
// tuwr	    without specific prior written permission.
// tniu	
// yhpk	This software is provided by the copyright holders and contributors "as is" and
// piab	any express or implied warranties, including, but not limited to, the implied
// kqiu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qoqz	In no event shall the Prince of Songkla University or contributors be liable 
// wmow	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oomo	(including, but not limited to, procurement of substitute goods or services;
// mowf	loss of use, data, or profits; or business interruption) however caused
// wtbo	and on any theory of liability, whether in contract, strict liability,
// nxkb	or tort (including negligence or otherwise) arising in any way out of
// mjal	the use of this software, even if advised of the possibility of such damage.
// zazk	
// mwne	Intelligent Systems Laboratory (iSys Lab)
// dxuh	Faculty of Engineering, Prince of Songkla University, THAILAND
// ymgj	Project leader by Nikom SUVONVORN
// vbxa	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using NLog; 

namespace Vs.Playback
{
    public class VsChartModel
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        public Dictionary<string, List<int>> dataModel = new Dictionary<string, List<int>>();

        public List<string> headerNsme;

        public string mainTitle;

        public void getCamData(string camName, List<int> value)
        {
            try
            {
                dataModel.Add(camName, value);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void getHeaderName(List<string> head)
        {
            headerNsme = head;
        }

        public void getMainTile(string s)
        {
            mainTitle = s;
        }

        public void exData()
        {
            try
            {
                List<int> value = new List<int>();
                List<string> head = new List<string>();

                for (int i = 1; i <= 12; i++)
                {
                    value.Add(i * 10);
                }

                for (int i = 1; i <= 12; i++)
                {
                    head.Add("" + i);
                }
                // getCamData("newCam", value);

                value = new List<int>();
                for (int i = 1; i <= 12; i++)
                {
                    value.Add(i * 8);
                }

                //getCamData("newCam2", value);

                getMainTile("testChart");
                getHeaderName(head);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
    }
}
