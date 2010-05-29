// zqux	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vdvs	
// dzeh	 By downloading, copying, installing or using the software you agree to this license.
// aujv	 If you do not agree to this license, do not download, install,
// vtls	 copy or use the software.
// xaas	
// fesm	                          License Agreement
// pyff	         For OpenVSS - Open Source Video Surveillance System
// daby	
// rkue	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cetc	
// lpvj	Third party copyrights are property of their respective owners.
// ujbg	
// kpmz	Redistribution and use in source and binary forms, with or without modification,
// qcsq	are permitted provided that the following conditions are met:
// licf	
// tyez	  * Redistribution's of source code must retain the above copyright notice,
// slel	    this list of conditions and the following disclaimer.
// ygqt	
// hxhp	  * Redistribution's in binary form must reproduce the above copyright notice,
// jirf	    this list of conditions and the following disclaimer in the documentation
// wzuo	    and/or other materials provided with the distribution.
// ocip	
// rett	  * Neither the name of the copyright holders nor the names of its contributors 
// bnjm	    may not be used to endorse or promote products derived from this software 
// lwri	    without specific prior written permission.
// fqid	
// ytrs	This software is provided by the copyright holders and contributors "as is" and
// uchc	any express or implied warranties, including, but not limited to, the implied
// rwjt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dqlp	In no event shall the Prince of Songkla University or contributors be liable 
// dott	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nxrt	(including, but not limited to, procurement of substitute goods or services;
// oudm	loss of use, data, or profits; or business interruption) however caused
// riaf	and on any theory of liability, whether in contract, strict liability,
// rrpu	or tort (including negligence or otherwise) arising in any way out of
// kpup	the use of this software, even if advised of the possibility of such damage.
// xqce	
// epiu	Intelligent Systems Laboratory (iSys Lab)
// lbfq	Faculty of Engineering, Prince of Songkla University, THAILAND
// xopb	Project leader by Nikom SUVONVORN
// bxea	Project website at http://code.google.com/p/openvss/

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


