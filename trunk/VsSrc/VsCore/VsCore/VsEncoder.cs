// vuij	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// iazv	
// toeo	 By downloading, copying, installing or using the software you agree to this license.
// fqgp	 If you do not agree to this license, do not download, install,
// qanq	 copy or use the software.
// oxyf	
// fawf	                          License Agreement
// howe	         For OpenVss - Open Source Video Surveillance System
// kfvd	
// vrfo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// igtk	
// nyyg	Third party copyrights are property of their respective owners.
// eqyi	
// hbsx	Redistribution and use in source and binary forms, with or without modification,
// vceh	are permitted provided that the following conditions are met:
// dune	
// rzez	  * Redistribution's of source code must retain the above copyright notice,
// udty	    this list of conditions and the following disclaimer.
// uyih	
// eorg	  * Redistribution's in binary form must reproduce the above copyright notice,
// cqar	    this list of conditions and the following disclaimer in the documentation
// qoxi	    and/or other materials provided with the distribution.
// nxht	
// nxln	  * Neither the name of the copyright holders nor the names of its contributors 
// toso	    may not be used to endorse or promote products derived from this software 
// tymb	    without specific prior written permission.
// xzni	
// skth	This software is provided by the copyright holders and contributors "as is" and
// kxfn	any express or implied warranties, including, but not limited to, the implied
// twoc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cvmw	In no event shall the Prince of Songkla University or contributors be liable 
// walw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nuop	(including, but not limited to, procurement of substitute goods or services;
// vdmd	loss of use, data, or profits; or business interruption) however caused
// eztq	and on any theory of liability, whether in contract, strict liability,
// aopc	or tort (including negligence or otherwise) arising in any way out of
// dzip	the use of this software, even if advised of the possibility of such damage.

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
