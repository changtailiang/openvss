// orwp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oysf	
// ltzt	 By downloading, copying, installing or using the software you agree to this license.
// ygio	 If you do not agree to this license, do not download, install,
// lbwr	 copy or use the software.
// wlne	
// lwai	                          License Agreement
// dggs	         For OpenVSS - Open Source Video Surveillance System
// oxti	
// xuiw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mjtx	
// axvn	Third party copyrights are property of their respective owners.
// ssym	
// fuuc	Redistribution and use in source and binary forms, with or without modification,
// drer	are permitted provided that the following conditions are met:
// xjbe	
// ngfa	  * Redistribution's of source code must retain the above copyright notice,
// mzrq	    this list of conditions and the following disclaimer.
// taen	
// rqeo	  * Redistribution's in binary form must reproduce the above copyright notice,
// bnql	    this list of conditions and the following disclaimer in the documentation
// iunu	    and/or other materials provided with the distribution.
// dref	
// qqyc	  * Neither the name of the copyright holders nor the names of its contributors 
// ioku	    may not be used to endorse or promote products derived from this software 
// rvas	    without specific prior written permission.
// ahte	
// phln	This software is provided by the copyright holders and contributors "as is" and
// nqqj	any express or implied warranties, including, but not limited to, the implied
// tqws	warranties of merchantability and fitness for a particular purpose are disclaimed.
// slxv	In no event shall the Prince of Songkla University or contributors be liable 
// ulac	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bcec	(including, but not limited to, procurement of substitute goods or services;
// fjwf	loss of use, data, or profits; or business interruption) however caused
// myka	and on any theory of liability, whether in contract, strict liability,
// bifw	or tort (including negligence or otherwise) arising in any way out of
// frrz	the use of this software, even if advised of the possibility of such damage.
// zojs	
// srbg	Intelligent Systems Laboratory (iSys Lab)
// xfxp	Faculty of Engineering, Prince of Songkla University, THAILAND
// hqdm	Project leader by Nikom SUVONVORN
// ciie	Project website at http://code.google.com/p/openvss/

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

