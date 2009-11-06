// xhom	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ieue	
// rslh	 By downloading, copying, installing or using the software you agree to this license.
// zeia	 If you do not agree to this license, do not download, install,
// kqri	 copy or use the software.
// ywlj	
// gixz	                          License Agreement
// ympx	         For OpenVss - Open Source Video Surveillance System
// roct	
// fmdj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bahv	
// ackl	Third party copyrights are property of their respective owners.
// crgl	
// tdsa	Redistribution and use in source and binary forms, with or without modification,
// wfga	are permitted provided that the following conditions are met:
// gufe	
// coqk	  * Redistribution's of source code must retain the above copyright notice,
// cpvy	    this list of conditions and the following disclaimer.
// nihy	
// pqjd	  * Redistribution's in binary form must reproduce the above copyright notice,
// ylxh	    this list of conditions and the following disclaimer in the documentation
// gddn	    and/or other materials provided with the distribution.
// vbwa	
// fdcg	  * Neither the name of the copyright holders nor the names of its contributors 
// udsm	    may not be used to endorse or promote products derived from this software 
// mzjn	    without specific prior written permission.
// whyl	
// wtlf	This software is provided by the copyright holders and contributors "as is" and
// vdbv	any express or implied warranties, including, but not limited to, the implied
// xyxy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kcoa	In no event shall the Prince of Songkla University or contributors be liable 
// svsk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// faem	(including, but not limited to, procurement of substitute goods or services;
// xxqy	loss of use, data, or profits; or business interruption) however caused
// bjky	and on any theory of liability, whether in contract, strict liability,
// fsqb	or tort (including negligence or otherwise) arising in any way out of
// qrec	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Xml;
using System.Collections;
using Vs.Core.Encoder;
using Vs.Core.Provider;
using System.Globalization;
using NLog; 

namespace Vs.Core
{

	/// <summary>
	/// VsProvider class
	/// </summary>
	public class VsProvider : IComparable
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		private VsICoreProviderDescription	sourceDesc = null;

		// Name property
		public string Name
		{
			get { return sourceDesc.Name; }
		}

		// Description property
		public string Description
		{
			get { return sourceDesc.Description; }
		}

		// ProviderName property
		public string ProviderName
		{
			get { return sourceDesc.GetType().ToString(); }
		}


		// Constructor
		public VsProvider(VsICoreProviderDescription sourceDesc)
		{
			this.sourceDesc = sourceDesc;
		}

		// Compares objects of the type
		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			VsProvider p = (VsProvider) obj;
			return (this.Name.CompareTo(p.Name));
		}

		// Get video source settings page
		public VsICoreProviderPage GetSettingsPage()
		{
            try
            {
                return sourceDesc.GetSettingsPage();
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
                sourceDesc.SaveConfiguration(writer, config);
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
                return sourceDesc.LoadConfiguration(reader);
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
                return sourceDesc.LoadConfiguration(reader);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
        }

		// Create video source
		public VsICoreProvider CreateVideoSource(object config)
		{
            try
            {
                return sourceDesc.CreateVideoSource(config);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            return null;
		}
	}
}
