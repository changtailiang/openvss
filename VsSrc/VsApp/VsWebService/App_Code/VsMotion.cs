// jttz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// sgjv	
// cktg	 By downloading, copying, installing or using the software you agree to this license.
// wrqn	 If you do not agree to this license, do not download, install,
// hxqe	 copy or use the software.
// cezx	
// owiz	                          License Agreement
// rycc	         For OpenVss - Open Source Video Surveillance System
// hksp	
// gtei	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// sdem	
// tnwg	Third party copyrights are property of their respective owners.
// zdvi	
// wgof	Redistribution and use in source and binary forms, with or without modification,
// tvlw	are permitted provided that the following conditions are met:
// xkee	
// hqzm	  * Redistribution's of source code must retain the above copyright notice,
// yahn	    this list of conditions and the following disclaimer.
// thmy	
// amda	  * Redistribution's in binary form must reproduce the above copyright notice,
// zbzn	    this list of conditions and the following disclaimer in the documentation
// duga	    and/or other materials provided with the distribution.
// vnwl	
// hhkh	  * Neither the name of the copyright holders nor the names of its contributors 
// zafd	    may not be used to endorse or promote products derived from this software 
// ojhz	    without specific prior written permission.
// wipo	
// upfg	This software is provided by the copyright holders and contributors "as is" and
// rlww	any express or implied warranties, including, but not limited to, the implied
// lqbn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kzql	In no event shall the Prince of Songkla University or contributors be liable 
// ewfl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wezz	(including, but not limited to, procurement of substitute goods or services;
// halp	loss of use, data, or profits; or business interruption) however caused
// uarv	and on any theory of liability, whether in contract, strict liability,
// ergf	or tort (including negligence or otherwise) arising in any way out of
// iptw	the use of this software, even if advised of the possibility of such damage.

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
