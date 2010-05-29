// zeud	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// krte	
// owyx	 By downloading, copying, installing or using the software you agree to this license.
// qgzl	 If you do not agree to this license, do not download, install,
// oocb	 copy or use the software.
// hcgo	
// loxv	                          License Agreement
// nkbx	         For OpenVSS - Open Source Video Surveillance System
// uier	
// wgao	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// citj	
// uklg	Third party copyrights are property of their respective owners.
// bcpa	
// uktw	Redistribution and use in source and binary forms, with or without modification,
// xfrv	are permitted provided that the following conditions are met:
// uyqd	
// uadi	  * Redistribution's of source code must retain the above copyright notice,
// bioi	    this list of conditions and the following disclaimer.
// oozy	
// jxtb	  * Redistribution's in binary form must reproduce the above copyright notice,
// cqtk	    this list of conditions and the following disclaimer in the documentation
// vbcj	    and/or other materials provided with the distribution.
// ohtr	
// oetd	  * Neither the name of the copyright holders nor the names of its contributors 
// rpou	    may not be used to endorse or promote products derived from this software 
// gdet	    without specific prior written permission.
// ngmg	
// luma	This software is provided by the copyright holders and contributors "as is" and
// lqsd	any express or implied warranties, including, but not limited to, the implied
// ffht	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xttu	In no event shall the Prince of Songkla University or contributors be liable 
// pxuj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uvgu	(including, but not limited to, procurement of substitute goods or services;
// izvy	loss of use, data, or profits; or business interruption) however caused
// lawp	and on any theory of liability, whether in contract, strict liability,
// owyt	or tort (including negligence or otherwise) arising in any way out of
// usfy	the use of this software, even if advised of the possibility of such damage.
// lqyl	
// ivwm	Intelligent Systems Laboratory (iSys Lab)
// kkeq	Faculty of Engineering, Prince of Songkla University, THAILAND
// lclp	Project leader by Nikom SUVONVORN
// ossl	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionDetection
{
    public partial class VsMotionDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsMotionDetectionSetupPage()
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
            VsMotionDetectionConfiguration cfg = new VsMotionDetectionConfiguration();

            cfg.ThresholdAlpha = this.trackBar1.Value;
            cfg.ThresholdSigma = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsMotionDetectionConfiguration cfg = (VsMotionDetectionConfiguration)config;

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
