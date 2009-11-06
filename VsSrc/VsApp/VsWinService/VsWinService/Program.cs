// dtjf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// coeg	
// qrlt	 By downloading, copying, installing or using the software you agree to this license.
// bzdh	 If you do not agree to this license, do not download, install,
// gpze	 copy or use the software.
// kecc	
// bhbz	                          License Agreement
// tfmj	         For OpenVss - Open Source Video Surveillance System
// nopi	
// ruzp	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bjrh	
// mphk	Third party copyrights are property of their respective owners.
// thez	
// jzfz	Redistribution and use in source and binary forms, with or without modification,
// qgev	are permitted provided that the following conditions are met:
// nfnl	
// fbfm	  * Redistribution's of source code must retain the above copyright notice,
// jvpm	    this list of conditions and the following disclaimer.
// pjda	
// muql	  * Redistribution's in binary form must reproduce the above copyright notice,
// arfl	    this list of conditions and the following disclaimer in the documentation
// anao	    and/or other materials provided with the distribution.
// jqrk	
// pecw	  * Neither the name of the copyright holders nor the names of its contributors 
// wfck	    may not be used to endorse or promote products derived from this software 
// juay	    without specific prior written permission.
// ssja	
// vemv	This software is provided by the copyright holders and contributors "as is" and
// qsuv	any express or implied warranties, including, but not limited to, the implied
// zclr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// brdt	In no event shall the Prince of Songkla University or contributors be liable 
// dewk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hheh	(including, but not limited to, procurement of substitute goods or services;
// sfcg	loss of use, data, or profits; or business interruption) however caused
// qgsi	and on any theory of liability, whether in contract, strict liability,
// dase	or tort (including negligence or otherwise) arising in any way out of
// dwuw	the use of this software, even if advised of the possibility of such damage.

using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace Vs.WinService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new VsWinService() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}
