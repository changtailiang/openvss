// iyqc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ftsk	
// ekrr	 By downloading, copying, installing or using the software you agree to this license.
// izor	 If you do not agree to this license, do not download, install,
// kbwy	 copy or use the software.
// jrcq	
// iupk	                          License Agreement
// knbu	         For OpenVSS - Open Source Video Surveillance System
// jvom	
// qhqt	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jzoo	
// epgw	Third party copyrights are property of their respective owners.
// oeaz	
// opbr	Redistribution and use in source and binary forms, with or without modification,
// wzul	are permitted provided that the following conditions are met:
// dizr	
// jxin	  * Redistribution's of source code must retain the above copyright notice,
// kbbc	    this list of conditions and the following disclaimer.
// kdoj	
// dnmt	  * Redistribution's in binary form must reproduce the above copyright notice,
// nsvg	    this list of conditions and the following disclaimer in the documentation
// mbgt	    and/or other materials provided with the distribution.
// txqq	
// nfpb	  * Neither the name of the copyright holders nor the names of its contributors 
// zxfh	    may not be used to endorse or promote products derived from this software 
// htln	    without specific prior written permission.
// dxol	
// broi	This software is provided by the copyright holders and contributors "as is" and
// maxk	any express or implied warranties, including, but not limited to, the implied
// mteh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qpun	In no event shall the Prince of Songkla University or contributors be liable 
// lkpf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// onjf	(including, but not limited to, procurement of substitute goods or services;
// iflu	loss of use, data, or profits; or business interruption) however caused
// hido	and on any theory of liability, whether in contract, strict liability,
// mvsb	or tort (including negligence or otherwise) arising in any way out of
// jiem	the use of this software, even if advised of the possibility of such damage.
// ieog	
// syqs	Intelligent Systems Laboratory (iSys Lab)
// yybs	Faculty of Engineering, Prince of Songkla University, THAILAND
// hjwn	Project leader by Nikom SUVONVORN
// iizh	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Vs.Core.Server;

namespace Vs.Monitor
{
    // monitor event delegate
    public delegate void VsMonitorEventHandler(object sender, VsMonitorEventArgs e);

    // application control type
    public enum VsAppControlType
    {
        APP_ALL = 0,
        APP_APPICATION,
        APP_PROPERTY,
        APP_ALARM,
        APP_MONITOR,
        APP_SIGLEVIEW,
        APP_MULTIVIEW
    }

    // device type
    public enum VsDeviceType
    {
        CAMERA = 0,
        CHANNEL,
        PAGE
    }

    // viewer type
    public enum VsViewerType
    {
        VIEW_STATUS = 0,
        VIEW_OPEN,
        VIEW_CLOSE,
        VIEW_ATTACH_RECEIVER,
        VIEW_ATTACH_ANALYZER
    }

    // alarm type
    public enum VsAlarmType
    {
        ALARM_ATTACH = 0,
        ALARM_DETACH
    }

    // message type
    public enum VsMessageType
    {
        MSG_NORMAL = 0,
        MSG_VIEWER_STYLE,
        MSG_ALARM_STYLE
    }

    public partial class VsLiveviewTool : UserControl
    {
        private VsMonitor vsMonitor;
        private VsCoreServer vsCoreMonitor;

        public event VsMonitorEventHandler vsUpdateEvent;

        public VsLiveviewTool()
        {
            InitializeComponent();
            this.vsUpdateEvent += new VsMonitorEventHandler(VsMonitor_vsUpdateEvent);
        }

        public VsMonitor Monitor
        {
            set 
            { 
                vsMonitor = value;
                // set reference to application control
                vsApplicationControl1.Monitor = this;
                vsApplicationControl1.CoreMonitor = vsCoreMonitor;

                // set reference to property control
                vsPropertyControl1.Monitor = this;
                vsPropertyControl1.CoreMonitor = vsCoreMonitor;

                // set reference to property control
                vsMultiViewer1.Monitor = this;
                vsMultiViewer1.CoreMonitor = vsCoreMonitor;

                // viewing initialization
                vsMultiViewer1.InitialCameraView();
            }
        }

        public VsCoreServer CoreMonitor
        {
            set { vsCoreMonitor = value; }
        }

        // update event between any views in application
        void VsMonitor_vsUpdateEvent(object sender, VsMonitorEventArgs e)
        {
            if (e.Parameters.EventTo == VsAppControlType.APP_MONITOR ||
                e.Parameters.EventTo == VsAppControlType.APP_ALL)
            {
                // TODO : 
            }
        }

        // event re-transmetter
        public void VsMonitor_vsUpdateEventAlls(object sender, VsMonitorEventArgs e)
        {
            this.vsUpdateEvent(sender, e);
        }

        private void actionSingleView_Click(object sender, EventArgs e)
        {
            vsMultiViewer1.SingleView();
        }

        private void actionMultiView_Click(object sender, EventArgs e)
        {
            vsMultiViewer1.MultiView();
        }

        private void actionPlus_Click(object sender, EventArgs e)
        {
            vsMultiViewer1.ViewPlus();
        }

        private void actionMinus_Click(object sender, EventArgs e)
        {
            vsMultiViewer1.ViewMinus();
        }
    }

    // parameters based-class
    public class VsParameter
    {
        public VsAppControlType EventFrom;
        public VsAppControlType EventTo;
        public VsDeviceType Device;
        public VsMessageType MsgType = VsMessageType.MSG_NORMAL;
        public String DeviceName;

        public VsParameter(VsAppControlType eventFrom, VsAppControlType eventTo, VsDeviceType device, String deviceName)
        {
            EventFrom = eventFrom;
            EventTo = eventTo;
            Device = device;
            DeviceName = deviceName;
        }
    }

    // viewer class
    public class VsViewerParas : VsParameter
    {
        public VsViewerType ViewerParas;

        public VsViewerParas(VsAppControlType eventFrom, VsAppControlType eventTo, VsDeviceType device,
            String deviceName, VsViewerType viewerParas)
            : base(eventFrom, eventTo, device, deviceName)
        {
            MsgType = VsMessageType.MSG_VIEWER_STYLE;
            ViewerParas = viewerParas;
        }
    }

    // alarm class
    public class VsAlarmParas : VsParameter
    {
        public VsAlarmType AlarmParas;

        public VsAlarmParas(VsAppControlType eventFrom, VsAppControlType eventTo, VsDeviceType device,
            String deviceName, VsAlarmType alarmParas)
            : base(eventFrom, eventTo, device, deviceName)
        {
            MsgType = VsMessageType.MSG_ALARM_STYLE;
            AlarmParas = alarmParas;
        }
    }

    // Monitor event arguments
    public class VsMonitorEventArgs : EventArgs
    {
        VsParameter vsParameters;

        // Constructor
        public VsMonitorEventArgs(VsParameter vsParas)
        {
            vsParameters = vsParas;
        }

        public VsParameter Parameters
        {
            get { return vsParameters; }
        }
    }
}



