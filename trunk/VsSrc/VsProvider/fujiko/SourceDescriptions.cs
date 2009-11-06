// lkpr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// choz	
// lurr	 By downloading, copying, installing or using the software you agree to this license.
// eflg	 If you do not agree to this license, do not download, install,
// enrw	 copy or use the software.
// tyuz	
// sjre	                          License Agreement
// dbdz	         For OpenVss - Open Source Video Surveillance System
// cspi	
// hkdo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wezy	
// zmka	Third party copyrights are property of their respective owners.
// orzi	
// jotm	Redistribution and use in source and binary forms, with or without modification,
// pqys	are permitted provided that the following conditions are met:
// qkvk	
// qspl	  * Redistribution's of source code must retain the above copyright notice,
// pczt	    this list of conditions and the following disclaimer.
// kdao	
// zvzf	  * Redistribution's in binary form must reproduce the above copyright notice,
// zrpl	    this list of conditions and the following disclaimer in the documentation
// buqo	    and/or other materials provided with the distribution.
// zdtq	
// llyl	  * Neither the name of the copyright holders nor the names of its contributors 
// ioih	    may not be used to endorse or promote products derived from this software 
// xzkl	    without specific prior written permission.
// sgyg	
// oemt	This software is provided by the copyright holders and contributors "as is" and
// rtty	any express or implied warranties, including, but not limited to, the implied
// vjiv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// camm	In no event shall the Prince of Songkla University or contributors be liable 
// jihz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eofk	(including, but not limited to, procurement of substitute goods or services;
// nshz	loss of use, data, or profits; or business interruption) however caused
// gdtv	and on any theory of liability, whether in contract, strict liability,
// wjau	or tort (including negligence or otherwise) arising in any way out of
// qazs	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Fujiko
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// DLinkCameraDescription
	/// </summary>
    public class FujikoCameraDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Fujiko network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to DLink network cameras"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new DLinkCameraSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			DLinkConfiguration cfg = (DLinkConfiguration) config;

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
			DLinkConfiguration config = new DLinkConfiguration();

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
            DLinkConfiguration config = new DLinkConfiguration();

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
			DLinkConfiguration cfg = (DLinkConfiguration) config;
			
			if (cfg != null)
			{
                FujikoCamera source = new FujikoCamera();

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
