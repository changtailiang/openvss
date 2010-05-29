// zekq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zcpw	
// oekn	 By downloading, copying, installing or using the software you agree to this license.
// zkco	 If you do not agree to this license, do not download, install,
// zyvk	 copy or use the software.
// ivmg	
// cnax	                          License Agreement
// oarp	         For OpenVSS - Open Source Video Surveillance System
// envw	
// exqw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// emdd	
// trdu	Third party copyrights are property of their respective owners.
// lbaq	
// bufe	Redistribution and use in source and binary forms, with or without modification,
// rdom	are permitted provided that the following conditions are met:
// bshn	
// mvim	  * Redistribution's of source code must retain the above copyright notice,
// ofjb	    this list of conditions and the following disclaimer.
// iygw	
// rjnk	  * Redistribution's in binary form must reproduce the above copyright notice,
// jglm	    this list of conditions and the following disclaimer in the documentation
// aanj	    and/or other materials provided with the distribution.
// hrfa	
// jevl	  * Neither the name of the copyright holders nor the names of its contributors 
// eqrx	    may not be used to endorse or promote products derived from this software 
// irgf	    without specific prior written permission.
// syic	
// ojmi	This software is provided by the copyright holders and contributors "as is" and
// qdcv	any express or implied warranties, including, but not limited to, the implied
// gvnl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hyex	In no event shall the Prince of Songkla University or contributors be liable 
// aird	for any direct, indirect, incidental, special, exemplary, or consequential damages
// durb	(including, but not limited to, procurement of substitute goods or services;
// spbs	loss of use, data, or profits; or business interruption) however caused
// zgub	and on any theory of liability, whether in contract, strict liability,
// rlvy	or tort (including negligence or otherwise) arising in any way out of
// ewkf	the use of this software, even if advised of the possibility of such damage.
// bzfj	
// cfqj	Intelligent Systems Laboratory (iSys Lab)
// mjfj	Faculty of Engineering, Prince of Songkla University, THAILAND
// hfyt	Project leader by Nikom SUVONVORN
// rlpa	Project website at http://code.google.com/p/openvss/

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
