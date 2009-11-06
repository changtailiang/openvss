// rwdv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dsva	
// optg	 By downloading, copying, installing or using the software you agree to this license.
// wflx	 If you do not agree to this license, do not download, install,
// rwbl	 copy or use the software.
// eenf	
// emkk	                          License Agreement
// xnkc	         For OpenVss - Open Source Video Surveillance System
// lygo	
// upwl	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pbjl	
// nmmi	Third party copyrights are property of their respective owners.
// egyl	
// qynn	Redistribution and use in source and binary forms, with or without modification,
// jxrr	are permitted provided that the following conditions are met:
// hkcb	
// equx	  * Redistribution's of source code must retain the above copyright notice,
// yxdb	    this list of conditions and the following disclaimer.
// zqvd	
// vbsr	  * Redistribution's in binary form must reproduce the above copyright notice,
// zcfq	    this list of conditions and the following disclaimer in the documentation
// ozlm	    and/or other materials provided with the distribution.
// ktex	
// xfdf	  * Neither the name of the copyright holders nor the names of its contributors 
// yigx	    may not be used to endorse or promote products derived from this software 
// spjh	    without specific prior written permission.
// dwla	
// ckrh	This software is provided by the copyright holders and contributors "as is" and
// farf	any express or implied warranties, including, but not limited to, the implied
// emmf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ehne	In no event shall the Prince of Songkla University or contributors be liable 
// sgdu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nqem	(including, but not limited to, procurement of substitute goods or services;
// vuyk	loss of use, data, or profits; or business interruption) however caused
// symr	and on any theory of liability, whether in contract, strict liability,
// olkz	or tort (including negligence or otherwise) arising in any way out of
// bxrx	the use of this software, even if advised of the possibility of such damage.

namespace Vs.WinService
{
    partial class VsInstaller
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
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.ServiceName = "VsService";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // VsInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
    }
}
