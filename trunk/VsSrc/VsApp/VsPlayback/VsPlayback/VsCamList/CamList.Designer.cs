// dbec	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xecu	
// jxlc	 By downloading, copying, installing or using the software you agree to this license.
// azay	 If you do not agree to this license, do not download, install,
// lxzm	 copy or use the software.
// fxbk	
// bvhu	                          License Agreement
// sjek	         For OpenVSS - Open Source Video Surveillance System
// ykhu	
// klfe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// axfd	
// oxeb	Third party copyrights are property of their respective owners.
// evmf	
// qhwg	Redistribution and use in source and binary forms, with or without modification,
// auab	are permitted provided that the following conditions are met:
// xica	
// saeq	  * Redistribution's of source code must retain the above copyright notice,
// rfnz	    this list of conditions and the following disclaimer.
// rvmh	
// rxve	  * Redistribution's in binary form must reproduce the above copyright notice,
// rgpx	    this list of conditions and the following disclaimer in the documentation
// wzuq	    and/or other materials provided with the distribution.
// obuq	
// ldgs	  * Neither the name of the copyright holders nor the names of its contributors 
// vfko	    may not be used to endorse or promote products derived from this software 
// sojy	    without specific prior written permission.
// hmnu	
// vooc	This software is provided by the copyright holders and contributors "as is" and
// yvkr	any express or implied warranties, including, but not limited to, the implied
// sedt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fnbq	In no event shall the Prince of Songkla University or contributors be liable 
// kxon	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oulm	(including, but not limited to, procurement of substitute goods or services;
// nglc	loss of use, data, or profits; or business interruption) however caused
// wrpk	and on any theory of liability, whether in contract, strict liability,
// mavz	or tort (including negligence or otherwise) arising in any way out of
// msrp	the use of this software, even if advised of the possibility of such damage.
// tpzq	
// brif	Intelligent Systems Laboratory (iSys Lab)
// mtok	Faculty of Engineering, Prince of Songkla University, THAILAND
// yzfb	Project leader by Nikom SUVONVORN
// ccor	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback
{
    partial class CamList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamList));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("cam001");
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageListDrag = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "8.png");
            // 
            // imageListDrag
            // 
            this.imageListDrag.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListDrag.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListDrag.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "camname";
            treeNode1.Text = "cam001";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(237, 373);
            this.treeView1.TabIndex = 1;
            // 
            // CamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "CamList";
            this.Size = new System.Drawing.Size(237, 373);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageListDrag;
        private System.Windows.Forms.TreeView treeView1;
    }
}
