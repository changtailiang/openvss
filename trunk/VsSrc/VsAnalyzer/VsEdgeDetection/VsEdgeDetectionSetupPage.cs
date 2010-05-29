// qiim	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// httt	
// ekzi	 By downloading, copying, installing or using the software you agree to this license.
// ambx	 If you do not agree to this license, do not download, install,
// yait	 copy or use the software.
// dbrv	
// czww	                          License Agreement
// ebvz	         For OpenVSS - Open Source Video Surveillance System
// dwpv	
// sngx	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eifh	
// bowq	Third party copyrights are property of their respective owners.
// idib	
// smcp	Redistribution and use in source and binary forms, with or without modification,
// rmjh	are permitted provided that the following conditions are met:
// xxpc	
// oaee	  * Redistribution's of source code must retain the above copyright notice,
// xfel	    this list of conditions and the following disclaimer.
// tkpu	
// vjuo	  * Redistribution's in binary form must reproduce the above copyright notice,
// cgna	    this list of conditions and the following disclaimer in the documentation
// suhq	    and/or other materials provided with the distribution.
// tadg	
// eyag	  * Neither the name of the copyright holders nor the names of its contributors 
// tcsa	    may not be used to endorse or promote products derived from this software 
// jstc	    without specific prior written permission.
// yxhh	
// xith	This software is provided by the copyright holders and contributors "as is" and
// rufr	any express or implied warranties, including, but not limited to, the implied
// joju	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tnkw	In no event shall the Prince of Songkla University or contributors be liable 
// bygu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kiat	(including, but not limited to, procurement of substitute goods or services;
// rtfk	loss of use, data, or profits; or business interruption) however caused
// mlcv	and on any theory of liability, whether in contract, strict liability,
// mztl	or tort (including negligence or otherwise) arising in any way out of
// gwoj	the use of this software, even if advised of the possibility of such damage.
// tjxf	
// sxhv	Intelligent Systems Laboratory (iSys Lab)
// hwaz	Faculty of Engineering, Prince of Songkla University, THAILAND
// qmxo	Project leader by Nikom SUVONVORN
// hzqy	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EdgeDetection
{
    public partial class VsEdgeDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsEdgeDetectionSetupPage()
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
            VsEdgeDetectionConfiguration cfg = new VsEdgeDetectionConfiguration();

            cfg.ThresholdStrong = this.trackBar1.Value;
            cfg.ThresholdWeak = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsEdgeDetectionConfiguration cfg = (VsEdgeDetectionConfiguration)config;

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
    }
}
