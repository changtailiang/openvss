// odmd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// puhe	
// isty	 By downloading, copying, installing or using the software you agree to this license.
// wjnl	 If you do not agree to this license, do not download, install,
// mlbd	 copy or use the software.
// deem	
// konp	                          License Agreement
// mmqf	         For OpenVss - Open Source Video Surveillance System
// pgom	
// futa	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pamg	
// izot	Third party copyrights are property of their respective owners.
// bxvr	
// neak	Redistribution and use in source and binary forms, with or without modification,
// yzta	are permitted provided that the following conditions are met:
// gssv	
// cniq	  * Redistribution's of source code must retain the above copyright notice,
// vafs	    this list of conditions and the following disclaimer.
// saoc	
// syek	  * Redistribution's in binary form must reproduce the above copyright notice,
// zunp	    this list of conditions and the following disclaimer in the documentation
// qysl	    and/or other materials provided with the distribution.
// fdng	
// astw	  * Neither the name of the copyright holders nor the names of its contributors 
// hqeu	    may not be used to endorse or promote products derived from this software 
// qyxa	    without specific prior written permission.
// rdzm	
// qysa	This software is provided by the copyright holders and contributors "as is" and
// vial	any express or implied warranties, including, but not limited to, the implied
// edfd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vxls	In no event shall the Prince of Songkla University or contributors be liable 
// nzra	for any direct, indirect, incidental, special, exemplary, or consequential damages
// grub	(including, but not limited to, procurement of substitute goods or services;
// tjub	loss of use, data, or profits; or business interruption) however caused
// xnxn	and on any theory of liability, whether in contract, strict liability,
// zfvg	or tort (including negligence or otherwise) arising in any way out of
// lmlr	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Vs.Playback
{
    partial class VsAboutBox : Form
    {
        public VsAboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
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
