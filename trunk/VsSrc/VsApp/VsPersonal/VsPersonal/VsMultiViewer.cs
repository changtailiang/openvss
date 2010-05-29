// nsoe	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ynru	
// eufb	 By downloading, copying, installing or using the software you agree to this license.
// forl	 If you do not agree to this license, do not download, install,
// sutb	 copy or use the software.
// nnmv	
// ryvu	                          License Agreement
// kjpt	         For OpenVSS - Open Source Video Surveillance System
// yood	
// eaoa	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// krod	
// ffcd	Third party copyrights are property of their respective owners.
// wnne	
// fyla	Redistribution and use in source and binary forms, with or without modification,
// ftma	are permitted provided that the following conditions are met:
// swju	
// fmdr	  * Redistribution's of source code must retain the above copyright notice,
// aohs	    this list of conditions and the following disclaimer.
// ftrw	
// yjpm	  * Redistribution's in binary form must reproduce the above copyright notice,
// vsyx	    this list of conditions and the following disclaimer in the documentation
// wkna	    and/or other materials provided with the distribution.
// coxl	
// nnin	  * Neither the name of the copyright holders nor the names of its contributors 
// itxt	    may not be used to endorse or promote products derived from this software 
// blch	    without specific prior written permission.
// gvym	
// hpbv	This software is provided by the copyright holders and contributors "as is" and
// daez	any express or implied warranties, including, but not limited to, the implied
// ymyu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ydol	In no event shall the Prince of Songkla University or contributors be liable 
// qves	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kdoe	(including, but not limited to, procurement of substitute goods or services;
// mvkk	loss of use, data, or profits; or business interruption) however caused
// pqqa	and on any theory of liability, whether in contract, strict liability,
// mbtn	or tort (including negligence or otherwise) arising in any way out of
// mbhn	the use of this software, even if advised of the possibility of such damage.
// iipv	
// vcvy	Intelligent Systems Laboratory (iSys Lab)
// wrrl	Faculty of Engineering, Prince of Songkla University, THAILAND
// qgcd	Project leader by Nikom SUVONVORN
// bxjh	Project website at http://code.google.com/p/openvss/

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
                this.vsCameraViewer1
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
            int cols = 1;
            int offset = 0;
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
