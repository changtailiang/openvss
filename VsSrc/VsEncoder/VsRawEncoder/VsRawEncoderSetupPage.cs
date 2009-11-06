// gows	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mfkj	
// ibfh	 By downloading, copying, installing or using the software you agree to this license.
// ppyl	 If you do not agree to this license, do not download, install,
// hmuf	 copy or use the software.
// vxck	
// maua	                          License Agreement
// utnq	         For OpenVss - Open Source Video Surveillance System
// qneq	
// qgzb	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// cghf	
// lcja	Third party copyrights are property of their respective owners.
// quik	
// fani	Redistribution and use in source and binary forms, with or without modification,
// mmfl	are permitted provided that the following conditions are met:
// lkpp	
// nprb	  * Redistribution's of source code must retain the above copyright notice,
// khvb	    this list of conditions and the following disclaimer.
// ntdp	
// qwyk	  * Redistribution's in binary form must reproduce the above copyright notice,
// rtjz	    this list of conditions and the following disclaimer in the documentation
// ldlq	    and/or other materials provided with the distribution.
// awdd	
// anqs	  * Neither the name of the copyright holders nor the names of its contributors 
// qrrw	    may not be used to endorse or promote products derived from this software 
// lhqi	    without specific prior written permission.
// zgxm	
// wysp	This software is provided by the copyright holders and contributors "as is" and
// nvus	any express or implied warranties, including, but not limited to, the implied
// apek	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dabo	In no event shall the Prince of Songkla University or contributors be liable 
// drbz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// clyy	(including, but not limited to, procurement of substitute goods or services;
// fcyj	loss of use, data, or profits; or business interruption) however caused
// dbae	and on any theory of liability, whether in contract, strict liability,
// gzuc	or tort (including negligence or otherwise) arising in any way out of
// doqe	the use of this software, even if advised of the possibility of such damage.

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
