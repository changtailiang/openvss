// txtd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ftjf	
// skkp	 By downloading, copying, installing or using the software you agree to this license.
// hpdv	 If you do not agree to this license, do not download, install,
// odow	 copy or use the software.
// ixyx	
// poir	                          License Agreement
// eswq	         For OpenVss - Open Source Video Surveillance System
// gnzy	
// acfb	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xbjk	
// ggxc	Third party copyrights are property of their respective owners.
// coqv	
// uhyv	Redistribution and use in source and binary forms, with or without modification,
// zvor	are permitted provided that the following conditions are met:
// lsbz	
// otiu	  * Redistribution's of source code must retain the above copyright notice,
// pfvm	    this list of conditions and the following disclaimer.
// xnzh	
// onrj	  * Redistribution's in binary form must reproduce the above copyright notice,
// rgpp	    this list of conditions and the following disclaimer in the documentation
// cbvz	    and/or other materials provided with the distribution.
// oeye	
// ooqf	  * Neither the name of the copyright holders nor the names of its contributors 
// ajwm	    may not be used to endorse or promote products derived from this software 
// xcmw	    without specific prior written permission.
// tdxg	
// irgm	This software is provided by the copyright holders and contributors "as is" and
// eeae	any express or implied warranties, including, but not limited to, the implied
// clxm	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yigl	In no event shall the Prince of Songkla University or contributors be liable 
// gqxi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xthf	(including, but not limited to, procurement of substitute goods or services;
// qflo	loss of use, data, or profits; or business interruption) however caused
// tswy	and on any theory of liability, whether in contract, strict liability,
// dprw	or tort (including negligence or otherwise) arising in any way out of
// xlaj	the use of this software, even if advised of the possibility of such damage.

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
