// hrol	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cdxt	
// zrap	 By downloading, copying, installing or using the software you agree to this license.
// vfji	 If you do not agree to this license, do not download, install,
// jzxj	 copy or use the software.
// bcau	
// spdp	                          License Agreement
// mepb	         For OpenVSS - Open Source Video Surveillance System
// nkrt	
// gpwz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yqmc	
// purk	Third party copyrights are property of their respective owners.
// bluf	
// sfre	Redistribution and use in source and binary forms, with or without modification,
// rutm	are permitted provided that the following conditions are met:
// aigv	
// bzck	  * Redistribution's of source code must retain the above copyright notice,
// nqbt	    this list of conditions and the following disclaimer.
// cxlk	
// pxex	  * Redistribution's in binary form must reproduce the above copyright notice,
// ysob	    this list of conditions and the following disclaimer in the documentation
// jjjh	    and/or other materials provided with the distribution.
// tmcm	
// wjzp	  * Neither the name of the copyright holders nor the names of its contributors 
// jrbq	    may not be used to endorse or promote products derived from this software 
// sgwl	    without specific prior written permission.
// kadu	
// tgot	This software is provided by the copyright holders and contributors "as is" and
// pvnh	any express or implied warranties, including, but not limited to, the implied
// uflr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// purb	In no event shall the Prince of Songkla University or contributors be liable 
// noxs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xvay	(including, but not limited to, procurement of substitute goods or services;
// vofr	loss of use, data, or profits; or business interruption) however caused
// wdrj	and on any theory of liability, whether in contract, strict liability,
// goom	or tort (including negligence or otherwise) arising in any way out of
// xiwb	the use of this software, even if advised of the possibility of such damage.
// wsve	
// fjax	Intelligent Systems Laboratory (iSys Lab)
// pvxv	Faculty of Engineering, Prince of Songkla University, THAILAND
// dkxy	Project leader by Nikom SUVONVORN
// gqyb	Project website at http://code.google.com/p/openvss/

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
