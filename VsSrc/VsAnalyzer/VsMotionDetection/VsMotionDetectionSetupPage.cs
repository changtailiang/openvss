// emfw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// piim	
// ojrg	 By downloading, copying, installing or using the software you agree to this license.
// ajmy	 If you do not agree to this license, do not download, install,
// fqol	 copy or use the software.
// wizd	
// bctc	                          License Agreement
// kvwq	         For OpenVss - Open Source Video Surveillance System
// qxrd	
// ljli	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// iizw	
// pglv	Third party copyrights are property of their respective owners.
// alyc	
// ybhv	Redistribution and use in source and binary forms, with or without modification,
// nbun	are permitted provided that the following conditions are met:
// ogct	
// maqc	  * Redistribution's of source code must retain the above copyright notice,
// sjnw	    this list of conditions and the following disclaimer.
// ffcn	
// jcov	  * Redistribution's in binary form must reproduce the above copyright notice,
// qycy	    this list of conditions and the following disclaimer in the documentation
// xusp	    and/or other materials provided with the distribution.
// pvpj	
// oxtc	  * Neither the name of the copyright holders nor the names of its contributors 
// gfjo	    may not be used to endorse or promote products derived from this software 
// qicq	    without specific prior written permission.
// ybxs	
// ytmk	This software is provided by the copyright holders and contributors "as is" and
// nzwq	any express or implied warranties, including, but not limited to, the implied
// ddvs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ianx	In no event shall the Prince of Songkla University or contributors be liable 
// tdhh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mahd	(including, but not limited to, procurement of substitute goods or services;
// szei	loss of use, data, or profits; or business interruption) however caused
// vlav	and on any theory of liability, whether in contract, strict liability,
// wzqv	or tort (including negligence or otherwise) arising in any way out of
// ifwp	the use of this software, even if advised of the possibility of such damage.

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
