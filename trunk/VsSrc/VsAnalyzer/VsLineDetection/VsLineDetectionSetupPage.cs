// vzph	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mcfv	
// gxjk	 By downloading, copying, installing or using the software you agree to this license.
// pxna	 If you do not agree to this license, do not download, install,
// azfw	 copy or use the software.
// ztpb	
// kqzm	                          License Agreement
// rzzs	         For OpenVSS - Open Source Video Surveillance System
// adnp	
// zoia	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ntpf	
// alvy	Third party copyrights are property of their respective owners.
// gxog	
// cjhb	Redistribution and use in source and binary forms, with or without modification,
// jnww	are permitted provided that the following conditions are met:
// dseh	
// xrkm	  * Redistribution's of source code must retain the above copyright notice,
// jybl	    this list of conditions and the following disclaimer.
// rfif	
// dkaz	  * Redistribution's in binary form must reproduce the above copyright notice,
// vagu	    this list of conditions and the following disclaimer in the documentation
// ktqq	    and/or other materials provided with the distribution.
// wmfl	
// smwv	  * Neither the name of the copyright holders nor the names of its contributors 
// pihj	    may not be used to endorse or promote products derived from this software 
// ajoh	    without specific prior written permission.
// wcpx	
// bbxz	This software is provided by the copyright holders and contributors "as is" and
// nxbd	any express or implied warranties, including, but not limited to, the implied
// mjwe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// atpx	In no event shall the Prince of Songkla University or contributors be liable 
// tpte	for any direct, indirect, incidental, special, exemplary, or consequential damages
// imqv	(including, but not limited to, procurement of substitute goods or services;
// dqyl	loss of use, data, or profits; or business interruption) however caused
// myyh	and on any theory of liability, whether in contract, strict liability,
// dtpv	or tort (including negligence or otherwise) arising in any way out of
// ogyu	the use of this software, even if advised of the possibility of such damage.
// ktjf	
// lcih	Intelligent Systems Laboratory (iSys Lab)
// uqog	Faculty of Engineering, Prince of Songkla University, THAILAND
// jkoo	Project leader by Nikom SUVONVORN
// lbvw	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.LineDetection
{
    public partial class VsLineDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsLineDetectionSetupPage()
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
            VsLineDetectionConfiguration cfg = new VsLineDetectionConfiguration();

            cfg.ThresholdStrong = this.trackBar1.Value;
            cfg.ThresholdWeak = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsLineDetectionConfiguration cfg = (VsLineDetectionConfiguration)config;

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
