// jcij	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hkyn	
// xxia	 By downloading, copying, installing or using the software you agree to this license.
// xcyy	 If you do not agree to this license, do not download, install,
// xkzb	 copy or use the software.
// nzzg	
// nbvr	                          License Agreement
// mars	         For OpenVss - Open Source Video Surveillance System
// zbfb	
// yevw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// gxmi	
// wjzo	Third party copyrights are property of their respective owners.
// kzjr	
// xzwk	Redistribution and use in source and binary forms, with or without modification,
// cbvg	are permitted provided that the following conditions are met:
// pgbw	
// gqaw	  * Redistribution's of source code must retain the above copyright notice,
// xxzs	    this list of conditions and the following disclaimer.
// ocvq	
// mqke	  * Redistribution's in binary form must reproduce the above copyright notice,
// bhgm	    this list of conditions and the following disclaimer in the documentation
// rzva	    and/or other materials provided with the distribution.
// fuyx	
// joha	  * Neither the name of the copyright holders nor the names of its contributors 
// vpcf	    may not be used to endorse or promote products derived from this software 
// idrn	    without specific prior written permission.
// aqcu	
// dfxl	This software is provided by the copyright holders and contributors "as is" and
// qrfi	any express or implied warranties, including, but not limited to, the implied
// zpfg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vaqc	In no event shall the Prince of Songkla University or contributors be liable 
// zcjz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vuux	(including, but not limited to, procurement of substitute goods or services;
// ofwy	loss of use, data, or profits; or business interruption) however caused
// ptla	and on any theory of liability, whether in contract, strict liability,
// wawz	or tort (including negligence or otherwise) arising in any way out of
// xmgr	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.LipDetection
{
    public partial class VsLipDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsLipDetectionSetupPage()
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
            VsLipDetectionConfiguration cfg = new VsLipDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsLipDetectionConfiguration cfg = (VsLipDetectionConfiguration)config;

            if (cfg != null)
            {
                this.trackBar1.Value = cfg.Threshold;
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
    }
}
