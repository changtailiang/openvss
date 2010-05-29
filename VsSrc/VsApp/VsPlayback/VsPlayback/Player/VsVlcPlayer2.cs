// ibfn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// evfe	
// iusp	 By downloading, copying, installing or using the software you agree to this license.
// ruuh	 If you do not agree to this license, do not download, install,
// tyir	 copy or use the software.
// rftp	
// wehe	                          License Agreement
// hixn	         For OpenVSS - Open Source Video Surveillance System
// zcrh	
// ssvp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hidp	
// qauw	Third party copyrights are property of their respective owners.
// qotr	
// ykkc	Redistribution and use in source and binary forms, with or without modification,
// hqqa	are permitted provided that the following conditions are met:
// naxz	
// xeqo	  * Redistribution's of source code must retain the above copyright notice,
// cnoa	    this list of conditions and the following disclaimer.
// cskj	
// ceyw	  * Redistribution's in binary form must reproduce the above copyright notice,
// kkot	    this list of conditions and the following disclaimer in the documentation
// pfpp	    and/or other materials provided with the distribution.
// spzc	
// cvbg	  * Neither the name of the copyright holders nor the names of its contributors 
// kdrl	    may not be used to endorse or promote products derived from this software 
// kfud	    without specific prior written permission.
// zspf	
// aazd	This software is provided by the copyright holders and contributors "as is" and
// rtqd	any express or implied warranties, including, but not limited to, the implied
// mekr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pawn	In no event shall the Prince of Songkla University or contributors be liable 
// nmyh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qdyy	(including, but not limited to, procurement of substitute goods or services;
// mnme	loss of use, data, or profits; or business interruption) however caused
// qktw	and on any theory of liability, whether in contract, strict liability,
// qkor	or tort (including negligence or otherwise) arising in any way out of
// pwki	the use of this software, even if advised of the possibility of such damage.
// fytg	
// tawj	Intelligent Systems Laboratory (iSys Lab)
// ihpn	Faculty of Engineering, Prince of Songkla University, THAILAND
// uiox	Project leader by Nikom SUVONVORN
// bbqe	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using NLog;

namespace Vs.Playback
{
    public partial class VsVlcPlayer2 : UserControl, VsIPlayer
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private ListBox playlist;

        string playState = "stop";
        string playOption;

        TextBox holdTest;

        private bool isPlaying;

        public bool IsPlaying
        {
            get
            {

                return isPlaying;
            }

        }

        string currentFile;

        public VsVlcPlayer2()
        {
            InitializeComponent();

            this.DragDrop += new DragEventHandler(VsVlcPlayer2_DragDrop);
            this.DragOver += new DragEventHandler(VsVlcPlayer2_DragOver);
            this.DragEnter += new DragEventHandler(VsVlcPlayer2_DragEnter);
            this.DragLeave += new EventHandler(VsVlcPlayer2_DragLeave);

        }

        #region "DragEvent"
        void VsVlcPlayer2_DragLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        void VsVlcPlayer2_DragEnter(object sender, DragEventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        void VsVlcPlayer2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        void VsVlcPlayer2_DragDrop(object sender, DragEventArgs e)
        {
            this.BorderStyle = BorderStyle.None;

            string send = (string)e.Data.GetData(typeof(string));

            if (holdTest != null)
            {
                holdTest.Text = send;
            }
        }

        #endregion
        private VsPlayback main;

        public void addMainGui(VsPlayback m)
        {
            try
            {
                main = m;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void addPlayList(ListBox list)
        {
            try
            {
                playlist = list;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void playFileUrl(string url)
        {
            try
            {
                //timer1.Interval = 50;
                isPlaying = true;
                currentFile = url;
                play();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }



        private void ended()
        {
            MessageBox.Show("enddd");
        }

        int time;
        int leng = 100;
        private void play()
        {
            try
            {
                colorSlider1.Maximum = leng;
                vlcUserControl1.AddAndPlay(currentFile, "");
               

                time = 0;
                timer1.Start();
                timer2.Start();
                label1.Visible = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void pause()
        {
            try
            {
                this.vlcUserControl1.TogglePause();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void stop()
        {
            try
            {
                this.vlcUserControl1.Stop();

                timer1.Enabled = false;
                playState = "stop ";
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void playNext()
        {
            try
            {
                if (playlist != null)
                    if (playlist.SelectedIndex < playlist.Items.Count - 1)
                    {
                        playlist.SelectedIndex++;
                        main.motionSelected();
                    }
                    else
                    {
                        playlist.SelectedIndex = 0;
                        main.motionSelected();
                    }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            play();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            playNext();
        }

        private void buttonPre_Click(object sender, EventArgs e)
        {
            try
            {
                if (playlist != null)
                    if (playlist.SelectedIndex > 0)
                    {
                        playlist.SelectedIndex--;
                        main.motionSelected();
                    }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                playOption = "man";
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public void setLable(string s)
        {
            label1.Text = s;
        }
        public void setHoldText(TextBox t)
        {
            holdTest = t;
        }

        private void VsVlcPlayer2_SizeChanged(object sender, EventArgs e)
        {

            this.label1.Location = new System.Drawing.Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (IsPlaying)
                {
                    if (vlcUserControl1.IsPlaying)
                    {
                        label1.Visible = false;
                        isPlaying = true;
                      
                    }
                    //textBox1.Text = playState + playlist.SelectedItem.ToString() + " : " + time++;
                    else if (!label1.Visible)
                    {
                        isPlaying = false;
                        label1.Visible = true;
                        colorSlider1.Value = 0;
                       // timer2.Stop();
                    }
                }
                else
                {
                    if (vlcUserControl1.IsPlaying)
                    {
                        label1.Visible = false;
                        isPlaying = true;
                    }
                }

                //if (playState == null)
                //{
                //    isPlaying = false;
                //    label1.Visible = true;

                //    return;
                //}

                //if ("play".Equals(playState))
                //{

                //    if (vlcUserControl1.IsPlaying)
                //    {
                //        label1.Visible = false;
                //        isPlaying = true;
                //    }
                //    //textBox1.Text = playState + playlist.SelectedItem.ToString() + " : " + time++;
                //    else
                //    {
                //        isPlaying = false;
                //        label1.Visible = true;
                //        playState = "stop";
                //        timer1.Interval = 1000;
                //    }

                //}
                //else
                //{
                //    if (vlcUserControl1.IsPlaying)
                //    {
                //        playState = "play";
                //        label1.Visible = false;
                //        isPlaying = true;
                //    }

                //}

            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                int Pos = (int)(vlcUserControl1.Position * leng);
                colorSlider1.Value = Pos;
            }
        }
    }
}
