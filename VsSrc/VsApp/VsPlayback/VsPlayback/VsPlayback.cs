// ctsp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zbtm	
// mrxo	 By downloading, copying, installing or using the software you agree to this license.
// iieo	 If you do not agree to this license, do not download, install,
// jkvl	 copy or use the software.
// dsco	
// cjcz	                          License Agreement
// pqje	         For OpenVSS - Open Source Video Surveillance System
// eqac	
// nnet	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qyqi	
// menu	Third party copyrights are property of their respective owners.
// tztd	
// uimk	Redistribution and use in source and binary forms, with or without modification,
// rdnp	are permitted provided that the following conditions are met:
// ztww	
// htjs	  * Redistribution's of source code must retain the above copyright notice,
// icbw	    this list of conditions and the following disclaimer.
// fbvf	
// btby	  * Redistribution's in binary form must reproduce the above copyright notice,
// vhgq	    this list of conditions and the following disclaimer in the documentation
// wgjv	    and/or other materials provided with the distribution.
// eqkj	
// apuw	  * Neither the name of the copyright holders nor the names of its contributors 
// bubt	    may not be used to endorse or promote products derived from this software 
// uvmq	    without specific prior written permission.
// yxyt	
// ngix	This software is provided by the copyright holders and contributors "as is" and
// cotr	any express or implied warranties, including, but not limited to, the implied
// ngza	warranties of merchantability and fitness for a particular purpose are disclaimed.
// joor	In no event shall the Prince of Songkla University or contributors be liable 
// rrvp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gyeh	(including, but not limited to, procurement of substitute goods or services;
// siea	loss of use, data, or profits; or business interruption) however caused
// vprz	and on any theory of liability, whether in contract, strict liability,
// iqix	or tort (including negligence or otherwise) arising in any way out of
// hnhl	the use of this software, even if advised of the possibility of such damage.
// vcjv	
// ubkg	Intelligent Systems Laboratory (iSys Lab)
// huzh	Faculty of Engineering, Prince of Songkla University, THAILAND
// bimo	Project leader by Nikom SUVONVORN
// cbet	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vs.Playback.VsService;
using System.Globalization;
using NLog;

namespace Vs.Playback
{
    public delegate void getAllcam();
    public delegate void setServerURL(string s);

    public partial class VsPlayback : Form
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        VsCoreEngine engine;

        VsCamera[] camList;

        List<int> camSelect = new List<int>();
        VsMotion[] motionList;
        List<VsMotion> motions = new List<VsMotion>();

        public DateTime timeBegin;
        public DateTime timeEnd;

        bool bCancel = false;

        public VsPlayback()
        {
            try
            {
                InitializeComponent();

                engine = new VsCoreEngine(new VsServiceConnect(), vlCplayer1);
                engine.connectData();

                setTimePeriod(DateTime.Now, DateTime.Now);
                setAllCam(camList);
                this.Load += new EventHandler(VsPlayback_Load);

                // Initial application core
                VsSplasher.Status = "Load application setting...";
                System.Threading.Thread.Sleep(1500);

                VsSplasher.LoginSerivce(new getAllcam(this.getAllCam), new setServerURL(this.setServerUrl));

                while (VsSplasher.Blocked) System.Threading.Thread.Sleep(100);


                if (!VsSplasher.Connected)
                {
                    this.Hide();
                    bCancel = true;
                }

                VsSplasher.Hide();


            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        void VsPlayback_Load(object sender, EventArgs e)
        {
            if (bCancel)
                this.Close();
            VsSplasher.Close();

            this.vsSystemInfo1.Start();

            //radioButtonGraph.Checked = true;
        }

        private void setServerUrl(string s)
        {
            try
            {
                engine.service.Url = s;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void setAllCam(VsCamera[] camLit)
        {
            try
            {
                if (camList != null)
                {
                    this.camList = camLit;

                    listCameras.Items.Clear();
                    foreach (VsCamera c in camList)
                    {
                        listCameras.Items.Add("" + c.location);
                    }
                }

                setVsTimeLine();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void getAllCam()
        {
            try
            {
                camList = engine.getCamAll();

                setAllCam(camList);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void setTimePeriod(DateTime t1, DateTime t2)
        {
            try
            {
                timeBegin = t1;
                timeEnd = t2;
                //textBoxDateBegin.Text = t1.ToString();
                //textBoxDateEnd.Text = t2.ToString();

            

                updateMotionList();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void setVsTimeLine()
        {
            vsTimeLine1.setCoreEngine(engine);
            vsTimeLine1.setVsPlayback(this);
            vsTimeLine1.setPlayers(vsVlcPlayerQuart1.players);
            camListDControl.setCam(camList);
        }

        private void connectDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                getAllCam();
                setAllCam(camList);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void camSelected()
        {
            try
            {
                int selectIndex = listCameras.SelectedIndex;

                if (!camSelect.Contains(listCameras.SelectedIndex))
                    camSelect.Add(listCameras.SelectedIndex);
                else
                    camSelect.RemoveAt(camSelect.FindIndex(delegate(int item) { return item == listCameras.SelectedIndex; }));

                listSelectedCameras.Items.Clear();
                foreach (int i in camSelect.ToArray())
                {
                    listSelectedCameras.Items.Add(camList[i].location);
                }

                updateMotionList();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void listCameras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listCameras.SelectedIndex >= 0)
                {
                    camSelected();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void listCameras_MouseClick(object sender, MouseEventArgs e)
        {
            listCameras_MouseDoubleClick(sender, e);
        }

        public void motionSelected()
        {
            try
            {
                radioButtonVideo_CheckedChanged(null, null);

                int index = listEvents.SelectedIndex;
                VsMotion m = motions[index];
                VsFileURL url = engine.getFileUrlOfMotion(m.MotionID.ToString(), m.timeBegin);

                textBox3.Text = "" + m.timeBegin + " To " + m.timeEnd;
                vlCplayer1.playFileUrl(url.FilesURL);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void updateMotionList()
        {
            try
            {
                motions.Clear();

                vlCplayer1.stop();
                listEvents.Items.Clear();

                foreach (int i in camSelect)
                {
                    motionList = engine.getMotionOfCamAsPeriod(timeBegin, timeEnd, camList[i].cameraID.ToString());

                    foreach (VsMotion m in motionList)
                    {
                        listEvents.Items.Add("" + m.timeBegin + " : " + camList[i].location);
                    }

                    motions.AddRange(motionList);

                }

                //foreach (VsMotion m in motions)
                //{
                //    listEvents.Items.Add("" + m.timeBegin+ " :"+ m.cameraID);
                //}

                vlCplayer1.addPlayList(listEvents);
                vlCplayer1.addMainGui(this);

               
                updateChart();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        string ChartMode = "day";

        private void updateChart()
        {
            try
            {
                VsChartModel model = new VsChartModel();

                List<string> headname = new List<string>();

                if ("day".Equals(ChartMode))
                {
                    foreach (int i in camSelect)
                    {
                        List<int> value = engine.getNumberOfMotionInDay(timeBegin, timeEnd, camList[i].cameraID.ToString());
                        model.getCamData(camList[i].location, value);
                    }
                    for (int i = 0; i <= 23; i++)
                    {
                        headname.Add("" + i);
                    }

                    model.getMainTile("แสดงกราฟของเหตุการณ์ตามวัน");
                    model.getHeaderName(headname);
                    chartPresent1.updateChartModel(model);
                }
                else if ("month".Equals(ChartMode))
                {
                    foreach (int i in camSelect)
                    {
                        List<int> value = engine.getNumberOfMotionInMonth(timeBegin, timeEnd, camList[i].cameraID.ToString());
                        model.getCamData(camList[i].location, value);
                    }
                    for (int i = 1; i <= 31; i++)
                    {
                        headname.Add("" + i);
                    }

                    model.getMainTile("แสดงกราฟของเหตุการณ์ตามเดือน");
                    model.getHeaderName(headname);
                    chartPresent1.updateChartModel(model);
                }
                else if ("year".Equals(ChartMode))
                {
                    foreach (int i in camSelect)
                    {
                        List<int> value = engine.getNumberOfMotionInYear(timeBegin, timeEnd, camList[i].cameraID.ToString());
                        model.getCamData(camList[i].location, value);
                    }
                    for (int i = 1; i <= 12; i++)
                    {
                        headname.Add("" + i);
                    }

                    model.getMainTile("แสดงกราฟของเหตุการณ์ตามปี");
                    model.getHeaderName(headname);
                    chartPresent1.updateChartModel(model);
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void listEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listEvents.SelectedIndex >= 0)
                {
                    motionSelected();
                    panel2.Visible = true;
                    panel5.Visible = false;
                    radioButtonVideo.Checked = true;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void listEvents_MouseClick(object sender, MouseEventArgs e)
        {
            listEvents_MouseDoubleClick(sender, e);
        }

        private void listSelectedCameras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listSelectedCameras.SelectedIndex >= 0)
                {

                    camSelect.RemoveAt(listSelectedCameras.SelectedIndex);
                    listSelectedCameras.Items.Clear();
                    foreach (int i in camSelect.ToArray())
                    {
                        listSelectedCameras.Items.Add(camList[i].location);
                    }
                    // camSelected();
                    updateMotionList();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        void listSelectedCameras_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            listSelectedCameras_MouseDoubleClick(sender, e);
        }

        //autoupdate
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxUpdate.Checked)
                {
                    timeBegin = timeEnd;
                    timeEnd = DateTime.Now;
                    setTimePeriod(timeBegin, timeEnd);

                    autoUpdateTimeEnd.Enabled = true;
                }
                else
                {
                    autoUpdateTimeEnd.Enabled = false;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void autoUpdateTimeEnd_Tick(object sender, EventArgs e)
        {
            try
            {
                timeBegin = timeEnd;
                timeEnd = DateTime.Now;
                setTimePeriod(timeBegin, timeEnd);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                VsAboutBox vsAbout = new VsAboutBox();
                this.TopMost = false;
                vsAbout.TopMost = true;
                vsAbout.Show();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }


        #region "chart"

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ChartMode = "day";
                updateChart();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ChartMode = "month";
                updateChart();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ChartMode = "year";
                updateChart();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        #endregion

        #region "SetTimeMenu"
        private void radioButtonToday_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                dateTimePicker1.Value = start;
                dateTimePicker2.Value = end;

                string h1 = "00";
                string m1 = "00";
                string s1 = "00";
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;

                string h2 = "23";
                string m2 = "59";
                string s2 = "59";
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;

                groupBoxDateSelect.Enabled = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButtonTomonth_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                start = start.AddDays(-DateTime.Now.Day + 1);

                dateTimePicker1.Value = start;
                dateTimePicker2.Value = end;

                string h1 = "00";
                string m1 = "00";
                string s1 = "00";
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;

                string h2 = "23";
                string m2 = "59";
                string s2 = "59";
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;

                groupBoxDateSelect.Enabled = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButtonToyear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                start = start.AddDays(-DateTime.Now.Day + 1);
                start = start.AddMonths(-DateTime.Now.Month + 1);

                dateTimePicker1.Value = start;
                dateTimePicker2.Value = end;

                string h1 = "00";
                string m1 = "00";
                string s1 = "01";
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;

                string h2 = "23";
                string m2 = "59";
                string s2 = "59";
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;

                groupBoxDateSelect.Enabled = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButtonTodefine_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                groupBoxDateSelect.Enabled = true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                string h1 = ((trackBar1.Value) / 2).ToString();
                string m1 = "00";
                if (trackBar1.Value % 2 == 1) m1 = "30";

                textBox1.Text = "" + h1 + ":" + m1 + ":01";

                if (trackBar1.Value == 48) textBox1.Text = "23:59:59";
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            try
            {
                string h1 = ((trackBar6.Value) / 2).ToString();
                string m1 = "00";
                if (trackBar6.Value % 2 == 1) m1 = "30";

                textBox2.Text = "" + h1 + ":" + m1 + ":01";

                if (trackBar6.Value == 48) textBox2.Text = "23:59:59";
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Parse(dateTimePicker1.Value.Date.ToString().Split()[0] + " " + textBox1.Text);
                DateTime end = DateTime.Parse(dateTimePicker2.Value.Date.ToString().Split()[0] + " " + textBox2.Text);

                setTimePeriod(start, end);

                textBox4.Text = start.ToString() + " ถึง " + end.ToString();
                vsTimeLine1.updateTimeLine();

                
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        #endregion

        #region "presentType"
        private void radioButtonVideo_CheckedChanged(object sender, EventArgs e)//show player
        {
            try
            {
                panel2.Visible = true;
                panel5.Visible = false;
                panelTimeLine.Visible = false;

                camListDControl.Visible = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButtonGraph_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = false;
                panel5.Visible = true;
                panelTimeLine.Visible = false;

                camListDControl.Visible = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        private void radioButtonTimeLine_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = false;
                panel5.Visible = false;
                panelTimeLine.Visible = true;

                camListDControl.Visible = true;

                vlCplayer1.stop();
                listEvents.Items.Clear();




            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

      
        #endregion

        private void txtboxInfo_TextChanged(object sender, EventArgs e)
        {
            //txtboxInfo.ScrollToCaret();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
