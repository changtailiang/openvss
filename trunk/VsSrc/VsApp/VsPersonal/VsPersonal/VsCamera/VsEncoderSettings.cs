// rcwf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// crpn	
// adia	 By downloading, copying, installing or using the software you agree to this license.
// miln	 If you do not agree to this license, do not download, install,
// ifog	 copy or use the software.
// ztow	
// ddrc	                          License Agreement
// usma	         For OpenVSS - Open Source Video Surveillance System
// qata	
// waln	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// okqg	
// nqqr	Third party copyrights are property of their respective owners.
// prfz	
// feax	Redistribution and use in source and binary forms, with or without modification,
// ozbz	are permitted provided that the following conditions are met:
// amsh	
// rikm	  * Redistribution's of source code must retain the above copyright notice,
// okri	    this list of conditions and the following disclaimer.
// tbro	
// ciin	  * Redistribution's in binary form must reproduce the above copyright notice,
// mznc	    this list of conditions and the following disclaimer in the documentation
// nmul	    and/or other materials provided with the distribution.
// zwmw	
// ymmb	  * Neither the name of the copyright holders nor the names of its contributors 
// rjof	    may not be used to endorse or promote products derived from this software 
// gede	    without specific prior written permission.
// awfe	
// nmuf	This software is provided by the copyright holders and contributors "as is" and
// qomb	any express or implied warranties, including, but not limited to, the implied
// zquf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nzns	In no event shall the Prince of Songkla University or contributors be liable 
// xujg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ppxt	(including, but not limited to, procurement of substitute goods or services;
// udhh	loss of use, data, or profits; or business interruption) however caused
// vicq	and on any theory of liability, whether in contract, strict liability,
// hqyn	or tort (including negligence or otherwise) arising in any way out of
// bhfj	the use of this software, even if advised of the possibility of such damage.
// zlcb	
// pjrh	Intelligent Systems Laboratory (iSys Lab)
// rkhg	Faculty of Engineering, Prince of Songkla University, THAILAND
// nyox	Project leader by Nikom SUVONVORN
// obln	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Encoder;
using Vs.Core.Server;

namespace Vs.Monitor
{
    public partial class VsEncoderSettings : UserControl, VsIDialogWizard
    {
        private VsCamera vsCamera = null;
        private VsChannel vsChannel = null;
        private bool completed = false;
        private VsICoreEncoderPage encoderPage;

        // state changed event
        public event EventHandler StateChanged;
        // reset event
        public event EventHandler Reset;

        private VsCoreServer vsCoreMonitor;

        public VsCoreServer CoreMonitor
        {
            set { vsCoreMonitor = value; }
        }

        // Camera property
        public VsCamera Camera
        {
            set
            {
                // check camera
                if (value != null)
                {
                    vsCamera = value;

                    // check exist setting page
                    // remove old page
                    if (encoderPage != null)
                        Controls.Remove((Control)encoderPage);

                    completed = false;

                    // check provider
                    if (vsCamera.Encoder != null)
                        encoderPage = vsCamera.Encoder.GetSettingsPage();

                    // check setting page
                    if (encoderPage != null)
                    {
                        Control control = (Control)encoderPage;

                        // add control
                        control.Dock = DockStyle.Fill;
                        Controls.Add(control);

                        // events
                        encoderPage.StateChanged += new EventHandler(page_StateChanged);

                        // set configuration
                        encoderPage.SetConfiguration(vsCamera.EncoderConfiguration);

                        // completed
                        completed = encoderPage.Completed;
                    }
                }
            }
        }

        // Channel property
        public VsChannel Channel
        {
            set
            {
                // check camera
                if (value != null)
                {
                    vsChannel = value;

                    // check exist setting page
                    // remove old page
                    if (encoderPage != null)
                        Controls.Remove((Control)encoderPage);

                    completed = false;

                    // check provider
                    if (vsChannel.Encoder != null)
                        encoderPage = vsChannel.Encoder.GetSettingsPage();

                    // check setting page
                    if (encoderPage != null)
                    {
                        Control control = (Control)encoderPage;

                        // add control
                        control.Dock = DockStyle.Fill;
                        Controls.Add(control);

                        // events
                        encoderPage.StateChanged += new EventHandler(page_StateChanged);

                        // set configuration
                        encoderPage.SetConfiguration(vsChannel.EncoderConfiguration);

                        // completed
                        completed = encoderPage.Completed;
                    }
                }
            }
        }

        // Constructor
        public VsEncoderSettings()
        {
            InitializeComponent();
        }

        #region VsIDialogWizard Members

        string VsIDialogWizard.PageName
        {
            get { return "Encoder Settings"; }
        }

        string VsIDialogWizard.PageDescription
        {
            get
            {
                string str = "Encoder settings";
                if (vsCamera != null && vsCamera.Encoder != null)
                {
                    str += " : " + vsCamera.Encoder.Name;
                }
                if (vsChannel !=null && vsChannel.Encoder != null)
                {
                    str += " : " + vsChannel.Encoder.Name;
                }
                return str;
            }
        }

        bool VsIDialogWizard.Completed
        {
            get { return completed; }
        }

        void VsIDialogWizard.Display()
        {
            if (encoderPage != null)
            {
                // show control
                ((Control)encoderPage).Show();
                // notify page
                encoderPage.Display();
            }
        }

        bool VsIDialogWizard.Apply()
        {
            bool ret = false;

            if (encoderPage != null)
            {
                if ((ret = encoderPage.Apply()) == true)
                {
                    if (vsCamera != null) vsCamera.EncoderConfiguration = encoderPage.GetConfiguration();
                    if (vsChannel != null) vsChannel.EncoderConfiguration = encoderPage.GetConfiguration();
                }
            }

            return ret;
        }

        #endregion

        public bool FinalUpdate()
        {
            bool ret = false;

            if (encoderPage != null)
            {
                if ((ret = encoderPage.Apply()) == true)
                {
                    if (vsCamera != null) vsCamera.EncoderConfiguration = encoderPage.GetConfiguration();
                    if (vsChannel != null) vsChannel.EncoderConfiguration = encoderPage.GetConfiguration();
                }
            }

            return ret;
        }

        // On source page state changed
        private void page_StateChanged(object sender, System.EventArgs e)
        {
            completed = encoderPage.Completed;

            // notify wizard
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

    }
}
