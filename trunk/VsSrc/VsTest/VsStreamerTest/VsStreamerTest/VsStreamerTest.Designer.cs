// xrhi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vzph	
// mjxc	 By downloading, copying, installing or using the software you agree to this license.
// udnk	 If you do not agree to this license, do not download, install,
// pkoh	 copy or use the software.
// jqaw	
// uzjy	                          License Agreement
// cwvn	         For OpenVSS - Open Source Video Surveillance System
// rpyc	
// olfv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eqfd	
// ppgc	Third party copyrights are property of their respective owners.
// pvhu	
// wgnh	Redistribution and use in source and binary forms, with or without modification,
// qknv	are permitted provided that the following conditions are met:
// qreq	
// njle	  * Redistribution's of source code must retain the above copyright notice,
// fkvd	    this list of conditions and the following disclaimer.
// esds	
// kxhe	  * Redistribution's in binary form must reproduce the above copyright notice,
// tgjg	    this list of conditions and the following disclaimer in the documentation
// obqk	    and/or other materials provided with the distribution.
// crmd	
// xkfn	  * Neither the name of the copyright holders nor the names of its contributors 
// lppf	    may not be used to endorse or promote products derived from this software 
// ebxe	    without specific prior written permission.
// aepe	
// duws	This software is provided by the copyright holders and contributors "as is" and
// dibj	any express or implied warranties, including, but not limited to, the implied
// hycm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// taco	In no event shall the Prince of Songkla University or contributors be liable 
// yrgu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nphv	(including, but not limited to, procurement of substitute goods or services;
// ibas	loss of use, data, or profits; or business interruption) however caused
// iefk	and on any theory of liability, whether in contract, strict liability,
// lmgi	or tort (including negligence or otherwise) arising in any way out of
// utao	the use of this software, even if advised of the possibility of such damage.
// ivfm	
// ndmd	Intelligent Systems Laboratory (iSys Lab)
// zjgj	Faculty of Engineering, Prince of Songkla University, THAILAND
// xvqn	Project leader by Nikom SUVONVORN
// mbkc	Project website at http://code.google.com/p/openvss/

namespace VsStreamerTest
{
    partial class VsStreamerTest
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 46);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(263, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Stream";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(12, 75);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(263, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "224.0.0.1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 105);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(262, 121);
            this.listBox1.TabIndex = 2;
            // 
            // VsStreamerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 238);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonConnect);
            this.Name = "VsStreamerTest";
            this.Text = "VsStreamerTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

