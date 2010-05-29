// adru	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// agyw	
// askg	 By downloading, copying, installing or using the software you agree to this license.
// speo	 If you do not agree to this license, do not download, install,
// hfbx	 copy or use the software.
// merf	
// pvut	                          License Agreement
// rees	         For OpenVSS - Open Source Video Surveillance System
// fwre	
// zqbb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mkyw	
// mjdt	Third party copyrights are property of their respective owners.
// waew	
// uxiw	Redistribution and use in source and binary forms, with or without modification,
// llef	are permitted provided that the following conditions are met:
// mffw	
// nrbv	  * Redistribution's of source code must retain the above copyright notice,
// yzpr	    this list of conditions and the following disclaimer.
// dzkb	
// fvtf	  * Redistribution's in binary form must reproduce the above copyright notice,
// sbxr	    this list of conditions and the following disclaimer in the documentation
// ziyi	    and/or other materials provided with the distribution.
// nvso	
// lwph	  * Neither the name of the copyright holders nor the names of its contributors 
// fciu	    may not be used to endorse or promote products derived from this software 
// ihvw	    without specific prior written permission.
// lntu	
// nhqq	This software is provided by the copyright holders and contributors "as is" and
// rzmk	any express or implied warranties, including, but not limited to, the implied
// hoxf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tsic	In no event shall the Prince of Songkla University or contributors be liable 
// gafg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kcwd	(including, but not limited to, procurement of substitute goods or services;
// myxl	loss of use, data, or profits; or business interruption) however caused
// fafl	and on any theory of liability, whether in contract, strict liability,
// pdug	or tort (including negligence or otherwise) arising in any way out of
// fcwm	the use of this software, even if advised of the possibility of such damage.
// jezr	
// edap	Intelligent Systems Laboratory (iSys Lab)
// ztqk	Faculty of Engineering, Prince of Songkla University, THAILAND
// imjl	Project leader by Nikom SUVONVORN
// kmes	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EllipseDetection
{
    public partial class VsEllipseDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsEllipseDetectionSetupPage()
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
            VsEllipseDetectionConfiguration cfg = new VsEllipseDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsEllipseDetectionConfiguration cfg = (VsEllipseDetectionConfiguration)config;

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
