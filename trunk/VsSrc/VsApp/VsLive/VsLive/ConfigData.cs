// juor	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// yefj	
// qoee	 By downloading, copying, installing or using the software you agree to this license.
// fzni	 If you do not agree to this license, do not download, install,
// tzwl	 copy or use the software.
// ujdg	
// eezj	                          License Agreement
// lwgr	         For OpenVSS - Open Source Video Surveillance System
// wgyp	
// lprn	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// plec	
// ncod	Third party copyrights are property of their respective owners.
// wlhf	
// surz	Redistribution and use in source and binary forms, with or without modification,
// qhnu	are permitted provided that the following conditions are met:
// evyu	
// inhy	  * Redistribution's of source code must retain the above copyright notice,
// bywd	    this list of conditions and the following disclaimer.
// iivi	
// ebtb	  * Redistribution's in binary form must reproduce the above copyright notice,
// pvnz	    this list of conditions and the following disclaimer in the documentation
// obyc	    and/or other materials provided with the distribution.
// ozyd	
// cwjt	  * Neither the name of the copyright holders nor the names of its contributors 
// nkuz	    may not be used to endorse or promote products derived from this software 
// upcx	    without specific prior written permission.
// odwj	
// yiup	This software is provided by the copyright holders and contributors "as is" and
// olfi	any express or implied warranties, including, but not limited to, the implied
// iyfh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pfkb	In no event shall the Prince of Songkla University or contributors be liable 
// zsbl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zcvt	(including, but not limited to, procurement of substitute goods or services;
// gthz	loss of use, data, or profits; or business interruption) however caused
// splk	and on any theory of liability, whether in contract, strict liability,
// eoeg	or tort (including negligence or otherwise) arising in any way out of
// ejpq	the use of this software, even if advised of the possibility of such damage.
// ralo	
// fnkp	Intelligent Systems Laboratory (iSys Lab)
// fbyv	Faculty of Engineering, Prince of Songkla University, THAILAND
// ckkv	Project leader by Nikom SUVONVORN
// maju	Project website at http://code.google.com/p/openvss/

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
