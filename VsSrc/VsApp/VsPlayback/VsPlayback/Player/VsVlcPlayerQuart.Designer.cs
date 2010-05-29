// mekj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fstg	
// yrqi	 By downloading, copying, installing or using the software you agree to this license.
// bqla	 If you do not agree to this license, do not download, install,
// dwni	 copy or use the software.
// mtwl	
// gxjr	                          License Agreement
// wtjt	         For OpenVSS - Open Source Video Surveillance System
// wcra	
// mnrm	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tlpq	
// eqap	Third party copyrights are property of their respective owners.
// fssd	
// csos	Redistribution and use in source and binary forms, with or without modification,
// izdh	are permitted provided that the following conditions are met:
// jcjf	
// hwlz	  * Redistribution's of source code must retain the above copyright notice,
// ylop	    this list of conditions and the following disclaimer.
// eapa	
// efgp	  * Redistribution's in binary form must reproduce the above copyright notice,
// xtld	    this list of conditions and the following disclaimer in the documentation
// bfqd	    and/or other materials provided with the distribution.
// nysn	
// kjdq	  * Neither the name of the copyright holders nor the names of its contributors 
// bjih	    may not be used to endorse or promote products derived from this software 
// fbqu	    without specific prior written permission.
// edyc	
// dooc	This software is provided by the copyright holders and contributors "as is" and
// snkp	any express or implied warranties, including, but not limited to, the implied
// rgeb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fila	In no event shall the Prince of Songkla University or contributors be liable 
// tbeu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xyyu	(including, but not limited to, procurement of substitute goods or services;
// xykv	loss of use, data, or profits; or business interruption) however caused
// dqzy	and on any theory of liability, whether in contract, strict liability,
// hoaz	or tort (including negligence or otherwise) arising in any way out of
// kpux	the use of this software, even if advised of the possibility of such damage.
// yozv	
// fgcw	Intelligent Systems Laboratory (iSys Lab)
// qpad	Faculty of Engineering, Prince of Songkla University, THAILAND
// yeee	Project leader by Nikom SUVONVORN
// pteu	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback.Player
{
    partial class VsVlcPlayerQuart
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
            this.vsVlcPlayer21 = new Vs.Playback.VsVlcPlayer2();
            this.vsVlcPlayer22 = new Vs.Playback.VsVlcPlayer2();
            this.vsVlcPlayer23 = new Vs.Playback.VsVlcPlayer2();
            this.vsVlcPlayer24 = new Vs.Playback.VsVlcPlayer2();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.vsVlcPlayer21, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vsVlcPlayer22, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.vsVlcPlayer23, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.vsVlcPlayer24, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.79704F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.20296F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 473);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // vsVlcPlayer21
            // 
            this.vsVlcPlayer21.BackColor = System.Drawing.Color.LightGray;
            this.vsVlcPlayer21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsVlcPlayer21.Location = new System.Drawing.Point(3, 3);
            this.vsVlcPlayer21.Name = "vsVlcPlayer21";
            this.vsVlcPlayer21.Size = new System.Drawing.Size(297, 238);
            this.vsVlcPlayer21.TabIndex = 0;
            // 
            // vsVlcPlayer22
            // 
            this.vsVlcPlayer22.BackColor = System.Drawing.Color.LightGray;
            this.vsVlcPlayer22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsVlcPlayer22.Location = new System.Drawing.Point(306, 3);
            this.vsVlcPlayer22.Name = "vsVlcPlayer22";
            this.vsVlcPlayer22.Size = new System.Drawing.Size(298, 238);
            this.vsVlcPlayer22.TabIndex = 1;
            // 
            // vsVlcPlayer23
            // 
            this.vsVlcPlayer23.BackColor = System.Drawing.Color.LightGray;
            this.vsVlcPlayer23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsVlcPlayer23.Location = new System.Drawing.Point(3, 247);
            this.vsVlcPlayer23.Name = "vsVlcPlayer23";
            this.vsVlcPlayer23.Size = new System.Drawing.Size(297, 223);
            this.vsVlcPlayer23.TabIndex = 2;
            // 
            // vsVlcPlayer24
            // 
            this.vsVlcPlayer24.BackColor = System.Drawing.Color.LightGray;
            this.vsVlcPlayer24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsVlcPlayer24.Location = new System.Drawing.Point(306, 247);
            this.vsVlcPlayer24.Name = "vsVlcPlayer24";
            this.vsVlcPlayer24.Size = new System.Drawing.Size(298, 223);
            this.vsVlcPlayer24.TabIndex = 3;
            // 
            // VsVlcPlayerQuart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VsVlcPlayerQuart";
            this.Size = new System.Drawing.Size(607, 473);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VsVlcPlayer2 vsVlcPlayer21;
        private VsVlcPlayer2 vsVlcPlayer22;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private VsVlcPlayer2 vsVlcPlayer23;
        private VsVlcPlayer2 vsVlcPlayer24;
    }
}
