// eckt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wvbx	
// uhgs	 By downloading, copying, installing or using the software you agree to this license.
// utjx	 If you do not agree to this license, do not download, install,
// agjl	 copy or use the software.
// svzj	
// wsfg	                          License Agreement
// ouqz	         For OpenVSS - Open Source Video Surveillance System
// ubjy	
// bvam	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// rdlc	
// lymx	Third party copyrights are property of their respective owners.
// wsmy	
// axci	Redistribution and use in source and binary forms, with or without modification,
// cbxe	are permitted provided that the following conditions are met:
// puiz	
// rgxt	  * Redistribution's of source code must retain the above copyright notice,
// jkwf	    this list of conditions and the following disclaimer.
// gwup	
// jxxx	  * Redistribution's in binary form must reproduce the above copyright notice,
// gijv	    this list of conditions and the following disclaimer in the documentation
// iszx	    and/or other materials provided with the distribution.
// zava	
// xvwx	  * Neither the name of the copyright holders nor the names of its contributors 
// umle	    may not be used to endorse or promote products derived from this software 
// bsnm	    without specific prior written permission.
// vgrd	
// dmyf	This software is provided by the copyright holders and contributors "as is" and
// dzyh	any express or implied warranties, including, but not limited to, the implied
// knqy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hauj	In no event shall the Prince of Songkla University or contributors be liable 
// owhk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// awux	(including, but not limited to, procurement of substitute goods or services;
// mswn	loss of use, data, or profits; or business interruption) however caused
// uxzb	and on any theory of liability, whether in contract, strict liability,
// bvum	or tort (including negligence or otherwise) arising in any way out of
// cqwx	the use of this software, even if advised of the possibility of such damage.
// xomh	
// vmxa	Intelligent Systems Laboratory (iSys Lab)
// yexz	Faculty of Engineering, Prince of Songkla University, THAILAND
// zhdg	Project leader by Nikom SUVONVORN
// ratk	Project website at http://code.google.com/p/openvss/

namespace VsMobile
{
    partial class VsMLive
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Menu";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 240;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboBox1.Items.Add("High");
            this.comboBox1.Items.Add("Medium");
            this.comboBox1.Items.Add("Low");
            this.comboBox1.Location = new System.Drawing.Point(134, 243);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 22);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Quality";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboBox2.Location = new System.Drawing.Point(4, 243);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(111, 22);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.Text = "Camera No.";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // VsMLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "VsMLive";
            this.Text = "VsLive";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

