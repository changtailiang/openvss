// ugns	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xkca	
// uaqj	 By downloading, copying, installing or using the software you agree to this license.
// fdns	 If you do not agree to this license, do not download, install,
// hqbx	 copy or use the software.
// yarp	
// havu	                          License Agreement
// docf	         For OpenVss - Open Source Video Surveillance System
// zvep	
// ecok	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wjod	
// adgl	Third party copyrights are property of their respective owners.
// rcek	
// ptqt	Redistribution and use in source and binary forms, with or without modification,
// pxkx	are permitted provided that the following conditions are met:
// ohwg	
// ylkj	  * Redistribution's of source code must retain the above copyright notice,
// zynf	    this list of conditions and the following disclaimer.
// brap	
// lnpd	  * Redistribution's in binary form must reproduce the above copyright notice,
// tjca	    this list of conditions and the following disclaimer in the documentation
// jspf	    and/or other materials provided with the distribution.
// fkzh	
// rrvo	  * Neither the name of the copyright holders nor the names of its contributors 
// mifp	    may not be used to endorse or promote products derived from this software 
// swmt	    without specific prior written permission.
// oziy	
// tbib	This software is provided by the copyright holders and contributors "as is" and
// igdf	any express or implied warranties, including, but not limited to, the implied
// fvwf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vfep	In no event shall the Prince of Songkla University or contributors be liable 
// ygnk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vlcd	(including, but not limited to, procurement of substitute goods or services;
// ialw	loss of use, data, or profits; or business interruption) however caused
// xjmk	and on any theory of liability, whether in contract, strict liability,
// jrld	or tort (including negligence or otherwise) arising in any way out of
// cyyk	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Axis
{
	using System;
	using System.Xml;
    using System.Collections;
    using Vs.Core.Provider;

	/// <summary>
	/// Axis2460Description
	/// </summary>
	public class Axis2460Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2460 Network DVR"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2460 network digital video recorder"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2460SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("camera", cfg.camera.ToString());
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.camera	= short.Parse(reader.GetAttribute("camera"));
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.camera = short.Parse((string)reader["camera"]);
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2460 source = new Axis2460();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;                
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Camera		= cfg.camera;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// Axis2100Description
	/// </summary>
	public class Axis2100Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2100 network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2100 network camera"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2100SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2100 source = new Axis2100();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// Axis2110Description
	/// </summary>
	public class Axis2110Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2110 network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2110 network camera"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2110SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2110 source = new Axis2110();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}

	
	/// <summary>
	/// Axis2120Description
	/// </summary>
	public class Axis2120Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2120 network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2120 network camera"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2120SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2120 source = new Axis2120();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}

	
	/// <summary>
	/// Axis2130RDescription
	/// </summary>
	public class Axis2130RDescription : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2130/2130R network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2130 network camera"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2130RSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2130R source = new Axis2130R();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// Axis205Description
	/// </summary>
	public class Axis205Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 205 network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 205 network camera"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis205SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis205 source = new Axis205();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// Axis206Description
	/// </summary>
	public class Axis206Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 206 network camera"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 206 network camera"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis206SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("size", cfg.resolution);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.resolution = reader.GetAttribute("size");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.resolution = (string)reader["size"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis206 source = new Axis206();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Resolution	= cfg.resolution;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// Axis2400Description
	/// </summary>
	public class Axis2400Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2400+ video server"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2400+ video server"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2400SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("camera", cfg.camera.ToString());
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.camera	= short.Parse(reader.GetAttribute("camera"));
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.camera = short.Parse((string)reader["camera"]);
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2400 source = new Axis2400();

				source.StreamType	= cfg.stremType;
				source.VideoSource	= cfg.source;
				source.Login		= cfg.login;
				source.Password		= cfg.password;
				source.Camera		= cfg.camera;
				source.FrameInterval = cfg.frameInterval;

				return (VsICoreProvider) source;
			}
			return null;
		}
	}


	/// <summary>
	/// Axis2401Description
	/// </summary>
	public class Axis2401Description : VsICoreProviderDescription
	{
		// Name property
		public string Name
		{
			get { return "Axis 2401+ video server"; }
		}

		// Description property
		public string Description
		{
			get { return "Provides access to Axis 2401+ video server"; }
		}

		// Return settings page
		public VsICoreProviderPage GetSettingsPage()
		{
			return new Axis2401SetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			AxisConfiguration cfg = (AxisConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
				writer.WriteAttributeString("login", cfg.login);
				writer.WriteAttributeString("password", cfg.password);
				writer.WriteAttributeString("stype", ((int) cfg.stremType).ToString());
				writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			AxisConfiguration	config = new AxisConfiguration();

			try
			{
				config.source	= reader.GetAttribute("source");
				config.login	= reader.GetAttribute("login");
				config.password	= reader.GetAttribute("password");
				config.stremType = (StreamType) (int.Parse(reader.GetAttribute("stype")));
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
            AxisConfiguration config = new AxisConfiguration();

            try
            {
                config.source = (string)reader["source"];
                config.login = (string)reader["login"];
                config.password = (string)reader["password"];
                config.stremType = (StreamType)(int.Parse((string)reader["stype"]));
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
			AxisConfiguration cfg = (AxisConfiguration) config;
			
			if (cfg != null)
			{
				Axis2401 source = new Axis2401();

				source.StreamType	= cfg.stremType;
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
