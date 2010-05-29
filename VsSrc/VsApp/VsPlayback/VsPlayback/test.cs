// xpub	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yfzr	
// adke	 By downloading, copying, installing or using the software you agree to this license.
// dtys	 If you do not agree to this license, do not download, install,
// jbti	 copy or use the software.
// xteo	
// ptmb	                          License Agreement
// dcru	         For OpenVSS - Open Source Video Surveillance System
// anfw	
// bfde	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// heml	
// qcnv	Third party copyrights are property of their respective owners.
// pzew	
// bble	Redistribution and use in source and binary forms, with or without modification,
// kgle	are permitted provided that the following conditions are met:
// tyox	
// lpdp	  * Redistribution's of source code must retain the above copyright notice,
// ncqe	    this list of conditions and the following disclaimer.
// xoas	
// gsyn	  * Redistribution's in binary form must reproduce the above copyright notice,
// fqld	    this list of conditions and the following disclaimer in the documentation
// yusy	    and/or other materials provided with the distribution.
// cbmv	
// tzlj	  * Neither the name of the copyright holders nor the names of its contributors 
// qoaa	    may not be used to endorse or promote products derived from this software 
// yyhn	    without specific prior written permission.
// izzn	
// atxr	This software is provided by the copyright holders and contributors "as is" and
// hyzc	any express or implied warranties, including, but not limited to, the implied
// mkzq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wfmm	In no event shall the Prince of Songkla University or contributors be liable 
// qvky	for any direct, indirect, incidental, special, exemplary, or consequential damages
// crcs	(including, but not limited to, procurement of substitute goods or services;
// syog	loss of use, data, or profits; or business interruption) however caused
// jyuy	and on any theory of liability, whether in contract, strict liability,
// vfxi	or tort (including negligence or otherwise) arising in any way out of
// duov	the use of this software, even if advised of the possibility of such damage.
// ajxf	
// pjdt	Intelligent Systems Laboratory (iSys Lab)
// lvxn	Faculty of Engineering, Prince of Songkla University, THAILAND
// pblj	Project leader by Nikom SUVONVORN
// rfzi	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vs.Playback.TimeLine;

namespace Vs.Playback
{
    public partial class test : Form
    {



        public test()
        {
            InitializeComponent();

            vsTimeLine1.setbar();

            this.listBox1.DragOver += new DragEventHandler(VsCameraViewer_DragOver);
            this.listBox1.DragDrop += new DragEventHandler(listBox1_DragDrop);
            this.listBox1.DragLeave += new EventHandler(VsCameraViewer_DragLeave);
            this.listBox1.DragEnter += new DragEventHandler(listBox1_DragEnter);


            this.textBox1.DragOver += new DragEventHandler(VsCameraViewer_DragOver);
            this.textBox1.DragDrop += new DragEventHandler(listBox1_DragDrop);
            this.textBox1.DragLeave += new EventHandler(VsCameraViewer_DragLeave);
            this.listBox1.DragEnter += new DragEventHandler(listBox1_DragEnter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        void VsCameraViewer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
        }
        void VsCameraViewer_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.BorderStyle = BorderStyle.None;

            string send = (string)e.Data.GetData(typeof(string));

            MessageBox.Show(send);
        }
        void VsCameraViewer_DragLeave(object sender, EventArgs e)
        {
            listBox1.BorderStyle = BorderStyle.None;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string send = (string)e.Data.GetData(typeof(string));

            listBox1.Items.Add(send);
        }
    }
}
