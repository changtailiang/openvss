// hpca	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nvrn	
// hham	 By downloading, copying, installing or using the software you agree to this license.
// stnw	 If you do not agree to this license, do not download, install,
// euhh	 copy or use the software.
// rrjs	
// mhhq	                          License Agreement
// kfam	         For OpenVSS - Open Source Video Surveillance System
// uzgz	
// jycv	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// qelt	
// pwgc	Third party copyrights are property of their respective owners.
// udsi	
// katp	Redistribution and use in source and binary forms, with or without modification,
// fjof	are permitted provided that the following conditions are met:
// nbcc	
// gnst	  * Redistribution's of source code must retain the above copyright notice,
// nomg	    this list of conditions and the following disclaimer.
// rmqn	
// gqdq	  * Redistribution's in binary form must reproduce the above copyright notice,
// bevh	    this list of conditions and the following disclaimer in the documentation
// mrct	    and/or other materials provided with the distribution.
// gqta	
// jwio	  * Neither the name of the copyright holders nor the names of its contributors 
// binb	    may not be used to endorse or promote products derived from this software 
// enpf	    without specific prior written permission.
// qlqx	
// jgjp	This software is provided by the copyright holders and contributors "as is" and
// fyei	any express or implied warranties, including, but not limited to, the implied
// fvpo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lynw	In no event shall the Prince of Songkla University or contributors be liable 
// umwu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dclx	(including, but not limited to, procurement of substitute goods or services;
// dbmo	loss of use, data, or profits; or business interruption) however caused
// pqqb	and on any theory of liability, whether in contract, strict liability,
// bekz	or tort (including negligence or otherwise) arising in any way out of
// heul	the use of this software, even if advised of the possibility of such damage.
// szjf	
// syqf	Intelligent Systems Laboratory (iSys Lab)
// asle	Faculty of Engineering, Prince of Songkla University, THAILAND
// pwth	Project leader by Nikom SUVONVORN
// vlme	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Jpeg
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// JPEGSourceDescription
	/// </summary>
	public class JPEGSourceDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "JPEG stream"; }
		}

		// Description property
		public string Description
		{
			get { return "Downloads separate JPEG files from the specified URL"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new JPEGSourcePage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			JPEGConfiguration	cfg = (JPEGConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			JPEGConfiguration	config = new JPEGConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.frameInterval = int.Parse(reader.GetAttribute("interval"));
			}
			catch (Exception)
			{
			}

			return (object) config;
		}

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            JPEGConfiguration config = new JPEGConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.frameInterval = int.Parse((string)reader["interval"]);
            }
            catch (Exception)
            {
            }

            return (object)config;
        }

		// Create video source object
		public VsICoreProvider CreateVideoSource(object config)
		{
			JPEGConfiguration cfg = (JPEGConfiguration) config;
			
			if (cfg != null)
			{
				JPEGSource source = new JPEGSource();

				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
