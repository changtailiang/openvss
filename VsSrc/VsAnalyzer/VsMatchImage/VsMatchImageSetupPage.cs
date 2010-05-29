// fnbd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vber	
// vtju	 By downloading, copying, installing or using the software you agree to this license.
// noai	 If you do not agree to this license, do not download, install,
// vrlb	 copy or use the software.
// glbd	
// ravk	                          License Agreement
// gzia	         For OpenVSS - Open Source Video Surveillance System
// ihfg	
// fwnu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tgyg	
// rdbx	Third party copyrights are property of their respective owners.
// bjly	
// wgeu	Redistribution and use in source and binary forms, with or without modification,
// mxlv	are permitted provided that the following conditions are met:
// fukw	
// kjmf	  * Redistribution's of source code must retain the above copyright notice,
// jtdz	    this list of conditions and the following disclaimer.
// eqhz	
// numo	  * Redistribution's in binary form must reproduce the above copyright notice,
// yyiw	    this list of conditions and the following disclaimer in the documentation
// njdb	    and/or other materials provided with the distribution.
// dluh	
// kspz	  * Neither the name of the copyright holders nor the names of its contributors 
// vbvi	    may not be used to endorse or promote products derived from this software 
// rwoh	    without specific prior written permission.
// gmuf	
// yegr	This software is provided by the copyright holders and contributors "as is" and
// lxwg	any express or implied warranties, including, but not limited to, the implied
// loia	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fkbx	In no event shall the Prince of Songkla University or contributors be liable 
// zvom	for any direct, indirect, incidental, special, exemplary, or consequential damages
// biel	(including, but not limited to, procurement of substitute goods or services;
// zdwb	loss of use, data, or profits; or business interruption) however caused
// jbpb	and on any theory of liability, whether in contract, strict liability,
// pydz	or tort (including negligence or otherwise) arising in any way out of
// ecwn	the use of this software, even if advised of the possibility of such damage.
// vinh	
// tudh	Intelligent Systems Laboratory (iSys Lab)
// uqil	Faculty of Engineering, Prince of Songkla University, THAILAND
// xieq	Project leader by Nikom SUVONVORN
// avsi	Project website at http://code.google.com/p/openvss/

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
