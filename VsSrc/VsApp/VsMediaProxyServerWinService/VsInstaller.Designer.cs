// keul	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yhhj	
// dmxw	 By downloading, copying, installing or using the software you agree to this license.
// kyws	 If you do not agree to this license, do not download, install,
// imyz	 copy or use the software.
// agvn	
// qyyy	                          License Agreement
// zaps	         For OpenVSS - Open Source Video Surveillance System
// lxwf	
// tyky	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jeof	
// xeck	Third party copyrights are property of their respective owners.
// dipm	
// afxd	Redistribution and use in source and binary forms, with or without modification,
// ihva	are permitted provided that the following conditions are met:
// iijd	
// xfkm	  * Redistribution's of source code must retain the above copyright notice,
// crzk	    this list of conditions and the following disclaimer.
// baqw	
// rppl	  * Redistribution's in binary form must reproduce the above copyright notice,
// wour	    this list of conditions and the following disclaimer in the documentation
// lcsf	    and/or other materials provided with the distribution.
// atwm	
// ckpa	  * Neither the name of the copyright holders nor the names of its contributors 
// vkhs	    may not be used to endorse or promote products derived from this software 
// tpim	    without specific prior written permission.
// ieka	
// pbls	This software is provided by the copyright holders and contributors "as is" and
// rkdu	any express or implied warranties, including, but not limited to, the implied
// nrsu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// meli	In no event shall the Prince of Songkla University or contributors be liable 
// unhr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kpah	(including, but not limited to, procurement of substitute goods or services;
// ixrg	loss of use, data, or profits; or business interruption) however caused
// gijg	and on any theory of liability, whether in contract, strict liability,
// ssqz	or tort (including negligence or otherwise) arising in any way out of
// hdus	the use of this software, even if advised of the possibility of such damage.
// gvme	
// smfo	Intelligent Systems Laboratory (iSys Lab)
// dzsv	Faculty of Engineering, Prince of Songkla University, THAILAND
// xsqz	Project leader by Nikom SUVONVORN
// aeku	Project website at http://code.google.com/p/openvss/

namespace VsMediaProxyServerWinService
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
            this.serviceInstaller.ServiceName = "VsMediaProxyServerWinService";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // VsInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstaller,
            this.serviceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
    }
}
