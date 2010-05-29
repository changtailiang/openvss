// jstn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qavr	
// hdiv	 By downloading, copying, installing or using the software you agree to this license.
// gpys	 If you do not agree to this license, do not download, install,
// uwci	 copy or use the software.
// vvvn	
// bgju	                          License Agreement
// tory	         For OpenVSS - Open Source Video Surveillance System
// ugli	
// qjop	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ollh	
// nbgz	Third party copyrights are property of their respective owners.
// dspu	
// cqno	Redistribution and use in source and binary forms, with or without modification,
// wfmj	are permitted provided that the following conditions are met:
// qayt	
// mjba	  * Redistribution's of source code must retain the above copyright notice,
// epck	    this list of conditions and the following disclaimer.
// hnuj	
// jnzz	  * Redistribution's in binary form must reproduce the above copyright notice,
// zkrb	    this list of conditions and the following disclaimer in the documentation
// zxwe	    and/or other materials provided with the distribution.
// twlk	
// xfyn	  * Neither the name of the copyright holders nor the names of its contributors 
// nsve	    may not be used to endorse or promote products derived from this software 
// agvn	    without specific prior written permission.
// qemo	
// wdej	This software is provided by the copyright holders and contributors "as is" and
// fmjg	any express or implied warranties, including, but not limited to, the implied
// jwto	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mwhh	In no event shall the Prince of Songkla University or contributors be liable 
// ernc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pgwq	(including, but not limited to, procurement of substitute goods or services;
// rvzt	loss of use, data, or profits; or business interruption) however caused
// oeku	and on any theory of liability, whether in contract, strict liability,
// khip	or tort (including negligence or otherwise) arising in any way out of
// rbfk	the use of this software, even if advised of the possibility of such damage.
// vseq	
// ygrd	Intelligent Systems Laboratory (iSys Lab)
// yniz	Faculty of Engineering, Prince of Songkla University, THAILAND
// qjzp	Project leader by Nikom SUVONVORN
// gorj	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback
{
    partial class test
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.camList1 = new Vs.Playback.CamList();
            this.vsTimeLine1 = new Vs.Playback.TimeLine.VsTimeLine();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(291, 172);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 186);
            this.listBox1.TabIndex = 4;
            // 
            // camList1
            // 
            this.camList1.Location = new System.Drawing.Point(12, 159);
            this.camList1.Name = "camList1";
            this.camList1.Size = new System.Drawing.Size(134, 199);
            this.camList1.TabIndex = 3;
            // 
            // vsTimeLine1
            // 
            this.vsTimeLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.vsTimeLine1.Location = new System.Drawing.Point(0, 0);
            this.vsTimeLine1.Name = "vsTimeLine1";
            this.vsTimeLine1.Size = new System.Drawing.Size(884, 153);
            this.vsTimeLine1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(449, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // test
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 370);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.camList1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vsTimeLine1);
            this.Name = "test";
            this.Text = "test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vs.Playback.TimeLine.VsTimeLine vsTimeLine1;
        private System.Windows.Forms.Button button1;
        private CamList camList1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;

    }
}
