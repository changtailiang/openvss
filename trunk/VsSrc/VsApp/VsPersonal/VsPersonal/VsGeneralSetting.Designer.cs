// tygn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fmip	
// ddot	 By downloading, copying, installing or using the software you agree to this license.
// tlut	 If you do not agree to this license, do not download, install,
// kllo	 copy or use the software.
// wrut	
// apqt	                          License Agreement
// blqc	         For OpenVSS - Open Source Video Surveillance System
// ivvx	
// kohu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xmnr	
// lqtb	Third party copyrights are property of their respective owners.
// qzmf	
// ttfc	Redistribution and use in source and binary forms, with or without modification,
// ennq	are permitted provided that the following conditions are met:
// voos	
// mlky	  * Redistribution's of source code must retain the above copyright notice,
// pxiw	    this list of conditions and the following disclaimer.
// eqrk	
// ddij	  * Redistribution's in binary form must reproduce the above copyright notice,
// vpdc	    this list of conditions and the following disclaimer in the documentation
// yljp	    and/or other materials provided with the distribution.
// qstw	
// bryi	  * Neither the name of the copyright holders nor the names of its contributors 
// yvfz	    may not be used to endorse or promote products derived from this software 
// gvlt	    without specific prior written permission.
// qqbc	
// cvza	This software is provided by the copyright holders and contributors "as is" and
// fdug	any express or implied warranties, including, but not limited to, the implied
// llta	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cvhx	In no event shall the Prince of Songkla University or contributors be liable 
// dlvn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rilh	(including, but not limited to, procurement of substitute goods or services;
// yida	loss of use, data, or profits; or business interruption) however caused
// ejli	and on any theory of liability, whether in contract, strict liability,
// jgnu	or tort (including negligence or otherwise) arising in any way out of
// tsrx	the use of this software, even if advised of the possibility of such damage.
// wsxm	
// cewk	Intelligent Systems Laboratory (iSys Lab)
// nnpe	Faculty of Engineering, Prince of Songkla University, THAILAND
// volt	Project leader by Nikom SUVONVORN
// krcw	Project website at http://code.google.com/p/openvss/

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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SmtpPasswd = new System.Windows.Forms.MaskedTextBox();
            this.EmailTo = new System.Windows.Forms.TextBox();
            this.EmailFrom = new System.Windows.Forms.TextBox();
            this.SmtpHost = new System.Windows.Forms.TextBox();
            this.SmtpUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.SmtpPasswd);
            this.groupBox2.Controls.Add(this.EmailTo);
            this.groupBox2.Controls.Add(this.EmailFrom);
            this.groupBox2.Controls.Add(this.SmtpHost);
            this.groupBox2.Controls.Add(this.SmtpUser);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(22, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mail Setting";
            // 
            // SmtpPasswd
            // 
            this.SmtpPasswd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SmtpPasswd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SmtpPasswd.Location = new System.Drawing.Point(87, 78);
            this.SmtpPasswd.Name = "SmtpPasswd";
            this.SmtpPasswd.PasswordChar = '*';
            this.SmtpPasswd.Size = new System.Drawing.Size(183, 20);
            this.SmtpPasswd.TabIndex = 2;
            // 
            // EmailTo
            // 
            this.EmailTo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EmailTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EmailTo.Location = new System.Drawing.Point(87, 143);
            this.EmailTo.Name = "EmailTo";
            this.EmailTo.Size = new System.Drawing.Size(183, 20);
            this.EmailTo.TabIndex = 1;
            // 
            // EmailFrom
            // 
            this.EmailFrom.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EmailFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EmailFrom.Location = new System.Drawing.Point(87, 117);
            this.EmailFrom.Name = "EmailFrom";
            this.EmailFrom.Size = new System.Drawing.Size(183, 20);
            this.EmailFrom.TabIndex = 1;
            // 
            // SmtpHost
            // 
            this.SmtpHost.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SmtpHost.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SmtpHost.Location = new System.Drawing.Point(87, 26);
            this.SmtpHost.Name = "SmtpHost";
            this.SmtpHost.Size = new System.Drawing.Size(183, 20);
            this.SmtpHost.TabIndex = 1;
            // 
            // SmtpUser
            // 
            this.SmtpUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SmtpUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SmtpUser.Location = new System.Drawing.Point(87, 52);
            this.SmtpUser.Name = "SmtpUser";
            this.SmtpUser.Size = new System.Drawing.Size(183, 20);
            this.SmtpUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 81);
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
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(20, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Smtp Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login";
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.SystemColors.Control;
            this.buttonApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonApply.Location = new System.Drawing.Point(238, 209);
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
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "VsGeneralSetting";
            this.Size = new System.Drawing.Size(337, 243);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox EmailFrom;
        private System.Windows.Forms.TextBox SmtpUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox SmtpPasswd;
        private System.Windows.Forms.TextBox SmtpHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TextBox EmailTo;
        private System.Windows.Forms.Label label1;
    }
}
