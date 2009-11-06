using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for OperatingSystem.
	/// </summary>
	public class WindowsOperatingSystem
	{
		// Win95 & 3.1, 3.11 not supported by .NET framework
		private byte		m_Windows98;
		private byte		m_WindowsMe;
		private byte		m_WindowsNT351;
		private byte		m_WindowsNT4;
		private byte		m_Windows2000;
		private byte		m_WindowsXP;
		private byte		m_WindowsDotNet;
		private byte		m_Server;

		public WindowsOperatingSystem ()
		{
			this.Update ();
		}

		#region Properties
		public bool		Windows98
		{
			get { return System.Convert.ToBoolean (m_Windows98); }
		}
		public bool		WindowsMe
		{
			get { return System.Convert.ToBoolean (m_WindowsMe); }
		}
		public bool		WindowsNT351
		{
			get { return System.Convert.ToBoolean (m_WindowsNT351); }
		}
		public bool		WindowsNT4
		{
			get { return System.Convert.ToBoolean (m_WindowsNT4); }
		}
		public bool		Windows2000
		{
			get { return System.Convert.ToBoolean (m_Windows2000); }
		}
		public bool		WindowsXP
		{
			get { return System.Convert.ToBoolean (m_WindowsXP); }
		}
		public bool		WindowsDotNet
		{
			get { return System.Convert.ToBoolean (m_WindowsDotNet); }
		}
		public bool		Server
		{
			get { return System.Convert.ToBoolean (m_Server); }
		}

		#endregion

		public void Reset ()
		{
			m_Windows98			= 0;
			m_WindowsMe			= 0;
			m_WindowsNT351		= 0;
			m_WindowsNT4		= 0;
			m_Windows2000		= 0;
			m_WindowsXP			= 0;
			m_WindowsDotNet		= 0;
			m_Server			= 0;
		}

		public void Update ()
		{
			Reset ();

			Version oCurrentVersion = Environment.OSVersion.Version ;
			switch (oCurrentVersion.Major)
			{
			default:
				break;

			case 3:			// NT3.51
				// (m_OVI.dwMinorVersion == 51
				m_WindowsNT351 = 1;
				break;

			case 4:
				switch (oCurrentVersion.Minor)
				{
				default:
					// Unknown
					break;

				case 0:		// Windows 95 & NT
					m_WindowsNT4 = 1;
					break;

				case 10:	// Windows 98
					m_Windows98 = 1;
					break;

				case 90:	// Windows Me
					m_WindowsMe = 1;
					break;
				}
				break;

			case 5:			// 2000/XP/.NET SERVER
				switch (oCurrentVersion.Minor)
				{
				default:
					// Unknown
					break;

				case 0:	// 2000
					m_Windows2000 = 1;
					break;

				case 1:	// XP
					m_WindowsXP = 1;
					break;

				case 2:	// .NET Server
					m_WindowsDotNet = 1;
					break;
				}
				break;
			}

			// Get server or Workstation
			//System.Environment.OSVersion.
			/*
			OperatingSystemVersionExtended os = new OperatingSystemVersionExtended();
			ApiNativeMethods.GetVersionEx(ref os);
			if (os.Reserved1 == 7682) //VER_NT_SERVER:
				m_Server = 1;
			else if (os.Reserved1 == 7683) //VER_NT_DOMAIN_CONTROLLER: VALEUR A TESTER
				m_Server = 1;
				*/
		}

		static public Version Version
		{
			get 
			{
				Version oCurrentVersion = Environment.OSVersion.Version;
				return oCurrentVersion;
			}
		}

		//[SecurityPermissionAttribute(SecurityAction.LinkDemand, Assertion=true)]
		internal static string ComputeServicePack ()
		{
			//System.Environment.OSVersion.Version;
			return string.Format (CultureInfo.InvariantCulture, "Check ComputeServicePack()");
			
			//OperatingSystemVersionExtended os = new OperatingSystemVersionExtended();
			
			//SecurityPermissionAttribute envPermission = new SecurityPermissionAttribute(SecurityAction.LinkDemand);

			/*os.OSVersionInfoSize = Marshal.SizeOf(typeof (OperatingSystemVersionExtended));
			ApiNativeMethods.GetVersionEx(ref os);
			if (os.AdditionalText == StringUtility.CreateEmptyString ())
				return string.Format (CultureInfo.InvariantCulture, "No Service Pack");
			else
				return os.AdditionalText;
				*/
		}

		public static string ServicePack
		{
			get { return ComputeServicePack (); }
		}

		override public string ToString ()
		{
			Version oCurrentVersion = Environment.OSVersion.Version;
			string	szOs, szSrvWk, szBuffer;

			if		(this.Windows98)		szOs = string.Format (CultureInfo.InvariantCulture, "98");
			else if (this.WindowsMe)		szOs = string.Format (CultureInfo.InvariantCulture, "Me");
			else if (this.WindowsNT351)		szOs = string.Format (CultureInfo.InvariantCulture, "NT 3.51");
			else if (this.WindowsNT4)		szOs = string.Format (CultureInfo.InvariantCulture, "NT 4");
			else if (this.Windows2000)		szOs = string.Format (CultureInfo.InvariantCulture, "2000");
			else if (this.WindowsXP)		szOs = string.Format (CultureInfo.InvariantCulture, "XP");
			else if (this.WindowsDotNet)	szOs = string.Format (CultureInfo.InvariantCulture, ".NET");
			else							szOs = string.Format (CultureInfo.InvariantCulture, "Unknown");

			if (this.Server)				szSrvWk = string.Format (CultureInfo.InvariantCulture, "Server");
			else							szSrvWk = string.Format (CultureInfo.InvariantCulture, "Workstation");

			szBuffer = String.Format (CultureInfo.InvariantCulture, "Microsoft Windows {0} {1} - {2} - {3}.{4}.{5}.{6}", szOs, szSrvWk, WindowsOperatingSystem.ServicePack, oCurrentVersion.Major, oCurrentVersion.Minor, oCurrentVersion.Build, oCurrentVersion.Revision);
			return szBuffer;
		}
	};
}
