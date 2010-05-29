// fqyu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gknl	
// fgad	 By downloading, copying, installing or using the software you agree to this license.
// gtuk	 If you do not agree to this license, do not download, install,
// trhp	 copy or use the software.
// vvne	
// mfkp	                          License Agreement
// uvvx	         For OpenVSS - Open Source Video Surveillance System
// hrbc	
// sehw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ckcd	
// ijvo	Third party copyrights are property of their respective owners.
// flli	
// fplk	Redistribution and use in source and binary forms, with or without modification,
// dtha	are permitted provided that the following conditions are met:
// axrj	
// ldvp	  * Redistribution's of source code must retain the above copyright notice,
// rsso	    this list of conditions and the following disclaimer.
// kknl	
// tjwc	  * Redistribution's in binary form must reproduce the above copyright notice,
// kvjj	    this list of conditions and the following disclaimer in the documentation
// jmrr	    and/or other materials provided with the distribution.
// fqyz	
// xgwe	  * Neither the name of the copyright holders nor the names of its contributors 
// tssf	    may not be used to endorse or promote products derived from this software 
// ngwn	    without specific prior written permission.
// txyu	
// cart	This software is provided by the copyright holders and contributors "as is" and
// weqe	any express or implied warranties, including, but not limited to, the implied
// nhay	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ldja	In no event shall the Prince of Songkla University or contributors be liable 
// ttre	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ojsa	(including, but not limited to, procurement of substitute goods or services;
// rrpe	loss of use, data, or profits; or business interruption) however caused
// zwql	and on any theory of liability, whether in contract, strict liability,
// owpf	or tort (including negligence or otherwise) arising in any way out of
// zfcs	the use of this software, even if advised of the possibility of such damage.
// prql	
// rttj	Intelligent Systems Laboratory (iSys Lab)
// wvuz	Faculty of Engineering, Prince of Songkla University, THAILAND
// gtgs	Project leader by Nikom SUVONVORN
// iqcf	Project website at http://code.google.com/p/openvss/

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
