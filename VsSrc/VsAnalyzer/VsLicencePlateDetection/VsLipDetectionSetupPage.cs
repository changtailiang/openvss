// yzzw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// runc	
// mwbw	 By downloading, copying, installing or using the software you agree to this license.
// snjl	 If you do not agree to this license, do not download, install,
// gpbc	 copy or use the software.
// ccar	
// qfcw	                          License Agreement
// acki	         For OpenVSS - Open Source Video Surveillance System
// fixx	
// snir	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// japy	
// npmy	Third party copyrights are property of their respective owners.
// zdtr	
// ggiw	Redistribution and use in source and binary forms, with or without modification,
// zhgm	are permitted provided that the following conditions are met:
// sqcj	
// mtqj	  * Redistribution's of source code must retain the above copyright notice,
// pmts	    this list of conditions and the following disclaimer.
// hksb	
// nbeb	  * Redistribution's in binary form must reproduce the above copyright notice,
// sdxw	    this list of conditions and the following disclaimer in the documentation
// jscy	    and/or other materials provided with the distribution.
// abyk	
// hwys	  * Neither the name of the copyright holders nor the names of its contributors 
// xfmt	    may not be used to endorse or promote products derived from this software 
// ycim	    without specific prior written permission.
// kbkv	
// ogjx	This software is provided by the copyright holders and contributors "as is" and
// dfuo	any express or implied warranties, including, but not limited to, the implied
// tfat	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rrio	In no event shall the Prince of Songkla University or contributors be liable 
// oikl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lzeh	(including, but not limited to, procurement of substitute goods or services;
// pkcp	loss of use, data, or profits; or business interruption) however caused
// ulli	and on any theory of liability, whether in contract, strict liability,
// igku	or tort (including negligence or otherwise) arising in any way out of
// rahc	the use of this software, even if advised of the possibility of such damage.
// bkzr	
// ftch	Intelligent Systems Laboratory (iSys Lab)
// tuxc	Faculty of Engineering, Prince of Songkla University, THAILAND
// qzko	Project leader by Nikom SUVONVORN
// ccis	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.LipDetection
{
    public partial class VsLipDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsLipDetectionSetupPage()
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
            VsLipDetectionConfiguration cfg = new VsLipDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsLipDetectionConfiguration cfg = (VsLipDetectionConfiguration)config;

            if (cfg != null)
            {
                this.trackBar1.Value = cfg.Threshold;
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
    }
}
