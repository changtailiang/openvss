// vbfb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ktqc	
// cyex	 By downloading, copying, installing or using the software you agree to this license.
// fenn	 If you do not agree to this license, do not download, install,
// rgej	 copy or use the software.
// yppi	
// ouoz	                          License Agreement
// mlht	         For OpenVss - Open Source Video Surveillance System
// rzsg	
// hgzk	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hncu	
// dznp	Third party copyrights are property of their respective owners.
// skqy	
// ycdf	Redistribution and use in source and binary forms, with or without modification,
// lxmq	are permitted provided that the following conditions are met:
// frqr	
// rkgg	  * Redistribution's of source code must retain the above copyright notice,
// lhgk	    this list of conditions and the following disclaimer.
// gtck	
// nuep	  * Redistribution's in binary form must reproduce the above copyright notice,
// gyhb	    this list of conditions and the following disclaimer in the documentation
// ujuo	    and/or other materials provided with the distribution.
// vnuj	
// uifq	  * Neither the name of the copyright holders nor the names of its contributors 
// wlds	    may not be used to endorse or promote products derived from this software 
// thdk	    without specific prior written permission.
// efre	
// atsq	This software is provided by the copyright holders and contributors "as is" and
// swkg	any express or implied warranties, including, but not limited to, the implied
// kpwi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// prky	In no event shall the Prince of Songkla University or contributors be liable 
// mxqy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// olnb	(including, but not limited to, procurement of substitute goods or services;
// rmwy	loss of use, data, or profits; or business interruption) however caused
// uwxo	and on any theory of liability, whether in contract, strict liability,
// rqoc	or tort (including negligence or otherwise) arising in any way out of
// vdqx	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.IO;

namespace Vs.Monitor
{
    public class ConfigData
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();

        public void saveSetting(string vsSettingsFile)
        {
            if (vsSettingsFile == null) return;

            string fullDirPath = Path.GetDirectoryName(vsSettingsFile);

            try
            {
                if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
            }
            catch { }

            // open file
            FileStream fs = new FileStream(vsSettingsFile, FileMode.Create);

            // create XML writer
            XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.UTF8);

            // use indenting for readability
            xmlOut.Formatting = Formatting.Indented;

            // start document
            xmlOut.WriteStartDocument();
            xmlOut.WriteComment("Visual Surveillance System configuration file");

            // main node
            xmlOut.WriteStartElement("appSettings");
            {
                foreach (KeyValuePair<string, string> kv in data)
                {
                    xmlOut.WriteStartElement("add");
                    {
                        xmlOut.WriteAttributeString("key", kv.Key);
                        xmlOut.WriteAttributeString("value", kv.Value);

                    }
                    xmlOut.WriteEndElement();
                }
            }
            xmlOut.WriteEndElement();

            // close file
            xmlOut.Close();
            fs.Close();
        }
        public bool LoadSettings(string vsSettingsFile)
        {
            // check file existance
            if (File.Exists(vsSettingsFile))
            {
                //  VsSplasher.Status = "Load setting...";

                FileStream fs = null;
                XmlTextReader xmlIn = null;


                // open file
                fs = new FileStream(vsSettingsFile, FileMode.Open, FileAccess.Read);
                // create XML reader
                xmlIn = new XmlTextReader(fs);

                xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                xmlIn.MoveToContent();

                // check for main node
                if (xmlIn.Name != "appSettings")
                    throw new ApplicationException("");

                xmlIn.Read();
                if (xmlIn.NodeType == XmlNodeType.EndElement)
                    xmlIn.Read();

                while (xmlIn.Name == "add")
                {
                    data.Add(xmlIn.GetAttribute("key"), xmlIn.GetAttribute("value"));


                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();
                }

                // close file
                xmlIn.Close();
                fs.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
