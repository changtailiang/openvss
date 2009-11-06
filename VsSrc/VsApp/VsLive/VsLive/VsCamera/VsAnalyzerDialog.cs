// avlk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ccnp	
// ikpv	 By downloading, copying, installing or using the software you agree to this license.
// zllf	 If you do not agree to this license, do not download, install,
// pshd	 copy or use the software.
// unhv	
// kpee	                          License Agreement
// rblt	         For OpenVss - Open Source Video Surveillance System
// xdre	
// tvvk	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// azar	
// bwaq	Third party copyrights are property of their respective owners.
// fzlk	
// stom	Redistribution and use in source and binary forms, with or without modification,
// nqzn	are permitted provided that the following conditions are met:
// yjyg	
// ywyw	  * Redistribution's of source code must retain the above copyright notice,
// uhlt	    this list of conditions and the following disclaimer.
// xwcu	
// mpto	  * Redistribution's in binary form must reproduce the above copyright notice,
// onyr	    this list of conditions and the following disclaimer in the documentation
// qbbd	    and/or other materials provided with the distribution.
// peqd	
// wimr	  * Neither the name of the copyright holders nor the names of its contributors 
// ausf	    may not be used to endorse or promote products derived from this software 
// yewy	    without specific prior written permission.
// ornv	
// rtax	This software is provided by the copyright holders and contributors "as is" and
// wlyk	any express or implied warranties, including, but not limited to, the implied
// lhpx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uuhp	In no event shall the Prince of Songkla University or contributors be liable 
// qhxo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// klts	(including, but not limited to, procurement of substitute goods or services;
// wnpk	loss of use, data, or profits; or business interruption) however caused
// rzdz	and on any theory of liability, whether in contract, strict liability,
// ogmv	or tort (including negligence or otherwise) arising in any way out of
// etgk	the use of this software, even if advised of the possibility of such damage.

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


