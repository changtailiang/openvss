// vszq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ffsv	
// fkha	 By downloading, copying, installing or using the software you agree to this license.
// bbhz	 If you do not agree to this license, do not download, install,
// nowj	 copy or use the software.
// ajmj	
// dyzc	                          License Agreement
// emsu	         For OpenVss - Open Source Video Surveillance System
// xfig	
// pdpi	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// loys	
// yqjm	Third party copyrights are property of their respective owners.
// xtkm	
// mybl	Redistribution and use in source and binary forms, with or without modification,
// gpnh	are permitted provided that the following conditions are met:
// fpqt	
// sndw	  * Redistribution's of source code must retain the above copyright notice,
// takj	    this list of conditions and the following disclaimer.
// znym	
// ltln	  * Redistribution's in binary form must reproduce the above copyright notice,
// pnel	    this list of conditions and the following disclaimer in the documentation
// bfhy	    and/or other materials provided with the distribution.
// dwaz	
// qicv	  * Neither the name of the copyright holders nor the names of its contributors 
// yezl	    may not be used to endorse or promote products derived from this software 
// mntx	    without specific prior written permission.
// jbmy	
// apam	This software is provided by the copyright holders and contributors "as is" and
// ezsr	any express or implied warranties, including, but not limited to, the implied
// lerm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// getw	In no event shall the Prince of Songkla University or contributors be liable 
// zktq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lcng	(including, but not limited to, procurement of substitute goods or services;
// uabb	loss of use, data, or profits; or business interruption) however caused
// uhca	and on any theory of liability, whether in contract, strict liability,
// tiyn	or tort (including negligence or otherwise) arising in any way out of
// wovq	the use of this software, even if advised of the possibility of such damage.

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


