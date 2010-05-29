// biou	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ogdp	
// mzik	 By downloading, copying, installing or using the software you agree to this license.
// lnjw	 If you do not agree to this license, do not download, install,
// fkwz	 copy or use the software.
// dlbz	
// iomx	                          License Agreement
// fbnl	         For OpenVSS - Open Source Video Surveillance System
// swil	
// oojq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lejz	
// cvns	Third party copyrights are property of their respective owners.
// pcxk	
// miyp	Redistribution and use in source and binary forms, with or without modification,
// gola	are permitted provided that the following conditions are met:
// tgkl	
// lwrp	  * Redistribution's of source code must retain the above copyright notice,
// fyiq	    this list of conditions and the following disclaimer.
// agoy	
// cbwn	  * Redistribution's in binary form must reproduce the above copyright notice,
// auhd	    this list of conditions and the following disclaimer in the documentation
// ddyj	    and/or other materials provided with the distribution.
// ytez	
// cjxe	  * Neither the name of the copyright holders nor the names of its contributors 
// uyof	    may not be used to endorse or promote products derived from this software 
// dynq	    without specific prior written permission.
// thjg	
// uznf	This software is provided by the copyright holders and contributors "as is" and
// syzy	any express or implied warranties, including, but not limited to, the implied
// yghh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yhrl	In no event shall the Prince of Songkla University or contributors be liable 
// tjnr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ijdd	(including, but not limited to, procurement of substitute goods or services;
// nrjb	loss of use, data, or profits; or business interruption) however caused
// hrjw	and on any theory of liability, whether in contract, strict liability,
// urpy	or tort (including negligence or otherwise) arising in any way out of
// gzhe	the use of this software, even if advised of the possibility of such damage.
// jyfo	
// qghv	Intelligent Systems Laboratory (iSys Lab)
// hbxk	Faculty of Engineering, Prince of Songkla University, THAILAND
// tryk	Project leader by Nikom SUVONVORN
// wjsb	Project website at http://code.google.com/p/openvss/

namespace Vs.Encoder.Wmv
{
    partial class VsWmvSetupPage
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
            // VsMediaEncoderSetupPage
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
            this.Name = "VsMediaEncoderSetupPage";
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
