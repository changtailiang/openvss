// iavx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tfam	
// vdvo	 By downloading, copying, installing or using the software you agree to this license.
// knvh	 If you do not agree to this license, do not download, install,
// ezki	 copy or use the software.
// jlna	
// eoau	                          License Agreement
// cbps	         For OpenVss - Open Source Video Surveillance System
// ycgo	
// dsed	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// awvg	
// ppfv	Third party copyrights are property of their respective owners.
// qrnw	
// xrtw	Redistribution and use in source and binary forms, with or without modification,
// nvte	are permitted provided that the following conditions are met:
// ffjt	
// ocpi	  * Redistribution's of source code must retain the above copyright notice,
// hgdm	    this list of conditions and the following disclaimer.
// uhin	
// phlo	  * Redistribution's in binary form must reproduce the above copyright notice,
// jfdl	    this list of conditions and the following disclaimer in the documentation
// nsvg	    and/or other materials provided with the distribution.
// ijbi	
// zzxv	  * Neither the name of the copyright holders nor the names of its contributors 
// mbrm	    may not be used to endorse or promote products derived from this software 
// zxnk	    without specific prior written permission.
// nacq	
// jghg	This software is provided by the copyright holders and contributors "as is" and
// jevz	any express or implied warranties, including, but not limited to, the implied
// byfv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hiax	In no event shall the Prince of Songkla University or contributors be liable 
// fvnv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jnan	(including, but not limited to, procurement of substitute goods or services;
// pzpl	loss of use, data, or profits; or business interruption) however caused
// rtxn	and on any theory of liability, whether in contract, strict liability,
// qfxb	or tort (including negligence or otherwise) arising in any way out of
// cvyu	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace VsSetup
{
    public partial class VsInstall : Form
    {
        VsInstallControl StateControl;

        public VsInstall()
        {
            InitializeComponent();

            this.StateControl = new VsInstallControl(this, this.setupState1);
        }

        public void addStateControl(UserControl control, string stateName)
        {
            groupBox2.Text = stateName;

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(control);
        }
    }
}
