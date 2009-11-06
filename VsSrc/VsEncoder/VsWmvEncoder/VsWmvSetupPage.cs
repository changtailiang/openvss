// pxru	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dytw	
// zdah	 By downloading, copying, installing or using the software you agree to this license.
// vcod	 If you do not agree to this license, do not download, install,
// bqqg	 copy or use the software.
// guom	
// bjgs	                          License Agreement
// fxwd	         For OpenVss - Open Source Video Surveillance System
// mgpa	
// cgxm	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ggvo	
// ofwm	Third party copyrights are property of their respective owners.
// koez	
// utou	Redistribution and use in source and binary forms, with or without modification,
// ifst	are permitted provided that the following conditions are met:
// sarc	
// gxvp	  * Redistribution's of source code must retain the above copyright notice,
// noau	    this list of conditions and the following disclaimer.
// tdaz	
// yzxw	  * Redistribution's in binary form must reproduce the above copyright notice,
// ntir	    this list of conditions and the following disclaimer in the documentation
// swis	    and/or other materials provided with the distribution.
// surx	
// oduf	  * Neither the name of the copyright holders nor the names of its contributors 
// pthr	    may not be used to endorse or promote products derived from this software 
// jgzv	    without specific prior written permission.
// njfr	
// towi	This software is provided by the copyright holders and contributors "as is" and
// hwgz	any express or implied warranties, including, but not limited to, the implied
// sajk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ocws	In no event shall the Prince of Songkla University or contributors be liable 
// wdgq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jukf	(including, but not limited to, procurement of substitute goods or services;
// rgmg	loss of use, data, or profits; or business interruption) however caused
// tmdi	and on any theory of liability, whether in contract, strict liability,
// qrze	or tort (including negligence or otherwise) arising in any way out of
// yips	the use of this software, even if advised of the possibility of such damage.

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
