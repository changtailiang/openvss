// fani	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// kkhc	
// wcka	 By downloading, copying, installing or using the software you agree to this license.
// hgrp	 If you do not agree to this license, do not download, install,
// coov	 copy or use the software.
// jvsz	
// wpun	                          License Agreement
// qmxs	         For OpenVSS - Open Source Video Surveillance System
// djrc	
// tmhk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// uayp	
// linv	Third party copyrights are property of their respective owners.
// xbpx	
// oecj	Redistribution and use in source and binary forms, with or without modification,
// iomv	are permitted provided that the following conditions are met:
// pulj	
// fsxy	  * Redistribution's of source code must retain the above copyright notice,
// opvq	    this list of conditions and the following disclaimer.
// gebi	
// xcon	  * Redistribution's in binary form must reproduce the above copyright notice,
// bzpp	    this list of conditions and the following disclaimer in the documentation
// xzdy	    and/or other materials provided with the distribution.
// gitf	
// amuz	  * Neither the name of the copyright holders nor the names of its contributors 
// ookt	    may not be used to endorse or promote products derived from this software 
// lpgh	    without specific prior written permission.
// fzrj	
// culf	This software is provided by the copyright holders and contributors "as is" and
// zytp	any express or implied warranties, including, but not limited to, the implied
// ewmf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// oyrg	In no event shall the Prince of Songkla University or contributors be liable 
// vqpu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kcuj	(including, but not limited to, procurement of substitute goods or services;
// rvcm	loss of use, data, or profits; or business interruption) however caused
// tijy	and on any theory of liability, whether in contract, strict liability,
// itwm	or tort (including negligence or otherwise) arising in any way out of
// wnfc	the use of this software, even if advised of the possibility of such damage.
// tevr	
// cfen	Intelligent Systems Laboratory (iSys Lab)
// xzmp	Faculty of Engineering, Prince of Songkla University, THAILAND
// jwza	Project leader by Nikom SUVONVORN
// zcne	Project website at http://code.google.com/p/openvss/

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
