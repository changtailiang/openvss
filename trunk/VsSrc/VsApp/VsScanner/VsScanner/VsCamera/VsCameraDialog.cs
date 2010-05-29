// shht	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zmod	
// zghd	 By downloading, copying, installing or using the software you agree to this license.
// erqo	 If you do not agree to this license, do not download, install,
// ufuu	 copy or use the software.
// iwhi	
// gtay	                          License Agreement
// vxoj	         For OpenVSS - Open Source Video Surveillance System
// ghjr	
// umgr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// scfp	
// ubgj	Third party copyrights are property of their respective owners.
// bhie	
// szqv	Redistribution and use in source and binary forms, with or without modification,
// zymg	are permitted provided that the following conditions are met:
// mpic	
// syxx	  * Redistribution's of source code must retain the above copyright notice,
// iyui	    this list of conditions and the following disclaimer.
// zccf	
// rsoe	  * Redistribution's in binary form must reproduce the above copyright notice,
// nrxn	    this list of conditions and the following disclaimer in the documentation
// pjqg	    and/or other materials provided with the distribution.
// rosv	
// zzfc	  * Neither the name of the copyright holders nor the names of its contributors 
// udwv	    may not be used to endorse or promote products derived from this software 
// eiad	    without specific prior written permission.
// nzfq	
// xkdh	This software is provided by the copyright holders and contributors "as is" and
// khtu	any express or implied warranties, including, but not limited to, the implied
// sumj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iqgu	In no event shall the Prince of Songkla University or contributors be liable 
// gyiz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wzkn	(including, but not limited to, procurement of substitute goods or services;
// vsze	loss of use, data, or profits; or business interruption) however caused
// ruap	and on any theory of liability, whether in contract, strict liability,
// eajg	or tort (including negligence or otherwise) arising in any way out of
// kllr	the use of this software, even if advised of the possibility of such damage.
// glkz	
// qnno	Intelligent Systems Laboratory (iSys Lab)
// bfwo	Faculty of Engineering, Prince of Songkla University, THAILAND
// rftx	Project leader by Nikom SUVONVORN
// zqls	Project website at http://code.google.com/p/openvss/

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


