// rsbs	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rhne	
// leus	 By downloading, copying, installing or using the software you agree to this license.
// zyiv	 If you do not agree to this license, do not download, install,
// xpnb	 copy or use the software.
// pudy	
// awuq	                          License Agreement
// vxin	         For OpenVss - Open Source Video Surveillance System
// izra	
// xglw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// tvmx	
// dxvq	Third party copyrights are property of their respective owners.
// iyxw	
// mitx	Redistribution and use in source and binary forms, with or without modification,
// odrv	are permitted provided that the following conditions are met:
// mxin	
// vgkz	  * Redistribution's of source code must retain the above copyright notice,
// ghxq	    this list of conditions and the following disclaimer.
// driu	
// hgud	  * Redistribution's in binary form must reproduce the above copyright notice,
// adhx	    this list of conditions and the following disclaimer in the documentation
// ambz	    and/or other materials provided with the distribution.
// gulu	
// ppjv	  * Neither the name of the copyright holders nor the names of its contributors 
// mybw	    may not be used to endorse or promote products derived from this software 
// nvka	    without specific prior written permission.
// agsv	
// aypi	This software is provided by the copyright holders and contributors "as is" and
// inui	any express or implied warranties, including, but not limited to, the implied
// plni	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fktl	In no event shall the Prince of Songkla University or contributors be liable 
// wdbn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hmhj	(including, but not limited to, procurement of substitute goods or services;
// eypf	loss of use, data, or profits; or business interruption) however caused
// thwt	and on any theory of liability, whether in contract, strict liability,
// ugyh	or tort (including negligence or otherwise) arising in any way out of
// ecmb	the use of this software, even if advised of the possibility of such damage.

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
