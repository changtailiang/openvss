// imxl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pvdt	
// logm	 By downloading, copying, installing or using the software you agree to this license.
// yfek	 If you do not agree to this license, do not download, install,
// safm	 copy or use the software.
// ctuf	
// ejax	                          License Agreement
// nqec	         For OpenVSS - Open Source Video Surveillance System
// lnzs	
// ltwa	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bcfd	
// xhuq	Third party copyrights are property of their respective owners.
// hnyy	
// abko	Redistribution and use in source and binary forms, with or without modification,
// srgf	are permitted provided that the following conditions are met:
// vfgv	
// keal	  * Redistribution's of source code must retain the above copyright notice,
// gmyy	    this list of conditions and the following disclaimer.
// delz	
// nqhx	  * Redistribution's in binary form must reproduce the above copyright notice,
// pjqz	    this list of conditions and the following disclaimer in the documentation
// rfcj	    and/or other materials provided with the distribution.
// ckzt	
// mqfv	  * Neither the name of the copyright holders nor the names of its contributors 
// wkst	    may not be used to endorse or promote products derived from this software 
// gjku	    without specific prior written permission.
// pzuv	
// qlbc	This software is provided by the copyright holders and contributors "as is" and
// kjqm	any express or implied warranties, including, but not limited to, the implied
// ogee	warranties of merchantability and fitness for a particular purpose are disclaimed.
// brjv	In no event shall the Prince of Songkla University or contributors be liable 
// neln	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zpdd	(including, but not limited to, procurement of substitute goods or services;
// xoqf	loss of use, data, or profits; or business interruption) however caused
// ywkr	and on any theory of liability, whether in contract, strict liability,
// lhtq	or tort (including negligence or otherwise) arising in any way out of
// jxjd	the use of this software, even if advised of the possibility of such damage.
// zthp	
// gorp	Intelligent Systems Laboratory (iSys Lab)
// aphk	Faculty of Engineering, Prince of Songkla University, THAILAND
// ogvb	Project leader by Nikom SUVONVORN
// iyev	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionHistory
{
    public partial class VsMotionHistorySetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsMotionHistorySetupPage()
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
            VsMotionHistoryConfiguration cfg = new VsMotionHistoryConfiguration();

            cfg.ThresholdAlpha = this.trackBar1.Value;
            cfg.ThresholdSigma = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsMotionHistoryConfiguration cfg = (VsMotionHistoryConfiguration)config;

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
