// ihob	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// umry	
// cusc	 By downloading, copying, installing or using the software you agree to this license.
// oujv	 If you do not agree to this license, do not download, install,
// fuav	 copy or use the software.
// rjiw	
// keqc	                          License Agreement
// rbur	         For OpenVss - Open Source Video Surveillance System
// oqlr	
// boin	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vwzu	
// iino	Third party copyrights are property of their respective owners.
// cutt	
// moqy	Redistribution and use in source and binary forms, with or without modification,
// ysrq	are permitted provided that the following conditions are met:
// voha	
// abox	  * Redistribution's of source code must retain the above copyright notice,
// istr	    this list of conditions and the following disclaimer.
// lnav	
// koob	  * Redistribution's in binary form must reproduce the above copyright notice,
// qcaw	    this list of conditions and the following disclaimer in the documentation
// haez	    and/or other materials provided with the distribution.
// ansi	
// wsrg	  * Neither the name of the copyright holders nor the names of its contributors 
// oytg	    may not be used to endorse or promote products derived from this software 
// upgj	    without specific prior written permission.
// aciz	
// ovoj	This software is provided by the copyright holders and contributors "as is" and
// epzt	any express or implied warranties, including, but not limited to, the implied
// nlta	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wpxv	In no event shall the Prince of Songkla University or contributors be liable 
// zlut	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vtgl	(including, but not limited to, procurement of substitute goods or services;
// uhgb	loss of use, data, or profits; or business interruption) however caused
// vqvf	and on any theory of liability, whether in contract, strict liability,
// rfkf	or tort (including negligence or otherwise) arising in any way out of
// yjeh	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core.Provider;

namespace Vs.Provider.Mjpeg
{
	/// <summary>
	/// Summary description for MJPEGSourcePage.
	/// </summary>
	public class MJPEGSourcePage : System.Windows.Forms.UserControl, VsICoreProviderPage
	{
		private bool completed = false;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox urlBox;
		private System.Windows.Forms.Label label1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// new frame event
		public event EventHandler StateChanged;

		// Constructor
		public MJPEGSourcePage()
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
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.loginBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.urlBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// passwordBox
			// 
			this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.passwordBox.Location = new System.Drawing.Point(70, 70);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.Size = new System.Drawing.Size(220, 20);
			this.passwordBox.TabIndex = 5;
			this.passwordBox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 14);
			this.label3.TabIndex = 4;
			this.label3.Text = "&Password:";
			// 
			// loginBox
			// 
			this.loginBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.loginBox.Location = new System.Drawing.Point(70, 40);
			this.loginBox.Name = "loginBox";
			this.loginBox.Size = new System.Drawing.Size(220, 20);
			this.loginBox.TabIndex = 3;
			this.loginBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Login:";
			// 
			// urlBox
			// 
			this.urlBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.urlBox.Location = new System.Drawing.Point(70, 10);
			this.urlBox.Name = "urlBox";
			this.urlBox.Size = new System.Drawing.Size(220, 20);
			this.urlBox.TabIndex = 1;
			this.urlBox.Text = "";
			this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "&URL:";
			// 
			// MJPEGSourcePage
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.passwordBox,
																		  this.label3,
																		  this.loginBox,
																		  this.label2,
																		  this.urlBox,
																		  this.label1});
			this.Name = "MJPEGSourcePage";
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
			urlBox.Focus();	
			urlBox.SelectionStart = urlBox.TextLength;
		}

		// Apply the page
		public bool Apply()
		{
			return true;
		}

		// Get configuration object
		public object GetConfiguration()
		{
			MJPEGConfiguration	config = new MJPEGConfiguration();

			config.source	= urlBox.Text;
			config.login	= loginBox.Text;
			config.password	= passwordBox.Text;

			return (object) config;
		}

		// Set configuration
		public void SetConfiguration(object config)
		{
			MJPEGConfiguration	cfg = (MJPEGConfiguration) config;

			if (cfg != null)
			{
				urlBox.Text = cfg.source;
				loginBox.Text = cfg.login;
				passwordBox.Text = cfg.password;
			}
		}

		// URL changed
		private void urlBox_TextChanged(object sender, System.EventArgs e)
		{
			completed = (urlBox.TextLength != 0);

			if (StateChanged != null)
				StateChanged(this, new EventArgs());
		}
	}
}
