// ldcf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// chyg	
// ertv	 By downloading, copying, installing or using the software you agree to this license.
// kycp	 If you do not agree to this license, do not download, install,
// bkko	 copy or use the software.
// pjlt	
// qdie	                          License Agreement
// szlj	         For OpenVSS - Open Source Video Surveillance System
// evap	
// gocz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pzgd	
// ntaz	Third party copyrights are property of their respective owners.
// lruj	
// umtc	Redistribution and use in source and binary forms, with or without modification,
// sipz	are permitted provided that the following conditions are met:
// zune	
// gjqo	  * Redistribution's of source code must retain the above copyright notice,
// xmim	    this list of conditions and the following disclaimer.
// hlzq	
// cigw	  * Redistribution's in binary form must reproduce the above copyright notice,
// cita	    this list of conditions and the following disclaimer in the documentation
// fbps	    and/or other materials provided with the distribution.
// cywy	
// zczv	  * Neither the name of the copyright holders nor the names of its contributors 
// lbwd	    may not be used to endorse or promote products derived from this software 
// dmcy	    without specific prior written permission.
// jhbi	
// nczk	This software is provided by the copyright holders and contributors "as is" and
// csxq	any express or implied warranties, including, but not limited to, the implied
// bnye	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uylz	In no event shall the Prince of Songkla University or contributors be liable 
// qkne	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ldeb	(including, but not limited to, procurement of substitute goods or services;
// lctq	loss of use, data, or profits; or business interruption) however caused
// gvry	and on any theory of liability, whether in contract, strict liability,
// ahez	or tort (including negligence or otherwise) arising in any way out of
// ymvh	the use of this software, even if advised of the possibility of such damage.
// fjuy	
// csje	Intelligent Systems Laboratory (iSys Lab)
// achy	Faculty of Engineering, Prince of Songkla University, THAILAND
// uwwj	Project leader by Nikom SUVONVORN
// yyya	Project website at http://code.google.com/p/openvss/

namespace VdPixord
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// PixordCameraDescription
	/// </summary>
	public class PixordCameraDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "PiXORD network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to PiXORD network cameras"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new PixordCameraSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			PixordConfiguration cfg = (PixordConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			PixordConfiguration	config = new PixordConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            PixordConfiguration config = new PixordConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			PixordConfiguration cfg = (PixordConfiguration) config;
			
			if (cfg != null)
			{
				PixordCamera source = new PixordCamera();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
