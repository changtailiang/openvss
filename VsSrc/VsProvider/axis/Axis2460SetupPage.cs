// uqqb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nhgq	
// yohv	 By downloading, copying, installing or using the software you agree to this license.
// clbu	 If you do not agree to this license, do not download, install,
// lmqs	 copy or use the software.
// rmeb	
// jofd	                          License Agreement
// npja	         For OpenVSS - Open Source Video Surveillance System
// mzcj	
// xxjr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vqfm	
// qrzz	Third party copyrights are property of their respective owners.
// vmon	
// ccth	Redistribution and use in source and binary forms, with or without modification,
// lprz	are permitted provided that the following conditions are met:
// cddj	
// egid	  * Redistribution's of source code must retain the above copyright notice,
// jsxn	    this list of conditions and the following disclaimer.
// cywb	
// hskr	  * Redistribution's in binary form must reproduce the above copyright notice,
// ogha	    this list of conditions and the following disclaimer in the documentation
// avxj	    and/or other materials provided with the distribution.
// guxh	
// fkps	  * Neither the name of the copyright holders nor the names of its contributors 
// mvhj	    may not be used to endorse or promote products derived from this software 
// iwqd	    without specific prior written permission.
// pale	
// grzs	This software is provided by the copyright holders and contributors "as is" and
// fzkv	any express or implied warranties, including, but not limited to, the implied
// vdij	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jywo	In no event shall the Prince of Songkla University or contributors be liable 
// uqhr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ieol	(including, but not limited to, procurement of substitute goods or services;
// kajr	loss of use, data, or profits; or business interruption) however caused
// qdla	and on any theory of liability, whether in contract, strict liability,
// jtdo	or tort (including negligence or otherwise) arising in any way out of
// uebf	the use of this software, even if advised of the possibility of such damage.
// auwj	
// nxak	Intelligent Systems Laboratory (iSys Lab)
// abjz	Faculty of Engineering, Prince of Songkla University, THAILAND
// suvb	Project leader by Nikom SUVONVORN
// coie	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core.Provider;

namespace Vs.Provider.Axis
{
	/// <summary>
	/// Summary description for Axis2460SetupPage.
	/// </summary>
	public class Axis2460SetupPage : System.Windows.Forms.UserControl, VsICoreProviderPage
	{
		private static int[] frameIntervals = new int[] {0, 100, 142, 200, 333, 1000,
															5000, 10000, 15000, 20000, 30000, 60000};
		private static StreamType[] streamTypes = new StreamType[] {StreamType.Jpeg, StreamType.MJpeg};
		private bool completed = false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox serverBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cameraCombo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox streamCombo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox rateCombo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// state changed event
		public event EventHandler StateChanged;

		// Constructor
		public Axis2460SetupPage()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			//
			cameraCombo.SelectedIndex = 0;
			streamCombo.SelectedIndex = 0;
			rateCombo.SelectedIndex = 0;
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
			this.serverBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.loginBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cameraCombo = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.streamCombo = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.rateCombo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Server:";
			// 
			// serverBox
			// 
			this.serverBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.serverBox.Location = new System.Drawing.Point(70, 10);
			this.serverBox.Name = "serverBox";
			this.serverBox.Size = new System.Drawing.Size(220, 20);
			this.serverBox.TabIndex = 1;
			this.serverBox.Text = "";
			this.serverBox.TextChanged += new System.EventHandler(this.serverBox_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Login:";
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
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 14);
			this.label3.TabIndex = 4;
			this.label3.Text = "&Password:";
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
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 14);
			this.label4.TabIndex = 6;
			this.label4.Text = "&Camera:";
			// 
			// cameraCombo
			// 
			this.cameraCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cameraCombo.Items.AddRange(new object[] {
															 "1",
															 "2",
															 "3",
															 "4"});
			this.cameraCombo.Location = new System.Drawing.Point(70, 100);
			this.cameraCombo.Name = "cameraCombo";
			this.cameraCombo.Size = new System.Drawing.Size(50, 21);
			this.cameraCombo.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(130, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 14);
			this.label5.TabIndex = 8;
			this.label5.Text = "Stream type:";
			// 
			// streamCombo
			// 
			this.streamCombo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.streamCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.streamCombo.Items.AddRange(new object[] {
															 "Jpeg",
															 "MJpeg"});
			this.streamCombo.Location = new System.Drawing.Point(200, 100);
			this.streamCombo.Name = "streamCombo";
			this.streamCombo.Size = new System.Drawing.Size(90, 21);
			this.streamCombo.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 14);
			this.label6.TabIndex = 10;
			this.label6.Text = "&Frame rate:";
			// 
			// rateCombo
			// 
			this.rateCombo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.rateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rateCombo.Items.AddRange(new object[] {
														   "Uncontrolled",
														   "10 frames per second",
														   "7 frames per second",
														   "5 frames per second",
														   "3 frames per second",
														   "1 frame per second",
														   "12 frames per minute",
														   "6 frames per minute",
														   "4 frames per minute",
														   "3 frames per minute",
														   "2 frames per minute",
														   "1 frame per minute"});
			this.rateCombo.Location = new System.Drawing.Point(70, 130);
			this.rateCombo.Name = "rateCombo";
			this.rateCombo.Size = new System.Drawing.Size(220, 21);
			this.rateCombo.TabIndex = 11;
			// 
			// Axis2460SetupPage
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.rateCombo,
																		  this.label6,
																		  this.streamCombo,
																		  this.label5,
																		  this.cameraCombo,
																		  this.label4,
																		  this.passwordBox,
																		  this.label3,
																		  this.loginBox,
																		  this.label2,
																		  this.serverBox,
																		  this.label1});
			this.Name = "Axis2460SetupPage";
			this.Size = new System.Drawing.Size(300, 185);
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
			AxisConfiguration	config = new AxisConfiguration();

			config.source	= serverBox.Text;
			config.login	= loginBox.Text;
			config.password	= passwordBox.Text;
			config.camera	= (short) (cameraCombo.SelectedIndex + 1);
			config.stremType = streamTypes[streamCombo.SelectedIndex];
			config.frameInterval = frameIntervals[rateCombo.SelectedIndex];

			return (object) config;
		}

		// Set configuration
		public void SetConfiguration(object config)
		{
			AxisConfiguration	cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				serverBox.Text = cfg.source;
				loginBox.Text = cfg.login;
				passwordBox.Text = cfg.password;
				cameraCombo.SelectedIndex = cfg.camera - 1;
				streamCombo.SelectedIndex = Array.IndexOf(streamTypes, cfg.stremType);
				rateCombo.SelectedIndex = Array.IndexOf(frameIntervals, cfg.frameInterval);
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
