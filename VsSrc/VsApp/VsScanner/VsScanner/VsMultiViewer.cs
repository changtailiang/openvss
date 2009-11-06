// wwcm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// efjl	
// lzqz	 By downloading, copying, installing or using the software you agree to this license.
// xjoi	 If you do not agree to this license, do not download, install,
// pmba	 copy or use the software.
// nvxd	
// tltb	                          License Agreement
// getk	         For OpenVss - Open Source Video Surveillance System
// fatg	
// ckax	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// fdjs	
// hqdh	Third party copyrights are property of their respective owners.
// bhwv	
// jaea	Redistribution and use in source and binary forms, with or without modification,
// zyss	are permitted provided that the following conditions are met:
// mheg	
// ffuw	  * Redistribution's of source code must retain the above copyright notice,
// pige	    this list of conditions and the following disclaimer.
// ldvk	
// mewd	  * Redistribution's in binary form must reproduce the above copyright notice,
// ilaz	    this list of conditions and the following disclaimer in the documentation
// iyae	    and/or other materials provided with the distribution.
// vtge	
// rilx	  * Neither the name of the copyright holders nor the names of its contributors 
// ydnb	    may not be used to endorse or promote products derived from this software 
// vgss	    without specific prior written permission.
// brjg	
// fuou	This software is provided by the copyright holders and contributors "as is" and
// bpka	any express or implied warranties, including, but not limited to, the implied
// hfxh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fpaw	In no event shall the Prince of Songkla University or contributors be liable 
// bcnd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// sxli	(including, but not limited to, procurement of substitute goods or services;
// ruhb	loss of use, data, or profits; or business interruption) however caused
// thxr	and on any theory of liability, whether in contract, strict liability,
// ouzb	or tort (including negligence or otherwise) arising in any way out of
// elcb	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
    public partial class VsMultiViewer : System.Windows.Forms.Panel
    {
        private VsLiveviewTool vsMonitor;
        private VsCoreServer vsCoreMonitor;
        public event VsMonitorEventHandler vsUpdateEvent;

        private VsSingleViewer[] vsSingleViewer = new VsSingleViewer[3];

        private const int MULTI_VIEW = 2;
        private int vsCol = MULTI_VIEW;

        public VsLiveviewTool Monitor
        {
            set
            {
                vsMonitor = value;
                vsMonitor.vsUpdateEvent += new VsMonitorEventHandler(vsMonitor_vsUpdateEvent);
                this.vsUpdateEvent += new VsMonitorEventHandler(vsMonitor.VsMonitor_vsUpdateEventAlls);

                foreach (VsSingleViewer cv in vsSingleViewer)
                {
                    cv.Monitor = value;
                }
            }
        }

        public VsCoreServer CoreMonitor
        {
            set
            {
                vsCoreMonitor = value;
                foreach (VsSingleViewer cv in vsSingleViewer)
                {
                    cv.CoreMonitor = value;
                }
            }
        }

        private void InitializeCameraViewer()
        {
            #region Define CameraViewer List

            this.Controls.AddRange(new System.Windows.Forms.Control[] 
            { 
                this.vsFlowLayout
            });

            vsFlowLayout.Controls.AddRange(new System.Windows.Forms.Control[] 
            {   
                this.vsCameraViewer1,
                this.vsCameraViewer2,
                this.vsCameraViewer3
            });

            // cache to list
            vsSingleViewer[0] = vsCameraViewer1;
            vsSingleViewer[1] = vsCameraViewer2;
            vsSingleViewer[2] = vsCameraViewer3;

            #endregion

            vsFlowLayout.Resize += new EventHandler(vsFlowLayout_Resize);
        }

        void vsFlowLayout_Resize(object sender, EventArgs e)
        {
            ViewLayout();
        }

        public VsMultiViewer()
        {
            InitializeComponent();

            InitializeCameraViewer();
        }

        public VsMultiViewer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InitializeCameraViewer();
        }

        // update event between any views in application
        void vsMonitor_vsUpdateEvent(object sender, VsMonitorEventArgs e)
        {
            if (e.Parameters.EventTo == VsAppControlType.APP_ALL ||
                e.Parameters.EventTo == VsAppControlType.APP_MULTIVIEW)
            {
                // TODO : 
            }
        }

        // view camera
        public void InitialCameraView()
        {
            ViewLayout();
        }

        public void SingleView()
        {
            vsCol  = 1;

            ViewLayout();            
        }

        public void MultiView()
        {
            vsCol = MULTI_VIEW;
            ViewLayout();
        }

        public void ViewPlus()
        {
            vsCol++;
            if (vsCol >5) vsCol = 5;

            ViewLayout();
        }

        public void ViewMinus()
        {
            vsCol--;
            if (vsCol < 1) vsCol = 1;

            ViewLayout();
        }

        private void ViewLayout()
        {
            bool first = true;
            int cols = vsCol;
            int offset = 20;
            int width = (this.ClientRectangle.Width/2);
            int height = (this.ClientRectangle.Height/2);

            vsFlowLayout.SuspendLayout();
            foreach (VsSingleViewer cv in vsSingleViewer)
            {
                cv.SuspendLayout();
                if (first)
                {
                    cv.Width = this.ClientRectangle.Width - offset;
                    cv.Height = height;
                    cv.Visible = true;
                    first = false;
                }
                else
                {
                    cv.Width = width - offset/2;
                    cv.Height = height;
                    cv.Visible = true;
                }
                cv.ResumeLayout();
            }
            vsFlowLayout.ResumeLayout();
        }
    }
}
