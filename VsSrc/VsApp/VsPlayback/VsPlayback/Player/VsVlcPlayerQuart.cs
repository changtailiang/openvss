// wddn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uipt	
// xzlu	 By downloading, copying, installing or using the software you agree to this license.
// zbbu	 If you do not agree to this license, do not download, install,
// smqd	 copy or use the software.
// ojwg	
// jzqo	                          License Agreement
// fdej	         For OpenVSS - Open Source Video Surveillance System
// vvhb	
// fbie	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// orfk	
// panp	Third party copyrights are property of their respective owners.
// exqm	
// ckrn	Redistribution and use in source and binary forms, with or without modification,
// hwdu	are permitted provided that the following conditions are met:
// rant	
// ucye	  * Redistribution's of source code must retain the above copyright notice,
// uzor	    this list of conditions and the following disclaimer.
// elox	
// elrj	  * Redistribution's in binary form must reproduce the above copyright notice,
// mbki	    this list of conditions and the following disclaimer in the documentation
// nrgk	    and/or other materials provided with the distribution.
// dttj	
// xnnn	  * Neither the name of the copyright holders nor the names of its contributors 
// dlpn	    may not be used to endorse or promote products derived from this software 
// bive	    without specific prior written permission.
// iyir	
// wujw	This software is provided by the copyright holders and contributors "as is" and
// fuiq	any express or implied warranties, including, but not limited to, the implied
// pfgc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vnaa	In no event shall the Prince of Songkla University or contributors be liable 
// fftq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xaus	(including, but not limited to, procurement of substitute goods or services;
// vehd	loss of use, data, or profits; or business interruption) however caused
// ffao	and on any theory of liability, whether in contract, strict liability,
// jpoj	or tort (including negligence or otherwise) arising in any way out of
// kxdd	the use of this software, even if advised of the possibility of such damage.
// exxx	
// emro	Intelligent Systems Laboratory (iSys Lab)
// huzc	Faculty of Engineering, Prince of Songkla University, THAILAND
// frtv	Project leader by Nikom SUVONVORN
// aqbb	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Vs.Playback.Player
{
    public partial class VsVlcPlayerQuart : UserControl
    {
        public VsVlcPlayer2[] players;
        public VsVlcPlayerQuart()
        {
            InitializeComponent();

            players = new VsVlcPlayer2[4];
           
            players[0] = vsVlcPlayer21;
            players[0].setLable("C1");
            players[1] = vsVlcPlayer22;
            players[1].setLable("C2");
            players[2] = vsVlcPlayer23;
            players[2].setLable("C3");
            players[3] = vsVlcPlayer24;
            players[3].setLable("C4");
        }

    }
}
