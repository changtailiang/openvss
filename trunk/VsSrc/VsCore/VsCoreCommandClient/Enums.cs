// dqpl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jghs	
// velj	 By downloading, copying, installing or using the software you agree to this license.
// dizf	 If you do not agree to this license, do not download, install,
// dwup	 copy or use the software.
// zuzw	
// bjqo	                          License Agreement
// hzed	         For OpenVss - Open Source Video Surveillance System
// bahp	
// fhbi	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// gqhv	
// oqci	Third party copyrights are property of their respective owners.
// fola	
// mfki	Redistribution and use in source and binary forms, with or without modification,
// rtkz	are permitted provided that the following conditions are met:
// qskv	
// ahid	  * Redistribution's of source code must retain the above copyright notice,
// akzv	    this list of conditions and the following disclaimer.
// vlji	
// mehk	  * Redistribution's in binary form must reproduce the above copyright notice,
// hhjt	    this list of conditions and the following disclaimer in the documentation
// oerw	    and/or other materials provided with the distribution.
// pyym	
// xbsn	  * Neither the name of the copyright holders nor the names of its contributors 
// glvh	    may not be used to endorse or promote products derived from this software 
// iyhu	    without specific prior written permission.
// opeb	
// wbwm	This software is provided by the copyright holders and contributors "as is" and
// lzsi	any express or implied warranties, including, but not limited to, the implied
// jrhv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pmnb	In no event shall the Prince of Songkla University or contributors be liable 
// mnyt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tvba	(including, but not limited to, procurement of substitute goods or services;
// iacj	loss of use, data, or profits; or business interruption) however caused
// apey	and on any theory of liability, whether in contract, strict liability,
// zqan	or tort (including negligence or otherwise) arising in any way out of
// clax	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;

namespace Vs.Core.Client.Command
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
