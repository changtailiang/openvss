// rkit	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// make	
// lvmd	 By downloading, copying, installing or using the software you agree to this license.
// pplq	 If you do not agree to this license, do not download, install,
// xlnz	 copy or use the software.
// sacs	
// lwgo	                          License Agreement
// egnk	         For OpenVss - Open Source Video Surveillance System
// lzvg	
// uokg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ddpn	
// xsva	Third party copyrights are property of their respective owners.
// jvpe	
// hziq	Redistribution and use in source and binary forms, with or without modification,
// ipiq	are permitted provided that the following conditions are met:
// uvaf	
// hbsp	  * Redistribution's of source code must retain the above copyright notice,
// tfvi	    this list of conditions and the following disclaimer.
// agvo	
// kpus	  * Redistribution's in binary form must reproduce the above copyright notice,
// bgfi	    this list of conditions and the following disclaimer in the documentation
// qjcl	    and/or other materials provided with the distribution.
// qexe	
// gumh	  * Neither the name of the copyright holders nor the names of its contributors 
// dkfv	    may not be used to endorse or promote products derived from this software 
// afge	    without specific prior written permission.
// zgdb	
// dtgt	This software is provided by the copyright holders and contributors "as is" and
// vpoo	any express or implied warranties, including, but not limited to, the implied
// qroy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zgzo	In no event shall the Prince of Songkla University or contributors be liable 
// iqcf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// tola	(including, but not limited to, procurement of substitute goods or services;
// jysv	loss of use, data, or profits; or business interruption) however caused
// zajk	and on any theory of liability, whether in contract, strict liability,
// fahw	or tort (including negligence or otherwise) arising in any way out of
// ydjr	the use of this software, even if advised of the possibility of such damage.

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
