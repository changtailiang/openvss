// pagv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// aljd	
// tfza	 By downloading, copying, installing or using the software you agree to this license.
// qnfi	 If you do not agree to this license, do not download, install,
// jort	 copy or use the software.
// elcg	
// aqyf	                          License Agreement
// motd	         For OpenVSS - Open Source Video Surveillance System
// hzfc	
// bzww	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fgcv	
// auyo	Third party copyrights are property of their respective owners.
// nkfe	
// atkd	Redistribution and use in source and binary forms, with or without modification,
// yavk	are permitted provided that the following conditions are met:
// merf	
// lwsq	  * Redistribution's of source code must retain the above copyright notice,
// hchk	    this list of conditions and the following disclaimer.
// rvnx	
// igff	  * Redistribution's in binary form must reproduce the above copyright notice,
// rksc	    this list of conditions and the following disclaimer in the documentation
// iodo	    and/or other materials provided with the distribution.
// obea	
// emjb	  * Neither the name of the copyright holders nor the names of its contributors 
// pxke	    may not be used to endorse or promote products derived from this software 
// bihk	    without specific prior written permission.
// dvne	
// fmvr	This software is provided by the copyright holders and contributors "as is" and
// upsc	any express or implied warranties, including, but not limited to, the implied
// loww	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tebf	In no event shall the Prince of Songkla University or contributors be liable 
// ygff	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mmik	(including, but not limited to, procurement of substitute goods or services;
// wbej	loss of use, data, or profits; or business interruption) however caused
// dhzm	and on any theory of liability, whether in contract, strict liability,
// byic	or tort (including negligence or otherwise) arising in any way out of
// gmfp	the use of this software, even if advised of the possibility of such damage.
// thpa	
// bnlx	Intelligent Systems Laboratory (iSys Lab)
// gbmw	Faculty of Engineering, Prince of Songkla University, THAILAND
// phst	Project leader by Nikom SUVONVORN
// ekvt	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback.TimeLine
{
    partial class VsTimeLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsTimeLine));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.videoSlider1 = new Vs.Playback.TimeLine.VideoSlider();
            this.colorSlider1 = new Vs.Playback.TimeLine.ColorSlider();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 139);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "C4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "C3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "C2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "C1";
            // 
            // button2
            // 
            this.button2.Image = global::Vs.Playback.Properties.Resources.control_pause_blue;
            this.button2.Location = new System.Drawing.Point(7, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 20);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Vs.Playback.Properties.Resources.control_play_blue;
            this.button1.Location = new System.Drawing.Point(73, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 20);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(147, 19);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "00:00:00";
            // 
            // textBox4
            // 
            this.textBox4.AllowDrop = true;
            this.textBox4.Location = new System.Drawing.Point(25, 74);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(116, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.AllowDrop = true;
            this.textBox3.Location = new System.Drawing.Point(25, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(116, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(25, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(116, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(25, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // videoSlider1
            // 
            this.videoSlider1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSlider1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.BarInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.BarMediaInnerColor = System.Drawing.Color.LightSkyBlue;
            this.videoSlider1.BarMediaOuterColor = System.Drawing.Color.DeepSkyBlue;
            this.videoSlider1.BarOffsetY = 0F;
            this.videoSlider1.BarOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.BorderRoundRectSize = new System.Drawing.Size(2, 2);
            this.videoSlider1.ChartColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.DataRect = ((System.Drawing.RectangleF)(resources.GetObject("videoSlider1.DataRect")));
            this.videoSlider1.displayDate = "11/2/2553";
            this.videoSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSlider1.LargeChange = ((uint)(5u));
            this.videoSlider1.Location = new System.Drawing.Point(147, 0);
            this.videoSlider1.Name = "videoSlider1";
            this.videoSlider1.ScreenOffsetY = 0F;
            this.videoSlider1.Size = new System.Drawing.Size(536, 120);
            this.videoSlider1.SmallChange = ((uint)(1u));
            this.videoSlider1.TabIndex = 4;
            this.videoSlider1.ThumbRoundRectSize = new System.Drawing.Size(2, 2);
            this.videoSlider1.Time24 = true;
            this.videoSlider1.Value = 0;
            this.videoSlider1.XLabel = "";
            this.videoSlider1.YLabel = "";
            // 
            // colorSlider1
            // 
            this.colorSlider1.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.colorSlider1.LargeChange = ((uint)(5u));
            this.colorSlider1.Location = new System.Drawing.Point(147, 120);
            this.colorSlider1.Name = "colorSlider1";
            this.colorSlider1.Size = new System.Drawing.Size(536, 19);
            this.colorSlider1.SmallChange = ((uint)(1u));
            this.colorSlider1.TabIndex = 3;
            this.colorSlider1.Text = "colorSlider1";
            this.colorSlider1.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.Value = 0;
            // 
            // VsTimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.videoSlider1);
            this.Controls.Add(this.colorSlider1);
            this.Controls.Add(this.panel1);
            this.Name = "VsTimeLine";
            this.Size = new System.Drawing.Size(683, 139);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private VideoSlider videoSlider1;
        private ColorSlider colorSlider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}
