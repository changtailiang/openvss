// ofju	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kycy	
// srzt	 By downloading, copying, installing or using the software you agree to this license.
// jscr	 If you do not agree to this license, do not download, install,
// ewoy	 copy or use the software.
// ouml	
// cqgo	                          License Agreement
// klii	         For OpenVSS - Open Source Video Surveillance System
// vxre	
// bcnh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vzwa	
// kgkn	Third party copyrights are property of their respective owners.
// eusr	
// gszt	Redistribution and use in source and binary forms, with or without modification,
// sxst	are permitted provided that the following conditions are met:
// rooh	
// jrym	  * Redistribution's of source code must retain the above copyright notice,
// bxqc	    this list of conditions and the following disclaimer.
// jhco	
// ymbw	  * Redistribution's in binary form must reproduce the above copyright notice,
// gsjp	    this list of conditions and the following disclaimer in the documentation
// tqbd	    and/or other materials provided with the distribution.
// xxme	
// jtph	  * Neither the name of the copyright holders nor the names of its contributors 
// lpqs	    may not be used to endorse or promote products derived from this software 
// iymh	    without specific prior written permission.
// eqiz	
// plvg	This software is provided by the copyright holders and contributors "as is" and
// vwnz	any express or implied warranties, including, but not limited to, the implied
// eyns	warranties of merchantability and fitness for a particular purpose are disclaimed.
// quoe	In no event shall the Prince of Songkla University or contributors be liable 
// kmsp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rvci	(including, but not limited to, procurement of substitute goods or services;
// vjni	loss of use, data, or profits; or business interruption) however caused
// gcld	and on any theory of liability, whether in contract, strict liability,
// ibnm	or tort (including negligence or otherwise) arising in any way out of
// cfin	the use of this software, even if advised of the possibility of such damage.
// gqdn	
// bybn	Intelligent Systems Laboratory (iSys Lab)
// jhws	Faculty of Engineering, Prince of Songkla University, THAILAND
// xsiu	Project leader by Nikom SUVONVORN
// imkm	Project website at http://code.google.com/p/openvss/

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


