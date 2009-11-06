// znqd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vswr	
// fffr	 By downloading, copying, installing or using the software you agree to this license.
// bqke	 If you do not agree to this license, do not download, install,
// pbdq	 copy or use the software.
// msaj	
// emis	                          License Agreement
// sipp	         For OpenVss - Open Source Video Surveillance System
// jdri	
// kiyy	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vnxz	
// fepc	Third party copyrights are property of their respective owners.
// ncyf	
// zpgh	Redistribution and use in source and binary forms, with or without modification,
// mhzj	are permitted provided that the following conditions are met:
// jeyx	
// ppiy	  * Redistribution's of source code must retain the above copyright notice,
// zcug	    this list of conditions and the following disclaimer.
// deuz	
// ubdz	  * Redistribution's in binary form must reproduce the above copyright notice,
// wgfp	    this list of conditions and the following disclaimer in the documentation
// jjqu	    and/or other materials provided with the distribution.
// wkvc	
// jopr	  * Neither the name of the copyright holders nor the names of its contributors 
// oajp	    may not be used to endorse or promote products derived from this software 
// wrdk	    without specific prior written permission.
// hscv	
// uhnk	This software is provided by the copyright holders and contributors "as is" and
// dzmd	any express or implied warranties, including, but not limited to, the implied
// zjnf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zoco	In no event shall the Prince of Songkla University or contributors be liable 
// hrxp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pdku	(including, but not limited to, procurement of substitute goods or services;
// snde	loss of use, data, or profits; or business interruption) however caused
// cuhr	and on any theory of liability, whether in contract, strict liability,
// huzo	or tort (including negligence or otherwise) arising in any way out of
// wkzj	the use of this software, even if advised of the possibility of such damage.

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
