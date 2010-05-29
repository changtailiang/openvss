// vrwp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// drhr	
// gwnv	 By downloading, copying, installing or using the software you agree to this license.
// qokt	 If you do not agree to this license, do not download, install,
// ihsq	 copy or use the software.
// nmej	
// ewyz	                          License Agreement
// lcfz	         For OpenVSS - Open Source Video Surveillance System
// hhvy	
// wejg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// obzv	
// ayzi	Third party copyrights are property of their respective owners.
// cxnf	
// suuj	Redistribution and use in source and binary forms, with or without modification,
// nnlg	are permitted provided that the following conditions are met:
// tifd	
// qnnj	  * Redistribution's of source code must retain the above copyright notice,
// tmxd	    this list of conditions and the following disclaimer.
// xmcl	
// miif	  * Redistribution's in binary form must reproduce the above copyright notice,
// wpwo	    this list of conditions and the following disclaimer in the documentation
// pzhn	    and/or other materials provided with the distribution.
// nlki	
// scmg	  * Neither the name of the copyright holders nor the names of its contributors 
// wvfm	    may not be used to endorse or promote products derived from this software 
// lqpq	    without specific prior written permission.
// zjig	
// riwe	This software is provided by the copyright holders and contributors "as is" and
// egjd	any express or implied warranties, including, but not limited to, the implied
// lroq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gawi	In no event shall the Prince of Songkla University or contributors be liable 
// bolv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zwpr	(including, but not limited to, procurement of substitute goods or services;
// dvug	loss of use, data, or profits; or business interruption) however caused
// afog	and on any theory of liability, whether in contract, strict liability,
// rave	or tort (including negligence or otherwise) arising in any way out of
// ofem	the use of this software, even if advised of the possibility of such damage.
// sjuf	
// gogk	Intelligent Systems Laboratory (iSys Lab)
// uhpl	Faculty of Engineering, Prince of Songkla University, THAILAND
// ynhv	Project leader by Nikom SUVONVORN
// tfbi	Project website at http://code.google.com/p/openvss/

namespace VdPixord
{
	using System;
    using Vs.Core.Provider;

	/// <summary>
	/// PixordConfiguration
	/// </summary>
	public class PixordConfiguration
	{
		public string	source;
		public string	login;
		public string	password;
		public int		frameInterval = 0;
		public StreamType	stremType = StreamType.Jpeg;
		public string	resolution;
	}
}
