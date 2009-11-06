// zlov	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oopy	
// fnyd	 By downloading, copying, installing or using the software you agree to this license.
// jxfv	 If you do not agree to this license, do not download, install,
// yyfi	 copy or use the software.
// kwai	
// dibx	                          License Agreement
// axcn	         For OpenVss - Open Source Video Surveillance System
// fcsx	
// jocx	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rkeo	
// fsyn	Third party copyrights are property of their respective owners.
// rrhq	
// osuc	Redistribution and use in source and binary forms, with or without modification,
// kfsg	are permitted provided that the following conditions are met:
// nryh	
// klxg	  * Redistribution's of source code must retain the above copyright notice,
// eimk	    this list of conditions and the following disclaimer.
// virz	
// smdk	  * Redistribution's in binary form must reproduce the above copyright notice,
// jngi	    this list of conditions and the following disclaimer in the documentation
// qmyn	    and/or other materials provided with the distribution.
// hqmd	
// vwjz	  * Neither the name of the copyright holders nor the names of its contributors 
// mxdu	    may not be used to endorse or promote products derived from this software 
// vrjj	    without specific prior written permission.
// fxuf	
// auky	This software is provided by the copyright holders and contributors "as is" and
// biwa	any express or implied warranties, including, but not limited to, the implied
// lqry	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mkzo	In no event shall the Prince of Songkla University or contributors be liable 
// vioz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zrnu	(including, but not limited to, procurement of substitute goods or services;
// jjos	loss of use, data, or profits; or business interruption) however caused
// ewcs	and on any theory of liability, whether in contract, strict liability,
// ssmm	or tort (including negligence or otherwise) arising in any way out of
// fobn	the use of this software, even if advised of the possibility of such damage.

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
    public partial class VsVlcPlayer : UserControl, VsIPlayer
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private ListBox playlist;

        string playState;
        string playOption;
        string currentFile;

        public VsVlcPlayer()
        {
            InitializeComponent();
        }

        private VsClient main;

        public void addMainGui(VsClient m)
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

        private void play()
        {
            try
            {
                vlcUserControl1.AddAndPlay(currentFile, "");
                playState = "play";
                time = 0;
                timer1.Enabled = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if ("play".Equals(playState))
                {
                    if (vlcUserControl1.IsPlaying)
                        textBox1.Text = playState + playlist.SelectedItem.ToString() + " : " + time++;
                    else if ("auto".Equals(playOption))
                    {
                        playNext();
                    }
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
                if (checkBox1.Checked)
                    playOption = "auto";
                else
                    playOption = "man";
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }       
    }
}
