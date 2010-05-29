// cypr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// icex	
// aocu	 By downloading, copying, installing or using the software you agree to this license.
// owky	 If you do not agree to this license, do not download, install,
// uook	 copy or use the software.
// osrf	
// osij	                          License Agreement
// mgqb	         For OpenVSS - Open Source Video Surveillance System
// awai	
// lbti	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bhlt	
// dkwa	Third party copyrights are property of their respective owners.
// zcei	
// yuzj	Redistribution and use in source and binary forms, with or without modification,
// gjdp	are permitted provided that the following conditions are met:
// uukt	
// xbus	  * Redistribution's of source code must retain the above copyright notice,
// vcmt	    this list of conditions and the following disclaimer.
// vfjg	
// hyce	  * Redistribution's in binary form must reproduce the above copyright notice,
// whkk	    this list of conditions and the following disclaimer in the documentation
// chcg	    and/or other materials provided with the distribution.
// xrbc	
// ydog	  * Neither the name of the copyright holders nor the names of its contributors 
// xrvb	    may not be used to endorse or promote products derived from this software 
// qeew	    without specific prior written permission.
// qlnt	
// ksch	This software is provided by the copyright holders and contributors "as is" and
// gytm	any express or implied warranties, including, but not limited to, the implied
// karp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// znud	In no event shall the Prince of Songkla University or contributors be liable 
// bjvr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rdjp	(including, but not limited to, procurement of substitute goods or services;
// daos	loss of use, data, or profits; or business interruption) however caused
// dntq	and on any theory of liability, whether in contract, strict liability,
// ujve	or tort (including negligence or otherwise) arising in any way out of
// ptvz	the use of this software, even if advised of the possibility of such damage.
// kbvw	
// afbc	Intelligent Systems Laboratory (iSys Lab)
// javg	Faculty of Engineering, Prince of Songkla University, THAILAND
// qvbh	Project leader by Nikom SUVONVORN
// jmef	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.Dlink
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// DLinkCameraDescription
	/// </summary>
	public class DLinkCameraDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "DLink network camera"; }
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
				DLinkCamera source = new DLinkCamera();

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
