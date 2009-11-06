// tplw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// obxx	
// jeos	 By downloading, copying, installing or using the software you agree to this license.
// zquj	 If you do not agree to this license, do not download, install,
// pfze	 copy or use the software.
// qrqe	
// esrh	                          License Agreement
// tlyr	         For OpenVss - Open Source Video Surveillance System
// nsum	
// plgl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rkqq	
// ewrv	Third party copyrights are property of their respective owners.
// jwue	
// cfdc	Redistribution and use in source and binary forms, with or without modification,
// yhrv	are permitted provided that the following conditions are met:
// jpdx	
// gwfh	  * Redistribution's of source code must retain the above copyright notice,
// viue	    this list of conditions and the following disclaimer.
// ynng	
// aazi	  * Redistribution's in binary form must reproduce the above copyright notice,
// awxx	    this list of conditions and the following disclaimer in the documentation
// ruoh	    and/or other materials provided with the distribution.
// osnh	
// tkbb	  * Neither the name of the copyright holders nor the names of its contributors 
// hski	    may not be used to endorse or promote products derived from this software 
// qkzb	    without specific prior written permission.
// cqfo	
// sxby	This software is provided by the copyright holders and contributors "as is" and
// ijvn	any express or implied warranties, including, but not limited to, the implied
// rggm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hysd	In no event shall the Prince of Songkla University or contributors be liable 
// vmkn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mlyi	(including, but not limited to, procurement of substitute goods or services;
// qqrq	loss of use, data, or profits; or business interruption) however caused
// xwua	and on any theory of liability, whether in contract, strict liability,
// ozpr	or tort (including negligence or otherwise) arising in any way out of
// qpzk	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.SquareDetection
{
    public partial class VsSquareDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsSquareDetectionSetupPage()
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
            VsSquareDetectionConfiguration cfg = new VsSquareDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsSquareDetectionConfiguration cfg = (VsSquareDetectionConfiguration)config;

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
