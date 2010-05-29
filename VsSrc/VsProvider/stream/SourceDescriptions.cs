// lfkj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ujsz	
// mjxx	 By downloading, copying, installing or using the software you agree to this license.
// gbhy	 If you do not agree to this license, do not download, install,
// ejsi	 copy or use the software.
// lwyd	
// khvx	                          License Agreement
// ibyo	         For OpenVSS - Open Source Video Surveillance System
// rrrq	
// eqcr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gxwv	
// fbqt	Third party copyrights are property of their respective owners.
// swxy	
// lhdo	Redistribution and use in source and binary forms, with or without modification,
// hhzn	are permitted provided that the following conditions are met:
// nuql	
// kifp	  * Redistribution's of source code must retain the above copyright notice,
// krtn	    this list of conditions and the following disclaimer.
// habo	
// adyi	  * Redistribution's in binary form must reproduce the above copyright notice,
// rbel	    this list of conditions and the following disclaimer in the documentation
// dadk	    and/or other materials provided with the distribution.
// ncix	
// rpdl	  * Neither the name of the copyright holders nor the names of its contributors 
// glkw	    may not be used to endorse or promote products derived from this software 
// vajb	    without specific prior written permission.
// cjrk	
// fooe	This software is provided by the copyright holders and contributors "as is" and
// iqvl	any express or implied warranties, including, but not limited to, the implied
// qehk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fubi	In no event shall the Prince of Songkla University or contributors be liable 
// iwwr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wpip	(including, but not limited to, procurement of substitute goods or services;
// sbnq	loss of use, data, or profits; or business interruption) however caused
// scju	and on any theory of liability, whether in contract, strict liability,
// isez	or tort (including negligence or otherwise) arising in any way out of
// oeob	the use of this software, even if advised of the possibility of such damage.
// trvb	
// daqa	Intelligent Systems Laboratory (iSys Lab)
// zatf	Faculty of Engineering, Prince of Songkla University, THAILAND
// nzoq	Project leader by Nikom SUVONVORN
// gzlg	Project website at http://code.google.com/p/openvss/

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
