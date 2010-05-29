// thry	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oavi	
// kfak	 By downloading, copying, installing or using the software you agree to this license.
// ylcg	 If you do not agree to this license, do not download, install,
// rjcv	 copy or use the software.
// lgpj	
// lpxd	                          License Agreement
// oeec	         For OpenVSS - Open Source Video Surveillance System
// awan	
// ells	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hmmz	
// mhhb	Third party copyrights are property of their respective owners.
// kgyn	
// pfxm	Redistribution and use in source and binary forms, with or without modification,
// riny	are permitted provided that the following conditions are met:
// dsug	
// bykb	  * Redistribution's of source code must retain the above copyright notice,
// kpcg	    this list of conditions and the following disclaimer.
// xjny	
// uqwe	  * Redistribution's in binary form must reproduce the above copyright notice,
// ivsi	    this list of conditions and the following disclaimer in the documentation
// grmu	    and/or other materials provided with the distribution.
// zovv	
// ynpp	  * Neither the name of the copyright holders nor the names of its contributors 
// sgyn	    may not be used to endorse or promote products derived from this software 
// wfrv	    without specific prior written permission.
// drpg	
// rysb	This software is provided by the copyright holders and contributors "as is" and
// lipi	any express or implied warranties, including, but not limited to, the implied
// zlzk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mpcv	In no event shall the Prince of Songkla University or contributors be liable 
// tgik	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uygn	(including, but not limited to, procurement of substitute goods or services;
// sjid	loss of use, data, or profits; or business interruption) however caused
// dxeo	and on any theory of liability, whether in contract, strict liability,
// cgda	or tort (including negligence or otherwise) arising in any way out of
// wukq	the use of this software, even if advised of the possibility of such damage.
// xhqh	
// gobg	Intelligent Systems Laboratory (iSys Lab)
// cvbx	Faculty of Engineering, Prince of Songkla University, THAILAND
// jemt	Project leader by Nikom SUVONVORN
// seic	Project website at http://code.google.com/p/openvss/

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
