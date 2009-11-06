// ybsb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ncbd	
// zkrr	 By downloading, copying, installing or using the software you agree to this license.
// kxas	 If you do not agree to this license, do not download, install,
// cspv	 copy or use the software.
// anzl	
// uhja	                          License Agreement
// pbjf	         For OpenVss - Open Source Video Surveillance System
// otmx	
// qmgc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jsck	
// lsui	Third party copyrights are property of their respective owners.
// nagx	
// kpjl	Redistribution and use in source and binary forms, with or without modification,
// cghf	are permitted provided that the following conditions are met:
// tboy	
// amcq	  * Redistribution's of source code must retain the above copyright notice,
// kdbq	    this list of conditions and the following disclaimer.
// mnlh	
// kpzc	  * Redistribution's in binary form must reproduce the above copyright notice,
// mamo	    this list of conditions and the following disclaimer in the documentation
// umuz	    and/or other materials provided with the distribution.
// kbvj	
// eaji	  * Neither the name of the copyright holders nor the names of its contributors 
// eejz	    may not be used to endorse or promote products derived from this software 
// pexj	    without specific prior written permission.
// zqlx	
// dcam	This software is provided by the copyright holders and contributors "as is" and
// hfss	any express or implied warranties, including, but not limited to, the implied
// ozdo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rcfi	In no event shall the Prince of Songkla University or contributors be liable 
// irll	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eccg	(including, but not limited to, procurement of substitute goods or services;
// fami	loss of use, data, or profits; or business interruption) however caused
// cdpe	and on any theory of liability, whether in contract, strict liability,
// bxwi	or tort (including negligence or otherwise) arising in any way out of
// bicz	the use of this software, even if advised of the possibility of such damage.

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

        private VsSingleViewer[] vsSingleViewer = new VsSingleViewer[25];

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
                this.vsCameraViewer3,
                this.vsCameraViewer4,
                this.vsCameraViewer5,
                this.vsCameraViewer6,
                this.vsCameraViewer7,
                this.vsCameraViewer8,
                this.vsCameraViewer9,
                this.vsCameraViewer10,
                this.vsCameraViewer11,
                this.vsCameraViewer12,
                this.vsCameraViewer13,
                this.vsCameraViewer14,
                this.vsCameraViewer15,
                this.vsCameraViewer16,
                this.vsCameraViewer17,
                this.vsCameraViewer18,
                this.vsCameraViewer19,
                this.vsCameraViewer20,
                this.vsCameraViewer21,
                this.vsCameraViewer22,
                this.vsCameraViewer23,
                this.vsCameraViewer24,
                this.vsCameraViewer25
            });

            // cache to list
            vsSingleViewer[0] = vsCameraViewer1;
            vsSingleViewer[1] = vsCameraViewer2;
            vsSingleViewer[2] = vsCameraViewer3;
            vsSingleViewer[3] = vsCameraViewer4;
            vsSingleViewer[4] = vsCameraViewer5;
            vsSingleViewer[5] = vsCameraViewer6;
            vsSingleViewer[6] = vsCameraViewer7;
            vsSingleViewer[7] = vsCameraViewer8;
            vsSingleViewer[8] = vsCameraViewer9;
            vsSingleViewer[9] = vsCameraViewer10;
            vsSingleViewer[10] = vsCameraViewer11;
            vsSingleViewer[11] = vsCameraViewer12;
            vsSingleViewer[12] = vsCameraViewer13;
            vsSingleViewer[13] = vsCameraViewer14;
            vsSingleViewer[14] = vsCameraViewer15;
            vsSingleViewer[15] = vsCameraViewer16;
            vsSingleViewer[16] = vsCameraViewer17;
            vsSingleViewer[17] = vsCameraViewer18;
            vsSingleViewer[18] = vsCameraViewer19;
            vsSingleViewer[19] = vsCameraViewer20;
            vsSingleViewer[20] = vsCameraViewer21;
            vsSingleViewer[21] = vsCameraViewer22;
            vsSingleViewer[22] = vsCameraViewer23;
            vsSingleViewer[23] = vsCameraViewer24;
            vsSingleViewer[24] = vsCameraViewer25;

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
            bool first = false;
            int cols = vsCol;
            int offset = 20;
            int width = (this.ClientRectangle.Width - offset) / cols;
            int height = (3 * width) / 4;

            vsFlowLayout.SuspendLayout();
            foreach (VsSingleViewer cv in vsSingleViewer)
            {
                cv.SuspendLayout();
                if (first)
                {
                    cv.Width = (this.ClientRectangle.Width - offset);
                    cv.Height = height;
                    cv.Visible = true;
                    first = false;
                }
                else
                {
                    cv.Width = width;
                    cv.Height = height;
                    cv.Visible = true;
                }
                cv.ResumeLayout();
            }
            vsFlowLayout.ResumeLayout();
        }
    }
}
