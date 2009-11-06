// kmgs	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rmso	
// dncn	 By downloading, copying, installing or using the software you agree to this license.
// lesc	 If you do not agree to this license, do not download, install,
// kdrl	 copy or use the software.
// unfl	
// ytyg	                          License Agreement
// vtsf	         For OpenVss - Open Source Video Surveillance System
// xhdl	
// uxnv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// uwdx	
// gxgx	Third party copyrights are property of their respective owners.
// nkpi	
// htuw	Redistribution and use in source and binary forms, with or without modification,
// guux	are permitted provided that the following conditions are met:
// nltk	
// uxqe	  * Redistribution's of source code must retain the above copyright notice,
// ahhn	    this list of conditions and the following disclaimer.
// pvrx	
// khfb	  * Redistribution's in binary form must reproduce the above copyright notice,
// nbsl	    this list of conditions and the following disclaimer in the documentation
// djxd	    and/or other materials provided with the distribution.
// mhea	
// dqhi	  * Neither the name of the copyright holders nor the names of its contributors 
// dtcj	    may not be used to endorse or promote products derived from this software 
// gcxg	    without specific prior written permission.
// ccsm	
// cwmy	This software is provided by the copyright holders and contributors "as is" and
// pskm	any express or implied warranties, including, but not limited to, the implied
// shgk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// znrt	In no event shall the Prince of Songkla University or contributors be liable 
// chkz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nitr	(including, but not limited to, procurement of substitute goods or services;
// fvuk	loss of use, data, or profits; or business interruption) however caused
// dmib	and on any theory of liability, whether in contract, strict liability,
// qkap	or tort (including negligence or otherwise) arising in any way out of
// vflk	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Xml;


namespace VsSetup.configuration
{

    public class VsWebConfigData
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();

        public void saveSetting(string vsSettingsFile)
        {
            if (vsSettingsFile == null) return;
            
            string fullDirPath = Path.GetDirectoryName(vsSettingsFile);
            if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
           
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
                fs = new FileStream(vsSettingsFile, FileMode.Open,FileAccess.Read);
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
