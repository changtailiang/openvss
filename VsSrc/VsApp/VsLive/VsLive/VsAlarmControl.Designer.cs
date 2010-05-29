// bqin	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// naun	
// ezen	 By downloading, copying, installing or using the software you agree to this license.
// xnoc	 If you do not agree to this license, do not download, install,
// lupo	 copy or use the software.
// vugw	
// qjyj	                          License Agreement
// fvcf	         For OpenVSS - Open Source Video Surveillance System
// mxxj	
// slze	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eqmn	
// tayy	Third party copyrights are property of their respective owners.
// beth	
// cqlg	Redistribution and use in source and binary forms, with or without modification,
// klwd	are permitted provided that the following conditions are met:
// blii	
// xybz	  * Redistribution's of source code must retain the above copyright notice,
// pfka	    this list of conditions and the following disclaimer.
// vkkf	
// iscq	  * Redistribution's in binary form must reproduce the above copyright notice,
// kzia	    this list of conditions and the following disclaimer in the documentation
// bvcw	    and/or other materials provided with the distribution.
// mqyh	
// ovdt	  * Neither the name of the copyright holders nor the names of its contributors 
// idqv	    may not be used to endorse or promote products derived from this software 
// zziw	    without specific prior written permission.
// utls	
// ffyr	This software is provided by the copyright holders and contributors "as is" and
// igtb	any express or implied warranties, including, but not limited to, the implied
// dhhb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wfmz	In no event shall the Prince of Songkla University or contributors be liable 
// gcla	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hrwe	(including, but not limited to, procurement of substitute goods or services;
// bhrl	loss of use, data, or profits; or business interruption) however caused
// rlfi	and on any theory of liability, whether in contract, strict liability,
// jkqh	or tort (including negligence or otherwise) arising in any way out of
// shyi	the use of this software, even if advised of the possibility of such damage.
// cbpb	
// wpyt	Intelligent Systems Laboratory (iSys Lab)
// njqr	Faculty of Engineering, Prince of Songkla University, THAILAND
// hlko	Project leader by Nikom SUVONVORN
// itpa	Project website at http://code.google.com/p/openvss/

namespace Vs.Monitor
{
    partial class VsAlarmControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colCamera = new System.Windows.Forms.ColumnHeader();
            this.colAlarm = new System.Windows.Forms.ColumnHeader();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.49223F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.50777F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 79);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlText;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colCamera,
            this.colAlarm});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.Red;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(84, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(685, 73);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 223;
            // 
            // colCamera
            // 
            this.colCamera.Text = "Device";
            this.colCamera.Width = 192;
            // 
            // colAlarm
            // 
            this.colAlarm.Text = "Detail";
            this.colAlarm.Width = 220;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = global::Vs.Monitor.Properties.Resources.isyscolor;
            this.pictureBox1.Image = global::Vs.Monitor.Properties.Resources.isyscolor;
            this.pictureBox1.InitialImage = global::Vs.Monitor.Properties.Resources.isyscolor;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // VsAlarmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VsAlarmControl";
            this.Size = new System.Drawing.Size(772, 79);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colCamera;
        private System.Windows.Forms.ColumnHeader colAlarm;
        private System.Windows.Forms.PictureBox pictureBox1;


    }
}
