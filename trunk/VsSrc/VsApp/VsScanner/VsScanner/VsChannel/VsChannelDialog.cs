// erbv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uvrb	
// bnhq	 By downloading, copying, installing or using the software you agree to this license.
// jzcg	 If you do not agree to this license, do not download, install,
// ltpm	 copy or use the software.
// jwvj	
// elgs	                          License Agreement
// puql	         For OpenVSS - Open Source Video Surveillance System
// uvak	
// lfku	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dmsb	
// jhpn	Third party copyrights are property of their respective owners.
// yebk	
// ffyi	Redistribution and use in source and binary forms, with or without modification,
// vrrj	are permitted provided that the following conditions are met:
// pymg	
// wwvn	  * Redistribution's of source code must retain the above copyright notice,
// yrug	    this list of conditions and the following disclaimer.
// iujx	
// duaw	  * Redistribution's in binary form must reproduce the above copyright notice,
// wsuk	    this list of conditions and the following disclaimer in the documentation
// tgfp	    and/or other materials provided with the distribution.
// xsou	
// nbfe	  * Neither the name of the copyright holders nor the names of its contributors 
// zmen	    may not be used to endorse or promote products derived from this software 
// lbpg	    without specific prior written permission.
// kubl	
// wafb	This software is provided by the copyright holders and contributors "as is" and
// qumx	any express or implied warranties, including, but not limited to, the implied
// ebnq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qgqg	In no event shall the Prince of Songkla University or contributors be liable 
// dash	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pexr	(including, but not limited to, procurement of substitute goods or services;
// qnkv	loss of use, data, or profits; or business interruption) however caused
// cnay	and on any theory of liability, whether in contract, strict liability,
// eutw	or tort (including negligence or otherwise) arising in any way out of
// mnds	the use of this software, even if advised of the possibility of such damage.
// ohzx	
// yowf	Intelligent Systems Laboratory (iSys Lab)
// kjdj	Faculty of Engineering, Prince of Songkla University, THAILAND
// cuwr	Project leader by Nikom SUVONVORN
// cold	Project website at http://code.google.com/p/openvss/

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

