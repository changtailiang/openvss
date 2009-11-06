// aytx	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// celw	
// mxro	 By downloading, copying, installing or using the software you agree to this license.
// mcdi	 If you do not agree to this license, do not download, install,
// gewr	 copy or use the software.
// suha	
// izdl	                          License Agreement
// dmuo	         For OpenVss - Open Source Video Surveillance System
// owbv	
// afwp	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ufls	
// doio	Third party copyrights are property of their respective owners.
// jybf	
// njof	Redistribution and use in source and binary forms, with or without modification,
// rsoc	are permitted provided that the following conditions are met:
// batz	
// ccaq	  * Redistribution's of source code must retain the above copyright notice,
// bhhb	    this list of conditions and the following disclaimer.
// hhxm	
// joxt	  * Redistribution's in binary form must reproduce the above copyright notice,
// rpbe	    this list of conditions and the following disclaimer in the documentation
// lpaf	    and/or other materials provided with the distribution.
// hveh	
// qtot	  * Neither the name of the copyright holders nor the names of its contributors 
// mlpa	    may not be used to endorse or promote products derived from this software 
// ornb	    without specific prior written permission.
// raxg	
// mbvc	This software is provided by the copyright holders and contributors "as is" and
// vulm	any express or implied warranties, including, but not limited to, the implied
// yoon	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cvif	In no event shall the Prince of Songkla University or contributors be liable 
// dzkn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// teax	(including, but not limited to, procurement of substitute goods or services;
// zwfz	loss of use, data, or profits; or business interruption) however caused
// canl	and on any theory of liability, whether in contract, strict liability,
// rusg	or tort (including negligence or otherwise) arising in any way out of
// zcmv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace VsSetup
{
    public partial class SetupState : UserControl
    {
        public SetupState()
        {
            InitializeComponent();
        }


        public void setingState(State s)
        {
            // CheckBox checkState;
            switch (s)
            {
                case State.start:

                    break;
                case State.mysql:
                    seting(checkBox1);
                    break;
                case State.iis:
                    seting(checkBox2);
                    break;
                case State.windowEndcode:
                    seting(checkBox3);
                    break;
                case State.copyVS:
                    seting(checkBox4);
                    break;
                case State.config:
                    seting(checkBox5);
                    break;

                case State.exit:
                    break;
            }
        }

        public void setedState(State s)
        {
            // CheckBox checkState;
            switch (s)
            {
                case State.start:
                    break;

                case State.mysql:
                    seted(checkBox1);
                    break;
                case State.iis:
                    seted(checkBox2);
                    break;
                case State.windowEndcode:
                    seted(checkBox3);
                    break;
                case State.copyVS:
                    seted(checkBox4);
                    break;
                case State.config:
                    seted(checkBox5);
                    break;

                case State.exit:
                    break;
            }
        }



        private void seting(CheckBox che)
        {
            che.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void seted(CheckBox che)
        {
            che.BackColor = Color.FromArgb(192, 255, 192);
           
            //che.BackColor = Color.PaleGreen;
            che.Checked = true;
        }

    }
}
