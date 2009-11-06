// coub	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qqlg	
// hnhm	 By downloading, copying, installing or using the software you agree to this license.
// tgsg	 If you do not agree to this license, do not download, install,
// kghz	 copy or use the software.
// pnqt	
// kuyx	                          License Agreement
// lujn	         For OpenVss - Open Source Video Surveillance System
// ljrg	
// vano	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// uhap	
// dvyk	Third party copyrights are property of their respective owners.
// fgog	
// gfqo	Redistribution and use in source and binary forms, with or without modification,
// ybrw	are permitted provided that the following conditions are met:
// sovn	
// euaj	  * Redistribution's of source code must retain the above copyright notice,
// plkj	    this list of conditions and the following disclaimer.
// tsfh	
// napo	  * Redistribution's in binary form must reproduce the above copyright notice,
// vosf	    this list of conditions and the following disclaimer in the documentation
// gdgg	    and/or other materials provided with the distribution.
// tdhu	
// jqwg	  * Neither the name of the copyright holders nor the names of its contributors 
// mmli	    may not be used to endorse or promote products derived from this software 
// uout	    without specific prior written permission.
// venn	
// ziby	This software is provided by the copyright holders and contributors "as is" and
// lcad	any express or implied warranties, including, but not limited to, the implied
// vpha	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ouql	In no event shall the Prince of Songkla University or contributors be liable 
// dqac	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wzua	(including, but not limited to, procurement of substitute goods or services;
// ogtg	loss of use, data, or profits; or business interruption) however caused
// tzjb	and on any theory of liability, whether in contract, strict liability,
// qshk	or tort (including negligence or otherwise) arising in any way out of
// bjig	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Monitor
{
    partial class VsLiveviewTool
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
            this.components = new System.ComponentModel.Container();
            this.vsSettingTool = new Vs.Monitor.VsGeneralSetting();
            this.vsSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vsTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vsMultiViewer1 = new Vs.Monitor.VsMultiViewer(this.components);
            this.vsSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.vsTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.vsApplicationControl1 = new Vs.Monitor.VsTreeviewControl();
            this.vsTableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.vsPropertyControl1 = new Vs.Monitor.VsPropertyControl();
            this.vsSplitContainer1.Panel1.SuspendLayout();
            this.vsSplitContainer1.Panel2.SuspendLayout();
            this.vsSplitContainer1.SuspendLayout();
            this.vsTableLayoutPanel1.SuspendLayout();
            this.vsSplitContainer2.Panel1.SuspendLayout();
            this.vsSplitContainer2.Panel2.SuspendLayout();
            this.vsSplitContainer2.SuspendLayout();
            this.vsTableLayoutPanel2.SuspendLayout();
            this.vsTableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsSettingTool
            // 
            this.vsSettingTool.BackColor = System.Drawing.SystemColors.Control;
            this.vsSettingTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vsSettingTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsSettingTool.ForeColor = System.Drawing.SystemColors.Desktop;
            this.vsSettingTool.Location = new System.Drawing.Point(0, 0);
            this.vsSettingTool.Name = "vsSettingTool";
            this.vsSettingTool.Size = new System.Drawing.Size(324, 244);
            this.vsSettingTool.TabIndex = 2;
            // 
            // vsSplitContainer1
            // 
            this.vsSplitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.vsSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsSplitContainer1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.vsSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.vsSplitContainer1.Name = "vsSplitContainer1";
            // 
            // vsSplitContainer1.Panel1
            // 
            this.vsSplitContainer1.Panel1.Controls.Add(this.vsTableLayoutPanel1);
            this.vsSplitContainer1.Panel1.Controls.Add(this.vsSettingTool);
            this.vsSplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // vsSplitContainer1.Panel2
            // 
            this.vsSplitContainer1.Panel2.Controls.Add(this.vsSplitContainer2);
            this.vsSplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vsSplitContainer1.Size = new System.Drawing.Size(505, 244);
            this.vsSplitContainer1.SplitterDistance = 324;
            this.vsSplitContainer1.TabIndex = 1;
            // 
            // vsTableLayoutPanel1
            // 
            this.vsTableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.vsTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.vsTableLayoutPanel1.ColumnCount = 1;
            this.vsTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.vsTableLayoutPanel1.Controls.Add(this.vsMultiViewer1, 0, 0);
            this.vsTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.vsTableLayoutPanel1.Name = "vsTableLayoutPanel1";
            this.vsTableLayoutPanel1.RowCount = 1;
            this.vsTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vsTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.vsTableLayoutPanel1.Size = new System.Drawing.Size(324, 244);
            this.vsTableLayoutPanel1.TabIndex = 1;
            // 
            // vsMultiViewer1
            // 
            this.vsMultiViewer1.AllowDrop = true;
            this.vsMultiViewer1.AutoScroll = true;
            this.vsMultiViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.vsMultiViewer1.Location = new System.Drawing.Point(2, 2);
            this.vsMultiViewer1.Margin = new System.Windows.Forms.Padding(1);
            this.vsMultiViewer1.Name = "vsMultiViewer1";
            this.vsMultiViewer1.Size = new System.Drawing.Size(320, 240);
            this.vsMultiViewer1.TabIndex = 2;
            // 
            // vsSplitContainer2
            // 
            this.vsSplitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.vsSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.vsSplitContainer2.Name = "vsSplitContainer2";
            this.vsSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // vsSplitContainer2.Panel1
            // 
            this.vsSplitContainer2.Panel1.Controls.Add(this.vsTableLayoutPanel2);
            this.vsSplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // vsSplitContainer2.Panel2
            // 
            this.vsSplitContainer2.Panel2.Controls.Add(this.vsTableLayoutPanel3);
            this.vsSplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vsSplitContainer2.Size = new System.Drawing.Size(177, 244);
            this.vsSplitContainer2.SplitterDistance = 127;
            this.vsSplitContainer2.TabIndex = 0;
            // 
            // vsTableLayoutPanel2
            // 
            this.vsTableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.vsTableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.vsTableLayoutPanel2.ColumnCount = 1;
            this.vsTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vsTableLayoutPanel2.Controls.Add(this.vsApplicationControl1, 0, 0);
            this.vsTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsTableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.vsTableLayoutPanel2.Name = "vsTableLayoutPanel2";
            this.vsTableLayoutPanel2.RowCount = 1;
            this.vsTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vsTableLayoutPanel2.Size = new System.Drawing.Size(177, 127);
            this.vsTableLayoutPanel2.TabIndex = 0;
            // 
            // vsApplicationControl1
            // 
            this.vsApplicationControl1.AllowDrop = true;
            this.vsApplicationControl1.BackColor = System.Drawing.SystemColors.Control;
            this.vsApplicationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsApplicationControl1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.vsApplicationControl1.Location = new System.Drawing.Point(4, 4);
            this.vsApplicationControl1.Name = "vsApplicationControl1";
            this.vsApplicationControl1.Size = new System.Drawing.Size(169, 119);
            this.vsApplicationControl1.TabIndex = 0;
            // 
            // vsTableLayoutPanel3
            // 
            this.vsTableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.vsTableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.vsTableLayoutPanel3.ColumnCount = 1;
            this.vsTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vsTableLayoutPanel3.Controls.Add(this.vsPropertyControl1, 0, 0);
            this.vsTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.vsTableLayoutPanel3.Name = "vsTableLayoutPanel3";
            this.vsTableLayoutPanel3.RowCount = 1;
            this.vsTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vsTableLayoutPanel3.Size = new System.Drawing.Size(177, 113);
            this.vsTableLayoutPanel3.TabIndex = 0;
            // 
            // vsPropertyControl1
            // 
            this.vsPropertyControl1.BackColor = System.Drawing.SystemColors.Control;
            this.vsPropertyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsPropertyControl1.Enabled = false;
            this.vsPropertyControl1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.vsPropertyControl1.Location = new System.Drawing.Point(4, 4);
            this.vsPropertyControl1.Name = "vsPropertyControl1";
            this.vsPropertyControl1.Size = new System.Drawing.Size(169, 105);
            this.vsPropertyControl1.TabIndex = 0;
            // 
            // VsLiveviewTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.vsSplitContainer1);
            this.Name = "VsLiveviewTool";
            this.Size = new System.Drawing.Size(505, 244);
            this.vsSplitContainer1.Panel1.ResumeLayout(false);
            this.vsSplitContainer1.Panel2.ResumeLayout(false);
            this.vsSplitContainer1.ResumeLayout(false);
            this.vsTableLayoutPanel1.ResumeLayout(false);
            this.vsSplitContainer2.Panel1.ResumeLayout(false);
            this.vsSplitContainer2.Panel2.ResumeLayout(false);
            this.vsSplitContainer2.ResumeLayout(false);
            this.vsTableLayoutPanel2.ResumeLayout(false);
            this.vsTableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer vsSplitContainer1;
        private System.Windows.Forms.TableLayoutPanel vsTableLayoutPanel1;
        private VsMultiViewer vsMultiViewer1;
        private System.Windows.Forms.SplitContainer vsSplitContainer2;
        private System.Windows.Forms.TableLayoutPanel vsTableLayoutPanel2;
        private VsTreeviewControl vsApplicationControl1;
        private System.Windows.Forms.TableLayoutPanel vsTableLayoutPanel3;
        private VsPropertyControl vsPropertyControl1;
        private VsGeneralSetting vsSettingTool;
    }
}
