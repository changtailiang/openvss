// rlwv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// iobs	
// ybfq	 By downloading, copying, installing or using the software you agree to this license.
// iyus	 If you do not agree to this license, do not download, install,
// ayjf	 copy or use the software.
// kqwu	
// sjsl	                          License Agreement
// yuge	         For OpenVSS - Open Source Video Surveillance System
// xjyq	
// newy	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// aohq	
// tgyn	Third party copyrights are property of their respective owners.
// wqxc	
// cxlb	Redistribution and use in source and binary forms, with or without modification,
// pcdy	are permitted provided that the following conditions are met:
// vpue	
// uatz	  * Redistribution's of source code must retain the above copyright notice,
// zeev	    this list of conditions and the following disclaimer.
// blew	
// ifal	  * Redistribution's in binary form must reproduce the above copyright notice,
// lfoh	    this list of conditions and the following disclaimer in the documentation
// wecz	    and/or other materials provided with the distribution.
// xxbl	
// aycl	  * Neither the name of the copyright holders nor the names of its contributors 
// udvt	    may not be used to endorse or promote products derived from this software 
// mzns	    without specific prior written permission.
// mcbq	
// spsj	This software is provided by the copyright holders and contributors "as is" and
// bsnp	any express or implied warranties, including, but not limited to, the implied
// amhq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xubb	In no event shall the Prince of Songkla University or contributors be liable 
// ctuc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// itbf	(including, but not limited to, procurement of substitute goods or services;
// khzl	loss of use, data, or profits; or business interruption) however caused
// rvvu	and on any theory of liability, whether in contract, strict liability,
// dmhi	or tort (including negligence or otherwise) arising in any way out of
// frji	the use of this software, even if advised of the possibility of such damage.
// kmkh	
// vfvs	Intelligent Systems Laboratory (iSys Lab)
// ymqs	Faculty of Engineering, Prince of Songkla University, THAILAND
// hyhy	Project leader by Nikom SUVONVORN
// nmzu	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Collections;
using Vs.Core.Provider;
using System.IO;
using System.Reflection;

using Vs.Core.Image;
using System.Threading;

namespace Vs.Core.MediaProxyServer
{
    public partial class Form1 : Form
    {

        HttpServer httpServer;


        public Form1()
        {
            InitializeComponent();

        }

 

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string appPath =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
                httpServer = new VsMediaProxyServer(int.Parse(textBox2.Text), textBox3.Text
                    ,appPath);
                httpServer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

    }
}
