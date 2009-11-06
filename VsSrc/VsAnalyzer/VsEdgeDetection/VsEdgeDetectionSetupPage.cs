// kubx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gmds	
// fdzv	 By downloading, copying, installing or using the software you agree to this license.
// xprg	 If you do not agree to this license, do not download, install,
// xsvm	 copy or use the software.
// udlu	
// ipex	                          License Agreement
// hlff	         For OpenVss - Open Source Video Surveillance System
// drhh	
// voih	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ooyc	
// txwq	Third party copyrights are property of their respective owners.
// ulwq	
// hugg	Redistribution and use in source and binary forms, with or without modification,
// ihor	are permitted provided that the following conditions are met:
// hflt	
// xtrf	  * Redistribution's of source code must retain the above copyright notice,
// ijli	    this list of conditions and the following disclaimer.
// jnyg	
// fjak	  * Redistribution's in binary form must reproduce the above copyright notice,
// sodv	    this list of conditions and the following disclaimer in the documentation
// ppyi	    and/or other materials provided with the distribution.
// lbyo	
// zrai	  * Neither the name of the copyright holders nor the names of its contributors 
// deez	    may not be used to endorse or promote products derived from this software 
// grik	    without specific prior written permission.
// angu	
// wzbz	This software is provided by the copyright holders and contributors "as is" and
// geyt	any express or implied warranties, including, but not limited to, the implied
// cpei	warranties of merchantability and fitness for a particular purpose are disclaimed.
// viug	In no event shall the Prince of Songkla University or contributors be liable 
// lwis	for any direct, indirect, incidental, special, exemplary, or consequential damages
// npda	(including, but not limited to, procurement of substitute goods or services;
// eadb	loss of use, data, or profits; or business interruption) however caused
// gsvb	and on any theory of liability, whether in contract, strict liability,
// ieml	or tort (including negligence or otherwise) arising in any way out of
// azhv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EdgeDetection
{
    public partial class VsEdgeDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsEdgeDetectionSetupPage()
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
            VsEdgeDetectionConfiguration cfg = new VsEdgeDetectionConfiguration();

            cfg.ThresholdStrong = this.trackBar1.Value;
            cfg.ThresholdWeak = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsEdgeDetectionConfiguration cfg = (VsEdgeDetectionConfiguration)config;

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
    }
}
