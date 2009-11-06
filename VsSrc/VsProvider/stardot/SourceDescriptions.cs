// zcvf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// brpi	
// rgrs	 By downloading, copying, installing or using the software you agree to this license.
// gtdh	 If you do not agree to this license, do not download, install,
// jioq	 copy or use the software.
// zhpg	
// xrdw	                          License Agreement
// zmvs	         For OpenVss - Open Source Video Surveillance System
// caav	
// vfwf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mfzx	
// pamx	Third party copyrights are property of their respective owners.
// ckig	
// agfr	Redistribution and use in source and binary forms, with or without modification,
// moij	are permitted provided that the following conditions are met:
// nsie	
// lyqg	  * Redistribution's of source code must retain the above copyright notice,
// shmd	    this list of conditions and the following disclaimer.
// mjeu	
// irqx	  * Redistribution's in binary form must reproduce the above copyright notice,
// fgup	    this list of conditions and the following disclaimer in the documentation
// epsw	    and/or other materials provided with the distribution.
// ujjg	
// xnru	  * Neither the name of the copyright holders nor the names of its contributors 
// xvlr	    may not be used to endorse or promote products derived from this software 
// jgeu	    without specific prior written permission.
// yetr	
// blju	This software is provided by the copyright holders and contributors "as is" and
// xleh	any express or implied warranties, including, but not limited to, the implied
// xtzw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gtmj	In no event shall the Prince of Songkla University or contributors be liable 
// yffy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rkwn	(including, but not limited to, procurement of substitute goods or services;
// gzny	loss of use, data, or profits; or business interruption) however caused
// baqa	and on any theory of liability, whether in contract, strict liability,
// vavi	or tort (including negligence or otherwise) arising in any way out of
// aojm	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Stardot
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// StardotNetCamDescription
	/// </summary>
	public class StardotNetCamDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "StarDot NetCam network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to StarDot NetCam network cameras"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new StardotNetCamSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			StardotConfiguration cfg = (StardotConfiguration) config;

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
			StardotConfiguration config = new StardotConfiguration();

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
            StardotConfiguration config = new StardotConfiguration();

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
			StardotConfiguration cfg = (StardotConfiguration) config;
			
			if (cfg != null)
			{
				StardotNetCam source = new StardotNetCam();

				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// StardotExpress6Description
	/// </summary>
	public class StardotExpress6Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "StarDot Express 6 video server"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to StarDot Express 6 video serevr"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new StardotExpress6SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			StardotConfiguration cfg = (StardotConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
				writer.WriteAttributeString("camera", cfg.camera.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			StardotConfiguration config = new StardotConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.frameInterval = int.Parse(reader.GetAttribute("interval"));
				config.camera	= short.Parse(reader.GetAttribute("camera"));
			}
			catch (Exception)
			{
			}
			return (object) config;
		}

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            StardotConfiguration config = new StardotConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.frameInterval = int.Parse((string)reader["interval"]);
                config.camera = short.Parse((string)reader["camera"]);
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

		// Create video source object
		public VsICoreProvider CreateVideoSource(object config)
		{
			StardotConfiguration cfg = (StardotConfiguration) config;
			
			if (cfg != null)
			{
				StardotExpress6 source = new StardotExpress6();

				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.FrameInterval = cfg.frameInterval;
				source.Camera		= cfg.camera;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
