// glnb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lnbe	
// mfxr	 By downloading, copying, installing or using the software you agree to this license.
// cqbs	 If you do not agree to this license, do not download, install,
// jsfm	 copy or use the software.
// rdwi	
// vfci	                          License Agreement
// wrpo	         For OpenVSS - Open Source Video Surveillance System
// ffct	
// ksvg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zrxc	
// jxke	Third party copyrights are property of their respective owners.
// gvnj	
// vdnc	Redistribution and use in source and binary forms, with or without modification,
// oegf	are permitted provided that the following conditions are met:
// kthu	
// pjlw	  * Redistribution's of source code must retain the above copyright notice,
// nihr	    this list of conditions and the following disclaimer.
// xznz	
// gtzx	  * Redistribution's in binary form must reproduce the above copyright notice,
// uyba	    this list of conditions and the following disclaimer in the documentation
// egsc	    and/or other materials provided with the distribution.
// szeg	
// mqvg	  * Neither the name of the copyright holders nor the names of its contributors 
// jdna	    may not be used to endorse or promote products derived from this software 
// loqx	    without specific prior written permission.
// owmv	
// qowu	This software is provided by the copyright holders and contributors "as is" and
// fikl	any express or implied warranties, including, but not limited to, the implied
// rhqj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qjdo	In no event shall the Prince of Songkla University or contributors be liable 
// dbfg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ehpd	(including, but not limited to, procurement of substitute goods or services;
// gylg	loss of use, data, or profits; or business interruption) however caused
// idmh	and on any theory of liability, whether in contract, strict liability,
// uxme	or tort (including negligence or otherwise) arising in any way out of
// cjbd	the use of this software, even if advised of the possibility of such damage.
// fjoc	
// mdkc	Intelligent Systems Laboratory (iSys Lab)
// kbum	Faculty of Engineering, Prince of Songkla University, THAILAND
// rfri	Project leader by Nikom SUVONVORN
// ztog	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback
{
    partial class VsVlcPlayer2
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.colorSlider1 = new Vs.Playback.TimeLine.ColorSlider();
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
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.vlcUserControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 479);
            this.panel2.TabIndex = 19;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.colorSlider1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 10);
            this.panel3.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 55);
            this.label1.TabIndex = 18;
            this.label1.Text = "0";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // colorSlider1
            // 
            this.colorSlider1.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider1.BarInnerColor = System.Drawing.Color.Black;
            this.colorSlider1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSlider1.ElapsedInnerColor = System.Drawing.Color.LightSteelBlue;
            this.colorSlider1.Enabled = false;
            this.colorSlider1.LargeChange = ((uint)(5u));
            this.colorSlider1.Location = new System.Drawing.Point(0, 0);
            this.colorSlider1.Name = "colorSlider1";
            this.colorSlider1.Size = new System.Drawing.Size(502, 10);
            this.colorSlider1.SmallChange = ((uint)(1u));
            this.colorSlider1.TabIndex = 19;
            this.colorSlider1.Text = "colorSlider1";
            this.colorSlider1.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.Value = 0;
            // 
            // VsVlcPlayer2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "VsVlcPlayer2";
            this.Size = new System.Drawing.Size(502, 479);
            this.SizeChanged += new System.EventHandler(this.VsVlcPlayer2_SizeChanged);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VLanControl.VlcUserControl vlcUserControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Vs.Playback.TimeLine.ColorSlider colorSlider1;
        private System.Windows.Forms.Timer timer2;
    }
}
