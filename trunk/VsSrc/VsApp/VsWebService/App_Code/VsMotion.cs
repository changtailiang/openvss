// rmuc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xeia	
// ltnt	 By downloading, copying, installing or using the software you agree to this license.
// jzzf	 If you do not agree to this license, do not download, install,
// vtsz	 copy or use the software.
// paou	
// dcgi	                          License Agreement
// kjme	         For OpenVSS - Open Source Video Surveillance System
// grvm	
// vihe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// onjc	
// axkw	Third party copyrights are property of their respective owners.
// vnqb	
// urxr	Redistribution and use in source and binary forms, with or without modification,
// yzyv	are permitted provided that the following conditions are met:
// xzpb	
// gjns	  * Redistribution's of source code must retain the above copyright notice,
// dnkm	    this list of conditions and the following disclaimer.
// mnkc	
// qltg	  * Redistribution's in binary form must reproduce the above copyright notice,
// skmx	    this list of conditions and the following disclaimer in the documentation
// tlkp	    and/or other materials provided with the distribution.
// udov	
// klgo	  * Neither the name of the copyright holders nor the names of its contributors 
// yivr	    may not be used to endorse or promote products derived from this software 
// krti	    without specific prior written permission.
// ddpg	
// gubm	This software is provided by the copyright holders and contributors "as is" and
// gsdn	any express or implied warranties, including, but not limited to, the implied
// nshv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yyyz	In no event shall the Prince of Songkla University or contributors be liable 
// zoba	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hvdi	(including, but not limited to, procurement of substitute goods or services;
// pbva	loss of use, data, or profits; or business interruption) however caused
// reuq	and on any theory of liability, whether in contract, strict liability,
// vdiz	or tort (including negligence or otherwise) arising in any way out of
// cbps	the use of this software, even if advised of the possibility of such damage.
// isbf	
// aatm	Intelligent Systems Laboratory (iSys Lab)
// ttio	Faculty of Engineering, Prince of Songkla University, THAILAND
// bpzk	Project leader by Nikom SUVONVORN
// rswe	Project website at http://code.google.com/p/openvss/

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
/// Summary description for VsMotion
/// </summary>
public class VsMotion //from report
{
    public int MotionID; // from r_id (report id)
    
    public string cameraID;// from r_ip_camera
    public string processor;// r_ip_processor(string)
    
    //public string File; //from r_file_name 
    //public int r_file_size;
    //public string r_file_location;

    public string r_algo_name;
   
    //public string r_enc_name;
    //public string r_enc_codecs;

    public DateTime timeBegin;//from r_date_start
    public DateTime timeEnd;//from r_date_end

    public string r_detail;


}
