// ijjd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jftc	
// msgx	 By downloading, copying, installing or using the software you agree to this license.
// glzv	 If you do not agree to this license, do not download, install,
// mwic	 copy or use the software.
// gugg	
// mvsd	                          License Agreement
// xbza	         For OpenVSS - Open Source Video Surveillance System
// jnas	
// ovsg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kdqq	
// pypb	Third party copyrights are property of their respective owners.
// dlfr	
// rdco	Redistribution and use in source and binary forms, with or without modification,
// ccro	are permitted provided that the following conditions are met:
// npel	
// tfot	  * Redistribution's of source code must retain the above copyright notice,
// kggr	    this list of conditions and the following disclaimer.
// dcrd	
// dqqo	  * Redistribution's in binary form must reproduce the above copyright notice,
// fqal	    this list of conditions and the following disclaimer in the documentation
// vhif	    and/or other materials provided with the distribution.
// lmqm	
// eetu	  * Neither the name of the copyright holders nor the names of its contributors 
// yfxj	    may not be used to endorse or promote products derived from this software 
// jwqx	    without specific prior written permission.
// foop	
// mykl	This software is provided by the copyright holders and contributors "as is" and
// ldiw	any express or implied warranties, including, but not limited to, the implied
// pspl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wjhy	In no event shall the Prince of Songkla University or contributors be liable 
// pumy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// iwex	(including, but not limited to, procurement of substitute goods or services;
// thej	loss of use, data, or profits; or business interruption) however caused
// adgh	and on any theory of liability, whether in contract, strict liability,
// ttsm	or tort (including negligence or otherwise) arising in any way out of
// beab	the use of this software, even if advised of the possibility of such damage.
// wxff	
// plna	Intelligent Systems Laboratory (iSys Lab)
// oshk	Faculty of Engineering, Prince of Songkla University, THAILAND
// bpgq	Project leader by Nikom SUVONVORN
// unse	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.SquareDetection
{
    public partial class VsSquareDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsSquareDetectionSetupPage()
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
            VsSquareDetectionConfiguration cfg = new VsSquareDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsSquareDetectionConfiguration cfg = (VsSquareDetectionConfiguration)config;

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
