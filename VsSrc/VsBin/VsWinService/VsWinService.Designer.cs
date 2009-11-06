// lrxm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zqid	
// hxgx	 By downloading, copying, installing or using the software you agree to this license.
// ahft	 If you do not agree to this license, do not download, install,
// xgyr	 copy or use the software.
// wsim	
// oivn	                          License Agreement
// tdzc	         For OpenVss - Open Source Video Surveillance System
// gbot	
// izcw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ybdk	
// mbls	Third party copyrights are property of their respective owners.
// opch	
// teit	Redistribution and use in source and binary forms, with or without modification,
// jlxr	are permitted provided that the following conditions are met:
// vukd	
// yeqy	  * Redistribution's of source code must retain the above copyright notice,
// tmlx	    this list of conditions and the following disclaimer.
// dctu	
// oxzn	  * Redistribution's in binary form must reproduce the above copyright notice,
// wcze	    this list of conditions and the following disclaimer in the documentation
// bric	    and/or other materials provided with the distribution.
// tujw	
// clad	  * Neither the name of the copyright holders nor the names of its contributors 
// qami	    may not be used to endorse or promote products derived from this software 
// knzb	    without specific prior written permission.
// dfdr	
// knem	This software is provided by the copyright holders and contributors "as is" and
// lkut	any express or implied warranties, including, but not limited to, the implied
// vgcg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// voey	In no event shall the Prince of Songkla University or contributors be liable 
// cous	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bqeo	(including, but not limited to, procurement of substitute goods or services;
// lqci	loss of use, data, or profits; or business interruption) however caused
// cxav	and on any theory of liability, whether in contract, strict liability,
// orrf	or tort (including negligence or otherwise) arising in any way out of
// pxls	the use of this software, even if advised of the possibility of such damage.

namespace Vs.WinService
{
    partial class VsWinService
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).BeginInit();
            // 
            // VsWinService
            // 
            this.ServiceName = "VsService";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog;
    }
}
