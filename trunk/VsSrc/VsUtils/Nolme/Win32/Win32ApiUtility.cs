using System;
using System.Text;						// StringBuilder
using System.Collections;				// ArrayList
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;	// for DllImport, MarshalAs, etc
using System.Drawing;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for ShutdownLogOffUtility.
	/// </summary>
	public sealed class ShutdownLogOffUtility
	{
		private ShutdownLogOffUtility() {}

		internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
		internal const int TOKEN_QUERY = 0x00000008;
		internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
		internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

		#region Windows shutdown & loggoff
		public static void Shutdown() 
		{
			Shutdown(ShutdownReason.FlagPlanned);
		}

		public static void Shutdown(ShutdownReason reasonFlag)
		{
			int			Result;
			bool		BooleanResult;
			TokenPrivileges	tp	= new TokenPrivileges ();
			long			LocallyUniqueIdentifier;

			IntPtr hproc	= (IntPtr)ApiNativeMethods.GetCurrentProcess();
			int		htok	= 0;

			BooleanResult	= ApiNativeMethods.OpenProcessToken( (int)hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok );
			if( BooleanResult == false)
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "OpenProcessToken Failed"));

			tp.Count					= 1;
			tp.LocallyUniqueIdentifier	= 0;
			tp.Attributes				= SE_PRIVILEGE_ENABLED;
			LocallyUniqueIdentifier		= 0;
			BooleanResult				= ApiNativeMethods.LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref LocallyUniqueIdentifier);
			if( BooleanResult == false)
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "LookupPrivilegeValue Failed"));

			tp.LocallyUniqueIdentifier	= LocallyUniqueIdentifier;
			BooleanResult	= ApiNativeMethods.AdjustTokenPrivileges( htok, false, ref tp, 0, 0, 0);
			if( BooleanResult == false)
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "AdjustTokenPrivileges Failed"));

			Result = User32ApiNativeMethods.ExitWindowsEx(ExitWindows.PowerOff | ExitWindows.Shutdown, reasonFlag);
			if( Result == 0)
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "Shutdown Failed"));
		}

		public static void LogOff()
		{
			LogOff(ShutdownReason.FlagPlanned);
		}

		public static void LogOff(ShutdownReason reasonFlag) 
		{
			int Result;
			Result = User32ApiNativeMethods.ExitWindowsEx(ExitWindows.LogOff, reasonFlag);
			if( Result == 0)
			{
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "LogOff Failed"));
			}
		}
		#endregion
	};

	/// <summary>
	/// Summary description for DiskSpace.
	/// </summary>
	public class DiskSpace
	{
		private uint m_SectorsPerCluster;
		private uint m_BytesPerSector;
		private uint m_NumberOfFreeClusters;
		private uint m_TotalNumberOfClusters;
		private long m_FreeBytes;
		private long m_TotalBytes;

		public uint SectorsPerCluster
		{
			get { return m_SectorsPerCluster; }
			set { m_SectorsPerCluster = value; }
		}
		public uint BytesPerSector
		{
			get { return m_BytesPerSector; }
			set { m_BytesPerSector = value; }
		}
		public uint NumberOfFreeClusters
		{
			get { return m_NumberOfFreeClusters; }
			set { m_NumberOfFreeClusters = value; }
		}
		public uint TotalNumberOfClusters
		{
			get { return m_TotalNumberOfClusters; }
			set { m_TotalNumberOfClusters = value; }
		}
		public long FreeBytes
		{
			get { return m_FreeBytes; }
			set { m_FreeBytes = value; }
		}
		public long TotalBytes
		{
			get { return m_TotalBytes; }
			set { m_TotalBytes = value; }
		}
	};

	
	/// <summary>
	/// Object used to control a Windows Form.
	/// </summary>
	public class Window
	{
		private IntPtr m_WindowHandle;
		private string m_Title;
		private string m_Process;

		/// <summary>
		/// Window Object's Public Properties
		/// </summary>
		public IntPtr WindowHandle
		{
			get{return m_WindowHandle;}
		}
		public string Title
		{
			get{return m_Title;}
		}
		public string Process
		{
			get{return m_Process;}
		}

		/// <summary>
		/// Constructs a Window Object
		/// </summary>
		/// <param name="Title">Title Caption</param>
		/// <param name="windowHandle">Handle</param>
		/// <param name="Process">Owning Process</param>
		public Window(string title, IntPtr windowHandle, string process)
		{
			m_Title			= title;
			m_WindowHandle	= windowHandle;
			m_Process		= process;
		}
	}


	/// <summary>
	/// Summary description for Win32ApiUtility.
	/// </summary>
	public sealed class Win32ApiUtility
	{
		static private ArrayList m_aoWndArray;

		private Win32ApiUtility() {}

		public static void ClearApplicationEventLog ()
		{
			int iHandle = ApiNativeMethods.OpenEventLogA (null, "Application");
			ApiNativeMethods.ClearEventLogA (iHandle, null);
			ApiNativeMethods.CloseEventLog (iHandle);
		}

		public static void ClearSecurityEventLog ()
		{
			int iHandle = ApiNativeMethods.OpenEventLogA (null, "Security");
			ApiNativeMethods.ClearEventLogA (iHandle, null);
			ApiNativeMethods.CloseEventLog (iHandle);
		}

		public static void ClearSystemEventLog ()
		{
			int iHandle = ApiNativeMethods.OpenEventLogA (null, "System");
			ApiNativeMethods.ClearEventLogA (iHandle, null);
			ApiNativeMethods.CloseEventLog (iHandle);
		}

		/// <summary>
		/// Collection Constructor with additional options
		/// </summary>
		public static ArrayList EnumWindows()
		{
			m_aoWndArray = new ArrayList(); //array of windows
        	
			//Declare a callback delegate for EnumWindows() API call
			EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);

			//Enumerate all Windows
			User32ApiNativeMethods.EnumWindows(ewp, 0);

			return m_aoWndArray;
		}

		//EnumWindows CALLBACK function
		private static int EvalWindow(int windowHandle, int lParam)
		{
			StringBuilder oTitle = new StringBuilder(256);
			StringBuilder oModule = new StringBuilder(256);

			User32ApiNativeMethods.GetWindowModuleFileName((int)windowHandle, oModule, oModule.Capacity-1);
			User32ApiNativeMethods.GetWindowText			((int)windowHandle, oTitle,  oTitle.Capacity-1);

			User32ApiNativeMethods.GetWindowThreadProcessId ((int)windowHandle, 0);

			m_aoWndArray.Add(new Window(oTitle.ToString(), (IntPtr)windowHandle, oModule.ToString()));
			return (0);
		}

		public static string GetWindowText (IntPtr windowHandle)
		{
			string			szText;
			StringBuilder	oTitle = new StringBuilder (1024);
			User32ApiNativeMethods.GetWindowText ((int)windowHandle, oTitle, oTitle.Capacity-1);
			szText = oTitle.ToString ();
			return szText;
		}

		public static string GetClassName (IntPtr windowHandle)
		{
			string			szText;
			StringBuilder	oTitle = new StringBuilder (1024);
			User32ApiNativeMethods.GetClassName ((int)windowHandle, oTitle, oTitle.Capacity-1);
			szText = oTitle.ToString ();
			return szText;
		}
		
		#region Drive/disk functions (free space, name & informations...
		/// <summary>
		/// Get a root drive type
		/// </summary>
		public static DriveType GetDriveType(string rootPathName)
		{
			if (rootPathName == null)
				return DriveType.Unknown;

			DriveType eType = (DriveType)ApiNativeMethods.GetDriveType(rootPathName);
			return eType;
		}


		/// <summary>
		/// Get a root drive name
		/// </summary>
		public static string GetDriveName(string rootPathName)
		{
			uint uiSerialNumber, uiSysFlags;
			string szFileSystem;
			string szDriveName = Win32ApiUtility.GetDriveInformations (rootPathName, out uiSerialNumber, out uiSysFlags, out szFileSystem);
			return szDriveName;
		}

		/// <summary>
		/// Get a root drive name
		/// </summary>
		public static string GetDriveInformations (string rootPathName, out uint serialNumber, out DriveInformations driveInformations, out string fileSystem)
		{
			uint uiSysFlags;
			string szDriveName = Win32ApiUtility.GetDriveInformations (rootPathName, out serialNumber, out uiSysFlags, out fileSystem);

			driveInformations = 0;
			if(szDriveName.Length != 0)
			{
				// Convert flags
				if ((uiSysFlags & (uint)DriveInformations.CaseSensitiveSearch	) == (uint)DriveInformations.CaseSensitiveSearch) driveInformations |= DriveInformations.CaseSensitiveSearch	;
				if ((uiSysFlags & (uint)DriveInformations.CasePreservedNames	) == (uint)DriveInformations.CasePreservedNames	) driveInformations |= DriveInformations.CasePreservedNames	;
				if ((uiSysFlags & (uint)DriveInformations.UnicodeOnDisk			) == (uint)DriveInformations.UnicodeOnDisk		) driveInformations |= DriveInformations.UnicodeOnDisk		;
				if ((uiSysFlags & (uint)DriveInformations.PersistentAcls		) == (uint)DriveInformations.PersistentAcls		) driveInformations |= DriveInformations.PersistentAcls		;
				if ((uiSysFlags & (uint)DriveInformations.FileCompression		) == (uint)DriveInformations.FileCompression	) driveInformations |= DriveInformations.FileCompression		;
				if ((uiSysFlags & (uint)DriveInformations.VolumeQuotas			) == (uint)DriveInformations.VolumeQuotas		) driveInformations |= DriveInformations.VolumeQuotas			;
				if ((uiSysFlags & (uint)DriveInformations.SparseFiles			) == (uint)DriveInformations.SparseFiles		) driveInformations |= DriveInformations.SparseFiles			;
				if ((uiSysFlags & (uint)DriveInformations.ReparsePoints			) == (uint)DriveInformations.ReparsePoints		) driveInformations |= DriveInformations.ReparsePoints		;
				if ((uiSysFlags & (uint)DriveInformations.RemoteStorage			) == (uint)DriveInformations.RemoteStorage		) driveInformations |= DriveInformations.RemoteStorage		;
				if ((uiSysFlags & (uint)DriveInformations.VolumeIsCompressed	) == (uint)DriveInformations.VolumeIsCompressed	) driveInformations |= DriveInformations.VolumeIsCompressed	;
				if ((uiSysFlags & (uint)DriveInformations.SupportObjectsIds		) == (uint)DriveInformations.SupportObjectsIds	) driveInformations |= DriveInformations.SupportObjectsIds	;
				if ((uiSysFlags & (uint)DriveInformations.SupportEncryption		) == (uint)DriveInformations.SupportEncryption	) driveInformations |= DriveInformations.SupportEncryption	;
				if ((uiSysFlags & (uint)DriveInformations.NamedStreams			) == (uint)DriveInformations.NamedStreams		) driveInformations |= DriveInformations.NamedStreams			;
				if ((uiSysFlags & (uint)DriveInformations.ReadOnlyVolume		) == (uint)DriveInformations.ReadOnlyVolume		) driveInformations |= DriveInformations.ReadOnlyVolume		;
			}
			return szDriveName;
		}

		public static string GetDriveInformations (string rootPathName, out uint serialNumber, out uint systemFlags, out string fileSystem)
		{
			StringBuilder volname	= new StringBuilder(260);	// receives volume name of drive
			uint uiMaxcomplen		= new uint();				//receives maximum component length
			StringBuilder sysname	= new StringBuilder(260);	//receives the file system name
			uint retval				= new uint();				//return value

			retval = ApiNativeMethods.GetVolumeInformation(rootPathName, volname, 260, out serialNumber, out uiMaxcomplen, out systemFlags, sysname,260);
			if(retval!=0)
			{
				fileSystem = sysname.ToString ();
				return volname.ToString();
			}
			else
			{
				fileSystem = "";
				return "";
			}
		}

		public static bool GetDiskFreeSpace (string rootPathName, out DiskSpace diskSpaceOut)
		{
			bool bResult;
			uint SectorsPerCluster;
			uint BytesPerSector;
			uint NumberOfFreeClusters;
			uint TotalNumberOfClusters;

			diskSpaceOut = new DiskSpace ();
			bResult = ApiNativeMethods.GetDiskFreeSpace(rootPathName, 
								out SectorsPerCluster, out BytesPerSector,
								out NumberOfFreeClusters, out TotalNumberOfClusters);

			diskSpaceOut.SectorsPerCluster		= SectorsPerCluster;
			diskSpaceOut.BytesPerSector			= BytesPerSector;
			diskSpaceOut.NumberOfFreeClusters	= NumberOfFreeClusters;
			diskSpaceOut.TotalNumberOfClusters	= TotalNumberOfClusters;
			diskSpaceOut.FreeBytes				= (long)(NumberOfFreeClusters)  * (long)(SectorsPerCluster) * (long)(BytesPerSector);
			diskSpaceOut.TotalBytes				= (long)(TotalNumberOfClusters) * (long)(SectorsPerCluster) * (long)(BytesPerSector);
			return bResult;
		}
		#endregion

		public static string GetShortPathName	(string path)
		{
			string	szResult;
			StringBuilder shortPath = new StringBuilder (256);
			ApiNativeMethods.GetShortPathName	(path, shortPath, 260);
			szResult = shortPath.ToString ();
			return szResult;
		}

		public static string GetLongPathName	(string path)
		{
			string	szResult;
			StringBuilder longPath = new StringBuilder (256);
			ApiNativeMethods.GetLongPathName	(path, longPath, 260);
			szResult = longPath.ToString ();
			return szResult;
		}

		public static uint	CaretBlinkTime
		{
			get 
			{
				uint	uiResult = User32ApiNativeMethods.GetCaretBlinkTime ();
				return uiResult;
			}
		}

		public static int PostMessage (HandleRef windowHandle, uint messageId, int generic16BitsParameter, int generic32BitsParameter)
		{
			int iResult =  User32ApiNativeMethods.PostMessage (windowHandle, messageId, generic16BitsParameter, generic32BitsParameter);
			return iResult;
		}

		public static int SendMessage (Control destinationObject, int messageId, int generic16BitsParameter, int generic32BitsParameter)
		{
			if (destinationObject == null)	throw new NolmeArgumentNullException ();

			int iResult = User32ApiNativeMethods.SendMessage (new HandleRef(destinationObject, destinationObject.Handle), messageId, generic16BitsParameter, generic32BitsParameter);
			return iResult;
		}

		public static int SendMessage (HandleRef windowHandle, WindowsMessage messageId, int generic16BitsParameter, int generic32BitsParameter)
		{
			int iResult = User32ApiNativeMethods.SendMessage (windowHandle, (int)messageId, generic16BitsParameter, generic32BitsParameter);
			return iResult;
		}

		public static int SendMessage (HandleRef windowHandle, int messageId, int generic16BitsParameter, int generic32BitsParameter)
		{
			int	iResult = User32ApiNativeMethods.SendMessage (windowHandle, messageId, generic16BitsParameter, generic32BitsParameter);
			return iResult;
		}

		public static int SendMessage (IntPtr windowHandle, int messageId, int generic16BitsParameter, object parameter)
		{
			int	iResult = User32ApiNativeMethods.SendMessage ((int)windowHandle, messageId, generic16BitsParameter, (int)parameter);
			return iResult;
		}


		public static IntPtr	LoadLibrary (string fileName)
		{
			IntPtr iResult = (IntPtr)ApiNativeMethods.LoadLibrary (fileName);
			return iResult;
		}

		public static bool		FreeLibrary (IntPtr libraryHandle)
		{
			bool bResult = ApiNativeMethods.FreeLibrary ((int)libraryHandle);
			return bResult;
		}

		public static bool CaptureWindow(Control destinationObject, ref System.Drawing.Bitmap destinationBitmap)
		{
			if (destinationObject == null)	throw new NolmeArgumentNullException ();

			//This function captures the contents of a window or control
			Graphics g2 = Graphics.FromImage(destinationBitmap);

			//PrfCHILDREN // PrfNONCLIENT
			int meint = (int)(Prints.Client | Prints.EraseBackground); //| Owned ); //  );
			System.IntPtr meptr = new System.IntPtr(meint);

			System.IntPtr hdc = g2.GetHdc();
			Win32ApiUtility.SendMessage(new HandleRef (destinationObject, destinationObject.Handle), WindowsMessage.Print, (int)hdc, (int)meptr);

			g2.ReleaseHdc(hdc);
			g2.Dispose();

			return true;
		}
	};
}

/*
 TOOLTIP
internal const int WmUSER = 0x0400;
internal const int TTM_SETMAXTIPWIDTH = WmUSER + 24;

int iLast, iCur = TTM_SETMAXTIPWIDTH;
iLast = Win32ApiUtility.SendMessage (this, iCur, 0, 50);

 * */