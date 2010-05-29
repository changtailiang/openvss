// hqiw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// huax	
// htmn	 By downloading, copying, installing or using the software you agree to this license.
// srmo	 If you do not agree to this license, do not download, install,
// qvqg	 copy or use the software.
// awkv	
// gxoa	                          License Agreement
// exji	         For OpenVSS - Open Source Video Surveillance System
// yxkx	
// chno	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// izql	
// pxoz	Third party copyrights are property of their respective owners.
// oxvi	
// ouxk	Redistribution and use in source and binary forms, with or without modification,
// gnpk	are permitted provided that the following conditions are met:
// fzsj	
// keov	  * Redistribution's of source code must retain the above copyright notice,
// holi	    this list of conditions and the following disclaimer.
// hcxa	
// gygi	  * Redistribution's in binary form must reproduce the above copyright notice,
// jolg	    this list of conditions and the following disclaimer in the documentation
// cate	    and/or other materials provided with the distribution.
// zzro	
// sdij	  * Neither the name of the copyright holders nor the names of its contributors 
// hhbk	    may not be used to endorse or promote products derived from this software 
// itsa	    without specific prior written permission.
// lmam	
// xxeh	This software is provided by the copyright holders and contributors "as is" and
// hgbq	any express or implied warranties, including, but not limited to, the implied
// nlhj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kkvh	In no event shall the Prince of Songkla University or contributors be liable 
// wxqe	for any direct, indirect, incidental, special, exemplary, or consequential damages
// totz	(including, but not limited to, procurement of substitute goods or services;
// wvap	loss of use, data, or profits; or business interruption) however caused
// wlvp	and on any theory of liability, whether in contract, strict liability,
// zhgc	or tort (including negligence or otherwise) arising in any way out of
// vkhl	the use of this software, even if advised of the possibility of such damage.
// csvv	
// zsay	Intelligent Systems Laboratory (iSys Lab)
// yldo	Faculty of Engineering, Prince of Songkla University, THAILAND
// wwsj	Project leader by Nikom SUVONVORN
// dfkl	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
    public partial class VsPropertyControl : UserControl
    {
        private VsLiveviewTool vsMonitor;
        private VsCoreServer vsCoreMonitor;
        public event VsMonitorEventHandler vsUpdateEvent;

        private Thread thread;
        private ManualResetEvent stopEvent = null;
        private VsDeviceType vsPropertyType;
        private String vsTypeName;
        VsCamera vsCamera;
        VsChannel vsChannel;
        VsPage vsPage;

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

        public VsPropertyControl()
        {
            InitializeComponent();

            this.Enabled = false;

            // create events
            stopEvent = new ManualResetEvent(false);

            // create and start new thread
            thread = new Thread(new ThreadStart(WorkerThread));
            thread.Name = "VsPropertyControl";
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Stop();

            if (disposing)
            {

                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Stop the pool
        public void Stop()
        {
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
                // wait for thread stop
                thread.Join();

                thread = null;

                // release events
                stopEvent.Close();
                stopEvent = null;
            }
        }

        // receive message from other window
        void vsMonitor_vsUpdateEvent(object sender, VsMonitorEventArgs e)
        {
            if (e.Parameters.EventTo == VsAppControlType.APP_ALL || 
                e.Parameters.EventTo == VsAppControlType.APP_PROPERTY)
            {
                try { this.Invoke(new VsMonitorEventHandler(vsPropertyControl_Update), sender, e); }
                catch { }
            }
        }

        // invoked method
        void vsPropertyControl_Update(object sender, VsMonitorEventArgs e)
        {
            ActivatePropertyControl(e.Parameters.Device, e.Parameters.DeviceName);
        }

        void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            String selectedTab = e.TabPage.Text;
            if (selectedTab.Length == 0) return;

            switch (selectedTab)
            {
                case "Controller":
                    ControllerProperty();
                    break;
                case "Streamer":
                    StreamerProperty();
                    break;
                case "Provider":
                    ProviderProperty();
                    break;
                case "Analyzer":
                    AnalyzerProperty();
                    break;
                case "Recorder":
                    RecorderProperty();
                    break;
            }
        }

        private void StreamerProperty()
        {
        }

        #region Camera Property

        private void ControllerProperty()
        {
        }        
        
        private void ProviderProperty()
        {
        }

        private void AnalyzerProperty()
        {
        }

        private void RecorderProperty()
        {
        }

        private void CameraProperty()
        {
            this.label1.Text = vsTypeName;
            this.buttonRecorder.Show();
            this.buttonRecorderStatus.Show();
            // get camera
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(this.vsTypeName);
            if (vsCamera == null) return;

            // connecter button
            if (vsCamera.Running)
            {
                this.buttonConnectorStatus.BackColor = Color.Red;
                this.buttonStreamer.Enabled = true;
                this.buttonRecorder.Enabled = true;
            }
            else
            {
                this.buttonConnectorStatus.BackColor = Color.Green;
                this.buttonStreamer.Enabled = false;
                this.buttonRecorder.Enabled = false;
            }

            // recorder button
            if (vsCamera.Recording)
            {
                this.buttonRecorderStatus.BackColor = Color.Red;
            }
            else
            {
                this.buttonRecorderStatus.BackColor = Color.Green;
            }
        }
        
        #endregion

        #region Channel Property

        private void ChannelProperty()
        {
            // text define
            this.label1.Text = "Properties : " + "\"" + vsTypeName + "\"";

            // enable/disable button
            this.buttonRecorder.Show();
            this.buttonRecorderStatus.Show();

            // get channel
            VsChannel vsChannel = vsCoreMonitor.GetChannelByName(this.vsTypeName);
            if (vsChannel == null) return;

            // connecter button
            if (vsChannel.Running)
                this.buttonConnecter.Text = "Stop Channel";
            else this.buttonConnecter.Text = "Start Channel";

            // streamer button
            if (vsChannel.Streaming)
                this.buttonStreamer.Text = "Stop Streamer";
            else this.buttonStreamer.Text = "Start Streamer";
        }
        
        #endregion

        #region Page Property

        private void PageProperty()
        {
            // text define
            //this.tabPageCamera.Text = "Page";
            this.label1.Text = "Properties : " + "\"" + vsTypeName + "\"";

            // enable/disable control
            this.buttonRecorder.Hide();
            this.buttonRecorderStatus.Hide();

            // get channel
            VsPage vsPage = vsCoreMonitor.GetPageByName(this.vsTypeName);
            if (vsPage == null) return;

            // connecter button
            if (vsPage.Running)
                this.buttonConnecter.Text = "Stop Page";
            else this.buttonConnecter.Text = "Start Page";

            // streamer button
            if (vsPage.Streaming)
                this.buttonStreamer.Text = "Stop Streamer";
            else this.buttonStreamer.Text = "Start Streamer";

            this.Enabled = false;
        }
        
        #endregion

        public void ActivatePropertyControl(VsDeviceType propType, String propName)
        {
            vsPropertyType = propType;
            vsTypeName = propName;

            this.Enabled = true;

            switch (vsPropertyType)
            {
                case VsDeviceType.CAMERA:
                    CameraProperty();
                    this.vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
                    break;
                case VsDeviceType.CHANNEL:
                    ChannelProperty();
                    this.vsChannel = vsCoreMonitor.GetChannelByName(vsTypeName);
                    break;
                case VsDeviceType.PAGE:
                    PageProperty();
                    this.vsPage = vsCoreMonitor.GetPageByName(vsTypeName);
                    break;
            }
        }

        private void buttonConnecter_Click(object sender, EventArgs e)
        {
            switch (vsPropertyType)
            {
                case VsDeviceType.CAMERA:
                    {
                        this.vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);

                        if (vsCamera == null) return;
                        if (vsCamera.Running)
                            vsCoreMonitor.DisconnectCamera(vsTypeName);
                        else vsCoreMonitor.ConnectCamera(vsTypeName, false);                     
                    }
                    break;
                case VsDeviceType.CHANNEL:
                    {
                        this.vsChannel = vsCoreMonitor.GetChannelByName(vsTypeName);
                        if (vsChannel == null) return;
                        if (vsChannel.Running)
                            vsCoreMonitor.DisconnectChannel(vsTypeName);
                        else vsCoreMonitor.ConnectChannel(vsTypeName, false);
                    }
                    break;
                case VsDeviceType.PAGE:
                    {
                        this.vsPage = vsCoreMonitor.GetPageByName(vsTypeName);
                        if (vsPage == null) return;
                        if (vsPage.Running)
                            vsCoreMonitor.DisconnectPage(vsTypeName);
                        else vsCoreMonitor.ConnectPage(vsTypeName, false);
                    }
                    break;
            }
        }

        private void buttonStreamer_Click(object sender, EventArgs e)
        {
            switch (vsPropertyType)
            {
                case VsDeviceType.CAMERA:
                    {
                        VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
                        if (vsCamera == null) return;
                        vsCamera.Streaming = !vsCamera.Streaming;
                        ActivatePropertyControl(VsDeviceType.CAMERA, vsTypeName);
                    }
                    break;
                case VsDeviceType.CHANNEL:
                    {
                        VsChannel vsChannel = vsCoreMonitor.GetChannelByName(vsTypeName);
                        if (vsChannel == null) return;

                        if (vsChannel.Streaming)
                            vsCoreMonitor.StopStreamChannel(vsTypeName);
                        else
                            vsCoreMonitor.StartStreamChannel(vsTypeName, textIp.Text, int.Parse(textPort.Text));
                        ActivatePropertyControl(VsDeviceType.CHANNEL, vsTypeName);
                    }
                    break;
                case VsDeviceType.PAGE:
                    {
                        VsPage vsPage = vsCoreMonitor.GetPageByName(vsTypeName);
                        if (vsPage == null) return;
                        vsPage.Streaming = !vsPage.Streaming;
                        ActivatePropertyControl(VsDeviceType.PAGE, vsTypeName);
                    }
                    break;
            }
        }
        
        private void buttonAnalyzer_Click(object sender, EventArgs e)
        {
            switch (vsPropertyType)
            {
                case VsDeviceType.CAMERA:
                    {
                        VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
                        if (vsCamera == null) return;
                        vsCamera.Analysing = !vsCamera.Analysing;
                        ActivatePropertyControl(VsDeviceType.CAMERA, vsTypeName);
                    }
                    break;
                case VsDeviceType.CHANNEL:
                    {
                        VsChannel vsChannel = vsCoreMonitor.GetChannelByName(vsTypeName);
                        if (vsChannel == null) return;
                        vsChannel.Analysing = !vsChannel.Analysing;
                        ActivatePropertyControl(VsDeviceType.CHANNEL, vsTypeName);
                    }
                    break;
            }

        }

        private void buttonRecorder_Click(object sender, EventArgs e)
        {
            buttonAnalyzer_Click(sender, e);

            switch (vsPropertyType)
            {
                case VsDeviceType.CAMERA:
                    {
                        VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
                        if (vsCamera == null) return;
                        vsCamera.Recording = !vsCamera.Recording;
                        ActivatePropertyControl(VsDeviceType.CAMERA, vsTypeName);
                    }
                    break;
                case VsDeviceType.CHANNEL:
                    {
                        VsChannel vsChannel = vsCoreMonitor.GetChannelByName(vsTypeName);
                        if (vsChannel == null) return;
                        vsChannel.Recording = !vsChannel.Recording;
                        ActivatePropertyControl(VsDeviceType.CHANNEL, vsTypeName);
                    }
                    break;
            }

        }

        private void buttonDataAlert_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.DataAlerting = !vsCamera.DataAlerting;
            ActivatePropertyControl(VsDeviceType.CAMERA, vsTypeName);
        }

        private void buttonEventAlert_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.EventAlerting = !vsCamera.EventAlerting;
            ActivatePropertyControl(VsDeviceType.CAMERA, vsTypeName);

            if(vsCamera.EventAlerting)
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsAlarmParas(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_ALARM, VsDeviceType.CAMERA, vsTypeName, VsAlarmType.ALARM_ATTACH)));
            else
                this.vsUpdateEvent(this, new VsMonitorEventArgs(
                    new VsAlarmParas(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_ALARM, VsDeviceType.CAMERA, vsTypeName, VsAlarmType.ALARM_DETACH)));
        }

        // Worker thread entry point
        private void WorkerThread()
        {
            bool swapColor = true;
            bool connectStatus = false;

            while (!stopEvent.WaitOne(0, true))
            {
                Thread.Sleep(500);

                if (vsTypeName != null)
                {
                    switch (vsPropertyType)
                    {
                        case VsDeviceType.CAMERA:
                            {
                                if (vsCamera == null) continue;
                                if (vsCamera.Running)
                                {
                                    if (swapColor) this.buttonConnectorStatus.BackColor = Color.Red;
                                    else this.buttonConnectorStatus.BackColor = Color.Yellow;
                                    connectStatus = true;
                                }
                                else
                                {
                                    this.buttonConnectorStatus.BackColor = Color.Green;
                                    connectStatus = false;
                                }

                                Thread.Sleep(500);

                                if (connectStatus != vsCamera.Running)
                                {
                                    connectStatus = vsCamera.Running;

                                    // update property control
                                    this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                        new VsParameter(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_PROPERTY, VsDeviceType.CAMERA, vsTypeName)));
                                    // update application control
                                    this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                        new VsParameter(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_APPICATION, VsDeviceType.CAMERA, vsTypeName)));
                                    
                                    // update viewer control
                                    if (connectStatus)
                                    {
                                        this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                            new VsViewerParas(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_SIGLEVIEW, VsDeviceType.CAMERA, vsTypeName, VsViewerType.VIEW_OPEN)));
                                    }
                                    else
                                    {
                                        this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                            new VsViewerParas(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_SIGLEVIEW, VsDeviceType.CAMERA, vsTypeName, VsViewerType.VIEW_CLOSE)));
                                    }
                                }

                                break;
                           }
                        case VsDeviceType.CHANNEL:
                            {
                                if (vsChannel == null) continue;
                                if (vsChannel.Running)
                                {
                                    if (swapColor) this.buttonConnectorStatus.BackColor = Color.Red;
                                    else this.buttonConnectorStatus.BackColor = Color.Yellow;
                                    connectStatus = true;
                                }
                                else
                                {
                                    this.buttonConnectorStatus.BackColor = Color.Green;
                                    connectStatus = false;
                                }

                                Thread.Sleep(500);

                                if (connectStatus != vsChannel.Running)
                                {
                                    connectStatus = vsChannel.Running;

                                    // update property control
                                    this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                        new VsParameter(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_PROPERTY, VsDeviceType.CHANNEL, vsTypeName)));

                                    // update application control
                                    this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                        new VsParameter(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_APPICATION, VsDeviceType.CHANNEL, vsTypeName)));

                                    // update viewer control
                                    if (connectStatus)
                                        this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                            new VsViewerParas(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_SIGLEVIEW, VsDeviceType.CHANNEL, vsTypeName, VsViewerType.VIEW_OPEN)));
                                    else
                                        this.vsUpdateEvent(this, new VsMonitorEventArgs(
                                            new VsViewerParas(VsAppControlType.APP_PROPERTY, VsAppControlType.APP_SIGLEVIEW, VsDeviceType.CHANNEL, vsTypeName, VsViewerType.VIEW_CLOSE)));                                
                                }
                                break;
                            }
                    }
                }

                swapColor = !swapColor;
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.PanLeft();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.PanRight();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.TiltUp();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.TiltDown();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.GoHome();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.ZoomIn();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            VsCamera vsCamera = vsCoreMonitor.GetCameraByName(vsTypeName);
            if (vsCamera == null) return;
            vsCamera.ZoomOut();
        }
    }
}
