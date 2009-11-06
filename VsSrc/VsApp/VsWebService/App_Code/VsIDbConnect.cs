// msmd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rkwb	
// kkum	 By downloading, copying, installing or using the software you agree to this license.
// jihh	 If you do not agree to this license, do not download, install,
// qtgq	 copy or use the software.
// mplf	
// xtvo	                          License Agreement
// agmp	         For OpenVss - Open Source Video Surveillance System
// xfyz	
// yxug	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mklk	
// ethe	Third party copyrights are property of their respective owners.
// shqt	
// zscx	Redistribution and use in source and binary forms, with or without modification,
// ghfy	are permitted provided that the following conditions are met:
// phbe	
// yfod	  * Redistribution's of source code must retain the above copyright notice,
// jiit	    this list of conditions and the following disclaimer.
// zaec	
// dbbe	  * Redistribution's in binary form must reproduce the above copyright notice,
// lrws	    this list of conditions and the following disclaimer in the documentation
// pspf	    and/or other materials provided with the distribution.
// casr	
// swre	  * Neither the name of the copyright holders nor the names of its contributors 
// ihmz	    may not be used to endorse or promote products derived from this software 
// eduj	    without specific prior written permission.
// yxuz	
// nauf	This software is provided by the copyright holders and contributors "as is" and
// gbmx	any express or implied warranties, including, but not limited to, the implied
// liog	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pjbj	In no event shall the Prince of Songkla University or contributors be liable 
// qrac	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jztw	(including, but not limited to, procurement of substitute goods or services;
// oczh	loss of use, data, or profits; or business interruption) however caused
// xnus	and on any theory of liability, whether in contract, strict liability,
// xqrc	or tort (including negligence or otherwise) arising in any way out of
// gnkq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for VsIDbConnect
/// </summary>
public interface VsIDbConnect
{
    System.Collections.Generic.List<VsCamera> getCamAll();

    System.Collections.Generic.List<VsCamera> getCamHasMotion(DateTime timeBegin, DateTime timeEnd);

    bool isCamHasMotion(string cameraID, DateTime timeBegin, DateTime timeEnd);

    System.Collections.Generic.List<VsMotion> getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string cameraID);

    System.Collections.Generic.List<VsMotion> getMotionOfAllAsPeriod(DateTime timeBegin, DateTime timeEnd);

    System.Collections.Generic.List<VsMotion> getMotionOfCamAsDay(string cameraID);

    System.Collections.Generic.List<VsMotion> getMotionOfCamAsHour(string cameraID);

    VsMotion getMotionOfCamAsLast(string cameraID);

    DateTime getTimeOfLastMotion(string cameraId);

    VsFileURL getFileUrlOfMotion(string motionID, DateTime motionDateTime);

    int getNumberOfMotion(DateTime timeBegin, DateTime timeEnd, string cameraID);

    System.Collections.Generic.List<int> getNumberOfMotionInDay(DateTime timeBegin, DateTime timeEnd, string cameraID);

    System.Collections.Generic.List<int> getNumberOfMotionInMonth(DateTime timeBegin, DateTime timeEnd, string cameraID);

    System.Collections.Generic.List<int> getNumberOfMotionInYear(DateTime timeBegin, DateTime timeEnd, string cameraID);
}
