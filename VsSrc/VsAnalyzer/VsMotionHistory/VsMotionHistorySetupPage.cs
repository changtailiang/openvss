// rtdk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tvvy	
// zveo	 By downloading, copying, installing or using the software you agree to this license.
// qnst	 If you do not agree to this license, do not download, install,
// hxki	 copy or use the software.
// xdgg	
// cgcr	                          License Agreement
// mkfj	         For OpenVss - Open Source Video Surveillance System
// zwgk	
// ezfl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// qdfk	
// bkxc	Third party copyrights are property of their respective owners.
// purc	
// rjbo	Redistribution and use in source and binary forms, with or without modification,
// mxim	are permitted provided that the following conditions are met:
// sdlp	
// quot	  * Redistribution's of source code must retain the above copyright notice,
// giph	    this list of conditions and the following disclaimer.
// ryru	
// xwer	  * Redistribution's in binary form must reproduce the above copyright notice,
// iacs	    this list of conditions and the following disclaimer in the documentation
// scsq	    and/or other materials provided with the distribution.
// vsxg	
// rtsm	  * Neither the name of the copyright holders nor the names of its contributors 
// squh	    may not be used to endorse or promote products derived from this software 
// vevg	    without specific prior written permission.
// ekks	
// rhqq	This software is provided by the copyright holders and contributors "as is" and
// tqds	any express or implied warranties, including, but not limited to, the implied
// bswn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cyyo	In no event shall the Prince of Songkla University or contributors be liable 
// liqy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// febh	(including, but not limited to, procurement of substitute goods or services;
// cwve	loss of use, data, or profits; or business interruption) however caused
// evoh	and on any theory of liability, whether in contract, strict liability,
// szyn	or tort (including negligence or otherwise) arising in any way out of
// bgna	the use of this software, even if advised of the possibility of such damage.

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
