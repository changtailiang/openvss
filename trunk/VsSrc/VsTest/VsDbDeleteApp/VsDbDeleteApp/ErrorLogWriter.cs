// jcqf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lxrb	
// cpkv	 By downloading, copying, installing or using the software you agree to this license.
// vrxl	 If you do not agree to this license, do not download, install,
// brxg	 copy or use the software.
// pbrv	
// neak	                          License Agreement
// yzwo	         For OpenVss - Open Source Video Surveillance System
// lokn	
// zraf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mxql	
// uxgs	Third party copyrights are property of their respective owners.
// mobo	
// rtai	Redistribution and use in source and binary forms, with or without modification,
// kush	are permitted provided that the following conditions are met:
// whcc	
// twjg	  * Redistribution's of source code must retain the above copyright notice,
// gjmk	    this list of conditions and the following disclaimer.
// qrtr	
// kgap	  * Redistribution's in binary form must reproduce the above copyright notice,
// xixj	    this list of conditions and the following disclaimer in the documentation
// yhws	    and/or other materials provided with the distribution.
// occe	
// ysif	  * Neither the name of the copyright holders nor the names of its contributors 
// uosy	    may not be used to endorse or promote products derived from this software 
// oald	    without specific prior written permission.
// bqxa	
// zixe	This software is provided by the copyright holders and contributors "as is" and
// udko	any express or implied warranties, including, but not limited to, the implied
// ktdl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// arse	In no event shall the Prince of Songkla University or contributors be liable 
// gily	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ioww	(including, but not limited to, procurement of substitute goods or services;
// ocbw	loss of use, data, or profits; or business interruption) however caused
// xuhh	and on any theory of liability, whether in contract, strict liability,
// kwtf	or tort (including negligence or otherwise) arising in any way out of
// eykv	the use of this software, even if advised of the possibility of such damage.

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
