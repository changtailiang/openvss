// xrpw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kclq	
// iknb	 By downloading, copying, installing or using the software you agree to this license.
// ihot	 If you do not agree to this license, do not download, install,
// gpsp	 copy or use the software.
// jfrj	
// hiwq	                          License Agreement
// nndr	         For OpenVSS - Open Source Video Surveillance System
// hqjk	
// unjv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dpdr	
// fpzs	Third party copyrights are property of their respective owners.
// vfsj	
// jlcs	Redistribution and use in source and binary forms, with or without modification,
// zgpb	are permitted provided that the following conditions are met:
// gvdu	
// gvus	  * Redistribution's of source code must retain the above copyright notice,
// xeyt	    this list of conditions and the following disclaimer.
// fwlu	
// cads	  * Redistribution's in binary form must reproduce the above copyright notice,
// jduh	    this list of conditions and the following disclaimer in the documentation
// vuiv	    and/or other materials provided with the distribution.
// nrkn	
// yhpi	  * Neither the name of the copyright holders nor the names of its contributors 
// likj	    may not be used to endorse or promote products derived from this software 
// vgvr	    without specific prior written permission.
// gzdn	
// aiqy	This software is provided by the copyright holders and contributors "as is" and
// dwsc	any express or implied warranties, including, but not limited to, the implied
// avzm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nyef	In no event shall the Prince of Songkla University or contributors be liable 
// tkvy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hdiu	(including, but not limited to, procurement of substitute goods or services;
// qtxc	loss of use, data, or profits; or business interruption) however caused
// idav	and on any theory of liability, whether in contract, strict liability,
// rvvf	or tort (including negligence or otherwise) arising in any way out of
// blkb	the use of this software, even if advised of the possibility of such damage.
// omhp	
// ixww	Intelligent Systems Laboratory (iSys Lab)
// cpxv	Faculty of Engineering, Prince of Songkla University, THAILAND
// defx	Project leader by Nikom SUVONVORN
// zwij	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	/// <summary>
	/// Summary description for VsCameraDescription.
	/// </summary>
	public class VsCameraDescription : System.Windows.Forms.UserControl, VsIDialogWizard
	{
        private VsCamera vsCamera = null;
		private bool completed = false;

		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox cameraDescription;
		private System.Windows.Forms.TextBox cameraName;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelProvider;
		private System.Windows.Forms.ComboBox cameraProvider;
		private System.ComponentModel.Container components = null;
        private Label labelAnalyzer;
        private ComboBox cameraAnalyzer;
        private ComboBox cameraEncoder;
        private Label labelEncoder;

		// state changed event
		public event EventHandler StateChanged;
		// reset event
		public event EventHandler Reset;

        private VsCoreServer vsCoreMonitor;

        public VsCoreServer CoreMonitor
        {
            set 
            { 
                // cache to current monitor
                vsCoreMonitor = value;

                // create new camera
                vsCamera = new VsCamera();

                // build lists
                BuildProviderCombo();
                BuildAnalyzerCombo();
                BuildEncoderCombo();
            }
        }

        public VsCamera Camera
        {
            get { return vsCamera; }
        }

        // SelectedProviderName property
		public String SelectedProviderName
		{
			get { return cameraProvider.SelectedItem.ToString(); }
		}

        // SelectedAnalyserName property
        public String SelectedAnalyserName
        {
            get { return cameraAnalyzer.SelectedItem.ToString(); }
        }

        // SelectedAnalyserName property
        public String SelectedEncoderName
        {
            get { return cameraEncoder.SelectedItem.ToString(); }
        }

		// Constructor
		public VsCameraDescription()
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
            this.labelDescription = new System.Windows.Forms.Label();
            this.cameraDescription = new System.Windows.Forms.TextBox();
            this.cameraName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelProvider = new System.Windows.Forms.Label();
            this.cameraProvider = new System.Windows.Forms.ComboBox();
            this.labelAnalyzer = new System.Windows.Forms.Label();
            this.cameraAnalyzer = new System.Windows.Forms.ComboBox();
            this.cameraEncoder = new System.Windows.Forms.ComboBox();
            this.labelEncoder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(10, 40);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(66, 16);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "&Description:";
            // 
            // cameraDescription
            // 
            this.cameraDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraDescription.Location = new System.Drawing.Point(10, 59);
            this.cameraDescription.Multiline = true;
            this.cameraDescription.Name = "cameraDescription";
            this.cameraDescription.Size = new System.Drawing.Size(300, 72);
            this.cameraDescription.TabIndex = 3;
            // 
            // cameraName
            // 
            this.cameraName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraName.BackColor = System.Drawing.SystemColors.Window;
            this.cameraName.Location = new System.Drawing.Point(60, 10);
            this.cameraName.Name = "cameraName";
            this.cameraName.Size = new System.Drawing.Size(250, 20);
            this.cameraName.TabIndex = 1;
            this.cameraName.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(10, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "N&ame:";
            // 
            // labelProvider
            // 
            this.labelProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProvider.Location = new System.Drawing.Point(10, 141);
            this.labelProvider.Name = "labelProvider";
            this.labelProvider.Size = new System.Drawing.Size(75, 17);
            this.labelProvider.TabIndex = 4;
            this.labelProvider.Text = "&Provider : ";
            // 
            // cameraProvider
            // 
            this.cameraProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraProvider.Location = new System.Drawing.Point(90, 138);
            this.cameraProvider.MaxDropDownItems = 15;
            this.cameraProvider.Name = "cameraProvider";
            this.cameraProvider.Size = new System.Drawing.Size(220, 21);
            this.cameraProvider.TabIndex = 5;
            this.cameraProvider.SelectedIndexChanged += new System.EventHandler(this.videoSourceCombo_SelectedIndexChanged);
            // 
            // labelAnalyzer
            // 
            this.labelAnalyzer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAnalyzer.Location = new System.Drawing.Point(10, 168);
            this.labelAnalyzer.Name = "labelAnalyzer";
            this.labelAnalyzer.Size = new System.Drawing.Size(75, 17);
            this.labelAnalyzer.TabIndex = 4;
            this.labelAnalyzer.Text = "&Analyzer : ";
            // 
            // cameraAnalyzer
            // 
            this.cameraAnalyzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraAnalyzer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraAnalyzer.Location = new System.Drawing.Point(90, 165);
            this.cameraAnalyzer.MaxDropDownItems = 15;
            this.cameraAnalyzer.Name = "cameraAnalyzer";
            this.cameraAnalyzer.Size = new System.Drawing.Size(220, 21);
            this.cameraAnalyzer.TabIndex = 5;
            this.cameraAnalyzer.SelectedIndexChanged += new System.EventHandler(this.analyserCombo_SelectedIndexChanged);
            // 
            // cameraEncoder
            // 
            this.cameraEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraEncoder.Location = new System.Drawing.Point(90, 195);
            this.cameraEncoder.MaxDropDownItems = 15;
            this.cameraEncoder.Name = "cameraEncoder";
            this.cameraEncoder.Size = new System.Drawing.Size(220, 21);
            this.cameraEncoder.TabIndex = 7;
            this.cameraEncoder.SelectedIndexChanged += new System.EventHandler(this.encoderCombo_SelectedIndexChanged);
            // 
            // labelEncoder
            // 
            this.labelEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEncoder.Location = new System.Drawing.Point(10, 198);
            this.labelEncoder.Name = "labelEncoder";
            this.labelEncoder.Size = new System.Drawing.Size(75, 17);
            this.labelEncoder.TabIndex = 6;
            this.labelEncoder.Text = "&Encoder : ";
            // 
            // VsCameraDescription
            // 
            this.Controls.Add(this.cameraEncoder);
            this.Controls.Add(this.labelEncoder);
            this.Controls.Add(this.cameraAnalyzer);
            this.Controls.Add(this.labelAnalyzer);
            this.Controls.Add(this.cameraProvider);
            this.Controls.Add(this.labelProvider);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.cameraDescription);
            this.Controls.Add(this.cameraName);
            this.Controls.Add(this.labelName);
            this.Name = "VsCameraDescription";
            this.Size = new System.Drawing.Size(320, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	
		// PageName property
		public string PageName
		{
			get { return "Add Analyzer"; }
		}

		// PageDescription property
		public string PageDescription
		{
            get { return "Analyzer description"; }
		}

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

        // Build video source combo
        private void BuildProviderCombo()
        {
            // clean combo
            cameraProvider.Items.Clear();

            // add default item
            cameraProvider.Items.Add("--- Select Provider ---");
            cameraProvider.SelectedIndex = 0;

            // add provider source
            String[] providerList = vsCoreMonitor.ListProviders();
            foreach (String pv in providerList)
                cameraProvider.Items.Add(pv);
        }

        // Build analyzer combo
        private void BuildAnalyzerCombo()
        {
            // clean combo
            cameraAnalyzer.Items.Clear();

            // add default item
            cameraAnalyzer.Items.Add("--- Select Analyzer ---");
            cameraAnalyzer.SelectedIndex = 0;

            // add provider source
            String[] analyzerList = vsCoreMonitor.ListAnalyzers();
            foreach (String al in analyzerList)
                cameraAnalyzer.Items.Add(al);
        }

        // Build encoder combo
        private void BuildEncoderCombo()
        {
            // clean combo
            cameraEncoder.Items.Clear();

            // add default item
            cameraEncoder.Items.Add("--- Select Encoder ---");

            // add provider source
            String[] encoderList = vsCoreMonitor.ListEncoders();
            foreach (String el in encoderList)
                cameraEncoder.Items.Add(el);
            cameraEncoder.SelectedIndex = 0;
        }

		// Show the page
		public void Display()
		{
			cameraName.Focus();
			cameraName.SelectionStart = cameraName.TextLength;
		}

		// Apply the page
		public bool Apply()
		{
			String name = cameraName.Text.Replace('\\', ' ');

            // check vsCamera
            if (vsCoreMonitor.GetCameraByName(name) != null)
            {
                Color tmp = this.cameraName.BackColor;
                // highligh name edit box
                this.cameraName.BackColor = Color.LightCoral;
                // error message
                MessageBox.Show(this, "A vsCamera with such name is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // restore & focus name edit box
                this.cameraName.BackColor = tmp;
                this.cameraName.Focus();

                return false;
            }

			// update vsCamera name and description
            vsCamera.CameraName = name;
            vsCamera.CameraDescription = cameraDescription.Text;
			vsCamera.Provider = vsCoreMonitor.GetProviderByName(SelectedProviderName);
            vsCamera.Analyser = vsCoreMonitor.GetAnalyzerByName(SelectedAnalyserName);
            vsCamera.Encoder = vsCoreMonitor.GetEncoderByName(SelectedEncoderName);

			return true;
		}

		// On Name edit box changed
		private void nameBox_TextChanged(object sender, System.EventArgs e)
		{
			UpdateState();
		}

		// On Video Source combo selection changed
		private void videoSourceCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateState();

			//if( Reset != null) Reset(this, new EventArgs());
		}

        // On Analyser combo selection changed
        private void analyserCombo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateState();

            //if (Reset != null) Reset(this, new EventArgs());
        }

        // On Encoder combo selection changed
        private void encoderCombo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateState();

            //if (Reset != null)  Reset(this, new EventArgs());
        }

		// Update state
		private void UpdateState()
		{
            completed = ((cameraName.TextLength != 0) && (cameraProvider.SelectedIndex != 0));
			
			if (StateChanged != null) StateChanged(this, new EventArgs());
		}
	}
}
