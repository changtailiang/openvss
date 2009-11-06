// qlro	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mgnp	
// eyal	 By downloading, copying, installing or using the software you agree to this license.
// heze	 If you do not agree to this license, do not download, install,
// pgqe	 copy or use the software.
// zvyz	
// gcfu	                          License Agreement
// ahfl	         For OpenVss - Open Source Video Surveillance System
// wzgi	
// itbs	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hjrl	
// xprw	Third party copyrights are property of their respective owners.
// vgcd	
// oyav	Redistribution and use in source and binary forms, with or without modification,
// nrij	are permitted provided that the following conditions are met:
// aspw	
// tooh	  * Redistribution's of source code must retain the above copyright notice,
// xrvw	    this list of conditions and the following disclaimer.
// fywq	
// dmbq	  * Redistribution's in binary form must reproduce the above copyright notice,
// lizt	    this list of conditions and the following disclaimer in the documentation
// fbwx	    and/or other materials provided with the distribution.
// zluq	
// krso	  * Neither the name of the copyright holders nor the names of its contributors 
// uusi	    may not be used to endorse or promote products derived from this software 
// akyd	    without specific prior written permission.
// kgyq	
// ckra	This software is provided by the copyright holders and contributors "as is" and
// qsxr	any express or implied warranties, including, but not limited to, the implied
// tvrs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// srim	In no event shall the Prince of Songkla University or contributors be liable 
// weln	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fiwi	(including, but not limited to, procurement of substitute goods or services;
// utqb	loss of use, data, or profits; or business interruption) however caused
// jvjy	and on any theory of liability, whether in contract, strict liability,
// dgvo	or tort (including negligence or otherwise) arising in any way out of
// tuas	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	public class VsCameraDialog : VsPageWizard
	{
        private VsCoreServer vsCoreMonitor;
        private VsCamera vsCamera;
		private VsCameraDescription	    vsCameraDescription = new VsCameraDescription();
		private VsCameraSettings		vsCameraSetting = new VsCameraSettings();
        private VsAnalyzerSettings      vsAnalyzerSetting = new VsAnalyzerSettings();
        private VsEncoderSettings       vsEncoderSetting = new VsEncoderSettings();

        public VsCamera Camera
        {
            get { return vsCamera; }
        }

		// Construction
		public VsCameraDialog(VsCoreServer vsCore)
		{
			this.AddPage(vsCameraDescription);
			this.AddPage(vsCameraSetting);

            this.Text = "Add Analyzer";

            // set current core
            vsCoreMonitor = vsCore;
            vsCameraDescription.CoreMonitor = vsCore;
            vsCameraSetting.CoreMonitor = vsCore;
            vsAnalyzerSetting.CoreMonitor = vsCore;
            vsEncoderSetting.CoreMonitor = vsCore;

            this.imagePanel.Visible = false;
        }

		// On page changing
		protected override void OnPageChanging(int page)
		{
			if (page == 1)
			{
				// switching to vsCamera settings
                vsCamera = vsCameraDescription.Camera;
                vsCameraSetting.Camera = vsCamera;
                vsAnalyzerSetting.Camera = vsCamera;
                vsEncoderSetting.Camera = vsCamera;
            }
			base.OnPageChanging(page);
		}

		// Reset event ocuren on page
		protected override void OnResetOnPage(int page)
		{
			if (page == 0)
			{
            }
		}

		// On finish
		protected override void OnFinish()
		{
            vsAnalyzerSetting.FinalUpdate();
            vsEncoderSetting.FinalUpdate();

            // add camera to camera list
            vsCoreMonitor.AddCamera(vsCamera);            
		}
	}
}


