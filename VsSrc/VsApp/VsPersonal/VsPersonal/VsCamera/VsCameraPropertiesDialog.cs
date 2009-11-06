// yvma	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ctsc	
// aiyb	 By downloading, copying, installing or using the software you agree to this license.
// dwap	 If you do not agree to this license, do not download, install,
// sscn	 copy or use the software.
// aivn	
// seif	                          License Agreement
// jtwn	         For OpenVss - Open Source Video Surveillance System
// qbkg	
// hcem	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ibmk	
// byhf	Third party copyrights are property of their respective owners.
// kboe	
// coep	Redistribution and use in source and binary forms, with or without modification,
// zzhx	are permitted provided that the following conditions are met:
// knth	
// mllc	  * Redistribution's of source code must retain the above copyright notice,
// muiq	    this list of conditions and the following disclaimer.
// npez	
// wklt	  * Redistribution's in binary form must reproduce the above copyright notice,
// xdui	    this list of conditions and the following disclaimer in the documentation
// frlb	    and/or other materials provided with the distribution.
// wvgh	
// uhbv	  * Neither the name of the copyright holders nor the names of its contributors 
// heyp	    may not be used to endorse or promote products derived from this software 
// nftq	    without specific prior written permission.
// sxrm	
// jeto	This software is provided by the copyright holders and contributors "as is" and
// noah	any express or implied warranties, including, but not limited to, the implied
// slbu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ajfq	In no event shall the Prince of Songkla University or contributors be liable 
// nawg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ojrr	(including, but not limited to, procurement of substitute goods or services;
// mvfs	loss of use, data, or profits; or business interruption) however caused
// kdph	and on any theory of liability, whether in contract, strict liability,
// aysr	or tort (including negligence or otherwise) arising in any way out of
// bruf	the use of this software, even if advised of the possibility of such damage.

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

