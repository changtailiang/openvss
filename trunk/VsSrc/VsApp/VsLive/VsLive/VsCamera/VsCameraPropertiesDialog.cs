// uiwe	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vexd	
// jooi	 By downloading, copying, installing or using the software you agree to this license.
// vooh	 If you do not agree to this license, do not download, install,
// yvie	 copy or use the software.
// zhqs	
// rmgv	                          License Agreement
// xslh	         For OpenVSS - Open Source Video Surveillance System
// xbcm	
// dunv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hnhm	
// ckzg	Third party copyrights are property of their respective owners.
// kewz	
// jxkm	Redistribution and use in source and binary forms, with or without modification,
// seni	are permitted provided that the following conditions are met:
// ycgr	
// dhkt	  * Redistribution's of source code must retain the above copyright notice,
// lcee	    this list of conditions and the following disclaimer.
// inxl	
// zdqg	  * Redistribution's in binary form must reproduce the above copyright notice,
// nzks	    this list of conditions and the following disclaimer in the documentation
// wlyz	    and/or other materials provided with the distribution.
// rpuz	
// hfwe	  * Neither the name of the copyright holders nor the names of its contributors 
// hpju	    may not be used to endorse or promote products derived from this software 
// agvi	    without specific prior written permission.
// asrv	
// azno	This software is provided by the copyright holders and contributors "as is" and
// nguz	any express or implied warranties, including, but not limited to, the implied
// sovr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jlbv	In no event shall the Prince of Songkla University or contributors be liable 
// hfwd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qsdk	(including, but not limited to, procurement of substitute goods or services;
// uvgg	loss of use, data, or profits; or business interruption) however caused
// dbse	and on any theory of liability, whether in contract, strict liability,
// ucys	or tort (including negligence or otherwise) arising in any way out of
// cfla	the use of this software, even if advised of the possibility of such damage.
// kxmt	
// urlo	Intelligent Systems Laboratory (iSys Lab)
// faau	Faculty of Engineering, Prince of Songkla University, THAILAND
// vnfh	Project leader by Nikom SUVONVORN
// vcus	Project website at http://code.google.com/p/openvss/

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

