using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;	// for DllImport, MarshalAs, etc

using System.Security;
using System.Security.Permissions;

namespace Nolme.Win32
{
	#region Delegate
	public delegate Int32 BrowseCallbackProc(IntPtr windowHandle, UInt32 messageId, Int32 generic32BitsParameter, Int32 generic32BitsDataParameter);
	#endregion

	/// <summary>
	/// Summary description for Win32ShellApiUtility.
	/// </summary>
	public sealed class Win32ShellApiUtility
	{
		private Win32ShellApiUtility() {}
		
		public static void EmptyRecycleBin (IntPtr hwndOwner)
		{
			ShellApiNativeMethods.SHEmptyRecycleBin ((int)hwndOwner, null, SHERB.SHERB_NOCONFIRMATION | SHERB.SHERB_NOSOUND);
		}

		internal static Int64 ComputeRecycleBinSize (string path)
		{
			//Int32 hResult;
			ShellQueryRecycledBinInformationStructure oQueryInfo = new ShellQueryRecycledBinInformationStructure(false);

			/*hResult = */ShellApiNativeMethods.SHQueryRecycleBin (path, ref oQueryInfo);
			// Using a path like @"C:\" doesn't work :( but works in C++
			//hResult = ApiNativeMethods.SHQueryRecycleBin (@"C:\", ref oQueryInfo);

			return oQueryInfo.SizeOn64Bits;
		}

		public static Int64 GetRecycleBinSize (string path)
		{
			return Win32ShellApiUtility.ComputeRecycleBinSize (path);
		}

		[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
		public static Icon GetIcon(string path, bool selected)
		{
			ShellFileInformationStructure info = new ShellFileInformationStructure(true);
			int cbFileInfo = Marshal.SizeOf(info);
			SHGFI flags;
			if (!selected)
				flags = SHGFI.SHGFI_ICON | SHGFI.SHGFI_SMALLICON;
			else
				flags = SHGFI.SHGFI_ICON | SHGFI.SHGFI_SMALLICON | SHGFI.SHGFI_OPENICON;

			ShellApiNativeMethods.SHGetFileInfo (path, 256, out info,(uint)cbFileInfo, flags);
			return Icon.FromHandle(info.IconHandle);
		}
	}
}

/*
		public static Icon GetDesktopIcon()
		{
			IntPtr[] handlesIconLarge = new IntPtr[1];
			IntPtr[] handlesIconSmall = new IntPtr[1];
			uint i = ExtractIconEx(Environment.SystemDirectory + "\\shell32.dll", 34, handlesIconLarge, handlesIconSmall, 1);

			return Icon.FromHandle(handlesIconSmall[0]);
		}*/