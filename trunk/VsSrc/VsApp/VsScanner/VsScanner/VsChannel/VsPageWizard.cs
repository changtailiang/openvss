// cnsz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yqvx	
// ykoi	 By downloading, copying, installing or using the software you agree to this license.
// clhk	 If you do not agree to this license, do not download, install,
// anle	 copy or use the software.
// aril	
// dtvv	                          License Agreement
// tlcv	         For OpenVSS - Open Source Video Surveillance System
// schl	
// erhr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ltfz	
// dwse	Third party copyrights are property of their respective owners.
// ghqs	
// imck	Redistribution and use in source and binary forms, with or without modification,
// egve	are permitted provided that the following conditions are met:
// vaen	
// itqz	  * Redistribution's of source code must retain the above copyright notice,
// ewgj	    this list of conditions and the following disclaimer.
// guth	
// miih	  * Redistribution's in binary form must reproduce the above copyright notice,
// bqol	    this list of conditions and the following disclaimer in the documentation
// ujmg	    and/or other materials provided with the distribution.
// zwgy	
// vcvk	  * Neither the name of the copyright holders nor the names of its contributors 
// psrj	    may not be used to endorse or promote products derived from this software 
// gtak	    without specific prior written permission.
// bhmo	
// tvyw	This software is provided by the copyright holders and contributors "as is" and
// yodf	any express or implied warranties, including, but not limited to, the implied
// lssy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gkzh	In no event shall the Prince of Songkla University or contributors be liable 
// piod	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yist	(including, but not limited to, procurement of substitute goods or services;
// ryah	loss of use, data, or profits; or business interruption) however caused
// pdkm	and on any theory of liability, whether in contract, strict liability,
// xyme	or tort (including negligence or otherwise) arising in any way out of
// ykzg	the use of this software, even if advised of the possibility of such damage.
// zqzw	
// zsdw	Intelligent Systems Laboratory (iSys Lab)
// ttvt	Faculty of Engineering, Prince of Songkla University, THAILAND
// tjpk	Project leader by Nikom SUVONVORN
// deez	Project website at http://code.google.com/p/openvss/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vs.Monitor
{
	/// <summary>
	/// Summary description for VsPageWizard.
	/// </summary>
	public class VsPageWizard : System.Windows.Forms.Form
	{
		private string title;
		private int currentPage;
		private Control currentControl = null;

		private System.Windows.Forms.Panel descPannel;
		private System.Windows.Forms.Panel controlPanel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button finishButton;
		protected System.Windows.Forms.Button nextButton;
		protected System.Windows.Forms.Button backButton;
		private System.Windows.Forms.PictureBox line1;
		private System.Windows.Forms.PictureBox line2;
		private System.Windows.Forms.Label descriptionLabel;
		protected System.Windows.Forms.Panel imagePanel;
		private System.Windows.Forms.PictureBox line3;
		private System.Windows.Forms.Panel workPanel;
        protected Button buttonApply;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		// Constructor
		public VsPageWizard()
		{
			//
			// Required for Windows Form Designer support
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.descPannel = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.nextButton = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.line1 = new System.Windows.Forms.PictureBox();
            this.line2 = new System.Windows.Forms.PictureBox();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.line3 = new System.Windows.Forms.PictureBox();
            this.workPanel = new System.Windows.Forms.Panel();
            this.descPannel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line3)).BeginInit();
            this.SuspendLayout();
            // 
            // descPannel
            // 
            this.descPannel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.descPannel.Controls.Add(this.descriptionLabel);
            this.descPannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.descPannel.Location = new System.Drawing.Point(0, 0);
            this.descPannel.Name = "descPannel";
            this.descPannel.Size = new System.Drawing.Size(494, 33);
            this.descPannel.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.descriptionLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.descriptionLabel.Location = new System.Drawing.Point(8, 7);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(460, 26);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Hello";
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlPanel.Controls.Add(this.nextButton);
            this.controlPanel.Controls.Add(this.buttonApply);
            this.controlPanel.Controls.Add(this.finishButton);
            this.controlPanel.Controls.Add(this.cancelButton);
            this.controlPanel.Controls.Add(this.backButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.controlPanel.Location = new System.Drawing.Point(0, 313);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(494, 31);
            this.controlPanel.TabIndex = 1;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.BackColor = System.Drawing.SystemColors.Control;
            this.nextButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nextButton.Location = new System.Drawing.Point(125, 5);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "&Next";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.BackColor = System.Drawing.SystemColors.Control;
            this.buttonApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonApply.Location = new System.Drawing.Point(255, 5);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Visible = false;
            this.buttonApply.Click += new System.EventHandler(this.finishApply_Click);
            // 
            // finishButton
            // 
            this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finishButton.BackColor = System.Drawing.SystemColors.Control;
            this.finishButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.finishButton.Location = new System.Drawing.Point(336, 5);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 3;
            this.finishButton.Text = "&Finish";
            this.finishButton.UseVisualStyleBackColor = false;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.Location = new System.Drawing.Point(416, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.BackColor = System.Drawing.SystemColors.Control;
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backButton.Location = new System.Drawing.Point(44, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "&Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.SystemColors.Control;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 33);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(494, 1);
            this.line1.TabIndex = 2;
            this.line1.TabStop = false;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.SystemColors.Control;
            this.line2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line2.Location = new System.Drawing.Point(0, 312);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(494, 1);
            this.line2.TabIndex = 3;
            this.line2.TabStop = false;
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.SystemColors.Control;
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.imagePanel.Location = new System.Drawing.Point(0, 34);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(231, 278);
            this.imagePanel.TabIndex = 4;
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.SystemColors.Control;
            this.line3.Dock = System.Windows.Forms.DockStyle.Left;
            this.line3.Location = new System.Drawing.Point(231, 34);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(1, 278);
            this.line3.TabIndex = 5;
            this.line3.TabStop = false;
            // 
            // workPanel
            // 
            this.workPanel.BackColor = System.Drawing.SystemColors.Control;
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(232, 34);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(262, 278);
            this.workPanel.TabIndex = 0;
            // 
            // VsPageWizard
            // 
            this.AcceptButton = this.nextButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(494, 344);
            this.ControlBox = false;
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.line3);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.descPannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VsPageWizard";
            this.Opacity = 0.95;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.descPannel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.line1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line3)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// Add page
		public void AddPage(VsIDialogWizard page)
		{
			Control ctrl = (Control) page;

			workPanel.Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			page.StateChanged += new EventHandler(page_StateChanged);
			page.Reset += new EventHandler(page_Reset);
		}

        // Remove page
        public void RemovePage(VsIDialogWizard page)
        {
            Control ctrl = (Control)page;

            workPanel.Controls.Remove(ctrl);
        }
		
		// On form load
		private void Wizard_Load(object sender, System.EventArgs e)
		{
			// save original title
			title = this.Text;

			// set current page to the first
			SetCurrentPage(0);
		}

		// Update control buttons state
		private void UpdateControlButtons()
		{
			// "Back" button
			backButton.Enabled = (currentPage != 0);
			// "Next" button
			nextButton.Enabled = ((currentPage < workPanel.Controls.Count - 1) && (currentControl != null) && (((VsIDialogWizard) currentControl).Completed));
			// "Finish" button
			finishButton.Enabled = true;
			foreach (VsIDialogWizard page in workPanel.Controls)
			{
				if (!page.Completed)
				{
					finishButton.Enabled = false;
					break;
				}
			}
		}

		// Set current page
		private void SetCurrentPage(int n)
		{
			OnPageChanging(n);

			// hide previous page
			if (currentControl != null)
			{
				currentControl.Hide();
			}

			//
			currentPage = n;

			// update dialog text
			this.Text = title + " - Page " + ((int)(n + 1)).ToString() + " of " + workPanel.Controls.Count.ToString();

			// show new page
			currentControl = workPanel.Controls[currentPage];
			VsIDialogWizard	page = (VsIDialogWizard) currentControl;

			currentControl.Show();

			// description
			descriptionLabel.Text = page.PageDescription;

			// notify the page
			page.Display();

			// update conrol buttons
			UpdateControlButtons();
		}

		// On "Next" button click
		private void nextButton_Click(object sender, System.EventArgs e)
		{
			if (((VsIDialogWizard) currentControl).Apply() == true)
			{
				if (currentPage < workPanel.Controls.Count - 1)
				{
					SetCurrentPage(currentPage + 1);
				}
			}
		}

		// On "Back" button click
		private void backButton_Click(object sender, System.EventArgs e)
		{
			if (currentPage > 0)
			{
				SetCurrentPage(currentPage - 1);
			}
		}

		// On "Finish" button click
		private void finishButton_Click(object sender, System.EventArgs e)
		{
			if (((VsIDialogWizard) currentControl).Apply() == true)
			{
				OnFinish();

				// close the dialog
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

        // On "Apply" button click
        private void finishApply_Click(object sender, System.EventArgs e)
        {
            if (((VsIDialogWizard)currentControl).Apply() == true)
            {
            }
        }

		// On page state changed
		private void page_StateChanged(object sender, System.EventArgs e)
		{
			// update conrol buttons
			UpdateControlButtons();
		}

		// Reset on page
		private void page_Reset(object sender, System.EventArgs e)
		{
			OnResetOnPage(workPanel.Controls.GetChildIndex((Control) sender));

			// update conrol buttons
			UpdateControlButtons();
		}

		// Before page changing
		protected virtual void OnPageChanging(int page)
		{
		}

		// Reset event ocuren on page
		protected virtual void OnResetOnPage(int page)
		{
		}

		// On dialog finish
		protected virtual void OnFinish()
		{
		}

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
