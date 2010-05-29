// grcy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ipmr	
// zwrn	 By downloading, copying, installing or using the software you agree to this license.
// svbt	 If you do not agree to this license, do not download, install,
// vroy	 copy or use the software.
// uazn	
// qeil	                          License Agreement
// tglu	         For OpenVSS - Open Source Video Surveillance System
// trkb	
// kiya	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jwju	
// puye	Third party copyrights are property of their respective owners.
// iqvn	
// cgqf	Redistribution and use in source and binary forms, with or without modification,
// spid	are permitted provided that the following conditions are met:
// haxs	
// kwtb	  * Redistribution's of source code must retain the above copyright notice,
// kajm	    this list of conditions and the following disclaimer.
// topx	
// rfxv	  * Redistribution's in binary form must reproduce the above copyright notice,
// gddd	    this list of conditions and the following disclaimer in the documentation
// lysn	    and/or other materials provided with the distribution.
// afjv	
// auti	  * Neither the name of the copyright holders nor the names of its contributors 
// zqjt	    may not be used to endorse or promote products derived from this software 
// bwui	    without specific prior written permission.
// hiuo	
// rtnm	This software is provided by the copyright holders and contributors "as is" and
// rmwd	any express or implied warranties, including, but not limited to, the implied
// xuhm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// egaf	In no event shall the Prince of Songkla University or contributors be liable 
// qnmy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vgyb	(including, but not limited to, procurement of substitute goods or services;
// weuk	loss of use, data, or profits; or business interruption) however caused
// jvwc	and on any theory of liability, whether in contract, strict liability,
// edvh	or tort (including negligence or otherwise) arising in any way out of
// rwen	the use of this software, even if advised of the possibility of such damage.
// yplf	
// jwou	Intelligent Systems Laboratory (iSys Lab)
// vort	Faculty of Engineering, Prince of Songkla University, THAILAND
// vvtl	Project leader by Nikom SUVONVORN
// umqn	Project website at http://code.google.com/p/openvss/

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
