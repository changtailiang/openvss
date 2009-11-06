// dspd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// knce	
// omwg	 By downloading, copying, installing or using the software you agree to this license.
// gmfv	 If you do not agree to this license, do not download, install,
// menc	 copy or use the software.
// pykm	
// cqdx	                          License Agreement
// lgsf	         For OpenVss - Open Source Video Surveillance System
// sltq	
// qnot	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// adas	
// hxnc	Third party copyrights are property of their respective owners.
// whnp	
// pxof	Redistribution and use in source and binary forms, with or without modification,
// hdbu	are permitted provided that the following conditions are met:
// kesh	
// tqnu	  * Redistribution's of source code must retain the above copyright notice,
// soey	    this list of conditions and the following disclaimer.
// qubm	
// ysee	  * Redistribution's in binary form must reproduce the above copyright notice,
// cbbd	    this list of conditions and the following disclaimer in the documentation
// tdpu	    and/or other materials provided with the distribution.
// xojn	
// mujw	  * Neither the name of the copyright holders nor the names of its contributors 
// ksyq	    may not be used to endorse or promote products derived from this software 
// ktji	    without specific prior written permission.
// dozv	
// vbgo	This software is provided by the copyright holders and contributors "as is" and
// ywrj	any express or implied warranties, including, but not limited to, the implied
// cpop	warranties of merchantability and fitness for a particular purpose are disclaimed.
// asxe	In no event shall the Prince of Songkla University or contributors be liable 
// eqmw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kfcf	(including, but not limited to, procurement of substitute goods or services;
// touj	loss of use, data, or profits; or business interruption) however caused
// rtaf	and on any theory of liability, whether in contract, strict liability,
// etyv	or tort (including negligence or otherwise) arising in any way out of
// hupp	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vs.Core.Analyzer;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// VsAnalyzer class
	/// </summary>
	public class VsAnalyzer : IComparable
	{
		private VsICoreAnalyzerDescription	analyserDesc = null;
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		// Name property
		public string Name
		{
			get { return analyserDesc.Name; }
		}

		// Description property
		public string Description
		{
			get { return analyserDesc.Description; }
		}

        // AnalyserName property
		public string AnalyserName
		{
			get { return analyserDesc.GetType().ToString(); }
		}

		// Constructor
        public VsAnalyzer(VsICoreAnalyzerDescription analyserDesc)
		{
			this.analyserDesc = analyserDesc;
		}

		// Compares objects of the type
		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			VsAnalyzer p = (VsAnalyzer) obj;
			return (this.Name.CompareTo(p.Name));
		}

		// Get video source settings page
        public VsICoreAnalyzerPage GetSettingsPage()
		{
            try
            {
                return analyserDesc.GetSettingsPage();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
		}

		// Save configuration
        public void SaveConfiguration(XmlTextWriter writer, VsICoreAnalyzerConfiguration config)
		{
            try
            {
                analyserDesc.SaveConfiguration(writer, config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Load configuration
        public VsICoreAnalyzerConfiguration LoadConfiguration(XmlTextReader reader)
		{
            try
            {
                return analyserDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
		}

        // Load configuration
        public VsICoreAnalyzerConfiguration LoadConfiguration(Hashtable reader)
        {
            try
            {
                return analyserDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

		// Create video source
        public VsICoreAnalyzer CreateAnalyserSource(long syncTimer, VsICoreAnalyzerConfiguration config)
		{
            try
            {
                return analyserDesc.CreateAnalyser(syncTimer, config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
		}
	}
}
