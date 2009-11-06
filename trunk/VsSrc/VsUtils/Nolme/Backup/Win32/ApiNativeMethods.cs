using System;
using System.Text;
using System.Runtime.InteropServices;	// for DllImport, MarshalAs, etc

namespace Nolme.Win32
{
	#region Enums
	[FlagsAttribute]
	public enum ExitWindows : int 
	{
		None		= 0,
		LogOff		= None,
		Shutdown	= 0x1,
		Reboot		= 0x2,
		Force		= 0x4,
		PowerOff	= 0x8,
		ForceIfHung = 0x10,
		Reset		= LogOff | Force | Reboot
	}

	public enum ShutdownReason : int
	{
		FlagCommentRequired = 0x1000000,
		FlagDirtyProblemIdRequired = 0x2000000,
		FlagCleanUI = 0x4000000,
		FlagDirtyUI = 0x8000000,
		FlagUserDefined = 0x40000000,
		FlagPlanned = unchecked((int)0x80000000),
		MajorOther = 0x0,
		MajorNone = 0x0,
		MajorHardware = 0x10000,
		MajorOperatingSystem = 0x20000,
		MajorSoftware = 0x30000,
		MajorApplication = 0x40000,
		MajorSystem = 0x50000,
		MajorPower = 0x60000,
		MajorLegacyApi = 0x70000,
		MinorOther = 0x0,
		MinorNone = 0xFF,
		MinorMaintenance = 0x1,
		MinorInstallation = 0x2,
		MinorUpgrade = 0x3,
		MinorNewConfiguration = 0x4,
		MinorHung = 0x5,
		MinorUnstable = 0x6,
		MinorDisk = 0x7,
		MinorProcessor = 0x8,
		MinorNetworkCard = 0x9,
		MinorPowerSupply = 0xA,
		MinorCordUnplugged = 0xB,
		MinorEnvironment = 0xC,
		MinorHardwareDriver = 0xD,
		MinorOtherDriver = 0xE,
		MinorBlueScreen = 0xF,
		MinorServicePack = 0x10,
		MinorHotFix = 0x11,
		MinorSecurityFix = 0x12,
		MinorSecurity = 0x13,
		MinorNetworkConnectivity = 0x14,
		MinorWmi = 0x15,
		MinorServicePackUninstall = 0x16,
		MinorHotFixUninstall = 0x17,
		MinorSecurityFixUninstall = 0x18,
		MinorMmc = 0x19,
		MinorTerminalServer = 0x20,
		Unknown = MinorNone ,
		LegacyApi = (MajorLegacyApi | FlagPlanned)
	}

	public enum WindowsStyle : int
	{
		None					= 0,
		Popup					= unchecked((int) 0x80000000),
		Overlapped				= 0x0,
		Child					= 0x40000000,
		Minimize				= 0x20000000,
		Visible					= 0x10000000,
		Disabled				= 0x8000000,
		ClipSiblings			= 0x4000000,
		ClipChildren			= 0x2000000,
		Maximize				= 0x1000000,
		Caption					= 0xC00000,                  //  Border | DialogFrame
		Border					= 0x800000,
		DialogFrame				= 0x400000,
		VerticalScroll			= 0x200000,
		HorizontalScroll		= 0x100000,
		SystemMenu				= 0x80000,
		ThickFrame				= 0x40000,
		Group					= 0x20000,
		TabStop					= 0x10000,

		MinimizeBox				= 0x20000,
		MaximizeBox				= 0x10000,

		Tiled					= Overlapped,
		Iconic					= Minimize,
		SizeBox					= ThickFrame,
		OverlappedWindow		= (Overlapped | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox),
		TiledWindow				= OverlappedWindow,
	}

	public enum WindowsMessage
	{
		None					= 0,
		InitDialog				= 0x0110,
		Command					= 0x0111,
		SystemCommand			= 0x0112,
		Timer					= 0x0113,
		HorizontalScroll		= 0x0114,
		VerticalScroll			= 0x0115,
		InitMenu				= 0x0116,
		InitMenuPopup			= 0x0117,
		MenuSelect				= 0x011F,
		MenuChar				= 0x0120,
		EnterIdle				= 0x0121,

		MouseMove				= 0x0200,
		LeftButtonDown			= 0x0201,
		LeftButtonUp			= 0x0202,
		LeftButtonDoubleClick	= 0x0203,
		RightButtonDown			= 0x0204,
		RightButtonUp			= 0x0205,
		RightButtonDoubleClick	= 0x0206,
		MiddleButtonDown		= 0x0207,
		MiddleButtonUp			= 0x0208,
		MiddleButtonDoubleClick	= 0x0209,

		Print					= 0x0317,
		PrintClient				= 0x0318,

		CopyData				= 0x004A,
		MouseLeave				= 0x02A3,
		Paint					= 0x000F,
		EraseBackground			= 0x0014
	}

	public enum ShowWindow
	{
		Hide					= 0,
		ShowNormal				= 1,
		Normal					= 1,
		ShowMinimized			= 2,
		ShowMaximized			= 3,
		Maximize				= 3,
		ShowNoActivate			= 4,
		Show					= 5,
		Minimize				= 6,
		ShowMinimizedNoActive	= 7,
		ShowNoActive			= 8,
		Restore					= 9,
		ShowDefault				= 10,
		Max						= 10
	}

	public enum EditMessage
	{
		None					= 0,
		GetSelection			= 0x00B0,
		LineIndex				= 0x00BB,
		LineFromCharacter		= 0x00C9,
		PositionFromCharacter	= 0x00D6
	}

	[Flags]
	public enum Prints : long
	{
		CheckVisible		= 0x00000001L,
		NonClient			= 0x00000002L,
		Client				= 0x00000004L,
		EraseBackground		= 0x00000008L,
		Children			= 0x00000010L,
		Owned				= 0x00000020L
	}

	public enum DriveType
	{
		Unknown,		// The drive type cannot be determined
		NoRootDir,		// The root path is invalid. For example, no volume is mounted at the path
		Removable,		// The disk can be removed from the drive
		Fixed,			// The disk cannot be removed from the drive
		Remote,			// The drive is a remote (network) drive
		CDRom,			// The drive is a CD-ROM drive
		RamDisk,		// The drive is a RAM disk
		Max
	};
	[Flags]
	public enum DriveInformations : int 
	{
		CaseSensitiveSearch = 0x00000001,	// == FS_CASE_SENSITIVE. The file system supports case-sensitive file names. 
		CasePreservedNames	= 0x00000002,	// == FS_CASE_IS_PRESERVED. The file system preserves the case of file names when it places a name on disk. 
		UnicodeOnDisk		= 0x00000004,	// == FS_UNICODE_STORED_ON_DISK. The file system supports Unicode in file names as they appear on disk. 
		PersistentAcls		= 0x00000008,	// == FS_PERSISTENT_ACLS. The file system preserves and enforces ACLs. For example, NTFS preserves and enforces ACLs, and FAT does not. 
		FileCompression		= 0x00000010,	// == FS_FILE_COMPRESSION. The file system supports file-based compression. 
		VolumeQuotas		= 0x00000020,	// The file system supports disk quotas. 
		SparseFiles			= 0x00000040,	// The file system supports sparse files. 
		ReparsePoints		= 0x00000080,	// The file system supports reparse points. 
		RemoteStorage		= 0x00000100,	// 
		VolumeIsCompressed	= 0x00008000,	// == FS_VOL_IS_COMPRESSED. The specified volume is a compressed volume; for example, a DoubleSpace volume.
		SupportObjectsIds	= 0x00010000,	// The file system supports object identifiers. 
		SupportEncryption	= 0x00020000,	// == FS_FILE_ENCRYPTION. The file system supports the Encrypted File System (EFS). 
		NamedStreams		= 0x00040000,	// The file system supports named streams. 
		ReadOnlyVolume		= 0x00080000	// The specified volume is read-only.Windows 2000/NT and Windows Me/98/95: This value is not supported. 
	}

	#region Not Used Constants
	/*
		 * Others messages
		 * */
	//internal const int GwlStyle				= (-16);
	//internal const int EMPTY				= 32;
	//internal const int CONSOLE_TEXTMODE_BUFFER = 1;

	/*
		internal const int FlashwStop			= 0;
		internal const int FlashwCaption		= 1;
		internal const int FlashwTray			= 2;
		internal const int FlashwAll			= 3;
		internal const int FlashwTimer			= 4;
		internal const int FlashwTimerNoFg		= 0xc;
		*/

	//internal const int _DefaultConsoleBufferSize = 256;

	/*
		internal const int FOREGROUND_BLUE = 0x1;     //  text color contains blue.
		internal const int FOREGROUND_GREEN = 0x2;     //  text color contains green.
		internal const int FOREGROUND_RED = 0x4;     //  text color contains red.
		internal const int FOREGROUND_INTENSITY = 0x8;     //  text color is intensified.
		internal const int BACKGROUND_BLUE = 0x10;    //  background color contains blue.
		internal const int BACKGROUND_GREEN = 0x20;    //  background color contains green.
		internal const int BACKGROUND_RED = 0x40;    //  background color contains red.
		internal const int BACKGROUND_INTENSITY = 0x80;    //  background color is intensified.
		internal const int COMMON_LVB_REVERSE_VIDEO = 0x4000;
		internal const int COMMON_LVB_UNDERSCORE = 0x8000;

		internal const int GENERIC_READ = unchecked((int) 0x80000000);
		internal const int GENERIC_WRITE = 0x40000000;

		internal const int FILE_SHARE_READ = 0x1;
		internal const int FILE_SHARE_WRITE = 0x2;

		internal const int STD_INPUT_HANDLE = -10;
		internal const int STD_OUTPUT_HANDLE = -11;
		internal const int STD_ERROR_HANDLE = -12;

		internal const int SWP_NOSIZE = 0x1;
		internal const int SWP_NOMOVE = 0x2;
		internal const int SWP_NOZORDER = 0x4;
		internal const int SWP_NOREDRAW = 0x8;
		internal const int SWP_NOACTIVATE = 0x10;
		*/
	#endregion
	#endregion

	#region Delegate
	//delegate used for EnumWindows() callback function
	[return: MarshalAs(UnmanagedType.SysInt)]
	public delegate int EnumWindowsProc([MarshalAs(UnmanagedType.SysInt)]int windowHandle, int genericDoubleWordParameter);

	public delegate bool HandlerRoutine(int type);
	#endregion

	#region Structures
	// It makes no difference if we use ParagraphFormat or
	// ParagraphFormat2 here, so I have opted for ParagraphFormat2
	[StructLayout( LayoutKind.Sequential )]
	public struct ParagraphFormat
	{
		private int		m_Size;
		private int		m_Mask;
		private short	m_Numbering;
		private short	m_Reserved;
		private int		m_xStartIndent;
		private int		m_xRightIndent;
		private int		m_xOffset;
		private short	m_Alignment;
		private short	m_TabCount;
		[MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )]
		private int[]	m_TabStopPositions;
        
		// ParagraphFormat2 from here onwards
		private int		m_ySpaceBefore;
		private int		m_ySpaceAfter;
		private int		m_yLineSpacing;
		private short	m_Style;
		private byte	m_LineSpacingRule;
		private byte	m_OutlineLevel;
		private short	m_ShadingWeight;
		private short	m_ShadingStyle;
		private short	m_NumberingStart;
		private short	m_NumberingStyle;
		private short	m_NumberingTab;
		private short	m_BorderSpace;
		private short	m_BorderWidth;
		private short	m_Borders;

		#region FxCop Warning
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode() 
		{
			return base.GetHashCode();
		}

		public static bool operator ==(ParagraphFormat obj1, ParagraphFormat obj2)
		{
			return Object.Equals (obj1, obj2);
		}

		public static bool operator !=(ParagraphFormat obj1, ParagraphFormat obj2)
		{
			return !Object.Equals (obj1, obj2);
		}
		#endregion

		#region Properties
		public int		Size
		{
			get { return m_Size; }
			set { m_Size = value; }
		}
		public int		Mask
		{
			get { return m_Mask; }
			set { m_Mask = value; }
		}
		public short	Numbering
		{
			get { return m_Numbering; }
			set { m_Numbering = value; }
		}
		public short	Reserved
		{
			get { return m_Reserved; }
			set { m_Reserved = value; }
		}
		public int		StartIndentOnX
		{
			get { return m_xStartIndent; }
			set { m_xStartIndent = value; }
		}
		public int		RightIndentOnX
		{
			get { return m_xRightIndent; }
			set { m_xRightIndent = value; }
		}
		public int		OffsetOnX
		{
			get { return m_xOffset; }
			set { m_xOffset = value; }
		}
		public short	Alignment
		{
			get { return m_Alignment; }
			set { m_Alignment = value; }
		}
		public short	TabCount
		{
			get { return m_TabCount; }
			set { m_TabCount = value; }
		}
		/*public int[]	TabStopPositions
		{
			get { return m_TabStopPositions; }
			set { m_TabStopPositions = value; }
		}
		*/
		public int[]	RetrieveTabStopPositions ()
		{
			return m_TabStopPositions;
		}

		public int		SpaceBeforeOnY
		{
			get { return m_ySpaceBefore; }
			set { m_ySpaceBefore = value; }
		}
		public int		SpaceAfterOnY
		{
			get { return m_ySpaceAfter; }
			set { m_ySpaceAfter = value; }
		}
		public int		LineSpacingOnY
		{
			get { return m_yLineSpacing; }
			set { m_yLineSpacing = value; }
		}
		public short	Style
		{
			get { return m_Style; }
			set { m_Style = value; }
		}
		public byte		LineSpacingRule
		{
			get { return m_LineSpacingRule; }
			set { m_LineSpacingRule = value; }
		}
		public byte		OutlineLevel
		{
			get { return m_OutlineLevel; }
			set { m_OutlineLevel = value; }
		}
		public short	ShadingWeight
		{
			get { return m_ShadingWeight; }
			set { m_ShadingWeight = value; }
		}
		public short	ShadingStyle
		{
			get { return m_ShadingStyle; }
			set { m_ShadingStyle = value; }
		}
		public short	NumberingStart
		{
			get { return m_NumberingStart; }
			set { m_NumberingStart = value; }
		}
		public short	NumberingStyle
		{
			get { return m_NumberingStyle; }
			set { m_NumberingStyle = value; }
		}
		public short	NumberingTab
		{
			get { return m_NumberingTab; }
			set { m_NumberingTab = value; }
		}
		public short	BorderSpace
		{
			get { return m_BorderSpace; }
			set { m_BorderSpace = value; }
		}
		public short	BorderWidth
		{
			get { return m_BorderWidth; }
			set { m_BorderWidth = value; }
		}
		public short	Borders
		{
			get { return m_Borders; }
			set { m_Borders = value; }
		}
		#endregion
	}

	/*
	[StructLayout(LayoutKind.Sequential)]
	public struct OperatingSystemVersion 
	{
		private int m_OSVersionInfoSize;
		private int m_MajorVersion;
		private int m_MinorVersion;
		private int m_BuildNumber;
		private int m_PlatformId;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
		private string m_AdditionalText;

	#region Properties
		public int OSVersionInfoSize
		{
			get { return m_OSVersionInfoSize; }
			set { m_OSVersionInfoSize = value; }
		}
		public int MajorVersion
		{
			get { return m_MajorVersion; }
			set { m_MajorVersion = value; }
		}
		public int MinorVersion
		{
			get { return m_MinorVersion; }
			set { m_MinorVersion = value; }
		}
		public int BuildNumber
		{
			get { return m_BuildNumber; }
			set { m_BuildNumber = value; }
		}
		public int PlatformId
		{
			get { return m_PlatformId; }
			set { m_PlatformId = value; }
		}
		public string AdditionalText
		{
			get { return m_AdditionalText; }
			set { m_AdditionalText = value; }
		}
	#endregion
	}
	*/

	/*public struct OperatingSystemVersionExtended
	{
		private int m_OSVersionInfoSize;
		private int m_MajorVersion;
		private int m_MinorVersion;
		private int m_BuildNumber;
		private int m_PlatformId;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
		private string m_AdditionalText;
		private short m_ServicePackMajor;
		private short m_ServicePackMinor;
		private short m_Reserved0;
		private short m_Reserved1;

		#region FxCop Warning
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode() 
		{
			return base.GetHashCode();
		}

		public static bool operator ==(OperatingSystemVersionExtended obj1, OperatingSystemVersionExtended obj2)
		{
			return Object.Equals (obj1, obj2);
		}

		public static bool operator !=(OperatingSystemVersionExtended obj1, OperatingSystemVersionExtended obj2)
		{
			return !Object.Equals (obj1, obj2);
		}
		#endregion

		#region Properties
		public int OSVersionInfoSize
		{
			get { return m_OSVersionInfoSize; }
			set { m_OSVersionInfoSize = value; }
		}
		public int MajorVersion
		{
			get { return m_MajorVersion; }
			set { m_MajorVersion = value; }
		}
		public int MinorVersion
		{
			get { return m_MinorVersion; }
			set { m_MinorVersion = value; }
		}
		public short ServicePackMajorVersion
		{
			get { return m_ServicePackMajor; }
			set { m_ServicePackMajor = value; }
		}
		public short ServicePackMinorVersion
		{
			get { return m_ServicePackMinor; }
			set { m_ServicePackMinor = value; }
		}
		public int BuildNumber
		{
			get { return m_BuildNumber; }
			set { m_BuildNumber = value; }
		}
		public int PlatformId
		{
			get { return m_PlatformId; }
			set { m_PlatformId = value; }
		}
		public string AdditionalText
		{
			get { return m_AdditionalText; }
			set { m_AdditionalText = value; }
		}
		public short Reserved0
		{
			get { return m_Reserved0; }
			set { m_Reserved0 = value; }
		}
		public short Reserved1
		{
			get { return m_Reserved1; }
			set { m_Reserved1 = value; }
		}
		#endregion
	}*/

	public struct TokenPrivileges 
	{
		private int		m_Count;
		private long	m_LocallyUniqueIdentifier;
		private int		m_Attributes;

		#region FxCop Warning
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode() 
		{
			return base.GetHashCode();
		}

		public static bool operator ==(TokenPrivileges obj1, TokenPrivileges obj2)
		{
			return Object.Equals (obj1, obj2);
		}

		public static bool operator !=(TokenPrivileges obj1, TokenPrivileges obj2)
		{
			return !Object.Equals (obj1, obj2);
		}
		#endregion

		#region Properties
		public int	Count
		{
			get { return m_Count; }
			set { m_Count = value; }
		}
		public long LocallyUniqueIdentifier
		{
			get { return m_LocallyUniqueIdentifier; }
			set { m_LocallyUniqueIdentifier = value; }
		}
		public int	Attributes
		{
			get { return m_Attributes; }
			set { m_Attributes = value; }
		}
		#endregion
	}

	/*
		struct ConsoleScreenBufferInfo
		{
			public Coord Size;
			public Coord CursorPosition;
			public ConsoleColor Attributes;
			public SmallRect Window;
			public Coord MaximumWindowSize;
		}

		public struct ConsoleSelectionInfo
		{
			public int Flags;
			public Coord SelectionAnchor;
			public SmallRect Selection;
		}

		public struct SmallRect
		{
			public short Left;
			public short Top;
			public short Right;
			public short Bottom;
		}
		*/

	#endregion


	/// <summary>
	/// Gdi32ApiNativeMethods dll access
	/// </summary>
	public sealed class Gdi32ApiNativeMethods
	{
		private Gdi32ApiNativeMethods () {}

		public const int SRCCOPY = 13369376;

		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleBitmap")]		internal static extern IntPtr CreateCompatibleBitmap(IntPtr handleDeviceContext, int nWidth, int nHeight);
		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleDC")]			internal static extern IntPtr CreateCompatibleDC(IntPtr handleDeviceContext);
		[DllImport("gdi32.dll", EntryPoint="SelectObject")]					internal static extern IntPtr SelectObject(IntPtr handleDeviceContext,IntPtr bmp);
		
		[DllImport("gdi32.dll", EntryPoint="DeleteDC")]
		internal static extern int DeleteDC(IntPtr handleDeviceContext);
		
		[DllImport("gdi32.dll", EntryPoint="DeleteObject")]
		internal static extern int DeleteObject(IntPtr handleDeviceContext);
		
		[DllImport("gdi32.dll", EntryPoint="BitBlt")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool BitBlt(IntPtr handleDeviceContextDestination,int xDestination, int yDestination,int wDestination,int hDestination,IntPtr handleDeviceContextSource, int xSource,int ySource,int RasterOp);
	}

	#region enums
	internal enum SHERB
	{
		SHERB_NOCONFIRMATION	= 0x00000001,		// No dialog box confirming the deletion of the objects will be displayed. 
		SHERB_NOPROGRESSUI		= 0x00000002,		// No dialog box indicating the progress will be displayed. 
		SHERB_NOSOUND			= 0x00000004		// No sound will be played when the operation is complete
	};

	internal enum SHGFI
	{
		SHGFI_ICON =             0x000000100,     // get icon
		SHGFI_DISPLAYNAME =      0x000000200,     // get display name
		SHGFI_TYPENAME =         0x000000400,     // get type name
		SHGFI_ATTRIBUTES =       0x000000800,     // get attributes
		SHGFI_ICONLOCATION =     0x000001000,     // get icon location
		SHGFI_EXETYPE =          0x000002000,     // return exe type
		SHGFI_SYSICONINDEX =     0x000004000,     // get system icon index
		SHGFI_LINKOVERLAY =      0x000008000,     // put a link overlay on icon
		SHGFI_SELECTED =         0x000010000,     // show icon in selected state
		SHGFI_ATTR_SPECIFIED =   0x000020000,     // get only specified attributes
		SHGFI_LARGEICON =        0x000000000,     // get large icon
		SHGFI_SMALLICON =        0x000000001,     // get small icon
		SHGFI_OPENICON =         0x000000002,     // get open icon
		SHGFI_SHELLICONSIZE =    0x000000004,     // get shell size icon
		SHGFI_PIDL =             0x000000008,     // pszPath is a pidl
		SHGFI_USEFILEATTRIBUTES = 0x000000010     // use passed dwFileAttribute
	}

	internal enum CSIDL 
	{
		CSIDL_FLAG_CREATE				= (0x8000),	// Version 5.0. Combine this CSIDL with any of the following CSIDLs to force the creation of the associated folder. 
		CSIDL_ADMINTOOLS				= (0x0030),	// Version 5.0. The file system directory that is used to store administrative tools for an individual user. The Microsoft 
		// Management Console (MMC) will save customized consoles to  this directory, and it will roam with the user.
		CSIDL_ALTSTARTUP				= (0x001d),	// The file system directory that corresponds to the user's nonlocalized Startup program group.
		CSIDL_APPDATA					= (0x001a),	// Version 4.71. The file system directory that serves as a common repository for application-specific data. A typical path is C:\Documents and Settings\username\Application Data. 
		// This CSIDL is supported by the redistributable Shfolder.dll for systems that do not have the Microsoft® Internet Explorer 4.0 integrated Shell installed.
		CSIDL_BITBUCKET					= (0x000a),	// The virtual folder containing the objects in the user's Recycle Bin.
		CSIDL_CDBURN_AREA				= (0x003b),	// Version 6.0. The file system directory acting as a staging area for files waiting to be written to CD. A typical path 
		// is C:\Documents and Settings\username\Local Settings\Application Data\Microsoft\CD Burning.
		CSIDL_COMMON_ADMINTOOLS			= (0x002f),	// Version 5.0. The file system directory containing administrative tools for all users of the computer.
		CSIDL_COMMON_ALTSTARTUP			= (0x001e), // The file system directory that corresponds to the nonlocalized Startup program group for all users. Valid only for Microsoft Windows NT® systems.
		CSIDL_COMMON_APPDATA			= (0x0023), // Version 5.0. The file system directory containing application data for all users. A typical path is C:\Documents and Settings\All Users\Application Data.
		CSIDL_COMMON_DESKTOPDIRECTORY	= (0x0019), // The file system directory that contains files and folders that appear on the desktop for all users. 
		// A typical path is C:\Documents and Settings\All Users\Desktop. Valid only for Windows NT systems.
		CSIDL_COMMON_DOCUMENTS			= (0x002e), // The file system directory that contains documents that are common to all users. 
		// A typical paths is C:\Documents and Settings\All Users\Documents. Valid for Windows NT systems 
		// and Microsoft Windows® 95 and Windows 98 systems with Shfolder.dll installed.
		CSIDL_COMMON_FAVORITES			= (0x001f), // The file system directory that serves as a common repository
		// for favorite items common to all users. Valid only for Windows NT systems.
		CSIDL_COMMON_MUSIC				= (0x0035), // Version 6.0. The file system directory that serves as a repository for music files common to all users. A typical 
		// path is C:\Documents and Settings\All Users\Documents\My Music.
		CSIDL_COMMON_PICTURES			= (0x0036), // Version 6.0. The file system directory that serves as a repository for image files common to all users. A typical 
		// path is C:\Documents and Settings\All Users\Documents\My Pictures.
		CSIDL_COMMON_PROGRAMS			= (0x0017), // The file system directory that contains the directories for the common program groups that appear on the Start menu for
		// all users. A typical path is C:\Documents and Settings\All Users\Start Menu\Programs. Valid only for Windows NT systems.
		CSIDL_COMMON_STARTMENU			= (0x0016), // The file system directory that contains the programs and folders that appear on the Start menu for all users. A 
		// typical path is C:\Documents and Settings\All Users\Start Menu. Valid only for Windows NT systems.
		CSIDL_COMMON_STARTUP			= (0x0018), // The file system directory that contains the programs that appear in the Startup folder for all users. A typical path 
		// is C:\Documents and Settings\All Users\Start Menu\Programs\Startup. Valid only for Windows NT systems.
		CSIDL_COMMON_TEMPLATES			= (0x002d), // The file system directory that contains the templates that are available to all users. A typical path is C:\Documents 
		// and Settings\All Users\Templates. Valid only for Windows NT systems.
		CSIDL_COMMON_VIDEO				= (0x0037), // Version 6.0. The file system directory that serves as a repository for video files common to all users. A typical 
		// path is C:\Documents and Settings\All Users\Documents\My Videos.
		CSIDL_CONTROLS					= (0x0003), // The virtual folder containing icons for the Control Panel applications.
		CSIDL_COOKIES					= (0x0021), // The file system directory that serves as a common repository for Internet cookies. A typical path is C:\Documents and Settings\username\Cookies.
		CSIDL_DESKTOP					= (0x0000), // The virtual folder representing the Windows desktop, the root of the namespace.
		CSIDL_DESKTOPDIRECTORY			= (0x0010), // The file system directory used to physically store file objects on the desktop (not to be confused with the desktop 
		// folder itself). A typical path is C:\Documents and Settings\username\Desktop.
		CSIDL_DRIVES					= (0x0011), // The virtual folder representing My Computer, containing everything on the local computer: storage devices, printers,
		// and Control Panel. The folder may also contain mapped network drives.
		CSIDL_FAVORITES					= (0x0006), // The file system directory that serves as a common repository for the user's favorite items. A typical path is C:\Documents and Settings\username\Favorites.
		CSIDL_FONTS						= (0x0014), // A virtual folder containing fonts. A typical path is C:\Windows\Fonts.
		CSIDL_HISTORY					= (0x0022), // The file system directory that serves as a common repository for Internet history items.
		CSIDL_INTERNET					= (0x0001), // A virtual folder representing the Internet.
		CSIDL_INTERNET_CACHE			= (0x0020), // Version 4.72. The file system directory that serves as a common repository for temporary Internet files. A typical 
		// path is C:\Documents and Settings\username\Local Settings\Temporary Internet Files.
		CSIDL_LOCAL_APPDATA				= (0x001c), // Version 5.0. The file system directory that serves as a data repository for local (nonroaming) applications. A typical 
		// path is C:\Documents and Settings\username\Local Settings\Application Data.
		CSIDL_MYDOCUMENTS				= (0x000c), // Version 6.0. The virtual folder representing the My Documents desktop item. This should not be confused with 
		// CSIDL_PERSONAL, which represents the file system folder that physically stores the documents.
		CSIDL_MYMUSIC					= (0x000d), // The file system directory that serves as a common repository for music files. A typical path is C:\Documents and Settings\User\My Documents\My Music.
		CSIDL_MYPICTURES				= (0x0027), // Version 5.0. The file system directory that serves as a common repository for image files. A typical path is C:\Documents and Settings\username\My Documents\My Pictures.
		CSIDL_MYVIDEO					= (0x000e), // Version 6.0. The file system directory that serves as a common repository for video files. A typical path is C:\Documents and Settings\username\My Documents\My Videos.
		CSIDL_NETHOOD					= (0x0013), // A file system directory containing the link objects that may exist in the My Network Places virtual folder. It is not the
		// same as CSIDL_NETWORK, which represents the network namespace root. A typical path is C:\Documents and Settings\username\NetHood.
		CSIDL_NETWORK					= (0x0012), // A virtual folder representing Network Neighborhood, the root of the network namespace hierarchy.
		CSIDL_PERSONAL					= (0x0005), // The file system directory used to physically store a user's common repository of documents. A typical path is 
		// C:\Documents and Settings\username\My Documents. This should be distinguished from the virtual My Documents folder in the namespace, identified by CSIDL_MYDOCUMENTS. 
		CSIDL_PRINTERS					= (0x0004), // The virtual folder containing installed printers.
		CSIDL_PRINTHOOD					= (0x001b), // The file system directory that contains the link objects that can exist in the Printers virtual folder. A typical path is C:\Documents and Settings\username\PrintHood.
		CSIDL_PROFILE					= (0x0028), // Version 5.0. The user's profile folder. A typical path is C:\Documents and Settings\username. Applications should not 
		// create files or folders at this level; they should put their data under the locations referred to by CSIDL_APPDATA or CSIDL_LOCAL_APPDATA.
		CSIDL_PROFILES					= (0x003e), // Version 6.0. The file system directory containing user profile folders. A typical path is C:\Documents and Settings.
		CSIDL_PROGRAM_FILES				= (0x0026), // Version 5.0. The Program Files folder. A typical path is C:\Program Files.
		CSIDL_PROGRAM_FILES_COMMON		= (0x002b), // Version 5.0. A folder for components that are shared across applications. A typical path is C:\Program Files\Common. 
		// Valid only for Windows NT, Windows 2000, and Windows XP systems. Not valid for Windows Millennium Edition (Windows Me).
		CSIDL_PROGRAMS					= (0x0002), // The file system directory that contains the user's program groups (which are themselves file system directories).
		// A typical path is C:\Documents and Settings\username\Start Menu\Programs. 
		CSIDL_RECENT					= (0x0008), // The file system directory that contains shortcuts to the user's most recently used documents. A typical path is 
		// C:\Documents and Settings\username\My Recent Documents. To create a shortcut in this folder, use SHAddToRecentDocs.
		// In addition to creating the shortcut, this function updates the Shell's list of recent documents and adds the shortcut 
		// to the My Recent Documents submenu of the Start menu.
		CSIDL_SENDTO					= (0x0009), // The file system directory that contains Send To menu items. A typical path is C:\Documents and Settings\username\SendTo.
		CSIDL_STARTMENU					= (0x000b), // The file system directory containing Start menu items. A typical path is C:\Documents and Settings\username\Start Menu.
		CSIDL_STARTUP					= (0x0007), // The file system directory that corresponds to the user's Startup program group. The system starts these programs 
		// whenever any user logs onto Windows NT or starts Windows 95. A typical path is C:\Documents and Settings\username\Start Menu\Programs\Startup.
		CSIDL_SYSTEM					= (0x0025), // Version 5.0. The Windows System folder. A typical path is C:\Windows\System32.
		CSIDL_TEMPLATES					= (0x0015), // The file system directory that serves as a common repository for document templates. A typical path is C:\Documents and Settings\username\Templates.
		CSIDL_WINDOWS					= (0x0024), // Version 5.0. The Windows directory or SYSROOT. This corresponds to the %windir% or %SYSTEMROOT% environment variables. A typical path is C:\Windows.
	}
	
	internal enum SHGFP_TYPE
	{
		SHGFP_TYPE_CURRENT = 0,						// current value for user, verify it exists
		SHGFP_TYPE_DEFAULT = 1						// default value, may not exist
	}

	internal enum SFGAO : uint
	{
		SFGAO_CANCOPY           = 0x00000001,	// Objects can be copied    
		SFGAO_CANMOVE           = 0x00000002,	// Objects can be moved     
		SFGAO_CANLINK           = 0x00000004,	// Objects can be linked    
		SFGAO_STORAGE           = 0x00000008,   // supports BindToObject(IID_IStorage)
		SFGAO_CANRENAME         = 0x00000010,   // Objects can be renamed
		SFGAO_CANDELETE         = 0x00000020,   // Objects can be deleted
		SFGAO_HASPROPSHEET      = 0x00000040,   // Objects have property sheets
		SFGAO_DROPTARGET        = 0x00000100,   // Objects are drop target
		SFGAO_CAPABILITYMASK    = 0x00000177,	// This flag is a mask for the capability flags.
		SFGAO_ENCRYPTED         = 0x00002000,   // object is encrypted (use alt color)
		SFGAO_ISSLOW            = 0x00004000,   // 'slow' object
		SFGAO_GHOSTED           = 0x00008000,   // ghosted icon
		SFGAO_LINK              = 0x00010000,   // Shortcut (link)
		SFGAO_SHARE             = 0x00020000,   // shared
		SFGAO_READONLY          = 0x00040000,   // read-only
		SFGAO_HIDDEN            = 0x00080000,   // hidden object
		SFGAO_DISPLAYATTRMASK   = 0x000FC000,	// This flag is a mask for the display attributes.
		SFGAO_FILESYSANCESTOR   = 0x10000000,   // may contain children with SFGAO_FILESYSTEM
		SFGAO_FOLDER            = 0x20000000,   // support BindToObject(IID_IShellFolder)
		SFGAO_FILESYSTEM        = 0x40000000,   // is a win32 file system object (file/folder/root)
		SFGAO_HASSUBFOLDER      = 0x80000000,   // may contain children with SFGAO_FOLDER
		SFGAO_CONTENTSMASK      = 0x80000000,	// This flag is a mask for the contents attributes.
		SFGAO_VALIDATE          = 0x01000000,   // invalidate cached information
		SFGAO_REMOVABLE         = 0x02000000,   // is this removeable media?
		SFGAO_COMPRESSED        = 0x04000000,   // Object is compressed (use alt color)
		SFGAO_BROWSABLE         = 0x08000000,   // supports IShellFolder, but only implements CreateViewObject() (non-folder view)
		SFGAO_NONENUMERATED     = 0x00100000,   // is a non-enumerated object
		SFGAO_NEWCONTENT        = 0x00200000,   // should show bold in explorer tree
		SFGAO_CANMONIKER        = 0x00400000,   // defunct
		SFGAO_HASSTORAGE        = 0x00400000,   // defunct
		SFGAO_STREAM            = 0x00400000,   // supports BindToObject(IID_IStream)
		SFGAO_STORAGEANCESTOR   = 0x00800000,   // may contain children with SFGAO_STORAGE or SFGAO_STREAM
		SFGAO_STORAGECAPMASK    = 0x70C50008    // for determining storage capabilities, ie for open/save semantics

	}

	internal enum SHCONTF
	{
		SHCONTF_FOLDERS             = 0x0020,   // only want folders enumerated (SFGAO_FOLDER)
		SHCONTF_NONFOLDERS          = 0x0040,   // include non folders
		SHCONTF_INCLUDEHIDDEN       = 0x0080,   // show items normally hidden
		SHCONTF_INIT_ON_FIRST_NEXT  = 0x0100,   // allow EnumObject() to return before validating enum
		SHCONTF_NETPRINTERSRCH      = 0x0200,   // hint that client is looking for printers
		SHCONTF_SHAREABLE           = 0x0400,   // hint that client is looking sharable resources (remote shares)
		SHCONTF_STORAGE             = 0x0800,   // include all items with accessible storage and their ancestors
	}

	internal enum SHCIDS : uint
	{
		SHCIDS_ALLFIELDS        = 0x80000000,	// Compare all the information contained in the ITEMIDLIST structure, not just the display names
		SHCIDS_CANONICALONLY    = 0x10000000,	// When comparing by name, compare the system names but not the display names. 
		SHCIDS_BITMASK          = 0xFFFF0000,
		SHCIDS_COLUMNMASK       = 0x0000FFFF
	}

	internal enum SHGNO
	{
		SHGDN_NORMAL             = 0x0000,		// default (display purpose)
		SHGDN_INFOLDER           = 0x0001,		// displayed under a folder (relative)
		SHGDN_FOREDITING         = 0x1000,		// for in-place editing
		SHGDN_FORADDRESSBAR      = 0x4000,		// UI friendly parsing name (remove ugly stuff)
		SHGDN_FORPARSING         = 0x8000		// parsing name for ParseDisplayName()
	} 

	internal enum STRRET_TYPE
	{
		STRRET_WSTR      = 0x0000,				// Use ShellStringReturnStructure.pOleStr
		STRRET_OFFSET    = 0x0001,				// Use ShellStringReturnStructure.uOffset to Ansi
		STRRET_CSTR      = 0x0002				// Use ShellStringReturnStructure.cStr
	}

	internal enum SHIL
	{
		SHIL_LARGE =          0,   // normally 32x32
		SHIL_SMALL =          1,  // normally 16x16
		SHIL_EXTRALARGE =     2,
		SHIL_SYSSMALL =       3   // like SHIL_SMALL, but tracks system small icon metric correctly
	}
	#endregion

	#region Structures
	[StructLayout(LayoutKind.Sequential, Pack=1)] internal struct ShellQueryRecycledBinInformationStructure
	{
		internal ShellQueryRecycledBinInformationStructure (bool valueToUse)
		{
			valueToUse	= !valueToUse;
			i32cbSize	= Marshal.SizeOf(typeof (ShellQueryRecycledBinInformationStructure));
			i64Size		= 0;
			i64NumItems	= 0;
		}

		private Int32 i32cbSize;				// Size of the structure, in bytes. This member must be filled in prior to calling the function
		private Int64 i64Size;					// Total size of all the objects in the specified Recycle Bin, in bytes
		private Int64 i64NumItems;				// Total number of items in the specified Recycle Bin

		#region Properties
		public Int32 SizeOn32Bits
		{
			get { return i32cbSize; }
			set { i32cbSize = value; }
		}
		public Int64 SizeOn64Bits
		{
			get { return i64Size; }
			set { i64Size = value; }
		}
		public Int64 NumberOfItems
		{
			get { return i64NumItems; }
			set { i64NumItems = value; }
		}
		#endregion
	};

	[StructLayout(LayoutKind.Sequential)]public struct ShellFileInformationStructure
	{
		public ShellFileInformationStructure(bool valueToUse)
		{
			valueToUse	= !valueToUse;
			hIcon=IntPtr.Zero;
			iIcon=0;
			dwAttributes=0;
			szDisplayName="";
			szTypeName="";
		}
		private IntPtr hIcon;
		private int iIcon;
		private uint dwAttributes;
		[MarshalAs(UnmanagedType.LPStr, SizeConst=260)]private string szDisplayName;
		[MarshalAs(UnmanagedType.LPStr, SizeConst=80)]private string szTypeName;

		#region FxCop Warning
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		public override int GetHashCode() 
		{
			return base.GetHashCode();
		}

		public static bool operator ==(ShellFileInformationStructure obj1, ShellFileInformationStructure obj2)
		{
			return Object.Equals (obj1, obj2);
		}

		public static bool operator !=(ShellFileInformationStructure obj1, ShellFileInformationStructure obj2)
		{
			return !Object.Equals (obj1, obj2);
		}
		#endregion

		#region Properties
		public IntPtr IconHandle
		{
			get { return hIcon; }
			set { hIcon = value; }
		}
		public int Icon
		{
			get { return iIcon; }
			set { iIcon = value; }
		}
		//public uint Attributes
		public int Attributes	// Use int for CLS Compliant option
		{
			get { return (int)dwAttributes; }
			set { dwAttributes = (uint)value; }
		}
		public string DisplayName
		{
			get { return szDisplayName; }
			set { szDisplayName = value; }
		}
		public string TypeName
		{
			get { return szTypeName; }
			set { szTypeName = value; }
		}
		#endregion
	};
	#endregion

	public sealed class ShellApiNativeMethods
	{
		private ShellApiNativeMethods () {}

		//internal static Int16 GetHResultCode(Int32 hr)		{ hr = hr & 0x0000ffff; return (Int16)hr; }

		// See : http://support.microsoft.com/?kbid=319350
		[DllImport("Shell32.dll")]
		internal static extern Int32		SHGetFileInfo (string pszPath, uint dwFileAttributes, out ShellFileInformationStructure psfi, uint cbfileInfo, SHGFI uFlags);
			
		//[DllImport("Shell32.dll", CharSet=CharSet.Auto)]
		//internal static extern uint		ExtractIconEx (string lpszFile, int nIconIndex, [MarshalAs(UnmanagedType.SysInt)]int[] phiconLarge, [MarshalAs(UnmanagedType.SysInt)]int[] phiconSmall, uint nIcons );

		[DllImport("Shell32.dll", CharSet=CharSet.Auto)]
		internal static extern /*IntPtr*/int ExtractIcon		([MarshalAs(UnmanagedType.SysInt)]int instanceHandle, string executableFileName, int iconIndex);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DestroyIcon	([MarshalAs(UnmanagedType.SysInt)]int iconHandle);

		[DllImport("shell32.dll")]
		internal static extern Int32	SHEmptyRecycleBin	([MarshalAs(UnmanagedType.SysInt)]int windowHandleOwner, [MarshalAs(UnmanagedType.LPWStr)]String path, SHERB flags);
		
		[DllImport("shell32.dll")]
		internal static extern Int32	SHQueryRecycleBin	([MarshalAs(UnmanagedType.LPWStr)]String path, ref ShellQueryRecycledBinInformationStructure shellQueryRBInfo);


		// Retrieves a pointer to the Shell's IMalloc interface.
		//[DllImport("shell32.dll")]internal static extern Int32 SHGetMalloc(out /*IntPtr*/int hObject);	// Address of a pointer that receives the Shell's IMalloc interface pointer. 

		// Retrieves the path of a folder as an PIDL.
		//[DllImport("shell32.dll")]internal static extern Int32 SHGetFolderLocation(
		//		/*IntPtr*/int windowHandleOwner,												// Handle to the owner window.
		//		Int32 nFolder,													// A CSIDL value that identifies the folder to be located.
		//		/*IntPtr*/int hToken,													// Token that can be used to represent a particular user.
		//		UInt32 dwReserved,												// Reserved.
		//		out /*IntPtr*/int ppidl);												// Address of a pointer to an item identifier list structure specifying the folder's location relative to the root of the namespace (the desktop). 

		// Converts an item identifier list to a file system path. 
		//[DllImport("shell32.dll")]internal static extern Int32 SHGetPathFromIDList(
		//		/*IntPtr*/int pidl,													// Address of an item identifier list that specifies a file or directory location relative to the root of the namespace (the desktop). 
		//		StringBuilder pszPath);											// Address of a buffer to receive the file system path.
			
		// Takes the CSIDL of a folder and returns the pathname.
		//[DllImport("shell32.dll")]internal static extern Int32 SHGetFolderPath(
		//		/*IntPtr*/int windowHandleOwner,												// Handle to an owner window.
		//		Int32 nFolder,													// A CSIDL value that identifies the folder whose path is to be retrieved.
		//		/*IntPtr*/int hToken,													// An access token that can be used to represent a particular user.
		//		UInt32 dwFlags,													// Flags to specify which path is to be returned. It is used for cases where the folder associated with a CSIDL may be moved or renamed by the user. 
		//		StringBuilder pszPath);											// Pointer to a null-terminated string which will receive the path.

		// Translates a Shell namespace object's display name into an item identifier list and returns the attributes 
		// of the object. This function is the preferred method to convert a string to a pointer to an item identifier list (PIDL). 
		//[DllImport("shell32.dll")]internal static extern Int32 SHParseDisplayName(
		//		[MarshalAs(UnmanagedType.LPWStr)]String pszName,				// Pointer to a zero-terminated wide string that contains the display name to parse. 
		//		/*IntPtr*/int pbc,														// Optional bind context that controls the parsing operation. This parameter is normally set to NULL.
		//		out /*IntPtr*/int ppidl,												// Address of a pointer to a variable of type ITEMIDLIST that receives the item identifier list for the object.
		//		UInt32 sfgaoIn,													// ULONG value that specifies the attributes to query.
		//		out UInt32 psfgaoOut);											// Pointer to a ULONG. On return, those attributes that are true for the object and were requested in sfgaoIn will be set. 

		// Retrieves the IShellFolder interface for the desktop folder, which is the root of the Shell's namespace. 
		//[DllImport("shell32.dll")]internal static extern Int32 SHGetDesktopFolder(out /*IntPtr*/int ppshf);		// Address that receives an IShellFolder interface pointer for the desktop folder.

		// This function takes the fully-qualified pointer to an item identifier list (PIDL) of a namespace object, and returns a specified interface pointer on the parent object.
		//[DllImport("shell32.dll")]internal static extern Int32 SHBindToParent(
		//		/*IntPtr*/int pidl,													// The item's PIDL. 
		//		[MarshalAs(UnmanagedType.LPStruct)]Guid riid,					// The REFIID of one of the interfaces exposed by the item's parent object. 
		//		out /*IntPtr*/int ppv,													// A pointer to the interface specified by riid. You must release the object when you are finished. 
		//		ref /*IntPtr*/int ppidlLast);											// The item's PIDL relative to the parent folder. This PIDL can be used with many
		// of the methods supported by the parent folder's interfaces. If you set ppidlLast to NULL, the PIDL will not be returned. 

		// Accepts a ShellStringReturnStructure structure returned by IShellFolder::GetDisplayNameOf that contains or points to a string, and then returns that string as a BSTR.
		//[DllImport("shlwapi.dll")]internal static extern Int32 StrRetToBSTR(
		//		ref ShellStringReturnStructure pstr,												// Pointer to a ShellStringReturnStructure structure.
		//		/*IntPtr*/int pidl,													// Pointer to an ITEMIDLIST uniquely identifying a file object or subfolder relative to the parent folder.
		//		[MarshalAs(UnmanagedType.BStr)]out String pbstr);				// Pointer to a variable of type BSTR that contains the converted string.
		//		*/

		// Takes a ShellStringReturnStructure structure returned by IShellFolder::GetDisplayNameOf, converts it to a string, and places the result in a buffer. 
		//[DllImport("shlwapi.dll")]internal static extern Int32 StrRetToBuf(
		//		ref ShellStringReturnStructure pstr,												// Pointer to the ShellStringReturnStructure structure. When the function returns, this pointer will no longer be valid.
		//		/*IntPtr*/int pidl,													// Pointer to the item's ITEMIDLIST structure.
		//		StringBuilder pszBuf,											// Buffer to hold the display name. It will be returned as a null-terminated string. If cchBuf is too small, the name will be truncated to fit. 
		//		UInt32 cchBuf);													// Size of pszBuf, in characters. If cchBuf is too small, the string will be truncated to fit. 
	}

	/// <summary>
	/// User32ApiNativeMethods dll access
	/// </summary>
	public sealed class User32ApiNativeMethods
	{
		private User32ApiNativeMethods () {}

		//public const int SM_CXSCREEN=0;
		//public const int SM_CYSCREEN=1;

		[DllImport("user32.dll", EntryPoint="GetDesktopWindow")]		internal static extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll",EntryPoint="GetDC")]					internal static extern IntPtr GetDC(IntPtr windowHandle);
		//[DllImport("user32.dll",EntryPoint="GetSystemMetrics")]			internal static extern int GetSystemMetrics(int abc);
		//[DllImport("user32.dll",EntryPoint="GetWindowDC")]				internal static extern IntPtr GetWindowDC(Int32 ptr);
		[DllImport("user32.dll",EntryPoint="ReleaseDC")]				internal static extern int ReleaseDC(IntPtr windowHandle, IntPtr handleDeviceContext);

		//[DllImport("user32.dll")]
		//internal static extern bool		IsIconic				([MarshalAs(UnmanagedType.SysInt)]int windowHandle);
		
		//[DllImport("user32.dll")]
		//[return: MarshalAs(UnmanagedType.Bool)]
		//internal static extern bool		IsZoomed				([MarshalAs(UnmanagedType.SysInt)]int windowHandle);
		
		//[DllImport("user32.dll")]
		//[return: MarshalAs(UnmanagedType.Bool)]
		//internal static extern bool		IsWindowVisible			(int windowHandle);
		
		[DllImport("USER32.DLL", EntryPoint= "GetCaretBlinkTime")]		internal static extern uint		GetCaretBlinkTime		();
		
		//[DllImport("user32.dll")]
		//internal static extern bool		GetClientRect			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, ref RECT rect);
		
		//[DllImport("user32.dll")]
		//internal static extern /*IntPtr*/int	GetParent				([MarshalAs(UnmanagedType.SysInt)]int windowHandle);

		//[DllImport("user32.dll")]
		//internal static extern int		GetWindowLong			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, int index);

		//[DllImport("user32.dll")]
		//internal static extern /*IntPtr*/int	GetForegroundWindow		();

		[DllImport("user32.dll")]
		internal static extern /*IntPtr*/int	GetWindowThreadProcessId([MarshalAs(UnmanagedType.SysInt)]int windowHandle, [MarshalAs(UnmanagedType.SysInt)]int processIdentifier);

		[DllImport("user32.dll")]
		internal static extern int		GetWindowText			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, StringBuilder title, int size);

		[DllImport("user32.dll")]
		internal static extern int		GetClassName			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, StringBuilder title, int size);
		//internal static extern int		GetClassName			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, StringBuilder title, int size);
		//internal static extern int		GetClassName			(IntPtr windowHandle, StringBuilder title, int size);

		[DllImport("user32.dll")]
		internal static extern int		GetWindowModuleFileName	([MarshalAs(UnmanagedType.SysInt)]int windowHandle, StringBuilder title, int size);

		//[DllImport("user32.dll")]
		//internal static extern bool		SetForegroundWindow		([MarshalAs(UnmanagedType.SysInt)]int windowHandle);
		//[DllImport("user32.dll")]
		//internal static extern /*IntPtr*/int	SetParent				([MarshalAs(UnmanagedType.SysInt)]int windowHandle, [MarshalAs(UnmanagedType.SysInt)]int windowsHandle2);
		//[DllImport("user32.dll")]
		//internal static extern bool		SetWindowPos			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, [MarshalAs(UnmanagedType.SysInt)]int windowsHandleInsertAfter, int positionOnX, int positionOnY, int width, int height, int flags);
		//[DllImport("user32.dll")]
		//internal static extern int		SetWindowLong			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, int nIndex, int newValue);
		
		//[DllImport("user32.dll")]
		//internal static extern /*IntPtr*/int	AttachThreadInput		([MarshalAs(UnmanagedType.SysInt)]int idAttach, [MarshalAs(UnmanagedType.SysInt)]int idAttachTo, int fAttach);

		//[DllImport("user32.dll")]
		//internal static extern void		MessageBeep				(int type);
		
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool		ShowWindow				([MarshalAs(UnmanagedType.SysInt)]int windowHandle, int nCmdShow);

		//[DllImport("user32.dll")]
		//[return: MarshalAs(UnmanagedType.Bool)]
		//internal static extern bool		ShowWindowAsync			([MarshalAs(UnmanagedType.SysInt)]int windowHandle, int nCmdShow);
		
		[DllImport("user32.dll")]
		internal static extern int		EnumWindows				(EnumWindowsProc enumWindowsProc, [MarshalAs(UnmanagedType.SysInt)]int genericDoubleWordParameter); 
		
		[DllImport("user32.dll", EntryPoint= "PostMessage")]
		internal static extern int		PostMessage				(HandleRef windowHandle, uint msg, [MarshalAs(UnmanagedType.SysInt)]int genericWordParameter, [MarshalAs(UnmanagedType.SysInt)]int genericDoubleWordParameter);
		
		[DllImport("user32.dll", CharSet = CharSet.Auto )]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern int		SendMessage				([MarshalAs(UnmanagedType.SysInt)]int windowHandle, int msg, [MarshalAs(UnmanagedType.SysInt)]int genericWordParameter, [MarshalAs(UnmanagedType.SysInt)]int genericDoubleWordParameter);
		
		[DllImport("user32.dll", CharSet = CharSet.Auto )]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern int		SendMessage				(HandleRef windowHandle, int msg, [MarshalAs(UnmanagedType.SysInt)]int genericWordParameter, [MarshalAs(UnmanagedType.SysInt)]int genericDoubleWordParameter);
		
		//[DllImport("user32.dll", CharSet = CharSet.Auto )]
		//internal static extern int		SendMessage			(HandleRef windowHandle, int msg, int genericWordParameter, ref ParagraphFormat lp);
		
		//[DllImport("user32.dll", EntryPoint= "SendMessage")]
		//internal static extern int		SendMessage				(HandleRef windowHandle, int msg, [MarshalAs(UnmanagedType.SysInt)]int genericWordParameter, [MarshalAs(UnmanagedType.SysInt)]int genericDoubleWordParameter);
		
		[DllImport("user32.dll", ExactSpelling=true, SetLastError=true) ]
		internal static extern int		ExitWindowsEx			(ExitWindows exitFlags, ShutdownReason shutDownReason);
	}

	/// <summary>
	/// Summary description for ApiNativeMethods.
	/// </summary>
	public sealed class ApiNativeMethods
	{
		private ApiNativeMethods () {}

		// Use : System.Environment.OSVersion
		//[DllImport("kernel32.Dll")]		internal static extern short	GetVersionEx			(ref OperatingSystemVersionExtended o);
		
		[DllImport("kernel32.dll", ExactSpelling=true) ]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern /*IntPtr*/int	GetCurrentProcess		();
		
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern /*IntPtr*/int	LoadLibrary				(string fileName);
		
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool		FreeLibrary				([MarshalAs(UnmanagedType.SysInt)]int lib);
		//[DllImport("kernel32.dll")] 											internal static extern /*IntPtr*/int	GetStdHandle			(int handle);
		//[DllImport("kernel32.dll")] 											internal static extern bool		SetStdHandle			(int handle1, [MarshalAs(UnmanagedType.SysInt)]int handle2);
		//[DllImport("kernel32.dll", SetLastError=true)]							internal static extern int		GetComputerName			(StringBuilder text, int size);
		
		// Disk manage
		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		internal static extern int		GetDriveType			(string rootPathName);

		[DllImport("kernel32.dll")]
		internal static extern uint		GetVolumeInformation	(string pathName, StringBuilder volumeNameBuffer, int volumeNameSize, out uint volumeSerialNumber, out uint maximumComponentLength, out uint fileSystemFlags, StringBuilder fileSystemNameBuffer, int fileSystemNameSize);

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool		GetDiskFreeSpace		(string rootPathName, out uint sectorsPerCluster, out uint bytesPerSector, out uint numberOfFreeClusters, out uint totalNumberOfClusters);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		internal static extern int		GetShortPathName		([MarshalAs(UnmanagedType.LPTStr)]string path, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder shortPath, int shortPathLength);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		internal static extern int		GetLongPathName			([MarshalAs(UnmanagedType.LPTStr)]string path, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder longPath, int longPathLength);

		// Console specific
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern int	GetConsoleWindow			();

		//[DllImport("kernel32.dll")] 											internal static extern int		GetConsoleCP					();
		//[DllImport("kernel32.dll")] 											internal static extern int		GetConsoleOutputCP				();
		//[DllImport("kernel32.dll")] 											internal static extern bool		GetConsoleMode					([MarshalAs(UnmanagedType.SysInt)]int handle, out int flags);
		//[DllImport("kernel32.dll")] 											internal static extern bool		GetConsoleScreenBufferInfo		([MarshalAs(UnmanagedType.SysInt)]int consoleOutput, out ConsoleScreenBufferInfo info);
		//[DllImport("kernel32.dll")] 											internal static extern bool		GetConsoleTitle					(StringBuilder text, int size);
		//[DllImport("kernel32.dll")] 											internal static extern int		SetConsoleCursorPosition		([MarshalAs(UnmanagedType.SysInt)]int buffer, Coord position);
		//[DllImport("kernel32.dll")] 											internal static extern bool		SetConsoleTextAttribute			([MarshalAs(UnmanagedType.SysInt)]int hConsoleOutput, ConsoleColor wAttributes);
		//[DllImport("kernel32.dll")] 											internal static extern bool		SetConsoleTitle					(string lpConsoleTitle);
		//[DllImport("kernel32.dll")] 											internal static extern bool		SetConsoleCtrlHandler			(HandlerRoutine routine, bool add);
		//[DllImport("kernel32.dll")] 											internal static extern bool		SetConsoleActiveScreenBuffer	([MarshalAs(UnmanagedType.SysInt)]int handle);
		//[DllImport("kernel32.dll")] 											internal static extern bool		AllocConsole					();
		//[DllImport("kernel32.dll")] 											internal static extern bool		FreeConsole						();
		//[DllImport("kernel32.dll")] 											internal static extern /*IntPtr*/int	CreateConsoleScreenBuffer		(int access, int share, [MarshalAs(UnmanagedType.SysInt)]int security, int flags, [MarshalAs(UnmanagedType.SysInt)]int reserved);
		//[DllImport("kernel32.dll")] 											internal static extern int		FillConsoleOutputCharacter		([MarshalAs(UnmanagedType.SysInt)]int buffer, char character, int length, Coord position, out int written);
		//[DllImport("kernel32.dll")] 											internal static extern bool		WriteConsole					([MarshalAs(UnmanagedType.SysInt)]int handle, string s, int length, out int written, [MarshalAs(UnmanagedType.SysInt)]int reserved);


		// Security privileges
		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool		OpenProcessToken		([MarshalAs(UnmanagedType.SysInt)]int handle, int acc, ref /*IntPtr*/int phtok);
		
		[DllImport("advapi32.dll", SetLastError=true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool		LookupPrivilegeValue	(string host, string name, ref long pluid);

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool		AdjustTokenPrivileges	([MarshalAs(UnmanagedType.SysInt)]int tokenHandle, [MarshalAs(UnmanagedType.Bool)]bool disall, ref TokenPrivileges newst, int len, [MarshalAs(UnmanagedType.SysInt)]int prev, [MarshalAs(UnmanagedType.SysInt)]int relen);

		[DllImport("advapi32.dll", EntryPoint="ClearEventLog")]
		internal static extern int		ClearEventLogA			([MarshalAs(UnmanagedType.SysInt)]int EventLog, string backupFileName);
		
		[DllImport("advapi32.dll", EntryPoint="OpenEventLog")]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern int		OpenEventLogA			(string universalNamingConventionServerName, string sourceName);
		
		[DllImport("advapi32.dll", EntryPoint="CloseEventLog")]
		internal static extern int		CloseEventLog			([MarshalAs(UnmanagedType.SysInt)]int EventLog);
	}
}