// gzqq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wvyn	
// ykhi	 By downloading, copying, installing or using the software you agree to this license.
// iawy	 If you do not agree to this license, do not download, install,
// icms	 copy or use the software.
// jyou	
// ffla	                          License Agreement
// tvxb	         For OpenVss - Open Source Video Surveillance System
// bsqy	
// tbla	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xptp	
// rlpz	Third party copyrights are property of their respective owners.
// qmve	
// tmxi	Redistribution and use in source and binary forms, with or without modification,
// lvkr	are permitted provided that the following conditions are met:
// kyuc	
// mfhp	  * Redistribution's of source code must retain the above copyright notice,
// jyfg	    this list of conditions and the following disclaimer.
// qluu	
// eycu	  * Redistribution's in binary form must reproduce the above copyright notice,
// pmjg	    this list of conditions and the following disclaimer in the documentation
// atho	    and/or other materials provided with the distribution.
// uinx	
// quqz	  * Neither the name of the copyright holders nor the names of its contributors 
// vrcl	    may not be used to endorse or promote products derived from this software 
// ezps	    without specific prior written permission.
// hpnh	
// rddm	This software is provided by the copyright holders and contributors "as is" and
// tqcy	any express or implied warranties, including, but not limited to, the implied
// oncs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ysua	In no event shall the Prince of Songkla University or contributors be liable 
// khpw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vuyn	(including, but not limited to, procurement of substitute goods or services;
// wrqp	loss of use, data, or profits; or business interruption) however caused
// wrzk	and on any theory of liability, whether in contract, strict liability,
// gzwr	or tort (including negligence or otherwise) arising in any way out of
// fbea	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MatchImage
{
    public partial class VsMatchImageSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsMatchImageSetupPage()
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
            VsMatchImageConfiguration cfg = new VsMatchImageConfiguration();

            cfg.ThresholdStrong = this.trackBar1.Value;
            cfg.ThresholdWeak = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsMatchImageConfiguration cfg = (VsMatchImageConfiguration)config;

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
