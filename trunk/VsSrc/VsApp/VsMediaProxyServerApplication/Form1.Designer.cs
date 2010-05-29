// bshs	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ssik	
// voef	 By downloading, copying, installing or using the software you agree to this license.
// tnhz	 If you do not agree to this license, do not download, install,
// hpty	 copy or use the software.
// qfqs	
// emtj	                          License Agreement
// cbio	         For OpenVSS - Open Source Video Surveillance System
// nsjq	
// psms	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qjjl	
// ewbn	Third party copyrights are property of their respective owners.
// aygr	
// tbzw	Redistribution and use in source and binary forms, with or without modification,
// bpog	are permitted provided that the following conditions are met:
// zzit	
// gqsa	  * Redistribution's of source code must retain the above copyright notice,
// eqko	    this list of conditions and the following disclaimer.
// dbhh	
// vfoh	  * Redistribution's in binary form must reproduce the above copyright notice,
// kgje	    this list of conditions and the following disclaimer in the documentation
// vqvl	    and/or other materials provided with the distribution.
// tmoa	
// eftr	  * Neither the name of the copyright holders nor the names of its contributors 
// apen	    may not be used to endorse or promote products derived from this software 
// eaij	    without specific prior written permission.
// nsor	
// traw	This software is provided by the copyright holders and contributors "as is" and
// agvs	any express or implied warranties, including, but not limited to, the implied
// qeyp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vhhr	In no event shall the Prince of Songkla University or contributors be liable 
// bkkx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hqgg	(including, but not limited to, procurement of substitute goods or services;
// aadj	loss of use, data, or profits; or business interruption) however caused
// xzqd	and on any theory of liability, whether in contract, strict liability,
// cdrc	or tort (including negligence or otherwise) arising in any way out of
// mszy	the use of this software, even if advised of the possibility of such damage.
// jaaw	
// rpsx	Intelligent Systems Laboratory (iSys Lab)
// trhd	Faculty of Engineering, Prince of Songkla University, THAILAND
// hqkd	Project leader by Nikom SUVONVORN
// kuva	Project website at http://code.google.com/p/openvss/

namespace VsMediaProxyServerApplication
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(286, 133);
            this.textBox1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(60, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(234, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Strart Server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 151);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(46, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "8080";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 192);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(286, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "C:\\VsData";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 223);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Vs Media Proxy Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

