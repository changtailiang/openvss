// ceej	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pccl	
// avsl	 By downloading, copying, installing or using the software you agree to this license.
// oapr	 If you do not agree to this license, do not download, install,
// ekxb	 copy or use the software.
// cpnd	
// pgoz	                          License Agreement
// mjvn	         For OpenVss - Open Source Video Surveillance System
// hdnz	
// ehhr	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ubfz	
// dplq	Third party copyrights are property of their respective owners.
// ethb	
// tulm	Redistribution and use in source and binary forms, with or without modification,
// qaui	are permitted provided that the following conditions are met:
// ocyr	
// zedl	  * Redistribution's of source code must retain the above copyright notice,
// mpmw	    this list of conditions and the following disclaimer.
// dgha	
// joaa	  * Redistribution's in binary form must reproduce the above copyright notice,
// uxvs	    this list of conditions and the following disclaimer in the documentation
// buun	    and/or other materials provided with the distribution.
// raid	
// nycr	  * Neither the name of the copyright holders nor the names of its contributors 
// cozy	    may not be used to endorse or promote products derived from this software 
// lado	    without specific prior written permission.
// hlym	
// mlcc	This software is provided by the copyright holders and contributors "as is" and
// ator	any express or implied warranties, including, but not limited to, the implied
// hgpf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kqtm	In no event shall the Prince of Songkla University or contributors be liable 
// hjje	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dqxv	(including, but not limited to, procurement of substitute goods or services;
// ocpt	loss of use, data, or profits; or business interruption) however caused
// thlq	and on any theory of liability, whether in contract, strict liability,
// whag	or tort (including negligence or otherwise) arising in any way out of
// xfct	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Client
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "localhost";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(105, 75);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(186, 75);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 114);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login to Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
