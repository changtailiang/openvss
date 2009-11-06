// wahw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zkul	
// zkrs	 By downloading, copying, installing or using the software you agree to this license.
// ssyx	 If you do not agree to this license, do not download, install,
// kdwg	 copy or use the software.
// yzcw	
// curq	                          License Agreement
// zist	         For OpenVss - Open Source Video Surveillance System
// qdfs	
// tifq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// joch	
// frtz	Third party copyrights are property of their respective owners.
// dswd	
// lgvw	Redistribution and use in source and binary forms, with or without modification,
// xlue	are permitted provided that the following conditions are met:
// selq	
// sybp	  * Redistribution's of source code must retain the above copyright notice,
// nfec	    this list of conditions and the following disclaimer.
// ygxj	
// wvqk	  * Redistribution's in binary form must reproduce the above copyright notice,
// bsmg	    this list of conditions and the following disclaimer in the documentation
// mohk	    and/or other materials provided with the distribution.
// hivh	
// naxe	  * Neither the name of the copyright holders nor the names of its contributors 
// dlog	    may not be used to endorse or promote products derived from this software 
// qdmx	    without specific prior written permission.
// otfe	
// ilzb	This software is provided by the copyright holders and contributors "as is" and
// ujca	any express or implied warranties, including, but not limited to, the implied
// reee	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rqhe	In no event shall the Prince of Songkla University or contributors be liable 
// kwpx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// isfl	(including, but not limited to, procurement of substitute goods or services;
// gkux	loss of use, data, or profits; or business interruption) however caused
// fost	and on any theory of liability, whether in contract, strict liability,
// jccw	or tort (including negligence or otherwise) arising in any way out of
// itnd	the use of this software, even if advised of the possibility of such damage.

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
