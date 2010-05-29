// fpfg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wbnq	
// rszv	 By downloading, copying, installing or using the software you agree to this license.
// iydd	 If you do not agree to this license, do not download, install,
// obek	 copy or use the software.
// hihr	
// yamk	                          License Agreement
// htkw	         For OpenVSS - Open Source Video Surveillance System
// ouan	
// aavz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// sjtb	
// wxmr	Third party copyrights are property of their respective owners.
// assb	
// qfqw	Redistribution and use in source and binary forms, with or without modification,
// iniv	are permitted provided that the following conditions are met:
// odiy	
// ichn	  * Redistribution's of source code must retain the above copyright notice,
// xpco	    this list of conditions and the following disclaimer.
// fesy	
// ofvb	  * Redistribution's in binary form must reproduce the above copyright notice,
// ovko	    this list of conditions and the following disclaimer in the documentation
// bifi	    and/or other materials provided with the distribution.
// eefn	
// ralo	  * Neither the name of the copyright holders nor the names of its contributors 
// avtt	    may not be used to endorse or promote products derived from this software 
// pztk	    without specific prior written permission.
// qevm	
// nshc	This software is provided by the copyright holders and contributors "as is" and
// rghs	any express or implied warranties, including, but not limited to, the implied
// tuwz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xyjt	In no event shall the Prince of Songkla University or contributors be liable 
// kowf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// sdxs	(including, but not limited to, procurement of substitute goods or services;
// lclp	loss of use, data, or profits; or business interruption) however caused
// bzyx	and on any theory of liability, whether in contract, strict liability,
// nsvm	or tort (including negligence or otherwise) arising in any way out of
// xcvk	the use of this software, even if advised of the possibility of such damage.
// stvg	
// zuwq	Intelligent Systems Laboratory (iSys Lab)
// paab	Faculty of Engineering, Prince of Songkla University, THAILAND
// hquj	Project leader by Nikom SUVONVORN
// uoqp	Project website at http://code.google.com/p/openvss/

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
