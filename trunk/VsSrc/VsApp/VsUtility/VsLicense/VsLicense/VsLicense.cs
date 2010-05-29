// zema	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// emza	
// kuzt	 By downloading, copying, installing or using the software you agree to this license.
// rxlv	 If you do not agree to this license, do not download, install,
// fzpy	 copy or use the software.
// jadr	
// ojng	                          License Agreement
// melt	         For OpenVSS - Open Source Video Surveillance System
// rjbv	
// zwxj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// iqcx	
// rxxq	Third party copyrights are property of their respective owners.
// kyyg	
// xmiz	Redistribution and use in source and binary forms, with or without modification,
// avmu	are permitted provided that the following conditions are met:
// zsof	
// jgch	  * Redistribution's of source code must retain the above copyright notice,
// vpwi	    this list of conditions and the following disclaimer.
// cfps	
// xfaq	  * Redistribution's in binary form must reproduce the above copyright notice,
// mwwn	    this list of conditions and the following disclaimer in the documentation
// gfve	    and/or other materials provided with the distribution.
// bbud	
// kckq	  * Neither the name of the copyright holders nor the names of its contributors 
// bwok	    may not be used to endorse or promote products derived from this software 
// vpuu	    without specific prior written permission.
// bqdr	
// wpcu	This software is provided by the copyright holders and contributors "as is" and
// uwid	any express or implied warranties, including, but not limited to, the implied
// wazd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kxgu	In no event shall the Prince of Songkla University or contributors be liable 
// vtyz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vzqa	(including, but not limited to, procurement of substitute goods or services;
// qpvx	loss of use, data, or profits; or business interruption) however caused
// bbmp	and on any theory of liability, whether in contract, strict liability,
// beim	or tort (including negligence or otherwise) arising in any way out of
// zzio	the use of this software, even if advised of the possibility of such damage.
// uhub	
// xlzx	Intelligent Systems Laboratory (iSys Lab)
// iazi	Faculty of Engineering, Prince of Songkla University, THAILAND
// sdwx	Project leader by Nikom SUVONVORN
// ybee	Project website at http://code.google.com/p/openvss/

using System.Threading;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace InsertComment
{
    //ทดสอบนะครับ
    public partial class VsLicense : Form
    {
        List<string> Files = new List<string>();
        Random random;
        string textStr;
        public VsLicense()
        {
            InitializeComponent();
            random = new Random();
        }

        string status = "";

        public void getAllFile(String str)
        {
            listBox1.Items.Clear();
            Thread t = new Thread(() =>
            {
                Files.Clear();

                Queue<string> Dirs = new Queue<string>();
                Dirs.Enqueue(str);

                string type = textBox2.Text;

                while (Dirs.Count > 0)
                {
                    string dir = Dirs.Dequeue();
                    foreach (string Element in Directory.GetFileSystemEntries(dir))
                    {
                        // Sub directories
                        if (Directory.Exists(Element))
                        {
                            status = "add Dir" + Element;
                            Dirs.Enqueue(Element);
                        }

                        // Files in directory
                        else if (Element.EndsWith(type))
                        {
                            status = "add" + Element;
                            Files.Add(Element);


                        }
                    }
                }
                status = "complete";

            });

            t.IsBackground = true;

            t.Start();

            //  return Files.ToArray();

        }


        protected string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            //builder.Append(RandomNumber(10000, 99999));
            return builder.ToString();
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            //  Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private int RandomNumber(int min, int max)
        {
            // Random random = new Random();
            return random.Next(min, max);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
            getAllFile(textBox1.Text);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getAllFile(textBox1.Text);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = status;

            if (status.Contains("add"))
            {
                textBox3.Text = Files.Count.ToString();
                //listBox1.Items.Add(status);
            }


            else if (status.Contains("append"))
            {
                button4.Enabled = false;
                //listBox1.Items.Add(status);
                textBox3.Text = i.ToString();
            }



            else if ("complete".Equals(status))
            {
                status = "show all file";
                textBox3.Text = Files.Count.ToString();
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Files.ToArray());


            }

            else if (status.Equals("appcompp"))
            {
                status = "";
                textBox3.Text = i.ToString();
                button4.Enabled = true;
            }


        }

        private string getText(string filePath)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

            StringBuilder s = new StringBuilder();

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                s.AppendLine("// " + GetRandomString() + "\t" + line);
            }


            sr.Close();
            fs.Close();

            return s.ToString();
        }




        private void addText(string filePath, string text)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

            StringBuilder file = new StringBuilder();

            file.AppendLine(text);

            string line;

            while ((line = sr.ReadLine()) != null 
                && ( line.Contains("//") || !( line.Contains("using ") ||line.Contains("namespace ")) )) { }
                
             


            while (line != null)
            {

                file.AppendLine(line);
                line = sr.ReadLine();
            }

            sr.Close();
            fs.Close();

            //string s = "";
            //s = text + "\r\n";
            //s += file.ToString();


            fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);

            sw.Write(file.ToString());
            sw.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                textBox4.Text = dlg.FileName;
                textStr = dlg.FileName;
                MessageBox.Show("You selected the file " + dlg.FileName + "\n\r" + getText(textStr));

                //addText(filename, );
            }
        }
        int i = 0;

        private void appendToAllFile()
        {
            Thread t = new Thread(() =>
            {
                random = new Random();
                i = 0;

                foreach (string file in Files)
                {
                    status = "append to " + file;
                    addText(file, getText(textStr));
                    i++;
                }

                status = "appcompp";
            });

            t.IsBackground = true;

            t.Start();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            appendToAllFile();
        }

    }
}
