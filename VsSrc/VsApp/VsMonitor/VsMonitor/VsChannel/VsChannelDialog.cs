// ajor	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// afdu	
// zxtw	 By downloading, copying, installing or using the software you agree to this license.
// ryym	 If you do not agree to this license, do not download, install,
// aupr	 copy or use the software.
// pgek	
// elwy	                          License Agreement
// kbqt	         For OpenVSS - Open Source Video Surveillance System
// wjjo	
// rwde	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dnqe	
// lxsz	Third party copyrights are property of their respective owners.
// cicl	
// vfhu	Redistribution and use in source and binary forms, with or without modification,
// fenp	are permitted provided that the following conditions are met:
// iekx	
// haah	  * Redistribution's of source code must retain the above copyright notice,
// ojud	    this list of conditions and the following disclaimer.
// rknb	
// payh	  * Redistribution's in binary form must reproduce the above copyright notice,
// sxwb	    this list of conditions and the following disclaimer in the documentation
// zeyq	    and/or other materials provided with the distribution.
// cojn	
// jnvy	  * Neither the name of the copyright holders nor the names of its contributors 
// dsxl	    may not be used to endorse or promote products derived from this software 
// xlkt	    without specific prior written permission.
// oyuk	
// rgff	This software is provided by the copyright holders and contributors "as is" and
// ffxl	any express or implied warranties, including, but not limited to, the implied
// iiyc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cjfa	In no event shall the Prince of Songkla University or contributors be liable 
// ahud	for any direct, indirect, incidental, special, exemplary, or consequential damages
// opxx	(including, but not limited to, procurement of substitute goods or services;
// cnkh	loss of use, data, or profits; or business interruption) however caused
// ncna	and on any theory of liability, whether in contract, strict liability,
// knzw	or tort (including negligence or otherwise) arising in any way out of
// jehd	the use of this software, even if advised of the possibility of such damage.
// pkpv	
// tujn	Intelligent Systems Laboratory (iSys Lab)
// fksg	Faculty of Engineering, Prince of Songkla University, THAILAND
// dqvc	Project leader by Nikom SUVONVORN
// ihcs	Project website at http://code.google.com/p/openvss/

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

