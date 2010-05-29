// acxd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// blgb	
// muby	 By downloading, copying, installing or using the software you agree to this license.
// rqye	 If you do not agree to this license, do not download, install,
// xwpw	 copy or use the software.
// yznp	
// nagu	                          License Agreement
// agwa	         For OpenVSS - Open Source Video Surveillance System
// mcof	
// ckzd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pzin	
// ddat	Third party copyrights are property of their respective owners.
// ntki	
// mbha	Redistribution and use in source and binary forms, with or without modification,
// ohqb	are permitted provided that the following conditions are met:
// flbf	
// xblo	  * Redistribution's of source code must retain the above copyright notice,
// bsbm	    this list of conditions and the following disclaimer.
// xmgy	
// ramj	  * Redistribution's in binary form must reproduce the above copyright notice,
// zmgg	    this list of conditions and the following disclaimer in the documentation
// wonl	    and/or other materials provided with the distribution.
// unru	
// uyxd	  * Neither the name of the copyright holders nor the names of its contributors 
// ydpb	    may not be used to endorse or promote products derived from this software 
// rmsv	    without specific prior written permission.
// rylz	
// ujjn	This software is provided by the copyright holders and contributors "as is" and
// ugct	any express or implied warranties, including, but not limited to, the implied
// fuij	warranties of merchantability and fitness for a particular purpose are disclaimed.
// natn	In no event shall the Prince of Songkla University or contributors be liable 
// ahrz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pdan	(including, but not limited to, procurement of substitute goods or services;
// kksm	loss of use, data, or profits; or business interruption) however caused
// tlox	and on any theory of liability, whether in contract, strict liability,
// corl	or tort (including negligence or otherwise) arising in any way out of
// eeao	the use of this software, even if advised of the possibility of such damage.
// veyd	
// ufor	Intelligent Systems Laboratory (iSys Lab)
// seuk	Faculty of Engineering, Prince of Songkla University, THAILAND
// gmkr	Project leader by Nikom SUVONVORN
// ivcj	Project website at http://code.google.com/p/openvss/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vs.Monitor
{
	/// <summary>
	/// Summary description for VsDialogWizard.
	/// </summary>
	public class VsDialogWizard : System.Windows.Forms.Form
	{
		private Control currentControl = null;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button applyButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// SelectedPageIndex property
		public int SelectedPageIndex
		{
			get { return tabControl.SelectedIndex; }
		}

		// Apply event
		public event EventHandler Apply;

		// Constructor
		public VsDialogWizard()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(494, 280);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(412, 288);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(332, 288);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(244, 288);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "&Apply";
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // VsDialogWizard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(494, 318);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VsDialogWizard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PagedWizard_Load);
            this.ResumeLayout(false);

		}
		#endregion

		// Add page
		public void AddPage(VsIDialogWizard page)
		{
			Control ctrl = (Control) page;

			// add new tab
			TabPage tabPage = new TabPage();
			tabPage.TabIndex = tabControl.TabCount;
			tabPage.Text = page.PageName;
			tabControl.Controls.Add(tabPage);

			// add page to tab
			tabPage.Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			page.StateChanged += new EventHandler(page_StateChanged);
		}

		// On form load
		private void PagedWizard_Load(object sender, System.EventArgs e)
		{
			// set current page to the first
			SetCurrentPage(0);
		}

		// Update control buttons state
		private void UpdateControlButtons()
		{
			// "Apply" button
			applyButton.Enabled = ((currentControl != null) && (((VsIDialogWizard) currentControl).Completed));
			// "Ok" button
			okButton.Enabled = true;
			foreach (Control ctrl in tabControl.Controls)
			{
				if (!((VsIDialogWizard) ctrl.Controls[0]).Completed)
				{
					okButton.Enabled = false;
					break;
				}
			}
		}

		// Set current page
		private void SetCurrentPage(int n)
		{
			// get current page
			currentControl = tabControl.Controls[n].Controls[0];
			VsIDialogWizard	page = (VsIDialogWizard) currentControl;

			// notify the page
			page.Display();

			// update conrol buttons
			UpdateControlButtons();
		}

		// Selection changed in tab control
		private void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetCurrentPage(tabControl.SelectedIndex);
		}

		// On "Apply" button click
		private void applyButton_Click(object sender, System.EventArgs e)
		{
			if ((((VsIDialogWizard) currentControl).Apply() == true) && (Apply != null))
			{
				Apply(this, new EventArgs());
			}
		}

		// On "Ok" button click
		private void okButton_Click(object sender, System.EventArgs e)
		{
			// apply all pages
			foreach (Control ctrl in tabControl.Controls)
			{
				if (!((VsIDialogWizard) ctrl.Controls[0]).Apply())
				{
					return;
				}
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		// On page state changed
		private void page_StateChanged(object sender, System.EventArgs e)
		{
			// update conrol buttons
			UpdateControlButtons();
		}

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
