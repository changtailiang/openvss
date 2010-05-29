// whzy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qfgr	
// dmdi	 By downloading, copying, installing or using the software you agree to this license.
// weba	 If you do not agree to this license, do not download, install,
// ibrs	 copy or use the software.
// louj	
// rtzv	                          License Agreement
// qfpn	         For OpenVSS - Open Source Video Surveillance System
// geem	
// datu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yyqu	
// ykvj	Third party copyrights are property of their respective owners.
// uech	
// kyqh	Redistribution and use in source and binary forms, with or without modification,
// mphw	are permitted provided that the following conditions are met:
// flax	
// xpcr	  * Redistribution's of source code must retain the above copyright notice,
// aowi	    this list of conditions and the following disclaimer.
// hwtn	
// xakg	  * Redistribution's in binary form must reproduce the above copyright notice,
// yqam	    this list of conditions and the following disclaimer in the documentation
// cidh	    and/or other materials provided with the distribution.
// owzn	
// sxpn	  * Neither the name of the copyright holders nor the names of its contributors 
// xsxj	    may not be used to endorse or promote products derived from this software 
// idjg	    without specific prior written permission.
// htzn	
// fdjm	This software is provided by the copyright holders and contributors "as is" and
// eayp	any express or implied warranties, including, but not limited to, the implied
// lnup	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mudd	In no event shall the Prince of Songkla University or contributors be liable 
// pipk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hgpe	(including, but not limited to, procurement of substitute goods or services;
// dbxu	loss of use, data, or profits; or business interruption) however caused
// hufi	and on any theory of liability, whether in contract, strict liability,
// ipbk	or tort (including negligence or otherwise) arising in any way out of
// mnir	the use of this software, even if advised of the possibility of such damage.
// yabk	
// xiwn	Intelligent Systems Laboratory (iSys Lab)
// afqy	Faculty of Engineering, Prince of Songkla University, THAILAND
// epfy	Project leader by Nikom SUVONVORN
// oejd	Project website at http://code.google.com/p/openvss/

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
