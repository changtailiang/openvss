// entp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xxyy	
// ugih	 By downloading, copying, installing or using the software you agree to this license.
// vcew	 If you do not agree to this license, do not download, install,
// afke	 copy or use the software.
// fgtm	
// ixyd	                          License Agreement
// hqit	         For OpenVSS - Open Source Video Surveillance System
// wltd	
// rgob	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// alig	
// lace	Third party copyrights are property of their respective owners.
// jlff	
// mpiy	Redistribution and use in source and binary forms, with or without modification,
// uhha	are permitted provided that the following conditions are met:
// yuqd	
// ypkk	  * Redistribution's of source code must retain the above copyright notice,
// ibfu	    this list of conditions and the following disclaimer.
// rjeu	
// ymah	  * Redistribution's in binary form must reproduce the above copyright notice,
// vuuw	    this list of conditions and the following disclaimer in the documentation
// kdgg	    and/or other materials provided with the distribution.
// cvjk	
// zocf	  * Neither the name of the copyright holders nor the names of its contributors 
// veiv	    may not be used to endorse or promote products derived from this software 
// qrwh	    without specific prior written permission.
// glnc	
// loah	This software is provided by the copyright holders and contributors "as is" and
// gzfe	any express or implied warranties, including, but not limited to, the implied
// autu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// iein	In no event shall the Prince of Songkla University or contributors be liable 
// ruud	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gyyt	(including, but not limited to, procurement of substitute goods or services;
// eerd	loss of use, data, or profits; or business interruption) however caused
// ympy	and on any theory of liability, whether in contract, strict liability,
// pdvn	or tort (including negligence or otherwise) arising in any way out of
// ucda	the use of this software, even if advised of the possibility of such damage.
// iyfa	
// knnl	Intelligent Systems Laboratory (iSys Lab)
// jipl	Faculty of Engineering, Prince of Songkla University, THAILAND
// rkwm	Project leader by Nikom SUVONVORN
// qgcb	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback
{
    partial class VsVlcPlayer
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
            this.components = new System.ComponentModel.Container();
            this.vlcUserControl1 = new VLanControl.VlcUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonPre = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // vlcUserControl1
            // 
            this.vlcUserControl1.BackColor = System.Drawing.Color.Black;
            this.vlcUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcUserControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcUserControl1.Name = "vlcUserControl1";
            this.vlcUserControl1.Size = new System.Drawing.Size(502, 479);
            this.vlcUserControl1.TabIndex = 17;
            this.vlcUserControl1.UseMpegVbrOffset = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vlcUserControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 479);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.buttonPre);
            this.panel3.Controls.Add(this.buttonNext);
            this.panel3.Controls.Add(this.buttonStop);
            this.panel3.Controls.Add(this.buttonPause);
            this.panel3.Controls.Add(this.buttonPlay);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 105);
            this.panel3.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox1.Location = new System.Drawing.Point(357, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "ต่อเนื่อง";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Value = 1;
            // 
            // buttonPre
            // 
            this.buttonPre.Image = global::Vs.Playback.Properties.Resources.control_start_blue;
            this.buttonPre.Location = new System.Drawing.Point(3, 32);
            this.buttonPre.Name = "buttonPre";
            this.buttonPre.Size = new System.Drawing.Size(50, 32);
            this.buttonPre.TabIndex = 11;
            this.buttonPre.UseVisualStyleBackColor = true;
            this.buttonPre.Click += new System.EventHandler(this.buttonPre_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Image = global::Vs.Playback.Properties.Resources.control_end_blue;
            this.buttonNext.Location = new System.Drawing.Point(227, 32);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 32);
            this.buttonNext.TabIndex = 10;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Image = global::Vs.Playback.Properties.Resources.control_stop_blue;
            this.buttonStop.Location = new System.Drawing.Point(171, 32);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(50, 32);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Image = global::Vs.Playback.Properties.Resources.control_pause_blue;
            this.buttonPause.Location = new System.Drawing.Point(115, 32);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(50, 32);
            this.buttonPause.TabIndex = 8;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Image = global::Vs.Playback.Properties.Resources.control_play_blue;
            this.buttonPlay.Location = new System.Drawing.Point(59, 32);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(50, 32);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(0, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(502, 35);
            this.textBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VsVlcPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "VsVlcPlayer";
            this.Size = new System.Drawing.Size(502, 479);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VLanControl.VlcUserControl vlcUserControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonPre;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
