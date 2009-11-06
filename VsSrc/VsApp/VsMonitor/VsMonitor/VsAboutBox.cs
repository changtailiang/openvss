// qjap	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lbej	
// cize	 By downloading, copying, installing or using the software you agree to this license.
// lbnb	 If you do not agree to this license, do not download, install,
// tzru	 copy or use the software.
// dhii	
// osrk	                          License Agreement
// vqiw	         For OpenVss - Open Source Video Surveillance System
// cxlp	
// fdmw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// knvm	
// lbeu	Third party copyrights are property of their respective owners.
// zvhq	
// ktqj	Redistribution and use in source and binary forms, with or without modification,
// arbs	are permitted provided that the following conditions are met:
// junm	
// adbn	  * Redistribution's of source code must retain the above copyright notice,
// pyvq	    this list of conditions and the following disclaimer.
// mvjp	
// lvxm	  * Redistribution's in binary form must reproduce the above copyright notice,
// nwka	    this list of conditions and the following disclaimer in the documentation
// irlj	    and/or other materials provided with the distribution.
// hbon	
// cumq	  * Neither the name of the copyright holders nor the names of its contributors 
// zili	    may not be used to endorse or promote products derived from this software 
// aqeb	    without specific prior written permission.
// zrep	
// jaxe	This software is provided by the copyright holders and contributors "as is" and
// upfn	any express or implied warranties, including, but not limited to, the implied
// jndj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rrgn	In no event shall the Prince of Songkla University or contributors be liable 
// kins	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jsqc	(including, but not limited to, procurement of substitute goods or services;
// kolw	loss of use, data, or profits; or business interruption) however caused
// rjaq	and on any theory of liability, whether in contract, strict liability,
// nvzg	or tort (including negligence or otherwise) arising in any way out of
// ejsn	the use of this software, even if advised of the possibility of such damage.

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
