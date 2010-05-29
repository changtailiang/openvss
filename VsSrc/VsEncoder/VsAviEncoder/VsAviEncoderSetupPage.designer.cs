// igxu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ojxz	
// bjiz	 By downloading, copying, installing or using the software you agree to this license.
// lcmv	 If you do not agree to this license, do not download, install,
// kzjo	 copy or use the software.
// hjxl	
// oilz	                          License Agreement
// lufe	         For OpenVSS - Open Source Video Surveillance System
// zobu	
// tole	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fzql	
// agjn	Third party copyrights are property of their respective owners.
// rueh	
// stnz	Redistribution and use in source and binary forms, with or without modification,
// jlfg	are permitted provided that the following conditions are met:
// xxng	
// dezw	  * Redistribution's of source code must retain the above copyright notice,
// arbw	    this list of conditions and the following disclaimer.
// neih	
// slli	  * Redistribution's in binary form must reproduce the above copyright notice,
// yyhq	    this list of conditions and the following disclaimer in the documentation
// qylg	    and/or other materials provided with the distribution.
// bbli	
// ifgi	  * Neither the name of the copyright holders nor the names of its contributors 
// ljiw	    may not be used to endorse or promote products derived from this software 
// gmma	    without specific prior written permission.
// tiuo	
// kfgx	This software is provided by the copyright holders and contributors "as is" and
// zxhz	any express or implied warranties, including, but not limited to, the implied
// pxqe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// stuy	In no event shall the Prince of Songkla University or contributors be liable 
// gtnh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xavj	(including, but not limited to, procurement of substitute goods or services;
// docm	loss of use, data, or profits; or business interruption) however caused
// lhxi	and on any theory of liability, whether in contract, strict liability,
// exww	or tort (including negligence or otherwise) arising in any way out of
// unil	the use of this software, even if advised of the possibility of such damage.
// yhto	
// sden	Intelligent Systems Laboratory (iSys Lab)
// rnta	Faculty of Engineering, Prince of Songkla University, THAILAND
// umqk	Project leader by Nikom SUVONVORN
// jxul	Project website at http://code.google.com/p/openvss/

namespace Vs.Encoder.Avi
{
    partial class VsAviEncoderSetupPage
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
            this.codecsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageWidth = new System.Windows.Forms.TextBox();
            this.imageHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.quality = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codecsName
            // 
            this.codecsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codecsName.Location = new System.Drawing.Point(72, 61);
            this.codecsName.Name = "codecsName";
            this.codecsName.Size = new System.Drawing.Size(237, 20);
            this.codecsName.TabIndex = 3;
            this.codecsName.Text = "Windows Media Codecs 9.0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Codecs";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image";
            // 
            // imageWidth
            // 
            this.imageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageWidth.Location = new System.Drawing.Point(72, 30);
            this.imageWidth.Name = "imageWidth";
            this.imageWidth.Size = new System.Drawing.Size(62, 20);
            this.imageWidth.TabIndex = 1;
            this.imageWidth.Text = "320";
            // 
            // imageHeight
            // 
            this.imageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageHeight.Location = new System.Drawing.Point(151, 30);
            this.imageHeight.Name = "imageHeight";
            this.imageHeight.Size = new System.Drawing.Size(62, 20);
            this.imageHeight.TabIndex = 2;
            this.imageHeight.Text = "240";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(69, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(148, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Height";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quality";
            // 
            // quality
            // 
            this.quality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quality.Location = new System.Drawing.Point(72, 92);
            this.quality.Name = "quality";
            this.quality.Size = new System.Drawing.Size(141, 20);
            this.quality.TabIndex = 4;
            this.quality.Text = "100";
            // 
            // VsAviEncoderSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageHeight);
            this.Controls.Add(this.imageWidth);
            this.Controls.Add(this.quality);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.codecsName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "VsAviEncoderSetupPage";
            this.Size = new System.Drawing.Size(374, 203);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codecsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imageWidth;
        private System.Windows.Forms.TextBox imageHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox quality;
    }
}
