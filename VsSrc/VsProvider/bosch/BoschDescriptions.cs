// pfts	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wmeo	
// vugk	 By downloading, copying, installing or using the software you agree to this license.
// eabp	 If you do not agree to this license, do not download, install,
// moep	 copy or use the software.
// mcla	
// sfyw	                          License Agreement
// zdfa	         For OpenVss - Open Source Video Surveillance System
// hxyb	
// ucdp	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pkig	
// lbgw	Third party copyrights are property of their respective owners.
// yofs	
// ucjm	Redistribution and use in source and binary forms, with or without modification,
// tsar	are permitted provided that the following conditions are met:
// nhps	
// pgdg	  * Redistribution's of source code must retain the above copyright notice,
// cavk	    this list of conditions and the following disclaimer.
// kpac	
// uepr	  * Redistribution's in binary form must reproduce the above copyright notice,
// ybxl	    this list of conditions and the following disclaimer in the documentation
// xmfe	    and/or other materials provided with the distribution.
// olhb	
// bmbh	  * Neither the name of the copyright holders nor the names of its contributors 
// uprf	    may not be used to endorse or promote products derived from this software 
// yzty	    without specific prior written permission.
// tvif	
// bgso	This software is provided by the copyright holders and contributors "as is" and
// djsl	any express or implied warranties, including, but not limited to, the implied
// kdvc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bysr	In no event shall the Prince of Songkla University or contributors be liable 
// stiy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// othe	(including, but not limited to, procurement of substitute goods or services;
// nksy	loss of use, data, or profits; or business interruption) however caused
// izsc	and on any theory of liability, whether in contract, strict liability,
// each	or tort (including negligence or otherwise) arising in any way out of
// stys	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Bosch
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// BoschCameraDescription
	/// </summary>
	public class BoschCameraDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Bosch network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Bosch network cameras"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new BoschCameraSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			BoschConfiguration cfg = (BoschConfiguration) config;

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
			BoschConfiguration	config = new BoschConfiguration();

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
            BoschConfiguration config = new BoschConfiguration();

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
			BoschConfiguration cfg = (BoschConfiguration) config;
			
			if (cfg != null)
			{
				BoschCamera source = new BoschCamera();

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
