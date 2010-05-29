// tiya	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tnzz	
// hgwk	 By downloading, copying, installing or using the software you agree to this license.
// epks	 If you do not agree to this license, do not download, install,
// coik	 copy or use the software.
// gbjs	
// maan	                          License Agreement
// boyz	         For OpenVSS - Open Source Video Surveillance System
// trbg	
// kyuw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lvjr	
// ncng	Third party copyrights are property of their respective owners.
// szgr	
// frjr	Redistribution and use in source and binary forms, with or without modification,
// yfnt	are permitted provided that the following conditions are met:
// mmxs	
// iwrm	  * Redistribution's of source code must retain the above copyright notice,
// neie	    this list of conditions and the following disclaimer.
// ulzl	
// rrfk	  * Redistribution's in binary form must reproduce the above copyright notice,
// nuvc	    this list of conditions and the following disclaimer in the documentation
// hhub	    and/or other materials provided with the distribution.
// ikhe	
// kbjz	  * Neither the name of the copyright holders nor the names of its contributors 
// xqjq	    may not be used to endorse or promote products derived from this software 
// katn	    without specific prior written permission.
// qcxu	
// sxah	This software is provided by the copyright holders and contributors "as is" and
// adgs	any express or implied warranties, including, but not limited to, the implied
// qulb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cpec	In no event shall the Prince of Songkla University or contributors be liable 
// wett	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bznb	(including, but not limited to, procurement of substitute goods or services;
// iozn	loss of use, data, or profits; or business interruption) however caused
// ahmf	and on any theory of liability, whether in contract, strict liability,
// jaik	or tort (including negligence or otherwise) arising in any way out of
// kadh	the use of this software, even if advised of the possibility of such damage.
// uqic	
// ehou	Intelligent Systems Laboratory (iSys Lab)
// vqql	Faculty of Engineering, Prince of Songkla University, THAILAND
// iess	Project leader by Nikom SUVONVORN
// kyym	Project website at http://code.google.com/p/openvss/

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


