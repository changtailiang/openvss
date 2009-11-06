// dexg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dlsv	
// ssby	 By downloading, copying, installing or using the software you agree to this license.
// ubfo	 If you do not agree to this license, do not download, install,
// rzky	 copy or use the software.
// kqug	
// acrp	                          License Agreement
// poed	         For OpenVss - Open Source Video Surveillance System
// rntx	
// gwqo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// nvvo	
// zvna	Third party copyrights are property of their respective owners.
// muab	
// btvm	Redistribution and use in source and binary forms, with or without modification,
// jrfb	are permitted provided that the following conditions are met:
// tdfd	
// oygh	  * Redistribution's of source code must retain the above copyright notice,
// hhhv	    this list of conditions and the following disclaimer.
// jwlp	
// ufgf	  * Redistribution's in binary form must reproduce the above copyright notice,
// ordv	    this list of conditions and the following disclaimer in the documentation
// nccy	    and/or other materials provided with the distribution.
// rgnp	
// qpuj	  * Neither the name of the copyright holders nor the names of its contributors 
// psab	    may not be used to endorse or promote products derived from this software 
// ogsf	    without specific prior written permission.
// mfse	
// igse	This software is provided by the copyright holders and contributors "as is" and
// kamb	any express or implied warranties, including, but not limited to, the implied
// ajpl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wipb	In no event shall the Prince of Songkla University or contributors be liable 
// tset	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bbzc	(including, but not limited to, procurement of substitute goods or services;
// efqi	loss of use, data, or profits; or business interruption) however caused
// zxii	and on any theory of liability, whether in contract, strict liability,
// jxpk	or tort (including negligence or otherwise) arising in any way out of
// ojep	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;

/// <summary>
/// Summary description for WebConfigData
/// </summary>
public class WebConfigData
{
	public WebConfigData()
	{  
	}


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
