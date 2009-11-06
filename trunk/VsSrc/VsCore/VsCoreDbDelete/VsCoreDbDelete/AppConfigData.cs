// yrfk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tkxv	
// yrrr	 By downloading, copying, installing or using the software you agree to this license.
// qfrs	 If you do not agree to this license, do not download, install,
// jkcf	 copy or use the software.
// xjmq	
// ypfm	                          License Agreement
// qcvi	         For OpenVss - Open Source Video Surveillance System
// yrkb	
// hxqe	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lhmh	
// ryzy	Third party copyrights are property of their respective owners.
// litf	
// cigp	Redistribution and use in source and binary forms, with or without modification,
// fple	are permitted provided that the following conditions are met:
// flfw	
// visy	  * Redistribution's of source code must retain the above copyright notice,
// uqkl	    this list of conditions and the following disclaimer.
// uytp	
// xfzz	  * Redistribution's in binary form must reproduce the above copyright notice,
// pgah	    this list of conditions and the following disclaimer in the documentation
// ipfp	    and/or other materials provided with the distribution.
// lvvs	
// lmza	  * Neither the name of the copyright holders nor the names of its contributors 
// bqli	    may not be used to endorse or promote products derived from this software 
// gaeu	    without specific prior written permission.
// xile	
// pqsa	This software is provided by the copyright holders and contributors "as is" and
// pmoz	any express or implied warranties, including, but not limited to, the implied
// kxnf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dcnz	In no event shall the Prince of Songkla University or contributors be liable 
// uszh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ztnh	(including, but not limited to, procurement of substitute goods or services;
// tqto	loss of use, data, or profits; or business interruption) however caused
// bfja	and on any theory of liability, whether in contract, strict liability,
// eaau	or tort (including negligence or otherwise) arising in any way out of
// dvcz	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Vs.Core.DbDelete
{
    public class AppConfigData
    {
        public MainWindow mainWindow = new MainWindow();
        public Autorun autorun = new Autorun();
        public LocalHost localHost = new LocalHost();
        public DataHost dataHost = new DataHost();
        public SmtpHost smtpHost = new SmtpHost();
        public Synchronize synchronize = new Synchronize();
        public Actions actions = new Actions();

        public void SaveSettings(string vsSettingsFile)
        {
            try
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
                xmlOut.WriteStartElement("Application");

                // main window node
                xmlOut.WriteStartElement("MainWindow");
                xmlOut.WriteAttributeString("x", mainWindow.x.ToString());
                xmlOut.WriteAttributeString("y", mainWindow.y.ToString());
                xmlOut.WriteAttributeString("width", mainWindow.width.ToString());
                xmlOut.WriteAttributeString("height", mainWindow.height.ToString());
                xmlOut.WriteAttributeString("cameraBar", mainWindow.cameraBar.ToString());
                xmlOut.WriteAttributeString("vsCameraBarWidth", mainWindow.vsCameraBarWidth.ToString());
                xmlOut.WriteEndElement();

                // Auto run (camera, channel, or page)
                xmlOut.WriteStartElement("Autorun");
                xmlOut.WriteAttributeString("Type", autorun.Type.ToString());
                xmlOut.WriteAttributeString("Item", autorun.Item.ToString());
                xmlOut.WriteEndElement();

                // localhost node
                xmlOut.WriteStartElement("LocalHost");
                xmlOut.WriteAttributeString("Host", localHost.Host);
                xmlOut.WriteAttributeString("Storage", localHost.Storage);
                xmlOut.WriteEndElement();

                // datahost node
                xmlOut.WriteStartElement("DataHost");
                xmlOut.WriteAttributeString("Host", dataHost.Host);
                xmlOut.WriteAttributeString("HostIP", dataHost.HostIP);
                xmlOut.WriteAttributeString("User", dataHost.User);
                xmlOut.WriteAttributeString("Passwd", dataHost.Passwd);
                xmlOut.WriteAttributeString("Database", dataHost.Database);
                xmlOut.WriteAttributeString("DatabaseClient", dataHost.DatabaseClient);
                xmlOut.WriteEndElement();

                // move to email node
                xmlOut.WriteStartElement("SmtpHost");
                xmlOut.WriteAttributeString("Host", smtpHost.Host);
                xmlOut.WriteAttributeString("User", smtpHost.User);
                xmlOut.WriteAttributeString("Passwd", smtpHost.Passwd);
                xmlOut.WriteAttributeString("EmailFrom", smtpHost.EmailFrom);
                xmlOut.WriteAttributeString("EmailTo", smtpHost.EmailTo);
                xmlOut.WriteEndElement();

                // synchronization
                xmlOut.WriteStartElement("Synchronize");
                xmlOut.WriteAttributeString("Timer", synchronize.Timer.ToString());
                xmlOut.WriteEndElement();

                // actions
                xmlOut.WriteStartElement("Actions");
                xmlOut.WriteAttributeString("Previewing", actions.Previewing.ToString());
                xmlOut.WriteAttributeString("Streaming", actions.Streaming.ToString());
                xmlOut.WriteAttributeString("Analysing", actions.Analysing.ToString());
                xmlOut.WriteAttributeString("Recording", actions.Recording.ToString());
                xmlOut.WriteAttributeString("DataAlerting", actions.DataAlerting.ToString());
                xmlOut.WriteAttributeString("EventAlerting", actions.EventAlerting.ToString());
                xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                // close file
                xmlOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool LoadSettings(string vsSettingsFile)
        {
            bool ret = false;

            // check file existance
            if (File.Exists(vsSettingsFile))
            {
                //  VsSplasher.Status = "Load setting...";

                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsSettingsFile, FileMode.Open, FileAccess.Read);
                    // create XML reader
                    xmlIn = new XmlTextReader(fs);

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent();

                    // check for main node
                    if (xmlIn.Name != "Application")
                        throw new ApplicationException("");

                    // ------------------------------------------------------------------------
                    // move to main window node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "MainWindow")
                        throw new ApplicationException("");

                    mainWindow.x = Convert.ToInt32(xmlIn.GetAttribute("x"));
                    mainWindow.y = Convert.ToInt32(xmlIn.GetAttribute("y"));
                    mainWindow.width = Convert.ToInt32(xmlIn.GetAttribute("width"));
                    mainWindow.height = Convert.ToInt32(xmlIn.GetAttribute("height"));

                    mainWindow.cameraBar = Convert.ToBoolean(xmlIn.GetAttribute("cameraBar"));
                    mainWindow.vsCameraBarWidth = Convert.ToInt32(xmlIn.GetAttribute("vsCameraBarWidth"));

                    // ------------------------------------------------------------------------
                    // move to Auto run (camera, channel, or page) node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Autorun")
                        throw new ApplicationException("");

                    autorun.Type = Convert.ToInt32(xmlIn.GetAttribute("Type"));
                    autorun.Item = Convert.ToInt32(xmlIn.GetAttribute("Item"));

                    // ------------------------------------------------------------------------
                    // move to localhost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "LocalHost")
                        throw new ApplicationException("");

                    localHost.Host = xmlIn.GetAttribute("Host");
                    localHost.Storage = xmlIn.GetAttribute("Storage");

                    // ------------------------------------------------------------------------
                    // move to datahost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "DataHost")
                        throw new ApplicationException("");

                    dataHost.HostIP = xmlIn.GetAttribute("Host");
                    dataHost.HostIP = xmlIn.GetAttribute("HostIP");
                    dataHost.User = xmlIn.GetAttribute("User");
                    dataHost.Passwd = xmlIn.GetAttribute("Passwd");
                    dataHost.Database = xmlIn.GetAttribute("Database");
                    dataHost.DatabaseClient = xmlIn.GetAttribute("DatabaseClient");

                    // ------------------------------------------------------------------------
                    // move to email node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "SmtpHost")
                        throw new ApplicationException("");

                    smtpHost.Host = xmlIn.GetAttribute("Host");
                    smtpHost.User = xmlIn.GetAttribute("User");
                    smtpHost.Passwd = xmlIn.GetAttribute("Passwd");
                    smtpHost.EmailFrom = xmlIn.GetAttribute("EmailFrom");
                    smtpHost.EmailTo = xmlIn.GetAttribute("EmailTo");

                    //string test = VsCryptography.Decrypt(VsCryptography.Encrypt(vsSmtpPasswd, "nikom"), "nikom");

                    // ------------------------------------------------------------------------
                    // move to synchronization node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Synchronize")
                        throw new ApplicationException("");

                    synchronize.Timer = Convert.ToInt32(xmlIn.GetAttribute("Timer"));
                    if (synchronize.Timer == 0) synchronize.Timer = 100;

                    // ------------------------------------------------------------------------
                    // move to actions node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Actions")
                        throw new ApplicationException("");

                    actions.Previewing = Convert.ToBoolean(xmlIn.GetAttribute("Previewing"));
                    actions.Streaming = Convert.ToBoolean(xmlIn.GetAttribute("Streaming"));
                    actions.Analysing = Convert.ToBoolean(xmlIn.GetAttribute("Analysing"));
                    actions.Recording = Convert.ToBoolean(xmlIn.GetAttribute("Recording"));
                    actions.DataAlerting = Convert.ToBoolean(xmlIn.GetAttribute("DataAlerting"));
                    actions.EventAlerting = Convert.ToBoolean(xmlIn.GetAttribute("EventAlerting"));

                    // ------------------------------------------------------------------------

                }
                // catch any exceptions
                catch (Exception)
                {
                }
                finally
                {
                    if (xmlIn != null)
                        xmlIn.Close();
                }
            }
            return ret;
        }

    }
    #region struct element
    public struct MainWindow
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public bool cameraBar;
        public int vsCameraBarWidth;
    }

    public struct Autorun
    {
        public int Type;
        public int Item;
    }

    public struct LocalHost
    {
        public string Host;
        public string Storage;
    }

    public struct DataHost
    {
        public string Host;
        public string HostIP;
        public string User;
        public string Passwd;
        public string Database;
        public string DatabaseClient;
    }

    public struct SmtpHost
    {
        public string Host;
        public string User;
        public string Passwd;
        public string EmailFrom;
        public string EmailTo;
    }

    public struct Synchronize
    {
        public int Timer;
    }

    public struct Actions
    {
        public bool Previewing;
        public bool Streaming;
        public bool Analysing;
        public bool Recording;
        public bool DataAlerting;
        public bool EventAlerting;
    }
    #endregion
}
