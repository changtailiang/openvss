// chjp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nteq	
// xkbc	 By downloading, copying, installing or using the software you agree to this license.
// iyts	 If you do not agree to this license, do not download, install,
// cccv	 copy or use the software.
// bjvf	
// mkce	                          License Agreement
// ccjg	         For OpenVSS - Open Source Video Surveillance System
// nccz	
// yzdf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jzvv	
// fxxz	Third party copyrights are property of their respective owners.
// gmnh	
// znws	Redistribution and use in source and binary forms, with or without modification,
// mddd	are permitted provided that the following conditions are met:
// ranv	
// bvog	  * Redistribution's of source code must retain the above copyright notice,
// vttd	    this list of conditions and the following disclaimer.
// yxlb	
// oaao	  * Redistribution's in binary form must reproduce the above copyright notice,
// ndxq	    this list of conditions and the following disclaimer in the documentation
// obga	    and/or other materials provided with the distribution.
// fknv	
// vaoj	  * Neither the name of the copyright holders nor the names of its contributors 
// mzuj	    may not be used to endorse or promote products derived from this software 
// jrdm	    without specific prior written permission.
// skic	
// cudl	This software is provided by the copyright holders and contributors "as is" and
// coqo	any express or implied warranties, including, but not limited to, the implied
// cwhz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ooal	In no event shall the Prince of Songkla University or contributors be liable 
// gyhy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ibpo	(including, but not limited to, procurement of substitute goods or services;
// gqfv	loss of use, data, or profits; or business interruption) however caused
// zkyd	and on any theory of liability, whether in contract, strict liability,
// texl	or tort (including negligence or otherwise) arising in any way out of
// gbsh	the use of this software, even if advised of the possibility of such damage.
// kahp	
// suvv	Intelligent Systems Laboratory (iSys Lab)
// rsgu	Faculty of Engineering, Prince of Songkla University, THAILAND
// djtb	Project leader by Nikom SUVONVORN
// fpfm	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using Vs.Core.DbDelete;
using System.Reflection;
using System.IO;
using System.Xml;

namespace VsDbDeleteExc
{
    class Program
    {
        static string vsDbHost;
        static string vsDbHostIP;
        static string vsDbUser;
        static string vsDbPasswd;
        static string vsDbDatabase;
        static string vsDbDatabaseClient;

        private static DateTime timeDelete;

        private static VsDbDelete DBdelete;

        static bool LoadSettings()
        {
            String vsAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Remove(0, 8));
            String vsSettingsFile = Path.Combine(vsAppPath, "app.config");

            bool ret = false;

            // check file existance
            if (File.Exists(vsSettingsFile))
            {
                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream(vsSettingsFile, FileMode.Open);
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

                    if (xmlIn.Name != "MainWindow") throw new ApplicationException("");

                    // ------------------------------------------------------------------------
                    // move to Auto run (camera, channel, or page) node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "Autorun") throw new ApplicationException("");

                    // ------------------------------------------------------------------------
                    // move to localhost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "LocalHost")
                        throw new ApplicationException("");

                    // ------------------------------------------------------------------------
                    // move to datahost node
                    xmlIn.Read();
                    if (xmlIn.NodeType == XmlNodeType.EndElement)
                        xmlIn.Read();

                    if (xmlIn.Name != "DataHost")
                        throw new ApplicationException("");

                    vsDbHost = xmlIn.GetAttribute("Host");
                    vsDbHostIP = xmlIn.GetAttribute("HostIP");
                    vsDbUser = xmlIn.GetAttribute("User");
                    vsDbPasswd = xmlIn.GetAttribute("Passwd");
                    vsDbDatabase = xmlIn.GetAttribute("Database");
                    vsDbDatabaseClient = xmlIn.GetAttribute("DatabaseClient");

                    ret = true;
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

        static void Main(string[] args)
        {
            if (!LoadSettings())
            {
                Console.WriteLine("can't load Setting configulation!!!");
                return;
            }

            string mainDbConnStr = "server=" + vsDbHost + " ;user id=" + vsDbUser + "; password=" + vsDbPasswd + "; database=" + vsDbDatabase + "; pooling=false; charset=utf8 ";
            string clientDbConnStr = "server=" + vsDbHost + " ;user id=" + vsDbUser + "; password=" + vsDbPasswd + "; database=" + vsDbDatabaseClient + "; pooling=false; charset=utf8 ";


            DBdelete = new VsDbDelete(mainDbConnStr, clientDbConnStr);

            VsDbDelete.setDelegate(showMess);

            if (args.Length == 2)
            {
                try
                {
                    timeDelete = DateTime.Parse(args[1]);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("invalid arg!!");
                    return;
                }

                string cmd = args[0];

                Console.WriteLine("command is : " + cmd + " time is " + timeDelete);

                if (cmd.Equals("delete"))
                {
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delete));
                    thread.Start();
                }
                else if (cmd.Equals("showfile"))
                {
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(showFile));
                    thread.Start();
                }
                else
                {
                    Console.WriteLine("invalid arg!!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("invalid arg!!");
                return;
            }
        }

        private static void showMess(string type, string text)
        {
            Console.WriteLine(type + " " + text);
        }

        private static void showFile()
        {
            try
            {
                VsDbDelete.setDelegate(showMess);


                string[] data = DBdelete.getFiles(timeDelete);


                foreach (string str in data)
                {
                    Console.WriteLine(str);

                }

                string msg = "\r\n number of file : " + data.Length + " sum of size :" + ((float)DBdelete.getSumOfFileSize(data) / 1048576) + " MB";
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void delete()
        {
            int ret = 0;
            DateTime end = timeDelete;
            ret = DBdelete.delete(end);

            Console.WriteLine("number of data deleted = " + ret);
        }

    }
}
