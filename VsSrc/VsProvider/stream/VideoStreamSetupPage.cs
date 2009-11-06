// nufg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ouue	
// eewr	 By downloading, copying, installing or using the software you agree to this license.
// rgfm	 If you do not agree to this license, do not download, install,
// aemt	 copy or use the software.
// llub	
// ftyl	                          License Agreement
// qxpn	         For OpenVss - Open Source Video Surveillance System
// ftwf	
// hkyo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// yxaw	
// cbzd	Third party copyrights are property of their respective owners.
// mexc	
// mswc	Redistribution and use in source and binary forms, with or without modification,
// adbu	are permitted provided that the following conditions are met:
// vjng	
// oimy	  * Redistribution's of source code must retain the above copyright notice,
// jzfp	    this list of conditions and the following disclaimer.
// fxun	
// lxzd	  * Redistribution's in binary form must reproduce the above copyright notice,
// uvym	    this list of conditions and the following disclaimer in the documentation
// anan	    and/or other materials provided with the distribution.
// xufd	
// ietp	  * Neither the name of the copyright holders nor the names of its contributors 
// jtit	    may not be used to endorse or promote products derived from this software 
// pbtm	    without specific prior written permission.
// zhxp	
// xirc	This software is provided by the copyright holders and contributors "as is" and
// exaa	any express or implied warranties, including, but not limited to, the implied
// kbgb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hzap	In no event shall the Prince of Songkla University or contributors be liable 
// tbhb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// efer	(including, but not limited to, procurement of substitute goods or services;
// pfot	loss of use, data, or profits; or business interruption) however caused
// blms	and on any theory of liability, whether in contract, strict liability,
// plpp	or tort (including negligence or otherwise) arising in any way out of
// ddzl	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core.Provider;

namespace Vs.Provider.Stream
{
	/// <summary>
	/// Summary description for VideoStreamSetupPage.
	/// </summary>
	public class VideoStreamSetupPage : System.Windows.Forms.UserControl, VsICoreProviderPage
	{
		private bool completed = false;
		private System.Windows.Forms.TextBox urlBox;
		private System.Windows.Forms.Label label1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// state changed event
		public event EventHandler StateChanged;

		// Constructor
		public VideoStreamSetupPage()
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
			this.urlBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// urlBox
			// 
			this.urlBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.urlBox.Location = new System.Drawing.Point(50, 10);
			this.urlBox.Name = "urlBox";
			this.urlBox.Size = new System.Drawing.Size(240, 20);
			this.urlBox.TabIndex = 1;
			this.urlBox.Text = "";
			this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "&URL:";
			// 
			// VideoStreamSetupPage
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.urlBox,
																		  this.label1});
			this.Name = "VideoStreamSetupPage";
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
			StreamConfiguration config = new StreamConfiguration();

			config.source = urlBox.Text;

			return (object) config;
		}

		// Set configuration
		public void SetConfiguration(object config)
		{
			StreamConfiguration cfg = (StreamConfiguration) config;

			if (cfg != null)
			{
				urlBox.Text = cfg.source;
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
