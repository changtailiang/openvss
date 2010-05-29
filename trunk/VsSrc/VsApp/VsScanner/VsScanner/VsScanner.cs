// tona	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// iwgl	
// cfbs	 By downloading, copying, installing or using the software you agree to this license.
// xbgy	 If you do not agree to this license, do not download, install,
// pfwm	 copy or use the software.
// pznz	
// ifiy	                          License Agreement
// mawt	         For OpenVSS - Open Source Video Surveillance System
// xzor	
// wabs	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ktok	
// wbud	Third party copyrights are property of their respective owners.
// qihc	
// mgft	Redistribution and use in source and binary forms, with or without modification,
// aosc	are permitted provided that the following conditions are met:
// oizc	
// jivx	  * Redistribution's of source code must retain the above copyright notice,
// mobp	    this list of conditions and the following disclaimer.
// eebv	
// ldcg	  * Redistribution's in binary form must reproduce the above copyright notice,
// leid	    this list of conditions and the following disclaimer in the documentation
// stgq	    and/or other materials provided with the distribution.
// uvrh	
// iydc	  * Neither the name of the copyright holders nor the names of its contributors 
// tlan	    may not be used to endorse or promote products derived from this software 
// gwqb	    without specific prior written permission.
// hsyi	
// ejix	This software is provided by the copyright holders and contributors "as is" and
// llrj	any express or implied warranties, including, but not limited to, the implied
// awkq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bedr	In no event shall the Prince of Songkla University or contributors be liable 
// xugf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// azba	(including, but not limited to, procurement of substitute goods or services;
// cpap	loss of use, data, or profits; or business interruption) however caused
// ogva	and on any theory of liability, whether in contract, strict liability,
// vymk	or tort (including negligence or otherwise) arising in any way out of
// mtvw	the use of this software, even if advised of the possibility of such damage.
// htcx	
// bklb	Intelligent Systems Laboratory (iSys Lab)
// syen	Faculty of Engineering, Prince of Songkla University, THAILAND
// lshf	Project leader by Nikom SUVONVORN
// hhvw	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Vs.Core;
using Vs.Core.Server;
using Vs.Core.SystemInfo;
using System.Runtime.InteropServices;
using System.Globalization;
using NLog; 

namespace Vs.Monitor
{
    /// <summary>
    /// Main Application Class
    /// </summary>
    public partial class VsScanner : Form
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private VsCoreServer vsCoreMonitor;
        private FormState formState = new FormState();
        private VsSystemInfo formInfo = new VsSystemInfo();

        public VsScanner()
        {
            InitializeComponent();

            // form load handler
            this.Load += new EventHandler(VsMonitor_Load);
            this.Resize += new EventHandler(VsMonitor_Resize);
            this.FormClosing += new FormClosingEventHandler(VsMonitor_FormClosing);

            try
            {
                // new object
                vsCoreMonitor = new VsCoreServer(Path.GetDirectoryName(Application.ExecutablePath));

                // allow to save all configs to files
                vsCoreMonitor.SaveConfigToFile = true;

                // Initial application core
                vsCoreMonitor.VsMonitorInitial();

                VsSplasher.Status = "Load application setting...";
                System.Threading.Thread.Sleep(1500);

                VsSplasher.Close();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        void VsMonitor_Load(object sender, EventArgs e)
        {
            // set reference to application control
            this.vsLiveviewTool1.CoreMonitor = vsCoreMonitor;
            this.vsLiveviewTool1.Monitor = this;

            this.vsSettingTool1.CoreMonitor = vsCoreMonitor;
            this.vsSettingTool1.Monitor = this;
        }

        void VsMonitor_Resize(object sender, EventArgs e)
        {
            //This code causes the form to not show up on the task bar only in the tray.
            //NOTE there is now a form property that will allow you to keep the 
            //application from every showing up in the task bar.
            if (this == null)
            { //This happen on create.
                return;
            }
            //If we are minimizing the form then hide it so it doesn't show up on the 
            //task bar
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(3000, "Security Surveillance System Server",
                        "The App has be moved to the tray.",
                        ToolTipIcon.Info);
                this.TopMost = false;
            }
            else
            {
                //any other windows state show it.
                this.Show();
            }
        }

        void VsMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            //There are several ways to close an application.
            //We are trying to find the click of the X in the upper right hand corner
            //We will only allow the closing of this app if it is minimized.
            if (this.WindowState != FormWindowState.Minimized)
            {
                //we don't close the app...
                e.Cancel = true;
                //minimize the app and then display a message to the user so
                //they understand they didn't close the app they just sent it to the tray.
                this.WindowState = FormWindowState.Minimized;
                //Show the message.
                notifyIcon1.ShowBalloonTip(3000, "Security Surveillance System Server",
                     "You have not closed this appliation." +
                     (Char)(13) + "It has be moved to the tray." +
                     (Char)(13) + "Right click the Icon to exit.",
                     ToolTipIcon.Info);
            }
            */
        }

        // form close
        void VsMonitor_Close()
        {
            //formState.Restore(this);

            if (vsCoreMonitor != null)
            {
                // disconnect all camera
                vsCoreMonitor.DisconnectCameraAll();

                // Dispose
                vsCoreMonitor.Dispose();

                vsCoreMonitor = null;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            VsMonitor_Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.vsLiveviewTool1.Visible = true;
            this.vsSettingTool1.Visible = false;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.vsLiveviewTool1.Visible = false;
            this.vsSettingTool1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                //formState.Maximize(this);
            }

            // Activate the form.
            this.Activate();
            this.Focus();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VsAboutBox vsAbout = new VsAboutBox();
            this.TopMost = false;
            vsAbout.TopMost = true;
            vsAbout.Show();
        }
    }

    public class WinApi
    {
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64; // 0x0040

        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        public static void SetWinFullScreen(IntPtr hwnd)
        {
            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }
    }

    /// <summary>
    /// Class used to preserve / restore state of the form
    /// </summary>
    public class FormState
    {
        private FormWindowState winState;
        private FormBorderStyle brdStyle;
        private bool topMost;
        private Rectangle bounds;

        private bool IsMaximized = false;

        public void Maximize(Form targetForm)
        {
            if (!IsMaximized)
            {
                IsMaximized = true;
                Save(targetForm);
                targetForm.WindowState = FormWindowState.Maximized;
                targetForm.FormBorderStyle = FormBorderStyle.None;
                targetForm.TopMost = true;
                WinApi.SetWinFullScreen(targetForm.Handle);
            }
        }

        public void Save(Form targetForm)
        {
            winState = targetForm.WindowState;
            brdStyle = targetForm.FormBorderStyle;
            topMost = targetForm.TopMost;
            bounds = targetForm.Bounds;
        }

        public void Restore(Form targetForm)
        {
            targetForm.WindowState = winState;
            targetForm.FormBorderStyle = brdStyle;
            targetForm.TopMost = topMost;
            targetForm.Bounds = bounds;
            IsMaximized = false;
        }
    }
}
