// niid	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// deqm	
// ljdy	 By downloading, copying, installing or using the software you agree to this license.
// zmxe	 If you do not agree to this license, do not download, install,
// hcxx	 copy or use the software.
// gmod	
// qgus	                          License Agreement
// uact	         For OpenVSS - Open Source Video Surveillance System
// ilux	
// lpnb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ljzq	
// szcf	Third party copyrights are property of their respective owners.
// txkt	
// bbab	Redistribution and use in source and binary forms, with or without modification,
// tenw	are permitted provided that the following conditions are met:
// kxsl	
// hjpn	  * Redistribution's of source code must retain the above copyright notice,
// rztr	    this list of conditions and the following disclaimer.
// owmw	
// mylq	  * Redistribution's in binary form must reproduce the above copyright notice,
// eoyx	    this list of conditions and the following disclaimer in the documentation
// pish	    and/or other materials provided with the distribution.
// lteh	
// brqn	  * Neither the name of the copyright holders nor the names of its contributors 
// roii	    may not be used to endorse or promote products derived from this software 
// konu	    without specific prior written permission.
// dtfe	
// pepu	This software is provided by the copyright holders and contributors "as is" and
// txsw	any express or implied warranties, including, but not limited to, the implied
// yvvy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ricy	In no event shall the Prince of Songkla University or contributors be liable 
// vmpx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fyex	(including, but not limited to, procurement of substitute goods or services;
// pcgp	loss of use, data, or profits; or business interruption) however caused
// aetw	and on any theory of liability, whether in contract, strict liability,
// dnrg	or tort (including negligence or otherwise) arising in any way out of
// djne	the use of this software, even if advised of the possibility of such damage.
// yuow	
// tjrb	Intelligent Systems Laboratory (iSys Lab)
// lpzr	Faculty of Engineering, Prince of Songkla University, THAILAND
// dhzq	Project leader by Nikom SUVONVORN
// zrfr	Project website at http://code.google.com/p/openvss/

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


