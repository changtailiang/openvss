// dnaw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vvan	
// nlhh	 By downloading, copying, installing or using the software you agree to this license.
// qdmg	 If you do not agree to this license, do not download, install,
// vraa	 copy or use the software.
// ozpv	
// mtom	                          License Agreement
// pylt	         For OpenVSS - Open Source Video Surveillance System
// ggrs	
// xzpr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// udyt	
// ogwv	Third party copyrights are property of their respective owners.
// rqda	
// dpyd	Redistribution and use in source and binary forms, with or without modification,
// yejb	are permitted provided that the following conditions are met:
// hoyp	
// anak	  * Redistribution's of source code must retain the above copyright notice,
// muiw	    this list of conditions and the following disclaimer.
// cjfl	
// avhg	  * Redistribution's in binary form must reproduce the above copyright notice,
// xsuy	    this list of conditions and the following disclaimer in the documentation
// vlqr	    and/or other materials provided with the distribution.
// hnts	
// pnjf	  * Neither the name of the copyright holders nor the names of its contributors 
// eita	    may not be used to endorse or promote products derived from this software 
// fmix	    without specific prior written permission.
// hhxt	
// jndc	This software is provided by the copyright holders and contributors "as is" and
// wdeo	any express or implied warranties, including, but not limited to, the implied
// uauo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wjcz	In no event shall the Prince of Songkla University or contributors be liable 
// bqgo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zahs	(including, but not limited to, procurement of substitute goods or services;
// cgal	loss of use, data, or profits; or business interruption) however caused
// jxqo	and on any theory of liability, whether in contract, strict liability,
// nwhu	or tort (including negligence or otherwise) arising in any way out of
// kqvm	the use of this software, even if advised of the possibility of such damage.
// ivld	
// oedw	Intelligent Systems Laboratory (iSys Lab)
// jjvr	Faculty of Engineering, Prince of Songkla University, THAILAND
// ajtj	Project leader by Nikom SUVONVORN
// fkaq	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace VsWinServiceControl
{
    public partial class VsWinserviceControl : Form
    {
        public VsWinserviceControl()
        {
            System.IO.Directory.SetCurrentDirectory(
                System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location));
            InitializeComponent();
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

        public bool installVsWinService()
        {
            try
            {
                unInstallVsWinService();
                string para = "\"" + "VsWinService.exe" + "\"";

                return runFileExe(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\installutil.exe", para, false);


                //runFileExe("NET", "START VsService", false);
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
                return runFileExe("NET.exe", "STOP  VsService", false);
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
                string para = "/u " + "\"" + "VsWinService.exe" + "\"";
                runFileExe("NET.exe", "STOP  VsService", false);

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
                return runFileExe("NET.exe", "START VsService", false);
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

        private void button4_Click(object sender, EventArgs e)
        {
            unInstallVsWinService();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            runVsWinService();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopVsWinService();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stopVsWinService();
            runVsWinService();

        }

    }

}
