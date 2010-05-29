// bknk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wuww	
// dosy	 By downloading, copying, installing or using the software you agree to this license.
// otps	 If you do not agree to this license, do not download, install,
// jmjh	 copy or use the software.
// gevx	
// rxvq	                          License Agreement
// rgwl	         For OpenVSS - Open Source Video Surveillance System
// cihq	
// wtrq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dknh	
// jekn	Third party copyrights are property of their respective owners.
// doxk	
// msqw	Redistribution and use in source and binary forms, with or without modification,
// pqsy	are permitted provided that the following conditions are met:
// ygex	
// sgwg	  * Redistribution's of source code must retain the above copyright notice,
// lzvq	    this list of conditions and the following disclaimer.
// utev	
// rnon	  * Redistribution's in binary form must reproduce the above copyright notice,
// mhmc	    this list of conditions and the following disclaimer in the documentation
// ilzk	    and/or other materials provided with the distribution.
// rkbg	
// asrw	  * Neither the name of the copyright holders nor the names of its contributors 
// fqoc	    may not be used to endorse or promote products derived from this software 
// idce	    without specific prior written permission.
// thqt	
// nufb	This software is provided by the copyright holders and contributors "as is" and
// cfmr	any express or implied warranties, including, but not limited to, the implied
// tboh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hlpb	In no event shall the Prince of Songkla University or contributors be liable 
// xppb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// biqb	(including, but not limited to, procurement of substitute goods or services;
// ylei	loss of use, data, or profits; or business interruption) however caused
// fijb	and on any theory of liability, whether in contract, strict liability,
// ufww	or tort (including negligence or otherwise) arising in any way out of
// ezdv	the use of this software, even if advised of the possibility of such damage.
// gacd	
// bhvw	Intelligent Systems Laboratory (iSys Lab)
// oagd	Faculty of Engineering, Prince of Songkla University, THAILAND
// sprf	Project leader by Nikom SUVONVORN
// eecq	Project website at http://code.google.com/p/openvss/

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
