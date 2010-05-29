// wqce	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rowa	
// yvdb	 By downloading, copying, installing or using the software you agree to this license.
// cwek	 If you do not agree to this license, do not download, install,
// qhlg	 copy or use the software.
// njps	
// jipk	                          License Agreement
// degc	         For OpenVSS - Open Source Video Surveillance System
// dglu	
// qura	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// picw	
// anom	Third party copyrights are property of their respective owners.
// ftfn	
// qzdn	Redistribution and use in source and binary forms, with or without modification,
// bjui	are permitted provided that the following conditions are met:
// ylxt	
// obyw	  * Redistribution's of source code must retain the above copyright notice,
// lkuw	    this list of conditions and the following disclaimer.
// qlqe	
// gsrw	  * Redistribution's in binary form must reproduce the above copyright notice,
// tcej	    this list of conditions and the following disclaimer in the documentation
// ztld	    and/or other materials provided with the distribution.
// dytg	
// zibd	  * Neither the name of the copyright holders nor the names of its contributors 
// kjiz	    may not be used to endorse or promote products derived from this software 
// osbv	    without specific prior written permission.
// zjxe	
// iygj	This software is provided by the copyright holders and contributors "as is" and
// sxpv	any express or implied warranties, including, but not limited to, the implied
// gouv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// putm	In no event shall the Prince of Songkla University or contributors be liable 
// rnwh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jnux	(including, but not limited to, procurement of substitute goods or services;
// jshb	loss of use, data, or profits; or business interruption) however caused
// ajkq	and on any theory of liability, whether in contract, strict liability,
// vgve	or tort (including negligence or otherwise) arising in any way out of
// rjoc	the use of this software, even if advised of the possibility of such damage.
// tgxw	
// onjt	Intelligent Systems Laboratory (iSys Lab)
// zoel	Faculty of Engineering, Prince of Songkla University, THAILAND
// mqvv	Project leader by Nikom SUVONVORN
// eizz	Project website at http://code.google.com/p/openvss/

namespace Vs.Operator
{
    partial class VsOperator
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
            if (disposing)
                VsOperator_Close();

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(462, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // VsOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(462, 386);
            this.Controls.Add(this.pictureBox1);
            this.Name = "VsOperator";
            this.Text = "VsOperator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

