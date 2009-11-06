// xrdi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yrvy	
// ozad	 By downloading, copying, installing or using the software you agree to this license.
// invh	 If you do not agree to this license, do not download, install,
// sbck	 copy or use the software.
// ymvp	
// vsrt	                          License Agreement
// qhrs	         For OpenVss - Open Source Video Surveillance System
// affp	
// hzay	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ycbx	
// uwgn	Third party copyrights are property of their respective owners.
// zhpt	
// jxtk	Redistribution and use in source and binary forms, with or without modification,
// wonf	are permitted provided that the following conditions are met:
// abih	
// hicd	  * Redistribution's of source code must retain the above copyright notice,
// hfat	    this list of conditions and the following disclaimer.
// bdlw	
// lxvz	  * Redistribution's in binary form must reproduce the above copyright notice,
// meti	    this list of conditions and the following disclaimer in the documentation
// syic	    and/or other materials provided with the distribution.
// lutt	
// muxw	  * Neither the name of the copyright holders nor the names of its contributors 
// tuql	    may not be used to endorse or promote products derived from this software 
// tcfu	    without specific prior written permission.
// gwrf	
// mxzy	This software is provided by the copyright holders and contributors "as is" and
// snsw	any express or implied warranties, including, but not limited to, the implied
// hzoi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zarm	In no event shall the Prince of Songkla University or contributors be liable 
// lhhg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fpcr	(including, but not limited to, procurement of substitute goods or services;
// hjgj	loss of use, data, or profits; or business interruption) however caused
// yzcv	and on any theory of liability, whether in contract, strict liability,
// hdqo	or tort (including negligence or otherwise) arising in any way out of
// vvay	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	public class VsCameraPropertiesDialog : VsDialogWizard
	{
        private VsCoreServer vsCoreMonitor;
		private VsCameraDescription	    vsCameraDescription = new VsCameraDescription();
		private VsCameraSettings		vsCameraSetting = new VsCameraSettings();
        private VsAnalyzerSettings      vsAnalyzerSetting = new VsAnalyzerSettings();
        private VsEncoderSettings       vsEncoderSetting = new VsEncoderSettings();

		// Construction
        public VsCameraPropertiesDialog(VsCoreServer vsCore)
		{
			this.AddPage(vsCameraDescription);
			this.AddPage(vsCameraSetting);
            this.AddPage(vsAnalyzerSetting);
            this.AddPage(vsEncoderSetting);
            this.Text = "Add New Camera";

            // set current core
            vsCoreMonitor = vsCore;
            vsCameraDescription.CoreMonitor = vsCore;
            vsCameraSetting.CoreMonitor = vsCore;
            vsAnalyzerSetting.CoreMonitor = vsCore;
            vsEncoderSetting.CoreMonitor = vsCore;
        }

	}
}

