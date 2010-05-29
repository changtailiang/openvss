// dehr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ilgx	
// tsrb	 By downloading, copying, installing or using the software you agree to this license.
// zxlh	 If you do not agree to this license, do not download, install,
// eegv	 copy or use the software.
// fkub	
// dget	                          License Agreement
// jcwh	         For OpenVSS - Open Source Video Surveillance System
// efou	
// skbm	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bzuh	
// opyg	Third party copyrights are property of their respective owners.
// dytj	
// xnxt	Redistribution and use in source and binary forms, with or without modification,
// jgnb	are permitted provided that the following conditions are met:
// hnoq	
// wjxt	  * Redistribution's of source code must retain the above copyright notice,
// jrpu	    this list of conditions and the following disclaimer.
// dutg	
// pmno	  * Redistribution's in binary form must reproduce the above copyright notice,
// hxpl	    this list of conditions and the following disclaimer in the documentation
// imjq	    and/or other materials provided with the distribution.
// ivkl	
// wzeo	  * Neither the name of the copyright holders nor the names of its contributors 
// keke	    may not be used to endorse or promote products derived from this software 
// rexl	    without specific prior written permission.
// izgc	
// urdw	This software is provided by the copyright holders and contributors "as is" and
// sztj	any express or implied warranties, including, but not limited to, the implied
// xchk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zhln	In no event shall the Prince of Songkla University or contributors be liable 
// hdxd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qfvk	(including, but not limited to, procurement of substitute goods or services;
// ciwd	loss of use, data, or profits; or business interruption) however caused
// aecj	and on any theory of liability, whether in contract, strict liability,
// ggvr	or tort (including negligence or otherwise) arising in any way out of
// rnsx	the use of this software, even if advised of the possibility of such damage.
// fvqi	
// xaek	Intelligent Systems Laboratory (iSys Lab)
// tkef	Faculty of Engineering, Prince of Songkla University, THAILAND
// bcmp	Project leader by Nikom SUVONVORN
// vsuk	Project website at http://code.google.com/p/openvss/

namespace Vs.Analyzer.ObjectDetection
{
    partial class VsObjectDetectionSetupPage
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "haarcascade_eye.xml",
            "haarcascade_eye_tree_eyeglasses.xml",
            "haarcascade_frontalface_alt.xml",
            "haarcascade_frontalface_alt2.xml",
            "haarcascade_frontalface_alt_tree.xml",
            "haarcascade_frontalface_default.xml",
            "haarcascade_fullbody.xml",
            "haarcascade_lefteye_2splits.xml",
            "haarcascade_lowerbody.xml",
            "haarcascade_mcs_eyepair_big.xml",
            "haarcascade_mcs_eyepair_small.xml",
            "haarcascade_mcs_lefteye.xml",
            "haarcascade_mcs_mouth.xml",
            "haarcascade_mcs_nose.xml",
            "haarcascade_mcs_righteye.xml",
            "haarcascade_mcs_upperbody.xml",
            "haarcascade_profileface.xml",
            "haarcascade_righteye_2splits.xml",
            "haarcascade_upperbody.xml"});
            this.comboBox1.Location = new System.Drawing.Point(16, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(393, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Detecting Object";
            // 
            // VsObjectDetectionSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "VsObjectDetectionSetupPage";
            this.Size = new System.Drawing.Size(421, 181);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}
