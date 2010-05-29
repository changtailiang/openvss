// xeil	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bazo	
// fdxn	 By downloading, copying, installing or using the software you agree to this license.
// gufe	 If you do not agree to this license, do not download, install,
// ccss	 copy or use the software.
// zkvp	
// mgkz	                          License Agreement
// bslh	         For OpenVSS - Open Source Video Surveillance System
// ospd	
// tnqv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// satj	
// olre	Third party copyrights are property of their respective owners.
// rsxp	
// gkpm	Redistribution and use in source and binary forms, with or without modification,
// itzu	are permitted provided that the following conditions are met:
// qann	
// spyn	  * Redistribution's of source code must retain the above copyright notice,
// fblp	    this list of conditions and the following disclaimer.
// lwzy	
// rmba	  * Redistribution's in binary form must reproduce the above copyright notice,
// ofii	    this list of conditions and the following disclaimer in the documentation
// uvae	    and/or other materials provided with the distribution.
// cdvz	
// nvfs	  * Neither the name of the copyright holders nor the names of its contributors 
// mgry	    may not be used to endorse or promote products derived from this software 
// ndzp	    without specific prior written permission.
// hidk	
// lrvw	This software is provided by the copyright holders and contributors "as is" and
// rzfk	any express or implied warranties, including, but not limited to, the implied
// rfsw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pulb	In no event shall the Prince of Songkla University or contributors be liable 
// flbq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rgmk	(including, but not limited to, procurement of substitute goods or services;
// ucnk	loss of use, data, or profits; or business interruption) however caused
// gsbm	and on any theory of liability, whether in contract, strict liability,
// rqsl	or tort (including negligence or otherwise) arising in any way out of
// izio	the use of this software, even if advised of the possibility of such damage.
// pvbg	
// ovjs	Intelligent Systems Laboratory (iSys Lab)
// sxkv	Faculty of Engineering, Prince of Songkla University, THAILAND
// gnte	Project leader by Nikom SUVONVORN
// ekbo	Project website at http://code.google.com/p/openvss/

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
	/// Summary description for VsChannelDescription.
	/// </summary>
	public class VsPageDescription : System.Windows.Forms.UserControl, VsIDialogWizard
	{
        private VsChannel vsChannel;
		private bool completed = false;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox channelName;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox channelDescription;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox cellWidthBox;
        private System.Windows.Forms.Label labelColumn;
        private System.Windows.Forms.Label labelRow;
        private System.Windows.Forms.Label labelCellWidth;
		private System.Windows.Forms.Label labelCellHeight;
		private System.Windows.Forms.TextBox cellHeightBox;
		private System.Windows.Forms.ComboBox rowsCombo;
		private System.Windows.Forms.ComboBox colsCombo;
        private ComboBox cameraAnalyzer;
        private Label labelAnalyzer;
        private ComboBox cameraEncoder;
        private Label labelEncoder;

		// state changed event
		public event EventHandler StateChanged;
		// reset event
		public event EventHandler Reset;

        private VsCoreServer vsCoreMonitor;

		// VsChannel property
        public VsChannel Channel
        {
            get { return vsChannel; }
        }

        public VsCoreServer CoreMonitor
        {
            set 
            { 
                if (value != null)
				{
                    vsCoreMonitor = value;

                    // create new channel
                    vsChannel = new VsChannel();

                    BuildAnalyzerCombo();
                    BuildEncoderCombo();
                }
			}
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
		public VsPageDescription()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
            this.colsCombo.SelectedIndex = 0;
            this.rowsCombo.SelectedIndex = 0;
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
            this.labelName = new System.Windows.Forms.Label();
            this.channelName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.channelDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cellHeightBox = new System.Windows.Forms.TextBox();
            this.labelCellHeight = new System.Windows.Forms.Label();
            this.cellWidthBox = new System.Windows.Forms.TextBox();
            this.labelCellWidth = new System.Windows.Forms.Label();
            this.rowsCombo = new System.Windows.Forms.ComboBox();
            this.labelRow = new System.Windows.Forms.Label();
            this.colsCombo = new System.Windows.Forms.ComboBox();
            this.labelColumn = new System.Windows.Forms.Label();
            this.cameraAnalyzer = new System.Windows.Forms.ComboBox();
            this.labelAnalyzer = new System.Windows.Forms.Label();
            this.cameraEncoder = new System.Windows.Forms.ComboBox();
            this.labelEncoder = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(7, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(40, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "&Name:";
            // 
            // channelName
            // 
            this.channelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.channelName.Location = new System.Drawing.Point(60, 10);
            this.channelName.Name = "channelName";
            this.channelName.Size = new System.Drawing.Size(257, 20);
            this.channelName.TabIndex = 1;
            this.channelName.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(7, 42);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(70, 15);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "&Description:";
            // 
            // channelDescription
            // 
            this.channelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.channelDescription.Location = new System.Drawing.Point(10, 60);
            this.channelDescription.Multiline = true;
            this.channelDescription.Name = "channelDescription";
            this.channelDescription.Size = new System.Drawing.Size(307, 80);
            this.channelDescription.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cellHeightBox);
            this.groupBox1.Controls.Add(this.labelCellHeight);
            this.groupBox1.Controls.Add(this.cellWidthBox);
            this.groupBox1.Controls.Add(this.labelCellWidth);
            this.groupBox1.Controls.Add(this.rowsCombo);
            this.groupBox1.Controls.Add(this.labelRow);
            this.groupBox1.Controls.Add(this.colsCombo);
            this.groupBox1.Controls.Add(this.labelColumn);
            this.groupBox1.Location = new System.Drawing.Point(10, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel configuration";
            // 
            // cellHeightBox
            // 
            this.cellHeightBox.Location = new System.Drawing.Point(220, 50);
            this.cellHeightBox.Name = "cellHeightBox";
            this.cellHeightBox.Size = new System.Drawing.Size(50, 20);
            this.cellHeightBox.TabIndex = 7;
            this.cellHeightBox.Text = "240";
            // 
            // labelCellHeight
            // 
            this.labelCellHeight.Location = new System.Drawing.Point(150, 53);
            this.labelCellHeight.Name = "labelCellHeight";
            this.labelCellHeight.Size = new System.Drawing.Size(70, 15);
            this.labelCellHeight.TabIndex = 6;
            this.labelCellHeight.Text = "Cell height:";
            // 
            // cellWidthBox
            // 
            this.cellWidthBox.Location = new System.Drawing.Point(80, 50);
            this.cellWidthBox.Name = "cellWidthBox";
            this.cellWidthBox.Size = new System.Drawing.Size(50, 20);
            this.cellWidthBox.TabIndex = 5;
            this.cellWidthBox.Text = "320";
            // 
            // labelCellWidth
            // 
            this.labelCellWidth.Location = new System.Drawing.Point(10, 53);
            this.labelCellWidth.Name = "labelCellWidth";
            this.labelCellWidth.Size = new System.Drawing.Size(70, 15);
            this.labelCellWidth.TabIndex = 4;
            this.labelCellWidth.Text = "Cell width:";
            // 
            // rowsCombo
            // 
            this.rowsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rowsCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.rowsCombo.Location = new System.Drawing.Point(220, 20);
            this.rowsCombo.Name = "rowsCombo";
            this.rowsCombo.Size = new System.Drawing.Size(50, 21);
            this.rowsCombo.TabIndex = 3;
            this.rowsCombo.SelectedIndexChanged += new System.EventHandler(this.rowsCombo_SelectedIndexChanged);
            // 
            // labelRow
            // 
            this.labelRow.Location = new System.Drawing.Point(150, 23);
            this.labelRow.Name = "labelRow";
            this.labelRow.Size = new System.Drawing.Size(70, 15);
            this.labelRow.TabIndex = 2;
            this.labelRow.Text = "Rows:";
            // 
            // colsCombo
            // 
            this.colsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colsCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.colsCombo.Location = new System.Drawing.Point(80, 20);
            this.colsCombo.Name = "colsCombo";
            this.colsCombo.Size = new System.Drawing.Size(50, 21);
            this.colsCombo.TabIndex = 1;
            this.colsCombo.SelectedIndexChanged += new System.EventHandler(this.colsCombo_SelectedIndexChanged);
            // 
            // labelColumn
            // 
            this.labelColumn.Location = new System.Drawing.Point(10, 23);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(65, 15);
            this.labelColumn.TabIndex = 0;
            this.labelColumn.Text = "Columns:";
            // 
            // cameraAnalyzer
            // 
            this.cameraAnalyzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraAnalyzer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraAnalyzer.Location = new System.Drawing.Point(92, 245);
            this.cameraAnalyzer.MaxDropDownItems = 15;
            this.cameraAnalyzer.Name = "cameraAnalyzer";
            this.cameraAnalyzer.Size = new System.Drawing.Size(225, 21);
            this.cameraAnalyzer.TabIndex = 7;
            // 
            // labelAnalyzer
            // 
            this.labelAnalyzer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAnalyzer.Location = new System.Drawing.Point(10, 248);
            this.labelAnalyzer.Name = "labelAnalyzer";
            this.labelAnalyzer.Size = new System.Drawing.Size(63, 20);
            this.labelAnalyzer.TabIndex = 6;
            this.labelAnalyzer.Text = "&Analyzer : ";
            // 
            // cameraEncoder
            // 
            this.cameraEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraEncoder.Location = new System.Drawing.Point(91, 226);
            this.cameraEncoder.MaxDropDownItems = 15;
            this.cameraEncoder.Name = "cameraEncoder";
            this.cameraEncoder.Size = new System.Drawing.Size(220, 21);
            this.cameraEncoder.TabIndex = 9;
            this.cameraEncoder.Visible = false;
            // 
            // labelEncoder
            // 
            this.labelEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEncoder.Location = new System.Drawing.Point(8, 229);
            this.labelEncoder.Name = "labelEncoder";
            this.labelEncoder.Size = new System.Drawing.Size(75, 17);
            this.labelEncoder.TabIndex = 8;
            this.labelEncoder.Text = "&Encoder : ";
            this.labelEncoder.Visible = false;
            // 
            // VsPageDescription
            // 
            this.Controls.Add(this.cameraEncoder);
            this.Controls.Add(this.labelEncoder);
            this.Controls.Add(this.cameraAnalyzer);
            this.Controls.Add(this.labelAnalyzer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.channelDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.channelName);
            this.Controls.Add(this.labelName);
            this.Name = "VsPageDescription";
            this.Size = new System.Drawing.Size(327, 280);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		// PageName property
		public string PageName
		{
			get { return "Add Layout"; }
		}

		// PageDescription property
		public string PageDescription
		{
            get { return "Layout description"; }
		}

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

		// Show the page
		public void Display()
		{
			channelName.Focus();
			channelName.SelectionStart = channelName.TextLength;
		}

		// Apply the page
		public bool Apply()
		{
			string name = channelName.Text.Replace('\\', ' ');

            // check vsChannel
            if (vsCoreMonitor.GetChannelByName(name) != null)
            {
				Color	tmp = this.channelName.BackColor;

				// highlight name edit box
				this.channelName.BackColor = Color.LightCoral;
				// error message
				MessageBox.Show(this, "A channel with such name is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				// restore & focus name edit box
				this.channelName.BackColor = tmp;
				this.channelName.Focus();

				return false;
			}

			// update vsChannel name and description
			vsChannel.ChannelName = name;
			vsChannel.Description = channelDescription.Text;

            try
            {
                vsChannel.Cols = short.Parse(colsCombo.SelectedItem.ToString());
                vsChannel.Rows = short.Parse(rowsCombo.SelectedItem.ToString());
                vsChannel.CellWidth = short.Parse(cellWidthBox.Text);
                vsChannel.CellHeight = short.Parse(cellHeightBox.Text);

                // update vsCamera name and description
                vsChannel.Analyser = vsCoreMonitor.GetAnalyzerByName(SelectedAnalyserName);
                vsChannel.Encoder = vsCoreMonitor.GetEncoderByName(SelectedEncoderName);

            }
            catch (Exception) { }

			return true;
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
            cameraEncoder.SelectedIndex = 1;
        }

		// On Name edit box changed
		private void nameBox_TextChanged(object sender, System.EventArgs e)
		{
            UpdateState();
		}

		// Cols changed
		private void colsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// update vsChannel size
            if(vsChannel!=null)
			    vsChannel.Cols = (short)(colsCombo.SelectedIndex + 1);

            UpdateState();
		}

		// Rows changed
		private void rowsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// update vsChannel size
            if (vsChannel != null)
                vsChannel.Rows = (short)(rowsCombo.SelectedIndex + 1);

            UpdateState();
		}

        // Update state
        private void UpdateState()
        {
            completed = ((channelName.TextLength != 0) &&
                (rowsCombo.SelectedIndex >= 0 && rowsCombo.SelectedIndex <= 4) && 
                (colsCombo.SelectedIndex >= 0 && colsCombo.SelectedIndex <= 4) && 
                cellHeightBox.Text.Length>0 && cellWidthBox.Text.Length >0);

            if (StateChanged != null) StateChanged(this, new EventArgs());
        }
	}
}
