// umkk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gshr	
// mygz	 By downloading, copying, installing or using the software you agree to this license.
// cgyx	 If you do not agree to this license, do not download, install,
// mbvz	 copy or use the software.
// zjlz	
// nedh	                          License Agreement
// nrri	         For OpenVSS - Open Source Video Surveillance System
// fqyp	
// cnkj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kipe	
// rngc	Third party copyrights are property of their respective owners.
// yoir	
// uiwl	Redistribution and use in source and binary forms, with or without modification,
// blwc	are permitted provided that the following conditions are met:
// ozev	
// hxum	  * Redistribution's of source code must retain the above copyright notice,
// hjvy	    this list of conditions and the following disclaimer.
// qloq	
// tgha	  * Redistribution's in binary form must reproduce the above copyright notice,
// xbjy	    this list of conditions and the following disclaimer in the documentation
// jzox	    and/or other materials provided with the distribution.
// tmor	
// rivk	  * Neither the name of the copyright holders nor the names of its contributors 
// euxt	    may not be used to endorse or promote products derived from this software 
// tuuo	    without specific prior written permission.
// tjbi	
// tgru	This software is provided by the copyright holders and contributors "as is" and
// dwen	any express or implied warranties, including, but not limited to, the implied
// qgli	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jxsu	In no event shall the Prince of Songkla University or contributors be liable 
// uehi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qemz	(including, but not limited to, procurement of substitute goods or services;
// iohd	loss of use, data, or profits; or business interruption) however caused
// gufa	and on any theory of liability, whether in contract, strict liability,
// yfdn	or tort (including negligence or otherwise) arising in any way out of
// vtou	the use of this software, even if advised of the possibility of such damage.
// dhux	
// ipkw	Intelligent Systems Laboratory (iSys Lab)
// bauo	Faculty of Engineering, Prince of Songkla University, THAILAND
// bssp	Project leader by Nikom SUVONVORN
// trmo	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Playback.VsService;

namespace Vs.Playback.TimeLine
{
    public partial class VsTimeLine : UserControl
    {

        Bars[] bars;
        Dictionary<int, VsMotion>[] data;
        TextBox[] texts;
        public VsTimeLine()
        {
            InitializeComponent();


            #region "setvideoSlider1"
            this.videoSlider1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SlidersScroll);
            this.videoSlider1.ValueChanged += new System.EventHandler(this.SlidersValueChanged);
            this.videoSlider1.MouseWheel += new MouseEventHandler(videoSlider1_MouseWheel);

            #endregion

            colorSlider1.Scroll += new ScrollEventHandler(sliderH_Scroll);
            colorSlider1.ValueChanged += new System.EventHandler(sliderH_ValueChanged);
            SetSliderH();

            texts = new TextBox[4];

            texts[0] = this.textBox1;
            texts[1] = this.textBox2;
            texts[2] = this.textBox3;
            texts[3] = this.textBox4;

           // updatePlyar();

            #region "addEventToTextbox"

            foreach(var text in texts){
                text.DragDrop += new DragEventHandler(textBox_DragDrop);
                text.DragOver += new DragEventHandler(textBox1_DragOver);
                text.DragEnter += new DragEventHandler(textBox1_DragEnter);
                text.DragLeave += new EventHandler(textBox1_DragLeave);

                text.TextChanged += new EventHandler(textBox1_TextChanged);
            }
           
            //this.textBox2.DragDrop += new DragEventHandler(textBox_DragDrop);
            //this.textBox2.DragOver += new DragEventHandler(textBox1_DragOver);
            //this.textBox2.DragEnter += new DragEventHandler(textBox1_DragEnter);
            //this.textBox2.DragLeave += new EventHandler(textBox1_DragLeave);

            //this.textBox3.DragDrop += new DragEventHandler(textBox_DragDrop);
            //this.textBox3.DragOver += new DragEventHandler(textBox1_DragOver);
            //this.textBox3.DragEnter += new DragEventHandler(textBox1_DragEnter);
            //this.textBox3.DragLeave += new EventHandler(textBox1_DragLeave);

            //this.textBox4.DragDrop += new DragEventHandler(textBox_DragDrop);
            //this.textBox4.DragOver += new DragEventHandler(textBox1_DragOver);
            //this.textBox4.DragEnter += new DragEventHandler(textBox1_DragEnter);
            //this.textBox4.DragLeave += new EventHandler(textBox1_DragLeave);

            //textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            //textBox2.TextChanged += new EventHandler(textBox1_TextChanged);
            //textBox3.TextChanged += new EventHandler(textBox1_TextChanged);
            //textBox4.TextChanged += new EventHandler(textBox1_TextChanged);

            #endregion


            bars = new Bars[4];
            data = new Dictionary<int, VsMotion>[4];
        }

      

        #region "textDragEvent"
        void textBox1_DragLeave(object sender, EventArgs e)
        {

        }

        void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        void textBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void textBox_DragDrop(object sender, DragEventArgs e)
        {
            // this.BorderStyle = BorderStyle.None;

            string send = (string)e.Data.GetData(typeof(string));

            TextBox text = (TextBox)sender;
            text.Text = send;
         
            //  textBox1.Text = send;
        }
        void textBox1_TextChanged(object sender, EventArgs e)
        {
               updateTimeLine();
        }

        #endregion

        public void setbar()
        {
            this.videoSlider1.barHeight = 24;
            this.videoSlider1.ScreenOffsetY = 0;
            this.videoSlider1.LoadBarsFromDataSet(bars);


            this.videoSlider1.Invalidate();
            SetZoom(v);
        }

        public void SetZoom(int zoom)
        {

            if (videoSlider1 != null)
            {
                int z = zoom;

                float ff = 86400f;
                switch (z)
                {
                    case 0:
                        {
                            ff = 86400f;

                        }
                        break;
                    case 1:
                        {
                            ff = 43200f;

                        }
                        break;
                    case 2:
                        {
                            ff = (float)6 * 3600;

                        }
                        break;
                    case 3:
                        {
                            ff = 3600f;

                        }
                        break;
                    case 4:
                        {
                            ff = 900f;

                        }
                        break;
                    case 5:
                        {
                            ff = 60f;

                        }
                        break;


                }

                this.videoSlider1.Zoom2(ff);
                this.videoSlider1.Invalidate();
                SetSliderH();
            }
        }

        private void SetSliderH()
        {
            this.colorSlider1.Minimum = 0;
            this.colorSlider1.SmallChange = (uint)1;
            this.colorSlider1.LargeChange = (uint)1;
            // this.colorSlider1.Value = 0;

            if ((4 > 0) && (this.videoSlider1.DataRect.Width < 86400))
            {
                this.colorSlider1.Enabled = true;
                this.colorSlider1.Maximum = 86400 - Convert.ToInt32(this.videoSlider1.DataRect.Width);
                this.colorSlider1.Value = Convert.ToInt32(this.videoSlider1.DataRect.Left);
            }
            else
            {
                this.colorSlider1.Value = 0;
                this.colorSlider1.Enabled = false;
            }

            this.Invalidate();
            this.Refresh();
        }

        private void SlidersValueChanged(object sender, EventArgs e)
        {
            if ((sender as VideoSlider).Value < 0)
                return;

            if ((sender as VideoSlider).Value > this.videoSlider1.DataRect.X + this.videoSlider1.DataRect.Width)
            {
                this.videoSlider1.ZoomRight();
            }
            if ((sender as VideoSlider).Value < this.videoSlider1.DataRect.X)
            {
                this.videoSlider1.ZoomLeft();
            }

            int zz = (sender as VideoSlider).Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, zz, 0);
            //LABEL_AMPM.Text = "AM";
            //  if (zz > 43200)
            //  LABEL_AMPM.Text = "PM";

            // if (!_time24)
            //    if (zz > 46800)
            //    {
            //        ts = new TimeSpan(0, 0, 0, zz - 43200, 0);
            //    }

            //if (!_time24)
            //    if (zz > 46800)
            //    {
            //        ts = new TimeSpan(0, 0, 0, zz - 43200, 0);
            //    }

            //if ((!_time24) && (zz < 3600))
            //    LABEL_ThumbTime.Text = string.Format("12:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            //else
            label1.Text = string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));

            this.colorSlider1.Value = Convert.ToInt32(this.videoSlider1.DataRect.X);
            Invalidate();

        }

        int v;
        void videoSlider1_MouseWheel(object sender, MouseEventArgs e)
        {
            v += e.Delta / 120;

            if (v > 5) v = 5;
            else if (v < 0) v = 0;
            //textBox1.Text = "" + v;
            SetZoom(v);
            //SetProperValue(Value + v);
            //
        }

        private void SlidersScroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue < 0)
                return;

            if (e.NewValue > this.videoSlider1.DataRect.X + this.videoSlider1.DataRect.Width)
            {
                this.videoSlider1.ZoomRight();
            }
            if (e.NewValue < this.videoSlider1.DataRect.X)
            {
                this.videoSlider1.ZoomLeft();
            }

            //if (e.Type == ScrollEventType.EndScroll)
            //{
            //    this.sliderH.Value = Convert.ToInt32(this.videoSlider1.DataRect.X);

            //}
        }

        private void sliderH_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.Type == ScrollEventType.EndScroll)
            //{
            this.videoSlider1.MoveSliderH((float)e.NewValue);
            //Invalidate();
            Application.DoEvents();
            //}
        }
        private void sliderH_ValueChanged(object sender, EventArgs e)
        {
            //if (e.Type == ScrollEventType.EndScroll)
            //{
            this.videoSlider1.MoveSliderH(((ColorSlider)sender).Value);
            //Invalidate();
            try
            {
                Application.DoEvents();

            }
            catch { 
            
            }
            //}
        }

        private VsCoreEngine engine;
        public void setCoreEngine(VsCoreEngine engine)
        {
            this.engine = engine;
        }
        VsPlayback Playback;
        public void setVsPlayback(VsPlayback Playback)
        {
            this.Playback = Playback;
        }
        VsVlcPlayer2[] players;
        public void setPlayers(VsVlcPlayer2[] players)
        {
            this.players = players;
            updatePlyar();
        }

        public void updateBar()
        {
            DateTime timeBegin = Playback.timeBegin;
            DateTime timeEnd = Playback.timeEnd;

            int i = 0;
            foreach(var text in texts)
            {
                string camName = text.Text;

                bars[i] = new Bars();

                bars[i].FileName = camName;

                if (!text.Text.Equals(""))
                {
                    bars[i].motions = engine.getMotionOfCamAsPeriod(timeBegin, timeEnd, camName);

                    Dictionary<int, VsMotion> dic = new Dictionary<int, VsMotion>();
                    foreach (var v in bars[i].motions)
                    {
                        dic.Add((int)v.timeBegin.TimeOfDay.TotalSeconds, v);
                    }
                    data[i] = dic;
                }

                bars[i].goodData = true;
                // bars[i].FileID =camName;

                bars[i].FilePath = "";
                double dd = 184.9920088;
                bars[i].Duration = dd;
                bars[i].FileLength = (float)dd;
                bars[i].FPS = 0;
                bars[i].startSeconds = 0;
                bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
                float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
                bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
                bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;
                
                i++;
            }

            //{
            //    string camName = textBox2.Text;
            //    int i = 1;

            //    bars[i] = new Bars();

            //    bars[i].FileName = camName;

            //    if (!textBox2.Text.Equals(""))
            //    {
            //        bars[i].motions = engine.getMotionOfCamAsPeriod(timeBegin, timeEnd, camName);

            //        Dictionary<int, VsMotion> dic = new Dictionary<int, VsMotion>();
            //        foreach (var v in bars[i].motions)
            //        {
            //            dic.Add((int)v.timeBegin.TimeOfDay.TotalSeconds, v);
            //        }
            //        data[i] = dic;

            //    }

            //    bars[i].goodData = true;
            //    // bars[i].FileID =camName;

            //    bars[i].FilePath = "";
            //    double dd = 184.9920088;
            //    bars[i].Duration = dd;
            //    bars[i].FileLength = (float)dd;
            //    bars[i].FPS = 0;
            //    bars[i].startSeconds = 0;
            //    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
            //    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
            //    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
            //    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;
            //}

            //{
            //    string camName = textBox3.Text;
            //    int i = 2;

            //    bars[i] = new Bars();

            //    bars[i].FileName = camName;

            //    if (!textBox3.Text.Equals(""))
            //    {
            //        bars[i].motions = engine.getMotionOfCamAsPeriod(timeBegin, timeEnd, camName);

            //        Dictionary<int, VsMotion> dic = new Dictionary<int, VsMotion>();
            //        foreach (var v in bars[i].motions)
            //        {
            //            dic.Add((int)v.timeBegin.TimeOfDay.TotalSeconds, v);
            //        }
            //        data[i] = dic;

            //    }

            //    bars[i].goodData = true;
            //    // bars[i].FileID =camName;

            //    bars[i].FilePath = "";
            //    double dd = 184.9920088;
            //    bars[i].Duration = dd;
            //    bars[i].FileLength = (float)dd;
            //    bars[i].FPS = 0;
            //    bars[i].startSeconds = 0;
            //    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
            //    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
            //    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
            //    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;
            //}

            //{
            //    string camName = textBox4.Text;
            //    int i = 3;

            //    bars[i] = new Bars();

            //    bars[i].FileName = camName;

            //    if (!textBox4.Text.Equals(""))
            //    {
            //        bars[i].motions = engine.getMotionOfCamAsPeriod(timeBegin, timeEnd, camName);

            //        Dictionary<int, VsMotion> dic = new Dictionary<int, VsMotion>();
            //        foreach (var v in bars[i].motions)
            //        {
            //            dic.Add((int)v.timeBegin.TimeOfDay.TotalSeconds, v);
            //        }
            //        data[i] = dic;

            //    }

            //    bars[i].goodData = true;
            //    // bars[i].FileID =camName;

            //    bars[i].FilePath = "";
            //    double dd = 184.9920088;
            //    bars[i].Duration = dd;
            //    bars[i].FileLength = (float)dd;
            //    bars[i].FPS = 0;
            //    bars[i].startSeconds = 0;
            //    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
            //    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
            //    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
            //    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;
            //}
        }

        public void updatePlyar()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].setHoldText(texts[i]);
            }
        }

        public void updateTimeLine()
        {
            updateBar();
            setbar();
            //
            SetSliderH();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        int speed = 100;
        private void timer1_Tick(object sender, EventArgs e)
        {

            int time = videoSlider1.Value++;
            checkVideoLine(time);

            if (checkPlayerPlaying())
            {
                timer1.Interval = 1000;
                speed = 100;
            }
            else
            {
                if (speed > 0) speed-=5;
                timer1.Interval = 100+speed;
            }
        }

        private bool checkPlayerPlaying()
        {
            foreach (var v in players)
            {
                if (v != null && v.IsPlaying)
                {
                    return true;
                }
            }
            return false;
        }

        public void checkVideoLine(int time)
        {
            
            for (int i = 0; i < data.Length; i++)
            {
               
                var v = data[i];
                if (v != null && v.ContainsKey(time))
                {

                     timer1.Stop();
                    VsFileURL url = engine.getFileUrlOfMotion(v[time].MotionID.ToString(), v[time].timeBegin);
                  
                    try
                    {
                        //int leng = (int)( v[time].timeEnd - v[time].timeBegin).TotalSeconds;
                        players[i].playFileUrl(url.FilesURL);
                        timer1.Interval = 1000;
                    }
                    catch (Exception ex){

                        MessageBox.Show(ex.Message+" "+DateTime.Now.ToString());
                    }
                  timer1.Start();
                } 
               
            }
        }


    }
}


