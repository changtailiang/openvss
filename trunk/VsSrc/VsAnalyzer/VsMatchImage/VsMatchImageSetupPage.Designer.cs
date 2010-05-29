// avxk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yhlh	
// gctw	 By downloading, copying, installing or using the software you agree to this license.
// zbqs	 If you do not agree to this license, do not download, install,
// uxse	 copy or use the software.
// aphs	
// tedg	                          License Agreement
// tmyi	         For OpenVSS - Open Source Video Surveillance System
// koma	
// ldil	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jwar	
// xlmw	Third party copyrights are property of their respective owners.
// rmvd	
// dohl	Redistribution and use in source and binary forms, with or without modification,
// neru	are permitted provided that the following conditions are met:
// eenu	
// dklk	  * Redistribution's of source code must retain the above copyright notice,
// oqgr	    this list of conditions and the following disclaimer.
// ogve	
// pqvh	  * Redistribution's in binary form must reproduce the above copyright notice,
// sgph	    this list of conditions and the following disclaimer in the documentation
// rvfw	    and/or other materials provided with the distribution.
// gbmh	
// mohe	  * Neither the name of the copyright holders nor the names of its contributors 
// ignm	    may not be used to endorse or promote products derived from this software 
// zbia	    without specific prior written permission.
// fdow	
// sdwx	This software is provided by the copyright holders and contributors "as is" and
// ijbx	any express or implied warranties, including, but not limited to, the implied
// pfch	warranties of merchantability and fitness for a particular purpose are disclaimed.
// epen	In no event shall the Prince of Songkla University or contributors be liable 
// dzfz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yrvj	(including, but not limited to, procurement of substitute goods or services;
// cjhq	loss of use, data, or profits; or business interruption) however caused
// ypbn	and on any theory of liability, whether in contract, strict liability,
// hidd	or tort (including negligence or otherwise) arising in any way out of
// fpyc	the use of this software, even if advised of the possibility of such damage.
// mkoc	
// dfhk	Intelligent Systems Laboratory (iSys Lab)
// xvwf	Faculty of Engineering, Prince of Songkla University, THAILAND
// ypyb	Project leader by Nikom SUVONVORN
// hnuz	Project website at http://code.google.com/p/openvss/

namespace Vs.Analyzer.MatchImage
{
    partial class VsMatchImageSetupPage
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
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trackBar3);
            this.groupBox1.Controls.Add(this.trackBar2);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(16, 148);
            this.trackBar3.Maximum = 255;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(361, 45);
            this.trackBar3.TabIndex = 8;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(16, 91);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(361, 45);
            this.trackBar2.TabIndex = 8;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 35);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(361, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hough Threshold";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Week Threshold";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Stong Threshold";
            // 
            // VsMatchImageSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "VsMatchImageSetupPage";
            this.Size = new System.Drawing.Size(421, 203);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label3;

    }
}
