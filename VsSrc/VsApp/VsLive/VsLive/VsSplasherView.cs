// ckrb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dtdk	
// kjoz	 By downloading, copying, installing or using the software you agree to this license.
// cmei	 If you do not agree to this license, do not download, install,
// wylq	 copy or use the software.
// lria	
// tvux	                          License Agreement
// yroe	         For OpenVSS - Open Source Video Surveillance System
// nujo	
// zvwd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jwci	
// stsd	Third party copyrights are property of their respective owners.
// vjqf	
// efrl	Redistribution and use in source and binary forms, with or without modification,
// cqii	are permitted provided that the following conditions are met:
// ygms	
// vklh	  * Redistribution's of source code must retain the above copyright notice,
// cqjb	    this list of conditions and the following disclaimer.
// chhp	
// oahz	  * Redistribution's in binary form must reproduce the above copyright notice,
// crbo	    this list of conditions and the following disclaimer in the documentation
// bizh	    and/or other materials provided with the distribution.
// cxmi	
// nnfc	  * Neither the name of the copyright holders nor the names of its contributors 
// kjni	    may not be used to endorse or promote products derived from this software 
// hkaf	    without specific prior written permission.
// apdx	
// ycwb	This software is provided by the copyright holders and contributors "as is" and
// jjfg	any express or implied warranties, including, but not limited to, the implied
// exrm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// keff	In no event shall the Prince of Songkla University or contributors be liable 
// dano	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ceef	(including, but not limited to, procurement of substitute goods or services;
// myrs	loss of use, data, or profits; or business interruption) however caused
// rwol	and on any theory of liability, whether in contract, strict liability,
// fcja	or tort (including negligence or otherwise) arising in any way out of
// akye	the use of this software, even if advised of the possibility of such damage.
// hyxn	
// rayd	Intelligent Systems Laboratory (iSys Lab)
// fvcz	Faculty of Engineering, Prince of Songkla University, THAILAND
// covt	Project leader by Nikom SUVONVORN
// xrok	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
//using Vs.Core;

namespace Vs.Monitor
{
    public partial class VsSplasherView : Form, VsISplasher
    {
        public bool Blocked = true;
        public bool Connected = false;

        private string configPath;

        public VsSplasherView()
        {
            InitializeComponent();

            ConfigData config = new ConfigData();

            configPath =Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"OpenVss\\VsClient") ;

            copyAllconfig();

            try
            {
                config.LoadSettings(Path.Combine(configPath,"ServerConn.config"));

                textBox1.Text = config.data["server"];
                textBox2.Text = config.data["user"];
                textBox3.Text = config.data["pass"];
            }
            catch { }
        }
        public void LoginSerivce()
        {
            try
            {
                //this.allcam = allcam;
                //this.setServer = setServer;
                labelStatus.Invoke(new MethodInvoker(labelStatus.Hide));
                panelLogin.Invoke(new MethodInvoker(panelLogin.Show));
                //labelStatus.Visible = false;
                //panelLogin.Visible = true;
            }
            catch (Exception err)
            {
                //logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
        void VsISplasher.SetStatusInfo(string StatusInfo)
        {
            labelStatus.Text = StatusInfo;
            // labelStatus.Text = StatusInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                panelLogin.Hide();
                labelStatus.Show();
                labelStatus.Text = "Logging...";
                System.Threading.Thread.Sleep(10);

                // Vs.Monitor.VsService.VsServiceSoapClient service = new Vs.Monitor.VsService.VsServiceSoapClient();

                VsService.VsService service = new Vs.Monitor.VsService.VsService();

                service.Url = "http://" + textBox1.Text + "/vsservice/service.asmx";

                service.getCamConfigToStringAsync();
                setCamConfig(service.getCamConfigToString());
                setIntervalToAllCam(100);

                //setServer();
                //allcam();
                Connected = true;
                Blocked = false;

                ConfigData config = new ConfigData();

                config.data["server"] = textBox1.Text;
                config.data["user"] = textBox2.Text;
                config.data["pass"] = textBox3.Text;

                config.saveSetting(Path.Combine(configPath, "ServerConn.config"));

                // setCamConfig();

            }
            catch (Exception err)
            {

                Connected = false;
                Blocked = false;
                  Application.Exit();
                 //logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void setIntervalToAllCam(int interval)
        {
            string fullFileName = Path.Combine(configPath, "cameras.config");

            Dictionary<string, string>[] data = loadSettings(fullFileName);

            foreach (Dictionary<string, string> cam in data)
            {
                if (cam.ContainsKey("interval"))
                {
                    cam["interval"] = interval.ToString();
                }
                else
                {
                    cam.Add("interval", interval.ToString());
                }
            }

            savaSetting(Path.Combine(configPath, "cameras.config"), data);
        }


        private Dictionary<string, string>[] loadSettings(string vsSettingsFile)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

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

                    Dictionary<string, string> cam = new Dictionary<string, string>();

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

        private void savaSetting(string vsSettingsFile, Dictionary<string, string>[] data)
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

        private void setCamConfig(string camConfig)
        {

            string fullFileName = Path.Combine(configPath,"cameras.config");

            TextWriter tw = new StreamWriter(new FileStream(fullFileName, FileMode.Create));

            // write a line of text to the file
            tw.Write(camConfig);

            // close the stream
            tw.Close();
        }

        private void copyAllconfig()
        {
            string vsAppPath = Path.GetDirectoryName(Application.ExecutablePath);

            string vsSettingsFile = Path.Combine(vsAppPath, "app.config");
           // string vsCamerasFile = Path.Combine(vsAppPath, "cameras.config");
           // string vsChannelsFile = Path.Combine(vsAppPath, "channels.config");
           // string vsPagesFile = Path.Combine(vsAppPath, "pages.config");

            if (!Directory.Exists(configPath))
            {
                Directory.CreateDirectory(configPath);
            }

            string vsSettingsDestFile = Path.Combine(configPath, "app.config");
            //string vsCamerasDestFile = Path.Combine(configPath, "cameras.config");
            //string vsChannelsDestFile = Path.Combine(configPath, "channels.config");
            //string vsPagesDestFile = Path.Combine(configPath, "pages.config");

            File.Copy(vsSettingsFile, vsSettingsDestFile,true);
            //File.Copy(vsCamerasFile, vsCamerasDestFile,true);
            //File.Copy(vsChannelsFile, vsChannelsDestFile,true);
           // File.Copy(vsPagesFile, vsPagesDestFile,true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connected = false;
            Blocked = false;
            Application.Exit();
        }
    }
}
