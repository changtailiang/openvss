// gjny	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nskr	
// dmoi	 By downloading, copying, installing or using the software you agree to this license.
// banr	 If you do not agree to this license, do not download, install,
// rfbd	 copy or use the software.
// lxob	
// jhmp	                          License Agreement
// tlzy	         For OpenVSS - Open Source Video Surveillance System
// fwcb	
// vnch	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ehru	
// nffz	Third party copyrights are property of their respective owners.
// jhke	
// boui	Redistribution and use in source and binary forms, with or without modification,
// vmpg	are permitted provided that the following conditions are met:
// gvxs	
// nqde	  * Redistribution's of source code must retain the above copyright notice,
// xlvd	    this list of conditions and the following disclaimer.
// cuze	
// gune	  * Redistribution's in binary form must reproduce the above copyright notice,
// cnfl	    this list of conditions and the following disclaimer in the documentation
// auwq	    and/or other materials provided with the distribution.
// ctgj	
// ywbi	  * Neither the name of the copyright holders nor the names of its contributors 
// jzgx	    may not be used to endorse or promote products derived from this software 
// babx	    without specific prior written permission.
// mgch	
// opcb	This software is provided by the copyright holders and contributors "as is" and
// ykds	any express or implied warranties, including, but not limited to, the implied
// plrs	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tmcd	In no event shall the Prince of Songkla University or contributors be liable 
// flef	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tqvg	(including, but not limited to, procurement of substitute goods or services;
// nqcb	loss of use, data, or profits; or business interruption) however caused
// lizu	and on any theory of liability, whether in contract, strict liability,
// spbm	or tort (including negligence or otherwise) arising in any way out of
// relo	the use of this software, even if advised of the possibility of such damage.
// sitx	
// indp	Intelligent Systems Laboratory (iSys Lab)
// yysa	Faculty of Engineering, Prince of Songkla University, THAILAND
// cwoy	Project leader by Nikom SUVONVORN
// uwoi	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.FqiDetection
{
    public partial class VsFqiDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsFqiDetectionSetupPage()
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
            VsFqiDetectionConfiguration cfg = new VsFqiDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsFqiDetectionConfiguration cfg = (VsFqiDetectionConfiguration)config;

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
