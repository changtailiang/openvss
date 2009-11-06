// rlmo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// syae	
// ffov	 By downloading, copying, installing or using the software you agree to this license.
// ljwh	 If you do not agree to this license, do not download, install,
// yzzh	 copy or use the software.
// hmel	
// wwgx	                          License Agreement
// frdk	         For OpenVss - Open Source Video Surveillance System
// mcpp	
// xcio	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pmdi	
// smxj	Third party copyrights are property of their respective owners.
// fbrl	
// mlte	Redistribution and use in source and binary forms, with or without modification,
// gbrw	are permitted provided that the following conditions are met:
// rdzo	
// cdii	  * Redistribution's of source code must retain the above copyright notice,
// tgkv	    this list of conditions and the following disclaimer.
// rlsv	
// iwtj	  * Redistribution's in binary form must reproduce the above copyright notice,
// ywse	    this list of conditions and the following disclaimer in the documentation
// zrya	    and/or other materials provided with the distribution.
// ikiw	
// klxm	  * Neither the name of the copyright holders nor the names of its contributors 
// mpfo	    may not be used to endorse or promote products derived from this software 
// dpqy	    without specific prior written permission.
// qvub	
// tywj	This software is provided by the copyright holders and contributors "as is" and
// hixu	any express or implied warranties, including, but not limited to, the implied
// kvok	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fizi	In no event shall the Prince of Songkla University or contributors be liable 
// xnlf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ngis	(including, but not limited to, procurement of substitute goods or services;
// qefj	loss of use, data, or profits; or business interruption) however caused
// gtne	and on any theory of liability, whether in contract, strict liability,
// xwhk	or tort (including negligence or otherwise) arising in any way out of
// ozoc	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.ObjectDetection
{
    public partial class VsObjectDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsObjectDetectionSetupPage()
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
            this.comboBox1.Focus();
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerPage.GetConfiguration()
        {
            VsObjectDetectionConfiguration cfg = new VsObjectDetectionConfiguration();

            cfg.SelectedObject = this.comboBox1.SelectedIndex;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsObjectDetectionConfiguration cfg = (VsObjectDetectionConfiguration)config;

            if (cfg != null)
            {
                this.comboBox1.SelectedIndex = cfg.SelectedObject ;
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
