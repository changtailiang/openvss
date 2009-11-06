// bddb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tiha	
// kzce	 By downloading, copying, installing or using the software you agree to this license.
// qxft	 If you do not agree to this license, do not download, install,
// tusd	 copy or use the software.
// evkp	
// uooz	                          License Agreement
// dxwv	         For OpenVss - Open Source Video Surveillance System
// mpua	
// owqm	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// nwsz	
// yjzq	Third party copyrights are property of their respective owners.
// wpmw	
// ktnf	Redistribution and use in source and binary forms, with or without modification,
// soge	are permitted provided that the following conditions are met:
// uhwm	
// chsb	  * Redistribution's of source code must retain the above copyright notice,
// dfex	    this list of conditions and the following disclaimer.
// efqi	
// dkql	  * Redistribution's in binary form must reproduce the above copyright notice,
// pxcn	    this list of conditions and the following disclaimer in the documentation
// kals	    and/or other materials provided with the distribution.
// boha	
// plsf	  * Neither the name of the copyright holders nor the names of its contributors 
// zfwr	    may not be used to endorse or promote products derived from this software 
// rxnq	    without specific prior written permission.
// kpse	
// deci	This software is provided by the copyright holders and contributors "as is" and
// yvow	any express or implied warranties, including, but not limited to, the implied
// ejbc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vazo	In no event shall the Prince of Songkla University or contributors be liable 
// yehs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nkix	(including, but not limited to, procurement of substitute goods or services;
// ozur	loss of use, data, or profits; or business interruption) however caused
// jmcv	and on any theory of liability, whether in contract, strict liability,
// ihow	or tort (including negligence or otherwise) arising in any way out of
// lycu	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Analyzer.EllipseDetection
{
    partial class VsEllipseDetectionSetupPage
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 45);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(361, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Threshold";
            // 
            // VsEllipseDetectionSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "VsEllipseDetectionSetupPage";
            this.Size = new System.Drawing.Size(421, 181);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;

    }
}
