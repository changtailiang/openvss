// xkjg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tlqt	
// xxmm	 By downloading, copying, installing or using the software you agree to this license.
// xqls	 If you do not agree to this license, do not download, install,
// zydi	 copy or use the software.
// vzqr	
// ulsk	                          License Agreement
// psed	         For OpenVss - Open Source Video Surveillance System
// usdg	
// pyee	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rply	
// sywu	Third party copyrights are property of their respective owners.
// ndli	
// dhex	Redistribution and use in source and binary forms, with or without modification,
// urmi	are permitted provided that the following conditions are met:
// sgee	
// tisf	  * Redistribution's of source code must retain the above copyright notice,
// nedb	    this list of conditions and the following disclaimer.
// tyqg	
// nszv	  * Redistribution's in binary form must reproduce the above copyright notice,
// oxwm	    this list of conditions and the following disclaimer in the documentation
// hvzn	    and/or other materials provided with the distribution.
// ofmx	
// mwll	  * Neither the name of the copyright holders nor the names of its contributors 
// kgfj	    may not be used to endorse or promote products derived from this software 
// grhi	    without specific prior written permission.
// zkof	
// qxjc	This software is provided by the copyright holders and contributors "as is" and
// rquv	any express or implied warranties, including, but not limited to, the implied
// jswx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jfrh	In no event shall the Prince of Songkla University or contributors be liable 
// sfpx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mfvh	(including, but not limited to, procurement of substitute goods or services;
// nqpw	loss of use, data, or profits; or business interruption) however caused
// qomx	and on any theory of liability, whether in contract, strict liability,
// guxq	or tort (including negligence or otherwise) arising in any way out of
// vkgv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	public class VsChannelDialog : VsPageWizard
	{
        private VsCoreServer vsCoreMonitor;
		private VsChannel vsChannel;
		private VsPageDescription vsChannelDescription = new VsPageDescription();
		private VsChannelStructure vsChannelStructure = new VsChannelStructure();
        private VsAnalyzerSettings vsAnalyzerSetting = new VsAnalyzerSettings();
        private VsEncoderSettings vsEncoderSetting = new VsEncoderSettings();

		// VsChannel property
		public VsChannel Channel
		{
			get { return vsChannel; }
		}

	    // Construction
		public VsChannelDialog(VsCoreServer vsCore)
		{
			this.AddPage(vsChannelDescription);
			this.AddPage(vsChannelStructure);
			this.Text = "Add Layout";

            vsCoreMonitor = vsCore;
            vsChannelDescription.CoreMonitor = vsCore;
            vsChannelStructure.CoreMonitor = vsCore;
            vsAnalyzerSetting.CoreMonitor = vsCore;
            vsEncoderSetting.CoreMonitor = vsCore;

            this.imagePanel.Visible = false;
		}

		// On page changing
		protected override void OnPageChanging(int page)
		{
            if (page == 1)
            {
                vsChannel = vsChannelDescription.Channel;
                vsChannelStructure.Channel = vsChannel;
                vsAnalyzerSetting.Channel = vsChannel;
                vsEncoderSetting.Channel = vsChannel;
            }
			base.OnPageChanging(page);
		}

        // On finish
        protected override void OnFinish()
        {
            vsAnalyzerSetting.FinalUpdate();
            vsEncoderSetting.FinalUpdate();

            // add camera to camera list
            vsCoreMonitor.AddChannel(vsChannel);
        }
	}
}

