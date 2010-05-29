// wiio	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tkom	
// kzll	 By downloading, copying, installing or using the software you agree to this license.
// yusp	 If you do not agree to this license, do not download, install,
// swzu	 copy or use the software.
// jxpv	
// rwgg	                          License Agreement
// ifwz	         For OpenVSS - Open Source Video Surveillance System
// wntg	
// ccve	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// iddk	
// fgew	Third party copyrights are property of their respective owners.
// vaku	
// pvdy	Redistribution and use in source and binary forms, with or without modification,
// snwx	are permitted provided that the following conditions are met:
// eidf	
// dlpl	  * Redistribution's of source code must retain the above copyright notice,
// blnq	    this list of conditions and the following disclaimer.
// bvlg	
// uepl	  * Redistribution's in binary form must reproduce the above copyright notice,
// sjli	    this list of conditions and the following disclaimer in the documentation
// uckb	    and/or other materials provided with the distribution.
// junp	
// gxaa	  * Neither the name of the copyright holders nor the names of its contributors 
// zxhu	    may not be used to endorse or promote products derived from this software 
// rsvj	    without specific prior written permission.
// nutu	
// jxen	This software is provided by the copyright holders and contributors "as is" and
// xkfu	any express or implied warranties, including, but not limited to, the implied
// wvkb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bncg	In no event shall the Prince of Songkla University or contributors be liable 
// yxjd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ukhw	(including, but not limited to, procurement of substitute goods or services;
// xvuz	loss of use, data, or profits; or business interruption) however caused
// obvz	and on any theory of liability, whether in contract, strict liability,
// iprm	or tort (including negligence or otherwise) arising in any way out of
// parv	the use of this software, even if advised of the possibility of such damage.
// sfde	
// nfsd	Intelligent Systems Laboratory (iSys Lab)
// qokp	Faculty of Engineering, Prince of Songkla University, THAILAND
// kqzy	Project leader by Nikom SUVONVORN
// qhpc	Project website at http://code.google.com/p/openvss/

namespace VsMobile
{
    partial class VsMotionPB
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer();
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
            this.pictureBox1.Size = new System.Drawing.Size(240, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.Control;
            this.listBox.Location = new System.Drawing.Point(-2, 182);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(240, 86);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 240;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // VsMotionPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.pictureBox1);
            this.Menu = this.mainMenu1;
            this.Name = "VsMotionPB";
            this.Text = "Playback";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Timer timer1;
    }
}
