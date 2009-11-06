// kzvh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// isuv	
// huvc	 By downloading, copying, installing or using the software you agree to this license.
// vedd	 If you do not agree to this license, do not download, install,
// gwck	 copy or use the software.
// wfil	
// guhc	                          License Agreement
// fdhc	         For OpenVss - Open Source Video Surveillance System
// iami	
// wvwi	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ewjj	
// diwl	Third party copyrights are property of their respective owners.
// ryit	
// yvze	Redistribution and use in source and binary forms, with or without modification,
// qjbo	are permitted provided that the following conditions are met:
// lspe	
// mstv	  * Redistribution's of source code must retain the above copyright notice,
// ruhl	    this list of conditions and the following disclaimer.
// ztgz	
// wzhx	  * Redistribution's in binary form must reproduce the above copyright notice,
// yvlg	    this list of conditions and the following disclaimer in the documentation
// uoen	    and/or other materials provided with the distribution.
// airm	
// tixm	  * Neither the name of the copyright holders nor the names of its contributors 
// gewl	    may not be used to endorse or promote products derived from this software 
// oauw	    without specific prior written permission.
// rxte	
// ozir	This software is provided by the copyright holders and contributors "as is" and
// bdpp	any express or implied warranties, including, but not limited to, the implied
// hijy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nguj	In no event shall the Prince of Songkla University or contributors be liable 
// durr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wtsr	(including, but not limited to, procurement of substitute goods or services;
// cwix	loss of use, data, or profits; or business interruption) however caused
// bopx	and on any theory of liability, whether in contract, strict liability,
// uayb	or tort (including negligence or otherwise) arising in any way out of
// aakp	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	public class VsAnalyzerDialog : VsPageWizard
	{
        private VsCoreServer vsCoreMonitor;
        private VsCamera vsCamera;
        private VsAnalyzerSettings      vsAnalyzerSetting = new VsAnalyzerSettings();

        public VsCamera Camera
        {
            get { return vsCamera; }
            set { vsCamera = value; }
        }

		// Construction
		public VsAnalyzerDialog(VsCoreServer vsCore, VsCamera vsCam)
		{
            this.AddPage(vsAnalyzerSetting);
            vsAnalyzerSetting.CoreMonitor = vsCoreMonitor;
            vsAnalyzerSetting.Camera = vsCam;

            // set current core
            vsCamera = vsCam;
            vsCoreMonitor = vsCore;

            this.Text = "Analyzer";
            this.buttonApply.Visible = true;
            this.backButton.Visible = false;
            this.nextButton.Visible = false;
            this.imagePanel.Visible = false;
        }

		// On page changing
		protected override void OnPageChanging(int page)
		{
			if (page == 1)
			{
            }
			base.OnPageChanging(page);
		}

		// Reset event ocuren on page
		protected override void OnResetOnPage(int page)
		{
			if (page == 0)
			{
                this.RemovePage(vsAnalyzerSetting);
            }
		}

		// On finish
		protected override void OnFinish()
		{
            // add camera to camera list
            ///vsCoreMonitor.AddCamera(vsCamera);
		}
	}
}


