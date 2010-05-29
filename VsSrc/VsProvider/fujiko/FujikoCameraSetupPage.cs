// xptx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// awjf	
// alin	 By downloading, copying, installing or using the software you agree to this license.
// myem	 If you do not agree to this license, do not download, install,
// wwtq	 copy or use the software.
// stkg	
// puzo	                          License Agreement
// rgaz	         For OpenVSS - Open Source Video Surveillance System
// quvd	
// xoad	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tjqp	
// pjlq	Third party copyrights are property of their respective owners.
// ohup	
// beze	Redistribution and use in source and binary forms, with or without modification,
// fmif	are permitted provided that the following conditions are met:
// xvou	
// kixs	  * Redistribution's of source code must retain the above copyright notice,
// cbpi	    this list of conditions and the following disclaimer.
// vqwj	
// cvqg	  * Redistribution's in binary form must reproduce the above copyright notice,
// iiak	    this list of conditions and the following disclaimer in the documentation
// llxl	    and/or other materials provided with the distribution.
// vryk	
// fvfy	  * Neither the name of the copyright holders nor the names of its contributors 
// vweg	    may not be used to endorse or promote products derived from this software 
// ltnm	    without specific prior written permission.
// smtl	
// ipbk	This software is provided by the copyright holders and contributors "as is" and
// vbxp	any express or implied warranties, including, but not limited to, the implied
// ueiz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// llxl	In no event shall the Prince of Songkla University or contributors be liable 
// ceca	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kxog	(including, but not limited to, procurement of substitute goods or services;
// qkup	loss of use, data, or profits; or business interruption) however caused
// unrz	and on any theory of liability, whether in contract, strict liability,
// rmdf	or tort (including negligence or otherwise) arising in any way out of
// pood	the use of this software, even if advised of the possibility of such damage.
// xqdq	
// neva	Intelligent Systems Laboratory (iSys Lab)
// vckn	Faculty of Engineering, Prince of Songkla University, THAILAND
// jtak	Project leader by Nikom SUVONVORN
// bvtl	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core.Provider;

namespace Vs.Provider.Fujiko
{
	/// <summary>
	/// Summary description for DLinkCameraSetupPage.
	/// </summary>
	public class DLinkCameraSetupPage : System.Windows.Forms.UserControl, VsICoreProviderPage
	{
		private static int[] frameIntervals = new int[] {0, 100, 142, 200, 333, 1000,
															5000, 10000, 15000, 20000, 30000, 60000};
        private bool completed = false;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.Label label1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// new frame event
		public event EventHandler StateChanged;

		// Constructor
		public DLinkCameraSetupPage()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordBox.Location = new System.Drawing.Point(70, 70);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(220, 20);
            this.passwordBox.TabIndex = 5;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Password:";
            // 
            // loginBox
            // 
            this.loginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loginBox.Location = new System.Drawing.Point(70, 40);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(220, 20);
            this.loginBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Login:";
            // 
            // serverBox
            // 
            this.serverBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverBox.Location = new System.Drawing.Point(70, 10);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(220, 20);
            this.serverBox.TabIndex = 1;
            this.serverBox.TextChanged += new System.EventHandler(this.serverBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Server:";
            // 
            // DLinkCameraSetupPage
            // 
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.label1);
            this.Name = "DLinkCameraSetupPage";
            this.Size = new System.Drawing.Size(300, 113);
            this.ResumeLayout(false);
            this.PerformLayout();

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
			serverBox.Focus();
			serverBox.SelectionStart = serverBox.TextLength;
		}

		// Apply the page
		public bool Apply()
		{
			return true;
		}

		// Get configuration object
		public object GetConfiguration()
		{
			DLinkConfiguration config = new DLinkConfiguration();

			config.source	= serverBox.Text;
			config.login	= loginBox.Text;
			config.password	= passwordBox.Text;

			return (object) config;
		}

		// Set configuration
		public void SetConfiguration(object config)
		{
			DLinkConfiguration cfg = (DLinkConfiguration) config;

			if (cfg != null)
			{
				serverBox.Text = cfg.source;
				loginBox.Text = cfg.login;
				passwordBox.Text = cfg.password;
			}
		}

		// Server edit box changed
		private void serverBox_TextChanged(object sender, System.EventArgs e)
		{
			completed = (serverBox.TextLength != 0);

			if (StateChanged != null)
				StateChanged(this, new EventArgs());
		}
	}
}
