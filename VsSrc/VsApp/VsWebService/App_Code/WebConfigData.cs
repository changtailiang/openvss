// kkon	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// aopc	
// kwub	 By downloading, copying, installing or using the software you agree to this license.
// usns	 If you do not agree to this license, do not download, install,
// paji	 copy or use the software.
// zrqs	
// mabl	                          License Agreement
// scyr	         For OpenVSS - Open Source Video Surveillance System
// avsd	
// khej	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lrpd	
// eida	Third party copyrights are property of their respective owners.
// nbrf	
// jrft	Redistribution and use in source and binary forms, with or without modification,
// twba	are permitted provided that the following conditions are met:
// mdki	
// yday	  * Redistribution's of source code must retain the above copyright notice,
// zkhi	    this list of conditions and the following disclaimer.
// vzwh	
// cmnd	  * Redistribution's in binary form must reproduce the above copyright notice,
// xayq	    this list of conditions and the following disclaimer in the documentation
// lsij	    and/or other materials provided with the distribution.
// qzjo	
// gewi	  * Neither the name of the copyright holders nor the names of its contributors 
// hhfb	    may not be used to endorse or promote products derived from this software 
// iebd	    without specific prior written permission.
// tijj	
// vxrh	This software is provided by the copyright holders and contributors "as is" and
// jxdm	any express or implied warranties, including, but not limited to, the implied
// etwf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vria	In no event shall the Prince of Songkla University or contributors be liable 
// atcr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cnau	(including, but not limited to, procurement of substitute goods or services;
// hmvs	loss of use, data, or profits; or business interruption) however caused
// yuxc	and on any theory of liability, whether in contract, strict liability,
// iynt	or tort (including negligence or otherwise) arising in any way out of
// icei	the use of this software, even if advised of the possibility of such damage.
// bkdo	
// kzgq	Intelligent Systems Laboratory (iSys Lab)
// wbcz	Faculty of Engineering, Prince of Songkla University, THAILAND
// gshh	Project leader by Nikom SUVONVORN
// xwzw	Project website at http://code.google.com/p/openvss/

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
