// ldks	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yqjg	
// deuk	 By downloading, copying, installing or using the software you agree to this license.
// tpxw	 If you do not agree to this license, do not download, install,
// pqam	 copy or use the software.
// hmmn	
// klcp	                          License Agreement
// elpp	         For OpenVSS - Open Source Video Surveillance System
// gtyk	
// lwdg	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hgcz	
// zmpi	Third party copyrights are property of their respective owners.
// iknw	
// fxqy	Redistribution and use in source and binary forms, with or without modification,
// qwin	are permitted provided that the following conditions are met:
// otcr	
// oeea	  * Redistribution's of source code must retain the above copyright notice,
// qmlt	    this list of conditions and the following disclaimer.
// nteb	
// jnox	  * Redistribution's in binary form must reproduce the above copyright notice,
// vtht	    this list of conditions and the following disclaimer in the documentation
// ytkj	    and/or other materials provided with the distribution.
// dato	
// npso	  * Neither the name of the copyright holders nor the names of its contributors 
// ellu	    may not be used to endorse or promote products derived from this software 
// ipsv	    without specific prior written permission.
// yujl	
// tood	This software is provided by the copyright holders and contributors "as is" and
// iksu	any express or implied warranties, including, but not limited to, the implied
// mitv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uuxq	In no event shall the Prince of Songkla University or contributors be liable 
// txfx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// aqwy	(including, but not limited to, procurement of substitute goods or services;
// cuog	loss of use, data, or profits; or business interruption) however caused
// blve	and on any theory of liability, whether in contract, strict liability,
// jypo	or tort (including negligence or otherwise) arising in any way out of
// lpfd	the use of this software, even if advised of the possibility of such damage.
// xybw	
// rpzn	Intelligent Systems Laboratory (iSys Lab)
// rbbb	Faculty of Engineering, Prince of Songkla University, THAILAND
// ollc	Project leader by Nikom SUVONVORN
// sqbo	Project website at http://code.google.com/p/openvss/

namespace Vs.Client
{
    partial class frmMain
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
            if ( disposing && ( components != null ) )
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.VS_START = new System.Windows.Forms.Button();
            this.VS_START_ALL = new System.Windows.Forms.Button();
            this.VS_STOP = new System.Windows.Forms.Button();
            this.VS_START_CONNECT = new System.Windows.Forms.Button();
            this.VS_START_CONNECT_ALL = new System.Windows.Forms.Button();
            this.VS_STOP_CONNECT = new System.Windows.Forms.Button();
            this.VS_STOP_ALL = new System.Windows.Forms.Button();
            this.VS_STOP_CONNECT_ALL = new System.Windows.Forms.Button();
            this.VS_START_ANALYSE = new System.Windows.Forms.Button();
            this.VS_START_ANALYSE_ALL = new System.Windows.Forms.Button();
            this.VS_STOP_ANALYSE = new System.Windows.Forms.Button();
            this.VS_STOP_ANALYSE_ALL = new System.Windows.Forms.Button();
            this.VS_START_EVENT_ALERT = new System.Windows.Forms.Button();
            this.VS_START_EVENT_ALERT_ALL = new System.Windows.Forms.Button();
            this.VS_STOP_EVENT_ALERT = new System.Windows.Forms.Button();
            this.VS_STOP_EVENT_ALERT_ALL = new System.Windows.Forms.Button();
            this.VS_START_RECORD = new System.Windows.Forms.Button();
            this.VS_START_RECORD_ALL = new System.Windows.Forms.Button();
            this.VS_STOP_RECORD = new System.Windows.Forms.Button();
            this.VS_STOP_RECORD_ALL = new System.Windows.Forms.Button();
            this.VS_START_DATA_ALERT = new System.Windows.Forms.Button();
            this.VS_START_DATA_ALERT_ALL = new System.Windows.Forms.Button();
            this.VS_STOP_DATA_ALERT = new System.Windows.Forms.Button();
            this.VS_STOP_DATA_ALERT_ALL = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERAS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERAS_CONNECT_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERAS_ANALYSE_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERAS_RECORD_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERA_ANALYSE_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERA_RECORD_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS = new System.Windows.Forms.Button();
            this.VS_LIST_CAMERA_CONNECT_STATUS = new System.Windows.Forms.Button();
            this.VS_INFO = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 542);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.VS_START, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_ALL, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_CONNECT, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_CONNECT_ALL, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_CONNECT, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_ALL, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_CONNECT_ALL, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_ANALYSE, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_ANALYSE_ALL, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_ANALYSE, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_ANALYSE_ALL, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_EVENT_ALERT, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_EVENT_ALERT_ALL, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_EVENT_ALERT, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_EVENT_ALERT_ALL, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_RECORD, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_RECORD_ALL, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_RECORD, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_RECORD_ALL, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_DATA_ALERT, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.VS_START_DATA_ALERT_ALL, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_DATA_ALERT, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.VS_STOP_DATA_ALERT_ALL, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERAS, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERAS_CONNECT_STATUS, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERAS_ANALYSE_STATUS, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERAS_RECORD_STATUS, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERAS_DATA_ALERT_STATUS, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERA_ANALYSE_STATUS, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERA_EVENT_ALERT_STATUS, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERA_RECORD_STATUS, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERA_DATA_ALERT_STATUS, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.VS_LIST_CAMERA_CONNECT_STATUS, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.VS_INFO, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.button36, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.button37, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.button38, 3, 10);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(714, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(299, 536);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // VS_START
            // 
            this.VS_START.BackColor = System.Drawing.Color.Red;
            this.VS_START.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START.ForeColor = System.Drawing.Color.White;
            this.VS_START.Location = new System.Drawing.Point(3, 3);
            this.VS_START.Name = "VS_START";
            this.VS_START.Size = new System.Drawing.Size(68, 42);
            this.VS_START.TabIndex = 0;
            this.VS_START.Text = "VS_START";
            this.VS_START.UseVisualStyleBackColor = false;
            this.VS_START.Click += new System.EventHandler(this.VS_START_Click);
            // 
            // VS_START_ALL
            // 
            this.VS_START_ALL.BackColor = System.Drawing.Color.Red;
            this.VS_START_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_START_ALL.Location = new System.Drawing.Point(77, 3);
            this.VS_START_ALL.Name = "VS_START_ALL";
            this.VS_START_ALL.Size = new System.Drawing.Size(68, 42);
            this.VS_START_ALL.TabIndex = 0;
            this.VS_START_ALL.Text = "VS_START_ALL";
            this.VS_START_ALL.UseVisualStyleBackColor = false;
            this.VS_START_ALL.Click += new System.EventHandler(this.VS_START_ALL_Click);
            // 
            // VS_STOP
            // 
            this.VS_STOP.BackColor = System.Drawing.Color.Red;
            this.VS_STOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP.ForeColor = System.Drawing.Color.White;
            this.VS_STOP.Location = new System.Drawing.Point(151, 3);
            this.VS_STOP.Name = "VS_STOP";
            this.VS_STOP.Size = new System.Drawing.Size(68, 42);
            this.VS_STOP.TabIndex = 0;
            this.VS_STOP.Text = "VS_STOP";
            this.VS_STOP.UseVisualStyleBackColor = false;
            this.VS_STOP.Click += new System.EventHandler(this.VS_STOP_Click);
            // 
            // VS_START_CONNECT
            // 
            this.VS_START_CONNECT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VS_START_CONNECT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_CONNECT.ForeColor = System.Drawing.Color.White;
            this.VS_START_CONNECT.Location = new System.Drawing.Point(3, 51);
            this.VS_START_CONNECT.Name = "VS_START_CONNECT";
            this.VS_START_CONNECT.Size = new System.Drawing.Size(68, 42);
            this.VS_START_CONNECT.TabIndex = 0;
            this.VS_START_CONNECT.Text = "VS_START_CONNECT";
            this.VS_START_CONNECT.UseVisualStyleBackColor = false;
            this.VS_START_CONNECT.Click += new System.EventHandler(this.VS_START_CONNECT_Click);
            // 
            // VS_START_CONNECT_ALL
            // 
            this.VS_START_CONNECT_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VS_START_CONNECT_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_CONNECT_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_START_CONNECT_ALL.Location = new System.Drawing.Point(77, 51);
            this.VS_START_CONNECT_ALL.Name = "VS_START_CONNECT_ALL";
            this.VS_START_CONNECT_ALL.Size = new System.Drawing.Size(68, 42);
            this.VS_START_CONNECT_ALL.TabIndex = 0;
            this.VS_START_CONNECT_ALL.Text = "VS_START_CONNECT_ALL";
            this.VS_START_CONNECT_ALL.UseVisualStyleBackColor = false;
            this.VS_START_CONNECT_ALL.Click += new System.EventHandler(this.VS_START_CONNECT_ALL_Click);
            // 
            // VS_STOP_CONNECT
            // 
            this.VS_STOP_CONNECT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VS_STOP_CONNECT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_CONNECT.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_CONNECT.Location = new System.Drawing.Point(151, 51);
            this.VS_STOP_CONNECT.Name = "VS_STOP_CONNECT";
            this.VS_STOP_CONNECT.Size = new System.Drawing.Size(68, 42);
            this.VS_STOP_CONNECT.TabIndex = 0;
            this.VS_STOP_CONNECT.Text = "VS_STOP_CONNECT";
            this.VS_STOP_CONNECT.UseVisualStyleBackColor = false;
            this.VS_STOP_CONNECT.Click += new System.EventHandler(this.VS_STOP_CONNECT_Click);
            // 
            // VS_STOP_ALL
            // 
            this.VS_STOP_ALL.BackColor = System.Drawing.Color.Red;
            this.VS_STOP_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_ALL.Location = new System.Drawing.Point(225, 3);
            this.VS_STOP_ALL.Name = "VS_STOP_ALL";
            this.VS_STOP_ALL.Size = new System.Drawing.Size(71, 42);
            this.VS_STOP_ALL.TabIndex = 0;
            this.VS_STOP_ALL.Text = "VS_STOP_ALL";
            this.VS_STOP_ALL.UseVisualStyleBackColor = false;
            this.VS_STOP_ALL.Click += new System.EventHandler(this.VS_STOP_ALL_Click);
            // 
            // VS_STOP_CONNECT_ALL
            // 
            this.VS_STOP_CONNECT_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VS_STOP_CONNECT_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_CONNECT_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_CONNECT_ALL.Location = new System.Drawing.Point(225, 51);
            this.VS_STOP_CONNECT_ALL.Name = "VS_STOP_CONNECT_ALL";
            this.VS_STOP_CONNECT_ALL.Size = new System.Drawing.Size(71, 42);
            this.VS_STOP_CONNECT_ALL.TabIndex = 0;
            this.VS_STOP_CONNECT_ALL.Text = "VS_STOP_CONNECT_ALL";
            this.VS_STOP_CONNECT_ALL.UseVisualStyleBackColor = false;
            this.VS_STOP_CONNECT_ALL.Click += new System.EventHandler(this.VS_STOP_CONNECT_ALL_Click);
            // 
            // VS_START_ANALYSE
            // 
            this.VS_START_ANALYSE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.VS_START_ANALYSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_ANALYSE.ForeColor = System.Drawing.Color.White;
            this.VS_START_ANALYSE.Location = new System.Drawing.Point(3, 99);
            this.VS_START_ANALYSE.Name = "VS_START_ANALYSE";
            this.VS_START_ANALYSE.Size = new System.Drawing.Size(68, 42);
            this.VS_START_ANALYSE.TabIndex = 0;
            this.VS_START_ANALYSE.Text = "VS_START_ANALYSE";
            this.VS_START_ANALYSE.UseVisualStyleBackColor = false;
            this.VS_START_ANALYSE.Click += new System.EventHandler(this.VS_START_ANALYSE_Click);
            // 
            // VS_START_ANALYSE_ALL
            // 
            this.VS_START_ANALYSE_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.VS_START_ANALYSE_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_ANALYSE_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_START_ANALYSE_ALL.Location = new System.Drawing.Point(77, 99);
            this.VS_START_ANALYSE_ALL.Name = "VS_START_ANALYSE_ALL";
            this.VS_START_ANALYSE_ALL.Size = new System.Drawing.Size(68, 42);
            this.VS_START_ANALYSE_ALL.TabIndex = 0;
            this.VS_START_ANALYSE_ALL.Text = "VS_START_ANALYSE_ALL";
            this.VS_START_ANALYSE_ALL.UseVisualStyleBackColor = false;
            this.VS_START_ANALYSE_ALL.Click += new System.EventHandler(this.VS_START_ANALYSE_ALL_Click);
            // 
            // VS_STOP_ANALYSE
            // 
            this.VS_STOP_ANALYSE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.VS_STOP_ANALYSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_ANALYSE.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_ANALYSE.Location = new System.Drawing.Point(151, 99);
            this.VS_STOP_ANALYSE.Name = "VS_STOP_ANALYSE";
            this.VS_STOP_ANALYSE.Size = new System.Drawing.Size(68, 42);
            this.VS_STOP_ANALYSE.TabIndex = 0;
            this.VS_STOP_ANALYSE.Text = "VS_STOP_ANALYSE";
            this.VS_STOP_ANALYSE.UseVisualStyleBackColor = false;
            this.VS_STOP_ANALYSE.Click += new System.EventHandler(this.VS_STOP_ANALYSE_Click);
            // 
            // VS_STOP_ANALYSE_ALL
            // 
            this.VS_STOP_ANALYSE_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.VS_STOP_ANALYSE_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_ANALYSE_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_ANALYSE_ALL.Location = new System.Drawing.Point(225, 99);
            this.VS_STOP_ANALYSE_ALL.Name = "VS_STOP_ANALYSE_ALL";
            this.VS_STOP_ANALYSE_ALL.Size = new System.Drawing.Size(71, 42);
            this.VS_STOP_ANALYSE_ALL.TabIndex = 0;
            this.VS_STOP_ANALYSE_ALL.Text = "VS_STOP_ANALYSE_ALL";
            this.VS_STOP_ANALYSE_ALL.UseVisualStyleBackColor = false;
            this.VS_STOP_ANALYSE_ALL.Click += new System.EventHandler(this.VS_STOP_ANALYSE_ALL_Click);
            // 
            // VS_START_EVENT_ALERT
            // 
            this.VS_START_EVENT_ALERT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_START_EVENT_ALERT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_EVENT_ALERT.ForeColor = System.Drawing.Color.White;
            this.VS_START_EVENT_ALERT.Location = new System.Drawing.Point(3, 147);
            this.VS_START_EVENT_ALERT.Name = "VS_START_EVENT_ALERT";
            this.VS_START_EVENT_ALERT.Size = new System.Drawing.Size(68, 42);
            this.VS_START_EVENT_ALERT.TabIndex = 0;
            this.VS_START_EVENT_ALERT.Text = "VS_START_EVENT_ALERT";
            this.VS_START_EVENT_ALERT.UseVisualStyleBackColor = false;
            this.VS_START_EVENT_ALERT.Click += new System.EventHandler(this.VS_START_EVENT_ALERT_Click);
            // 
            // VS_START_EVENT_ALERT_ALL
            // 
            this.VS_START_EVENT_ALERT_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_START_EVENT_ALERT_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_EVENT_ALERT_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_START_EVENT_ALERT_ALL.Location = new System.Drawing.Point(77, 147);
            this.VS_START_EVENT_ALERT_ALL.Name = "VS_START_EVENT_ALERT_ALL";
            this.VS_START_EVENT_ALERT_ALL.Size = new System.Drawing.Size(68, 42);
            this.VS_START_EVENT_ALERT_ALL.TabIndex = 0;
            this.VS_START_EVENT_ALERT_ALL.Text = "VS_START_EVENT_ALERT_ALL";
            this.VS_START_EVENT_ALERT_ALL.UseVisualStyleBackColor = false;
            this.VS_START_EVENT_ALERT_ALL.Click += new System.EventHandler(this.VS_START_EVENT_ALERT_ALL_Click);
            // 
            // VS_STOP_EVENT_ALERT
            // 
            this.VS_STOP_EVENT_ALERT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_STOP_EVENT_ALERT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_EVENT_ALERT.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_EVENT_ALERT.Location = new System.Drawing.Point(151, 147);
            this.VS_STOP_EVENT_ALERT.Name = "VS_STOP_EVENT_ALERT";
            this.VS_STOP_EVENT_ALERT.Size = new System.Drawing.Size(68, 42);
            this.VS_STOP_EVENT_ALERT.TabIndex = 0;
            this.VS_STOP_EVENT_ALERT.Text = "VS_STOP_EVENT_ALERT";
            this.VS_STOP_EVENT_ALERT.UseVisualStyleBackColor = false;
            this.VS_STOP_EVENT_ALERT.Click += new System.EventHandler(this.VS_STOP_EVENT_ALERT_Click);
            // 
            // VS_STOP_EVENT_ALERT_ALL
            // 
            this.VS_STOP_EVENT_ALERT_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_STOP_EVENT_ALERT_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_EVENT_ALERT_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_EVENT_ALERT_ALL.Location = new System.Drawing.Point(225, 147);
            this.VS_STOP_EVENT_ALERT_ALL.Name = "VS_STOP_EVENT_ALERT_ALL";
            this.VS_STOP_EVENT_ALERT_ALL.Size = new System.Drawing.Size(71, 42);
            this.VS_STOP_EVENT_ALERT_ALL.TabIndex = 0;
            this.VS_STOP_EVENT_ALERT_ALL.Text = "VS_STOP_EVENT_ALERT_ALL";
            this.VS_STOP_EVENT_ALERT_ALL.UseVisualStyleBackColor = false;
            this.VS_STOP_EVENT_ALERT_ALL.Click += new System.EventHandler(this.VS_STOP_EVENT_ALERT_ALL_Click);
            // 
            // VS_START_RECORD
            // 
            this.VS_START_RECORD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_START_RECORD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_RECORD.ForeColor = System.Drawing.Color.White;
            this.VS_START_RECORD.Location = new System.Drawing.Point(3, 195);
            this.VS_START_RECORD.Name = "VS_START_RECORD";
            this.VS_START_RECORD.Size = new System.Drawing.Size(68, 42);
            this.VS_START_RECORD.TabIndex = 0;
            this.VS_START_RECORD.Text = "VS_START_RECORD";
            this.VS_START_RECORD.UseVisualStyleBackColor = false;
            this.VS_START_RECORD.Click += new System.EventHandler(this.VS_START_RECORD_Click);
            // 
            // VS_START_RECORD_ALL
            // 
            this.VS_START_RECORD_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_START_RECORD_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_RECORD_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_START_RECORD_ALL.Location = new System.Drawing.Point(77, 195);
            this.VS_START_RECORD_ALL.Name = "VS_START_RECORD_ALL";
            this.VS_START_RECORD_ALL.Size = new System.Drawing.Size(68, 42);
            this.VS_START_RECORD_ALL.TabIndex = 0;
            this.VS_START_RECORD_ALL.Text = "VS_START_RECORD_ALL";
            this.VS_START_RECORD_ALL.UseVisualStyleBackColor = false;
            this.VS_START_RECORD_ALL.Click += new System.EventHandler(this.VS_START_RECORD_ALL_Click);
            // 
            // VS_STOP_RECORD
            // 
            this.VS_STOP_RECORD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_STOP_RECORD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_RECORD.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_RECORD.Location = new System.Drawing.Point(151, 195);
            this.VS_STOP_RECORD.Name = "VS_STOP_RECORD";
            this.VS_STOP_RECORD.Size = new System.Drawing.Size(68, 42);
            this.VS_STOP_RECORD.TabIndex = 0;
            this.VS_STOP_RECORD.Text = "VS_STOP_RECORD";
            this.VS_STOP_RECORD.UseVisualStyleBackColor = false;
            this.VS_STOP_RECORD.Click += new System.EventHandler(this.VS_STOP_RECORD_Click);
            // 
            // VS_STOP_RECORD_ALL
            // 
            this.VS_STOP_RECORD_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VS_STOP_RECORD_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_RECORD_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_RECORD_ALL.Location = new System.Drawing.Point(225, 195);
            this.VS_STOP_RECORD_ALL.Name = "VS_STOP_RECORD_ALL";
            this.VS_STOP_RECORD_ALL.Size = new System.Drawing.Size(71, 42);
            this.VS_STOP_RECORD_ALL.TabIndex = 0;
            this.VS_STOP_RECORD_ALL.Text = "VS_STOP_RECORD_ALL";
            this.VS_STOP_RECORD_ALL.UseVisualStyleBackColor = false;
            this.VS_STOP_RECORD_ALL.Click += new System.EventHandler(this.VS_STOP_RECORD_ALL_Click);
            // 
            // VS_START_DATA_ALERT
            // 
            this.VS_START_DATA_ALERT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VS_START_DATA_ALERT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_DATA_ALERT.ForeColor = System.Drawing.Color.White;
            this.VS_START_DATA_ALERT.Location = new System.Drawing.Point(3, 243);
            this.VS_START_DATA_ALERT.Name = "VS_START_DATA_ALERT";
            this.VS_START_DATA_ALERT.Size = new System.Drawing.Size(68, 42);
            this.VS_START_DATA_ALERT.TabIndex = 0;
            this.VS_START_DATA_ALERT.Text = "VS_START_DATA_ALERT";
            this.VS_START_DATA_ALERT.UseVisualStyleBackColor = false;
            this.VS_START_DATA_ALERT.Click += new System.EventHandler(this.VS_START_DATA_ALERT_Click);
            // 
            // VS_START_DATA_ALERT_ALL
            // 
            this.VS_START_DATA_ALERT_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VS_START_DATA_ALERT_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_START_DATA_ALERT_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_START_DATA_ALERT_ALL.Location = new System.Drawing.Point(77, 243);
            this.VS_START_DATA_ALERT_ALL.Name = "VS_START_DATA_ALERT_ALL";
            this.VS_START_DATA_ALERT_ALL.Size = new System.Drawing.Size(68, 42);
            this.VS_START_DATA_ALERT_ALL.TabIndex = 0;
            this.VS_START_DATA_ALERT_ALL.Text = "VS_START_DATA_ALERT_ALL";
            this.VS_START_DATA_ALERT_ALL.UseVisualStyleBackColor = false;
            this.VS_START_DATA_ALERT_ALL.Click += new System.EventHandler(this.VS_START_DATA_ALERT_ALL_Click);
            // 
            // VS_STOP_DATA_ALERT
            // 
            this.VS_STOP_DATA_ALERT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VS_STOP_DATA_ALERT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_DATA_ALERT.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_DATA_ALERT.Location = new System.Drawing.Point(151, 243);
            this.VS_STOP_DATA_ALERT.Name = "VS_STOP_DATA_ALERT";
            this.VS_STOP_DATA_ALERT.Size = new System.Drawing.Size(68, 42);
            this.VS_STOP_DATA_ALERT.TabIndex = 0;
            this.VS_STOP_DATA_ALERT.Text = "VS_STOP_DATA_ALERT";
            this.VS_STOP_DATA_ALERT.UseVisualStyleBackColor = false;
            this.VS_STOP_DATA_ALERT.Click += new System.EventHandler(this.VS_STOP_DATA_ALERT_Click);
            // 
            // VS_STOP_DATA_ALERT_ALL
            // 
            this.VS_STOP_DATA_ALERT_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VS_STOP_DATA_ALERT_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_STOP_DATA_ALERT_ALL.ForeColor = System.Drawing.Color.White;
            this.VS_STOP_DATA_ALERT_ALL.Location = new System.Drawing.Point(225, 243);
            this.VS_STOP_DATA_ALERT_ALL.Name = "VS_STOP_DATA_ALERT_ALL";
            this.VS_STOP_DATA_ALERT_ALL.Size = new System.Drawing.Size(71, 42);
            this.VS_STOP_DATA_ALERT_ALL.TabIndex = 0;
            this.VS_STOP_DATA_ALERT_ALL.Text = "VS_STOP_DATA_ALERT_ALL";
            this.VS_STOP_DATA_ALERT_ALL.UseVisualStyleBackColor = false;
            this.VS_STOP_DATA_ALERT_ALL.Click += new System.EventHandler(this.VS_STOP_DATA_ALERT_ALL_Click);
            // 
            // VS_LIST_CAMERAS
            // 
            this.VS_LIST_CAMERAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERAS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERAS.Location = new System.Drawing.Point(3, 291);
            this.VS_LIST_CAMERAS.Name = "VS_LIST_CAMERAS";
            this.VS_LIST_CAMERAS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERAS.TabIndex = 0;
            this.VS_LIST_CAMERAS.Text = "VS_LIST_CAMERAS";
            this.VS_LIST_CAMERAS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERAS.Click += new System.EventHandler(this.VS_LIST_CAMERAS_Click);
            // 
            // VS_LIST_CAMERAS_CONNECT_STATUS
            // 
            this.VS_LIST_CAMERAS_CONNECT_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERAS_CONNECT_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERAS_CONNECT_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERAS_CONNECT_STATUS.Location = new System.Drawing.Point(77, 291);
            this.VS_LIST_CAMERAS_CONNECT_STATUS.Name = "VS_LIST_CAMERAS_CONNECT_STATUS";
            this.VS_LIST_CAMERAS_CONNECT_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERAS_CONNECT_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERAS_CONNECT_STATUS.Text = "VS_LIST_CAMERAS_CONNECT_STATUS";
            this.VS_LIST_CAMERAS_CONNECT_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERAS_CONNECT_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERAS_CONNECT_STATUS_Click);
            // 
            // VS_LIST_CAMERAS_ANALYSE_STATUS
            // 
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.Location = new System.Drawing.Point(3, 339);
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.Name = "VS_LIST_CAMERAS_ANALYSE_STATUS";
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.Text = "VS_LIST_CAMERAS_ANALYSE_STATUS";
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERAS_ANALYSE_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERAS_ANALYSE_STATUS_Click);
            // 
            // VS_LIST_CAMERAS_EVENT_ALERT_STATUS
            // 
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.Location = new System.Drawing.Point(77, 339);
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.Name = "VS_LIST_CAMERAS_EVENT_ALERT_STATUS";
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.Text = "VS_LIST_CAMERAS_EVENT_ALERT_STATUS";
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERAS_EVENT_ALERT_STATUS_Click);
            // 
            // VS_LIST_CAMERAS_RECORD_STATUS
            // 
            this.VS_LIST_CAMERAS_RECORD_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERAS_RECORD_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERAS_RECORD_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERAS_RECORD_STATUS.Location = new System.Drawing.Point(151, 339);
            this.VS_LIST_CAMERAS_RECORD_STATUS.Name = "VS_LIST_CAMERAS_RECORD_STATUS";
            this.VS_LIST_CAMERAS_RECORD_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERAS_RECORD_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERAS_RECORD_STATUS.Text = "VS_LIST_CAMERAS_RECORD_STATUS";
            this.VS_LIST_CAMERAS_RECORD_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERAS_RECORD_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERAS_RECORD_STATUS_Click);
            // 
            // VS_LIST_CAMERAS_DATA_ALERT_STATUS
            // 
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.Location = new System.Drawing.Point(225, 339);
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.Name = "VS_LIST_CAMERAS_DATA_ALERT_STATUS";
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.Size = new System.Drawing.Size(71, 42);
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.Text = "VS_LIST_CAMERAS_DATA_ALERT_STATUS";
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERAS_DATA_ALERT_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERAS_DATA_ALERT_STATUS_Click);
            // 
            // VS_LIST_CAMERA_ANALYSE_STATUS
            // 
            this.VS_LIST_CAMERA_ANALYSE_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERA_ANALYSE_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERA_ANALYSE_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERA_ANALYSE_STATUS.Location = new System.Drawing.Point(3, 435);
            this.VS_LIST_CAMERA_ANALYSE_STATUS.Name = "VS_LIST_CAMERA_ANALYSE_STATUS";
            this.VS_LIST_CAMERA_ANALYSE_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERA_ANALYSE_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERA_ANALYSE_STATUS.Text = "VS_LIST_CAMERA_ANALYSE_STATUS";
            this.VS_LIST_CAMERA_ANALYSE_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERA_ANALYSE_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERA_ANALYSE_STATUS_Click);
            // 
            // VS_LIST_CAMERA_EVENT_ALERT_STATUS
            // 
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.Location = new System.Drawing.Point(77, 435);
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.Name = "VS_LIST_CAMERA_EVENT_ALERT_STATUS";
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.Text = "VS_LIST_CAMERA_EVENT_ALERT_STATUS";
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERA_EVENT_ALERT_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERA_EVENT_ALERT_STATUS_Click);
            // 
            // VS_LIST_CAMERA_RECORD_STATUS
            // 
            this.VS_LIST_CAMERA_RECORD_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERA_RECORD_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERA_RECORD_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERA_RECORD_STATUS.Location = new System.Drawing.Point(151, 435);
            this.VS_LIST_CAMERA_RECORD_STATUS.Name = "VS_LIST_CAMERA_RECORD_STATUS";
            this.VS_LIST_CAMERA_RECORD_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERA_RECORD_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERA_RECORD_STATUS.Text = "VS_LIST_CAMERA_RECORD_STATUS";
            this.VS_LIST_CAMERA_RECORD_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERA_RECORD_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERA_RECORD_STATUS_Click);
            // 
            // VS_LIST_CAMERA_DATA_ALERT_STATUS
            // 
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.Location = new System.Drawing.Point(225, 435);
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.Name = "VS_LIST_CAMERA_DATA_ALERT_STATUS";
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.Size = new System.Drawing.Size(71, 42);
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.Text = "VS_LIST_CAMERA_DATA_ALERT_STATUS";
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERA_DATA_ALERT_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERA_DATA_ALERT_STATUS_Click);
            // 
            // VS_LIST_CAMERA_CONNECT_STATUS
            // 
            this.VS_LIST_CAMERA_CONNECT_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VS_LIST_CAMERA_CONNECT_STATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_LIST_CAMERA_CONNECT_STATUS.ForeColor = System.Drawing.Color.White;
            this.VS_LIST_CAMERA_CONNECT_STATUS.Location = new System.Drawing.Point(77, 387);
            this.VS_LIST_CAMERA_CONNECT_STATUS.Name = "VS_LIST_CAMERA_CONNECT_STATUS";
            this.VS_LIST_CAMERA_CONNECT_STATUS.Size = new System.Drawing.Size(68, 42);
            this.VS_LIST_CAMERA_CONNECT_STATUS.TabIndex = 0;
            this.VS_LIST_CAMERA_CONNECT_STATUS.Text = "VS_LIST_CAMERA_CONNECT_STATUS";
            this.VS_LIST_CAMERA_CONNECT_STATUS.UseVisualStyleBackColor = false;
            this.VS_LIST_CAMERA_CONNECT_STATUS.Click += new System.EventHandler(this.VS_LIST_CAMERA_CONNECT_STATUS_Click);
            // 
            // VS_INFO
            // 
            this.VS_INFO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VS_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VS_INFO.ForeColor = System.Drawing.Color.White;
            this.VS_INFO.Location = new System.Drawing.Point(3, 483);
            this.VS_INFO.Name = "VS_INFO";
            this.VS_INFO.Size = new System.Drawing.Size(68, 50);
            this.VS_INFO.TabIndex = 0;
            this.VS_INFO.Text = "VS_INFO";
            this.VS_INFO.UseVisualStyleBackColor = false;
            this.VS_INFO.Click += new System.EventHandler(this.VS_INFO_Click);
            // 
            // button36
            // 
            this.button36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button36.Location = new System.Drawing.Point(77, 483);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(68, 50);
            this.button36.TabIndex = 0;
            this.button36.Text = "\\";
            this.button36.UseVisualStyleBackColor = true;
            // 
            // button37
            // 
            this.button37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button37.Location = new System.Drawing.Point(151, 483);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(68, 50);
            this.button37.TabIndex = 0;
            this.button37.Text = "\\";
            this.button37.UseVisualStyleBackColor = true;
            // 
            // button38
            // 
            this.button38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button38.Location = new System.Drawing.Point(225, 483);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(71, 50);
            this.button38.TabIndex = 0;
            this.button38.Text = "\\";
            this.button38.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 536);
            this.panel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.ForeColor = System.Drawing.Color.Lime;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(705, 533);
            this.listBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1022, 480);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VsAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button VS_START;
        private System.Windows.Forms.Button VS_START_ALL;
        private System.Windows.Forms.Button VS_STOP;
        private System.Windows.Forms.Button VS_START_CONNECT;
        private System.Windows.Forms.Button VS_START_CONNECT_ALL;
        private System.Windows.Forms.Button VS_STOP_CONNECT;
        private System.Windows.Forms.Button VS_STOP_CONNECT_ALL;
        private System.Windows.Forms.Button VS_START_ANALYSE;
        private System.Windows.Forms.Button VS_START_ANALYSE_ALL;
        private System.Windows.Forms.Button VS_STOP_ANALYSE;
        private System.Windows.Forms.Button VS_STOP_ANALYSE_ALL;
        private System.Windows.Forms.Button VS_START_EVENT_ALERT;
        private System.Windows.Forms.Button VS_START_EVENT_ALERT_ALL;
        private System.Windows.Forms.Button VS_STOP_EVENT_ALERT;
        private System.Windows.Forms.Button VS_STOP_EVENT_ALERT_ALL;
        private System.Windows.Forms.Button VS_START_RECORD;
        private System.Windows.Forms.Button VS_START_RECORD_ALL;
        private System.Windows.Forms.Button VS_STOP_RECORD;
        private System.Windows.Forms.Button VS_STOP_RECORD_ALL;
        private System.Windows.Forms.Button VS_START_DATA_ALERT;
        private System.Windows.Forms.Button VS_START_DATA_ALERT_ALL;
        private System.Windows.Forms.Button VS_STOP_DATA_ALERT;
        private System.Windows.Forms.Button VS_STOP_DATA_ALERT_ALL;
        private System.Windows.Forms.Button VS_LIST_CAMERAS;
        private System.Windows.Forms.Button VS_LIST_CAMERAS_CONNECT_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERAS_ANALYSE_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERAS_EVENT_ALERT_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERAS_RECORD_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERAS_DATA_ALERT_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERA_CONNECT_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERA_ANALYSE_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERA_EVENT_ALERT_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERA_RECORD_STATUS;
        private System.Windows.Forms.Button VS_LIST_CAMERA_DATA_ALERT_STATUS;
        private System.Windows.Forms.Button VS_INFO;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Button VS_STOP_ALL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;

    }
}

