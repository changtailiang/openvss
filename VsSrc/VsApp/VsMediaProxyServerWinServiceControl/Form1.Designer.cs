// peky	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ihdn	
// uvqs	 By downloading, copying, installing or using the software you agree to this license.
// dels	 If you do not agree to this license, do not download, install,
// tjtl	 copy or use the software.
// xvhy	
// rltw	                          License Agreement
// pymu	         For OpenVSS - Open Source Video Surveillance System
// ttsr	
// lezh	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ekaa	
// bwgm	Third party copyrights are property of their respective owners.
// jnkr	
// otrt	Redistribution and use in source and binary forms, with or without modification,
// xlgw	are permitted provided that the following conditions are met:
// nhyv	
// iwzj	  * Redistribution's of source code must retain the above copyright notice,
// mtgp	    this list of conditions and the following disclaimer.
// klhm	
// vgxv	  * Redistribution's in binary form must reproduce the above copyright notice,
// ehmb	    this list of conditions and the following disclaimer in the documentation
// oufa	    and/or other materials provided with the distribution.
// cyua	
// xctw	  * Neither the name of the copyright holders nor the names of its contributors 
// mesf	    may not be used to endorse or promote products derived from this software 
// wwaq	    without specific prior written permission.
// hvhc	
// leyr	This software is provided by the copyright holders and contributors "as is" and
// nlsg	any express or implied warranties, including, but not limited to, the implied
// vwhn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qzho	In no event shall the Prince of Songkla University or contributors be liable 
// ygri	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rkar	(including, but not limited to, procurement of substitute goods or services;
// nsyh	loss of use, data, or profits; or business interruption) however caused
// gvus	and on any theory of liability, whether in contract, strict liability,
// ndox	or tort (including negligence or otherwise) arising in any way out of
// zdmm	the use of this software, even if advised of the possibility of such damage.
// jnbp	
// wepw	Intelligent Systems Laboratory (iSys Lab)
// olra	Faculty of Engineering, Prince of Songkla University, THAILAND
// dzla	Project leader by Nikom SUVONVORN
// egdv	Project website at http://code.google.com/p/openvss/

namespace VsMediaProxyServerWinServiceControl
{
    partial class VsMediaProxyServerWinServiceControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsMediaProxyServerWinServiceControl));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // VsMediaProxyServerWinServiceControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "VsMediaProxyServerWinServiceControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

