// ecjz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// weij	
// krjf	 By downloading, copying, installing or using the software you agree to this license.
// jiho	 If you do not agree to this license, do not download, install,
// puit	 copy or use the software.
// exqx	
// rlgo	                          License Agreement
// sxjm	         For OpenVSS - Open Source Video Surveillance System
// cgsy	
// iazp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dvwu	
// bupo	Third party copyrights are property of their respective owners.
// ztth	
// csqg	Redistribution and use in source and binary forms, with or without modification,
// mlhk	are permitted provided that the following conditions are met:
// yuqm	
// hxcd	  * Redistribution's of source code must retain the above copyright notice,
// pjfp	    this list of conditions and the following disclaimer.
// vspj	
// avvx	  * Redistribution's in binary form must reproduce the above copyright notice,
// vrpz	    this list of conditions and the following disclaimer in the documentation
// ecjk	    and/or other materials provided with the distribution.
// pllx	
// sorj	  * Neither the name of the copyright holders nor the names of its contributors 
// ejne	    may not be used to endorse or promote products derived from this software 
// rmzq	    without specific prior written permission.
// nelk	
// chfr	This software is provided by the copyright holders and contributors "as is" and
// pjpg	any express or implied warranties, including, but not limited to, the implied
// frif	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nsne	In no event shall the Prince of Songkla University or contributors be liable 
// xhwh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bger	(including, but not limited to, procurement of substitute goods or services;
// hrfj	loss of use, data, or profits; or business interruption) however caused
// syla	and on any theory of liability, whether in contract, strict liability,
// qzhi	or tort (including negligence or otherwise) arising in any way out of
// fuhj	the use of this software, even if advised of the possibility of such damage.
// zkem	
// ahqz	Intelligent Systems Laboratory (iSys Lab)
// zutg	Faculty of Engineering, Prince of Songkla University, THAILAND
// idiw	Project leader by Nikom SUVONVORN
// cojy	Project website at http://code.google.com/p/openvss/

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
