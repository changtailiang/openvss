// yruq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ldfm	
// kykh	 By downloading, copying, installing or using the software you agree to this license.
// ksvs	 If you do not agree to this license, do not download, install,
// euwf	 copy or use the software.
// mdma	
// onri	                          License Agreement
// mpny	         For OpenVss - Open Source Video Surveillance System
// zjxk	
// ziip	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rphw	
// aycf	Third party copyrights are property of their respective owners.
// ooue	
// bulv	Redistribution and use in source and binary forms, with or without modification,
// ftby	are permitted provided that the following conditions are met:
// lwau	
// llia	  * Redistribution's of source code must retain the above copyright notice,
// vlsv	    this list of conditions and the following disclaimer.
// lgow	
// vpaq	  * Redistribution's in binary form must reproduce the above copyright notice,
// lmty	    this list of conditions and the following disclaimer in the documentation
// ujxf	    and/or other materials provided with the distribution.
// xcef	
// gkeu	  * Neither the name of the copyright holders nor the names of its contributors 
// pnlo	    may not be used to endorse or promote products derived from this software 
// qbkd	    without specific prior written permission.
// vysu	
// gpzp	This software is provided by the copyright holders and contributors "as is" and
// tlny	any express or implied warranties, including, but not limited to, the implied
// dbzb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// occs	In no event shall the Prince of Songkla University or contributors be liable 
// gnpb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ctgi	(including, but not limited to, procurement of substitute goods or services;
// dlzj	loss of use, data, or profits; or business interruption) however caused
// cqdw	and on any theory of liability, whether in contract, strict liability,
// qczi	or tort (including negligence or otherwise) arising in any way out of
// colv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.LineDetection
{
    public partial class VsLineDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsLineDetectionSetupPage()
        {
            InitializeComponent();
        }

        #region VsICoreAnalyzerPage Members

        bool VsICoreAnalyzerPage.Apply()
        {
            return true;
        }

        bool VsICoreAnalyzerPage.Completed
        {
            get { return completed; }
        }

        void VsICoreAnalyzerPage.Display()
        {
            this.trackBar1.Focus();
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerPage.GetConfiguration()
        {
            VsLineDetectionConfiguration cfg = new VsLineDetectionConfiguration();

            cfg.ThresholdStrong = this.trackBar1.Value;
            cfg.ThresholdWeak = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsLineDetectionConfiguration cfg = (VsLineDetectionConfiguration)config;

            if (cfg != null)
            {
                this.trackBar1.Value = cfg.ThresholdStrong ;
                this.trackBar2.Value = cfg.ThresholdWeak;
            }
        }

       #endregion

        // Update state
        private void UpdateState()
        {
            completed = true;

            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}
