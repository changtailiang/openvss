// djar	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vqpb	
// pyfn	 By downloading, copying, installing or using the software you agree to this license.
// xjti	 If you do not agree to this license, do not download, install,
// xpbb	 copy or use the software.
// mfvn	
// tmhu	                          License Agreement
// fmhu	         For OpenVSS - Open Source Video Surveillance System
// wsvj	
// jpzy	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// abdy	
// hbkw	Third party copyrights are property of their respective owners.
// fysb	
// zsyx	Redistribution and use in source and binary forms, with or without modification,
// nmyi	are permitted provided that the following conditions are met:
// iuvd	
// qkre	  * Redistribution's of source code must retain the above copyright notice,
// njzi	    this list of conditions and the following disclaimer.
// qcal	
// cxgs	  * Redistribution's in binary form must reproduce the above copyright notice,
// bkog	    this list of conditions and the following disclaimer in the documentation
// tfud	    and/or other materials provided with the distribution.
// uxvx	
// rqpg	  * Neither the name of the copyright holders nor the names of its contributors 
// fzhw	    may not be used to endorse or promote products derived from this software 
// jgjw	    without specific prior written permission.
// zkkw	
// smvq	This software is provided by the copyright holders and contributors "as is" and
// gfhx	any express or implied warranties, including, but not limited to, the implied
// fokl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qokp	In no event shall the Prince of Songkla University or contributors be liable 
// ncra	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mugc	(including, but not limited to, procurement of substitute goods or services;
// pjiv	loss of use, data, or profits; or business interruption) however caused
// bshj	and on any theory of liability, whether in contract, strict liability,
// vxlh	or tort (including negligence or otherwise) arising in any way out of
// cfrl	the use of this software, even if advised of the possibility of such damage.
// isaq	
// pwgv	Intelligent Systems Laboratory (iSys Lab)
// vtix	Faculty of Engineering, Prince of Songkla University, THAILAND
// sjky	Project leader by Nikom SUVONVORN
// gtaw	Project website at http://code.google.com/p/openvss/

namespace VsDbDeleteApp
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBoxDateSelect = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxDateSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "แสดงตารางทั้งหมดใน main Db";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(341, 9);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(392, 277);
            this.listBox1.TabIndex = 4;
            // 
            // groupBoxDateSelect
            // 
            this.groupBoxDateSelect.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBoxDateSelect.Controls.Add(this.dateTimePicker1);
            this.groupBoxDateSelect.Controls.Add(this.textBox2);
            this.groupBoxDateSelect.Controls.Add(this.trackBar1);
            this.groupBoxDateSelect.Controls.Add(this.label8);
            this.groupBoxDateSelect.Controls.Add(this.label3);
            this.groupBoxDateSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxDateSelect.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDateSelect.Name = "groupBoxDateSelect";
            this.groupBoxDateSelect.Size = new System.Drawing.Size(302, 74);
            this.groupBoxDateSelect.TabIndex = 47;
            this.groupBoxDateSelect.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(56, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 20);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox2.Location = new System.Drawing.Point(194, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 20);
            this.textBox2.TabIndex = 36;
            this.textBox2.Text = "00:00:01";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(47, 36);
            this.trackBar1.Maximum = 48;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(230, 45);
            this.trackBar1.TabIndex = 39;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(9, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "ชั่วโมง";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ตั้งแต่";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(277, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(277, 23);
            this.button3.TabIndex = 49;
            this.button3.Text = "แสดงไฟล์ในเวลาที่กำหนด";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 306);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxDateSelect);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxDateSelect.ResumeLayout(false);
            this.groupBoxDateSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBoxDateSelect;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

