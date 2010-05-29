// lnqk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// obyd	
// figm	 By downloading, copying, installing or using the software you agree to this license.
// wmiu	 If you do not agree to this license, do not download, install,
// bzgt	 copy or use the software.
// elzf	
// foiy	                          License Agreement
// gaku	         For OpenVSS - Open Source Video Surveillance System
// ycaq	
// zcgj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tsso	
// taqd	Third party copyrights are property of their respective owners.
// qlyc	
// guya	Redistribution and use in source and binary forms, with or without modification,
// okea	are permitted provided that the following conditions are met:
// taxf	
// xlou	  * Redistribution's of source code must retain the above copyright notice,
// mrvz	    this list of conditions and the following disclaimer.
// twzl	
// slmf	  * Redistribution's in binary form must reproduce the above copyright notice,
// yehu	    this list of conditions and the following disclaimer in the documentation
// bind	    and/or other materials provided with the distribution.
// daco	
// xgqt	  * Neither the name of the copyright holders nor the names of its contributors 
// vnqh	    may not be used to endorse or promote products derived from this software 
// lwry	    without specific prior written permission.
// qzjj	
// vnhd	This software is provided by the copyright holders and contributors "as is" and
// yzco	any express or implied warranties, including, but not limited to, the implied
// scdp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xlql	In no event shall the Prince of Songkla University or contributors be liable 
// pgbn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ggqf	(including, but not limited to, procurement of substitute goods or services;
// uftb	loss of use, data, or profits; or business interruption) however caused
// njec	and on any theory of liability, whether in contract, strict liability,
// yehq	or tort (including negligence or otherwise) arising in any way out of
// szqx	the use of this software, even if advised of the possibility of such damage.
// ebas	
// jbja	Intelligent Systems Laboratory (iSys Lab)
// gfjk	Faculty of Engineering, Prince of Songkla University, THAILAND
// xwcp	Project leader by Nikom SUVONVORN
// wbis	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Mjpeg
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// MJPEGSourceDescription
	/// </summary>
	public class MJPEGSourceDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "MJPEG stream"; }
		}

		// Description property
		public string Description
		{
			get { return "Retrieve Motion JPEG stream from the specified URL"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new MJPEGSourcePage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			MJPEGConfiguration	cfg = (MJPEGConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			MJPEGConfiguration	config = new MJPEGConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
			}
			catch (Exception)
			{
			}

			return (object) config;
		}

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            MJPEGConfiguration config = new MJPEGConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
            }
            catch (Exception)
            {
            }

            return (object)config;
        }

		// Create video source object
		public VsICoreProvider CreateVideoSource(object config)
		{
			MJPEGConfiguration cfg = (MJPEGConfiguration) config;
			
			if (cfg != null)
			{
				MJPEGSource source = new MJPEGSource();

				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
