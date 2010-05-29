// ctew	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kgba	
// chpk	 By downloading, copying, installing or using the software you agree to this license.
// utge	 If you do not agree to this license, do not download, install,
// oddy	 copy or use the software.
// deba	
// byne	                          License Agreement
// cxpz	         For OpenVSS - Open Source Video Surveillance System
// qfjo	
// qoti	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cdtc	
// ulxh	Third party copyrights are property of their respective owners.
// dpvb	
// hcmy	Redistribution and use in source and binary forms, with or without modification,
// sevl	are permitted provided that the following conditions are met:
// sxxe	
// squo	  * Redistribution's of source code must retain the above copyright notice,
// jroz	    this list of conditions and the following disclaimer.
// kvvz	
// kygp	  * Redistribution's in binary form must reproduce the above copyright notice,
// bgbn	    this list of conditions and the following disclaimer in the documentation
// cnsn	    and/or other materials provided with the distribution.
// slwl	
// tipf	  * Neither the name of the copyright holders nor the names of its contributors 
// gpkd	    may not be used to endorse or promote products derived from this software 
// qjxl	    without specific prior written permission.
// awrl	
// hnot	This software is provided by the copyright holders and contributors "as is" and
// yfkm	any express or implied warranties, including, but not limited to, the implied
// vjce	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yhvy	In no event shall the Prince of Songkla University or contributors be liable 
// ucfb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fptv	(including, but not limited to, procurement of substitute goods or services;
// ocys	loss of use, data, or profits; or business interruption) however caused
// ipnf	and on any theory of liability, whether in contract, strict liability,
// vgff	or tort (including negligence or otherwise) arising in any way out of
// xcmo	the use of this software, even if advised of the possibility of such damage.
// ycjw	
// mffj	Intelligent Systems Laboratory (iSys Lab)
// nzrx	Faculty of Engineering, Prince of Songkla University, THAILAND
// qpfs	Project leader by Nikom SUVONVORN
// usfw	Project website at http://code.google.com/p/openvss/

namespace VsWinServiceControl
{
    partial class VsWinserviceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsWinserviceControl));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Install Service";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "StartService";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(38, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 21);
            this.button3.TabIndex = 2;
            this.button3.Text = "Stop Service";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(39, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 21);
            this.button4.TabIndex = 3;
            this.button4.Text = "UnInstall Serice";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(39, 129);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Restart Service";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // VsWinserviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 195);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VsWinserviceControl";
            this.Text = "Service Control";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

