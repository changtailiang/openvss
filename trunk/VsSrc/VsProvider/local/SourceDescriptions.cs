// rxnq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rgge	
// mdvw	 By downloading, copying, installing or using the software you agree to this license.
// uytv	 If you do not agree to this license, do not download, install,
// tkjb	 copy or use the software.
// ysga	
// qrlh	                          License Agreement
// qocf	         For OpenVss - Open Source Video Surveillance System
// jfmo	
// amlc	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// yuuy	
// dfck	Third party copyrights are property of their respective owners.
// wchv	
// jxoy	Redistribution and use in source and binary forms, with or without modification,
// qnzz	are permitted provided that the following conditions are met:
// uzox	
// apno	  * Redistribution's of source code must retain the above copyright notice,
// levh	    this list of conditions and the following disclaimer.
// yhdd	
// yiwk	  * Redistribution's in binary form must reproduce the above copyright notice,
// pbln	    this list of conditions and the following disclaimer in the documentation
// hgvl	    and/or other materials provided with the distribution.
// royn	
// mmhz	  * Neither the name of the copyright holders nor the names of its contributors 
// gwxn	    may not be used to endorse or promote products derived from this software 
// snzr	    without specific prior written permission.
// hzxc	
// ukai	This software is provided by the copyright holders and contributors "as is" and
// rpjt	any express or implied warranties, including, but not limited to, the implied
// napu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tbxx	In no event shall the Prince of Songkla University or contributors be liable 
// ghul	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zdxb	(including, but not limited to, procurement of substitute goods or services;
// kisc	loss of use, data, or profits; or business interruption) however caused
// btgh	and on any theory of liability, whether in contract, strict liability,
// isrg	or tort (including negligence or otherwise) arising in any way out of
// npwx	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Local
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// CaptureDeviceDescription
	/// </summary>
	public class CaptureDeviceDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Local capture device"; }
		}

		// Description property
		public string Description
		{
			get { return "Captures video form local capture device attached to the computer"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new CaptureDeviceSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			LocalConfiguration cfg = (LocalConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			LocalConfiguration config = new LocalConfiguration();

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
            LocalConfiguration config = new LocalConfiguration();

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
			LocalConfiguration cfg = (LocalConfiguration) config;
			
			if (cfg != null)
			{
				CaptureDevice source = new CaptureDevice();

				source.VideoSource	= cfg.source;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}
}
