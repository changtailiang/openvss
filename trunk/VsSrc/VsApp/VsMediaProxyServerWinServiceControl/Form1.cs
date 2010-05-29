// lfcr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rtwp	
// dxyl	 By downloading, copying, installing or using the software you agree to this license.
// qgdn	 If you do not agree to this license, do not download, install,
// dgjb	 copy or use the software.
// jfln	
// ccsg	                          License Agreement
// tuix	         For OpenVSS - Open Source Video Surveillance System
// jbxq	
// hcux	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xgpq	
// juus	Third party copyrights are property of their respective owners.
// tbfp	
// geuf	Redistribution and use in source and binary forms, with or without modification,
// toop	are permitted provided that the following conditions are met:
// aqvi	
// oacp	  * Redistribution's of source code must retain the above copyright notice,
// jnfb	    this list of conditions and the following disclaimer.
// mldc	
// pvei	  * Redistribution's in binary form must reproduce the above copyright notice,
// hzms	    this list of conditions and the following disclaimer in the documentation
// ptqe	    and/or other materials provided with the distribution.
// grwt	
// oexh	  * Neither the name of the copyright holders nor the names of its contributors 
// lhbi	    may not be used to endorse or promote products derived from this software 
// sejg	    without specific prior written permission.
// wecu	
// bspy	This software is provided by the copyright holders and contributors "as is" and
// kgha	any express or implied warranties, including, but not limited to, the implied
// edsu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kxir	In no event shall the Prince of Songkla University or contributors be liable 
// rmmh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// owri	(including, but not limited to, procurement of substitute goods or services;
// tvqd	loss of use, data, or profits; or business interruption) however caused
// qgvl	and on any theory of liability, whether in contract, strict liability,
// qwdn	or tort (including negligence or otherwise) arising in any way out of
// byii	the use of this software, even if advised of the possibility of such damage.
// wwch	
// phyu	Intelligent Systems Laboratory (iSys Lab)
// vrok	Faculty of Engineering, Prince of Songkla University, THAILAND
// ruge	Project leader by Nikom SUVONVORN
// bheo	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace VsMediaProxyServerWinServiceControl
{
    public partial class VsMediaProxyServerWinServiceControl : Form
    {
        string serviceName = "VsMediaProxyServerWinService";
        string serviceFileName = "VsMediaProxyServerWinService.exe";
        public VsMediaProxyServerWinServiceControl()
        {
            System.IO.Directory.SetCurrentDirectory(
              System.IO.Path.GetDirectoryName(
              System.Reflection.Assembly.GetExecutingAssembly().Location));

            InitializeComponent();
        }

        public bool installVsWinService()
        {
            try
            {
                unInstallVsWinService();
                string para = "\"" + serviceFileName + "\"";

                return runFileExe(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\installutil.exe", para, false);


                //runFileExe("NET", "START VsService", false);
            }
            catch
            {
                return false;
            }

        }

        public bool unInstallVsWinService()
        {
            try
            {
                string para = "/u " + "\"" +serviceFileName + "\"";
                runFileExe("NET.exe", "STOP  "+serviceName, false);

                return runFileExe(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\installutil.exe", para, false);

            }
            catch
            {
                return false;
            }
        }

        public bool runVsWinService()
        {
            try
            {
                return runFileExe("NET.exe", "START "+serviceName, false);
            }
            catch
            {
                return false;
            }
        }

        public bool stopVsWinService()
        {
            try
            {
                return runFileExe("NET.exe", "STOP  "+serviceName, false);
            }
            catch
            {
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            installVsWinService();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            unInstallVsWinService();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            runVsWinService();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopVsWinService();
        }

        string rootProgramDir = "";
        public bool runFileExe(string cmd, string para, bool hiddenCmd)
        {
            try
            {
                Process myProgram = new Process(); //Process.Start(cmd, para);

                myProgram.StartInfo.FileName = cmd;
                myProgram.StartInfo.Arguments = para;

                if (hiddenCmd)
                {
                    myProgram.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    myProgram.StartInfo.UseShellExecute = false;
                    myProgram.StartInfo.CreateNoWindow = true;
                    myProgram.EnableRaisingEvents = true;
                }

                myProgram.Start();

                myProgram.WaitForExit();
                myProgram.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
