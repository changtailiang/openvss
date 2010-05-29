// agtp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lanr	
// ashg	 By downloading, copying, installing or using the software you agree to this license.
// sqjn	 If you do not agree to this license, do not download, install,
// xhem	 copy or use the software.
// cisl	
// gadz	                          License Agreement
// gjrc	         For OpenVSS - Open Source Video Surveillance System
// hfmp	
// mdxq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lymk	
// ojpv	Third party copyrights are property of their respective owners.
// eotm	
// rmdr	Redistribution and use in source and binary forms, with or without modification,
// oiik	are permitted provided that the following conditions are met:
// xnlr	
// aezn	  * Redistribution's of source code must retain the above copyright notice,
// duau	    this list of conditions and the following disclaimer.
// koae	
// vhwx	  * Redistribution's in binary form must reproduce the above copyright notice,
// khvr	    this list of conditions and the following disclaimer in the documentation
// pflu	    and/or other materials provided with the distribution.
// bvae	
// umtx	  * Neither the name of the copyright holders nor the names of its contributors 
// nvjk	    may not be used to endorse or promote products derived from this software 
// kcsk	    without specific prior written permission.
// nzbd	
// lzvh	This software is provided by the copyright holders and contributors "as is" and
// llzp	any express or implied warranties, including, but not limited to, the implied
// stbv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// teli	In no event shall the Prince of Songkla University or contributors be liable 
// twzy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ucrz	(including, but not limited to, procurement of substitute goods or services;
// xmni	loss of use, data, or profits; or business interruption) however caused
// pleq	and on any theory of liability, whether in contract, strict liability,
// dhic	or tort (including negligence or otherwise) arising in any way out of
// ztsi	the use of this software, even if advised of the possibility of such damage.
// mdft	
// uoqf	Intelligent Systems Laboratory (iSys Lab)
// qkqq	Faculty of Engineering, Prince of Songkla University, THAILAND
// zdii	Project leader by Nikom SUVONVORN
// hvjz	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Vs.Monitor
{
    partial class VsAboutBox : Form
    {
        public VsAboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("About {0} {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0} {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
