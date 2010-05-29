// txfz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lbxx	
// yrto	 By downloading, copying, installing or using the software you agree to this license.
// xqbg	 If you do not agree to this license, do not download, install,
// ufns	 copy or use the software.
// vibj	
// cijd	                          License Agreement
// wsuw	         For OpenVSS - Open Source Video Surveillance System
// ouoc	
// aemk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jhfv	
// uzoj	Third party copyrights are property of their respective owners.
// hsoi	
// jekl	Redistribution and use in source and binary forms, with or without modification,
// vwxc	are permitted provided that the following conditions are met:
// stbf	
// wwzd	  * Redistribution's of source code must retain the above copyright notice,
// bygp	    this list of conditions and the following disclaimer.
// sdjn	
// cgod	  * Redistribution's in binary form must reproduce the above copyright notice,
// uzve	    this list of conditions and the following disclaimer in the documentation
// dmnk	    and/or other materials provided with the distribution.
// jdge	
// hkrp	  * Neither the name of the copyright holders nor the names of its contributors 
// gzyx	    may not be used to endorse or promote products derived from this software 
// zlhj	    without specific prior written permission.
// myqf	
// uwip	This software is provided by the copyright holders and contributors "as is" and
// huhs	any express or implied warranties, including, but not limited to, the implied
// yxbk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// joty	In no event shall the Prince of Songkla University or contributors be liable 
// rbih	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ltgd	(including, but not limited to, procurement of substitute goods or services;
// hqdj	loss of use, data, or profits; or business interruption) however caused
// smsf	and on any theory of liability, whether in contract, strict liability,
// whpm	or tort (including negligence or otherwise) arising in any way out of
// urwn	the use of this software, even if advised of the possibility of such damage.
// dzrj	
// xook	Intelligent Systems Laboratory (iSys Lab)
// rjrk	Faculty of Engineering, Prince of Songkla University, THAILAND
// qiub	Project leader by Nikom SUVONVORN
// qfir	Project website at http://code.google.com/p/openvss/

namespace Vs.Core.Provider
{
	using System;
	using System.Drawing.Imaging;

	// FrameOut delegate
	public delegate void CameraEventHandler(object sender, CameraEventArgs e);

	/// <summary>
	/// Camera event arguments
	/// </summary>
	public class CameraEventArgs : EventArgs
	{
		private System.Drawing.Bitmap bmp;

		// Constructor
		public CameraEventArgs(System.Drawing.Bitmap bmp)
		{
			this.bmp = bmp;
		}

		// Bitmap property
		public System.Drawing.Bitmap Bitmap
		{
			get { return bmp; }
		}
	}
}
