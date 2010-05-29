// kpha	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pusy	
// oaas	 By downloading, copying, installing or using the software you agree to this license.
// bahc	 If you do not agree to this license, do not download, install,
// echt	 copy or use the software.
// unlt	
// dyeg	                          License Agreement
// pisw	         For OpenVSS - Open Source Video Surveillance System
// hogk	
// xgqp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// utof	
// jvoy	Third party copyrights are property of their respective owners.
// ojwo	
// cgew	Redistribution and use in source and binary forms, with or without modification,
// dowr	are permitted provided that the following conditions are met:
// qljg	
// heln	  * Redistribution's of source code must retain the above copyright notice,
// txfy	    this list of conditions and the following disclaimer.
// mrya	
// zgki	  * Redistribution's in binary form must reproduce the above copyright notice,
// kfsf	    this list of conditions and the following disclaimer in the documentation
// meua	    and/or other materials provided with the distribution.
// jkgj	
// jzzi	  * Neither the name of the copyright holders nor the names of its contributors 
// khxf	    may not be used to endorse or promote products derived from this software 
// kafq	    without specific prior written permission.
// exck	
// hdxx	This software is provided by the copyright holders and contributors "as is" and
// dogk	any express or implied warranties, including, but not limited to, the implied
// tdud	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jldi	In no event shall the Prince of Songkla University or contributors be liable 
// rwon	for any direct, indirect, incidental, special, exemplary, or consequential damages
// sqqr	(including, but not limited to, procurement of substitute goods or services;
// ieyj	loss of use, data, or profits; or business interruption) however caused
// abbo	and on any theory of liability, whether in contract, strict liability,
// bjsg	or tort (including negligence or otherwise) arising in any way out of
// mjfv	the use of this software, even if advised of the possibility of such damage.
// soog	
// nuvz	Intelligent Systems Laboratory (iSys Lab)
// xwzi	Faculty of Engineering, Prince of Songkla University, THAILAND
// ipsr	Project leader by Nikom SUVONVORN
// ngoy	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Vs.Playback
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
