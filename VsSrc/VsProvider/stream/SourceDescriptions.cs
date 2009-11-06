// zvdy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// msnq	
// poeg	 By downloading, copying, installing or using the software you agree to this license.
// dgcf	 If you do not agree to this license, do not download, install,
// lear	 copy or use the software.
// tama	
// pult	                          License Agreement
// mymt	         For OpenVss - Open Source Video Surveillance System
// ufoi	
// khvg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hgvm	
// mtjp	Third party copyrights are property of their respective owners.
// zmnw	
// czrz	Redistribution and use in source and binary forms, with or without modification,
// jdis	are permitted provided that the following conditions are met:
// hudq	
// bkly	  * Redistribution's of source code must retain the above copyright notice,
// rtve	    this list of conditions and the following disclaimer.
// iukn	
// fzov	  * Redistribution's in binary form must reproduce the above copyright notice,
// kvtz	    this list of conditions and the following disclaimer in the documentation
// lqrv	    and/or other materials provided with the distribution.
// npzg	
// ydzn	  * Neither the name of the copyright holders nor the names of its contributors 
// cekc	    may not be used to endorse or promote products derived from this software 
// ilyf	    without specific prior written permission.
// qioi	
// odtk	This software is provided by the copyright holders and contributors "as is" and
// pnil	any express or implied warranties, including, but not limited to, the implied
// adfl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tpkb	In no event shall the Prince of Songkla University or contributors be liable 
// uofe	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vwla	(including, but not limited to, procurement of substitute goods or services;
// olny	loss of use, data, or profits; or business interruption) however caused
// wnjc	and on any theory of liability, whether in contract, strict liability,
// bjgj	or tort (including negligence or otherwise) arising in any way out of
// wprl	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Stream
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// VideoStreamSourceDescription
	/// </summary>
	public class VideoStreamSourceDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Video stream"; }
		}

		// Description property
		public string Description
		{
			get { return "Downloads video from video streaming servers"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new VideoStreamSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			StreamConfiguration cfg = (StreamConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			StreamConfiguration config = new StreamConfiguration();

			try
			{
				config.source = reader.GetAttribute("source");
			}
			catch (Exception)
			{
			}
			return (object) config;
		}

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            StreamConfiguration config = new StreamConfiguration();

            try
            {
                config.source = (string)reader["source"];
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

		// Create video source object
		public VsICoreProvider CreateVideoSource(object config)
		{
			StreamConfiguration cfg = (StreamConfiguration) config;
			
			if (cfg != null)
			{
				VideoStream source = new VideoStream();

				source.VideoSource	= cfg.source;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
