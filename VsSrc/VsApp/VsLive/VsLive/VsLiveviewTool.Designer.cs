// xqbu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vtwq	
// kynt	 By downloading, copying, installing or using the software you agree to this license.
// cquk	 If you do not agree to this license, do not download, install,
// ubkw	 copy or use the software.
// pncx	
// xtqk	                          License Agreement
// mwyy	         For OpenVSS - Open Source Video Surveillance System
// kzxi	
// sowl	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// edaa	
// vajy	Third party copyrights are property of their respective owners.
// qqnm	
// rpbj	Redistribution and use in source and binary forms, with or without modification,
// oewb	are permitted provided that the following conditions are met:
// cmdo	
// zojd	  * Redistribution's of source code must retain the above copyright notice,
// tmrf	    this list of conditions and the following disclaimer.
// fzrl	
// mbbx	  * Redistribution's in binary form must reproduce the above copyright notice,
// kstv	    this list of conditions and the following disclaimer in the documentation
// imhu	    and/or other materials provided with the distribution.
// ynuo	
// ruis	  * Neither the name of the copyright holders nor the names of its contributors 
// zmbg	    may not be used to endorse or promote products derived from this software 
// qgfe	    without specific prior written permission.
// zihs	
// ypxn	This software is provided by the copyright holders and contributors "as is" and
// czrk	any express or implied warranties, including, but not limited to, the implied
// shfn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// goeg	In no event shall the Prince of Songkla University or contributors be liable 
// rdnk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qzlz	(including, but not limited to, procurement of substitute goods or services;
// avge	loss of use, data, or profits; or business interruption) however caused
// nowa	and on any theory of liability, whether in contract, strict liability,
// epwi	or tort (including negligence or otherwise) arising in any way out of
// phls	the use of this software, even if advised of the possibility of such damage.
// dxzs	
// hnzc	Intelligent Systems Laboratory (iSys Lab)
// bzmv	Faculty of Engineering, Prince of Songkla University, THAILAND
// uwbz	Project leader by Nikom SUVONVORN
// dxmh	Project website at http://code.google.com/p/openvss/

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
            this.vsSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vsTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vsMultiViewer1 = new Vs.Monitor.VsMultiViewer(this.components);
            this.vsSplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.vsTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.vsApplicationControl1 = new Vs.Monitor.VsTreeviewControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.actionSingleView = new System.Windows.Forms.Button();
            this.actionMultiView = new System.Windows.Forms.Button();
            this.actionMinus = new System.Windows.Forms.Button();
            this.actionPlus = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.vsTableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
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
            this.vsSplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // vsSplitContainer1.Panel2
            // 
            this.vsSplitContainer1.Panel2.Controls.Add(this.vsSplitContainer2);
            this.vsSplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vsSplitContainer1.Size = new System.Drawing.Size(1016, 648);
            this.vsSplitContainer1.SplitterDistance = 830;
            this.vsSplitContainer1.TabIndex = 1;
            // 
            // vsTableLayoutPanel1
            // 
            this.vsTableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.vsTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.vsTableLayoutPanel1.ColumnCount = 1;
            this.vsTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.vsTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.vsTableLayoutPanel1.Controls.Add(this.vsMultiViewer1, 0, 0);
            this.vsTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.vsTableLayoutPanel1.Name = "vsTableLayoutPanel1";
            this.vsTableLayoutPanel1.RowCount = 1;
            this.vsTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vsTableLayoutPanel1.Size = new System.Drawing.Size(830, 648);
            this.vsTableLayoutPanel1.TabIndex = 1;
            // 
            // vsMultiViewer1
            // 
            this.vsMultiViewer1.AllowDrop = true;
            this.vsMultiViewer1.AutoScroll = true;
            this.vsMultiViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.vsMultiViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsMultiViewer1.Location = new System.Drawing.Point(2, 2);
            this.vsMultiViewer1.Margin = new System.Windows.Forms.Padding(1);
            this.vsMultiViewer1.Name = "vsMultiViewer1";
            this.vsMultiViewer1.Size = new System.Drawing.Size(826, 644);
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
            this.vsSplitContainer2.Size = new System.Drawing.Size(182, 648);
            this.vsSplitContainer2.SplitterDistance = 463;
            this.vsSplitContainer2.TabIndex = 0;
            // 
            // vsTableLayoutPanel2
            // 
            this.vsTableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.vsTableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.vsTableLayoutPanel2.ColumnCount = 1;
            this.vsTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vsTableLayoutPanel2.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.vsTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsTableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.vsTableLayoutPanel2.Name = "vsTableLayoutPanel2";
            this.vsTableLayoutPanel2.RowCount = 1;
            this.vsTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vsTableLayoutPanel2.Size = new System.Drawing.Size(182, 463);
            this.vsTableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.vsApplicationControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(180, 461);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // vsApplicationControl1
            // 
            this.vsApplicationControl1.AllowDrop = true;
            this.vsApplicationControl1.BackColor = System.Drawing.SystemColors.Control;
            this.vsApplicationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsApplicationControl1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.vsApplicationControl1.Location = new System.Drawing.Point(0, 123);
            this.vsApplicationControl1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.vsApplicationControl1.Name = "vsApplicationControl1";
            this.vsApplicationControl1.Size = new System.Drawing.Size(180, 338);
            this.vsApplicationControl1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.actionSingleView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionMultiView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionMinus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.actionPlus, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 120);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // actionSingleView
            // 
            this.actionSingleView.BackColor = System.Drawing.SystemColors.Control;
            this.actionSingleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionSingleView.Image = global::Vs.Monitor.Properties.Resources.view_single;
            this.actionSingleView.Location = new System.Drawing.Point(0, 0);
            this.actionSingleView.Margin = new System.Windows.Forms.Padding(0);
            this.actionSingleView.Name = "actionSingleView";
            this.actionSingleView.Size = new System.Drawing.Size(90, 60);
            this.actionSingleView.TabIndex = 0;
            this.actionSingleView.UseVisualStyleBackColor = false;
            this.actionSingleView.Click += new System.EventHandler(this.actionSingleView_Click);
            // 
            // actionMultiView
            // 
            this.actionMultiView.BackColor = System.Drawing.SystemColors.Control;
            this.actionMultiView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionMultiView.Image = global::Vs.Monitor.Properties.Resources.view_multi;
            this.actionMultiView.Location = new System.Drawing.Point(90, 0);
            this.actionMultiView.Margin = new System.Windows.Forms.Padding(0);
            this.actionMultiView.Name = "actionMultiView";
            this.actionMultiView.Size = new System.Drawing.Size(90, 60);
            this.actionMultiView.TabIndex = 0;
            this.actionMultiView.UseVisualStyleBackColor = false;
            this.actionMultiView.Click += new System.EventHandler(this.actionMultiView_Click);
            // 
            // actionMinus
            // 
            this.actionMinus.BackColor = System.Drawing.SystemColors.Control;
            this.actionMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionMinus.Image = global::Vs.Monitor.Properties.Resources.zoom_in;
            this.actionMinus.Location = new System.Drawing.Point(90, 60);
            this.actionMinus.Margin = new System.Windows.Forms.Padding(0);
            this.actionMinus.Name = "actionMinus";
            this.actionMinus.Size = new System.Drawing.Size(90, 60);
            this.actionMinus.TabIndex = 0;
            this.actionMinus.UseVisualStyleBackColor = false;
            this.actionMinus.Click += new System.EventHandler(this.actionMinus_Click);
            // 
            // actionPlus
            // 
            this.actionPlus.BackColor = System.Drawing.SystemColors.Control;
            this.actionPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPlus.Image = global::Vs.Monitor.Properties.Resources.zoom_out;
            this.actionPlus.Location = new System.Drawing.Point(0, 60);
            this.actionPlus.Margin = new System.Windows.Forms.Padding(0);
            this.actionPlus.Name = "actionPlus";
            this.actionPlus.Size = new System.Drawing.Size(90, 60);
            this.actionPlus.TabIndex = 0;
            this.actionPlus.UseVisualStyleBackColor = false;
            this.actionPlus.Click += new System.EventHandler(this.actionPlus_Click);
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
            this.vsTableLayoutPanel3.Size = new System.Drawing.Size(182, 181);
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
            this.vsPropertyControl1.Size = new System.Drawing.Size(174, 173);
            this.vsPropertyControl1.TabIndex = 0;
            // 
            // VsLiveviewTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.vsSplitContainer1);
            this.Name = "VsLiveviewTool";
            this.Size = new System.Drawing.Size(1016, 648);
            this.vsSplitContainer1.Panel1.ResumeLayout(false);
            this.vsSplitContainer1.Panel2.ResumeLayout(false);
            this.vsSplitContainer1.ResumeLayout(false);
            this.vsTableLayoutPanel1.ResumeLayout(false);
            this.vsSplitContainer2.Panel1.ResumeLayout(false);
            this.vsSplitContainer2.Panel2.ResumeLayout(false);
            this.vsSplitContainer2.ResumeLayout(false);
            this.vsTableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.vsTableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer vsSplitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button actionSingleView;
        private System.Windows.Forms.Button actionMultiView;
        private System.Windows.Forms.SplitContainer vsSplitContainer2;
        private System.Windows.Forms.TableLayoutPanel vsTableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel vsTableLayoutPanel3;
        private VsPropertyControl vsPropertyControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
       
        private System.Windows.Forms.TableLayoutPanel vsTableLayoutPanel1;
        
        private System.Windows.Forms.Button actionMinus;
        private System.Windows.Forms.Button actionPlus;


        private VsMultiViewer vsMultiViewer1;
        public VsMultiViewer VsMultiViewer1
        {
            get { return vsMultiViewer1; }
            //set { vsMultiViewer1 = value; }
        }
       
        private VsTreeviewControl vsApplicationControl1;
        public VsTreeviewControl VsApplicationControl1
        {
            get { return vsApplicationControl1; }
           // set { vsApplicationControl1 = value; }
        }
    }
}
