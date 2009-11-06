// ijrc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nyra	
// xxum	 By downloading, copying, installing or using the software you agree to this license.
// wiyb	 If you do not agree to this license, do not download, install,
// rrjo	 copy or use the software.
// afcr	
// ynbd	                          License Agreement
// dcwr	         For OpenVss - Open Source Video Surveillance System
// vnpe	
// sqkd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ssqv	
// okoe	Third party copyrights are property of their respective owners.
// jkyd	
// otpd	Redistribution and use in source and binary forms, with or without modification,
// gadz	are permitted provided that the following conditions are met:
// xnxv	
// bcrj	  * Redistribution's of source code must retain the above copyright notice,
// stib	    this list of conditions and the following disclaimer.
// gfvi	
// ohdo	  * Redistribution's in binary form must reproduce the above copyright notice,
// zxts	    this list of conditions and the following disclaimer in the documentation
// escb	    and/or other materials provided with the distribution.
// xmxs	
// mlgf	  * Neither the name of the copyright holders nor the names of its contributors 
// vuul	    may not be used to endorse or promote products derived from this software 
// selp	    without specific prior written permission.
// bwwj	
// xhoz	This software is provided by the copyright holders and contributors "as is" and
// woaz	any express or implied warranties, including, but not limited to, the implied
// teri	warranties of merchantability and fitness for a particular purpose are disclaimed.
// aqmg	In no event shall the Prince of Songkla University or contributors be liable 
// wpov	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yqnu	(including, but not limited to, procurement of substitute goods or services;
// nswu	loss of use, data, or profits; or business interruption) however caused
// lerh	and on any theory of liability, whether in contract, strict liability,
// wtdq	or tort (including negligence or otherwise) arising in any way out of
// xyvy	the use of this software, even if advised of the possibility of such damage.

using System;

namespace Vs.Core.Client.Command
{
    /// <summary>
    /// Throw when the remote server not found.
    /// </summary>
    public class ServerNotFoundException : Exception
    {
        /// <summary>
        /// Creates an instance of ServerNotFoundException class.
        /// </summary>
        /// <param name="message">The message to show to the user.</param>
        public ServerNotFoundException(string message): base(message)
        { }
    }
}
