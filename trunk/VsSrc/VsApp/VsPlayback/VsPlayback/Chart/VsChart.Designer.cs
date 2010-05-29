// rzpm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tmef	
// porg	 By downloading, copying, installing or using the software you agree to this license.
// zzcg	 If you do not agree to this license, do not download, install,
// iekm	 copy or use the software.
// bcpr	
// vnuv	                          License Agreement
// mnla	         For OpenVSS - Open Source Video Surveillance System
// rwnz	
// jspf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qcvf	
// vqom	Third party copyrights are property of their respective owners.
// vmnh	
// okyo	Redistribution and use in source and binary forms, with or without modification,
// jyqg	are permitted provided that the following conditions are met:
// sjtc	
// drpd	  * Redistribution's of source code must retain the above copyright notice,
// ldxq	    this list of conditions and the following disclaimer.
// pfvz	
// hjwe	  * Redistribution's in binary form must reproduce the above copyright notice,
// zhzz	    this list of conditions and the following disclaimer in the documentation
// zdlh	    and/or other materials provided with the distribution.
// xzpk	
// bimh	  * Neither the name of the copyright holders nor the names of its contributors 
// jtce	    may not be used to endorse or promote products derived from this software 
// bkbs	    without specific prior written permission.
// pxrj	
// ozhz	This software is provided by the copyright holders and contributors "as is" and
// cmhl	any express or implied warranties, including, but not limited to, the implied
// judz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fhgl	In no event shall the Prince of Songkla University or contributors be liable 
// omog	for any direct, indirect, incidental, special, exemplary, or consequential damages
// soqo	(including, but not limited to, procurement of substitute goods or services;
// hrdo	loss of use, data, or profits; or business interruption) however caused
// fhkc	and on any theory of liability, whether in contract, strict liability,
// mcty	or tort (including negligence or otherwise) arising in any way out of
// sphp	the use of this software, even if advised of the possibility of such damage.
// bbxp	
// qdyt	Intelligent Systems Laboratory (iSys Lab)
// epec	Faculty of Engineering, Prince of Songkla University, THAILAND
// ilrz	Project leader by Nikom SUVONVORN
// itsk	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback.Chart
{
    partial class VsChart
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
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.chartPresent1 = new Vs.Playback.VsChartPresent();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonDay = new System.Windows.Forms.RadioButton();
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vsChartPresent1 = new Vs.Playback.VsChartPresent();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.chartPresent1);
            this.splitContainer5.Size = new System.Drawing.Size(150, 100);
            this.splitContainer5.TabIndex = 0;
            // 
            // chartPresent1
            // 
            this.chartPresent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPresent1.Location = new System.Drawing.Point(0, 0);
            this.chartPresent1.Name = "chartPresent1";
            this.chartPresent1.Size = new System.Drawing.Size(150, 50);
            this.chartPresent1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonDay, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonYear, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radioButtonDay
            // 
            this.radioButtonDay.AutoSize = true;
            this.radioButtonDay.Checked = true;
            this.radioButtonDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButtonDay.Location = new System.Drawing.Point(3, 23);
            this.radioButtonDay.Name = "radioButtonDay";
            this.radioButtonDay.Size = new System.Drawing.Size(60, 14);
            this.radioButtonDay.TabIndex = 13;
            this.radioButtonDay.TabStop = true;
            this.radioButtonDay.Text = "?????? (???? 24 ???????)";
            this.radioButtonDay.UseVisualStyleBackColor = true;
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButtonYear.Location = new System.Drawing.Point(135, 23);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(62, 14);
            this.radioButtonYear.TabIndex = 15;
            this.radioButtonYear.TabStop = true;
            this.radioButtonYear.Text = "????? (???? 12 ?????)";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButtonMonth.Location = new System.Drawing.Point(52, 3);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(44, 19);
            this.radioButtonMonth.TabIndex = 14;
            this.radioButtonMonth.TabStop = true;
            this.radioButtonMonth.Text = "???????? (???? 31 ???)";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vsChartPresent1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(742, 581);
            this.splitContainer1.SplitterDistance = 537;
            this.splitContainer1.TabIndex = 1;
            // 
            // vsChartPresent1
            // 
            this.vsChartPresent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsChartPresent1.Location = new System.Drawing.Point(0, 0);
            this.vsChartPresent1.Name = "vsChartPresent1";
            this.vsChartPresent1.Size = new System.Drawing.Size(742, 537);
            this.vsChartPresent1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.radioButton1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButton2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButton3, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(742, 40);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButton1.Location = new System.Drawing.Point(3, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(241, 19);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "?????? (???? 24 ???????)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButton2.Location = new System.Drawing.Point(497, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(242, 19);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "????? (???? 12 ?????)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButton3.Location = new System.Drawing.Point(250, 10);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(241, 19);
            this.radioButton3.TabIndex = 14;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "???????? (???? 31 ???)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // VsChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "VsChart";
            this.Size = new System.Drawing.Size(742, 581);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer5;
        private VsChartPresent chartPresent1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonDay;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private VsChartPresent vsChartPresent1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}
