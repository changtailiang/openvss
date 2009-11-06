// esht	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cpzb	
// evax	 By downloading, copying, installing or using the software you agree to this license.
// ryju	 If you do not agree to this license, do not download, install,
// mgcm	 copy or use the software.
// vjvx	
// lhza	                          License Agreement
// vpud	         For OpenVss - Open Source Video Surveillance System
// ihoz	
// gzbd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// njxn	
// moyh	Third party copyrights are property of their respective owners.
// mjzk	
// fekv	Redistribution and use in source and binary forms, with or without modification,
// wkhu	are permitted provided that the following conditions are met:
// pyfo	
// awok	  * Redistribution's of source code must retain the above copyright notice,
// jjon	    this list of conditions and the following disclaimer.
// eyym	
// lilw	  * Redistribution's in binary form must reproduce the above copyright notice,
// jsnl	    this list of conditions and the following disclaimer in the documentation
// qkye	    and/or other materials provided with the distribution.
// wtdw	
// rgop	  * Neither the name of the copyright holders nor the names of its contributors 
// dimp	    may not be used to endorse or promote products derived from this software 
// anxd	    without specific prior written permission.
// vmfh	
// gyjn	This software is provided by the copyright holders and contributors "as is" and
// yllw	any express or implied warranties, including, but not limited to, the implied
// kuyq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ykoq	In no event shall the Prince of Songkla University or contributors be liable 
// gsvx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jjid	(including, but not limited to, procurement of substitute goods or services;
// wvwv	loss of use, data, or profits; or business interruption) however caused
// vkqd	and on any theory of liability, whether in contract, strict liability,
// erxx	or tort (including negligence or otherwise) arising in any way out of
// jpxg	the use of this software, even if advised of the possibility of such damage.

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
    public partial class SystemConfig : UserControl
    {
        VsInstallControl control;

        //0=> ยังไม่เริมทำ
        //1=> ทำสำเร็จ
        //-1=> ทำไม่สำเร็จ
        //2=> ไปยัง state ต่อไป
        //3=> ทำไม่สำเร็จแต่ไปต่อได้

        int createDBState = 0;

        int createVDforServiceState = 0;
        int createVDforVideoDataState = 0;

        int updateWebConfigState = 0;
        int updateAppConfigState = 0;
        int updateSystemConfigState = 0;

        int installVsServiceState = 0;
        int runVsServiceState = 0;

        public SystemConfig(VsInstallControl control)
        {
            this.control = control;
            InitializeComponent();

            createDB();
        }

        #region method working
        private void createDB()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);

                if (control.createDB())
                {
                    createDBState = 1;
                }
                else
                {
                    createDBState = -1;
                }

            });
            timer1.Start();
            t.Start();
        }


        private void createVDforService()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.createVirtualDirForService())
                    {
                        createVDforServiceState = 1;
                    }
                    else
                    {
                        createVDforServiceState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    createVDforServiceState = 3;
                }

            });
            timer1.Start();
            t.Start();
        }

        private void createVDforVideoData()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.createVirtualDirForVideoData())
                    {
                        createVDforVideoDataState = 1;
                    }
                    else
                    {
                        createVDforVideoDataState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    createVDforVideoDataState = 3;
                }

            });
            timer1.Start();
            t.Start();
        }
    
        private void updateWebConfig()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.updateWebServiceConfiguration())
                    {
                        updateWebConfigState = 1;
                    }
                    else
                    {
                        updateWebConfigState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    updateWebConfigState = -1;
                }

            });
            timer1.Start();
            t.Start();
        }
        
        private void updateAppConfig()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.updateAppConfiguration())
                    {
                        updateAppConfigState = 1;
                    }
                    else
                    {
                        updateAppConfigState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    updateAppConfigState = -1;
                }

            });
            timer1.Start();
            t.Start();
        }

        private void updateSystemConfig()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.updateSystemConfig())
                    {
                        updateSystemConfigState = 1;
                    }
                    else
                    {
                        updateSystemConfigState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    updateSystemConfigState = -1;
                }

            });
            timer1.Start();
            t.Start();
        }

        private void installVsService()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.installVsWinService())
                    {
                        installVsServiceState = 1;
                    }
                    else
                    {
                        installVsServiceState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    installVsServiceState = -1;
                }

            });
            timer1.Start();
            t.Start();
        }

        private void runVsService()
        {
            Thread t = new Thread(() =>
            {
                // Thread.Sleep(500);
                try
                {
                    if (control.runVsWinService())
                    {
                        runVsServiceState = 1;
                    }
                    else
                    {
                        runVsServiceState = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    runVsServiceState = -1;
                }

            });
            timer1.Start();
            t.Start();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region//create database check
            if (createDBState == 1)
            {
                checkBox1.Checked = true;
                createDBState = 2;
                checkBox1.BackColor = Color.FromArgb(192, 255, 192);

                //call next state
                createVDforService();

                return;
            }
            else if (createDBState < 0)
            {
                timer1.Stop();
                checkBox1.BackColor = Color.Red;
                MessageBox.Show("error ");
                createDBState = 0;

                // errer();
            }

            #endregion //---------------------------

            #region//create virdir for service check
            if (createVDforServiceState == 1)
            {
                checkBox2.Checked = true;
                createVDforServiceState = 2;
                checkBox2.BackColor = Color.FromArgb(192, 255, 192);

                createVDforVideoData();

                return;
            } 
            else if (createVDforServiceState == 3)
            {
                checkBox2.Checked = true;
                createVDforServiceState = 2;
               
                createVDforVideoData();

                return;
            }
            else if (createVDforServiceState < 0)
            {
                timer1.Stop();
                checkBox2.BackColor = Color.Red;
                MessageBox.Show("error createVDforService()");
            
                createVDforServiceState = 0;
                //createVDforVideoData();

            }
            #endregion//-----------------

            #region//create virdir for video data check
            if (createVDforVideoDataState == 1)
            {
                checkBox3.Checked = true;
                createVDforVideoDataState = 2;
                checkBox3.BackColor = Color.FromArgb(192, 255, 192);
                //testingSuccess();
                updateWebConfig();
            }
           else if (createVDforVideoDataState == 3)
            {
                checkBox3.Checked = true;
                createVDforVideoDataState = 2;

                updateWebConfig();
                //testingSuccess();
            }
            else if (createVDforVideoDataState < 0)
            {
                timer1.Stop();
                checkBox3.BackColor = Color.Red;
                MessageBox.Show("error createVDforVideoData()");
                createVDforVideoDataState = 0;
            }
            #endregion

            #region// update Web config check

            if (updateWebConfigState == 1)
            {
                checkBox4.Checked = true;
                updateWebConfigState = 2;
                checkBox4.BackColor = Color.FromArgb(192, 255, 192);

                updateAppConfig();
            }

            else if (updateWebConfigState == -1)
            {
                timer1.Stop();
                checkBox4.BackColor = Color.Red;
                MessageBox.Show("error ");
                updateWebConfigState = 0;
            }
            #endregion
      
            #region// update App config check

            if (updateAppConfigState == 1)
            {
                checkBox5.Checked = true;
                updateAppConfigState = 2;
                checkBox5.BackColor = Color.FromArgb(192, 255, 192);

                updateSystemConfig();
            }

            else if (updateAppConfigState == -1)
            {
                timer1.Stop();
                checkBox5.BackColor = Color.Red;
                MessageBox.Show("error App config");
                updateAppConfigState = 0;
            }
            #endregion

            #region// update System config check

            if (updateSystemConfigState == 1)
            {
                checkBox6.Checked = true;
                updateSystemConfigState = 2;
                checkBox6.BackColor = Color.FromArgb(192, 255, 192);

                installVsService();
            }

            else if (updateSystemConfigState == -1)
            {
                timer1.Stop();
                checkBox6.BackColor = Color.Red;
                MessageBox.Show("error System config");
                updateSystemConfigState =0;
            }
            #endregion

            #region// install win service check

            if (installVsServiceState == 1)
            {
                checkBox7.Checked = true;
                installVsServiceState = 2;
                checkBox7.BackColor = Color.FromArgb(192, 255, 192);

                runVsService();
            }

            else if (installVsServiceState == -1)
            {
                timer1.Stop();
                checkBox7.BackColor = Color.Red;
                MessageBox.Show("error install win service");
                installVsServiceState = 0;
            }
            #endregion

            #region// run win service check

            if (runVsServiceState == 1)
            {
                checkBox8.Checked = true;
                runVsServiceState = 2;
                checkBox8.BackColor = Color.FromArgb(192, 255, 192);


                configStateSuccess();
            }

            else if (runVsServiceState == -1)
            {
                timer1.Stop();
                checkBox8.BackColor = Color.Red;
                MessageBox.Show("error System config");
                runVsServiceState = 0;
            }
            #endregion
        }

        private void configStateSuccess()
        {
            button1.Enabled = true;
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            control.createPlaybackShortCut();
            control.exitSetup(State.config);
        }

    }
}
