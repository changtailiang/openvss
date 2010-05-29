// ynik	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bdvu	
// jhcs	 By downloading, copying, installing or using the software you agree to this license.
// prrz	 If you do not agree to this license, do not download, install,
// rvfh	 copy or use the software.
// qgyd	
// shve	                          License Agreement
// kpvm	         For OpenVSS - Open Source Video Surveillance System
// iomc	
// qahe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hteh	
// trbe	Third party copyrights are property of their respective owners.
// sqnd	
// ppks	Redistribution and use in source and binary forms, with or without modification,
// ofsu	are permitted provided that the following conditions are met:
// irku	
// mqja	  * Redistribution's of source code must retain the above copyright notice,
// fpiq	    this list of conditions and the following disclaimer.
// nazw	
// brka	  * Redistribution's in binary form must reproduce the above copyright notice,
// gqmt	    this list of conditions and the following disclaimer in the documentation
// crwt	    and/or other materials provided with the distribution.
// eunl	
// inwq	  * Neither the name of the copyright holders nor the names of its contributors 
// jkuc	    may not be used to endorse or promote products derived from this software 
// iazc	    without specific prior written permission.
// iwpp	
// pnrx	This software is provided by the copyright holders and contributors "as is" and
// uror	any express or implied warranties, including, but not limited to, the implied
// fqsu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// upwl	In no event shall the Prince of Songkla University or contributors be liable 
// bwia	for any direct, indirect, incidental, special, exemplary, or consequential damages
// djnq	(including, but not limited to, procurement of substitute goods or services;
// whsf	loss of use, data, or profits; or business interruption) however caused
// rjlf	and on any theory of liability, whether in contract, strict liability,
// chdq	or tort (including negligence or otherwise) arising in any way out of
// dpqr	the use of this software, even if advised of the possibility of such damage.
// zfks	
// sais	Intelligent Systems Laboratory (iSys Lab)
// enal	Faculty of Engineering, Prince of Songkla University, THAILAND
// oplg	Project leader by Nikom SUVONVORN
// aabn	Project website at http://code.google.com/p/openvss/

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
