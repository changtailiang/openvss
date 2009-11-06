// ctrh	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jrvs	
// qedz	 By downloading, copying, installing or using the software you agree to this license.
// synu	 If you do not agree to this license, do not download, install,
// rxih	 copy or use the software.
// pbgq	
// syjr	                          License Agreement
// zjps	         For OpenVss - Open Source Video Surveillance System
// nrhi	
// pbeq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ppyt	
// tpma	Third party copyrights are property of their respective owners.
// uedp	
// liqa	Redistribution and use in source and binary forms, with or without modification,
// mbol	are permitted provided that the following conditions are met:
// idsh	
// pllb	  * Redistribution's of source code must retain the above copyright notice,
// qefq	    this list of conditions and the following disclaimer.
// srrz	
// dnxd	  * Redistribution's in binary form must reproduce the above copyright notice,
// ljxu	    this list of conditions and the following disclaimer in the documentation
// fagf	    and/or other materials provided with the distribution.
// agwo	
// msil	  * Neither the name of the copyright holders nor the names of its contributors 
// wrei	    may not be used to endorse or promote products derived from this software 
// dljp	    without specific prior written permission.
// ynwu	
// qqxy	This software is provided by the copyright holders and contributors "as is" and
// dlzz	any express or implied warranties, including, but not limited to, the implied
// gybp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// egaj	In no event shall the Prince of Songkla University or contributors be liable 
// irda	for any direct, indirect, incidental, special, exemplary, or consequential damages
// igdl	(including, but not limited to, procurement of substitute goods or services;
// jpza	loss of use, data, or profits; or business interruption) however caused
// zhvs	and on any theory of liability, whether in contract, strict liability,
// dmpj	or tort (including negligence or otherwise) arising in any way out of
// jxkb	the use of this software, even if advised of the possibility of such damage.

namespace VsSetup
{
    partial class WMEncodeSetup
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Install Windows Media Encoder";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 47);
            this.button3.TabIndex = 3;
            this.button3.Text = "Install Window Media Encoder";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Please install Windows Media Encoder";
            // 
            // WMEncodeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "WMEncodeSetup";
            this.Size = new System.Drawing.Size(394, 481);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}
