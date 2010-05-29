// hehf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dklq	
// uwtj	 By downloading, copying, installing or using the software you agree to this license.
// mcci	 If you do not agree to this license, do not download, install,
// qdsu	 copy or use the software.
// yngj	
// lkoh	                          License Agreement
// ymtu	         For OpenVSS - Open Source Video Surveillance System
// vbwh	
// eqrl	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ejqi	
// wcwk	Third party copyrights are property of their respective owners.
// pcss	
// npqt	Redistribution and use in source and binary forms, with or without modification,
// yxtt	are permitted provided that the following conditions are met:
// wdsi	
// dyok	  * Redistribution's of source code must retain the above copyright notice,
// guea	    this list of conditions and the following disclaimer.
// lhpo	
// xxni	  * Redistribution's in binary form must reproduce the above copyright notice,
// nesv	    this list of conditions and the following disclaimer in the documentation
// uagf	    and/or other materials provided with the distribution.
// ldjg	
// wypa	  * Neither the name of the copyright holders nor the names of its contributors 
// rifx	    may not be used to endorse or promote products derived from this software 
// omdv	    without specific prior written permission.
// yrhg	
// zbva	This software is provided by the copyright holders and contributors "as is" and
// klfr	any express or implied warranties, including, but not limited to, the implied
// lxnc	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sjzd	In no event shall the Prince of Songkla University or contributors be liable 
// kyem	for any direct, indirect, incidental, special, exemplary, or consequential damages
// spxp	(including, but not limited to, procurement of substitute goods or services;
// spub	loss of use, data, or profits; or business interruption) however caused
// bxxc	and on any theory of liability, whether in contract, strict liability,
// tafj	or tort (including negligence or otherwise) arising in any way out of
// hjvk	the use of this software, even if advised of the possibility of such damage.
// txpu	
// ucff	Intelligent Systems Laboratory (iSys Lab)
// nakz	Faculty of Engineering, Prince of Songkla University, THAILAND
// nunk	Project leader by Nikom SUVONVORN
// egiu	Project website at http://code.google.com/p/openvss/

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
