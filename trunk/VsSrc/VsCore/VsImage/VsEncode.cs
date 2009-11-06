// elhd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// hjky	
// smqc	 By downloading, copying, installing or using the software you agree to this license.
// cmdj	 If you do not agree to this license, do not download, install,
// egtr	 copy or use the software.
// nasc	
// agjo	                          License Agreement
// dhzl	         For OpenVss - Open Source Video Surveillance System
// lqsi	
// eaid	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// zgfn	
// qbrz	Third party copyrights are property of their respective owners.
// pssi	
// nfte	Redistribution and use in source and binary forms, with or without modification,
// teca	are permitted provided that the following conditions are met:
// zvuk	
// merl	  * Redistribution's of source code must retain the above copyright notice,
// tufd	    this list of conditions and the following disclaimer.
// yqrg	
// ufmy	  * Redistribution's in binary form must reproduce the above copyright notice,
// pkzk	    this list of conditions and the following disclaimer in the documentation
// pqyf	    and/or other materials provided with the distribution.
// xopz	
// xhdd	  * Neither the name of the copyright holders nor the names of its contributors 
// lual	    may not be used to endorse or promote products derived from this software 
// kffu	    without specific prior written permission.
// nokx	
// nmjo	This software is provided by the copyright holders and contributors "as is" and
// selo	any express or implied warranties, including, but not limited to, the implied
// wkuw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// glof	In no event shall the Prince of Songkla University or contributors be liable 
// ffgq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mnva	(including, but not limited to, procurement of substitute goods or services;
// faok	loss of use, data, or profits; or business interruption) however caused
// fexb	and on any theory of liability, whether in contract, strict liability,
// fark	or tort (including negligence or otherwise) arising in any way out of
// faht	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;
using NLog; 

namespace Vs.Core.Image
{
    public class VsEncode : IComparable, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        string fileFrom;
        string fileTo;

        public String FileFrom
        {
            get { return fileFrom; }
        }

        public String FileTo
        {
            get { return fileTo; }
        }

        /// <summary>
        /// constructor
        /// </summary> 
        public VsEncode()
        {

        }

        public VsEncode(String from, String to)
        {
            fileFrom = from;
            fileTo = to;
        }

        // disposable object
        public void Dispose()
        {

        }

        // Compares objects of the type
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            VsEncode p = (VsEncode)obj;
            return (this.fileFrom.CompareTo(p.fileFrom));
        }

        // methodes
        public VsEncode Clone()
        {
            VsEncode encode = null;
            try
            {
                encode = new VsEncode(fileFrom, fileTo);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }

            return encode;
        }
    }
}
