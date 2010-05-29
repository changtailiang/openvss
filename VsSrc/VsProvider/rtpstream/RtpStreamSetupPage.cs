// utjh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tavu	
// bwse	 By downloading, copying, installing or using the software you agree to this license.
// iowk	 If you do not agree to this license, do not download, install,
// xyxk	 copy or use the software.
// rrmu	
// jlol	                          License Agreement
// juad	         For OpenVSS - Open Source Video Surveillance System
// arig	
// vpao	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bnmd	
// qcvp	Third party copyrights are property of their respective owners.
// paxz	
// dwsc	Redistribution and use in source and binary forms, with or without modification,
// goxi	are permitted provided that the following conditions are met:
// mkkg	
// vpdr	  * Redistribution's of source code must retain the above copyright notice,
// fpoi	    this list of conditions and the following disclaimer.
// xijd	
// fjeg	  * Redistribution's in binary form must reproduce the above copyright notice,
// pywj	    this list of conditions and the following disclaimer in the documentation
// xbae	    and/or other materials provided with the distribution.
// yfzg	
// rscq	  * Neither the name of the copyright holders nor the names of its contributors 
// dfhb	    may not be used to endorse or promote products derived from this software 
// zejz	    without specific prior written permission.
// locu	
// npxx	This software is provided by the copyright holders and contributors "as is" and
// krsn	any express or implied warranties, including, but not limited to, the implied
// obju	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pzsa	In no event shall the Prince of Songkla University or contributors be liable 
// pire	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gsaz	(including, but not limited to, procurement of substitute goods or services;
// cchl	loss of use, data, or profits; or business interruption) however caused
// owyj	and on any theory of liability, whether in contract, strict liability,
// yfqj	or tort (including negligence or otherwise) arising in any way out of
// hcva	the use of this software, even if advised of the possibility of such damage.
// aocc	
// wmmz	Intelligent Systems Laboratory (iSys Lab)
// ljkc	Faculty of Engineering, Prince of Songkla University, THAILAND
// xxou	Project leader by Nikom SUVONVORN
// oyvh	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core.Provider;

namespace Vs.Provider.RtpStream
{
	/// <summary>
	/// Summary description for VideoStreamSetupPage.
	/// </summary>
	public class RtpStreamSetupPage : System.Windows.Forms.UserControl, VsICoreProviderPage
	{
		private bool completed = false;
		private System.Windows.Forms.TextBox urlBox;
		private System.Windows.Forms.Label label1;
        private Label label2;
        private TextBox portBox;
        private Label label3;
        private TextBox sourceDest;
        private Label label4;
        private TextBox ssrcBox;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// state changed event
		public event EventHandler StateChanged;

		// Constructor
		public RtpStreamSetupPage()
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
            this.label2 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sourceDest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ssrcBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlBox.Location = new System.Drawing.Point(50, 10);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(240, 20);
            this.urlBox.TabIndex = 1;
            this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "&URL_L:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // portBox
            // 
            this.portBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.portBox.Location = new System.Drawing.Point(50, 36);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(240, 20);
            this.portBox.TabIndex = 1;
            this.portBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "URL_D";
            // 
            // sourceDest
            // 
            this.sourceDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDest.Location = new System.Drawing.Point(50, 62);
            this.sourceDest.Name = "sourceDest";
            this.sourceDest.Size = new System.Drawing.Size(240, 20);
            this.sourceDest.TabIndex = 1;
            this.sourceDest.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "SSRC";
            // 
            // ssrcBox
            // 
            this.ssrcBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ssrcBox.Location = new System.Drawing.Point(50, 88);
            this.ssrcBox.Name = "ssrcBox";
            this.ssrcBox.Size = new System.Drawing.Size(240, 20);
            this.ssrcBox.TabIndex = 1;
            this.ssrcBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
            // 
            // RtpStreamSetupPage
            // 
            this.Controls.Add(this.ssrcBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sourceDest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.label1);
            this.Name = "RtpStreamSetupPage";
            this.Size = new System.Drawing.Size(300, 150);
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
			RtpStreamConfiguration config = new RtpStreamConfiguration();

			config.source = urlBox.Text;
            config.video_port = int.Parse(portBox.Text);
            config.dest = sourceDest.Text;

			return (object) config;
		}

		// Set configuration
		public void SetConfiguration(object config)
		{
			RtpStreamConfiguration cfg = (RtpStreamConfiguration) config;

			if (cfg != null)
			{
				urlBox.Text = cfg.source;
                portBox.Text = cfg.video_port.ToString();
                sourceDest.Text = cfg.dest;
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
