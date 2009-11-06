// ftgv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fdjf	
// qagp	 By downloading, copying, installing or using the software you agree to this license.
// ebbp	 If you do not agree to this license, do not download, install,
// gsdh	 copy or use the software.
// jsky	
// blja	                          License Agreement
// yzxl	         For OpenVss - Open Source Video Surveillance System
// bjom	
// ygjp	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bzpx	
// qpct	Third party copyrights are property of their respective owners.
// bofa	
// ooqn	Redistribution and use in source and binary forms, with or without modification,
// ihtu	are permitted provided that the following conditions are met:
// tjhr	
// cunv	  * Redistribution's of source code must retain the above copyright notice,
// mpqa	    this list of conditions and the following disclaimer.
// infk	
// cnim	  * Redistribution's in binary form must reproduce the above copyright notice,
// jpyj	    this list of conditions and the following disclaimer in the documentation
// uxxn	    and/or other materials provided with the distribution.
// sbdq	
// mpws	  * Neither the name of the copyright holders nor the names of its contributors 
// ryuv	    may not be used to endorse or promote products derived from this software 
// bggm	    without specific prior written permission.
// xera	
// igkv	This software is provided by the copyright holders and contributors "as is" and
// zgle	any express or implied warranties, including, but not limited to, the implied
// kxwf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wacl	In no event shall the Prince of Songkla University or contributors be liable 
// lant	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rntd	(including, but not limited to, procurement of substitute goods or services;
// smkc	loss of use, data, or profits; or business interruption) however caused
// immp	and on any theory of liability, whether in contract, strict liability,
// fwem	or tort (including negligence or otherwise) arising in any way out of
// qirg	the use of this software, even if advised of the possibility of such damage.

namespace VsSetup
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(388, 446);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Start";
            this.Size = new System.Drawing.Size(394, 481);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
