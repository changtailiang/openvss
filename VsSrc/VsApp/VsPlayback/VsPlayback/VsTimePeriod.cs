// wvgj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wovv	
// qzaa	 By downloading, copying, installing or using the software you agree to this license.
// npnh	 If you do not agree to this license, do not download, install,
// dlix	 copy or use the software.
// xgfb	
// ywoo	                          License Agreement
// hxlg	         For OpenVss - Open Source Video Surveillance System
// qyuk	
// pxwq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jcyb	
// wiqs	Third party copyrights are property of their respective owners.
// upst	
// gqzp	Redistribution and use in source and binary forms, with or without modification,
// peka	are permitted provided that the following conditions are met:
// agos	
// nujp	  * Redistribution's of source code must retain the above copyright notice,
// udsf	    this list of conditions and the following disclaimer.
// psnv	
// hefp	  * Redistribution's in binary form must reproduce the above copyright notice,
// fwus	    this list of conditions and the following disclaimer in the documentation
// fsza	    and/or other materials provided with the distribution.
// yfuk	
// mwpc	  * Neither the name of the copyright holders nor the names of its contributors 
// ognb	    may not be used to endorse or promote products derived from this software 
// zbxr	    without specific prior written permission.
// xmeo	
// ceil	This software is provided by the copyright holders and contributors "as is" and
// zuue	any express or implied warranties, including, but not limited to, the implied
// mwmv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vjqp	In no event shall the Prince of Songkla University or contributors be liable 
// ihts	for any direct, indirect, incidental, special, exemplary, or consequential damages
// clhb	(including, but not limited to, procurement of substitute goods or services;
// qdqe	loss of use, data, or profits; or business interruption) however caused
// ycvt	and on any theory of liability, whether in contract, strict liability,
// nlxu	or tort (including negligence or otherwise) arising in any way out of
// xilr	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using NLog; 

namespace Vs.Playback
{
    public partial class VsTimePeriod : Form
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public VsTimePeriod()
        {
            InitializeComponent();
        }

        VsClient main;

        public void getParent(VsClient m)
        {
            try
            {
                main = m;

                dateTimePicker1.Value = m.timeBegin;
                dateTimePicker2.Value = m.timeEnd;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        private void buttonTime_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Parse(dateTimePicker1.Value.Date.ToString().Split()[0] + " " + textBox1.Text);
                DateTime end = DateTime.Parse(dateTimePicker2.Value.Date.ToString().Split()[0] + " " + textBox2.Text);

                main.setTimePeriod(start, end);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Parse(dateTimePicker1.Value.Date.ToString().Split()[0] + " " + textBox1.Text);
                DateTime end = DateTime.Parse(dateTimePicker2.Value.Date.ToString().Split()[0] + " " + textBox2.Text);

                main.setTimePeriod(start, end);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string h1 = "00";
        string m1 = "00";
        string s1 = "00";

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                h1 = trackBar1.Value.ToString();

                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            try
            {
                m1 = trackBar2.Value.ToString();
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            try
            {
                s1 = trackBar3.Value.ToString();
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        string h2 = "00";
        string m2 = "00";
        string s2 = "00";

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            try
            {
                h2 = trackBar6.Value.ToString();
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            try
            {
                m2 = trackBar5.Value.ToString();
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            try
            {
                s2 = trackBar4.Value.ToString();
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }


        private void radioButtonVideo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                dateTimePicker1.Value = start;
                dateTimePicker2.Value = end;

                h1 = "00";
                m1 = "00";
                s1 = "00";
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;

                h2 = "23";
                m2 = "59";
                s2 = "59";
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;

                panel1.Enabled = false;
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
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                start = start.AddDays(-DateTime.Now.Day + 1);

                dateTimePicker1.Value = start;
                dateTimePicker2.Value = end;

                h1 = "00";
                m1 = "00";
                s1 = "00";
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;

                h2 = "23";
                m2 = "59";
                s2 = "59";
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;

                panel1.Enabled = false;
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
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                start = start.AddDays(-DateTime.Now.Day + 1);
                start = start.AddMonths(-DateTime.Now.Month + 1);

                dateTimePicker1.Value = start;
                dateTimePicker2.Value = end;

                h1 = "00";
                m1 = "00";
                s1 = "00";
                textBox1.Text = "" + h1 + ":" + m1 + ":" + s1;

                h2 = "23";
                m2 = "59";
                s2 = "59";
                textBox2.Text = "" + h2 + ":" + m2 + ":" + s2;

                panel1.Enabled = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
    }
}
