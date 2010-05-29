// yxwc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mnww	
// uhbx	 By downloading, copying, installing or using the software you agree to this license.
// hkmb	 If you do not agree to this license, do not download, install,
// fjjz	 copy or use the software.
// fakr	
// wxuo	                          License Agreement
// vsel	         For OpenVSS - Open Source Video Surveillance System
// irue	
// jwmt	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yngf	
// iysa	Third party copyrights are property of their respective owners.
// hikm	
// skiy	Redistribution and use in source and binary forms, with or without modification,
// nfgo	are permitted provided that the following conditions are met:
// siab	
// dqoq	  * Redistribution's of source code must retain the above copyright notice,
// qiri	    this list of conditions and the following disclaimer.
// wqar	
// ufix	  * Redistribution's in binary form must reproduce the above copyright notice,
// ftgn	    this list of conditions and the following disclaimer in the documentation
// irtx	    and/or other materials provided with the distribution.
// iwre	
// qyaq	  * Neither the name of the copyright holders nor the names of its contributors 
// mebs	    may not be used to endorse or promote products derived from this software 
// jckz	    without specific prior written permission.
// qbqb	
// jqdh	This software is provided by the copyright holders and contributors "as is" and
// wijy	any express or implied warranties, including, but not limited to, the implied
// bntl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wqht	In no event shall the Prince of Songkla University or contributors be liable 
// rnsy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qkfq	(including, but not limited to, procurement of substitute goods or services;
// dqoc	loss of use, data, or profits; or business interruption) however caused
// jhwg	and on any theory of liability, whether in contract, strict liability,
// bsor	or tort (including negligence or otherwise) arising in any way out of
// sjih	the use of this software, even if advised of the possibility of such damage.
// oboz	
// kpvs	Intelligent Systems Laboratory (iSys Lab)
// uqid	Faculty of Engineering, Prince of Songkla University, THAILAND
// jrky	Project leader by Nikom SUVONVORN
// lnef	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Image;
using Vs.Core.Server;
using System.Runtime.CompilerServices;

namespace Vs.Monitor
{
    public enum VsViewStatusType
    {
        VIEW_AVAIABLE = 0,
        VIEW_CONNECTING,
        VIEW_CONNECTED
    }

    public enum VsAttachType
    {
        ATTACH_RECEIVER = 0,
        ATTACH_ANALYZER
    }

    public partial class VsSingleViewer : UserControl, VsAppInterface
    {
        private VsLiveviewTool vsMonitor;
        private VsCoreServer vsCoreMonitor;
        public event VsMonitorEventHandler vsUpdateEvent;

        VsViewStatusType vsStatus = VsViewStatusType.VIEW_AVAIABLE;
        VsDeviceType vsDeviceType;
        VsAttachType vsAttachType;
        String vsDeviceName;
        VsCamera vsCamera = null;
        VsChannel vsChannel = null;
        int i;

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
            set { vsCoreMonitor = value; }
        }

        public void InitialViewer()
        {
            vsViewer.Image = global::Vs.Monitor.Properties.Resources.isys;
            vsViewer.SizeMode = PictureBoxSizeMode.CenterImage;

            i = 0;
            // initial toolbox - disable 
            labelStatus.Text = "";
            panelTool.Focus();
            buttonStop.Enabled = false;
            buttonAttach.Enabled = false;
            buttonAnalyzer.Enabled = false;

            this.BorderStyle = BorderStyle.None;

            vsDeviceType = VsDeviceType.CAMERA;
            vsAttachType = VsAttachType.ATTACH_RECEIVER;
            vsStatus = VsViewStatusType.VIEW_AVAIABLE;
        }

        public VsSingleViewer()
        {
            InitializeComponent();

            // drag & drop vent handler 
            this.DragOver += new DragEventHandler(VsCameraViewer_DragOver);
            this.DragDrop += new DragEventHandler(VsCameraViewer_DragDrop);
            this.DragLeave += new EventHandler(VsCameraViewer_DragLeave);

            InitialViewer();
        }

        // receive messages from other windows
        void vsMonitor_vsUpdateEvent(object sender, VsMonitorEventArgs e)
        {
            if (e.Parameters.EventTo == VsAppControlType.APP_ALL ||
                e.Parameters.EventTo == VsAppControlType.APP_SIGLEVIEW)
            {
                if (e.Parameters.Device == vsDeviceType && e.Parameters.DeviceName == vsDeviceName && e.Parameters.MsgType == VsMessageType.MSG_VIEWER_STYLE)
                    try { this.Invoke(new VsMonitorEventHandler(vsSigleViewer_Update), sender, e); }
                    catch { }
            }
        }

        //invoked method
        void vsSigleViewer_Update(object sender, VsMonitorEventArgs e)
        {
            VsViewerParas vsViewerParas = (VsViewerParas)e.Parameters;
            switch (vsViewerParas.ViewerParas)
            {
                case VsViewerType.VIEW_STATUS:
                    switch (vsStatus)
                    {
                        case VsViewStatusType.VIEW_AVAIABLE:
                            labelStatus.Text = "";
                            break;
                        case VsViewStatusType.VIEW_CONNECTING:
                            labelStatus.Text = "Connecting to \"" + vsDeviceName + "\"...";
                            break;
                        case VsViewStatusType.VIEW_CONNECTED:
                            labelStatus.Text = vsDeviceName;
                            break;
                    }
                    break;
                case VsViewerType.VIEW_CLOSE:
                    CloseCameraView();
                    break;
            }
        }

        // drage leave the window
        void VsCameraViewer_DragLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        // drag drop into window
        void VsCameraViewer_DragDrop(object sender, DragEventArgs e)
        {
            this.BorderStyle = BorderStyle.None;

            string send = (string)e.Data.GetData(typeof(string));

            connectDevice(send);
        }

        public void connectDevice(string send)
        {

            if (vsStatus == VsViewStatusType.VIEW_CONNECTING || vsStatus == VsViewStatusType.VIEW_CONNECTED) return;

            string[] cmd = send.Split('\\');

            vsDeviceName = cmd[1];
            // check if not root node
            if (cmd.Length == 2 && cmd[0] == "Analyzers")
            {
                // set flag
                vsDeviceType = VsDeviceType.CAMERA;
                vsStatus = VsViewStatusType.VIEW_CONNECTING;

                // update event
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsParameter(VsAppControlType.APP_SIGLEVIEW, VsAppControlType.APP_SIGLEVIEW, vsDeviceType, vsDeviceName)));

                labelStatus.Text = "Connecting...";
                // the current camera is connected
                if (!vsCoreMonitor.ConnectingCamera(vsDeviceName))
                {
                    // not connected
                    // try to connect
                    if (!vsCoreMonitor.ConnectCamera(vsDeviceName, false))
                        return;

                    // cache current camera
                    vsCamera = vsCoreMonitor.GetCameraByName(vsDeviceName);
                }

                // the camera is connected
                // attach to current view
                vsCoreMonitor.AttachCameraView(vsDeviceName, this);
                vsAttachType = VsAttachType.ATTACH_RECEIVER;

                // enable toolbox
                buttonStop.Enabled = true;
                buttonAttach.Enabled = true;
                buttonAnalyzer.Enabled = true;
            }
            else if (cmd.Length == 2 && cmd[0] == "Layouts")
            {
                // set flag
                vsDeviceType = VsDeviceType.CHANNEL;
                vsStatus = VsViewStatusType.VIEW_CONNECTING;

                // update event
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsParameter(VsAppControlType.APP_SIGLEVIEW, VsAppControlType.APP_SIGLEVIEW, vsDeviceType, vsDeviceName)));

                // the current channel is connected
                if (!vsCoreMonitor.ConnectingChannel(vsDeviceName))
                {
                    // not connected
                    // try to connect
                    if (!vsCoreMonitor.ConnectChannel(vsDeviceName, false))
                        return;

                    // cache current camera
                    vsChannel = vsCoreMonitor.GetChannelByName(vsDeviceName);
                }

                // the camera is connected
                // attach to current view
                vsCoreMonitor.AttachChannelView(vsDeviceName, this);

                // enable toolbox
                buttonStop.Enabled = true;
                buttonAttach.Enabled = true;
                buttonAnalyzer.Enabled = true;
            }
        }

        // drag over event
        void VsCameraViewer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        // New frame
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void FrameIn(object sender, VsImageEventArgs e)
        {
            VsImage img = (VsImage)e.Image.Clone();

            this.vsViewer.SizeMode = PictureBoxSizeMode.StretchImage;

            //if (vsAttachType == VsAttachType.ATTACH_ANALYZER)
            //    this.vsViewer.Image = img.AnalyzedImage;
            //else
            this.vsViewer.Image = img.Image;

            //this.vsViewer.Image.Save("test.bmp");
            // if the first frame -> alert to application and property control
            if (vsStatus == VsViewStatusType.VIEW_CONNECTING)
            {
                // connected flag
                vsStatus = VsViewStatusType.VIEW_CONNECTED;

                // alert to sigleview
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsViewerParas(VsAppControlType.APP_SIGLEVIEW, VsAppControlType.APP_SIGLEVIEW, vsDeviceType, vsDeviceName, VsViewerType.VIEW_STATUS)));

                // alert to application control
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsViewerParas(VsAppControlType.APP_SIGLEVIEW, VsAppControlType.APP_APPICATION, vsDeviceType, vsDeviceName, VsViewerType.VIEW_STATUS)));

                // alert to property control
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsViewerParas(VsAppControlType.APP_SIGLEVIEW, VsAppControlType.APP_PROPERTY, vsDeviceType, vsDeviceName, VsViewerType.VIEW_STATUS)));
            }
        }

        // Close Camera
        public void CloseCameraView()
        {
            // try to detache
            switch (vsDeviceType)
            {
                case VsDeviceType.CAMERA:
                    {
                        switch (vsAttachType)
                        {
                            case VsAttachType.ATTACH_RECEIVER:
                                vsCoreMonitor.DetachCameraView(vsDeviceName, this);
                                break;
                            case VsAttachType.ATTACH_ANALYZER:
                                vsCoreMonitor.DetachCameraViewAnalyzer(vsDeviceName, this);
                                break;
                        }
                        break;
                    }
                case VsDeviceType.CHANNEL:
                    {
                        switch (vsAttachType)
                        {
                            case VsAttachType.ATTACH_RECEIVER:
                                vsCoreMonitor.DetachChannelView(vsDeviceName, this);
                                break;
                            case VsAttachType.ATTACH_ANALYZER:
                                vsCoreMonitor.DetachChannelViewAnalyzer(vsDeviceName, this);
                                break;
                        }
                        break;
                    }
            }

            InitialViewer();
        }

        private void AttachCameraView()
        {
            switch (vsDeviceType)
            {
                case VsDeviceType.CAMERA:
                    {
                        if (vsAttachType == VsAttachType.ATTACH_RECEIVER)
                        {
                            vsCoreMonitor.DetachCameraView(vsDeviceName, this);
                            // vsCoreMonitor.DetachCameraViewAnalyzer(vsDeviceName, this);

                            vsViewer.Image = global::Vs.Monitor.Properties.Resources.isys;
                            vsViewer.SizeMode = PictureBoxSizeMode.CenterImage;

                            vsCoreMonitor.AttachCameraViewAnalyzer(vsDeviceName, this);
                            vsAttachType = VsAttachType.ATTACH_ANALYZER;
                        }
                        else
                        {
                            //vsCoreMonitor.DetachCameraView(vsDeviceName, this);
                            vsCoreMonitor.DetachCameraViewAnalyzer(vsDeviceName, this);

                            vsViewer.Image = global::Vs.Monitor.Properties.Resources.isys;
                            vsViewer.SizeMode = PictureBoxSizeMode.CenterImage;

                            vsCoreMonitor.AttachCameraView(vsDeviceName, this);
                            vsAttachType = VsAttachType.ATTACH_RECEIVER;
                        }
                        break;
                    }
                case VsDeviceType.CHANNEL:
                    {
                        if (vsAttachType == VsAttachType.ATTACH_RECEIVER)
                        {
                            vsCoreMonitor.DetachChannelView(vsDeviceName, this);
                            //vsCoreMonitor.DetachChannelViewAnalyzer(vsDeviceName, this);

                            vsViewer.Image = global::Vs.Monitor.Properties.Resources.isys;
                            vsViewer.SizeMode = PictureBoxSizeMode.CenterImage;

                            vsCoreMonitor.AttachChannelViewAnalyzer(vsDeviceName, this);
                            vsAttachType = VsAttachType.ATTACH_ANALYZER;
                        }
                        else
                        {
                            //vsCoreMonitor.DetachChannelView(vsDeviceName, this);
                            vsCoreMonitor.DetachChannelViewAnalyzer(vsDeviceName, this);

                            vsViewer.Image = global::Vs.Monitor.Properties.Resources.isys;
                            vsViewer.SizeMode = PictureBoxSizeMode.CenterImage;

                            vsCoreMonitor.AttachChannelView(vsDeviceName, this);
                            vsAttachType = VsAttachType.ATTACH_RECEIVER;
                        }
                        break;
                    }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CloseCameraView();
        }

        private void buttonAttach_Click(object sender, EventArgs e)
        {
            AttachCameraView();
        }

        private void buttonAnalyzer_Click(object sender, EventArgs e)
        {
            if (vsCamera != null && vsAttachType == VsAttachType.ATTACH_ANALYZER)
            {
                VsAnalyzerDialog analyzerDialog = new VsAnalyzerDialog(vsCoreMonitor, vsCamera);

                analyzerDialog.ShowDialog(this);
            }
        }
    }
}
