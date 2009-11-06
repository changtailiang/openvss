// pwuj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fzet	
// bjqh	 By downloading, copying, installing or using the software you agree to this license.
// luts	 If you do not agree to this license, do not download, install,
// tgjg	 copy or use the software.
// qiwm	
// xnel	                          License Agreement
// fniy	         For OpenVss - Open Source Video Surveillance System
// gjmh	
// fpwz	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// zecz	
// gymu	Third party copyrights are property of their respective owners.
// ygmb	
// xgmg	Redistribution and use in source and binary forms, with or without modification,
// zilr	are permitted provided that the following conditions are met:
// utoo	
// brbb	  * Redistribution's of source code must retain the above copyright notice,
// immd	    this list of conditions and the following disclaimer.
// kjhm	
// gwgy	  * Redistribution's in binary form must reproduce the above copyright notice,
// akmy	    this list of conditions and the following disclaimer in the documentation
// agbz	    and/or other materials provided with the distribution.
// xfhx	
// deeg	  * Neither the name of the copyright holders nor the names of its contributors 
// poyo	    may not be used to endorse or promote products derived from this software 
// xllm	    without specific prior written permission.
// uirn	
// zaac	This software is provided by the copyright holders and contributors "as is" and
// cnrk	any express or implied warranties, including, but not limited to, the implied
// gqnv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pced	In no event shall the Prince of Songkla University or contributors be liable 
// epag	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fbxr	(including, but not limited to, procurement of substitute goods or services;
// yrbp	loss of use, data, or profits; or business interruption) however caused
// yzdr	and on any theory of liability, whether in contract, strict liability,
// oozx	or tort (including negligence or otherwise) arising in any way out of
// eevq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.DummyDetection
{
    public partial class VsDummyDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsDummyDetectionSetupPage()
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
            VsDummyDetectionConfiguration cfg = new VsDummyDetectionConfiguration();

            cfg.ThresholdAlpha = this.trackBar1.Value;
            cfg.ThresholdSigma = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsDummyDetectionConfiguration cfg = (VsDummyDetectionConfiguration)config;

            if (cfg != null)
            {
                this.trackBar1.Value = cfg.ThresholdAlpha ;
                this.trackBar2.Value = cfg.ThresholdSigma;
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
    }
}
