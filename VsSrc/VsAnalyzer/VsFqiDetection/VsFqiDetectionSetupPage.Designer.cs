// xduc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hegq	
// deer	 By downloading, copying, installing or using the software you agree to this license.
// awur	 If you do not agree to this license, do not download, install,
// elag	 copy or use the software.
// uijr	
// iixq	                          License Agreement
// lltn	         For OpenVss - Open Source Video Surveillance System
// znis	
// owac	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// byfd	
// sysx	Third party copyrights are property of their respective owners.
// acwy	
// nlpo	Redistribution and use in source and binary forms, with or without modification,
// udty	are permitted provided that the following conditions are met:
// hqer	
// lqrm	  * Redistribution's of source code must retain the above copyright notice,
// occi	    this list of conditions and the following disclaimer.
// kyfv	
// dfyk	  * Redistribution's in binary form must reproduce the above copyright notice,
// qapj	    this list of conditions and the following disclaimer in the documentation
// puzo	    and/or other materials provided with the distribution.
// ytxl	
// cbul	  * Neither the name of the copyright holders nor the names of its contributors 
// torb	    may not be used to endorse or promote products derived from this software 
// gfjy	    without specific prior written permission.
// zonp	
// gtlo	This software is provided by the copyright holders and contributors "as is" and
// eiih	any express or implied warranties, including, but not limited to, the implied
// avcr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rdou	In no event shall the Prince of Songkla University or contributors be liable 
// erfi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// duco	(including, but not limited to, procurement of substitute goods or services;
// nxek	loss of use, data, or profits; or business interruption) however caused
// qrka	and on any theory of liability, whether in contract, strict liability,
// gkhe	or tort (including negligence or otherwise) arising in any way out of
// ijhu	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Analyzer.FqiDetection
{
    partial class VsFqiDetectionSetupPage
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
            this.trackBar1.Maximum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(361, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Constant N";
            // 
            // VsFqiDetectionSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "VsFqiDetectionSetupPage";
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
