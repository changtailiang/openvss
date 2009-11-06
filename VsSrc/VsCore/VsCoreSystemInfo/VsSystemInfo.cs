// wdkm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cksd	
// ddlh	 By downloading, copying, installing or using the software you agree to this license.
// kqlw	 If you do not agree to this license, do not download, install,
// uxip	 copy or use the software.
// swnd	
// xiyl	                          License Agreement
// lyjk	         For OpenVss - Open Source Video Surveillance System
// pyvk	
// eosu	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lomo	
// vpcs	Third party copyrights are property of their respective owners.
// cwae	
// mhwa	Redistribution and use in source and binary forms, with or without modification,
// pgot	are permitted provided that the following conditions are met:
// lhrf	
// tbsm	  * Redistribution's of source code must retain the above copyright notice,
// ubrf	    this list of conditions and the following disclaimer.
// eoee	
// jyih	  * Redistribution's in binary form must reproduce the above copyright notice,
// ffjp	    this list of conditions and the following disclaimer in the documentation
// yfxh	    and/or other materials provided with the distribution.
// cvux	
// ayid	  * Neither the name of the copyright holders nor the names of its contributors 
// xhvu	    may not be used to endorse or promote products derived from this software 
// wqya	    without specific prior written permission.
// fvzy	
// crqq	This software is provided by the copyright holders and contributors "as is" and
// ygog	any express or implied warranties, including, but not limited to, the implied
// ycgo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dljz	In no event shall the Prince of Songkla University or contributors be liable 
// gtff	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gahc	(including, but not limited to, procurement of substitute goods or services;
// dnkp	loss of use, data, or profits; or business interruption) however caused
// hikc	and on any theory of liability, whether in contract, strict liability,
// gzek	or tort (including negligence or otherwise) arising in any way out of
// edzt	the use of this software, even if advised of the possibility of such damage.

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
