// anyb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rfwk	
// myfo	 By downloading, copying, installing or using the software you agree to this license.
// exli	 If you do not agree to this license, do not download, install,
// pjet	 copy or use the software.
// hzqe	
// eotv	                          License Agreement
// noqu	         For OpenVSS - Open Source Video Surveillance System
// cinr	
// ljyh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// uopv	
// yrmr	Third party copyrights are property of their respective owners.
// eegl	
// hozb	Redistribution and use in source and binary forms, with or without modification,
// wtwc	are permitted provided that the following conditions are met:
// laxy	
// hllv	  * Redistribution's of source code must retain the above copyright notice,
// kuxg	    this list of conditions and the following disclaimer.
// kwys	
// jvgn	  * Redistribution's in binary form must reproduce the above copyright notice,
// bcri	    this list of conditions and the following disclaimer in the documentation
// hfmo	    and/or other materials provided with the distribution.
// jlur	
// mwvt	  * Neither the name of the copyright holders nor the names of its contributors 
// rrnm	    may not be used to endorse or promote products derived from this software 
// frhk	    without specific prior written permission.
// haak	
// qgsb	This software is provided by the copyright holders and contributors "as is" and
// njai	any express or implied warranties, including, but not limited to, the implied
// jorc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yxly	In no event shall the Prince of Songkla University or contributors be liable 
// afto	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bebr	(including, but not limited to, procurement of substitute goods or services;
// ithk	loss of use, data, or profits; or business interruption) however caused
// vgag	and on any theory of liability, whether in contract, strict liability,
// ecxd	or tort (including negligence or otherwise) arising in any way out of
// tted	the use of this software, even if advised of the possibility of such damage.
// vnjc	
// akoi	Intelligent Systems Laboratory (iSys Lab)
// fikc	Faculty of Engineering, Prince of Songkla University, THAILAND
// hmjl	Project leader by Nikom SUVONVORN
// ebtt	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.OpticalFlow
{
    public partial class VsOpticalFlowSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsOpticalFlowSetupPage()
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
            VsOpticalFlowConfiguration cfg = new VsOpticalFlowConfiguration();

            cfg.ThresholdAlpha = this.trackBar1.Value;
            cfg.ThresholdSigma = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsOpticalFlowConfiguration cfg = (VsOpticalFlowConfiguration)config;

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
