// luoy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bwrd	
// ccbt	 By downloading, copying, installing or using the software you agree to this license.
// bapi	 If you do not agree to this license, do not download, install,
// sryl	 copy or use the software.
// kbyq	
// vltf	                          License Agreement
// ymat	         For OpenVSS - Open Source Video Surveillance System
// jznb	
// fjxe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qmxp	
// uqdl	Third party copyrights are property of their respective owners.
// jsqy	
// lvrj	Redistribution and use in source and binary forms, with or without modification,
// vxdq	are permitted provided that the following conditions are met:
// cmeq	
// chjb	  * Redistribution's of source code must retain the above copyright notice,
// nodj	    this list of conditions and the following disclaimer.
// ttuy	
// djve	  * Redistribution's in binary form must reproduce the above copyright notice,
// hivg	    this list of conditions and the following disclaimer in the documentation
// vchn	    and/or other materials provided with the distribution.
// hdfh	
// fhbd	  * Neither the name of the copyright holders nor the names of its contributors 
// ignm	    may not be used to endorse or promote products derived from this software 
// gbxv	    without specific prior written permission.
// oher	
// atgm	This software is provided by the copyright holders and contributors "as is" and
// byiu	any express or implied warranties, including, but not limited to, the implied
// qyvz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// awuk	In no event shall the Prince of Songkla University or contributors be liable 
// jwdm	for any direct, indirect, incidental, special, exemplary, or consequential damages
// srqw	(including, but not limited to, procurement of substitute goods or services;
// vixf	loss of use, data, or profits; or business interruption) however caused
// karn	and on any theory of liability, whether in contract, strict liability,
// xpno	or tort (including negligence or otherwise) arising in any way out of
// xsfg	the use of this software, even if advised of the possibility of such damage.
// zhnj	
// lnmk	Intelligent Systems Laboratory (iSys Lab)
// hmls	Faculty of Engineering, Prince of Songkla University, THAILAND
// dszj	Project leader by Nikom SUVONVORN
// djqs	Project website at http://code.google.com/p/openvss/

namespace VsMobile
{
    partial class VsMLogin
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.proxy = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelLogin.Controls.Add(this.proxy);
            this.panelLogin.Controls.Add(this.button2);
            this.panelLogin.Controls.Add(this.password);
            this.panelLogin.Controls.Add(this.button1);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.username);
            this.panelLogin.Location = new System.Drawing.Point(3, 131);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(233, 134);
            // 
            // proxy
            // 
            this.proxy.Location = new System.Drawing.Point(57, 12);
            this.proxy.Name = "proxy";
            this.proxy.Size = new System.Drawing.Size(150, 21);
            this.proxy.TabIndex = 0;
            this.proxy.Text = "172.30.136.110";
            this.proxy.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "OK";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(57, 65);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(150, 21);
            this.password.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.Click += new System.EventHandler(this.buttonTime_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.Text = "Server";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.Text = "User";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(57, 39);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(150, 21);
            this.username.TabIndex = 1;
            this.username.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.Text = "Surveillance";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 108);
            // 
            // VsMLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "VsMLogin";
            this.Text = "Login";
            this.panelLogin.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox proxy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
    }
}
