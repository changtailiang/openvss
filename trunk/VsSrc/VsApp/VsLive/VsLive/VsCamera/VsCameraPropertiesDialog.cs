// asjy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// aexf	
// qfgx	 By downloading, copying, installing or using the software you agree to this license.
// xzoo	 If you do not agree to this license, do not download, install,
// bzqm	 copy or use the software.
// mkzi	
// gabu	                          License Agreement
// zzkb	         For OpenVss - Open Source Video Surveillance System
// wtcd	
// lmqs	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bzvq	
// pquw	Third party copyrights are property of their respective owners.
// pzuk	
// inzp	Redistribution and use in source and binary forms, with or without modification,
// tbrz	are permitted provided that the following conditions are met:
// cdgr	
// veae	  * Redistribution's of source code must retain the above copyright notice,
// xkco	    this list of conditions and the following disclaimer.
// jxkm	
// oitq	  * Redistribution's in binary form must reproduce the above copyright notice,
// fffa	    this list of conditions and the following disclaimer in the documentation
// eztj	    and/or other materials provided with the distribution.
// umkk	
// vqqx	  * Neither the name of the copyright holders nor the names of its contributors 
// teuk	    may not be used to endorse or promote products derived from this software 
// pqye	    without specific prior written permission.
// wgbk	
// cmak	This software is provided by the copyright holders and contributors "as is" and
// ibuw	any express or implied warranties, including, but not limited to, the implied
// xgnw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lqkl	In no event shall the Prince of Songkla University or contributors be liable 
// zsts	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hmsk	(including, but not limited to, procurement of substitute goods or services;
// niap	loss of use, data, or profits; or business interruption) however caused
// hbdy	and on any theory of liability, whether in contract, strict liability,
// xihh	or tort (including negligence or otherwise) arising in any way out of
// lact	the use of this software, even if advised of the possibility of such damage.

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

