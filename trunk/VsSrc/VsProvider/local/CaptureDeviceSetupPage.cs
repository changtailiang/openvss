// vdja	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bprn	
// jivl	 By downloading, copying, installing or using the software you agree to this license.
// prxw	 If you do not agree to this license, do not download, install,
// olpw	 copy or use the software.
// ufye	
// zzkr	                          License Agreement
// hzat	         For OpenVSS - Open Source Video Surveillance System
// mujw	
// wnvm	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// efma	
// htxt	Third party copyrights are property of their respective owners.
// diag	
// gpgp	Redistribution and use in source and binary forms, with or without modification,
// ffbb	are permitted provided that the following conditions are met:
// fafj	
// iczv	  * Redistribution's of source code must retain the above copyright notice,
// hbaa	    this list of conditions and the following disclaimer.
// pdrp	
// txwf	  * Redistribution's in binary form must reproduce the above copyright notice,
// cqnz	    this list of conditions and the following disclaimer in the documentation
// ztmw	    and/or other materials provided with the distribution.
// nurq	
// muhd	  * Neither the name of the copyright holders nor the names of its contributors 
// zcse	    may not be used to endorse or promote products derived from this software 
// ublc	    without specific prior written permission.
// izqd	
// xrvh	This software is provided by the copyright holders and contributors "as is" and
// iwyo	any express or implied warranties, including, but not limited to, the implied
// nfko	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pchn	In no event shall the Prince of Songkla University or contributors be liable 
// kjov	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vopq	(including, but not limited to, procurement of substitute goods or services;
// eskb	loss of use, data, or profits; or business interruption) however caused
// fkqz	and on any theory of liability, whether in contract, strict liability,
// djzw	or tort (including negligence or otherwise) arising in any way out of
// yjiq	the use of this software, even if advised of the possibility of such damage.
// vsqu	
// repr	Intelligent Systems Laboratory (iSys Lab)
// uysz	Faculty of Engineering, Prince of Songkla University, THAILAND
// kvhj	Project leader by Nikom SUVONVORN
// cfcq	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core.Provider;
using Vs.Provider.Dshow;
using Vs.Provider.Dshow.Core;

namespace Vs.Provider.Local
{
	/// <summary>
	/// Summary description for CaptureDeviceSetupPage.
	/// </summary>
	public class CaptureDeviceSetupPage : System.Windows.Forms.UserControl, VsICoreProviderPage
	{
		FilterCollection filters;
		private bool completed = false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox deviceCombo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// state changed event
		public event EventHandler StateChanged;

		// Constructor
		public CaptureDeviceSetupPage()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			//
			filters = new FilterCollection(FilterCategory.VideoInputDevice);

			if (filters.Count == 0)
			{
				deviceCombo.Items.Add("No local capture devices");
				deviceCombo.Enabled = false;
			}
			else
			{
				// add all devices to combo
				foreach (Filter filter in filters)
				{
					deviceCombo.Items.Add(filter.Name);
				}
				completed = true;
			}
			deviceCombo.SelectedIndex = 0;
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
			this.label1 = new System.Windows.Forms.Label();
			this.deviceCombo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Device:";
			// 
			// deviceCombo
			// 
			this.deviceCombo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.deviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.deviceCombo.Location = new System.Drawing.Point(60, 10);
			this.deviceCombo.Name = "deviceCombo";
			this.deviceCombo.Size = new System.Drawing.Size(230, 21);
			this.deviceCombo.TabIndex = 1;
			// 
			// CaptureDeviceSetupPage
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.deviceCombo,
																		  this.label1});
			this.Name = "CaptureDeviceSetupPage";
			this.Size = new System.Drawing.Size(300, 150);
			this.ResumeLayout(false);

		}
		#endregion

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

		// Show the page
		public void Display()
		{
			deviceCombo.Focus();
		}

		// Apply the page
		public bool Apply()
		{
			return true;
		}

		// Get configuration object
		public object GetConfiguration()
		{
			LocalConfiguration config = new LocalConfiguration();

			config.source = filters[deviceCombo.SelectedIndex].MonikerString;

			return (object) config;
		}

		// Set configuration
		public void SetConfiguration(object config)
		{
			LocalConfiguration cfg = (LocalConfiguration) config;

			if (cfg != null)
			{
				for (int i = 0; i < filters.Count; i++)
				{
					if (filters[i].MonikerString == cfg.source)
					{
						deviceCombo.SelectedIndex = i;
						break;
					}
				}
			}
		}
	}
}
