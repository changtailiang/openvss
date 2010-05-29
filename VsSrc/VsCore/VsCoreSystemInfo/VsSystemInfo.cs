// pnuq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jhgv	
// rdzc	 By downloading, copying, installing or using the software you agree to this license.
// xzfn	 If you do not agree to this license, do not download, install,
// kars	 copy or use the software.
// bpyv	
// rtwp	                          License Agreement
// sxcq	         For OpenVSS - Open Source Video Surveillance System
// lbnd	
// linr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lqhl	
// yrzz	Third party copyrights are property of their respective owners.
// oqgz	
// xlaz	Redistribution and use in source and binary forms, with or without modification,
// pzzp	are permitted provided that the following conditions are met:
// krdu	
// ajqv	  * Redistribution's of source code must retain the above copyright notice,
// lbbc	    this list of conditions and the following disclaimer.
// nzgl	
// imwz	  * Redistribution's in binary form must reproduce the above copyright notice,
// uxac	    this list of conditions and the following disclaimer in the documentation
// rdta	    and/or other materials provided with the distribution.
// bonm	
// ixgu	  * Neither the name of the copyright holders nor the names of its contributors 
// mnlp	    may not be used to endorse or promote products derived from this software 
// bdnm	    without specific prior written permission.
// odmx	
// eord	This software is provided by the copyright holders and contributors "as is" and
// dzvn	any express or implied warranties, including, but not limited to, the implied
// qbdw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ppux	In no event shall the Prince of Songkla University or contributors be liable 
// optp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// smzu	(including, but not limited to, procurement of substitute goods or services;
// agyq	loss of use, data, or profits; or business interruption) however caused
// jonn	and on any theory of liability, whether in contract, strict liability,
// rwwm	or tort (including negligence or otherwise) arising in any way out of
// xjij	the use of this software, even if advised of the possibility of such damage.
// ctdl	
// kozl	Intelligent Systems Laboratory (iSys Lab)
// jqyz	Faculty of Engineering, Prince of Songkla University, THAILAND
// kwer	Project leader by Nikom SUVONVORN
// pwdw	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using NLog; 

namespace Vs.Core.SystemInfo
{
    public partial class VsSystemInfo : UserControl
    {
        private System.Windows.Forms.Timer timer = null;
        private ArrayList _listCPU = new ArrayList();
        private ArrayList _listMem = new ArrayList();
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        private VsSystemData sd = null; 

        public VsSystemInfo()
        {
            InitializeComponent();

            try
            {
                sd = new VsSystemData();

                UpdateData();

                timer = new Timer();
                timer.Interval = 1000;
                this.timer.Tick += new System.EventHandler(this.timer_Tick);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            try
            {
                string s = sd.GetProcessorData();
                labelCpu.Text = s;
                double d = double.Parse(s.Substring(0, s.IndexOf("%")));
                dataBarCPU.Value = (int)d;
                dataChartCPU.UpdateChart(d);

                s = sd.GetMemoryPData();
                labelMemP.Text = s;
                int v = (int)double.Parse(s.Substring(0, s.IndexOf("%")));
                dataBarMemP.Value = v;
                dataChartMem.UpdateChart(v);
            }
            catch { }
        }
    }
}
