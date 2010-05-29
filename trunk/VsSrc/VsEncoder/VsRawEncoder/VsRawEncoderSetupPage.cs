// xrwc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ulks	
// btxc	 By downloading, copying, installing or using the software you agree to this license.
// baxv	 If you do not agree to this license, do not download, install,
// wbib	 copy or use the software.
// wgal	
// bcyi	                          License Agreement
// erbp	         For OpenVSS - Open Source Video Surveillance System
// rfaa	
// rfhc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ebtf	
// cobm	Third party copyrights are property of their respective owners.
// zxso	
// iroq	Redistribution and use in source and binary forms, with or without modification,
// rlbr	are permitted provided that the following conditions are met:
// mcnj	
// rhkv	  * Redistribution's of source code must retain the above copyright notice,
// axeq	    this list of conditions and the following disclaimer.
// tfxv	
// nuim	  * Redistribution's in binary form must reproduce the above copyright notice,
// amih	    this list of conditions and the following disclaimer in the documentation
// zngz	    and/or other materials provided with the distribution.
// rjif	
// eqqc	  * Neither the name of the copyright holders nor the names of its contributors 
// njou	    may not be used to endorse or promote products derived from this software 
// dflc	    without specific prior written permission.
// tbud	
// uscw	This software is provided by the copyright holders and contributors "as is" and
// doqz	any express or implied warranties, including, but not limited to, the implied
// tgkd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bleq	In no event shall the Prince of Songkla University or contributors be liable 
// oymd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// puhe	(including, but not limited to, procurement of substitute goods or services;
// gnjv	loss of use, data, or profits; or business interruption) however caused
// agox	and on any theory of liability, whether in contract, strict liability,
// sdfy	or tort (including negligence or otherwise) arising in any way out of
// hmcp	the use of this software, even if advised of the possibility of such damage.
// zqjh	
// zkts	Intelligent Systems Laboratory (iSys Lab)
// bvou	Faculty of Engineering, Prince of Songkla University, THAILAND
// proa	Project leader by Nikom SUVONVORN
// kxqp	Project website at http://code.google.com/p/openvss/

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
    public partial class VsRawEncoderSetupPage : UserControl, VsICoreEncoderPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsRawEncoderSetupPage()
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
            VsRawEncoderConfiguration cfg = new VsRawEncoderConfiguration();

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
            VsRawEncoderConfiguration cfg = (VsRawEncoderConfiguration)config;

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
