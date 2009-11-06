using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;		// DllImport
using System.Globalization;

namespace Nolme.Core
{
	/// <summary>
	/// Summary description for PathFileAndArguments.
	/// </summary>
	public class PathFileAndArguments
	{
		private string m_OriginalString;
		private string m_PathNameOnly;
		private string []m_PathNameOnlyArray;
		private string m_FileNameWithExtensionOnly;
		private string m_Arguments;
		private string []m_ArgumentArray;

		public  PathFileAndArguments () {}
		public  PathFileAndArguments (string bufferToManage)
		{
			m_OriginalString = bufferToManage;
		}

		#region Properties
		public string OriginalString
		{
			get {return m_OriginalString;}
			set {m_OriginalString = value; }
		}
		public string PathNameOnly
		{
			get {return m_PathNameOnly;}
			set {m_PathNameOnly = value; }
		}
		public string FileNameWithExtensionOnly
		{
			get {return m_FileNameWithExtensionOnly;}
			set {m_FileNameWithExtensionOnly = value; }
		}
		public string Arguments
		{
			get {return m_Arguments;}
			set {m_Arguments = value; }
		}

		
		public string [] GetArgumentArray ()
		{
			return m_ArgumentArray;
		}

		public string[] GetPathNameOnlyArray ()
		{
			return m_PathNameOnlyArray;
		}

		public void AssignArgumentArray (string[]itemArray)
		{
			if (itemArray != null)
				m_ArgumentArray = itemArray;
		}

		public void AssignPathNameOnlyArray (string[]itemArray)
		{
			if (itemArray != null)
				m_PathNameOnlyArray = itemArray;
		}
		

		#endregion

		#region Split functions
		public void ConvertLocalPathToArray ()
		{
			m_PathNameOnlyArray = DirectoryUtility.SplitLocalPath (m_PathNameOnly);
		}
		public void ConvertRelativePathToArray ()
		{
			m_PathNameOnlyArray = DirectoryUtility.SplitRelativePath (m_PathNameOnly);
		}

		public void ConvertArgumentsToArray ()
		{
			m_ArgumentArray	= StringUtility.GetWordArray2 (m_Arguments);
		}
		#endregion
		
		#region Oter functions
		public void Reset ()
		{
			m_OriginalString			= null;
			m_PathNameOnly				= null;
			m_PathNameOnlyArray			= null;
			m_FileNameWithExtensionOnly	= null;
			m_Arguments					= null;
			m_ArgumentArray				= null;
		}
		#endregion
	}

	#region DirectoryStats
	/// <summary>
	/// Summary description for DirectoryStats.
	/// </summary>
	public class DirectoryStats
	{
		private int		m_NumberOfFilesFound;
		private int		m_NumberOfFilesDeleted;
		private long	m_AllFilesSize;
		private long	m_DeletedFilesSize;
		private int		m_NumberOfDirectoriesFound;
		private int		m_NumberOfDirectoriesDeleted;

		public DirectoryStats ()
		{
			Init ();
		}
		public void Init ()
		{
			m_NumberOfFilesFound			= 0;
			m_NumberOfFilesDeleted			= 0;
			m_AllFilesSize					= 0;
			m_DeletedFilesSize				= 0;
			m_NumberOfDirectoriesFound		= 0;
			m_NumberOfDirectoriesDeleted	= 0;
		}

		#region Properties
		public int		NumberOfFilesFound
		{
			get { return m_NumberOfFilesFound;}
			set { m_NumberOfFilesFound = value; }
		}
		public int		NumberOfFilesDeleted
		{
			get { return m_NumberOfFilesDeleted;}
			set { m_NumberOfFilesDeleted = value; }
		}
		public long		AllFilesSize
		{
			get { return m_AllFilesSize;}
			set { m_AllFilesSize = value; }
		}
		public long		DeletedFilesSize
		{
			get { return m_DeletedFilesSize;}
			set { m_DeletedFilesSize = value; }
		}
		public int		NumberOfDirectoriesFound
		{
			get { return m_NumberOfDirectoriesFound;}
			set { m_NumberOfDirectoriesFound = value; }
		}
		public int		NumberOfDirectoriesDeleted
		{
			get { return m_NumberOfDirectoriesDeleted;}
			set { m_NumberOfDirectoriesDeleted = value; }
		}
		#endregion
	};
	#endregion

	/// <summary>
	/// Summary description for DirectoryUtility.
	/// </summary>
	public sealed class DirectoryUtility
	{
		public const int MaxPath = 260;					/// <summary>Maximum path length</summary>

		private DirectoryUtility() {}

		#region Methods - Is ()
		/// <summary>
		/// Check if a directory is empty from files & subdirectories
		/// </summary>
		public static bool IsEmpty (string sourcePath)
		{
			bool BooleanResult;
			FileInfo[]		aoFiles			= GetFiles (sourcePath);
			DirectoryInfo[] aoDirectories	= GetDirectories (sourcePath);
			int				iCount			= aoFiles.Length + aoDirectories.Length;

			if (iCount == 0)
				BooleanResult = true;
			else
				BooleanResult = false;
			return BooleanResult;
		}

		/// <summary>
		/// Check path contain a good drive letter information
		/// This function don't check drive existence
		/// </summary>
		public static bool IsValidPathDriveLetter (string pathToCheck)
		{
			if (pathToCheck == null)		throw new NolmeArgumentNullException ();

			if (pathToCheck.Length < 3)
				return false;

			/*if (pathToCheck[1] != ':')
				return false;*/
			if (Path.VolumeSeparatorChar != pathToCheck[1]) 
				return false;
			/*if (Path.DirectorySeparatorChar != pathToCheck[2]) 
				return false;*/
			if ((pathToCheck[2] != '\\') && (pathToCheck[2] != '/'))
				return false;
			if (((pathToCheck[0] >= 'A') && (pathToCheck[0] <= 'Z')) ||
				((pathToCheck[0] >= 'a') && (pathToCheck[0] <= 'z')))
				return true;
			return false;
		}

		public static bool IsValidStartingPath (string pathToCheck)
		{
			string StartingPath = DirectoryUtility.GetValidStartingPath (pathToCheck);
			return StringUtility.IsValid (StartingPath);
		}

		public static string GetValidStartingPath (string pathToCheck)
		{
			if (pathToCheck == null)			throw new NolmeArgumentNullException ();

			bool BooleanResult = DirectoryUtility.IsValidPathDriveLetter (pathToCheck);
			string StartingPathOut;

			if (!BooleanResult)
			{
				StartingPathOut = StringUtility.CreateEmptyString ();

				// Check ./ path type
				if (pathToCheck.Length >= 2)
				{
					if ((pathToCheck[0] == '.') &&  ((pathToCheck[1] == '/') || (pathToCheck[1] == '\\')))
					{
						// Save starting path with / or \ 
						StartingPathOut = pathToCheck.Substring (0, 2);
						BooleanResult	= true;
					}
				}

				// Check ../ path type
				if (pathToCheck.Length >= 3)
				{
					if ((pathToCheck[0] == '.') &&  (pathToCheck[1] == '.') && ((pathToCheck[2] == '/') || (pathToCheck[2] == '\\')))
					{
						// Save starting path with / or \ 
						StartingPathOut = pathToCheck.Substring (0, 3);
						BooleanResult	= true;
					}
				}
			}
			else
			{
				StartingPathOut = pathToCheck.Substring (0, 3);
			}
			return StartingPathOut;
		}

		/*
		/// <summary>
		/// Check is a file exists in a specified directory
		/// </summary>
		/// <param name="sourcePath">Source path to check in</param>
		/// <param name="sourceFileName">Filename to check existence</param>
		/// <returns></returns>
		public static bool IsFileExist (string sourcePath, string sourceFileName)
		{

			int  iCount;
			bool BooleanResult = IsFileExist (sourcePath, sourceFileName, out iCount);
			return BooleanResult;
		}

		public static bool GetFileCount (string sourcePath, string sourceFileName, out int fileCountOut)
		{
			int			i;
			FileInfo[]	aoAllFiles = DirectoryUtility.GetFiles (sourcePath);

			for (i = 0; i < aoAllFiles.Length; i++)
			{
				if (string.Compare (aoAllFiles [i].Name, sourceFileName, true, CultureInfo.InvariantCulture) == 0)
					break;
			}
			if (i == aoAllFiles.Length)
			{
				// Nor found
				fileCountOut = 0;
				return false;
			}
			fileCountOut = aoAllFiles.Length;
			return true;
		}
		*/
		#endregion

		#region Methods - Get ()
		/// <summary>
		/// Get all filenames in a directory
		/// </summary>
		public static FileInfo[] GetFiles (string sourcePath)
		{
			FileInfo[]	oFileList;
			string		szSrcPath = SetCorrectDirectory (sourcePath);

			if (!Directory.Exists(szSrcPath))
			{
				oFileList = null;
			}
			else
			{
				DirectoryInfo dirFinder = new DirectoryInfo(sourcePath);
				//DirectoryInfo[] dirList = dirFinder.GetDirectories();
				oFileList				= dirFinder.GetFiles();
			}
			return oFileList;
		}

		/// <summary>
		/// Get filenames in a directory
		/// </summary>
		public static FileInfo[] GetFiles (string sourcePath, string searchPatternFilter)
		{
			FileInfo[]	oFileList;
			string		szSrcPath = SetCorrectDirectory (sourcePath);

			if (!Directory.Exists(szSrcPath))
			{
				oFileList = null;
			}
			else
			{
				DirectoryInfo dirFinder = new DirectoryInfo(sourcePath);
				//DirectoryInfo[] dirList = dirFinder.GetDirectories();
				oFileList				= dirFinder.GetFiles(searchPatternFilter);
			}
			return oFileList;
		}

		/// <summary>
		/// Get all directories inside a directory
		/// </summary>
		public static DirectoryInfo[] GetDirectories (string sourcePath)
		{
			return DirectoryUtility.GetDirectories (sourcePath, "*.*");
		}

		/// <summary>
		/// Get all directories inside a directory
		/// </summary>
		public static DirectoryInfo[] GetDirectories (string sourcePath, string searchPatternFilter)
		{
			DirectoryInfo[]	oDirList;
			string			szSrcPath = SetCorrectDirectory (sourcePath);

			if (!Directory.Exists(szSrcPath))
			{
				oDirList = new DirectoryInfo[0];	// Allocate object with no directory inside
			}
			else
			{
				DirectoryInfo dirFinder = new DirectoryInfo(sourcePath);
				oDirList				= dirFinder.GetDirectories(searchPatternFilter);
			}
			return oDirList;
		}

		/// <summary>
		/// Get the size in bytes of a directory
		/// </summary>
		public static long GetDirectorySize (string sourcePath)
		{
			long	size = GetDirectorySize (sourcePath, "*.*", true);
			return size;
		}

		/// <summary>
		/// Get the size in bytes of a directory
		/// </summary>
		public static long GetDirectorySize (string sourcePath, string fileFilter, bool recurseSubfolders)
		{
			if (sourcePath == null)		throw new NolmeArgumentNullException ();

			DirectoryInfo	dirInfo = new DirectoryInfo(sourcePath);
			long			size	= GetDirectorySize (dirInfo, fileFilter, recurseSubfolders);
			return size;
		}

		/// <summary>
		/// Get the size in bytes of a directory
		/// </summary>
		public static long GetDirectorySize (DirectoryInfo directoryInfo, string fileFilter)
		{
			long	total	= GetDirectorySize (directoryInfo, fileFilter, true);
			return total;
		}

		/// <summary>
		/// Get the size in bytes of a directory
		/// </summary>
		public static long GetDirectorySize (DirectoryInfo directoryInfo, string fileFilter, bool recurseSubfolders)
		{
			if (directoryInfo == null)		throw new NolmeArgumentNullException ();

			long	total	= 0;

			foreach(System.IO.FileInfo file in directoryInfo.GetFiles(fileFilter))
				total += file.Length;
  
			if (recurseSubfolders)
			{
				foreach(System.IO.DirectoryInfo dir in directoryInfo.GetDirectories())
					total += GetDirectorySize(dir, fileFilter);
			}

			return total;
		}

		/// <summary>
		/// Retrieve the number of directories in a path name or generic path
		/// </summary>
		/// <param name="pathToCheck">Folder to manage</param>
		/// <param name="countFileName">During counting, include or not filename (in last position)</param>
		/// <param name="manageFirstFolderAsDriveLetter">manage input path like path format (c:/MyFolder/) or generic format (HKLM\folder)</param>
		/// <returns>Number of directories computed</returns>
		/// manageFirstFolderAsDriveLetter == true
		///		'c:\'                           will return 0
		///		'c:\Myfolder1\MySubfolder'      will return 2
		///		'c:\Myfolder1\MySubfolder\'     will return 2 too
		///		'C:\WINDOWS\system32\calc.exe'  will return 2 (countFileName==false) OR 3 (countFileName==true)
		///		
		/// manageFirstFolderAsDriveLetter == false
		///		'c:\'                       will return 1
		///		'c:\Myfolder1\MySubfolder'  will return 3
		///		'c:\Myfolder1\MySubfolder\' will return 3
		///		
		/// TEST CODE
		/// int Count;
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\", true, true);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\Myfolder1\MySubfolder1", true, true);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\Myfolder2\MySubfolder2\", true, true);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"C:\WINDOWS\system32\calc.exe", false, true);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"C:\WINDOWS\system32\calc.exe", true, true);
		/// 
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\", true, false);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\Myfolder1\MySubfolder1", true, false);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\Myfolder2\MySubfolder2\", true, false);
		/// Count = DirectoryUtility.GetNumberOfDirectories (@"c:\My folder3\My Subfolder3\", true, false);
		/// 
		public static int GetNumberOfDirectories (string pathToCheck, bool countFileName, bool manageFirstFolderAsDriveLetter)
		{
			string	Letter;						// Path drive letter (c:\)
			string	UnixFormatDirectoryPath;	// Folder under form 'Drive:/folder' or 'Drive:/folder/'
			int		ReadOffset;					// Current read offset of '/' in pathToCheck
			int		FoundOffset;				// Offset in pathToCheck where '/' has been found
			int		DirectoryCounter;			// Final result

			if (pathToCheck == null)		throw new NolmeArgumentNullException ();

			DirectoryCounter	= 0;
			if (manageFirstFolderAsDriveLetter)
			{
				Letter				= DirectoryUtility.GetValidStartingPath (pathToCheck);
				if (!StringUtility.IsValid (Letter))
					return DirectoryCounter;
				if (pathToCheck.Length <= 3)
					return DirectoryCounter;

				ReadOffset = Letter.Length;
			}
			else
			{
				ReadOffset = 0;
			}

			UnixFormatDirectoryPath = DirectoryUtility.ConvertToUnixFormat (pathToCheck);

			// Count number of / after drive letter
			while (ReadOffset != UnixFormatDirectoryPath.Length)
			{
				FoundOffset = UnixFormatDirectoryPath.IndexOf ("/", ReadOffset, UnixFormatDirectoryPath.Length - ReadOffset);
				if (FoundOffset != -1)
				{
					// Found new '/'
					DirectoryCounter++;

					// Set next position
					ReadOffset = FoundOffset + 1;
				}
				else
				{
					// There are remaining character after ReadOffset, so it's another directory name or filename
					if (File.Exists (pathToCheck))
					{
						if (countFileName)
							DirectoryCounter++;
					}
					else if (Directory.Exists (pathToCheck))
					{
						DirectoryCounter++;
					}
					else
					{
						// Path or file not valid or not created
						// assume directory
						DirectoryCounter++;
					}

					// Leave loop
					break;
				}
			}
			return DirectoryCounter;
		}
		#endregion

		#region Methodes - Remove,Copy & Empty directory
		/*
		/// <summary>
		/// Remove all files in a directory
		/// </summary>
		public static bool RemoveOnlyFiles (string sourcePath, bool recurseSubfolders, ref DirectoryStats directoryStatisticsOut)
		{
			bool	BooleanResult = DirectoryUtility.ParseOnlyFiles (sourcePath, "*.*", recurseSubfolders, true, ref directoryStatisticsOut);
			return BooleanResult;
		}

		/// <summary>
		/// Remove all files according to filter in a directory
		/// </summary>
		public static bool RemoveOnlyFiles (string sourcePath, string fileFilter, bool recurseSubfolders, ref DirectoryStats directoryStatisticsOut)
		{
			bool	BooleanResult = DirectoryUtility.ParseOnlyFiles (sourcePath, fileFilter, recurseSubfolders, true, ref directoryStatisticsOut);
			return BooleanResult;
		}
		*/

		public static void RemoveAllFiles (string sourcePath)
		{
			if (sourcePath == null)		throw new NolmeArgumentNullException ();

			// Remove all files
			FileInfo		[]aoFiles		= DirectoryUtility.GetFiles (sourcePath);
			for (int i = 0; i < aoFiles.Length; i++)
			{
				// Remove read only attribute
				File.SetAttributes (aoFiles[i].FullName, FileAttributes.Normal);

				// Delete
				aoFiles[i].Delete ();
			}
		}
		
		/// <summary>
		/// Empty a directory of all subdirectories & files
		/// <param name="sourcePath">Source path to empty</param>
		/// </summary>
		public static bool EmptyDirectory (string sourcePath)
		{
			bool BooleanResult    = Directory.Exists (sourcePath);
			if (BooleanResult)
			{
				// Remove files in sourcePath folder
				RemoveAllFiles (sourcePath);

				// Remove all directories in sourcePath folder
				DirectoryInfo	[]aoDirectories	= DirectoryUtility.GetDirectories (sourcePath);
				for (int j = 0; j < aoDirectories.Length; j++)
				{
					DirectoryUtility.DeleteDirectory (aoDirectories[j].FullName);
				}
			}

			/*
			string[]	Files;
			bool		BooleanResult;
			string		oInputPath, oFullPath;

			DirectoryUtility.RemoveReadOnlyToAllChilds (sourcePath);
			oInputPath = DirectoryUtility.SetCorrectDirectory (sourcePath);
			BooleanResult    = Directory.Exists (oInputPath);
			if (BooleanResult)
			{
				Files = Directory.GetFileSystemEntries(oInputPath);
				foreach(string Element in Files)
				{
					// Files in directory
					oFullPath = oInputPath + Path.GetFileName (Element);
					if(Directory.Exists(Element)) 
					{
						DirectoryUtility.DeleteDirectory (oFullPath);
					}
					else
					{
						FileUtility.DeleteFile (oFullPath);
					}
				}
			}
			*/
			return BooleanResult;
		}

		/// <summary>
		/// Remove read only flag
		/// <param name="sourcePath">Source path to empty</param>
		/// </summary>
		public static void RemoveReadOnlyToAllChilds (string sourcePath)
		{
			string[]	Files;
			bool		BooleanResult;
			string		oInputPath, oFullPath;

			oInputPath = DirectoryUtility.SetCorrectDirectory (sourcePath);
			BooleanResult    = Directory.Exists (oInputPath);
			if (BooleanResult)
			{
				Files = Directory.GetFileSystemEntries(oInputPath);
				foreach(string Element in Files)
				{
					// Files in directory
					oFullPath = oInputPath + Path.GetFileName (Element);
					if(Directory.Exists(Element)) 
					{
						File.SetAttributes	(oFullPath, FileAttributes.Normal);
						RemoveReadOnlyToAllChilds (oFullPath);
					}
					else
					{
						File.SetAttributes	(oFullPath, FileAttributes.Normal);
					}
				}
			}
		}

		/// <summary>
		/// Empty a directory of all subdirectories & files
		/// <param name="sourcePath">Source path to empty</param>
		/// </summary>
		public static bool DeleteDirectory (string sourcePath)
		{
			/*
			File.SetAttributes							(sourcePath, FileAttributes.Normal);
			DirectoryUtility.RemoveReadOnlyToAllChilds	(sourcePath);
			Directory.Delete							(sourcePath, true);
			*/

			// Remove all files
			FileInfo		[]aoFiles		= DirectoryUtility.GetFiles (sourcePath);
			for (int i = 0; i < aoFiles.Length; i++)
			{
				File.SetAttributes (aoFiles[i].FullName, FileAttributes.Normal);
				aoFiles[i].Delete ();
			}

			// Recurse sub-directories
			DirectoryInfo	[]aoDirectories	= DirectoryUtility.GetDirectories (sourcePath);
			for (int j = 0; j < aoDirectories.Length; j++)
			{
				DirectoryUtility.DeleteDirectory (aoDirectories[j].FullName);
			}

			// Remove readonly on current dir
			File.SetAttributes	(sourcePath, FileAttributes.Normal);
			Directory.Delete	(sourcePath);
			return true;
		}

		/// <summary>
		/// Copy a directory into another
		/// <param name="sourcePath">Source path for copy</param>
		/// <param name="destinationPath">Destination path</param>
		/// </summary>
		public static bool CopyDirectory (string sourcePath, string destinationPath)
		{
			string[]	Files;
			bool		BooleanResult;
			string		DestinationPath;

			DestinationPath = DirectoryUtility.SetCorrectDirectory (destinationPath);
			if(!Directory.Exists(DestinationPath))
				Directory.CreateDirectory(DestinationPath);

			Files			= Directory.GetFileSystemEntries(sourcePath);
			BooleanResult	= true;
			foreach(string Element in Files)
			{
				// Sub directories
				if(Directory.Exists(Element)) 
				{
					// Recurse
					DirectoryUtility.CopyDirectory (Element, DestinationPath + Path.GetFileName(Element));
				}
				else 
				{
					// Files in directory
					File.Copy (Element, DestinationPath + Path.GetFileName(Element), true);
				}
			}
			return BooleanResult;
		}

		#endregion

		#region Conversion
		/// <summary>
		/// Add directory terminaison
		/// <param name="sourcePath">Source path to correct</param>
		/// </summary>
		public static string SetCorrectDirectory (string sourcePath)
		{
			if (sourcePath == null)		throw new NolmeArgumentNullException ();

			string oPathNoSpace = ConvertToWindowsFormat(sourcePath.Trim ());
			string oCorrectPath;

			if (oPathNoSpace.EndsWith ("\\"))
			{
				// Nothing to do
				oCorrectPath = oPathNoSpace;
			}
			else
			{
				oCorrectPath = oPathNoSpace + "\\";
			}
			return oCorrectPath;
		}

		/// <summary>
		/// Convert a path like 'c:/Myfolder1/MySubfolder' to 'c:\\Myfolder1\\MySubfolder'
		/// </summary>
		public static string ConvertToWindowsFormat (string pathToConvert)
		{
			if (pathToConvert == null)		throw new NolmeArgumentNullException ();

			string szResult = pathToConvert.Replace ("/", "\\");
			return szResult;
		}


		/// <summary>
		/// Convert a path like 'c:/Myfolder1/MySubfolder' to 'c:/Myfolder1/MySubfolder'
		/// </summary>
		public static string ConvertToUnixFormat (string pathToConvert)
		{
			if (pathToConvert == null)		throw new NolmeArgumentNullException ();

			string szResult = pathToConvert.Replace ("\\", "/");
			return szResult;
		}
		#endregion

		#region Methods - Split
		/// <summary>
		/// Split a path under form 'c:\\Myfolder1\\MySubfolder' or 'c:/MyFolder1/MySubfolder'
		/// to an array of folder name ('c:\\', 'Myfolder1', 'MySubfolder')
		/// </summary>
		/// <param name="sourcePathToSplit">Path to split</param>
		/// <returns>Directories and filename</returns>
		/// 
		/// TEST CODE
		/// string[]	FolderArray;
		/// FolderArray = DirectoryUtility.SplitLocalPath (@"c:\Myfolder1\MySubfolder1");
		/// FolderArray = DirectoryUtility.SplitLocalPath (@"c:\Myfolder3\MySubfolder3\toto.exe");
		/// 
		public static string[] SplitLocalPath (string sourcePathToSplit)
		{
			return DirectoryUtility.SplitGenericPath (sourcePathToSplit, true);
		}

		/// <summary>
		/// Split a path under form 'Myfolder1\\MySubfolder' or 'MyFolder1/MySubfolder'
		/// to an array of folder name ('Myfolder1', 'MySubfolder')
		/// </summary>
		/// <param name="sourcePathToSplit">Path to split</param>
		/// <returns>Directories and filename</returns>
		/// 
		/// TEST CODE
		/// string[]	FolderArray;
		/// FolderArray = DirectoryUtility.SplitRelativePath (@"CurrentUser\SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
		/// FolderArray = DirectoryUtility.SplitRelativePath (@".\toto\toto.exe");
		/// FolderArray = DirectoryUtility.SplitRelativePath (@"..\..\./toto.exe");
		/// 
		public static string[] SplitRelativePath (string sourcePathToSplit)
		{
			return DirectoryUtility.SplitGenericPath (sourcePathToSplit, false);
		}

		/// <summary>
		/// Split a path or url into a path and its filename
		/// </summary>
		/// <param name="sourcePathToSplit"></param>
		/// <returns>Directories and filename</returns>
		/// 
		/// TEST CODE
		/// string[]	FolderArray;
		/// FolderArray = DirectoryUtility.SplitUrlPath (@"ftp://nolme.serveftp.net/Public");
		/// FolderArray = DirectoryUtility.SplitUrlPath (@"ms-its:mhtml:file://nolme.serveftp.net/Public2/Folder2/titi.exe");
		/// FolderArray = DirectoryUtility.SplitUrlPath (@"www.nolme.com/logiciels/systCleaner/systcleaner.exe");
		/// 
		public static string[] SplitUrlPath (string sourcePathToSplit)
		{
			if (sourcePathToSplit == null)		throw new NolmeArgumentNullException ();

			int OffsetDoubleSlash = sourcePathToSplit.IndexOf ("://");
			int EndOffset;

			if (OffsetDoubleSlash != -1)
			{
				EndOffset = OffsetDoubleSlash + 3;	// 3 == length (://)

				// ftp://
				// file://
				// http://
				// https://
				// ms-its:mhtml:file://
				// ...
				string PathToSplit	= DirectoryUtility.ConvertToWindowsFormat (sourcePathToSplit.Substring (EndOffset, sourcePathToSplit.Length - EndOffset));
				return DirectoryUtility.SplitGenericPath (PathToSplit, false);
			}
			else
			{
				return DirectoryUtility.SplitGenericPath (sourcePathToSplit, false);
			}
		}


		/// <summary>
		/// Split a path into severals parts
		/// </summary>
		/// <param name="pathToCheck">Path to split</param>
		/// <param name="manageFirstFolderAsDriveLetter">manage input path like path format (c:/MyFolder/) or generic format (HKLM\folder)</param>
		/// <returns>Directories and filename</returns>
		public static string[] SplitGenericPath (string pathToCheck, bool manageFirstFolderAsDriveLetter)
		{
			if (pathToCheck == null)		throw new NolmeArgumentNullException ();

			string		Letter;						// Path drive letter (c:\)
			int			ReadOffset;					// Current read offset of '/' in pathToCheck
			int			FoundOffset;				// Offset in pathToCheck where '/' has been found
			int			DirectoryCounter;			// Current directory or filename to store
			string		CurrentName;				// Name of current folder or filename
			string[]	FolderArray;				// All folders (& filename) founds with Letter drive
			int			NumberOfDirectories;		// Number of directories stored in FolderArray
			string		PathSeparator		= "\\/";						// Path separator
			char[]		PathSeparatorArray	= PathSeparator.ToCharArray();	// Path separator into char array format

			FolderArray = null;
			if (!StringUtility.IsValid (pathToCheck))
				return FolderArray;

			if (manageFirstFolderAsDriveLetter)
			{
				Letter = DirectoryUtility.GetValidStartingPath (pathToCheck);
				if (!StringUtility.IsValid (Letter))
					return FolderArray;
			
				NumberOfDirectories	= DirectoryUtility.GetNumberOfDirectories (pathToCheck, true, manageFirstFolderAsDriveLetter);
				FolderArray			= new string [NumberOfDirectories + 1];		// Add 1 to keep drive letter
				FolderArray[0]		= Letter;
				DirectoryCounter	= 1;
				ReadOffset			= Letter.Length;
			}
			else
			{
				NumberOfDirectories	= DirectoryUtility.GetNumberOfDirectories (pathToCheck, true, manageFirstFolderAsDriveLetter);
				FolderArray			= new string [NumberOfDirectories];
				ReadOffset			= 0;
				DirectoryCounter	= 0;
			}

			// Count number of '/' or '\' after drive letter
			while (ReadOffset != pathToCheck.Length)
			{
				FoundOffset = pathToCheck.IndexOfAny (PathSeparatorArray, ReadOffset, pathToCheck.Length - ReadOffset);
				if (FoundOffset != -1)
				{
					// Found new '/'
					CurrentName		= pathToCheck.Substring (ReadOffset, FoundOffset-ReadOffset);

					// Add element
					FolderArray[DirectoryCounter]	= CurrentName;

					// Set next position
					DirectoryCounter++;
					ReadOffset		= FoundOffset + 1;
				}
				else
				{
					CurrentName		= pathToCheck.Substring (ReadOffset, pathToCheck.Length-ReadOffset);

					// Add element
					FolderArray[DirectoryCounter]	= CurrentName;
					DirectoryCounter++;	// Increase just for equality that will be checked in debug mode

					// Leave loop
					break;
				}
			}

#if DEBUG
			if (DirectoryCounter != FolderArray.Length)
			{
				throw new NolmeOutOfBoundsException (DirectoryCounter, 0, FolderArray.Length, "Counter mismatch");
			}
#endif

			return FolderArray;
		}
		
		
		/// <summary>
		/// Split a path and its filename
		/// </summary>
		/// <param name="sourcePathToSplit">Path & filename WITHOUT QUOTES AND ARGUMENT</param>
		/// <returns>Objet containing splitted informations</returns>
		public static PathFileAndArguments SplitLocalPathAndFileName (string sourcePathToSplit)
		{
			if (sourcePathToSplit == null)		throw new NolmeArgumentNullException ();

			PathFileAndArguments	Result = new PathFileAndArguments (sourcePathToSplit);
			string	ConvertedSource = DirectoryUtility.ConvertToWindowsFormat (sourcePathToSplit);
			int		Offset;

#if DEBUG
			Offset = ConvertedSource.IndexOf ("\"");
			if (Offset != -1)
			{
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "This function doesn't accept quotes or parameter as input path"));
			}
#endif

			Offset = ConvertedSource.LastIndexOf (@"\");
			if (Offset == -1)
			{
				// Only a filename
				Result.FileNameWithExtensionOnly = sourcePathToSplit;
			}
			else
			{
				Result.FileNameWithExtensionOnly	= sourcePathToSplit.Substring (Offset + 1, sourcePathToSplit.Length - Offset - 1);
				Result.PathNameOnly					= sourcePathToSplit.Substring (0, Offset + 1);
			}
			return Result;
		}

		/// <summary>
		/// Split a path and its filename
		/// </summary>
		/// <param name="sourcePathToSplit">Path & filename WITHOUT QUOTES AND ARGUMENT</param>
		/// <returns>Objet containing splitted informations</returns>
		public static PathFileAndArguments SplitRelativePathAndFileName (string sourcePathToSplit)
		{
			return DirectoryUtility.SplitLocalPathAndFileName (sourcePathToSplit);
		}

		/// <summary>
		/// Split a filename with or not arguments
		/// </summary>
		/// TODO : check quotes or not
		public static PathFileAndArguments SplitFileNameAndArguments (string sourceFileNameWithArgs)
		{
			if (sourceFileNameWithArgs == null)	throw new NolmeArgumentNullException ();

			PathFileAndArguments	Result = null;

			if (StringUtility.IsValid (sourceFileNameWithArgs))
			{
				if (sourceFileNameWithArgs.IndexOf ("\"") != -1)
				{
				}
				else
				{
					// Simple path (no space, no quote) with simple arguments (no space, no quote)
					string []ParamBufferArray	= StringUtility.GetWordArray (sourceFileNameWithArgs);

					//ParamBufferArray[0] == path+filename
					//ParamBufferArray[n] == arguments
					Result = DirectoryUtility.SplitLocalPathAndFileName (ParamBufferArray[0]);

					Result.Arguments = sourceFileNameWithArgs.Substring (ParamBufferArray[0].Length + 1);
					Result.ConvertArgumentsToArray ();
				}
				/*
				Result						= new PathFileAndArguments (sourceFileNameWithArgs);
				string []ParamBufferArray	= StringUtility.GetWordArray2 (sourceFileNameWithArgs);

				if (ParamBufferArray.Length != 0)
					Result.FileNameWithExtensionOnly = ParamBufferArray[0];

				if (ParamBufferArray.Length > 1)
				{
					ParamBufferArray.CopyTo (Result.GetArgumentArray (), 1);
				}
				*/
			}
			return Result;
		}

		/// <summary>
		/// Split a filename with or not arguments
		/// </summary>
		public static PathFileAndArguments SplitFileNameAndArgsToArgumentString (string sourceFileNameWithArgs/*, out string destinationFileNameOut, out string destinationArgumentOut*/)
		{
			int  i = 0; // TODO

			/*
			int		i;
			//bool	BooleanResult;
			//string	[]ParamBufferArray;
			PathFileAndArguments	SplittedFileName;

			//destinationArgumentOut	= StringUtility.CreateEmptyString ();
			SplittedFileName		= DirectoryUtility.SplitFileNameAndArgumentsToArgumentArray (sourceFileNameWithArgs);
			//BooleanResult			= DirectoryUtility.SplitFileNameAndArgs (sourceFileNameWithArgs, out destinationFileNameOut, out ParamBufferArray);
			if (SplittedFileName != null)
			{
				if (SplittedFileName.GetArgumentArray () != null)
				{
					StringBuilder	LocalStringBuilder = new StringBuilder ();
					
					for (i = 0; i < SplittedFileName.GetArgumentArray ().Length-1; i++)
					{
						LocalStringBuilder.Append (SplittedFileName.GetArgumentArray()[i]);
						LocalStringBuilder.Append (" ");
						//destinationArgumentOut += ParamBufferArray[i];
						//destinationArgumentOut += " ";
					}
					// For last element don't add space ;p
					LocalStringBuilder.Append (SplittedFileName.GetArgumentArray()[i]);
					//destinationArgumentOut += ParamBufferArray[i];
				}
			}
			return SplittedFileName;
			*/
			return null;
		}

		/// <summary>
		/// Add a directory to an existing one, convert to Windows directory format & add path terminaison
		/// </summary>
		/// <param name="firstPath">Path like @"c:\MyFolder" or @"c:/MyFolder\"</param>
		/// <param name="newPathToAdd">My New Folder</param>
		/// <returns>New path</returns>
		public static string FormatPath (string firstPath, string newPathToAdd)
		{
			if (firstPath == null)		throw new NolmeArgumentNullException ();

			string Separator;
			string IntermediatePath;
			string FinalPath;

			if (!firstPath.EndsWith (@"\"))
				Separator = @"\";
			else if (!firstPath.EndsWith (@"/"))
				Separator = @"\";
			else
				Separator = "";
			IntermediatePath	= ConvertToWindowsFormat (firstPath) + Separator + ConvertToWindowsFormat(newPathToAdd);
			FinalPath			= SetCorrectDirectory (IntermediatePath);
			return FinalPath;
		}

		/// <summary>
		/// Add a directory to an existing one, convert to Windows directory format & add path terminaison
		/// </summary>
		/// <param name="firstPath">Path like @"c:\MyFolder" or @"c:/MyFolder\"</param>
		/// <param name="newFileNameToAdd">MyFile.exe</param>
		/// <returns>New path</returns>
		public static string FormatPathWithFileName (string firstPath, string newFileNameToAdd)
		{
			if (!StringUtility.IsValid (firstPath))
				return newFileNameToAdd;

			string szFinalPath = SetCorrectDirectory (firstPath) + newFileNameToAdd;
			return szFinalPath;
		}

		/// <summary>
		/// Replace an executable filename by another or a folder name by another
		/// </summary>
		/// <param name="pathToManage">Path to manage</param>
		/// <param name="newNameToSet">new name to set in last input path</param>
		/// <returns>string with new name inside</returns>
		/// 
		/// TEST CODE
		/// string NewFolder;
		/// NewFolder = DirectoryUtility.ReplaceLastElementInPath (@"c:\Myfolder1\MySubfolder\MyFile1.txt", "MyNewFile2.exe"); // => @"c:\Myfolder1\MySubfolder\MyNewFile2.exe"
		/// NewFolder = DirectoryUtility.ReplaceLastElementInPath (@"c:\Myfolder1\MySubfolder\MyFile1.txt", null);             // => @"c:\Myfolder1\MySubfolder\"
		/// NewFolder = DirectoryUtility.ReplaceLastElementInPath (@"MyFile1.txt", null);                                      // => null
		/// NewFolder = DirectoryUtility.ReplaceLastElementInPath (@"MyFile1.txt", "MyNewFile2.exe");                          // => @"MyNewFile2.exe"
		/// 
		public static string ReplaceLastElementInPath (string pathToManage, string newNameToSet)
		{
			int			FoundOffset;										// Offset in pathToManage where '/' or '\' has been found
			string		Result				= null;							// New path
			string		PathSeparator		= "\\/";						// Path separator
			char[]		PathSeparatorArray	= PathSeparator.ToCharArray();	// Path separator into char array format

			if (pathToManage == null)		throw new NolmeArgumentNullException ();

			if (!StringUtility.IsValid (pathToManage))
				return Result;

			FoundOffset = pathToManage.LastIndexOfAny (PathSeparatorArray);
			if (FoundOffset == -1)
			{
				// Path is only a filename
				return newNameToSet;
			}
			else
			{
				// SaveFileDialog objet not compatible with Unix path format
				Result = DirectoryUtility.ConvertToWindowsFormat (pathToManage.Substring (0, FoundOffset+1) + newNameToSet);
				return Result;
			}
		}
		
	
		/// <summary>
		/// Change last element (path or filename) extension (WHICH MUST EXISTS)
		/// </summary>
		/// <param name="pathToManage">Path to manage</param>
		/// <param name="newFileExtension">New extension to set (without point)</param>
		/// <returns>string with new name inside</returns>
		/// 
		/// TEST CODE
		/// string NewFolder;
		/// NewFolder = DirectoryUtility.ReplaceFileExtension (@"c:\Myfolder1\MySubfolder\MyFile1.txt", "exe");	// => @"c:\Myfolder1\MySubfolder\MyFile1.exe"
		/// NewFolder = DirectoryUtility.ReplaceFileExtension (@"c:\Myfolder1\MySubfolder\MyFile1.txt", null);		// => error
		/// NewFolder = DirectoryUtility.ReplaceFileExtension (@"c:\Myfolder1\MySubfolder.exe\MyFile1", "bin");	// => error
		/// NewFolder = DirectoryUtility.ReplaceFileExtension (@"MyFile1.txt", "exe");								// => MyFile1.exe
		/// NewFolder = DirectoryUtility.ReplaceFileExtension (@"MyFile1.txt", ".exe");							// => error
		/// 
		public static string ReplaceFileExtension (string pathToManage, string newFileExtension)
		{
			if (pathToManage == null)					throw new NolmeArgumentNullException ();
			if (newFileExtension == null)				throw new NolmeArgumentNullException ();
			if (!StringUtility.IsValid(pathToManage))		throw new NolmeArgumentNullException ();
			if (!StringUtility.IsValid(newFileExtension))	throw new NolmeArgumentNullException ();

			string		Result;
			int			OffsetForFile = pathToManage.LastIndexOf (".");
#if DEBUG
			// First check
			string		PathSeparator		= "\\/";						// Path separator
			char[]		PathSeparatorArray	= PathSeparator.ToCharArray();	// Path separator into char array format
			int			OffsetForSlash		= pathToManage.LastIndexOfAny (PathSeparatorArray);
			if (OffsetForSlash != -1)
			{
				// Just check that we are not modifying a previous fodler name (c:\MyFolder.exe\MyFile
				if (OffsetForSlash > OffsetForFile)
				{
					throw new NolmeOutOfBoundsException (OffsetForFile, OffsetForSlash, pathToManage.Length-1, "You're trying to change previous folder extension NOT last one");
				}
			}

			// Second Check
			if (newFileExtension.IndexOf (".") != -1)
			{
				throw new NolmeGenericException (string.Format (CultureInfo.InvariantCulture, "Remove '.' on new file extension to set"));
			}
#endif
			if (OffsetForFile != -1)
			{
				Result = pathToManage.Substring (0, OffsetForFile+1) + newFileExtension;
			}
			else
			{
				throw new NolmeFileNotFoundException (pathToManage);
			}
			return Result;
		}
		#endregion

		#region Environment
		static public string []	GetAllPathsFromEnvironment ()
		{
			char	[]SeparatorArray	= {',', ';'};
			string	TemporaryBuffer		= Environment.GetEnvironmentVariable ("PATH");
			string	[]DirectorieArray	= StringUtility.GetWordArray (TemporaryBuffer, SeparatorArray);

			return DirectorieArray;
		}

		static public string GetFirstFileOccurrenceFromEnvironment (string sourceFileName)
		{
			/*
			if (sourceFileName == null)			throw new NolmeArgumentNullException ();

			string szPath;//, szFilename;

			// Test fullfilename path
			if (File.Exists (sourceFileName))
			{
				PathFileAndArguments	PathAndFilename = DirectoryUtility.SplitGlobalPath (sourceFileName);
				//DirectoryUtility.SplitPath (sourceFileName, out szPath, out szFilename);
				return DirectoryUtility.SetCorrectDirectory (PathAndFilename.PathNameOnly);
			}

			// Test environment
			if (sourceFileName.IndexOf ("%") != -1)
			{
				string szExpandedFilename = Environment.ExpandEnvironmentVariables (sourceFileName);
				
				PathFileAndArguments	PathAndFilename = DirectoryUtility.SplitGlobalPath (szExpandedFilename);
				//DirectoryUtility.SplitPath (szExpandedFilename, out szPath, out szFilename);
				return DirectoryUtility.SetCorrectDirectory (PathAndFilename.PathNameOnly);
			}

			// Test relative filename
			string []aszPath = DirectoryUtility.GetAllPathsFromEnvironment ();
			string szResult	= StringUtility.CreateEmptyString ();

			for (int i = 0; i < aszPath.Length; i++)
			{
				szPath		= Environment.ExpandEnvironmentVariables (aszPath[i]);
				szResult	= DirectoryUtility.FormatPathWithFileName (szPath, sourceFileName);
				if (File.Exists (szResult))
					return DirectoryUtility.SetCorrectDirectory (szPath);
			}
			return szResult;
			*/
			return null;
		}
		#endregion
	}
}
