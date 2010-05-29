// bipk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jzyu	
// ccss	 By downloading, copying, installing or using the software you agree to this license.
// dmzv	 If you do not agree to this license, do not download, install,
// sckp	 copy or use the software.
// gyxm	
// ejao	                          License Agreement
// wkdx	         For OpenVSS - Open Source Video Surveillance System
// ugvl	
// eorq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fjhk	
// wmhs	Third party copyrights are property of their respective owners.
// gqkf	
// wnyd	Redistribution and use in source and binary forms, with or without modification,
// kdgz	are permitted provided that the following conditions are met:
// yjxs	
// yuxw	  * Redistribution's of source code must retain the above copyright notice,
// roqd	    this list of conditions and the following disclaimer.
// kujw	
// rmqr	  * Redistribution's in binary form must reproduce the above copyright notice,
// chig	    this list of conditions and the following disclaimer in the documentation
// zybh	    and/or other materials provided with the distribution.
// irab	
// isrw	  * Neither the name of the copyright holders nor the names of its contributors 
// momb	    may not be used to endorse or promote products derived from this software 
// okbr	    without specific prior written permission.
// zgvb	
// dbmx	This software is provided by the copyright holders and contributors "as is" and
// mowq	any express or implied warranties, including, but not limited to, the implied
// arta	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tqoz	In no event shall the Prince of Songkla University or contributors be liable 
// opvs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dmkd	(including, but not limited to, procurement of substitute goods or services;
// apcr	loss of use, data, or profits; or business interruption) however caused
// grgs	and on any theory of liability, whether in contract, strict liability,
// czdg	or tort (including negligence or otherwise) arising in any way out of
// fcou	the use of this software, even if advised of the possibility of such damage.
// vbwu	
// vlhy	Intelligent Systems Laboratory (iSys Lab)
// wbck	Faculty of Engineering, Prince of Songkla University, THAILAND
// lcyq	Project leader by Nikom SUVONVORN
// qjxx	Project website at http://code.google.com/p/openvss/

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
