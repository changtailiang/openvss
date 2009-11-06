using System;
using System.Text;
using System.Globalization;
using System.Collections;
using Microsoft.Win32;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for Win32RegistryUtility.
	/// </summary>
	public sealed class Win32RegistryUtility
	{
		private Win32RegistryUtility() {}
		
		#region Is.. ()
		public static bool  IsExists (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			RegistryKey oKey		= registryKey.OpenSubKey (key);
			if (oKey != null)
			{
				oKey.Close ();
				return true;
			}
			return false;
		}

		public static bool  IsExists (RegistryKey registryKey, string key, string subKey)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			bool		bResult		= false;
			RegistryKey oKey		= registryKey.OpenSubKey (key);
			if (oKey != null)
			{
				if (oKey.GetValue (subKey) != null)
					bResult = true;
				oKey.Close ();
			}
			return bResult;
		}

		public static bool IsEmpty (RegistryKey registryKey, string key)
		{
			if (Count (registryKey, key) == 0)
				return true;
			return false;
		}
		#endregion

		public static int  Count (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			int			iCount;
			RegistryKey oKey		= registryKey.OpenSubKey (key);
			if (oKey != null)
			{
				iCount = oKey.SubKeyCount + oKey.ValueCount;
				//string[]	aszKeys		= oKey.GetSubKeyNames ();
				//string[]	aszValues	= oKey.GetValueNames ();
				oKey.Close ();
				//iCount = aszKeys.Length + aszValues.Length;
			}
			else
			{
				iCount = 0;
			}
			
			return iCount;
		}

		public static bool EmptyKey (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			int			i;
			bool		bResult		= false;
			RegistryKey oKey		= registryKey.OpenSubKey (key, true);

			if (oKey != null)
			{
				// Clear keys
				string[]	aszKeys		= oKey.GetSubKeyNames ();
				for (i = 0; i < aszKeys.Length; i++)
				{
					oKey.DeleteSubKeyTree (aszKeys[i]);
				}

				// Clear values
				string[]	aszValues	= oKey.GetValueNames ();
				for (i = 0; i < aszValues.Length; i++)
				{
					oKey.DeleteValue (aszValues[i]);
				}

				oKey.Close ();
				bResult = true;
			}
			return bResult;
		}

		public static bool DeleteKey (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			bool bResult = false;

			if (registryKey != null)
			{
				registryKey.DeleteSubKey (key);
				bResult = !Win32RegistryUtility.IsExists (registryKey, key);
			}
			return bResult;
		}

		/// <summary>
		/// Delete a key (Folder) in registry only
		/// </summary>
		/// <param name="registryKey"></param>
		/// <param name="key"></param>
		/// <param name="subKey"></param>
		public static void DeleteKey (RegistryKey registryKey, string key, string subKey)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			RegistryKey oKey = registryKey.OpenSubKey (key, true);

			if (oKey != null)
			{
				//string []asz1 = oKey.GetValueNames ();
				//string []asz2 = oKey.GetSubKeyNames ();

				oKey.DeleteSubKey (subKey, true);
				oKey.Close ();
			}
		}

		/// <summary>
		/// Delete an entry (File) in registry only
		/// </summary>
		/// <param name="registryKey"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void DeleteValue (RegistryKey registryKey, string key, string value)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			RegistryKey oKey = registryKey.OpenSubKey (key, true);

			if (oKey != null)
			{
				oKey.DeleteValue (value, true);
				oKey.Close ();
			}
		}

		#region GET()
		public static string[]  GetSubkeys (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			string[]	aszValues;
			RegistryKey oKey		= registryKey.OpenSubKey (key);
			if (oKey != null)
			{
				aszValues	= oKey.GetSubKeyNames ();
				oKey.Close ();
			}
			else
			{
				aszValues	= new string [0];
			}
			
			return aszValues;
		}

		public static string[]  GetValueNames (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			string[]	aszValuesName;
			RegistryKey oKey		= registryKey.OpenSubKey (key);
			if (oKey != null)
			{
				aszValuesName	= oKey.GetValueNames ();
				oKey.Close ();
			}
			else
			{
				aszValuesName	= new string [0];
			}
			return aszValuesName;
		}

		public static string[]  GetValues (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			string[]	aszValues, aszValuesName;
			RegistryKey oKey		= registryKey.OpenSubKey (key);
			if (oKey != null)
			{
				aszValuesName	= oKey.GetValueNames ();
				aszValues		= new string [aszValuesName.Length];
				for (int i = 0 ; i < aszValuesName.Length; i++)
				{
					aszValues [i]	= Win32RegistryUtility.GetValue (registryKey, key, aszValuesName[i], "");
				}
				oKey.Close ();
			}
			else
			{
				aszValues	= new string [0];
			}
			
			return aszValues;
		}


		public static int GetValue (RegistryKey registryKey, string key, string subKey, int defaultValue)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			int			iResult;
			RegistryKey oKey = registryKey.OpenSubKey (key);

			if (oKey != null)
			{
				//iResult = (int)oKey.GetValue (subKey, defaultValue);
				iResult = Int32.Parse ((string)oKey.GetValue (subKey, defaultValue), CultureInfo.InvariantCulture);
				oKey.Close ();
			}
			else
			{
				iResult = defaultValue;
			}
			return iResult;
		}

		public static void GetValueExtend (RegistryKey registryKey, string key, string subKey, ref string result, ref string []resultArray)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			string		szDefault	= StringUtility.CreateEmptyString ();
			RegistryKey oKey		= registryKey.OpenSubKey (key);

			// Init default values
			if (result != null)
				result = StringUtility.CreateEmptyString ();
			if (resultArray != null)
				resultArray = null;

			// Test key opened
			if (oKey != null)
			{
				object oResult = oKey.GetValue (subKey, szDefault);
				if (oResult != null)
				{
					Type oType = oResult.GetType ();
					if (oType.FullName == "System.Byte[]")
					{
						Byte[] oaBytes = (Byte[])oKey.GetValue (subKey, szDefault);
						
						if (result != null)
						{
							result = System.Text.Encoding.ASCII.GetString (oaBytes);
						}
					}
					else if (oType.FullName == "System.String[]")
					{
						resultArray = (string[])oKey.GetValue (subKey, szDefault);
					}
					else
					{
						if (result != null)
						{
							result = oResult.ToString ();
						}
					}
				}
				oKey.Close ();
			}
		}

		public static string GetValue (RegistryKey registryKey, string key, string subKey, string defaultValue)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			string		szResult;
			RegistryKey oKey		= registryKey.OpenSubKey (key);

			// Set default return value
			szResult = defaultValue;

			// Test key opened
			if (oKey != null)
			{
				//szResult = (string)oKey.GetValue (subKey);
				//szResult = oKey.GetValue (subKey, defaultValue).ToString ();
				object oResult = oKey.GetValue (subKey, defaultValue);
				if (oResult != null)
				{
					Type oType = oResult.GetType ();
					if (oType.FullName == "System.Byte[]")
					{
						Byte[] oaBytes = (Byte[])oKey.GetValue (subKey, defaultValue);
						//szResult = System.Text.Encoding.Default.GetString (oaBytes);
						szResult = System.Text.Encoding.ASCII.GetString (oaBytes);
					}
					else if (oType.FullName == "System.String[]")
					{
						StringBuilder sb = new StringBuilder ();
						string		[]aszResult = (string[])oKey.GetValue (subKey, defaultValue);
						for (int i = 0; i < aszResult.Length; i++)
						{
							if (i != 0)
								sb.Append (' ');
							sb.Append (aszResult[i]);
						}
						szResult = sb.ToString ();
					}
					else
					{
						// "System.String"
						szResult = oResult.ToString ();
					}
				}
				oKey.Close ();
			}
			return szResult;
		}
		#endregion

		#region SET & Write()
		public static bool SetValue (RegistryKey registryKey, string key, string subKey, int valueToSet)
		{
			return Win32RegistryUtility.SetValue (registryKey, key, subKey, valueToSet.ToString (CultureInfo.InvariantCulture));
		}

		public static bool SetValue (RegistryKey registryKey, string key, string subKey, string valueToSet)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			bool		bResult	= false;
			RegistryKey oKey	= registryKey.OpenSubKey (key, true);

			if (oKey != null)
			{
				oKey.SetValue (subKey, valueToSet);
				oKey.Close ();
				bResult = true;
			}
			return bResult;
		}

		public static bool WriteKey (RegistryKey registryKey, string key)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			registryKey.CreateSubKey (key);
			return true;
			/*
			string		[]aszPath = glcStringUtility.GetWordArray (key, '\\');
			bool		bResult	= false;

			
			RegistryKey oKey	= registryKey.OpenSubKey (key, true);

			if (oKey != null)
			{
				oKey.SetValue (subKey, value);
				oKey.Close ();
				bResult = true;
			}
			return bResult;
			*/
		}
		#endregion

	
		#region string convertion
		static public string ConvertToShortName (RegistryKey registryKey)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			if (registryKey == Registry.CurrentUser)		return string.Format (CultureInfo.InstalledUICulture, "HKCU");
			if (registryKey == Registry.LocalMachine)		return string.Format (CultureInfo.InstalledUICulture, "HKLM");
			if (registryKey == Registry.PerformanceData)	return string.Format (CultureInfo.InstalledUICulture, "HKPD");
			if (registryKey == Registry.ClassesRoot)		return string.Format (CultureInfo.InstalledUICulture, "HKCR");
			if (registryKey == Registry.CurrentConfig)		return string.Format (CultureInfo.InstalledUICulture, "HKCC");
			if (registryKey == Registry.DynData)			return string.Format (CultureInfo.InstalledUICulture, "HKDD");
			if (registryKey == Registry.Users)				return string.Format (CultureInfo.InstalledUICulture, "HKUS");
			else											return string.Format (CultureInfo.InstalledUICulture, "HK__");
		}

		static public RegistryKey ConvertShortNameToObject (string registryShortName)
		{
			if (string.Compare (registryShortName, "HKCU", true, CultureInfo.InstalledUICulture) == 0)		return Registry.CurrentUser;
			if (string.Compare (registryShortName, "HKLM", true, CultureInfo.InstalledUICulture) == 0)		return Registry.LocalMachine;
			if (string.Compare (registryShortName, "HKPD", true, CultureInfo.InstalledUICulture) == 0)		return Registry.PerformanceData;
			if (string.Compare (registryShortName, "HKCR", true, CultureInfo.InstalledUICulture) == 0)		return Registry.ClassesRoot;
			if (string.Compare (registryShortName, "HKCC", true, CultureInfo.InstalledUICulture) == 0)		return Registry.CurrentConfig;
			if (string.Compare (registryShortName, "HKDD", true, CultureInfo.InstalledUICulture) == 0)		return Registry.DynData;
			if (string.Compare (registryShortName, "HKUS", true, CultureInfo.InstalledUICulture) == 0)		return Registry.Users;
			else																							return Registry.Users;
		}

		static public string ConvertToStdName (RegistryKey registryKey)
		{
			if (registryKey == null)		throw new NolmeArgumentNullException ();

			if (registryKey == Registry.CurrentUser)		return string.Format (CultureInfo.InstalledUICulture, "HKEY_CURRENT_USER");
			if (registryKey == Registry.LocalMachine)		return string.Format (CultureInfo.InstalledUICulture, "HKEY_LOCAL_MACHINE");
			if (registryKey == Registry.PerformanceData)	return string.Format (CultureInfo.InstalledUICulture, "HKEY_PERFORMANCE_DATA");
			if (registryKey == Registry.ClassesRoot)		return string.Format (CultureInfo.InstalledUICulture, "HKEY_CLASSES_ROOT");
			if (registryKey == Registry.CurrentConfig)		return string.Format (CultureInfo.InstalledUICulture, "HKEY_CURRENT_CONFIG");
			if (registryKey == Registry.DynData)			return string.Format (CultureInfo.InstalledUICulture, "HKEY_DYN_DATA");
			if (registryKey == Registry.Users)				return string.Format (CultureInfo.InstalledUICulture, "HKEY_USERS");
			else											return string.Format (CultureInfo.InstalledUICulture, "HK__");
		}

		static public RegistryKey ConvertStdNameToObject (string registryShortName)
		{
			if (string.Compare (registryShortName, "HKEY_CURRENT_USER"		, true, CultureInfo.InstalledUICulture) == 0)	return Registry.CurrentUser;
			if (string.Compare (registryShortName, "HKEY_LOCAL_MACHINE"		, true, CultureInfo.InstalledUICulture) == 0)	return Registry.LocalMachine;
			if (string.Compare (registryShortName, "HKEY_PERFORMANCE_DATA"	, true, CultureInfo.InstalledUICulture) == 0)	return Registry.PerformanceData;
			if (string.Compare (registryShortName, "HKEY_CLASSES_ROOT"		, true, CultureInfo.InstalledUICulture) == 0)	return Registry.ClassesRoot;
			if (string.Compare (registryShortName, "HKEY_CURRENT_CONFIG"	, true, CultureInfo.InstalledUICulture) == 0)	return Registry.CurrentConfig;
			if (string.Compare (registryShortName, "HKEY_DYN_DATA"			, true, CultureInfo.InstalledUICulture) == 0)	return Registry.DynData;
			if (string.Compare (registryShortName, "HKEY_USERS"				, true, CultureInfo.InstalledUICulture) == 0)	return Registry.Users;
			else																											return Registry.Users;
		}
		#endregion
	}
}
