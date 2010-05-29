// uqyg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cuqg	
// iuqf	 By downloading, copying, installing or using the software you agree to this license.
// nocw	 If you do not agree to this license, do not download, install,
// rmbg	 copy or use the software.
// vjsv	
// gshv	                          License Agreement
// atma	         For OpenVSS - Open Source Video Surveillance System
// rqkv	
// fuuh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gjot	
// stgl	Third party copyrights are property of their respective owners.
// wujj	
// lfzk	Redistribution and use in source and binary forms, with or without modification,
// yczk	are permitted provided that the following conditions are met:
// nufp	
// hpox	  * Redistribution's of source code must retain the above copyright notice,
// dgqx	    this list of conditions and the following disclaimer.
// rtzl	
// vzdm	  * Redistribution's in binary form must reproduce the above copyright notice,
// lvyg	    this list of conditions and the following disclaimer in the documentation
// kcol	    and/or other materials provided with the distribution.
// qaxd	
// ukul	  * Neither the name of the copyright holders nor the names of its contributors 
// dyld	    may not be used to endorse or promote products derived from this software 
// fjhp	    without specific prior written permission.
// dlss	
// fopy	This software is provided by the copyright holders and contributors "as is" and
// znzr	any express or implied warranties, including, but not limited to, the implied
// wzfe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// acgd	In no event shall the Prince of Songkla University or contributors be liable 
// jndh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yohw	(including, but not limited to, procurement of substitute goods or services;
// ozhb	loss of use, data, or profits; or business interruption) however caused
// oicy	and on any theory of liability, whether in contract, strict liability,
// kwgc	or tort (including negligence or otherwise) arising in any way out of
// kzeh	the use of this software, even if advised of the possibility of such damage.
// kdod	
// tgcc	Intelligent Systems Laboratory (iSys Lab)
// cdgq	Faculty of Engineering, Prince of Songkla University, THAILAND
// iktq	Project leader by Nikom SUVONVORN
// gtkz	Project website at http://code.google.com/p/openvss/

namespace VsMobile
{
    partial class VsMPlayBack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dtpTime2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.btOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboBox2.Location = new System.Drawing.Point(11, 105);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 22);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.Text = "Camera No.";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(11, 150);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // dtpTime
            // 
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(127, 150);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(100, 22);
            this.dtpTime.TabIndex = 2;
            // 
            // dtpTime2
            // 
            this.dtpTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime2.Location = new System.Drawing.Point(127, 193);
            this.dtpTime2.Name = "dtpTime2";
            this.dtpTime2.ShowUpDown = true;
            this.dtpTime2.Size = new System.Drawing.Size(100, 22);
            this.dtpTime2.TabIndex = 3;
            // 
            // dtpDate2
            // 
            this.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate2.Location = new System.Drawing.Point(11, 193);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(100, 22);
            this.dtpDate2.TabIndex = 4;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btOk.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btOk.Location = new System.Drawing.Point(11, 228);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(100, 31);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "Ok";
            this.btOk.Click += new System.EventHandler(this.btOk_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 91);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(4, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 36);
            this.label6.Text = "VsMobile\r\n\r\n";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(139, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.Text = "System";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.Text = "Surveillance";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboBox1.Items.Add("High");
            this.comboBox1.Items.Add("Medium");
            this.comboBox1.Items.Add("Low");
            this.comboBox1.Location = new System.Drawing.Point(127, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 22);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Quality";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Location = new System.Drawing.Point(11, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 21);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "From";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox2.Location = new System.Drawing.Point(11, 173);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 21);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "To";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Location = new System.Drawing.Point(127, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Cancle";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VsMPlayBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.dtpDate2);
            this.Controls.Add(this.dtpTime2);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.comboBox2);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "VsMPlayBack";
            this.Text = "VsMPlayback";
            this.Load += new System.EventHandler(this.VsMPlayBack_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DateTimePicker dtpTime2;
        private System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;

    }
}
