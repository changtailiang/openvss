// bpxl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pqpq	
// apij	 By downloading, copying, installing or using the software you agree to this license.
// ljhb	 If you do not agree to this license, do not download, install,
// aeya	 copy or use the software.
// akbj	
// mlpy	                          License Agreement
// vmwg	         For OpenVSS - Open Source Video Surveillance System
// tmew	
// nbco	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// vkbr	
// rpfa	Third party copyrights are property of their respective owners.
// nndj	
// tgrq	Redistribution and use in source and binary forms, with or without modification,
// nozd	are permitted provided that the following conditions are met:
// aruo	
// tbqz	  * Redistribution's of source code must retain the above copyright notice,
// floz	    this list of conditions and the following disclaimer.
// ckfq	
// ijsw	  * Redistribution's in binary form must reproduce the above copyright notice,
// gpli	    this list of conditions and the following disclaimer in the documentation
// jmnm	    and/or other materials provided with the distribution.
// uniz	
// cyod	  * Neither the name of the copyright holders nor the names of its contributors 
// pnxq	    may not be used to endorse or promote products derived from this software 
// zfub	    without specific prior written permission.
// zehj	
// bbid	This software is provided by the copyright holders and contributors "as is" and
// vcxk	any express or implied warranties, including, but not limited to, the implied
// fmfh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// odes	In no event shall the Prince of Songkla University or contributors be liable 
// dowe	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vbav	(including, but not limited to, procurement of substitute goods or services;
// lcwa	loss of use, data, or profits; or business interruption) however caused
// ukje	and on any theory of liability, whether in contract, strict liability,
// fdkt	or tort (including negligence or otherwise) arising in any way out of
// fedz	the use of this software, even if advised of the possibility of such damage.
// aeyd	
// iqcv	Intelligent Systems Laboratory (iSys Lab)
// bcyk	Faculty of Engineering, Prince of Songkla University, THAILAND
// hdoz	Project leader by Nikom SUVONVORN
// amrt	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
    public partial class VsTreeviewControl : UserControl
    {
        private VsLiveviewTool vsMonitor;
        private VsCoreServer vsCoreMonitor;
        public event VsMonitorEventHandler vsUpdateEvent;

        private TreeNode camerasNode;
        private TreeNode channelsNode;
        private TreeNode pagesNode;

        public VsLiveviewTool Monitor
        {
            set 
            {
                vsMonitor = value;
                vsMonitor.vsUpdateEvent += new VsMonitorEventHandler(vsMonitor_vsUpdateEvent);
                this.vsUpdateEvent += new VsMonitorEventHandler(vsMonitor.VsMonitor_vsUpdateEventAlls);
            }
        }

        public VsCoreServer CoreMonitor
        {
            set 
            { 
                vsCoreMonitor = value;
                // populate tree
                // cameras tree
                PopulateCameras(vsCoreMonitor.ListCameras());

                // channels tree
                PopulateChannels(vsCoreMonitor.ListChannels());

                // pages tree
                //PopulatePages(vsCoreMonitor.ListPages());

                // scroll-up to the top
                camerasNode.EnsureVisible();
            }
        }

        public VsTreeviewControl()
        {
            InitializeComponent();

            // event handler
            vsCameraTree.MouseClick += new MouseEventHandler(vsCameraTree_MouseClick);
            vsCameraTree.AfterSelect += new TreeViewEventHandler(vsCameraTree_AfterSelect);
            vsCameraTree.ItemDrag += new ItemDragEventHandler(vsCameraTree_ItemDrag);
            vsCameraTree.DragOver += new DragEventHandler(vsCameraTree_DragOver);
            this.DragOver += new DragEventHandler(VsApplicationControl_DragOver);

            // Add camera node
            camerasNode = new TreeNode("Analyzers");
            camerasNode.ImageIndex = 1; camerasNode.SelectedImageIndex = 1;
            vsCameraTree.Nodes.Add(camerasNode);

            // Add channel node
            channelsNode = new TreeNode("Layouts");
            channelsNode.ImageIndex = 2; channelsNode.SelectedImageIndex = 2;
            vsCameraTree.Nodes.Add(channelsNode);

            // Add page 
            /*
            pagesNode = new TreeNode("Pages");
            pagesNode.ImageIndex = 3; pagesNode.SelectedImageIndex = 3;
            vsCameraTree.Nodes.Add(pagesNode);
            */
        }

        // received message from other windows
        void vsMonitor_vsUpdateEvent(object sender, VsMonitorEventArgs e)
        {
            if (e.Parameters.EventTo == VsAppControlType.APP_ALL ||
                e.Parameters.EventTo == VsAppControlType.APP_APPICATION)
            {
                try { this.Invoke(new VsMonitorEventHandler(vsApplicationControl_Update), sender, e); }
                catch { }
            }
        }

        //invoked method
        void vsApplicationControl_Update(object sender, VsMonitorEventArgs e)
        {            
            foreach (TreeNode tn in camerasNode.Nodes)
            {
                if (vsCoreMonitor.GetCameraByName(tn.Text).Running)
                { tn.ImageIndex = 7; tn.SelectedImageIndex = 7; }
                else { tn.ImageIndex = 4; tn.SelectedImageIndex = 4; }
            }

            foreach (TreeNode tn in channelsNode.Nodes)
            {
                if (vsCoreMonitor.GetChannelByName(tn.Text).Running)
                { tn.ImageIndex = 7; tn.SelectedImageIndex = 7; }
                else { tn.ImageIndex = 5; tn.SelectedImageIndex = 5; }
            }
            /*
            foreach (TreeNode tn in pagesNode.Nodes)
            {
                if (vsCoreMonitor.GetPageByName(tn.Text).Running)
                { tn.ImageIndex = 7; tn.SelectedImageIndex = 7; }
                else { tn.ImageIndex = 6; tn.SelectedImageIndex = 6; }
            }
            */
        }

        void VsApplicationControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void vsCameraTree_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void vsCameraTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode dragNode = (TreeNode)e.Item;

            vsCameraTree.DoDragDrop(dragNode.FullPath, DragDropEffects.Copy);
        }

        // populate cameras
        public void PopulateCameras(String[] cameraNames)
        {
            camerasNode.Nodes.Clear();
            foreach (String name in cameraNames)
            {
                TreeNode node = new TreeNode(name);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
                camerasNode.Nodes.Add(node);
            }
            camerasNode.Expand();
        }

        // populate channels
        public void PopulateChannels(String[] channelNames)
        {
            channelsNode.Nodes.Clear();
            foreach (String name in channelNames)
            {
                TreeNode node = new TreeNode(name);
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;
                channelsNode.Nodes.Add(node);
            }
            channelsNode.Expand();            
        }

        /*
        // populate pages
        public void PopulatePages(String[] pageNames)
        {
            pagesNode.Nodes.Clear();
            foreach (String name in pageNames)
            {
                TreeNode node = new TreeNode(name);
                node.ImageIndex = 6;
                node.SelectedImageIndex = 6;
                pagesNode.Nodes.Add(node);
            }
            pagesNode.Expand();
        } 
        */

        // tree mouse click
        void vsCameraTree_MouseClick(object sender, MouseEventArgs e)
        {
            #region Check click item in Treeview
            
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            
            String selectedNode = node.Text;
            String selectedType = node.Parent.Text;

            #endregion

            switch (e.Button)
            {
                case MouseButtons.Right:
                {
                    switch (selectedType)
                    {
                        case "Analyzers":
                            this.ContextMenuStrip = cameraContextMenu;
                            cameraContextMenu.Show();
                            break;
                        case "Layouts":
                            this.ContextMenuStrip = channelContextMenu;
                            channelContextMenu.Show();
                            break;
                            /*
                        case "Pages":
                            this.ContextMenuStrip = pageContextMenu;
                            //pageContextMenu.Show();
                            break;
                             */
                    }
                    break;
                }
            }
        }

        void vsCameraTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;

            String selectedNode = node.Text;
            String selectedType = node.Parent.Text;

            this.vsApplicationControl_Update(null, null);

            switch (selectedType)
            {
                case "Analyzers":
                    // update property page
                    vsUpdateEvent(this, new VsMonitorEventArgs(
                        new VsParameter(VsAppControlType.APP_APPICATION, 
                            VsAppControlType.APP_PROPERTY, 
                            VsDeviceType.CAMERA, selectedNode)));
                    break;
                case "Layouts":
                    // update property page
                    vsUpdateEvent(this, new VsMonitorEventArgs(
                        new VsParameter(VsAppControlType.APP_APPICATION,
                            VsAppControlType.APP_PROPERTY,
                            VsDeviceType.CHANNEL, selectedNode)));
                    break;
                    /*
                case "Pages":
                    // update property page
                    vsUpdateEvent(this, new VsMonitorEventArgs(
                        new VsParameter(VsAppControlType.APP_APPICATION,
                            VsAppControlType.APP_PROPERTY,
                            VsDeviceType.PAGE, selectedNode)));
                    break;
                     */
            }
        }

        #region Camera Context Menu

        private void cameraConnect_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;

            // test if camera is connected
            if (vsCoreMonitor.ConnectingCamera(selectedNode)) return;

            // try to connect
            if (vsCoreMonitor.ConnectCamera(selectedNode, false))
            {
                // TODO...
            }

            // TODO...
        }

        private void cameraDisconnectMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;

            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(selectedNode);

            // test if camera is connected
            if (!vsCoreMonitor.ConnectingCamera(selectedNode)) return;

            // try to connect
            if (vsCoreMonitor.DisconnectCamera(selectedNode))
            {
                // TODO...
            }

            // TODO...

        }

        // add new camera
        private void cameraAddMenu_Click(object sender, EventArgs e)
        {
            // show dialog box
            VsCameraDialog cameraDialog = new VsCameraDialog(vsCoreMonitor);

            cameraDialog.ShowDialog(this);            

            // update tree list
            if (cameraDialog.DialogResult == DialogResult.OK)
            {
                TreeNode retNode = this.camerasNode.Nodes.Add(cameraDialog.Camera.CameraName);
                retNode.ImageIndex = 4;
                retNode.SelectedImageIndex = 4;
                retNode.EnsureVisible();
            }
        }

        // remove camera
        private void cameraRemoveMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;

            // ask before remove
            if (MessageBox.Show(this, "Do you want to remove \"" + selectedNode + "\"", "Remove Analyzer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                vsCoreMonitor.DeleteCamera(selectedNode);

                TreeNode retNode = node.PrevVisibleNode;
                this.camerasNode.Nodes.Remove(node);
                retNode.EnsureVisible();
            }
        } 
        #endregion

        #region Channel Context Menu
        private void channelConnectMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;

            // test if camera is connected
            if (vsCoreMonitor.ConnectingChannel(selectedNode)) return;

            // try to connect
            if (vsCoreMonitor.ConnectChannel(selectedNode, false))
            {
                // TODO...
            }

            // TODO...

        }

        private void channelDisconnectMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;

            // test if camera is connected
            if (!vsCoreMonitor.ConnectingChannel(selectedNode)) return;

            // try to connect
            if (vsCoreMonitor.DisconnectChannel(selectedNode))
            {
                // TODO...
            }

            // TODO...

        }

        private void channelAddMenu_Click(object sender, EventArgs e)
        {
            // show dialog box
            VsChannelDialog channelDialog = new VsChannelDialog(vsCoreMonitor);

            channelDialog.ShowDialog(this);

            // update tree list
            if (channelDialog.DialogResult == DialogResult.OK)
            {
                TreeNode retNode = this.channelsNode.Nodes.Add(channelDialog.Channel.ChannelName);
                retNode.ImageIndex = 5;
                retNode.SelectedImageIndex = 5;
                retNode.EnsureVisible();
            }
        }

        private void channelRemoveMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;

            // ask before remove
            if (MessageBox.Show(this, "Do you want to remove \"" + selectedNode + "\"", "Remove Layout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                vsCoreMonitor.DeleteChannel(selectedNode);

                TreeNode retNode = node.PrevVisibleNode;
                this.camerasNode.Nodes.Remove(node);
                retNode.EnsureVisible();
            }
        }
        
        #endregion

        #region Page Context Menu
        /*
        private void pageConnectMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;


            // test if camera is connected
            if (vsCoreMonitor.ConnectingPage(selectedNode)) return;

            // try to connect
            if (vsCoreMonitor.ConnectPage(selectedNode, false))
            {
                // TODO...
            }

            // TODO...

        }

        private void pageDisconnectMenu_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;


            // test if camera is connected
            if (!vsCoreMonitor.ConnectingPage(selectedNode)) return;

            // try to connect
            if (vsCoreMonitor.DisconnectPage(selectedNode))
            {
                // TODO...
            }

            // TODO...

        }

        private void pageAddMenu_Click(object sender, EventArgs e)
        {
        }

        private void pageRemoveMenu_Click(object sender, EventArgs e)
        {
        }
        */
        #endregion    

        private void buttonAddCamera_Click(object sender, EventArgs e)
        {
            cameraAddMenu_Click(null, null);
        }

        private void buttonAddChannel_Click(object sender, EventArgs e)
        {
            channelAddMenu_Click(null, null);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            TreeNode node = vsCameraTree.SelectedNode;
            if (node == null || node.Parent == null) return;
            String selectedNode = node.Text;
            switch (node.Parent.Text)
            {
                case "Analyzers":
                    {
                        // ask before remove
                        if (MessageBox.Show(this, "Do you want to remove \"" + selectedNode + "\"", "Remove Analyzer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            vsCoreMonitor.DeleteCamera(selectedNode);

                            TreeNode retNode = node.PrevVisibleNode;
                            this.camerasNode.Nodes.Remove(node);
                            retNode.EnsureVisible();
                        }
                    }
                    break;
                case "Layouts":
                    {
                        // ask before remove
                        if (MessageBox.Show(this, "Do you want to remove \"" + selectedNode + "\"", "Remove Layout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            vsCoreMonitor.DeleteChannel(selectedNode);

                            TreeNode retNode = node.PrevVisibleNode;
                            this.camerasNode.Nodes.Remove(node);
                            retNode.EnsureVisible();
                        }
                    }
                    break;
            }
        }
    }
}
