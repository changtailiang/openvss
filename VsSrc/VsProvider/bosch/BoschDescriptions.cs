// jqol	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zeex	
// jtrn	 By downloading, copying, installing or using the software you agree to this license.
// qvml	 If you do not agree to this license, do not download, install,
// oyjf	 copy or use the software.
// lhwz	
// xuxj	                          License Agreement
// hfsv	         For OpenVSS - Open Source Video Surveillance System
// gfzp	
// gser	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jclq	
// jtxb	Third party copyrights are property of their respective owners.
// ylzk	
// wfec	Redistribution and use in source and binary forms, with or without modification,
// uooe	are permitted provided that the following conditions are met:
// hvpe	
// bvgk	  * Redistribution's of source code must retain the above copyright notice,
// vwev	    this list of conditions and the following disclaimer.
// trwi	
// vfpd	  * Redistribution's in binary form must reproduce the above copyright notice,
// wvkw	    this list of conditions and the following disclaimer in the documentation
// fiyb	    and/or other materials provided with the distribution.
// bwvr	
// eakn	  * Neither the name of the copyright holders nor the names of its contributors 
// nhpo	    may not be used to endorse or promote products derived from this software 
// nmfc	    without specific prior written permission.
// geqf	
// jwho	This software is provided by the copyright holders and contributors "as is" and
// zkhl	any express or implied warranties, including, but not limited to, the implied
// ktyt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wejz	In no event shall the Prince of Songkla University or contributors be liable 
// amqt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hiun	(including, but not limited to, procurement of substitute goods or services;
// pbqk	loss of use, data, or profits; or business interruption) however caused
// pipb	and on any theory of liability, whether in contract, strict liability,
// rtsf	or tort (including negligence or otherwise) arising in any way out of
// pgsu	the use of this software, even if advised of the possibility of such damage.
// szcu	
// jwsj	Intelligent Systems Laboratory (iSys Lab)
// dgbt	Faculty of Engineering, Prince of Songkla University, THAILAND
// nwya	Project leader by Nikom SUVONVORN
// btzy	Project website at http://code.google.com/p/openvss/

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
