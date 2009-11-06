// relx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nwep	
// jimq	 By downloading, copying, installing or using the software you agree to this license.
// xbzk	 If you do not agree to this license, do not download, install,
// diyp	 copy or use the software.
// tanp	
// wcee	                          License Agreement
// agbw	         For OpenVss - Open Source Video Surveillance System
// pwsl	
// chwn	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// czda	
// tzfy	Third party copyrights are property of their respective owners.
// rzjd	
// hqpr	Redistribution and use in source and binary forms, with or without modification,
// qvbl	are permitted provided that the following conditions are met:
// rzod	
// gqba	  * Redistribution's of source code must retain the above copyright notice,
// ioiw	    this list of conditions and the following disclaimer.
// mlnt	
// wmvw	  * Redistribution's in binary form must reproduce the above copyright notice,
// wgnb	    this list of conditions and the following disclaimer in the documentation
// xyoz	    and/or other materials provided with the distribution.
// gbug	
// fkvc	  * Neither the name of the copyright holders nor the names of its contributors 
// katd	    may not be used to endorse or promote products derived from this software 
// yeqc	    without specific prior written permission.
// qmrw	
// cwue	This software is provided by the copyright holders and contributors "as is" and
// aepk	any express or implied warranties, including, but not limited to, the implied
// mnfi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bcug	In no event shall the Prince of Songkla University or contributors be liable 
// ubqb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pljw	(including, but not limited to, procurement of substitute goods or services;
// ssyr	loss of use, data, or profits; or business interruption) however caused
// qkkk	and on any theory of liability, whether in contract, strict liability,
// gswk	or tort (including negligence or otherwise) arising in any way out of
// hqgb	the use of this software, even if advised of the possibility of such damage.

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

