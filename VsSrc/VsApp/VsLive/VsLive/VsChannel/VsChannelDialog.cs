// zokk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vlie	
// qeyo	 By downloading, copying, installing or using the software you agree to this license.
// zogk	 If you do not agree to this license, do not download, install,
// tgjz	 copy or use the software.
// gaei	
// qara	                          License Agreement
// eldj	         For OpenVSS - Open Source Video Surveillance System
// qzsb	
// kuso	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nsux	
// rpok	Third party copyrights are property of their respective owners.
// pwyz	
// oebz	Redistribution and use in source and binary forms, with or without modification,
// jbtu	are permitted provided that the following conditions are met:
// uhze	
// aoyz	  * Redistribution's of source code must retain the above copyright notice,
// wfzz	    this list of conditions and the following disclaimer.
// nvmn	
// fgra	  * Redistribution's in binary form must reproduce the above copyright notice,
// mgli	    this list of conditions and the following disclaimer in the documentation
// ndvl	    and/or other materials provided with the distribution.
// ytri	
// ayuf	  * Neither the name of the copyright holders nor the names of its contributors 
// spwc	    may not be used to endorse or promote products derived from this software 
// rpok	    without specific prior written permission.
// wymt	
// sotd	This software is provided by the copyright holders and contributors "as is" and
// kthn	any express or implied warranties, including, but not limited to, the implied
// vrrx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tmbd	In no event shall the Prince of Songkla University or contributors be liable 
// nryo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// agup	(including, but not limited to, procurement of substitute goods or services;
// jojx	loss of use, data, or profits; or business interruption) however caused
// sbmo	and on any theory of liability, whether in contract, strict liability,
// rbtk	or tort (including negligence or otherwise) arising in any way out of
// zoyh	the use of this software, even if advised of the possibility of such damage.
// qgkb	
// xzje	Intelligent Systems Laboratory (iSys Lab)
// okwf	Faculty of Engineering, Prince of Songkla University, THAILAND
// axsl	Project leader by Nikom SUVONVORN
// tetv	Project website at http://code.google.com/p/openvss/

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

