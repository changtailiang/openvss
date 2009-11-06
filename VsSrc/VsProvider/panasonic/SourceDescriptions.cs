// dsqj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uile	
// tccl	 By downloading, copying, installing or using the software you agree to this license.
// bvej	 If you do not agree to this license, do not download, install,
// dzfy	 copy or use the software.
// szmj	
// xbuk	                          License Agreement
// nidp	         For OpenVss - Open Source Video Surveillance System
// qnic	
// mmfe	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pbcy	
// rian	Third party copyrights are property of their respective owners.
// hydf	
// avje	Redistribution and use in source and binary forms, with or without modification,
// fgls	are permitted provided that the following conditions are met:
// nbrl	
// zmuo	  * Redistribution's of source code must retain the above copyright notice,
// mbwr	    this list of conditions and the following disclaimer.
// taiq	
// wnsp	  * Redistribution's in binary form must reproduce the above copyright notice,
// bgco	    this list of conditions and the following disclaimer in the documentation
// fxov	    and/or other materials provided with the distribution.
// dewf	
// anrn	  * Neither the name of the copyright holders nor the names of its contributors 
// krze	    may not be used to endorse or promote products derived from this software 
// nmbg	    without specific prior written permission.
// clma	
// mshs	This software is provided by the copyright holders and contributors "as is" and
// owrg	any express or implied warranties, including, but not limited to, the implied
// zcgc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xzli	In no event shall the Prince of Songkla University or contributors be liable 
// frrg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ivgf	(including, but not limited to, procurement of substitute goods or services;
// onbo	loss of use, data, or profits; or business interruption) however caused
// fvmt	and on any theory of liability, whether in contract, strict liability,
// koik	or tort (including negligence or otherwise) arising in any way out of
// werd	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Panasonic
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// PanasonicCameraDescription
	/// </summary>
	public class PanasonicCameraDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Panasonic network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Panasonic network cameras"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new PanasonicCameraSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			PanasonicConfiguration cfg = (PanasonicConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("quality", cfg.quality);
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			PanasonicConfiguration	config = new PanasonicConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
				config.quality	= reader.GetAttribute("quality");
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
            PanasonicConfiguration config = new PanasonicConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
                config.quality = (string)reader["quality"];
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
			PanasonicConfiguration cfg = (PanasonicConfiguration) config;
			
			if (cfg != null)
			{
				PanasonicCamera source = new PanasonicCamera();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.Quality		= cfg.quality;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
