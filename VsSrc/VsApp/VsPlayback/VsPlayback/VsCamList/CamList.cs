// kjye	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pjvu	
// vzyl	 By downloading, copying, installing or using the software you agree to this license.
// bqle	 If you do not agree to this license, do not download, install,
// whji	 copy or use the software.
// qgcb	
// udwt	                          License Agreement
// fpxv	         For OpenVSS - Open Source Video Surveillance System
// qmek	
// illr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// sqbh	
// dbuz	Third party copyrights are property of their respective owners.
// wnwx	
// amce	Redistribution and use in source and binary forms, with or without modification,
// gxjl	are permitted provided that the following conditions are met:
// mbpf	
// ccuo	  * Redistribution's of source code must retain the above copyright notice,
// mawl	    this list of conditions and the following disclaimer.
// vsqa	
// fvyt	  * Redistribution's in binary form must reproduce the above copyright notice,
// ixxr	    this list of conditions and the following disclaimer in the documentation
// savd	    and/or other materials provided with the distribution.
// jaek	
// bzer	  * Neither the name of the copyright holders nor the names of its contributors 
// avfa	    may not be used to endorse or promote products derived from this software 
// ggmv	    without specific prior written permission.
// rkbi	
// wczl	This software is provided by the copyright holders and contributors "as is" and
// zqdp	any express or implied warranties, including, but not limited to, the implied
// dxmb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hqfm	In no event shall the Prince of Songkla University or contributors be liable 
// wmkw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nyzj	(including, but not limited to, procurement of substitute goods or services;
// qxmc	loss of use, data, or profits; or business interruption) however caused
// kbai	and on any theory of liability, whether in contract, strict liability,
// zmhh	or tort (including negligence or otherwise) arising in any way out of
// atlk	the use of this software, even if advised of the possibility of such damage.
// wpnc	
// jdsp	Intelligent Systems Laboratory (iSys Lab)
// aaze	Faculty of Engineering, Prince of Songkla University, THAILAND
// aeux	Project leader by Nikom SUVONVORN
// cqub	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Playback.VsCamList;
using Vs.Playback.VsService;

namespace Vs.Playback
{
    public partial class CamList : UserControl
    {
        public CamList()
        {
            InitializeComponent();

            treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            treeView1.DragEnter+=new DragEventHandler(treeView1_DragEnter);
            treeView1.DragOver+=new DragEventHandler(treeView1_DragOver);

            //this.DragOver += new DragEventHandler(treeView1_DragOver);
            this.DragOver += new DragEventHandler(treeView1_DragOver);
            // this.Parent.DragOver += new DragEventHandler(treeView1_DragOver);

            this.DragEnter += new DragEventHandler(treeView1_DragEnter);
            //this.Parent.DragEnter += new DragEventHandler(treeView1_DragEnter);
        }
        TreeNode dragNode;
        private void treeView1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            dragNode = (TreeNode)e.Item;
            string strItem = dragNode.Name;

            this.imageListDrag.Images.Clear();
            this.imageListDrag.ImageSize = new Size(this.dragNode.Bounds.Size.Width + this.treeView1.Indent, this.dragNode.Bounds.Height);

            Bitmap bmp = new Bitmap(this.dragNode.Bounds.Width + this.treeView1.Indent, this.dragNode.Bounds.Height);



            // Get graphics from bitmap
            Graphics gfx = Graphics.FromImage(bmp);


            gfx.DrawImage(this.imageList1.Images[0], 0, 0);

            // Draw node label into bitmap
            gfx.DrawString(this.dragNode.Text,
                this.treeView1.Font,
                new SolidBrush(this.treeView1.ForeColor),
                (float)this.treeView1.Indent, 1.0f);

            // Add bitmap to imagelist
            this.imageListDrag.Images.Add(bmp);


            Point p = this.treeView1.PointToClient(Control.MousePosition);

            // Compute delta between mouse position and node bounds
            int dx = p.X + this.treeView1.Indent - this.dragNode.Bounds.Left;
            int dy = p.Y - this.dragNode.Bounds.Top;

            // Begin dragging image
            if (DragHelper.ImageList_BeginDrag(this.imageListDrag.Handle, 0, dx, dy))
            {
                // Begin dragging
                // this.treeView1.DoDragDrop(bmp, DragDropEffects.Move);

                DoDragDrop(strItem, DragDropEffects.Move);
                // End dragging image
                DragHelper.ImageList_EndDrag();
            }

        }

        private void treeView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;


            DragHelper.ImageList_DragEnter(this.treeView1.Handle, e.X - this.treeView1.Left,
                e.Y - this.treeView1.Top);

        }

        // Temporary drop node for selection
        private TreeNode tempDropNode = null;

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Compute drag position and move image
            Point formP = this.PointToClient(new Point(e.X, e.Y));
            DragHelper.ImageList_DragMove(formP.X - this.treeView1.Left, formP.Y - this.treeView1.Top);

            // Get actual drop node
            TreeNode dropNode = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));
            if (dropNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;

            // if mouse is on a new node select it
            if (this.tempDropNode != dropNode)
            {
                DragHelper.ImageList_DragShowNolock(false);
                this.treeView1.SelectedNode = dropNode;
                DragHelper.ImageList_DragShowNolock(true);
                tempDropNode = dropNode;
            }

            // Avoid that drop node is child of drag node 
            TreeNode tmpNode = dropNode;
            while (tmpNode.Parent != null)
            {
                if (tmpNode.Parent == this.dragNode) e.Effect = DragDropEffects.None;
                tmpNode = tmpNode.Parent;
            }
        }


        public TreeView getTreeView()
        {
            return treeView1;
        }

        public void setCam(VsCamera[] camData)
        {
            treeView1.Nodes.Clear();

            foreach (var cam in camData)
            {
                TreeNode node = new TreeNode();
                node.Text = cam.location;
                node.Name = cam.cameraID;
                node.ImageIndex = 0; node.SelectedImageIndex = 0;

                treeView1.Nodes.Add(node);
            }
        }
    }
}
