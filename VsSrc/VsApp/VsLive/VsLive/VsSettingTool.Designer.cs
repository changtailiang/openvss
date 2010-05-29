// mwxw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// swau	
// wlza	 By downloading, copying, installing or using the software you agree to this license.
// tlnr	 If you do not agree to this license, do not download, install,
// xwmm	 copy or use the software.
// xevp	
// qexd	                          License Agreement
// yinz	         For OpenVSS - Open Source Video Surveillance System
// uepz	
// szkc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pfoz	
// mklw	Third party copyrights are property of their respective owners.
// zmmu	
// crxi	Redistribution and use in source and binary forms, with or without modification,
// bhgo	are permitted provided that the following conditions are met:
// yxvo	
// yzgp	  * Redistribution's of source code must retain the above copyright notice,
// woyx	    this list of conditions and the following disclaimer.
// lkws	
// pwdf	  * Redistribution's in binary form must reproduce the above copyright notice,
// tbdl	    this list of conditions and the following disclaimer in the documentation
// vsxd	    and/or other materials provided with the distribution.
// ggxk	
// twds	  * Neither the name of the copyright holders nor the names of its contributors 
// jzbm	    may not be used to endorse or promote products derived from this software 
// eval	    without specific prior written permission.
// opjr	
// ufsf	This software is provided by the copyright holders and contributors "as is" and
// eaux	any express or implied warranties, including, but not limited to, the implied
// tktf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cdip	In no event shall the Prince of Songkla University or contributors be liable 
// qndo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// heiq	(including, but not limited to, procurement of substitute goods or services;
// uqbx	loss of use, data, or profits; or business interruption) however caused
// brxf	and on any theory of liability, whether in contract, strict liability,
// jfia	or tort (including negligence or otherwise) arising in any way out of
// osft	the use of this software, even if advised of the possibility of such damage.
// bfyz	
// gvka	Intelligent Systems Laboratory (iSys Lab)
// nkva	Faculty of Engineering, Prince of Songkla University, THAILAND
// lujq	Project leader by Nikom SUVONVORN
// wcko	Project website at http://code.google.com/p/openvss/

namespace Vs.Monitor
{
    partial class VsSettingTool
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGeneral = new System.Windows.Forms.Button();
            this.buttonRecording = new System.Windows.Forms.Button();
            this.vsRecordSetting1 = new Vs.Monitor.VsRecordSetting();
            this.vsGeneralSetting1 = new Vs.Monitor.VsGeneralSetting();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vsRecordSetting1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.vsGeneralSetting1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 354);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonGeneral, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRecording, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(116, 345);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonGeneral
            // 
            this.buttonGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonGeneral.Location = new System.Drawing.Point(4, 4);
            this.buttonGeneral.Name = "buttonGeneral";
            this.buttonGeneral.Size = new System.Drawing.Size(108, 44);
            this.buttonGeneral.TabIndex = 0;
            this.buttonGeneral.Text = "General";
            this.buttonGeneral.UseVisualStyleBackColor = false;
            this.buttonGeneral.Click += new System.EventHandler(this.buttonGeneral_Click);
            // 
            // buttonRecording
            // 
            this.buttonRecording.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRecording.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecording.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRecording.Location = new System.Drawing.Point(4, 55);
            this.buttonRecording.Name = "buttonRecording";
            this.buttonRecording.Size = new System.Drawing.Size(108, 44);
            this.buttonRecording.TabIndex = 0;
            this.buttonRecording.Text = "Recording";
            this.buttonRecording.UseVisualStyleBackColor = false;
            this.buttonRecording.Click += new System.EventHandler(this.buttonRecording_Click);
            // 
            // vsRecordSetting1
            // 
            this.vsRecordSetting1.BackColor = System.Drawing.SystemColors.Control;
            this.vsRecordSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsRecordSetting1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vsRecordSetting1.Location = new System.Drawing.Point(4, 356);
            this.vsRecordSetting1.Name = "vsRecordSetting1";
            this.vsRecordSetting1.Size = new System.Drawing.Size(116, 1);
            this.vsRecordSetting1.TabIndex = 1;
            // 
            // vsGeneralSetting1
            // 
            this.vsGeneralSetting1.BackColor = System.Drawing.SystemColors.Control;
            this.vsGeneralSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsGeneralSetting1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vsGeneralSetting1.Location = new System.Drawing.Point(127, 4);
            this.vsGeneralSetting1.Name = "vsGeneralSetting1";
            this.vsGeneralSetting1.Size = new System.Drawing.Size(453, 345);
            this.vsGeneralSetting1.TabIndex = 1;
            // 
            // VsSettingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "VsSettingTool";
            this.Size = new System.Drawing.Size(584, 354);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonGeneral;
        private System.Windows.Forms.Button buttonRecording;
        private VsGeneralSetting vsGeneralSetting1;
        private VsRecordSetting vsRecordSetting1;

    }
}
