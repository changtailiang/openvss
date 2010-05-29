// zeza	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qzyg	
// fyrg	 By downloading, copying, installing or using the software you agree to this license.
// xbni	 If you do not agree to this license, do not download, install,
// ryii	 copy or use the software.
// opzn	
// ypbo	                          License Agreement
// nzaa	         For OpenVSS - Open Source Video Surveillance System
// zqkk	
// kkms	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cxle	
// hbqe	Third party copyrights are property of their respective owners.
// nbnc	
// rgkj	Redistribution and use in source and binary forms, with or without modification,
// fmba	are permitted provided that the following conditions are met:
// xktf	
// yrgh	  * Redistribution's of source code must retain the above copyright notice,
// qdxh	    this list of conditions and the following disclaimer.
// lqgr	
// eufw	  * Redistribution's in binary form must reproduce the above copyright notice,
// zwam	    this list of conditions and the following disclaimer in the documentation
// lyit	    and/or other materials provided with the distribution.
// gafy	
// ilur	  * Neither the name of the copyright holders nor the names of its contributors 
// efgq	    may not be used to endorse or promote products derived from this software 
// vjok	    without specific prior written permission.
// egqb	
// asfk	This software is provided by the copyright holders and contributors "as is" and
// geba	any express or implied warranties, including, but not limited to, the implied
// khta	warranties of merchantability and fitness for a particular purpose are disclaimed.
// inaq	In no event shall the Prince of Songkla University or contributors be liable 
// xyya	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wony	(including, but not limited to, procurement of substitute goods or services;
// oobp	loss of use, data, or profits; or business interruption) however caused
// iqhf	and on any theory of liability, whether in contract, strict liability,
// hhtn	or tort (including negligence or otherwise) arising in any way out of
// vvrd	the use of this software, even if advised of the possibility of such damage.
// jthx	
// lfih	Intelligent Systems Laboratory (iSys Lab)
// ixmf	Faculty of Engineering, Prince of Songkla University, THAILAND
// hqfl	Project leader by Nikom SUVONVORN
// fgvr	Project website at http://code.google.com/p/openvss/

namespace VsMobile
{
    partial class VsMSelect
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.rbPBMjpeg = new System.Windows.Forms.RadioButton();
            this.rbPBWmv = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLJpeg = new System.Windows.Forms.RadioButton();
            this.rbLMjpeg = new System.Windows.Forms.RadioButton();
            this.btCancle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(0, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 36);
            this.label6.Text = "VsMobile\r\n\r\n";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(20, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.Text = "Surveillance";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(132, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.Text = "System";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 124);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.btOk);
            this.panel2.Controls.Add(this.rbPBMjpeg);
            this.panel2.Controls.Add(this.rbPBWmv);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rbLJpeg);
            this.panel2.Controls.Add(this.rbLMjpeg);
            this.panel2.Controls.Add(this.btCancle);
            this.panel2.Location = new System.Drawing.Point(9, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 150);
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btOk.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btOk.Location = new System.Drawing.Point(17, 109);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 28);
            this.btOk.TabIndex = 13;
            this.btOk.Text = "Ok";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // rbPBMjpeg
            // 
            this.rbPBMjpeg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rbPBMjpeg.ForeColor = System.Drawing.Color.Navy;
            this.rbPBMjpeg.Location = new System.Drawing.Point(94, 72);
            this.rbPBMjpeg.Name = "rbPBMjpeg";
            this.rbPBMjpeg.Size = new System.Drawing.Size(60, 20);
            this.rbPBMjpeg.TabIndex = 12;
            this.rbPBMjpeg.TabStop = false;
            this.rbPBMjpeg.Text = "Mjpeg";
            // 
            // rbPBWmv
            // 
            this.rbPBWmv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rbPBWmv.ForeColor = System.Drawing.Color.Navy;
            this.rbPBWmv.Location = new System.Drawing.Point(160, 72);
            this.rbPBWmv.Name = "rbPBWmv";
            this.rbPBWmv.Size = new System.Drawing.Size(60, 20);
            this.rbPBWmv.TabIndex = 11;
            this.rbPBWmv.TabStop = false;
            this.rbPBWmv.Text = "....";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "VsPlayback";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 35);
            this.label1.Text = "VsLive";
            // 
            // rbLJpeg
            // 
            this.rbLJpeg.ForeColor = System.Drawing.Color.Navy;
            this.rbLJpeg.Location = new System.Drawing.Point(160, 25);
            this.rbLJpeg.Name = "rbLJpeg";
            this.rbLJpeg.Size = new System.Drawing.Size(69, 20);
            this.rbLJpeg.TabIndex = 8;
            this.rbLJpeg.TabStop = false;
            this.rbLJpeg.Text = "Jpeg";
            this.rbLJpeg.CheckedChanged += new System.EventHandler(this.rbLJpeg_CheckedChanged);
            // 
            // rbLMjpeg
            // 
            this.rbLMjpeg.Checked = true;
            this.rbLMjpeg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rbLMjpeg.ForeColor = System.Drawing.Color.Navy;
            this.rbLMjpeg.Location = new System.Drawing.Point(94, 25);
            this.rbLMjpeg.Name = "rbLMjpeg";
            this.rbLMjpeg.Size = new System.Drawing.Size(60, 20);
            this.rbLMjpeg.TabIndex = 7;
            this.rbLMjpeg.Text = "Mjpeg";
            this.rbLMjpeg.CheckedChanged += new System.EventHandler(this.rbLMjpeg_CheckedChanged);
            // 
            // btCancle
            // 
            this.btCancle.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btCancle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btCancle.Location = new System.Drawing.Point(125, 109);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(72, 28);
            this.btCancle.TabIndex = 6;
            this.btCancle.Text = "Cancle";
            this.btCancle.Click += new System.EventHandler(this.button3_Click);
            // 
            // VsMSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "VsMSelect";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCancle;
        private System.Windows.Forms.RadioButton rbLJpeg;
        private System.Windows.Forms.RadioButton rbLMjpeg;
        private System.Windows.Forms.RadioButton rbPBMjpeg;
        private System.Windows.Forms.RadioButton rbPBWmv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOk;

    }
}
