// capz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kzyj	
// knjr	 By downloading, copying, installing or using the software you agree to this license.
// hixn	 If you do not agree to this license, do not download, install,
// dnpb	 copy or use the software.
// mejj	
// kkrg	                          License Agreement
// vayn	         For OpenVSS - Open Source Video Surveillance System
// tcht	
// uvmu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ebig	
// ziyv	Third party copyrights are property of their respective owners.
// urbp	
// dwoy	Redistribution and use in source and binary forms, with or without modification,
// rgpa	are permitted provided that the following conditions are met:
// irnk	
// ovxf	  * Redistribution's of source code must retain the above copyright notice,
// aeti	    this list of conditions and the following disclaimer.
// buwk	
// wdkb	  * Redistribution's in binary form must reproduce the above copyright notice,
// lvme	    this list of conditions and the following disclaimer in the documentation
// yjkx	    and/or other materials provided with the distribution.
// njbo	
// fmmn	  * Neither the name of the copyright holders nor the names of its contributors 
// oxrd	    may not be used to endorse or promote products derived from this software 
// lsvp	    without specific prior written permission.
// xtni	
// adco	This software is provided by the copyright holders and contributors "as is" and
// voom	any express or implied warranties, including, but not limited to, the implied
// eime	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kasr	In no event shall the Prince of Songkla University or contributors be liable 
// cecp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ijwy	(including, but not limited to, procurement of substitute goods or services;
// lgpt	loss of use, data, or profits; or business interruption) however caused
// axgf	and on any theory of liability, whether in contract, strict liability,
// vcwj	or tort (including negligence or otherwise) arising in any way out of
// hnsr	the use of this software, even if advised of the possibility of such damage.
// xzif	
// lmsl	Intelligent Systems Laboratory (iSys Lab)
// adms	Faculty of Engineering, Prince of Songkla University, THAILAND
// qyar	Project leader by Nikom SUVONVORN
// hdcp	Project website at http://code.google.com/p/openvss/

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

/// <summary>
/// Summary description for CamConfigData
/// </summary>
public class CamConfigData
{
    public CamConfigData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region camera attribute
    public int id;
    public string name;
    public string desc;

    public bool run;
    public bool analyse;
    public bool record;
    public bool events;
    public bool data;

    public string provider;
    public string source;
    public string analyzer;

    public int ThresholdAlpha;
    public int ThresholdSigma;

    public string endcoder;

    public int ImageWidth;
    public int ImageHeight;

    public string CodecsName;
    public int Quality;

    #endregion

    public static CamConfigData[] LoadSettings(string vsSettingsFile)
    {

        List<CamConfigData> data = new List<CamConfigData>();
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

            CamConfigData obj;

            while (xmlIn.Name == "Camera")
            {
                obj = new CamConfigData();

                obj.id = Convert.ToInt32(xmlIn.GetAttribute("id"));
                obj.name = xmlIn.GetAttribute("name");
                obj.desc = xmlIn.GetAttribute("desc");

                obj.run = Convert.ToBoolean(xmlIn.GetAttribute("run"));
                obj.analyse = Convert.ToBoolean(xmlIn.GetAttribute("analyse"));
                obj.record = Convert.ToBoolean(xmlIn.GetAttribute("record"));
                obj.events = Convert.ToBoolean(xmlIn.GetAttribute("event"));
                obj.data = Convert.ToBoolean(xmlIn.GetAttribute("data"));

                obj.provider = xmlIn.GetAttribute("provider");
                obj.source = xmlIn.GetAttribute("source");
                obj.analyzer = xmlIn.GetAttribute("analyzer");

                obj.ThresholdAlpha = Convert.ToInt32(xmlIn.GetAttribute("ThresholdAlpha"));
                obj.ThresholdSigma = Convert.ToInt32(xmlIn.GetAttribute("ThresholdSigma"));
                obj.endcoder = xmlIn.GetAttribute("encoder");

                obj.ImageWidth = Convert.ToInt32(xmlIn.GetAttribute("ImageWidth"));
                obj.ImageHeight = Convert.ToInt32(xmlIn.GetAttribute("ImageHeight"));

                obj.CodecsName = xmlIn.GetAttribute("CodecsName");
                obj.Quality = Convert.ToInt32(xmlIn.GetAttribute("Quality"));

                data.Add(obj);

                xmlIn.Read();
                if (xmlIn.NodeType == XmlNodeType.EndElement)
                    xmlIn.Read();
            }

            // close file
            xmlIn.Close();
            fs.Close();

            return data.ToArray();
        }
        else
        {
            return data.ToArray();
        }
    }

}
