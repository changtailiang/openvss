// pedz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fclu	
// txhq	 By downloading, copying, installing or using the software you agree to this license.
// jzes	 If you do not agree to this license, do not download, install,
// nmfk	 copy or use the software.
// sdxy	
// lbrt	                          License Agreement
// oiws	         For OpenVSS - Open Source Video Surveillance System
// qgwx	
// riho	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pbeq	
// kemn	Third party copyrights are property of their respective owners.
// ctns	
// htnl	Redistribution and use in source and binary forms, with or without modification,
// gfoe	are permitted provided that the following conditions are met:
// ksfk	
// apad	  * Redistribution's of source code must retain the above copyright notice,
// dhaf	    this list of conditions and the following disclaimer.
// ervq	
// zgnh	  * Redistribution's in binary form must reproduce the above copyright notice,
// perv	    this list of conditions and the following disclaimer in the documentation
// uekx	    and/or other materials provided with the distribution.
// tkqm	
// uddx	  * Neither the name of the copyright holders nor the names of its contributors 
// vtpv	    may not be used to endorse or promote products derived from this software 
// djkv	    without specific prior written permission.
// sioq	
// xwmz	This software is provided by the copyright holders and contributors "as is" and
// rgog	any express or implied warranties, including, but not limited to, the implied
// akpw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// edjt	In no event shall the Prince of Songkla University or contributors be liable 
// qnkb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nxvg	(including, but not limited to, procurement of substitute goods or services;
// rsef	loss of use, data, or profits; or business interruption) however caused
// uvcm	and on any theory of liability, whether in contract, strict liability,
// qtzx	or tort (including negligence or otherwise) arising in any way out of
// xqvn	the use of this software, even if advised of the possibility of such damage.
// oxwl	
// dsqa	Intelligent Systems Laboratory (iSys Lab)
// aqef	Faculty of Engineering, Prince of Songkla University, THAILAND
// xmdz	Project leader by Nikom SUVONVORN
// agiy	Project website at http://code.google.com/p/openvss/

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VsDbDeleteApp
{
    /// <summary>
    /// ErrorLogWriter class
    /// </summary>
    public class ErrorLogWriter : TextWriter
    {
        // Variables
        private bool Disposed;
        private XmlTextWriter Writer;

        private int logFileElementNumber;

        string DirectoryPath;

        // Constructor
        public ErrorLogWriter(string DirectoryPath)
        {

            this.DirectoryPath = DirectoryPath + @"\Error\";
            logFileElementNumber = 0;
            //  CreateNew();

        }

        private void CreateNew()
        {
            logFileElementNumber = 1;

            Disposed = false;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            string now = DateTime.Now.ToString("yyyyMMdd-HHmmss-ff", System.Globalization.CultureInfo.InvariantCulture);

            string fileName = DirectoryPath + now + ".xml";

            while (File.Exists(fileName))
            {
                now = DateTime.Now.AddMilliseconds(1).ToString("yyyyMMdd-HHmmss-ff", System.Globalization.CultureInfo.InvariantCulture);
                fileName = DirectoryPath + now + ".xml";
                Console.WriteLine("fileExist " + now);

            }
            Writer = new XmlTextWriter("log.xml"

                // DirectoryPath + @"\Error.xml"
                , Encoding.Unicode);

            // Write header
            Writer.Formatting = Formatting.Indented;
            Writer.WriteStartDocument();
            Writer.WriteStartElement("error" + now);
            Writer.Flush();
        }

        // Destructor (equivalent to Finalize() without the need to call base.Finalize())
        ~ErrorLogWriter()
        {
            // Close();
            Dispose(false);
        }

        // Free resources immediately
        protected override void Dispose(bool Disposing)
        {
            if (!Disposed)
            {
                if (Disposing)
                {
                }
                // Close file
                Writer.WriteEndElement();
                Writer.WriteEndDocument();
                Writer.Flush();
                // Free resources
                Dispose(true);
                GC.SuppressFinalize(this);

                Writer.Close();
                Writer = null;
                // Disposed
                Disposed = true;
                // Parent disposing
                base.Dispose(Disposing);
            }
        }

        // Close the file
        public override void Close()
        {
            //// Write footer
            //Writer.WriteEndElement();
            //Writer.WriteEndDocument();
            //Writer.Flush();
            //// Free resources
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }



        // Implement Encoding() method from TextWriter
        public override Encoding Encoding
        {
            get
            {
                return (Encoding.Unicode);
            }
        }


        // Implement WriteLine() method from TextWriter (remove MethodImpl attribute for single-threaded app)
        // Use stack trace and reflection to get the calling class and method
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void WriteLine(string Txt)
        {

            if (logFileElementNumber < 1)
            {
                CreateNew();
            }

            if (logFileElementNumber > 10)
            {

                Close();
                CreateNew();
            }

            Writer.WriteStartElement("event");
            Writer.WriteStartElement("time");
            Writer.WriteString(DateTime.Now.ToLongTimeString());
            Writer.WriteEndElement();
            Writer.WriteStartElement("class");
            Writer.WriteString(new StackTrace().GetFrame(2).GetMethod().ReflectedType.FullName);
            Writer.WriteEndElement();
            Writer.WriteStartElement("method");
            Writer.WriteString(new StackTrace().GetFrame(2).GetMethod().ToString());
            Writer.WriteEndElement();
            Writer.WriteStartElement("text");
            Writer.WriteString(Txt);
            Writer.WriteEndElement();
            Writer.WriteEndElement();
            Writer.Flush();

            logFileElementNumber = 0;

            Close();
            Dispose(false);
        }
    }
}
