// prxm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// euvj	
// gjcc	 By downloading, copying, installing or using the software you agree to this license.
// bpxu	 If you do not agree to this license, do not download, install,
// dhpo	 copy or use the software.
// ecgf	
// fbdu	                          License Agreement
// adyb	         For OpenVSS - Open Source Video Surveillance System
// flqj	
// ixnf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gokt	
// jksw	Third party copyrights are property of their respective owners.
// hapa	
// oubn	Redistribution and use in source and binary forms, with or without modification,
// lrhc	are permitted provided that the following conditions are met:
// qaid	
// laxp	  * Redistribution's of source code must retain the above copyright notice,
// znmg	    this list of conditions and the following disclaimer.
// ujiq	
// rmwv	  * Redistribution's in binary form must reproduce the above copyright notice,
// ihna	    this list of conditions and the following disclaimer in the documentation
// nymk	    and/or other materials provided with the distribution.
// kdyq	
// qkof	  * Neither the name of the copyright holders nor the names of its contributors 
// ggii	    may not be used to endorse or promote products derived from this software 
// ndwu	    without specific prior written permission.
// njfe	
// mlvz	This software is provided by the copyright holders and contributors "as is" and
// vluj	any express or implied warranties, including, but not limited to, the implied
// nipm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// omfw	In no event shall the Prince of Songkla University or contributors be liable 
// ovqj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vcjl	(including, but not limited to, procurement of substitute goods or services;
// dnif	loss of use, data, or profits; or business interruption) however caused
// ksme	and on any theory of liability, whether in contract, strict liability,
// shxz	or tort (including negligence or otherwise) arising in any way out of
// izve	the use of this software, even if advised of the possibility of such damage.
// qesx	
// qvua	Intelligent Systems Laboratory (iSys Lab)
// xags	Faculty of Engineering, Prince of Songkla University, THAILAND
// twjk	Project leader by Nikom SUVONVORN
// bkvh	Project website at http://code.google.com/p/openvss/

namespace InsertAssemblyInfo
{
    partial class VsInseartAssemblyInfo
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxAssemblyCompany = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAssemblyCopyright = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(130, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(705, 290);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Dir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(705, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(12, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Search File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 148);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "AssemblyInfo.cs";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "test";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel1.Text = "test";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(763, 415);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Open file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxAssemblyCompany
            // 
            this.textBoxAssemblyCompany.Location = new System.Drawing.Point(242, 90);
            this.textBoxAssemblyCompany.Name = "textBoxAssemblyCompany";
            this.textBoxAssemblyCompany.Size = new System.Drawing.Size(183, 20);
            this.textBoxAssemblyCompany.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 234);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 38);
            this.button4.TabIndex = 10;
            this.button4.Text = "Append textfile";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "AssemblyCompany";
            // 
            // textBoxAssemblyCopyright
            // 
            this.textBoxAssemblyCopyright.Location = new System.Drawing.Point(572, 90);
            this.textBoxAssemblyCopyright.Name = "textBoxAssemblyCopyright";
            this.textBoxAssemblyCopyright.Size = new System.Drawing.Size(174, 20);
            this.textBoxAssemblyCopyright.TabIndex = 12;
            this.textBoxAssemblyCopyright.Text = "Copyright   2008";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "AssemblyCopyright";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 460);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAssemblyCopyright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxAssemblyCompany);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxAssemblyCompany;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAssemblyCopyright;
        private System.Windows.Forms.Label label2;
    }
}

