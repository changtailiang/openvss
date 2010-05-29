// vxgj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mwyj	
// zwla	 By downloading, copying, installing or using the software you agree to this license.
// tzvg	 If you do not agree to this license, do not download, install,
// esqn	 copy or use the software.
// prhu	
// yzfl	                          License Agreement
// leck	         For OpenVSS - Open Source Video Surveillance System
// xgsv	
// zpgn	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lxsr	
// laop	Third party copyrights are property of their respective owners.
// waev	
// qhbd	Redistribution and use in source and binary forms, with or without modification,
// pmkm	are permitted provided that the following conditions are met:
// qmyv	
// tacm	  * Redistribution's of source code must retain the above copyright notice,
// haho	    this list of conditions and the following disclaimer.
// mccr	
// zqiy	  * Redistribution's in binary form must reproduce the above copyright notice,
// lppk	    this list of conditions and the following disclaimer in the documentation
// zgtp	    and/or other materials provided with the distribution.
// eofn	
// etwy	  * Neither the name of the copyright holders nor the names of its contributors 
// zwxl	    may not be used to endorse or promote products derived from this software 
// xciv	    without specific prior written permission.
// tpjo	
// fkdy	This software is provided by the copyright holders and contributors "as is" and
// dmbb	any express or implied warranties, including, but not limited to, the implied
// xown	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gnhs	In no event shall the Prince of Songkla University or contributors be liable 
// vuks	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fdsc	(including, but not limited to, procurement of substitute goods or services;
// txaj	loss of use, data, or profits; or business interruption) however caused
// gtqj	and on any theory of liability, whether in contract, strict liability,
// wfku	or tort (including negligence or otherwise) arising in any way out of
// kgjr	the use of this software, even if advised of the possibility of such damage.
// svbk	
// ajek	Intelligent Systems Laboratory (iSys Lab)
// uqay	Faculty of Engineering, Prince of Songkla University, THAILAND
// frjb	Project leader by Nikom SUVONVORN
// sbeg	Project website at http://code.google.com/p/openvss/

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

