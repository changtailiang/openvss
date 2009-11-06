// jnrk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rwns	
// gnjm	 By downloading, copying, installing or using the software you agree to this license.
// ijld	 If you do not agree to this license, do not download, install,
// hwfi	 copy or use the software.
// ixeg	
// wkrl	                          License Agreement
// xety	         For OpenVss - Open Source Video Surveillance System
// zrfo	
// qvlb	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hjmw	
// vnmk	Third party copyrights are property of their respective owners.
// ghdt	
// evtm	Redistribution and use in source and binary forms, with or without modification,
// ilnh	are permitted provided that the following conditions are met:
// ecuc	
// ulmr	  * Redistribution's of source code must retain the above copyright notice,
// dwmm	    this list of conditions and the following disclaimer.
// kdaz	
// liki	  * Redistribution's in binary form must reproduce the above copyright notice,
// xheq	    this list of conditions and the following disclaimer in the documentation
// aztd	    and/or other materials provided with the distribution.
// xtgf	
// hewf	  * Neither the name of the copyright holders nor the names of its contributors 
// ojcj	    may not be used to endorse or promote products derived from this software 
// bvgk	    without specific prior written permission.
// uqja	
// vuaa	This software is provided by the copyright holders and contributors "as is" and
// aekw	any express or implied warranties, including, but not limited to, the implied
// yebu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// riuk	In no event shall the Prince of Songkla University or contributors be liable 
// qheg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hvkc	(including, but not limited to, procurement of substitute goods or services;
// fbhc	loss of use, data, or profits; or business interruption) however caused
// buvj	and on any theory of liability, whether in contract, strict liability,
// qsic	or tort (including negligence or otherwise) arising in any way out of
// sffd	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Monitor
{
    public partial class VsAlarmControl : UserControl, VsEventInterface
    {
        private VsLiveviewTool vsMonitor;
        private VsCoreServer vsCoreMonitor;
        public event VsMonitorEventHandler vsUpdateEvent;

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

        public VsAlarmControl()
        {
            InitializeComponent();
        }

        // update event between any views in application
        void vsMonitor_vsUpdateEvent(object sender, VsMonitorEventArgs e)
        {
            if (e.Parameters.EventTo == VsAppControlType.APP_ALL ||
                e.Parameters.EventTo == VsAppControlType.APP_ALARM &&
                e.Parameters.Device == VsDeviceType.CAMERA)
            {
                try { this.Invoke(new VsMonitorEventHandler(vsAlarm_Update), sender, e); }
                catch { }
            }
        }

        //invoked method
        void vsAlarm_Update(object sender, VsMonitorEventArgs e)
        {
            VsAlarmParas vsAlarmParas = (VsAlarmParas)e.Parameters;
            switch (vsAlarmParas.AlarmParas)
            {
                case VsAlarmType.ALARM_ATTACH:
                    this.vsCoreMonitor.AttachEventView(vsAlarmParas.DeviceName, this);
                    break;
                case VsAlarmType.ALARM_DETACH:
                    this.vsCoreMonitor.DetachEventView(vsAlarmParas.DeviceName, this);
                    break;
            }
        }

        // New frame
        public void FrameIn(object sender, VsMotionEventArgs e)
        {
            this.listView1.Invoke(new VsMotionEventHandler(vsListView_Update), sender, e);
        }

        public void vsListView_Update(object sender, VsMotionEventArgs e)
        {
            VsMotion vsMotion = (VsMotion)e.Motion.Clone();
            
            String [] strItem = {vsMotion.DateStart.ToString(), vsMotion.CameraName, vsMotion.EventName};

            ListViewItem item = new ListViewItem(strItem);
            this.listView1.Items.Add(item);
            item.Selected = true;
            item.EnsureVisible();
        }
    }
}
