// bupg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lauz	
// oeqv	 By downloading, copying, installing or using the software you agree to this license.
// gvze	 If you do not agree to this license, do not download, install,
// lzws	 copy or use the software.
// lfcl	
// jhxd	                          License Agreement
// lenn	         For OpenVss - Open Source Video Surveillance System
// crbh	
// gpjf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// yxcr	
// etrq	Third party copyrights are property of their respective owners.
// hjzb	
// gtwv	Redistribution and use in source and binary forms, with or without modification,
// sdxd	are permitted provided that the following conditions are met:
// drnk	
// qdto	  * Redistribution's of source code must retain the above copyright notice,
// trxw	    this list of conditions and the following disclaimer.
// qrun	
// ckhp	  * Redistribution's in binary form must reproduce the above copyright notice,
// qgvb	    this list of conditions and the following disclaimer in the documentation
// flgi	    and/or other materials provided with the distribution.
// vfoc	
// rfbg	  * Neither the name of the copyright holders nor the names of its contributors 
// jsba	    may not be used to endorse or promote products derived from this software 
// acwp	    without specific prior written permission.
// lclp	
// yiti	This software is provided by the copyright holders and contributors "as is" and
// winx	any express or implied warranties, including, but not limited to, the implied
// vmee	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wkto	In no event shall the Prince of Songkla University or contributors be liable 
// dvfk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pnek	(including, but not limited to, procurement of substitute goods or services;
// jgpn	loss of use, data, or profits; or business interruption) however caused
// jgqc	and on any theory of liability, whether in contract, strict liability,
// zrkm	or tort (including negligence or otherwise) arising in any way out of
// mggj	the use of this software, even if advised of the possibility of such damage.

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
