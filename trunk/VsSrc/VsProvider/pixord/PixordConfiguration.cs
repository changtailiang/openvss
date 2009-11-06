// xfpg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mxzr	
// urna	 By downloading, copying, installing or using the software you agree to this license.
// mewu	 If you do not agree to this license, do not download, install,
// etgd	 copy or use the software.
// cpog	
// iknm	                          License Agreement
// pbmt	         For OpenVss - Open Source Video Surveillance System
// nnaw	
// rilc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vdcp	
// kdha	Third party copyrights are property of their respective owners.
// tmua	
// njui	Redistribution and use in source and binary forms, with or without modification,
// rixc	are permitted provided that the following conditions are met:
// jnbs	
// ftnz	  * Redistribution's of source code must retain the above copyright notice,
// dacv	    this list of conditions and the following disclaimer.
// iehy	
// mzvf	  * Redistribution's in binary form must reproduce the above copyright notice,
// cnsd	    this list of conditions and the following disclaimer in the documentation
// hmgd	    and/or other materials provided with the distribution.
// ssei	
// ljsi	  * Neither the name of the copyright holders nor the names of its contributors 
// bkjq	    may not be used to endorse or promote products derived from this software 
// piwt	    without specific prior written permission.
// jyrj	
// cvws	This software is provided by the copyright holders and contributors "as is" and
// mrzw	any express or implied warranties, including, but not limited to, the implied
// uykt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// njgl	In no event shall the Prince of Songkla University or contributors be liable 
// vtky	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lzwb	(including, but not limited to, procurement of substitute goods or services;
// pfpt	loss of use, data, or profits; or business interruption) however caused
// ryti	and on any theory of liability, whether in contract, strict liability,
// uxbx	or tort (including negligence or otherwise) arising in any way out of
// vmvt	the use of this software, even if advised of the possibility of such damage.

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
