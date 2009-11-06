// dchw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// blyd	
// rjrj	 By downloading, copying, installing or using the software you agree to this license.
// ewiw	 If you do not agree to this license, do not download, install,
// zdtr	 copy or use the software.
// xspr	
// dkeh	                          License Agreement
// havt	         For OpenVss - Open Source Video Surveillance System
// klpj	
// xlhc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// zxal	
// qtko	Third party copyrights are property of their respective owners.
// eily	
// hrfl	Redistribution and use in source and binary forms, with or without modification,
// mpsr	are permitted provided that the following conditions are met:
// hqwq	
// oyyt	  * Redistribution's of source code must retain the above copyright notice,
// gyzo	    this list of conditions and the following disclaimer.
// vrra	
// rebj	  * Redistribution's in binary form must reproduce the above copyright notice,
// zpcy	    this list of conditions and the following disclaimer in the documentation
// pwlt	    and/or other materials provided with the distribution.
// gdwh	
// spvi	  * Neither the name of the copyright holders nor the names of its contributors 
// ajws	    may not be used to endorse or promote products derived from this software 
// vqhg	    without specific prior written permission.
// jwcq	
// aeti	This software is provided by the copyright holders and contributors "as is" and
// oisr	any express or implied warranties, including, but not limited to, the implied
// oybr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mend	In no event shall the Prince of Songkla University or contributors be liable 
// bswf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wizi	(including, but not limited to, procurement of substitute goods or services;
// hioj	loss of use, data, or profits; or business interruption) however caused
// iwps	and on any theory of liability, whether in contract, strict liability,
// uvtb	or tort (including negligence or otherwise) arising in any way out of
// kosj	the use of this software, even if advised of the possibility of such damage.

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
