// oeof	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yhsu	
// qvum	 By downloading, copying, installing or using the software you agree to this license.
// bogg	 If you do not agree to this license, do not download, install,
// dgai	 copy or use the software.
// bwjp	
// gmxl	                          License Agreement
// qjac	         For OpenVSS - Open Source Video Surveillance System
// gmrg	
// iqwt	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kqxc	
// uaaq	Third party copyrights are property of their respective owners.
// xbgl	
// bdks	Redistribution and use in source and binary forms, with or without modification,
// uzzm	are permitted provided that the following conditions are met:
// jgeh	
// vsfo	  * Redistribution's of source code must retain the above copyright notice,
// xaxn	    this list of conditions and the following disclaimer.
// jhyk	
// yhvf	  * Redistribution's in binary form must reproduce the above copyright notice,
// mgno	    this list of conditions and the following disclaimer in the documentation
// dpad	    and/or other materials provided with the distribution.
// czlj	
// qkjd	  * Neither the name of the copyright holders nor the names of its contributors 
// mqhb	    may not be used to endorse or promote products derived from this software 
// vltx	    without specific prior written permission.
// esbt	
// fztn	This software is provided by the copyright holders and contributors "as is" and
// dtzd	any express or implied warranties, including, but not limited to, the implied
// tpdf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rcmx	In no event shall the Prince of Songkla University or contributors be liable 
// powy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xuyi	(including, but not limited to, procurement of substitute goods or services;
// ztkb	loss of use, data, or profits; or business interruption) however caused
// mqkk	and on any theory of liability, whether in contract, strict liability,
// ngxc	or tort (including negligence or otherwise) arising in any way out of
// fxfx	the use of this software, even if advised of the possibility of such damage.
// kgkw	
// mbks	Intelligent Systems Laboratory (iSys Lab)
// ywhp	Faculty of Engineering, Prince of Songkla University, THAILAND
// vcwk	Project leader by Nikom SUVONVORN
// bkok	Project website at http://code.google.com/p/openvss/

namespace Vs.Monitor
{
    partial class VsGeneralSetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClock = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxHostnameDatabase = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxStorageHostName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxStorageDirectory = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxClock);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clock";
            // 
            // textBoxClock
            // 
            this.textBoxClock.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxClock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxClock.Location = new System.Drawing.Point(91, 19);
            this.textBoxClock.Name = "textBoxClock";
            this.textBoxClock.Size = new System.Drawing.Size(135, 20);
            this.textBoxClock.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.textBoxPassword);
            this.groupBox2.Controls.Add(this.textBoxDatabase);
            this.groupBox2.Controls.Add(this.textBoxHostnameDatabase);
            this.groupBox2.Controls.Add(this.textBoxUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(16, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPassword.Location = new System.Drawing.Point(270, 45);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 2;
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxDatabase.Location = new System.Drawing.Point(91, 71);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(279, 20);
            this.textBoxDatabase.TabIndex = 1;
            // 
            // textBoxHostnameDatabase
            // 
            this.textBoxHostnameDatabase.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxHostnameDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxHostnameDatabase.Location = new System.Drawing.Point(91, 19);
            this.textBoxHostnameDatabase.Name = "textBoxHostnameDatabase";
            this.textBoxHostnameDatabase.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostnameDatabase.TabIndex = 1;
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxUser.Location = new System.Drawing.Point(91, 45);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(211, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(24, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(24, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hostname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.textBoxStorageHostName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxStorageDirectory);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(16, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 81);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Storage";
            // 
            // textBoxStorageHostName
            // 
            this.textBoxStorageHostName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxStorageHostName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxStorageHostName.Location = new System.Drawing.Point(91, 19);
            this.textBoxStorageHostName.Name = "textBoxStorageHostName";
            this.textBoxStorageHostName.Size = new System.Drawing.Size(100, 20);
            this.textBoxStorageHostName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(24, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Directory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(24, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hostname";
            // 
            // textBoxStorageDirectory
            // 
            this.textBoxStorageDirectory.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxStorageDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxStorageDirectory.Location = new System.Drawing.Point(91, 45);
            this.textBoxStorageDirectory.Name = "textBoxStorageDirectory";
            this.textBoxStorageDirectory.Size = new System.Drawing.Size(279, 20);
            this.textBoxStorageDirectory.TabIndex = 1;
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.SystemColors.Control;
            this.buttonApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonApply.Location = new System.Drawing.Point(357, 8);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // VsGeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "VsGeneralSetting";
            this.Size = new System.Drawing.Size(446, 430);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxClock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxHostnameDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxStorageHostName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxStorageDirectory;
        private System.Windows.Forms.Button buttonApply;
    }
}
