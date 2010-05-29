// zonb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// obim	
// radz	 By downloading, copying, installing or using the software you agree to this license.
// ughv	 If you do not agree to this license, do not download, install,
// bquy	 copy or use the software.
// cjyz	
// izhx	                          License Agreement
// wjjq	         For OpenVSS - Open Source Video Surveillance System
// nchv	
// bjxe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mdkm	
// mqlj	Third party copyrights are property of their respective owners.
// uspl	
// ecmp	Redistribution and use in source and binary forms, with or without modification,
// qnto	are permitted provided that the following conditions are met:
// tkqh	
// rnmr	  * Redistribution's of source code must retain the above copyright notice,
// ymtr	    this list of conditions and the following disclaimer.
// sqmz	
// ymns	  * Redistribution's in binary form must reproduce the above copyright notice,
// oycd	    this list of conditions and the following disclaimer in the documentation
// txll	    and/or other materials provided with the distribution.
// prfn	
// qjkb	  * Neither the name of the copyright holders nor the names of its contributors 
// nduz	    may not be used to endorse or promote products derived from this software 
// dtki	    without specific prior written permission.
// yxtn	
// qnqe	This software is provided by the copyright holders and contributors "as is" and
// aaau	any express or implied warranties, including, but not limited to, the implied
// hmnu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bbch	In no event shall the Prince of Songkla University or contributors be liable 
// hgbi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fklv	(including, but not limited to, procurement of substitute goods or services;
// ropu	loss of use, data, or profits; or business interruption) however caused
// oufv	and on any theory of liability, whether in contract, strict liability,
// exuc	or tort (including negligence or otherwise) arising in any way out of
// banq	the use of this software, even if advised of the possibility of such damage.
// iptb	
// qaxb	Intelligent Systems Laboratory (iSys Lab)
// rdbs	Faculty of Engineering, Prince of Songkla University, THAILAND
// wkif	Project leader by Nikom SUVONVORN
// bvmm	Project website at http://code.google.com/p/openvss/

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


