// zctw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mzyt	
// zclg	 By downloading, copying, installing or using the software you agree to this license.
// aukb	 If you do not agree to this license, do not download, install,
// otzu	 copy or use the software.
// emwi	
// cgbq	                          License Agreement
// ikxf	         For OpenVSS - Open Source Video Surveillance System
// nvor	
// mvnv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qyjq	
// uhzh	Third party copyrights are property of their respective owners.
// svrm	
// phvm	Redistribution and use in source and binary forms, with or without modification,
// glug	are permitted provided that the following conditions are met:
// xhlp	
// ffse	  * Redistribution's of source code must retain the above copyright notice,
// gsot	    this list of conditions and the following disclaimer.
// fedf	
// cfou	  * Redistribution's in binary form must reproduce the above copyright notice,
// gtym	    this list of conditions and the following disclaimer in the documentation
// skqf	    and/or other materials provided with the distribution.
// ablb	
// bgxi	  * Neither the name of the copyright holders nor the names of its contributors 
// nulo	    may not be used to endorse or promote products derived from this software 
// puaz	    without specific prior written permission.
// hyhk	
// eqja	This software is provided by the copyright holders and contributors "as is" and
// wzze	any express or implied warranties, including, but not limited to, the implied
// jyxu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pmef	In no event shall the Prince of Songkla University or contributors be liable 
// hmsz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// husi	(including, but not limited to, procurement of substitute goods or services;
// uzfm	loss of use, data, or profits; or business interruption) however caused
// syft	and on any theory of liability, whether in contract, strict liability,
// dgbj	or tort (including negligence or otherwise) arising in any way out of
// rkfb	the use of this software, even if advised of the possibility of such damage.
// gszo	
// xqzc	Intelligent Systems Laboratory (iSys Lab)
// pvsu	Faculty of Engineering, Prince of Songkla University, THAILAND
// ghdj	Project leader by Nikom SUVONVORN
// xbfw	Project website at http://code.google.com/p/openvss/

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

