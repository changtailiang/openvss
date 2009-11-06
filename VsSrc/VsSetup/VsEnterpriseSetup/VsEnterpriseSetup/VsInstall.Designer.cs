// eyto	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vwfq	
// wqes	 By downloading, copying, installing or using the software you agree to this license.
// mhgw	 If you do not agree to this license, do not download, install,
// ftrk	 copy or use the software.
// pjhi	
// aseb	                          License Agreement
// lyuk	         For OpenVss - Open Source Video Surveillance System
// wtqk	
// tmss	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// uypb	
// ofaj	Third party copyrights are property of their respective owners.
// yavj	
// dofu	Redistribution and use in source and binary forms, with or without modification,
// rkod	are permitted provided that the following conditions are met:
// rdfy	
// vuvt	  * Redistribution's of source code must retain the above copyright notice,
// qwct	    this list of conditions and the following disclaimer.
// ayqr	
// uftu	  * Redistribution's in binary form must reproduce the above copyright notice,
// svdk	    this list of conditions and the following disclaimer in the documentation
// clgi	    and/or other materials provided with the distribution.
// nwti	
// ypaq	  * Neither the name of the copyright holders nor the names of its contributors 
// sqgu	    may not be used to endorse or promote products derived from this software 
// kgtc	    without specific prior written permission.
// xcif	
// yozl	This software is provided by the copyright holders and contributors "as is" and
// rtkw	any express or implied warranties, including, but not limited to, the implied
// auvj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// onft	In no event shall the Prince of Songkla University or contributors be liable 
// ctvl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xzye	(including, but not limited to, procurement of substitute goods or services;
// zzkl	loss of use, data, or profits; or business interruption) however caused
// bama	and on any theory of liability, whether in contract, strict liability,
// dakz	or tort (including negligence or otherwise) arising in any way out of
// wire	the use of this software, even if advised of the possibility of such damage.

namespace VsSetup
{
    partial class VsInstall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsInstall));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setupState1 = new VsSetup.SetupState();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setupState1);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 500);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // setupState1
            // 
            this.setupState1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.setupState1.Location = new System.Drawing.Point(6, 13);
            this.setupState1.Name = "setupState1";
            this.setupState1.Size = new System.Drawing.Size(238, 481);
            this.setupState1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(294, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 500);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 481);
            this.panel1.TabIndex = 0;
            // 
            // VsInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(707, 544);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VsInstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenVss Installer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SetupState setupState1;
        private System.Windows.Forms.Panel panel1;
    }
}

