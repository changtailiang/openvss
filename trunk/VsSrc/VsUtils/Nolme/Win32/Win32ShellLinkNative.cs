/**************************************************************************
*
* Filename:     ShellLinkNative.cs
* Author:       Mattias Sjögren (mattias@mvps.org)
*               http://www.msjogren.net/dotnet/
*
* Description:  Defines the native types used to manipulate shell shortcuts.
*
* Public types: enum ShellLinkResolve
*               enum ShellLinkPath
*               struct WIN32_FIND_DATA[A|W]
*               interface IPersistFile
*               interface IShellLink[A|W]
*               class ShellLink
*
*
* Copyright ©2001-2002, Mattias Sjögren
* 
**************************************************************************/

using System;
using System.Text;
using System.Runtime.InteropServices;
using Nolme.Core;

namespace Nolme.Win32
{
	// IShellLink.Resolve fFlags
	[Flags()]
	public enum ShellLinkResolves
	{
		NoUI		= 0x1,
		AnyMatch	= 0x2,
		Update		= 0x4,
		NoUpdate	= 0x8,
		NoSearch	= 0x10,
		NoTrack		= 0x20,
		NoLinkInfo	= 0x40,
		InvokeMsi	= 0x80
	}

	// IShellLink.GetPath fFlags
	[Flags()]
	public enum ShellLinkPaths
	{
		ShortPath	= 0x1,
		UniversalNamingConventionPriority = 0x2,
		RawPath		= 0x4
	}

	[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
	public struct Win32FindDataAnsi
	{
		private int dwFileAttributes;
		private FILETIME ftCreationTime;
		private FILETIME ftLastAccessTime;
		private FILETIME ftLastWriteTime;
		private int nFileSizeHigh;
		private int nFileSizeLow;
		private int reserved0;
		private int reserved1;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=DirectoryUtility.MaxPath)]
		private string cFileName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=14)]
		private string cAlternateFileName;

		#region FxCop Warning
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode() 
		{
			return base.GetHashCode();
		}

		public static bool operator ==(Win32FindDataAnsi obj1, Win32FindDataAnsi obj2)
		{
			return Object.Equals (obj1, obj2);
		}

		public static bool operator !=(Win32FindDataAnsi obj1, Win32FindDataAnsi obj2)
		{
			return !Object.Equals (obj1, obj2);
		}
		#endregion

		#region Properties
		public int FileAttributes
		{
			get { return dwFileAttributes; }
			set { dwFileAttributes = value; }
		}
		public FILETIME CreationTime
		{
			get { return ftCreationTime; }
			set { ftCreationTime = value; }
		}
		public FILETIME LastAccessTime
		{
			get { return ftLastAccessTime; }
			set { ftLastAccessTime = value; }
		}
		public FILETIME LastWriteTime
		{
			get { return ftLastWriteTime; }
			set { ftLastWriteTime = value; }
		}
		public int FileSizeHigh
		{
			get { return nFileSizeHigh; }
			set { nFileSizeHigh = value; }
		}
		public int FileSizeLow
		{
			get { return nFileSizeLow; }
			set { nFileSizeLow = value; }
		}
		public int Reserved0
		{
			get { return reserved0; }
			set { reserved0 = value; }
		}
		public int Reserved1
		{
			get { return reserved1; }
			set { reserved1 = value; }
		}
		
		public string FileName
		{
			get { return cFileName; }
			set { cFileName = value; }
		}
		
		public string AlternateFileName
		{
			get { return cAlternateFileName; }
			set { cAlternateFileName = value; }
		}
		#endregion
	}

	[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
	public struct Win32FindDataWide
	{
		private int dwFileAttributes;
		private FILETIME ftCreationTime;
		private FILETIME ftLastAccessTime;
		private FILETIME ftLastWriteTime;
		private int nFileSizeHigh;
		private int nFileSizeLow;
		private int reserved0;
		private int reserved1;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=DirectoryUtility.MaxPath)]
		private string cFileName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=14)]
		private string cAlternateFileName;

		#region FxCop Warning
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode() 
		{
			return base.GetHashCode();
		}

		public static bool operator ==(Win32FindDataWide obj1, Win32FindDataWide obj2)
		{
			return Object.Equals (obj1, obj2);
		}

		public static bool operator !=(Win32FindDataWide obj1, Win32FindDataWide obj2)
		{
			return !Object.Equals (obj1, obj2);
		}
		#endregion

		#region Properties
		public int FileAttributes
		{
			get { return dwFileAttributes; }
			set { dwFileAttributes = value; }
		}
		public FILETIME CreationTime
		{
			get { return ftCreationTime; }
			set { ftCreationTime = value; }
		}
		public FILETIME LastAccessTime
		{
			get { return ftLastAccessTime; }
			set { ftLastAccessTime = value; }
		}
		public FILETIME LastWriteTime
		{
			get { return ftLastWriteTime; }
			set { ftLastWriteTime = value; }
		}
		public int FileSizeHigh
		{
			get { return nFileSizeHigh; }
			set { nFileSizeHigh = value; }
		}
		public int FileSizeLow
		{
			get { return nFileSizeLow; }
			set { nFileSizeLow = value; }
		}
		public int Reserved0
		{
			get { return reserved0; }
			set { reserved0 = value; }
		}
		public int Reserved1
		{
			get { return reserved1; }
			set { reserved1 = value; }
		}
		
		public string FileName
		{
			get { return cFileName; }
			set { cFileName = value; }
		}
		
		public string AlternateFileName
		{
			get { return cAlternateFileName; }
			set { cAlternateFileName = value; }
		}
		#endregion
	}

  [
    ComImport(),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("0000010B-0000-0000-C000-000000000046")
  ]
  public interface IPersistFile
  {
    #region Methods inherited from IPersist

    //void GetClassId(out Guid classId);

    #endregion

    [PreserveSig()]
    int IsDirty();

    void Load( [MarshalAs(UnmanagedType.LPWStr)] string fileName, int loadingMode);

    void Save( [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.Bool)] bool remember);

    void SaveCompleted( [MarshalAs(UnmanagedType.LPWStr)] string fileName);

    //void GetCurFile( out IntPtr fileNameOut);
  }

  [
    ComImport(),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214EE-0000-0000-C000-000000000046")
  ]
  public interface IShellLinkA
  {
    void GetPath(
      [Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder fileName,
      int pathMaxLength,
      out Win32FindDataAnsi findDataOut,
      ShellLinkPaths flags);

    void GetIdentifierList(out IntPtr identifierList);

    void SetIdentifierList(IntPtr identifierList);

    void GetDescription([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder name, int nameMaxLength);

    void SetDescription([MarshalAs(UnmanagedType.LPStr)] string name);

    void GetWorkingDirectory( [Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder destinationPathName, int maxLength);

    void SetWorkingDirectory([MarshalAs(UnmanagedType.LPStr)] string destinationPathName);

    void GetArguments([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder arguments, int maxLength);

    void SetArguments([MarshalAs(UnmanagedType.LPStr)] string arguments);

    void GetHotkey(out short hotkeyOut);

    void SetHotkey(short hotkey);

    void GetShowCommand(out int showCommandOut);

    void SetShowCommand(int showCommand);

    void GetIconLocation([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder iconPathOut, int iconPathLength, out int iconOut);

    void SetIconLocation([MarshalAs(UnmanagedType.LPStr)] string iconPath,int icon);

    void SetRelativePath([MarshalAs(UnmanagedType.LPStr)] string relativePath, int reserved);

    void Resolve(IntPtr windowHandle, ShellLinkResolves flags);

    void SetPath([MarshalAs(UnmanagedType.LPStr)] string fileName);

  }

  [
    ComImport(),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214F9-0000-0000-C000-000000000046")
  ]
  public interface IShellLinkW
  {
    void GetPath([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder fileNameOut,
      int maxLength,
      out Win32FindDataWide findDataWideOut,
      ShellLinkPaths flags);

    void GetIdentifierList(out IntPtr identifierListOut);

    void SetIdentifierList(IntPtr identifierList);

    void GetDescription([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameOut,int nameMaxLength);

    void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string name);

    void GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder destinationPathNameOut,
      int maxLength);

    void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string destinationPathName);

    void GetArguments([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder argumentsOut, int maxLength);

    void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string arguments);

    void GetHotkey(out short hotkey);
    void SetHotkey(short hotkey);

    void GetShowCmd(out int showCommand);
    void SetShowCmd(int showCommand);

    void GetIconLocation([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder iconPath, int iconPathLength, out int iconHandleOut);

    void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string iconPath,int icon);

    void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string relativePath, int reserved);

    void Resolve(IntPtr windowHandle, ShellLinkResolves flags);

    void SetPath([MarshalAs(UnmanagedType.LPWStr)] string fileName);

  }


  [
    ComImport(),
    Guid("00021401-0000-0000-C000-000000000046")
  ]
  public class ShellLink  // : IPersistFile, IShellLinkA, IShellLinkW 
  {
  }

}
