// golj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qjso	
// zpyn	 By downloading, copying, installing or using the software you agree to this license.
// gimt	 If you do not agree to this license, do not download, install,
// ahpn	 copy or use the software.
// qcuh	
// bmoa	                          License Agreement
// qygx	         For OpenVss - Open Source Video Surveillance System
// enff	
// pznq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// kdgz	
// wtvz	Third party copyrights are property of their respective owners.
// kwva	
// fxxe	Redistribution and use in source and binary forms, with or without modification,
// udie	are permitted provided that the following conditions are met:
// usxa	
// jbit	  * Redistribution's of source code must retain the above copyright notice,
// cgea	    this list of conditions and the following disclaimer.
// uzdm	
// vvlh	  * Redistribution's in binary form must reproduce the above copyright notice,
// qppu	    this list of conditions and the following disclaimer in the documentation
// dfrh	    and/or other materials provided with the distribution.
// pbll	
// rivs	  * Neither the name of the copyright holders nor the names of its contributors 
// ffpv	    may not be used to endorse or promote products derived from this software 
// lbwd	    without specific prior written permission.
// rugg	
// ukjz	This software is provided by the copyright holders and contributors "as is" and
// sanf	any express or implied warranties, including, but not limited to, the implied
// ccxe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jaeb	In no event shall the Prince of Songkla University or contributors be liable 
// vtil	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dlhp	(including, but not limited to, procurement of substitute goods or services;
// fpvp	loss of use, data, or profits; or business interruption) however caused
// smdi	and on any theory of liability, whether in contract, strict liability,
// zlme	or tort (including negligence or otherwise) arising in any way out of
// rmtq	the use of this software, even if advised of the possibility of such damage.

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
