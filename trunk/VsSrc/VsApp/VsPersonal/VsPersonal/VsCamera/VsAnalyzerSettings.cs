// hlfw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// erbj	
// gonb	 By downloading, copying, installing or using the software you agree to this license.
// mgba	 If you do not agree to this license, do not download, install,
// ipoo	 copy or use the software.
// wqmm	
// jlwz	                          License Agreement
// pcnl	         For OpenVss - Open Source Video Surveillance System
// kxtc	
// vtjm	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// chkj	
// kzak	Third party copyrights are property of their respective owners.
// zbvu	
// kper	Redistribution and use in source and binary forms, with or without modification,
// ztnt	are permitted provided that the following conditions are met:
// vctd	
// bcqp	  * Redistribution's of source code must retain the above copyright notice,
// mzfo	    this list of conditions and the following disclaimer.
// gclp	
// fcbj	  * Redistribution's in binary form must reproduce the above copyright notice,
// klzn	    this list of conditions and the following disclaimer in the documentation
// gtav	    and/or other materials provided with the distribution.
// tcdb	
// gpqa	  * Neither the name of the copyright holders nor the names of its contributors 
// ngii	    may not be used to endorse or promote products derived from this software 
// jlya	    without specific prior written permission.
// vhnh	
// dolw	This software is provided by the copyright holders and contributors "as is" and
// sdij	any express or implied warranties, including, but not limited to, the implied
// cgxh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bvwj	In no event shall the Prince of Songkla University or contributors be liable 
// weiq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// llbz	(including, but not limited to, procurement of substitute goods or services;
// utay	loss of use, data, or profits; or business interruption) however caused
// nzrz	and on any theory of liability, whether in contract, strict liability,
// gtre	or tort (including negligence or otherwise) arising in any way out of
// rgjc	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;
using Vs.Core.Analyzer;

namespace Vs.Monitor
{
    public partial class VsAnalyzerSettings : UserControl, VsIDialogWizard
    {
        private VsCamera vsCamera = null;
        private VsChannel vsChannel = null;
        private bool completed = false;
        private VsICoreAnalyzerPage analyserPage;

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
                    if (analyserPage != null)
                        Controls.Remove((Control)analyserPage);

                    completed = false;

                    // check provider
                    if (vsCamera.Analyser != null)
                        analyserPage = vsCamera.Analyser.GetSettingsPage();

                    // check setting page
                    if (analyserPage != null)
                    {
                        Control control = (Control)analyserPage;

                        // add control
                        control.Dock = DockStyle.Fill;
                        Controls.Add(control);

                        // events
                        analyserPage.StateChanged += new EventHandler(page_StateChanged);

                        // set configuration
                        analyserPage.SetConfiguration(vsCamera.AnalyserConfiguration);

                        // completed
                        completed = analyserPage.Completed;
                    }
                }
            }
        }

        // Channel property
        public VsChannel Channel
        {
            set
            {
                // check channel
                if (value != null)
                {
                    vsChannel = value;

                    // check exist setting page
                    // remove old page
                    if (analyserPage != null)
                        Controls.Remove((Control)analyserPage);

                    completed = false;

                    // check provider
                    if (vsChannel.Analyser != null)
                        analyserPage = vsChannel.Analyser.GetSettingsPage();

                    // check setting page
                    if (analyserPage != null)
                    {
                        Control control = (Control)analyserPage;

                        // add control
                        control.Dock = DockStyle.Fill;
                        Controls.Add(control);

                        // events
                        analyserPage.StateChanged += new EventHandler(page_StateChanged);

                        // set configuration
                        analyserPage.SetConfiguration(vsChannel.AnalyserConfiguration);

                        // completed
                        completed = analyserPage.Completed;
                    }
                }
            }
        }

        // Constructor
        public VsAnalyzerSettings()
        {
            InitializeComponent();
        }

        #region VsIDialogWizard Members

        string VsIDialogWizard.PageName
        {
            get { return "Analyser Settings"; }
        }

        string VsIDialogWizard.PageDescription
        {
            get
            {
                string str = "Analyser settings";
                if (vsCamera != null && vsCamera.Analyser != null)
                {
                    str += " : " + vsCamera.Analyser.Name;
                }
                if (vsChannel != null && vsChannel.Analyser != null)
                {
                    str += " : " + vsChannel.Analyser.Name;
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
            if (analyserPage != null)
            {
                // show control
                ((Control)analyserPage).Show();

                // notify page
                analyserPage.Display();
            }
        }

        bool VsIDialogWizard.Apply()
        {
            bool ret = false;

            if (analyserPage != null)
            {
                if ((ret = analyserPage.Apply()) == true)
                {
                    if (vsCamera != null)
                    {
                        vsCamera.AnalyserConfiguration = analyserPage.GetConfiguration();
                        vsCamera.AnalyzerSource.AnalyzerConfiguration = vsCamera.AnalyserConfiguration.GetConfiguration();
                    }
                    if (vsChannel != null)
                    {
                        vsChannel.AnalyserConfiguration = analyserPage.GetConfiguration();
                        vsChannel.AnalyzerSource.AnalyzerConfiguration = vsChannel.AnalyserConfiguration.GetConfiguration();
                    }
                }
            }

            return ret;
        }

        #endregion

        public bool FinalUpdate()
        {
            bool ret = false;

            if (analyserPage != null)
            {
                if ((ret = analyserPage.Apply()) == true)
                {
                    if (vsCamera != null)
                        vsCamera.AnalyserConfiguration = analyserPage.GetConfiguration();
                    if (vsChannel != null)
                        vsChannel.AnalyserConfiguration = analyserPage.GetConfiguration();
                }
            }

            return ret;
        }       

        // On source page state changed
        private void page_StateChanged(object sender, System.EventArgs e)
        {
            completed = analyserPage.Completed;

            // notify wizard
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }
    }
}
