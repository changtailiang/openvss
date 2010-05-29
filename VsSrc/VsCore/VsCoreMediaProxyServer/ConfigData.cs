// ezpa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cmij	
// iacw	 By downloading, copying, installing or using the software you agree to this license.
// qxhn	 If you do not agree to this license, do not download, install,
// guef	 copy or use the software.
// lvdo	
// fafz	                          License Agreement
// zzek	         For OpenVSS - Open Source Video Surveillance System
// zeru	
// edur	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pyuc	
// dzrx	Third party copyrights are property of their respective owners.
// wwrg	
// hfoj	Redistribution and use in source and binary forms, with or without modification,
// wbuc	are permitted provided that the following conditions are met:
// gijj	
// wrwl	  * Redistribution's of source code must retain the above copyright notice,
// fnid	    this list of conditions and the following disclaimer.
// anqm	
// ablf	  * Redistribution's in binary form must reproduce the above copyright notice,
// iidc	    this list of conditions and the following disclaimer in the documentation
// ixdu	    and/or other materials provided with the distribution.
// qiyd	
// islg	  * Neither the name of the copyright holders nor the names of its contributors 
// olgl	    may not be used to endorse or promote products derived from this software 
// cfri	    without specific prior written permission.
// ongu	
// pciu	This software is provided by the copyright holders and contributors "as is" and
// potx	any express or implied warranties, including, but not limited to, the implied
// fhby	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ocuw	In no event shall the Prince of Songkla University or contributors be liable 
// pevi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bkxp	(including, but not limited to, procurement of substitute goods or services;
// vzdd	loss of use, data, or profits; or business interruption) however caused
// quou	and on any theory of liability, whether in contract, strict liability,
// rjfo	or tort (including negligence or otherwise) arising in any way out of
// zdot	the use of this software, even if advised of the possibility of such damage.
// ynah	
// jhxz	Intelligent Systems Laboratory (iSys Lab)
// kvtj	Faculty of Engineering, Prince of Songkla University, THAILAND
// ryse	Project leader by Nikom SUVONVORN
// ftzp	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;
using System.Collections;

namespace Vs.Core.MediaProxyServer
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

        public static Hashtable[] loadCamConfig(string vsSettingsFile)
        {
            //List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            List<Hashtable> data = new List<Hashtable>();
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
                if (xmlIn.Name != "Cameras")
                    throw new ApplicationException("");

                xmlIn.Read();
                if (xmlIn.NodeType == XmlNodeType.EndElement)
                    xmlIn.Read();



                while (xmlIn.Name == "Camera")
                {

                    Hashtable cam = new Hashtable();

                    while (xmlIn.MoveToNextAttribute())
                    {

                        cam.Add(xmlIn.Name, xmlIn.Value);
                    }

                    data.Add(cam);

                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();
                }

                // close file
                xmlIn.Close();
                fs.Close();

            }

            return data.ToArray();
        }

        public static void savaCamConfig(string vsSettingsFile, Dictionary<string, string>[] data)
        {

            if (vsSettingsFile == null) return;

            //string fullDirPath = Path.GetDirectoryName(vsSettingsFile);
            //if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);


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
            xmlOut.WriteStartElement("Cameras");
            {

                foreach (Dictionary<string, string> cam in data)
                {
                    xmlOut.WriteStartElement("Camera");
                    foreach (KeyValuePair<string, string> kv in cam)
                    {
                        xmlOut.WriteAttributeString(kv.Key, kv.Value);
                    }
                    xmlOut.WriteEndElement();
                }
            }
            xmlOut.WriteEndElement();

            // close file
            xmlOut.Close();
            fs.Close();
        }
    }
}
