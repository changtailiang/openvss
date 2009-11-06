// pdcv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kivl	
// iver	 By downloading, copying, installing or using the software you agree to this license.
// qatf	 If you do not agree to this license, do not download, install,
// ahcg	 copy or use the software.
// qpwz	
// wxiw	                          License Agreement
// hvwk	         For OpenVss - Open Source Video Surveillance System
// atkm	
// amrp	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ifuw	
// qxvv	Third party copyrights are property of their respective owners.
// gvfi	
// krta	Redistribution and use in source and binary forms, with or without modification,
// hdym	are permitted provided that the following conditions are met:
// azen	
// ytrx	  * Redistribution's of source code must retain the above copyright notice,
// qheo	    this list of conditions and the following disclaimer.
// qnxl	
// uzjy	  * Redistribution's in binary form must reproduce the above copyright notice,
// cmpl	    this list of conditions and the following disclaimer in the documentation
// qnaj	    and/or other materials provided with the distribution.
// zjex	
// neoj	  * Neither the name of the copyright holders nor the names of its contributors 
// bhxw	    may not be used to endorse or promote products derived from this software 
// gyfz	    without specific prior written permission.
// qqsx	
// tigh	This software is provided by the copyright holders and contributors "as is" and
// uzko	any express or implied warranties, including, but not limited to, the implied
// kswk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// thxg	In no event shall the Prince of Songkla University or contributors be liable 
// cham	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ynkm	(including, but not limited to, procurement of substitute goods or services;
// bmsd	loss of use, data, or profits; or business interruption) however caused
// gquz	and on any theory of liability, whether in contract, strict liability,
// vcpr	or tort (including negligence or otherwise) arising in any way out of
// dwdn	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace VsSetup
{
    public partial class IIsSetup : UserControl
    {
        //0=> ยังไม่เริมทำ
        //1=> ทำสำเร็จ
        //-1=> ทำไม่สำเร็จ
        //2=> ไปยัง state ต่อไป
        public int iisInstalling = 0;
        public int iisRunign = 0;
        public int iisConfig = 0;

        VsInstallControl control;
        public IIsSetup(VsInstallControl control)
        {
            InitializeComponent();
            this.control = control;

            checkedIIsInstalling();
        }

        public void checkedIIsInstalling()
        {

            Thread t = new Thread(() =>
              {
                  // Thread.Sleep(500);

                  if (control.checkIIsWebServer())
                  {
                      iisInstalling = 1;
                  }
                  else
                  {
                      iisInstalling = -1;
                  }

              });
            timer1.Start();
            t.Start();
        }

        public void checkedIIsRuning()
        {

            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);

                if (control.checkIIsWebServerRuning())
                {
                    iisRunign = 1;
                }
                else
                {
                    iisRunign = -1;
                }

            });
            timer1.Start();
            t.Start();
        }

        public void checkedIIsConfigured()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);

                if(control.configIIs())
                {
                    iisConfig = 1;
                }
                else
                {
                    iisConfig = -1;
                }

            });
            timer1.Start();
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             control.nextState();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region iisInstalling
            if (iisInstalling == 1)
            {
                checkBox1.Checked = true;
                iisInstalling = 2;
                checkBox1.BackColor = Color.FromArgb(192, 255, 192);
                checkedIIsRuning();

                return;
            }
            else if (iisInstalling < 0)
            {
                timer1.Stop();
                checkBox1.BackColor = Color.Red;
                MessageBox.Show("error iisInstalling");
                iisInstalling = 0;

                errer();
            }
            #endregion //---------------------------

            #region iisRunign
            if (iisRunign == 1)
            {
                checkBox2.Checked = true;
                iisRunign = 2;
                checkBox2.BackColor = Color.FromArgb(192, 255, 192);
                checkedIIsConfigured();


                return;
            }
            else if (iisRunign < 0)
            {
                timer1.Stop();
                checkBox2.BackColor = Color.Red;
                MessageBox.Show("error iisRunign");
                iisRunign = 0;

                errer();
            }

            #endregion//-----------------

            #region iisConfig
            if (iisConfig == 1)
            {
                checkBox3.Checked = true;
                iisConfig = 2;
                checkBox3.BackColor = Color.FromArgb(192, 255, 192);
                testingSuccess();
            }
            else if (iisConfig < 0)
            {
                timer1.Stop();
                checkBox3.BackColor = Color.Red;
                MessageBox.Show("error iisConfig");
                iisConfig = 0;
                
                errer();
            }
            #endregion

        }

        private void errer()
        {
            label1.Visible = true;
            button3.Visible = true;
        }

        private void testingSuccess()
        {
            label1.Visible = false;
            button3.Visible = false;  
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.exitSetup(State.iis);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkedIIsInstalling();
        }
    }
}
