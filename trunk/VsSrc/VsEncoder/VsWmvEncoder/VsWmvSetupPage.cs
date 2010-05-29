// wvpy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ymwq	
// lhcd	 By downloading, copying, installing or using the software you agree to this license.
// splw	 If you do not agree to this license, do not download, install,
// nabl	 copy or use the software.
// jftb	
// uhoh	                          License Agreement
// qqid	         For OpenVSS - Open Source Video Surveillance System
// ryob	
// nxtz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gaqo	
// nzap	Third party copyrights are property of their respective owners.
// bttj	
// awmq	Redistribution and use in source and binary forms, with or without modification,
// coeq	are permitted provided that the following conditions are met:
// yozv	
// yymt	  * Redistribution's of source code must retain the above copyright notice,
// akjq	    this list of conditions and the following disclaimer.
// gbfj	
// oenv	  * Redistribution's in binary form must reproduce the above copyright notice,
// hzfx	    this list of conditions and the following disclaimer in the documentation
// wydv	    and/or other materials provided with the distribution.
// mxyz	
// scbr	  * Neither the name of the copyright holders nor the names of its contributors 
// avpp	    may not be used to endorse or promote products derived from this software 
// ngor	    without specific prior written permission.
// jdcy	
// qdcx	This software is provided by the copyright holders and contributors "as is" and
// ajjz	any express or implied warranties, including, but not limited to, the implied
// icya	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uqhd	In no event shall the Prince of Songkla University or contributors be liable 
// lkxd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// znit	(including, but not limited to, procurement of substitute goods or services;
// pyha	loss of use, data, or profits; or business interruption) however caused
// kons	and on any theory of liability, whether in contract, strict liability,
// weei	or tort (including negligence or otherwise) arising in any way out of
// ubyj	the use of this software, even if advised of the possibility of such damage.
// tciy	
// wpuw	Intelligent Systems Laboratory (iSys Lab)
// zlfz	Faculty of Engineering, Prince of Songkla University, THAILAND
// gyzd	Project leader by Nikom SUVONVORN
// ujic	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Encoder;

namespace Vs.Encoder.Wmv
{
    public partial class VsWmvSetupPage : UserControl, VsICoreEncoderPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsWmvSetupPage()
        {
            InitializeComponent();
            UpdateState();
        }

        #region VsICoreEncoderPage Members

        bool VsICoreEncoderPage.Apply()
        {
            return true;
        }

        bool VsICoreEncoderPage.Completed
        {
            get { return completed; }
        }

        void VsICoreEncoderPage.Display()
        {
            codecsName.Focus();
            codecsName.SelectionStart = codecsName.TextLength;
        }

        object VsICoreEncoderPage.GetConfiguration()
        {
            VsWmvEncoderConfiguration cfg = new VsWmvEncoderConfiguration();

            try
            {
                cfg.ImageWidth = int.Parse(imageWidth.Text);
                cfg.ImageHeight = int.Parse(imageHeight.Text);
                cfg.CodecsName = codecsName.Text;
                cfg.Quality = int.Parse(quality.Text);
            }
            catch(Exception)
            {
            }

            return (object)cfg;
        }

        void VsICoreEncoderPage.SetConfiguration(object config)
        {
            VsWmvEncoderConfiguration cfg = (VsWmvEncoderConfiguration)config;

            if (cfg != null)
            {
                try
                {
                    imageWidth.Text = cfg.ImageWidth.ToString();
                    imageHeight.Text = cfg.ImageHeight.ToString();
                    codecsName.Text = cfg.CodecsName;
                    quality.Text = cfg.Quality.ToString();
                }
                catch (Exception)
                {
                }
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
    }
}
