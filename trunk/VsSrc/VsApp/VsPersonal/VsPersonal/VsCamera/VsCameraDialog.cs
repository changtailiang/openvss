// fzpy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qrwg	
// yxhk	 By downloading, copying, installing or using the software you agree to this license.
// ilsc	 If you do not agree to this license, do not download, install,
// iges	 copy or use the software.
// urck	
// ijdt	                          License Agreement
// njud	         For OpenVSS - Open Source Video Surveillance System
// ctgy	
// lxqd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zcqr	
// sauz	Third party copyrights are property of their respective owners.
// iuxg	
// vkhn	Redistribution and use in source and binary forms, with or without modification,
// xeqg	are permitted provided that the following conditions are met:
// ocsp	
// ddip	  * Redistribution's of source code must retain the above copyright notice,
// furl	    this list of conditions and the following disclaimer.
// qbss	
// bksh	  * Redistribution's in binary form must reproduce the above copyright notice,
// pels	    this list of conditions and the following disclaimer in the documentation
// lois	    and/or other materials provided with the distribution.
// msag	
// hjpx	  * Neither the name of the copyright holders nor the names of its contributors 
// jaoo	    may not be used to endorse or promote products derived from this software 
// sfto	    without specific prior written permission.
// dmqu	
// somn	This software is provided by the copyright holders and contributors "as is" and
// lirk	any express or implied warranties, including, but not limited to, the implied
// raeo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vpcn	In no event shall the Prince of Songkla University or contributors be liable 
// tkeg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mvia	(including, but not limited to, procurement of substitute goods or services;
// vepj	loss of use, data, or profits; or business interruption) however caused
// kwpz	and on any theory of liability, whether in contract, strict liability,
// yoax	or tort (including negligence or otherwise) arising in any way out of
// fnuy	the use of this software, even if advised of the possibility of such damage.
// sefj	
// vatc	Intelligent Systems Laboratory (iSys Lab)
// dfus	Faculty of Engineering, Prince of Songkla University, THAILAND
// hjhw	Project leader by Nikom SUVONVORN
// gmsh	Project website at http://code.google.com/p/openvss/

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


