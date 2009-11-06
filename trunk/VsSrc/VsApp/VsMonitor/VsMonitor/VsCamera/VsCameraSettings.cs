// egsp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// txwi	
// acov	 By downloading, copying, installing or using the software you agree to this license.
// ehfi	 If you do not agree to this license, do not download, install,
// ztol	 copy or use the software.
// mqza	
// rgjl	                          License Agreement
// ekxh	         For OpenVss - Open Source Video Surveillance System
// rvlv	
// zvew	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xlxs	
// namt	Third party copyrights are property of their respective owners.
// ubtk	
// rgan	Redistribution and use in source and binary forms, with or without modification,
// gsxn	are permitted provided that the following conditions are met:
// nldp	
// fhej	  * Redistribution's of source code must retain the above copyright notice,
// wkjd	    this list of conditions and the following disclaimer.
// psna	
// shmq	  * Redistribution's in binary form must reproduce the above copyright notice,
// tqrd	    this list of conditions and the following disclaimer in the documentation
// rmpk	    and/or other materials provided with the distribution.
// vxog	
// xqim	  * Neither the name of the copyright holders nor the names of its contributors 
// himg	    may not be used to endorse or promote products derived from this software 
// wdxk	    without specific prior written permission.
// spvz	
// szvz	This software is provided by the copyright holders and contributors "as is" and
// fguw	any express or implied warranties, including, but not limited to, the implied
// tayt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rtny	In no event shall the Prince of Songkla University or contributors be liable 
// vcgy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jbtk	(including, but not limited to, procurement of substitute goods or services;
// ugup	loss of use, data, or profits; or business interruption) however caused
// thlb	and on any theory of liability, whether in contract, strict liability,
// qqrv	or tort (including negligence or otherwise) arising in any way out of
// bpbq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Provider;
using Vs.Core.Server;

namespace Vs.Monitor
{
	/// <summary>
	/// Summary description for CameraSettings.
	/// </summary>
	public class VsCameraSettings : System.Windows.Forms.UserControl, VsIDialogWizard
	{
        private VsCamera vsCamera = null;

		private bool completed = false;
		private VsICoreProviderPage sourcePage;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
                    if (sourcePage != null)
                        Controls.Remove((Control)sourcePage);

                    completed = false;

                    // check provider
                    if(vsCamera.Provider != null)
                        sourcePage = vsCamera.Provider.GetSettingsPage();

					// check setting page
                    if (sourcePage != null)
                    {
                        Control control = (Control)sourcePage;

                        // add control
                        control.Dock = DockStyle.Fill;
                        Controls.Add(control);

                        // events
                        sourcePage.StateChanged += new EventHandler(page_StateChanged);

                        // set configuration
                        sourcePage.SetConfiguration(vsCamera.CameraConfiguration);

                        // completed
                        completed = sourcePage.Completed;
                    }
				}
			}
		}

		// Constructor
		public VsCameraSettings()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// VsCameraSettings
			// 
			this.Name = "CameraSettings";
			this.Size = new System.Drawing.Size(320, 180);

		}
		#endregion

		// PageName property
		public string PageName
		{
			get { return "Video Settings"; }
		}

		// PageDescription property
		public string PageDescription
		{
			get
			{
                string str = "Video settings";
				if (vsCamera.Provider != null)
				{
                    str += " : " + vsCamera.Provider.Name;
				}
				return str;
			}
		}

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

		// Show the page
		public void Display()
		{
			if (sourcePage != null)
			{
				// show control
				((Control) sourcePage).Show();
				// notify page
				sourcePage.Display();
			}
		}

		// Apply the page
		public bool Apply()
		{
			bool	ret = false;

			if (sourcePage != null)
			{
				if ((ret = sourcePage.Apply()) == true)
				{
                    vsCamera.CameraConfiguration = sourcePage.GetConfiguration();
				}
			}

			return ret;
		}

		// On source page state changed
		private void page_StateChanged(object sender, System.EventArgs e)
		{
			completed = sourcePage.Completed;

			// notify wizard
			if (StateChanged != null) StateChanged(this, new EventArgs());
		}
	}
}
