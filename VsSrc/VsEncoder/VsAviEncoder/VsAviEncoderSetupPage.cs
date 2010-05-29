// doyq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zrff	
// zvdm	 By downloading, copying, installing or using the software you agree to this license.
// fuqd	 If you do not agree to this license, do not download, install,
// mzlh	 copy or use the software.
// xito	
// epij	                          License Agreement
// smay	         For OpenVSS - Open Source Video Surveillance System
// lrab	
// wflr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// sfmy	
// gcfq	Third party copyrights are property of their respective owners.
// bxif	
// vvyv	Redistribution and use in source and binary forms, with or without modification,
// uklj	are permitted provided that the following conditions are met:
// jwmn	
// veao	  * Redistribution's of source code must retain the above copyright notice,
// tohg	    this list of conditions and the following disclaimer.
// otps	
// wvic	  * Redistribution's in binary form must reproduce the above copyright notice,
// jrhu	    this list of conditions and the following disclaimer in the documentation
// dudp	    and/or other materials provided with the distribution.
// sfhl	
// tbiw	  * Neither the name of the copyright holders nor the names of its contributors 
// sydb	    may not be used to endorse or promote products derived from this software 
// brwn	    without specific prior written permission.
// qcrb	
// ggzz	This software is provided by the copyright holders and contributors "as is" and
// cjzr	any express or implied warranties, including, but not limited to, the implied
// oska	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bkvo	In no event shall the Prince of Songkla University or contributors be liable 
// hvmn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lszx	(including, but not limited to, procurement of substitute goods or services;
// rhas	loss of use, data, or profits; or business interruption) however caused
// uudb	and on any theory of liability, whether in contract, strict liability,
// dbjm	or tort (including negligence or otherwise) arising in any way out of
// fhjk	the use of this software, even if advised of the possibility of such damage.
// bqia	
// oczr	Intelligent Systems Laboratory (iSys Lab)
// vifv	Faculty of Engineering, Prince of Songkla University, THAILAND
// pdqo	Project leader by Nikom SUVONVORN
// gbhu	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Encoder;

namespace Vs.Encoder.Avi
{
    public partial class VsAviEncoderSetupPage : UserControl, VsICoreEncoderPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsAviEncoderSetupPage()
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
            VsAviEncoderConfiguration cfg = new VsAviEncoderConfiguration();

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
            VsAviEncoderConfiguration cfg = (VsAviEncoderConfiguration)config;

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
