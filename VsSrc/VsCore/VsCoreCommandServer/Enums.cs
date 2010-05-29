// ovqg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uhta	
// igdw	 By downloading, copying, installing or using the software you agree to this license.
// bsah	 If you do not agree to this license, do not download, install,
// bovz	 copy or use the software.
// kbfh	
// bkdk	                          License Agreement
// kyvl	         For OpenVSS - Open Source Video Surveillance System
// yqwd	
// yzdz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cywi	
// aocn	Third party copyrights are property of their respective owners.
// qkzb	
// nkun	Redistribution and use in source and binary forms, with or without modification,
// pjej	are permitted provided that the following conditions are met:
// diqj	
// lryl	  * Redistribution's of source code must retain the above copyright notice,
// vwjb	    this list of conditions and the following disclaimer.
// lvxl	
// exhm	  * Redistribution's in binary form must reproduce the above copyright notice,
// iqua	    this list of conditions and the following disclaimer in the documentation
// zuyn	    and/or other materials provided with the distribution.
// wjop	
// vtwt	  * Neither the name of the copyright holders nor the names of its contributors 
// imwj	    may not be used to endorse or promote products derived from this software 
// qqrt	    without specific prior written permission.
// axqs	
// miis	This software is provided by the copyright holders and contributors "as is" and
// crbm	any express or implied warranties, including, but not limited to, the implied
// oqjr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tkom	In no event shall the Prince of Songkla University or contributors be liable 
// iugr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yeds	(including, but not limited to, procurement of substitute goods or services;
// axwr	loss of use, data, or profits; or business interruption) however caused
// yazc	and on any theory of liability, whether in contract, strict liability,
// egbn	or tort (including negligence or otherwise) arising in any way out of
// awnd	the use of this software, even if advised of the possibility of such damage.
// sjer	
// cfpg	Intelligent Systems Laboratory (iSys Lab)
// cfkg	Faculty of Engineering, Prince of Songkla University, THAILAND
// qyti	Project leader by Nikom SUVONVORN
// eqre	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;

namespace Vs.Core.Server.Command
{
    /// <summary>
    /// Command type
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// bool Start(String camName);
        /// </summary>
        VS_START = 0,
        /// <summary>
        /// bool StartAll();
        /// </summary>
        VS_START_ALL,
        /// <summary>
        /// bool Stop(String camName);
        /// </summary>
        VS_STOP,
        /// <summary>
        /// bool StopAll();
        /// </summary>
        VS_STOP_ALL,

        /// <summary>
        /// bool StartConnect(String camName)
        /// </summary>
        VS_START_CONNECT,
        /// <summary>
        /// bool StartConnectAll()
        /// </summary>
        VS_START_CONNECT_ALL,
        /// <summary>
        /// bool StopConnect(String camName);
        /// </summary>
        VS_STOP_CONNECT,
        /// <summary>
        /// bool StopConnectAll();
        /// </summary>
        VS_STOP_CONNECT_ALL,

        /// <summary>
        /// bool StartAnalyse(String camName);
        /// </summary>
        VS_START_ANALYSE,
        /// <summary>
        /// bool StartAnalyseAll();
        /// </summary>
        VS_START_ANALYSE_ALL,
        /// <summary>
        /// bool StopAnalyse(String camName);
        /// </summary>
        VS_STOP_ANALYSE,
        /// <summary>
        ///  bool StopAnalyseAll();
        /// </summary>
        VS_STOP_ANALYSE_ALL,

        /// <summary>
        /// bool StartEventAlert(String camName);
        /// </summary>
        VS_START_EVENT_ALERT,
        /// <summary>
        /// bool StartEventAlertAll();
        /// </summary>
        VS_START_EVENT_ALERT_ALL,
        /// <summary>
        /// bool StopEventAlert(String camName);
        /// </summary>
        VS_STOP_EVENT_ALERT,
        /// <summary>
        /// bool StopEventAlertAll();
        /// </summary>
        VS_STOP_EVENT_ALERT_ALL,

        /// <summary>
        /// bool StartRecord(String camName);
        /// </summary>
        VS_START_RECORD,
        /// <summary>
        /// bool StartRecordAll();
        /// </summary>
        VS_START_RECORD_ALL,
        /// <summary>
        /// bool StopRecord(String camName);
        /// </summary>
        VS_STOP_RECORD,
        /// <summary>
        /// bool StopRecordAll();
        /// </summary>
        VS_STOP_RECORD_ALL,

        /// <summary>
        /// bool StartDataAlert(String camName);
        /// </summary>
        VS_START_DATA_ALERT,
        /// <summary>
        /// bool StartDataAlertAll();
        /// </summary>
        VS_START_DATA_ALERT_ALL,
        /// <summary>
        /// bool StopDataAlert(String camName);
        /// </summary>
        VS_STOP_DATA_ALERT,
        /// <summary>
        /// bool StopDataAlertAll();
        /// </summary>
        VS_STOP_DATA_ALERT_ALL,


        /// <summary>
        /// String[] ListCameras();
        /// </summary>
        VS_LIST_CAMERAS,
        /// <summary>
        /// String[] ListCamerasConnect();
        /// </summary>
        VS_LIST_CAMERAS_CONNECT_STATUS,
        /// <summary>
        /// String[] ListCamerasAnalyse();
        /// </summary>
        VS_LIST_CAMERAS_ANALYSE_STATUS,
        /// <summary>
        /// String[] ListCamerasEventAlert();
        /// </summary>
        VS_LIST_CAMERAS_EVENT_ALERT_STATUS,
        /// <summary>
        /// String[] ListCamerasRecord();
        /// </summary>
        VS_LIST_CAMERAS_RECORD_STATUS,
        /// <summary>
        /// String[] ListCamerasDataAlert();
        /// </summary>
        VS_LIST_CAMERAS_DATA_ALERT_STATUS,

        /// <summary>
        /// String ListCameraConnect(String camName);
        /// </summary>
        VS_LIST_CAMERA_CONNECT_STATUS,
        /// <summary>
        /// String ListCameraAnalyse(String camName);
        /// </summary>
        VS_LIST_CAMERA_ANALYSE_STATUS,
        /// <summary>
        /// String ListCameraEventAlert(String camName);
        /// </summary>
        VS_LIST_CAMERA_EVENT_ALERT_STATUS,
        /// <summary>
        /// String ListCameraRecord(String camName);
        /// </summary>
        VS_LIST_CAMERA_RECORD_STATUS,
        /// <summary>
        /// String ListCameraDataAlert(String camName);
        /// </summary>
        VS_LIST_CAMERA_DATA_ALERT_STATUS,

        /// <summary>
        /// status infomation
        /// </summary>
        VS_INFO
    }
}
