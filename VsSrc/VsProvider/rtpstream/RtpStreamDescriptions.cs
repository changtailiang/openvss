// dufz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fhwe	
// plhl	 By downloading, copying, installing or using the software you agree to this license.
// owsl	 If you do not agree to this license, do not download, install,
// hbzw	 copy or use the software.
// rria	
// ppin	                          License Agreement
// pgpa	         For OpenVSS - Open Source Video Surveillance System
// ndfj	
// qnxr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// fttl	
// eegx	Third party copyrights are property of their respective owners.
// ckql	
// ghom	Redistribution and use in source and binary forms, with or without modification,
// mfkp	are permitted provided that the following conditions are met:
// zjpj	
// vhyk	  * Redistribution's of source code must retain the above copyright notice,
// qivu	    this list of conditions and the following disclaimer.
// ehqx	
// xxvl	  * Redistribution's in binary form must reproduce the above copyright notice,
// ilke	    this list of conditions and the following disclaimer in the documentation
// pdtg	    and/or other materials provided with the distribution.
// ptwk	
// chsv	  * Neither the name of the copyright holders nor the names of its contributors 
// ekpw	    may not be used to endorse or promote products derived from this software 
// fvgt	    without specific prior written permission.
// owhz	
// qqop	This software is provided by the copyright holders and contributors "as is" and
// jzgo	any express or implied warranties, including, but not limited to, the implied
// ykur	warranties of merchantability and fitness for a particular purpose are disclaimed.
// orvx	In no event shall the Prince of Songkla University or contributors be liable 
// mkrw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ousn	(including, but not limited to, procurement of substitute goods or services;
// hzfn	loss of use, data, or profits; or business interruption) however caused
// erqt	and on any theory of liability, whether in contract, strict liability,
// wuqy	or tort (including negligence or otherwise) arising in any way out of
// ehbc	the use of this software, even if advised of the possibility of such damage.
// aexu	
// pxhn	Intelligent Systems Laboratory (iSys Lab)
// ajhe	Faculty of Engineering, Prince of Songkla University, THAILAND
// elkv	Project leader by Nikom SUVONVORN
// xbhk	Project website at http://code.google.com/p/openvss/

namespace Vs.Provider.RtpStream
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// RtpStreamDescription
	/// </summary>
	public class RtpStream1Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Rtp Stream #1"; }
		}

		// Description property
		public string Description
		{
			get { return "Downloads video from video rtp streaming servers"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new RtpStreamSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			RtpStreamConfiguration cfg = (RtpStreamConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("dest", cfg.dest);
                writer.WriteAttributeString("ssrc", cfg.ssrc);
                writer.WriteAttributeString("video_port", cfg.video_port.ToString());
                writer.WriteAttributeString("audio_port", cfg.video_port.ToString());
                writer.WriteAttributeString("video_codec", cfg.video_codec);
                writer.WriteAttributeString("audio_codec", cfg.audio_codec);
                writer.WriteAttributeString("video_width", cfg.video_width.ToString());
                writer.WriteAttributeString("video_height", cfg.video_height.ToString());
                writer.WriteAttributeString("video_quality", cfg.video_quality.ToString());
            }
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			RtpStreamConfiguration config = new RtpStreamConfiguration();

			try
			{
				config.source = reader.GetAttribute("source");
                config.dest = reader.GetAttribute("dest");
                config.ssrc = reader.GetAttribute("ssrc");
                config.video_port = int.Parse(reader.GetAttribute("video_port"));
                config.audio_port = int.Parse(reader.GetAttribute("audio_port"));
                config.video_codec = reader.GetAttribute("video_codec");
                config.audio_codec = reader.GetAttribute("audio_codec");
                config.video_width = int.Parse(reader.GetAttribute("video_width"));
                config.video_height = int.Parse(reader.GetAttribute("video_height"));
                config.video_quality = int.Parse(reader.GetAttribute("video_quality"));
			}
			catch (Exception)
			{
			}
			return (object) config;
		}

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.dest = (string)reader["dest"];
                config.ssrc = (string)reader["ssrc"];
                config.video_port = (int)reader["video_port"];
                config.audio_port = (int)reader["audio_port"];
                config.video_codec = (string)reader["video_codec"];
                config.audio_codec = (string)reader["audio_codec"];
                config.video_width = (int)reader["video_width"];
                config.video_height = (int)reader["video_height"];
                config.video_quality = (int)reader["video_quality"];
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

		// Create video source object
		public VsICoreProvider CreateVideoSource(object config)
		{
			RtpStreamConfiguration cfg = (RtpStreamConfiguration) config;
			
			if (cfg != null)
			{
                RtpStream1 source = new RtpStream1();

				source.VideoSource	= cfg.source;
                source.VideoDest = cfg.dest;
                source.SSRC = cfg.ssrc;
                source.VideoPort = cfg.video_port;
                source.AudioPort = cfg.audio_port;
                source.VideoCodec = cfg.video_codec;
                source.AudioCodec = cfg.audio_codec;
                source.VideoSizeWidth = cfg.video_width;
                source.VideoSizeHeight = cfg.video_height;
                source.VideoQuality = cfg.video_quality;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}



	/// <summary>
	/// RtpStreamDescription
	/// </summary>
    public class RtpStream2Description : VsICoreProviderDescription
    {
        // Name property
        public string Name
        {
            get { return "Rtp Stream #2"; }
        }

        // Description property
        public string Description
        {
            get { return "Downloads video from video rtp streaming servers"; }
        }

        // Return settings page
        public VsICoreProviderPage GetSettingsPage()
        {
            return new RtpStreamSetupPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("dest", cfg.dest);
                writer.WriteAttributeString("ssrc", cfg.ssrc);
                writer.WriteAttributeString("video_port", cfg.video_port.ToString());
                writer.WriteAttributeString("audio_port", cfg.video_port.ToString());
                writer.WriteAttributeString("video_codec", cfg.video_codec);
                writer.WriteAttributeString("audio_codec", cfg.audio_codec);
                writer.WriteAttributeString("video_width", cfg.video_width.ToString());
                writer.WriteAttributeString("video_height", cfg.video_height.ToString());
                writer.WriteAttributeString("video_quality", cfg.video_quality.ToString());
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
                config.dest = reader.GetAttribute("dest");
                config.ssrc = reader.GetAttribute("ssrc");
                config.video_port = int.Parse(reader.GetAttribute("video_port"));
                config.audio_port = int.Parse(reader.GetAttribute("audio_port"));
                config.video_codec = reader.GetAttribute("video_codec");
                config.audio_codec = reader.GetAttribute("audio_codec");
                config.video_width = int.Parse(reader.GetAttribute("video_width"));
                config.video_height = int.Parse(reader.GetAttribute("video_height"));
                config.video_quality = int.Parse(reader.GetAttribute("video_quality"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.dest = (string)reader["dest"];
                config.ssrc = (string)reader["ssrc"];
                config.video_port = (int)reader["video_port"];
                config.audio_port = (int)reader["audio_port"];
                config.video_codec = (string)reader["video_codec"];
                config.audio_codec = (string)reader["audio_codec"];
                config.video_width = (int)reader["video_width"];
                config.video_height = (int)reader["video_height"];
                config.video_quality = (int)reader["video_quality"];
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Create video source object
        public VsICoreProvider CreateVideoSource(object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                RtpStream2 source = new RtpStream2();

                source.VideoSource = cfg.source;
                source.VideoDest = cfg.dest;
                source.SSRC = cfg.ssrc;
                source.VideoPort = cfg.video_port;
                source.AudioPort = cfg.audio_port;
                source.VideoCodec = cfg.video_codec;
                source.AudioCodec = cfg.audio_codec;
                source.VideoSizeWidth = cfg.video_width;
                source.VideoSizeHeight = cfg.video_height;
                source.VideoQuality = cfg.video_quality;

                return (VsICoreProvider)source;
            }
            return null;
        }
    }



	/// <summary>
	/// RtpStreamDescription
	/// </summary>
    public class RtpStream3Description : VsICoreProviderDescription
    {
        // Name property
        public string Name
        {
            get { return "Rtp Stream #3"; }
        }

        // Description property
        public string Description
        {
            get { return "Downloads video from video rtp streaming servers"; }
        }

        // Return settings page
        public VsICoreProviderPage GetSettingsPage()
        {
            return new RtpStreamSetupPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("dest", cfg.dest);
                writer.WriteAttributeString("ssrc", cfg.ssrc);
                writer.WriteAttributeString("video_port", cfg.video_port.ToString());
                writer.WriteAttributeString("audio_port", cfg.video_port.ToString());
                writer.WriteAttributeString("video_codec", cfg.video_codec);
                writer.WriteAttributeString("audio_codec", cfg.audio_codec);
                writer.WriteAttributeString("video_width", cfg.video_width.ToString());
                writer.WriteAttributeString("video_height", cfg.video_height.ToString());
                writer.WriteAttributeString("video_quality", cfg.video_quality.ToString());
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
                config.dest = reader.GetAttribute("dest");
                config.ssrc = reader.GetAttribute("ssrc");
                config.video_port = int.Parse(reader.GetAttribute("video_port"));
                config.audio_port = int.Parse(reader.GetAttribute("audio_port"));
                config.video_codec = reader.GetAttribute("video_codec");
                config.audio_codec = reader.GetAttribute("audio_codec");
                config.video_width = int.Parse(reader.GetAttribute("video_width"));
                config.video_height = int.Parse(reader.GetAttribute("video_height"));
                config.video_quality = int.Parse(reader.GetAttribute("video_quality"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.dest = (string)reader["dest"];
                config.ssrc = (string)reader["ssrc"];
                config.video_port = (int)reader["video_port"];
                config.audio_port = (int)reader["audio_port"];
                config.video_codec = (string)reader["video_codec"];
                config.audio_codec = (string)reader["audio_codec"];
                config.video_width = (int)reader["video_width"];
                config.video_height = (int)reader["video_height"];
                config.video_quality = (int)reader["video_quality"];
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Create video source object
        public VsICoreProvider CreateVideoSource(object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                RtpStream3 source = new RtpStream3();

                source.VideoSource = cfg.source;
                source.VideoDest = cfg.dest;
                source.SSRC = cfg.ssrc;
                source.VideoPort = cfg.video_port;
                source.AudioPort = cfg.audio_port;
                source.VideoCodec = cfg.video_codec;
                source.AudioCodec = cfg.audio_codec;
                source.VideoSizeWidth = cfg.video_width;
                source.VideoSizeHeight = cfg.video_height;
                source.VideoQuality = cfg.video_quality;

                return (VsICoreProvider)source;
            }
            return null;
        }
    }


	/// <summary>
	/// RtpStreamDescription
	/// </summary>
    public class RtpStream4Description : VsICoreProviderDescription
    {
        // Name property
        public string Name
        {
            get { return "Rtp Stream #4"; }
        }

        // Description property
        public string Description
        {
            get { return "Downloads video from video rtp streaming servers"; }
        }

        // Return settings page
        public VsICoreProviderPage GetSettingsPage()
        {
            return new RtpStreamSetupPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("dest", cfg.dest);
                writer.WriteAttributeString("ssrc", cfg.ssrc);
                writer.WriteAttributeString("video_port", cfg.video_port.ToString());
                writer.WriteAttributeString("audio_port", cfg.video_port.ToString());
                writer.WriteAttributeString("video_codec", cfg.video_codec);
                writer.WriteAttributeString("audio_codec", cfg.audio_codec);
                writer.WriteAttributeString("video_width", cfg.video_width.ToString());
                writer.WriteAttributeString("video_height", cfg.video_height.ToString());
                writer.WriteAttributeString("video_quality", cfg.video_quality.ToString());
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
                config.dest = reader.GetAttribute("dest");
                config.ssrc = reader.GetAttribute("ssrc");
                config.video_port = int.Parse(reader.GetAttribute("video_port"));
                config.audio_port = int.Parse(reader.GetAttribute("audio_port"));
                config.video_codec = reader.GetAttribute("video_codec");
                config.audio_codec = reader.GetAttribute("audio_codec");
                config.video_width = int.Parse(reader.GetAttribute("video_width"));
                config.video_height = int.Parse(reader.GetAttribute("video_height"));
                config.video_quality = int.Parse(reader.GetAttribute("video_quality"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.dest = (string)reader["dest"];
                config.ssrc = (string)reader["ssrc"];
                config.video_port = (int)reader["video_port"];
                config.audio_port = (int)reader["audio_port"];
                config.video_codec = (string)reader["video_codec"];
                config.audio_codec = (string)reader["audio_codec"];
                config.video_width = (int)reader["video_width"];
                config.video_height = (int)reader["video_height"];
                config.video_quality = (int)reader["video_quality"];
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Create video source object
        public VsICoreProvider CreateVideoSource(object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                RtpStream4 source = new RtpStream4();

                source.VideoSource = cfg.source;
                source.VideoDest = cfg.dest;
                source.SSRC = cfg.ssrc;
                source.VideoPort = cfg.video_port;
                source.AudioPort = cfg.audio_port;
                source.VideoCodec = cfg.video_codec;
                source.AudioCodec = cfg.audio_codec;
                source.VideoSizeWidth = cfg.video_width;
                source.VideoSizeHeight = cfg.video_height;
                source.VideoQuality = cfg.video_quality;

                return (VsICoreProvider)source;
            }
            return null;
        }
    }

	/// <summary>
	/// RtpStreamDescription
	/// </summary>
    public class RtpStream5Description : VsICoreProviderDescription
    {
        // Name property
        public string Name
        {
            get { return "Rtp Stream #5"; }
        }

        // Description property
        public string Description
        {
            get { return "Downloads video from video rtp streaming servers"; }
        }

        // Return settings page
        public VsICoreProviderPage GetSettingsPage()
        {
            return new RtpStreamSetupPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("dest", cfg.dest);
                writer.WriteAttributeString("ssrc", cfg.ssrc);
                writer.WriteAttributeString("video_port", cfg.video_port.ToString());
                writer.WriteAttributeString("audio_port", cfg.video_port.ToString());
                writer.WriteAttributeString("video_codec", cfg.video_codec);
                writer.WriteAttributeString("audio_codec", cfg.audio_codec);
                writer.WriteAttributeString("video_width", cfg.video_width.ToString());
                writer.WriteAttributeString("video_height", cfg.video_height.ToString());
                writer.WriteAttributeString("video_quality", cfg.video_quality.ToString());
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = reader.GetAttribute("source");
                config.dest = reader.GetAttribute("dest");
                config.ssrc = reader.GetAttribute("ssrc");
                config.video_port = int.Parse(reader.GetAttribute("video_port"));
                config.audio_port = int.Parse(reader.GetAttribute("audio_port"));
                config.video_codec = reader.GetAttribute("video_codec");
                config.audio_codec = reader.GetAttribute("audio_codec");
                config.video_width = int.Parse(reader.GetAttribute("video_width"));
                config.video_height = int.Parse(reader.GetAttribute("video_height"));
                config.video_quality = int.Parse(reader.GetAttribute("video_quality"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Load configuration
        public object LoadConfiguration(Hashtable reader)
        {
            RtpStreamConfiguration config = new RtpStreamConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.dest = (string)reader["dest"];
                config.ssrc = (string)reader["ssrc"];
                config.video_port = (int)reader["video_port"];
                config.audio_port = (int)reader["audio_port"];
                config.video_codec = (string)reader["video_codec"];
                config.audio_codec = (string)reader["audio_codec"];
                config.video_width = (int)reader["video_width"];
                config.video_height = (int)reader["video_height"];
                config.video_quality = (int)reader["video_quality"];
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Create video source object
        public VsICoreProvider CreateVideoSource(object config)
        {
            RtpStreamConfiguration cfg = (RtpStreamConfiguration)config;

            if (cfg != null)
            {
                RtpStream5 source = new RtpStream5();

                source.VideoSource = cfg.source;
                source.VideoDest = cfg.dest;
                source.SSRC = cfg.ssrc;
                source.VideoPort = cfg.video_port;
                source.AudioPort = cfg.audio_port;
                source.VideoCodec = cfg.video_codec;
                source.AudioCodec = cfg.audio_codec;
                source.VideoSizeWidth = cfg.video_width;
                source.VideoSizeHeight = cfg.video_height;
                source.VideoQuality = cfg.video_quality;

                return (VsICoreProvider)source;
            }
            return null;
        }
    }
}
