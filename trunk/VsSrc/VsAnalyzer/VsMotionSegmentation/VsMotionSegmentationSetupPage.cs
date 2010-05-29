// bywr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rraz	
// neiq	 By downloading, copying, installing or using the software you agree to this license.
// obni	 If you do not agree to this license, do not download, install,
// ankp	 copy or use the software.
// njwr	
// rhgi	                          License Agreement
// fxjq	         For OpenVSS - Open Source Video Surveillance System
// oded	
// phbs	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qpvq	
// krmu	Third party copyrights are property of their respective owners.
// dkuc	
// xlns	Redistribution and use in source and binary forms, with or without modification,
// cezj	are permitted provided that the following conditions are met:
// lrup	
// usbk	  * Redistribution's of source code must retain the above copyright notice,
// xkst	    this list of conditions and the following disclaimer.
// mryx	
// ngga	  * Redistribution's in binary form must reproduce the above copyright notice,
// vmfv	    this list of conditions and the following disclaimer in the documentation
// cgsd	    and/or other materials provided with the distribution.
// qmbk	
// hrhz	  * Neither the name of the copyright holders nor the names of its contributors 
// vfvs	    may not be used to endorse or promote products derived from this software 
// pbwt	    without specific prior written permission.
// rbqf	
// mqev	This software is provided by the copyright holders and contributors "as is" and
// yzoy	any express or implied warranties, including, but not limited to, the implied
// lznn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zxuk	In no event shall the Prince of Songkla University or contributors be liable 
// jhlu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kzbi	(including, but not limited to, procurement of substitute goods or services;
// kokt	loss of use, data, or profits; or business interruption) however caused
// pmdb	and on any theory of liability, whether in contract, strict liability,
// qmrz	or tort (including negligence or otherwise) arising in any way out of
// ifmi	the use of this software, even if advised of the possibility of such damage.
// diow	
// shss	Intelligent Systems Laboratory (iSys Lab)
// gmjk	Faculty of Engineering, Prince of Songkla University, THAILAND
// pvvn	Project leader by Nikom SUVONVORN
// owlj	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionSegmentation
{
    public partial class VsMotionSegmentationSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsMotionSegmentationSetupPage()
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
            VsMotionSegmentationConfiguration cfg = new VsMotionSegmentationConfiguration();

            cfg.ThresholdAlpha = this.trackBar1.Value;
            cfg.ThresholdSigma = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsMotionSegmentationConfiguration cfg = (VsMotionSegmentationConfiguration)config;

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
