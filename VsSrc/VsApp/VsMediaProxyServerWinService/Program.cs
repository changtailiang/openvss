// wnhu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qcdd	
// pmpj	 By downloading, copying, installing or using the software you agree to this license.
// wppc	 If you do not agree to this license, do not download, install,
// aohv	 copy or use the software.
// yxse	
// zhlo	                          License Agreement
// iuqu	         For OpenVSS - Open Source Video Surveillance System
// jqkp	
// nnbg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// atvl	
// znov	Third party copyrights are property of their respective owners.
// onqp	
// zadz	Redistribution and use in source and binary forms, with or without modification,
// vcvj	are permitted provided that the following conditions are met:
// rpuv	
// wuag	  * Redistribution's of source code must retain the above copyright notice,
// ezpn	    this list of conditions and the following disclaimer.
// nbue	
// bhem	  * Redistribution's in binary form must reproduce the above copyright notice,
// tpzv	    this list of conditions and the following disclaimer in the documentation
// davi	    and/or other materials provided with the distribution.
// mluk	
// srol	  * Neither the name of the copyright holders nor the names of its contributors 
// zaof	    may not be used to endorse or promote products derived from this software 
// mhqo	    without specific prior written permission.
// xdcx	
// gzyo	This software is provided by the copyright holders and contributors "as is" and
// yiqb	any express or implied warranties, including, but not limited to, the implied
// pzrw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ystt	In no event shall the Prince of Songkla University or contributors be liable 
// ffuv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// njfa	(including, but not limited to, procurement of substitute goods or services;
// szzl	loss of use, data, or profits; or business interruption) however caused
// zlxa	and on any theory of liability, whether in contract, strict liability,
// xxcn	or tort (including negligence or otherwise) arising in any way out of
// mglj	the use of this software, even if advised of the possibility of such damage.
// bmvz	
// jsgu	Intelligent Systems Laboratory (iSys Lab)
// owjs	Faculty of Engineering, Prince of Songkla University, THAILAND
// igkx	Project leader by Nikom SUVONVORN
// txvy	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.ServiceProcess;
using System.Text;

namespace VsMediaProxyServerWinService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new VsMediaProxyServerWinService()
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
