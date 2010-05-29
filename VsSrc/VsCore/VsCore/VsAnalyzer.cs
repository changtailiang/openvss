// qeqe	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tmnd	
// chjf	 By downloading, copying, installing or using the software you agree to this license.
// lfzm	 If you do not agree to this license, do not download, install,
// hhcy	 copy or use the software.
// aaxd	
// cvpn	                          License Agreement
// qqlh	         For OpenVSS - Open Source Video Surveillance System
// nfzy	
// iaam	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bwov	
// yqcx	Third party copyrights are property of their respective owners.
// lpih	
// gaaq	Redistribution and use in source and binary forms, with or without modification,
// hncx	are permitted provided that the following conditions are met:
// wanl	
// wcsg	  * Redistribution's of source code must retain the above copyright notice,
// gaeh	    this list of conditions and the following disclaimer.
// hqxd	
// lbem	  * Redistribution's in binary form must reproduce the above copyright notice,
// tsba	    this list of conditions and the following disclaimer in the documentation
// hdan	    and/or other materials provided with the distribution.
// fjrv	
// ycpb	  * Neither the name of the copyright holders nor the names of its contributors 
// jdzw	    may not be used to endorse or promote products derived from this software 
// ywrl	    without specific prior written permission.
// lbzq	
// dweg	This software is provided by the copyright holders and contributors "as is" and
// ipee	any express or implied warranties, including, but not limited to, the implied
// ymds	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bfaw	In no event shall the Prince of Songkla University or contributors be liable 
// iiie	for any direct, indirect, incidental, special, exemplary, or consequential damages
// avui	(including, but not limited to, procurement of substitute goods or services;
// biox	loss of use, data, or profits; or business interruption) however caused
// appg	and on any theory of liability, whether in contract, strict liability,
// ekji	or tort (including negligence or otherwise) arising in any way out of
// elmi	the use of this software, even if advised of the possibility of such damage.
// yldw	
// zgus	Intelligent Systems Laboratory (iSys Lab)
// vudc	Faculty of Engineering, Prince of Songkla University, THAILAND
// svqi	Project leader by Nikom SUVONVORN
// bwea	Project website at http://code.google.com/p/openvss/

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
