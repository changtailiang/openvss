// obtn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mcwb	
// uuae	 By downloading, copying, installing or using the software you agree to this license.
// ikjd	 If you do not agree to this license, do not download, install,
// bzgq	 copy or use the software.
// rbdz	
// izsm	                          License Agreement
// qmik	         For OpenVss - Open Source Video Surveillance System
// ctfe	
// siry	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// weez	
// baqw	Third party copyrights are property of their respective owners.
// nmuo	
// wacm	Redistribution and use in source and binary forms, with or without modification,
// xufn	are permitted provided that the following conditions are met:
// kkkh	
// lqbo	  * Redistribution's of source code must retain the above copyright notice,
// eelt	    this list of conditions and the following disclaimer.
// hhun	
// xeyh	  * Redistribution's in binary form must reproduce the above copyright notice,
// jvye	    this list of conditions and the following disclaimer in the documentation
// ruob	    and/or other materials provided with the distribution.
// rshy	
// deol	  * Neither the name of the copyright holders nor the names of its contributors 
// twnl	    may not be used to endorse or promote products derived from this software 
// zbrj	    without specific prior written permission.
// bbgo	
// gppt	This software is provided by the copyright holders and contributors "as is" and
// vydp	any express or implied warranties, including, but not limited to, the implied
// lfqr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// baxm	In no event shall the Prince of Songkla University or contributors be liable 
// wmpd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// titb	(including, but not limited to, procurement of substitute goods or services;
// qnih	loss of use, data, or profits; or business interruption) however caused
// dpdq	and on any theory of liability, whether in contract, strict liability,
// ozvb	or tort (including negligence or otherwise) arising in any way out of
// doce	the use of this software, even if advised of the possibility of such damage.

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


