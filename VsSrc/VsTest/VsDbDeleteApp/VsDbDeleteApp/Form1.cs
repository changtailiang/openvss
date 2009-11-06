// iuvb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kgyw	
// igwt	 By downloading, copying, installing or using the software you agree to this license.
// fzrk	 If you do not agree to this license, do not download, install,
// maqr	 copy or use the software.
// cnqp	
// lwad	                          License Agreement
// xmzi	         For OpenVss - Open Source Video Surveillance System
// xqpn	
// tumh	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// eeoq	
// yocl	Third party copyrights are property of their respective owners.
// eitd	
// hstu	Redistribution and use in source and binary forms, with or without modification,
// dfqn	are permitted provided that the following conditions are met:
// fuzv	
// gnvp	  * Redistribution's of source code must retain the above copyright notice,
// jdrr	    this list of conditions and the following disclaimer.
// ojny	
// yarw	  * Redistribution's in binary form must reproduce the above copyright notice,
// tpyp	    this list of conditions and the following disclaimer in the documentation
// twae	    and/or other materials provided with the distribution.
// wuko	
// eybj	  * Neither the name of the copyright holders nor the names of its contributors 
// etjk	    may not be used to endorse or promote products derived from this software 
// smbb	    without specific prior written permission.
// rbpy	
// fvwd	This software is provided by the copyright holders and contributors "as is" and
// ntup	any express or implied warranties, including, but not limited to, the implied
// wkbk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mqso	In no event shall the Prince of Songkla University or contributors be liable 
// tcnq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hdtf	(including, but not limited to, procurement of substitute goods or services;
// qheh	loss of use, data, or profits; or business interruption) however caused
// oxxr	and on any theory of liability, whether in contract, strict liability,
// hczb	or tort (including negligence or otherwise) arising in any way out of
// ygak	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using Vs.Core.DbDelete;
using System.Xml;
using System.Reflection;

namespace VsDbDeleteApp
{
    public partial class Form1 : Form
    {

        // Database Server
        static string vsDbHost;
        static string vsDbHostIP;
        static string vsDbUser;
        static string vsDbPasswd;
        static string vsDbDatabase;
        static string vsDbDatabaseClient;

        // Load application settings
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

        VsDbDelete DBdelete;
        public Form1()
        {
          
            InitializeComponent();

            //string mainDbConnStr = "server=localhost ;user id=root; password=; database=vsa-main; pooling=false; charset=utf8 ";
            //string clientDbConnStr = "server=localhost ;user id=root; password=; database=vsa-client; pooling=false; charset=utf8 ";

            if (!LoadSettings()) return;

            string mainDbConnStr = "server=" + vsDbHost + " ;user id=" + vsDbUser + "; password=" + vsDbPasswd + "; database=" + vsDbDatabase + "; pooling=false; charset=utf8 ";
            string clientDbConnStr = "server=" + vsDbHost + " ;user id=" + vsDbUser + "; password=" + vsDbPasswd + "; database=" + vsDbDatabaseClient + "; pooling=false; charset=utf8 ";


            DBdelete = new VsDbDelete(mainDbConnStr, clientDbConnStr);
            VsDbDelete.setDelegate(showMess);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();

            //DateTime start = DateTime.Parse(dateTimePicker1.Value.Date.ToString().Split()[0] + " " + textBox2.Text);
            //DateTime end = DateTime.Parse(dateTimePicker2.Value.Date.ToString().Split()[0] + " " + textBox3.Text);

            string[] datearr = DBdelete.getAllTableName();// DBdelete.getListOfTableInPeriod(start, end);

            foreach (string date in datearr)
            {
                listBox1.Items.Add(date);
            }

            textBox1.Text = "จำนวน table: "+datearr.Length;
            // textBox1.Text = datearr.Length.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Close(object sender, EventArgs e)
        {
        }

        ~Form1()
        {


        }

        public DateTime getTime1()
        {
            return DateTime.Parse(dateTimePicker1.Value.Date.ToString().Split()[0] + " " + textBox2.Text);
        }

       
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                string h1 = ((trackBar1.Value) / 2).ToString();
                string m1 = "00";
                if (trackBar1.Value % 2 == 1) m1 = "30";

                textBox2.Text = "" + h1 + ":" + m1 + ":01";

                if (trackBar1.Value == 48) textBox2.Text = "23:59:59";
            }
            catch (Exception err)
            {

            }
        }


        private int ret;
        public void delete()
        {  
            ret = 0;
            DateTime end = getTime1();
            ret = DBdelete.delete(end);

            UpdatelistBox1("จำนวนข้อมูลที่ถูกลบ = " + ret);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delete));
            thread.Start();

        }
        private delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            listBox1.Items.Add(text);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        private void UpdatelistBox1(string statusMsg)
        {
            // Check if this method is running on a different thread
            // than the thread that created the control.
            if (this.listBox1.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                SetTextCallback delegateCB = new SetTextCallback(SetText);
                this.Invoke(delegateCB, new object[] { statusMsg });
            }
            else
            {
                listBox1.Items.Add(statusMsg);
               
                if (listBox1.Items.Count > 1000)
                {
                    listBox1.Items.RemoveAt(0);
                } 
                
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                this.listBox1.Refresh();
            }
        }

        private void showMess(string type,string text)
        {
            UpdatelistBox1(type + " " + text);
        }
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                VsDbDelete.setDelegate(showMess);


                listBox1.Items.Clear();
              
                string[] data = DBdelete.getFiles( getTime1());

                int i = 0;
                foreach (string str in data)
                {
                    listBox1.Items.Add(str);
                    i++;
                    if (i > 5000)
                    {
                        break;
                    }
                    

                }

                textBox1.Text = " จำนวนไฟล์ : " + data.Length + " ขนาดของไฟล์รวม :" + ((float)DBdelete.getSumOfFileSize(data) / 1048576) + " MB";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
