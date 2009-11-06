// eeqy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uwgw	
// azze	 By downloading, copying, installing or using the software you agree to this license.
// gwhy	 If you do not agree to this license, do not download, install,
// qvlr	 copy or use the software.
// jyuz	
// hvgn	                          License Agreement
// dgxu	         For OpenVss - Open Source Video Surveillance System
// crht	
// jzjd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// tnlc	
// bitg	Third party copyrights are property of their respective owners.
// tlja	
// xzvf	Redistribution and use in source and binary forms, with or without modification,
// krqy	are permitted provided that the following conditions are met:
// pstu	
// cfbp	  * Redistribution's of source code must retain the above copyright notice,
// popq	    this list of conditions and the following disclaimer.
// mhyv	
// nsxy	  * Redistribution's in binary form must reproduce the above copyright notice,
// catr	    this list of conditions and the following disclaimer in the documentation
// wwwc	    and/or other materials provided with the distribution.
// vbjr	
// ikoa	  * Neither the name of the copyright holders nor the names of its contributors 
// urzw	    may not be used to endorse or promote products derived from this software 
// gdqe	    without specific prior written permission.
// wtop	
// bzsr	This software is provided by the copyright holders and contributors "as is" and
// tswo	any express or implied warranties, including, but not limited to, the implied
// ybxg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// izto	In no event shall the Prince of Songkla University or contributors be liable 
// fxhb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// txbw	(including, but not limited to, procurement of substitute goods or services;
// sbry	loss of use, data, or profits; or business interruption) however caused
// kpvd	and on any theory of liability, whether in contract, strict liability,
// hhbw	or tort (including negligence or otherwise) arising in any way out of
// iryq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using ICSharpCode.SharpZipLib.Zip;
using System.DirectoryServices;
using IWshRuntimeLibrary;

namespace VsSetup
{
    public class VsInstallControl
    {
        public VsInstall mainForm;
        public SetupState setupState;

        public static configuration.VsAppConfigData configuration = new VsSetup.configuration.VsAppConfigData();
        public static configuration.VsWebConfigData webConfiguration = new VsSetup.configuration.VsWebConfigData();

        State state;

        #region state control
        public VsInstallControl(VsInstall mainForm, SetupState setupState)
        {
            this.mainForm = mainForm;
            this.setupState = setupState;

            doState(state);
        }

        private void doState(State s)
        {
            setupState.setingState(s);

            switch (s)
            {
                case State.start:
                    mainForm.addStateControl(new Start(this), "Software License");
                    break;
                case State.mysql:
                    mainForm.addStateControl(new MySqlSetup(this), "MySQL Server");
                    break;
                case State.iis:
                    mainForm.addStateControl(new IIsSetup(this), "IIS Server");
                    break;
                case State.windowEndcode:
                    mainForm.addStateControl(new WMEncodeSetup(this), "Windows Media Encoder");
                    break;
                case State.copyVS:
                    mainForm.addStateControl(new VsCopyFile(this), "OpenVss");
                    break;
                case State.config:
                    mainForm.addStateControl(new SystemConfig(this), "System Configuration");
                    break;

                case State.exit:
                    break;
            }

        }

        public void nextState()
        {
            setupState.setedState(state++);

            doState(state);
        }


        public void exitSetup(State s)
        {
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        #region for MySql Section


        //   string ConnString = "server=localhost;user id=root; password=l0o=0-85; database=vsa-client; pooling=false";

        string host;
        string port;
        string userName;
        string password;

        public void setDBconnectionProp(string host, string port, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.userName = userName;
            this.password = password;


        }

        public bool testMysqlConnection(string host, string port, string userName, string password)
        {
            string conns = String.Format("server={0};port={1};user id={2}; password={3} ", host, port, userName, password);

            return Connecting(conns) != null;
        }


        public string getConnString()
        {
            return getConnString(host, port, userName, password, "", false);
        }


        #endregion

        #region for VS coppy file

        //public int progressState;
        public int compeatedState = 0;
        public string unzipfile;

        public string programDir;
        public string dataDir;

        public string rootProgramDir;

        public void UnZipFiles(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
        {
            FileInfo fileinfo;
            ZipInputStream s = null;
            try
            {
                // progressState = 0;
                compeatedState = 0;
                // long filesize = fileinfo.Length;
                // long comProgress = 0;

                fileinfo = new FileInfo(zipPathAndFile);
                s = new ZipInputStream(fileinfo.OpenRead());

                //progressState = (int)s.Length;
                if (password != null && password != String.Empty)
                    s.Password = password;
                ZipEntry theEntry;
                string tmpEntry = String.Empty;

                bool hasRootProgramDir = false;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    //comProgress += theEntry.Size;
                    string directoryName = outputFolder;
                    string fileName = Path.GetFileName(theEntry.Name);
                    // create directory 
                    if (directoryName != "")
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                    if (fileName != String.Empty)
                    {
                        if (theEntry.Name.IndexOf(".ini") < 0)
                        {
                            unzipfile = theEntry.Name;
                            string fullPath = directoryName + "\\" + theEntry.Name;
                            fullPath = fullPath.Replace("/", "\\");
                            string fullDirPath = Path.GetDirectoryName(fullPath);

                            //เพื่อเก็บ root dir ที่ unzip
                            if (!hasRootProgramDir)
                            {
                                rootProgramDir = fullDirPath;
                                hasRootProgramDir = true;

                                if (Directory.Exists(rootProgramDir))
                                {
                                    unzipfile = "delete " + rootProgramDir;
                                    Directory.Delete(rootProgramDir, true);
                                }
                            }

                            if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
                            FileStream streamWriter = System.IO.File.Create(fullPath);
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            streamWriter.Close();
                        }
                    }
                }
                s.Close();

                compeatedState = 1;

                //if (deleteZipFile)
                //    File.Delete(zipPathAndFile);
            }
            catch (Exception ex)
            {
                if (s != null)
                {
                    s.Close();
                }
                unzipfile = ex.Message;
                compeatedState = -1;
            }
        }

        public void setDir(string programDir, string dataDir)
        {
            this.programDir = programDir;
            this.dataDir = dataDir;
        }

        #endregion

        #region for iis

        public bool checkIIsWebServer()
        {
            const string WebServerSchema = "IIsWebServer"; // Case Sensitive
            string ServerName = "LocalHost";
            DirectoryEntry W3SVC = new DirectoryEntry("IIS://" + ServerName + "/w3svc");
            try
            {

                foreach (DirectoryEntry Site in W3SVC.Children)
                {
                    if (Site.SchemaClassName == WebServerSchema)
                    {
                        PropertyValueCollection pvc = Site.Properties["KeyType"];
                        //Console.WriteLine("WebSite Instance ID : " + Site.Name);

                        foreach (object Value in pvc)
                        {
                            if ("IIsWebServer".Equals(Value))
                            {
                                return true;
                            }
                        }
                    }

                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public bool checkIIsWebServerRuning()
        {
            const string WebServerSchema = "IIsWebServer"; // Case Sensitive
            string ServerName = "LocalHost";
            DirectoryEntry W3SVC = new DirectoryEntry("IIS://" + ServerName + "/w3svc");
            foreach (DirectoryEntry Site in W3SVC.Children)
            {
                if (Site.SchemaClassName == WebServerSchema)
                {
                    PropertyValueCollection pvc = Site.Properties["ServerAutoStart"];
                    // Console.WriteLine("WebSite Instance ID : " + Site.Name);

                    foreach (object Value in pvc)
                    {
                        return ((bool)Value);

                    }
                }
            }
            return false;
        }

        public bool configIIs()
        {
            return runFileExe(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_regiis.exe ", "-i", false);
        }

        public void CreateNewVirtualDirectory(int ServerId, string VirtualDirName, string Path, bool AccessScript)
        {

            DirectoryEntry Parent = new DirectoryEntry(@"IIS://localhost/W3SVC/" + ServerId.ToString() + "/Root");
            DirectoryEntry NewVirtualDir;
            NewVirtualDir = Parent.Children.Add(VirtualDirName, "IIsWebVirtualDir");
            NewVirtualDir.Properties["Path"][0] = Path;
            NewVirtualDir.Properties["AccessScript"][0] = AccessScript.ToString();
            // NewVirtualDir.Properties["AppFriendlyName"][0] = VirtualDirName;
            NewVirtualDir.CommitChanges();
            NewVirtualDir.Invoke("AppCreate", 1);
        }

        public void deleteNewVirtualDirectory(int ServerId, string VirtualDirName)
        {
            DirectoryEntry Parent = new DirectoryEntry(@"IIS://localhost/W3SVC/" + ServerId.ToString() + "/Root");
            DirectoryEntry NewVirtualDir;
            NewVirtualDir = Parent.Children.Find(VirtualDirName, "IIsWebVirtualDir");

            Parent.Children.Remove(NewVirtualDir);
        }

        #endregion

        #region for configuration


        public bool createDB()
        {
            string constr = getConnString();
            if (!hasDB("vsa-main", constr))
            {
                return createDB("vsa-main", constr);
            }
            else
            {
                return true;
            }
        }

        public bool createVirtualDirForService()
        {
            string servicePath = Path.Combine(rootProgramDir, "VsWebService");

            try
            {
                CreateNewVirtualDirectory(1, "vsservice", servicePath, true);
            }
            catch
            {
                deleteNewVirtualDirectory(1, "vsservice");
                CreateNewVirtualDirectory(1, "vsservice", servicePath, true);
            }
            return true;
        }

        public bool createVirtualDirForVideoData()
        {

            string virDirName = new DirectoryInfo(dataDir).Name;
            try
            {
                CreateNewVirtualDirectory(1, virDirName, dataDir, false);
            }
            catch
            {
                deleteNewVirtualDirectory(1, virDirName);
                CreateNewVirtualDirectory(1, virDirName, dataDir, false);
            }
            return true;

        }

        public void deleteAllVirDir()
        {
            try
            {
                deleteNewVirtualDirectory(1, "vsservice");

                string virDirName = new DirectoryInfo(dataDir).Name;

                deleteNewVirtualDirectory(1, virDirName);
            }
            catch { }

        }


        public bool updateAppConfiguration()
        {
            try
            {
                string settingPath = Path.Combine(rootProgramDir, "app.config");

                configuration.LoadSettings(settingPath);

                //for database
                configuration.dataHost.Host = host;
                configuration.dataHost.HostIP = getMyHostIP();
                configuration.dataHost.User = userName;
                configuration.dataHost.Passwd = password;


                //for file location config
                configuration.localHost.Storage = dataDir;

                configuration.SaveSettings(settingPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //update 
        public bool updateWebServiceConfiguration()
        {
            try
            {
                string settingPath = Path.Combine(rootProgramDir, "VsWebService\\config\\VsWebServiceApp.config");

                webConfiguration.LoadSettings(settingPath);

                webConfiguration.data["ConnectionString"] = getConnString(host, port, userName, password, "vsa-main", false);

                webConfiguration.data["HostIP"] = getMyHostIP();

                webConfiguration.saveSetting(settingPath);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool updateSystemConfig()
        {
            try
            {
                setEnvironment();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void setEnvironment()
        {
            Environment.SetEnvironmentVariable("VsPath", rootProgramDir, EnvironmentVariableTarget.Machine);
        }

        public bool installVsWinService()
        {
            try
            {
                unInstallVsWinService();
                string para = "\"" + Path.Combine(rootProgramDir, "VsWinService.exe") + "\"";

                return runFileExe(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\installutil.exe", para, false);


                //runFileExe("NET", "START VsService", false);
            }
            catch
            {
                return false;
            }

        }

        public bool stopVsWinService()
        {
            try
            {
                return runFileExe("NET.exe", "STOP  VsService", false);
            }
            catch
            {
                return false;
            }
        }

        public bool unInstallVsWinService()
        {
            try
            {
                string para = "/u " + "\"" + Path.Combine(rootProgramDir, "VsWinService.exe") + "\"";
                runFileExe("NET.exe", "STOP  VsService", false);

                return runFileExe(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\installutil.exe", para, false);

            }
            catch
            {
                return false;
            }
        }

        public bool runVsWinService()
        {
            try
            {
                return runFileExe("NET.exe", "START VsService", false);
            }
            catch
            {
                return false;
            }
        }

        public void createPlaybackShortCut()
        {
            urlShortcutToDesktop("VsAdmin", Path.Combine(rootProgramDir, "VsAdmin.exe"));
            urlShortcutToDesktop("VsMonitor", Path.Combine(rootProgramDir, "VsMonitor.exe"));
            urlShortcutToDesktop("VsServiceControl", Path.Combine(rootProgramDir, "VsWinServiceControl.exe"));
        }

        #endregion

        #region Utility
        public bool runFileExe(string cmd, string para, bool hiddenCmd)
        {
            try
            {
                Process myProgram = new Process(); //Process.Start(cmd, para);

                myProgram.StartInfo.FileName = cmd;
                myProgram.StartInfo.Arguments = para;

                if (hiddenCmd)
                {
                    myProgram.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    myProgram.StartInfo.UseShellExecute = false;
                    myProgram.StartInfo.CreateNoWindow = true;
                    myProgram.EnableRaisingEvents = true;
                }

                myProgram.Start();

                myProgram.WaitForExit();
                myProgram.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //สร้าง string connectionจากค่าต่างๆ
        public string getConnString(string server, string port, string userId, string password, string database, bool pooling)
        {
            if (port.Equals(""))
            {
                port = "3306";
            }
            string conn = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; pooling={5}", server, port, userId, password, database, pooling.ToString());
            return conn;
        }


        public MySqlConnection Connecting(string connString)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection("");
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySqlException err)
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                // throw ex;
                //        //MessageBox.Show("Error connecting to the server: " + ex.Message);

            }
            return conn;
        }

        //ตวจสอบว่ามี dataBASE ที่กำหนดหรือไม่
        public bool hasDB(string DBname, string ConnString)
        {
            MySqlConnection conn = this.Connecting(ConnString);

            if (conn != null)
            {
                try
                {
                    MySqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "show databases;";
                    MySqlDataReader aReader = comm.ExecuteReader();

                    while (aReader.Read())
                    {
                        if (aReader["database"].Equals(DBname))
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    conn.Close();
                }
                catch (MySqlException err)
                {
                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                }
            }
            return false;
        }

        //ตรวจสอบว่ามีตารางที่กำหนดหรือไม่
        public bool hasTable(string DBname, string TableName, string ConnString)
        {
            MySqlConnection conn = this.Connecting(ConnString);

            if (conn != null)
            {
                try
                {
                    conn.ChangeDatabase(DBname);
                    MySqlCommand comm = conn.CreateCommand();

                    comm.CommandText = "show tables";
                    MySqlDataReader aReader = comm.ExecuteReader();
                    while (aReader.Read())
                    {
                        if (aReader[0].Equals(TableName))
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    conn.Close();
                }
                catch (MySqlException err)
                {
                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                }
            }
            return false;
        }

        //สร้าง database 
        public bool createDB(string DBname, string ConnString)
        {
            MySqlConnection conn = this.Connecting(ConnString);

            if (conn != null)
            {
                try
                {
                    MySqlCommand comm = conn.CreateCommand();
                    string query = String.Format("create database `{0}` ;", DBname);

                    comm.CommandText = query;
                    comm.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (MySqlException err)
                {
                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }

                }
            }
            return false;
        }

        public bool deleteDB()
        {
            return false;
        }

        public string getMyHost()
        {
            string myhost = System.Net.Dns.GetHostName();//????????????????????????? Dns 

            System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(myhost);//????? Ip?????????????????????????? myhost

            foreach (System.Net.IPAddress a in ip.AddressList)
            {
                myhost += ":" + a.ToString();
            }
            return myhost;

        }

        public string getMyHostIP()
        {
            string myhost = System.Net.Dns.GetHostName();//????????????????????????? Dns 

            System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(myhost);//????? Ip?????????????????????????? myhost

            foreach (System.Net.IPAddress a in ip.AddressList)
            {
                myhost = a.ToString();
            }
            return myhost;

        }

        private void urlShortcutToDesktop(string LinkPathName, string TargetPathName)
        {
            string DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //    string linkPath = deskDir + "\\" + linkName + ".url";

            //    if(File.Exists(linkPath)) File.Delete(linkPath);

            //    using (StreamWriter writer = new StreamWriter(linkPath))
            //    {
            //        writer.WriteLine("[InternetShortcut]");
            //      //  writer.WriteLine("URL=" + linkUrl);

            //        writer.WriteLine("URL=file:///" + app);
            //        writer.WriteLine("IconIndex=0");
            //        string icon = app;
            //        writer.WriteLine("IconFile=" + icon);

            //        writer.Flush();


            DirectoryInfo SpecialDir = new DirectoryInfo(DirectoryPath);
         
            FileInfo OriginalFile = new FileInfo(LinkPathName);
            string NewFileName = SpecialDir.FullName + "\\" + OriginalFile.Name + ".lnk";
            FileInfo LinkFile = new FileInfo(NewFileName);


            if (LinkFile.Exists) 
                try
                {
                    LinkFile.Delete();
                }
                catch
                {
                 
                }

            try
            {
                // Create a shortcut in the special folder for the file
                // Making use of the Windows Scripting Host
                WshShell shell = new WshShell();
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(LinkFile.FullName);
                link.TargetPath = TargetPathName;
                link.Save();
            }
            catch
            {
                
            }

        }


        #endregion

    }

    public enum State
    {
        start,
        mysql,
        iis,
        windowEndcode,
        copyVS,
        config,

        exit
    }
}
