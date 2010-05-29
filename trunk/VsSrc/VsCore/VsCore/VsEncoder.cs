// qcbs	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mbwz	
// qslg	 By downloading, copying, installing or using the software you agree to this license.
// orio	 If you do not agree to this license, do not download, install,
// bwcj	 copy or use the software.
// asvb	
// ueuj	                          License Agreement
// xrhv	         For OpenVSS - Open Source Video Surveillance System
// gaiu	
// uger	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ocko	
// kkip	Third party copyrights are property of their respective owners.
// ypuz	
// fkyy	Redistribution and use in source and binary forms, with or without modification,
// hzxi	are permitted provided that the following conditions are met:
// gmbz	
// kpao	  * Redistribution's of source code must retain the above copyright notice,
// jouv	    this list of conditions and the following disclaimer.
// rlvx	
// hgrk	  * Redistribution's in binary form must reproduce the above copyright notice,
// wfli	    this list of conditions and the following disclaimer in the documentation
// xiqv	    and/or other materials provided with the distribution.
// cknu	
// iwkb	  * Neither the name of the copyright holders nor the names of its contributors 
// bleu	    may not be used to endorse or promote products derived from this software 
// jtgk	    without specific prior written permission.
// uyht	
// paqb	This software is provided by the copyright holders and contributors "as is" and
// imlb	any express or implied warranties, including, but not limited to, the implied
// btcc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zemy	In no event shall the Prince of Songkla University or contributors be liable 
// azmv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// atww	(including, but not limited to, procurement of substitute goods or services;
// bwac	loss of use, data, or profits; or business interruption) however caused
// ybny	and on any theory of liability, whether in contract, strict liability,
// awgc	or tort (including negligence or otherwise) arising in any way out of
// tmmw	the use of this software, even if advised of the possibility of such damage.
// kjzh	
// jcvf	Intelligent Systems Laboratory (iSys Lab)
// hhjv	Faculty of Engineering, Prince of Songkla University, THAILAND
// lmtw	Project leader by Nikom SUVONVORN
// dtzl	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vs.Core.Encoder;
using System.Globalization;
using NLog; 

namespace Vs.Core
{

	/// <summary>
	/// VsEncoder class
	/// </summary>
	public class VsEncoder : IComparable
	{
		private VsICoreEncoderDescription	encoderDesc = null;
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		// Name property
		public string Name
		{
			get { return encoderDesc.Name; }
		}

		// Description property
		public string Description
		{
			get { return encoderDesc.Description; }
		}

		// EncoderName property
		public string EncoderName
		{
			get { return encoderDesc.GetType().ToString(); }
		}


		// Constructor
        public VsEncoder(VsICoreEncoderDescription encoderDesc)
		{
			this.encoderDesc = encoderDesc;
		}

		// Compares objects of the type
		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			VsEncoder p = (VsEncoder) obj;
			return (this.Name.CompareTo(p.Name));
		}

		// Get video source settings page
        public VsICoreEncoderPage GetSettingsPage()
		{
            try
            {
                return encoderDesc.GetSettingsPage();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
            try
            {
                encoderDesc.SaveConfiguration(writer, config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
            try
            {
                return encoderDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
		}

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            try
            {
                return encoderDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

		// Create video source
        public VsICoreEncoder CreateEncoderSource(long syncTimer, object config)
		{
            try
            {
                return encoderDesc.CreateEncoder(syncTimer, config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
		}
	}
}
