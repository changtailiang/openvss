// kbfv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// agrl	
// gzul	 By downloading, copying, installing or using the software you agree to this license.
// qtsc	 If you do not agree to this license, do not download, install,
// konl	 copy or use the software.
// vzzp	
// rdie	                          License Agreement
// gzuc	         For OpenVss - Open Source Video Surveillance System
// ulve	
// umcx	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wzih	
// oymm	Third party copyrights are property of their respective owners.
// gcaq	
// qnxl	Redistribution and use in source and binary forms, with or without modification,
// cqdw	are permitted provided that the following conditions are met:
// ymfh	
// erqe	  * Redistribution's of source code must retain the above copyright notice,
// yohy	    this list of conditions and the following disclaimer.
// lqow	
// qrbt	  * Redistribution's in binary form must reproduce the above copyright notice,
// rvxd	    this list of conditions and the following disclaimer in the documentation
// zelg	    and/or other materials provided with the distribution.
// okbe	
// jfyj	  * Neither the name of the copyright holders nor the names of its contributors 
// tbdw	    may not be used to endorse or promote products derived from this software 
// iios	    without specific prior written permission.
// vcea	
// zaul	This software is provided by the copyright holders and contributors "as is" and
// ojfc	any express or implied warranties, including, but not limited to, the implied
// pchz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fjpn	In no event shall the Prince of Songkla University or contributors be liable 
// mcog	for any direct, indirect, incidental, special, exemplary, or consequential damages
// redp	(including, but not limited to, procurement of substitute goods or services;
// nelj	loss of use, data, or profits; or business interruption) however caused
// gfix	and on any theory of liability, whether in contract, strict liability,
// alhn	or tort (including negligence or otherwise) arising in any way out of
// pppz	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Core.SystemInfo
{
    partial class VsSystemInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCpu = new System.Windows.Forms.Label();
            this.labelMemP = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataBarCPU = new Vs.Core.SystemInfo.VsDataBar();
            this.dataChartCPU = new Vs.Core.SystemInfo.VsDataChart();
            this.dataBarMemP = new Vs.Core.SystemInfo.VsDataBar();
            this.dataChartMem = new Vs.Core.SystemInfo.VsDataChart();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "MEM";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "CPU";
            // 
            // labelCpu
            // 
            this.labelCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCpu.Location = new System.Drawing.Point(108, 0);
            this.labelCpu.Name = "labelCpu";
            this.labelCpu.Size = new System.Drawing.Size(77, 15);
            this.labelCpu.TabIndex = 31;
            this.labelCpu.Text = "CPU";
            // 
            // labelMemP
            // 
            this.labelMemP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMemP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelMemP.Location = new System.Drawing.Point(108, 0);
            this.labelMemP.Name = "labelMemP";
            this.labelMemP.Size = new System.Drawing.Size(77, 15);
            this.labelMemP.TabIndex = 42;
            this.labelMemP.Text = "MEM";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(187, 71);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataBarCPU);
            this.panel1.Controls.Add(this.labelCpu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 15);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataChartCPU);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 15);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataBarMemP);
            this.panel3.Controls.Add(this.labelMemP);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 15);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataChartMem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 52);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 18);
            this.panel4.TabIndex = 3;
            // 
            // dataBarCPU
            // 
            this.dataBarCPU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataBarCPU.BackColor = System.Drawing.Color.Silver;
            this.dataBarCPU.BarColor = System.Drawing.Color.Green;
            this.dataBarCPU.Location = new System.Drawing.Point(41, 0);
            this.dataBarCPU.Name = "dataBarCPU";
            this.dataBarCPU.Size = new System.Drawing.Size(62, 15);
            this.dataBarCPU.TabIndex = 35;
            this.dataBarCPU.Value = 0;
            // 
            // dataChartCPU
            // 
            this.dataChartCPU.BackColor = System.Drawing.Color.Silver;
            this.dataChartCPU.ChartType = Vs.Core.SystemInfo.ChartType.Line;
            this.dataChartCPU.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChartCPU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataChartCPU.GridColor = System.Drawing.Color.Yellow;
            this.dataChartCPU.GridPixels = 8;
            this.dataChartCPU.InitialHeight = 100;
            this.dataChartCPU.LineColor = System.Drawing.Color.Green;
            this.dataChartCPU.Location = new System.Drawing.Point(0, 0);
            this.dataChartCPU.Name = "dataChartCPU";
            this.dataChartCPU.Size = new System.Drawing.Size(185, 15);
            this.dataChartCPU.TabIndex = 39;
            // 
            // dataBarMemP
            // 
            this.dataBarMemP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataBarMemP.BackColor = System.Drawing.Color.Silver;
            this.dataBarMemP.BarColor = System.Drawing.Color.SlateBlue;
            this.dataBarMemP.Location = new System.Drawing.Point(41, 0);
            this.dataBarMemP.Name = "dataBarMemP";
            this.dataBarMemP.Size = new System.Drawing.Size(62, 15);
            this.dataBarMemP.TabIndex = 36;
            this.dataBarMemP.Value = 0;
            // 
            // dataChartMem
            // 
            this.dataChartMem.BackColor = System.Drawing.Color.Silver;
            this.dataChartMem.ChartType = Vs.Core.SystemInfo.ChartType.Line;
            this.dataChartMem.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChartMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataChartMem.GridColor = System.Drawing.Color.Gold;
            this.dataChartMem.GridPixels = 12;
            this.dataChartMem.InitialHeight = 100;
            this.dataChartMem.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartMem.Location = new System.Drawing.Point(0, 0);
            this.dataChartMem.Name = "dataChartMem";
            this.dataChartMem.Size = new System.Drawing.Size(185, 18);
            this.dataChartMem.TabIndex = 41;
            // 
            // VsSystemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VsSystemInfo";
            this.Size = new System.Drawing.Size(187, 71);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VsDataChart dataChartMem;
        private VsDataChart dataChartCPU;
        private VsDataBar dataBarMemP;
        private VsDataBar dataBarCPU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCpu;
        private System.Windows.Forms.Label labelMemP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
