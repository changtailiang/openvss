using System;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for Win32Utility.
	/// </summary>
	public sealed class Win32Utility
	{
		private Win32Utility () { }

		public static void OpenFolder (string path)
		{
			System.Diagnostics.Process.Start("explorer.exe", path);
		}

		public static void LaunchDefaultWebExplorer (System.Uri url)
		{
			if (url == null)	throw new NolmeArgumentNullException ();

			// Get WebBrowser directory & filename
			RegistryKey oKey = Registry.ClassesRoot.OpenSubKey ("http\\shell\\open\\command");
			string szResult = (string)oKey.GetValue ("");
			string[] aszParams = StringUtility.GetWordArray2 (szResult);

			System.Diagnostics.Process.Start(aszParams[0], url.ToString());
		}

		public static void LaunchDefaultMail (string sendMailto)
		{
			// Get WebBrowser directory & filename
			RegistryKey oKey = Registry.ClassesRoot.OpenSubKey ("mailto\\shell\\open\\command");
			string szResult = (string)oKey.GetValue ("");
			string[] aszParams = StringUtility.GetWordArray2 (szResult);

			string szDst = String.Format (CultureInfo.InvariantCulture, "/mailurl:mailto:{0}?subject=Question requested&Body=Type your question here", sendMailto);
			System.Diagnostics.Process.Start(aszParams[0], szDst);
		}

		/// <summary>
		/// Definive environment value in registry
		/// </summary>
		/// <param name="variable">Variable to modify</param>
		/// <param name="valueToSet">Value toset for variable</param>
		public static void SetEnvironmentVariable (string variable, string valueToSet)
		{
			RegistryKey oKey = Registry.LocalMachine.OpenSubKey ("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment", true);
			oKey.SetValue (variable, valueToSet);
		}

		/// <summary>
		/// Get environment variable that is stored in REGISTRY
		/// WARNING : Result may be different from Environment.GetEnvironmentVariable()
		/// which contain variable loaded in memory, not the stored one
		/// </summary>
		/// <param name="variable">Variable name to retrieve</param>
		/// <returns></returns>
		public static string GetEnvironmentVariable (string variable)
		{
			RegistryKey oKey	= Registry.LocalMachine.OpenSubKey ("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment");
			string		szValue	= (string)oKey.GetValue (variable);
			return szValue;
		}
	}
}
