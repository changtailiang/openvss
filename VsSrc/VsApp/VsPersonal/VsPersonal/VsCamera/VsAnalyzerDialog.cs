// icnm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vynd	
// frbg	 By downloading, copying, installing or using the software you agree to this license.
// ekra	 If you do not agree to this license, do not download, install,
// uoxx	 copy or use the software.
// iktp	
// ruil	                          License Agreement
// zvgf	         For OpenVSS - Open Source Video Surveillance System
// odnl	
// dajr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cntz	
// ynsf	Third party copyrights are property of their respective owners.
// aany	
// rsox	Redistribution and use in source and binary forms, with or without modification,
// jyva	are permitted provided that the following conditions are met:
// qbek	
// kwrb	  * Redistribution's of source code must retain the above copyright notice,
// xgxt	    this list of conditions and the following disclaimer.
// fguu	
// quqe	  * Redistribution's in binary form must reproduce the above copyright notice,
// ccky	    this list of conditions and the following disclaimer in the documentation
// hinv	    and/or other materials provided with the distribution.
// opbf	
// fiab	  * Neither the name of the copyright holders nor the names of its contributors 
// jjoc	    may not be used to endorse or promote products derived from this software 
// vqiu	    without specific prior written permission.
// cusk	
// ytho	This software is provided by the copyright holders and contributors "as is" and
// hqxn	any express or implied warranties, including, but not limited to, the implied
// rfcc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ivmh	In no event shall the Prince of Songkla University or contributors be liable 
// esnw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fslh	(including, but not limited to, procurement of substitute goods or services;
// goil	loss of use, data, or profits; or business interruption) however caused
// uqwn	and on any theory of liability, whether in contract, strict liability,
// pdxu	or tort (including negligence or otherwise) arising in any way out of
// inyp	the use of this software, even if advised of the possibility of such damage.
// lmke	
// gltz	Intelligent Systems Laboratory (iSys Lab)
// eaqk	Faculty of Engineering, Prince of Songkla University, THAILAND
// gwff	Project leader by Nikom SUVONVORN
// iahs	Project website at http://code.google.com/p/openvss/

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


