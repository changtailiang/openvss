using System;
using System.Text;
using System.IO;
using System.Collections;				// IComparer
using System.Globalization;

namespace Nolme.Core
{
	#region IComparer - Sort classes
	/// <summary>
	/// Comparison class by SIZE
	/// </summary>
	public class FileSystemCompareBySize: IComparer
	{
		public int Compare(object x, object y) 
		{
			// Only FILES
			FileInfo filex = x as FileInfo;
			FileInfo filey = y as FileInfo;
			long fileSize1 = filex == null? -1: filex.Length;
			long fileSize2 = filey == null? -1: filey.Length;
			if (fileSize1 > fileSize2) return 1;
			if (fileSize1 < fileSize2) return -1;
			return 0;
		}
	}

	/// <summary>
	/// Comparison class by NAME
	/// </summary>
	public class FileSystemCompareByName: IComparer
	{
		public int Compare(object x, object y) 
		{
			FileSystemInfo filex = x as FileSystemInfo;
			FileSystemInfo filey = y as FileSystemInfo;

			return (filex.Name.CompareTo ( filey.Name));
		}
	}
	#endregion

	public class NumberOfLinesResult
	{
		private int m_NumberOfLines;
		private int m_NumberOfEmptyLines;

		public int NumberOfLines
		{
			get { return m_NumberOfLines; }
			set { m_NumberOfLines = value; }
		}
		public int NumberOfEmptyLines
		{
			get { return m_NumberOfEmptyLines; }
			set { m_NumberOfEmptyLines = value; }
		}
	}

	/// <summary>
	/// Generic tools function.
	/// </summary>
	public sealed class FileUtility
	{
		private FileUtility() {}

		public static long GetFileSize (string fileName)
		{
			FileInfo fi = new FileInfo(fileName);
			return fi.Length;
		}

		public static int MakeInt32 (char characterOne, char characterTwo, char characterThree, char characterFour)
		{
			int iResult = (characterFour<<24) + (characterThree<<16) + (characterTwo<<8) + (characterOne);
			return iResult;
		}

		public static FileInfo[] SortByName(FileInfo[] fileInfoArray)
		{
			FileInfo[] aInfos = fileInfoArray;
			IComparer sizeComparer = new FileSystemCompareByName();
			Array.Sort(aInfos, sizeComparer);
			return aInfos;
		}

		public static DirectoryInfo[] SortByName(DirectoryInfo[] directoryInfoArray)
		{
			DirectoryInfo[] aInfos = directoryInfoArray;
			IComparer sizeComparer = new FileSystemCompareByName();
			Array.Sort(aInfos, sizeComparer);
			return aInfos;
		}

		#region Read file
		/// <summary>
		/// Count number of lines in a text file
		/// </summary>
		public static NumberOfLinesResult GetNumberOfLines (string fileName)
		{
			NumberOfLinesResult	Result = null;
			bool				BooleanResult;
			StreamReader		InputFileStream;
		
			BooleanResult		= File.Exists (fileName);
			if (BooleanResult)
			{
				InputFileStream	= new System.IO.StreamReader(fileName);
				Result			= FileUtility.GetNumberOfLines (InputFileStream);
				InputFileStream.Close ();
			}
			return Result;
		}

		public static NumberOfLinesResult GetNumberOfLines (TextReader inputStream)
		{
			NumberOfLinesResult	Result = new NumberOfLinesResult ();
			string				CurrentLine;

			// Check not null object
			if (inputStream != null)
			{
				// Count number of lines
				while ((CurrentLine = inputStream.ReadLine ()) != null)
				{
					if (CurrentLine.Length == 0)
						Result.NumberOfEmptyLines++;
					Result.NumberOfLines++;
				}
				// DO NOT CLOSE, IT'S PARENT FUNCTION JOB
				// inputStream.Close ();
			}

			return Result;
		}

		/// <summary>
		/// Read all lines in a text file
		/// </summary>
        public static string ReadAllFile(string fileName)
        {
			string	DestinationString;

			if (File.Exists(fileName))
			{
				long			lFileSize		= FileUtility.GetFileSize	(fileName);
				Stream			oReadBinStream	= File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				BinaryReader	oReadBinOutput	= new BinaryReader (oReadBinStream);
				char[]			CharacterBuffer	= new char [lFileSize];

				oReadBinOutput.Read (CharacterBuffer, 0, (int)lFileSize);
				oReadBinOutput.Close ();
				oReadBinStream.Close ();

                DestinationString = new string(CharacterBuffer);
            }
			else
			{
                throw new FileNotFoundException (String.Format (CultureInfo.InvariantCulture, "File NOT found '{0}'", fileName));
            }
			return DestinationString;
		}

        public static char[] ReadAllFileInCharacterArray(string fileName)
        {
			char	[]DestinationArray;

            if (File.Exists(fileName))
            {
                long lFileSize = FileUtility.GetFileSize(fileName);
                Stream oReadBinStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader oReadBinOutput = new BinaryReader(oReadBinStream);
                DestinationArray = new char[lFileSize];

                oReadBinOutput.Read(DestinationArray, 0, (int)lFileSize);
                oReadBinOutput.Close();
                oReadBinStream.Close();
            }
            else
            {
                throw new FileNotFoundException (String.Format (CultureInfo.InvariantCulture, "File NOT found '{0}'", fileName));
            }
            return DestinationArray;
        }

        public static byte[] ReadAllFileInByteArray(string fileName)
        {
			byte[]DestinationArray;

            if (File.Exists(fileName))
            {
                long lFileSize = FileUtility.GetFileSize(fileName);
                Stream oReadBinStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader oReadBinOutput = new BinaryReader(oReadBinStream);
                DestinationArray = new byte[lFileSize];

                oReadBinOutput.Read(DestinationArray, 0, (int)lFileSize);
                oReadBinOutput.Close();
                oReadBinStream.Close();
            }
            else
            {
                throw new FileNotFoundException (String.Format (CultureInfo.InvariantCulture, "File NOT found '{0}'", fileName));
            }
            return DestinationArray;
        }

        /// <summary>
		/// Read all lines in a text file
		/// </summary>
		public static string[] ReadAllLines (string fileName, bool excludeEmptyLine)
		{
			return ReadAllLines (fileName, excludeEmptyLine, false);
		}

		public static string[] ReadAllLines (string fileName, bool excludeEmptyLine, bool keepLineTermination)
		{
			return FileUtility.ReadAllLines (fileName, excludeEmptyLine, keepLineTermination, System.Text.Encoding.Default);
		}

		public static string[] ReadAllLines (string fileName, bool excludeEmptyLine, bool keepLineTermination, System.Text.Encoding textEncoding)
		{
			bool			BooleanResult;
			string[]		LineArray;
			StreamReader	InputFileStream;

			LineArray	= null;
			BooleanResult		= File.Exists (fileName);
			if (BooleanResult)
			{
				InputFileStream		= new System.IO.StreamReader(fileName,textEncoding);
				LineArray			= FileUtility.ReadAllLines (InputFileStream, excludeEmptyLine, keepLineTermination);
				InputFileStream.Close ();
			}
			else
			{
				throw new FileNotFoundException (String.Format (CultureInfo.InvariantCulture, "File NOT found : {0}", fileName));
			}
			return LineArray;
		}

		public static string[] ReadAllLines (StreamReader inputStream, bool excludeEmptyLine)
		{
			return FileUtility.ReadAllLines (inputStream, excludeEmptyLine, false);
		}

		public static string[] ReadAllLines (StreamReader inputStream, bool excludeEmptyLine, bool keepLineTermination)
		{
			string[]		LineArray;
			int				NumberOfAddedLines;
			string			CurrentLine;
			NumberOfLinesResult	LinesResult;

			// Init
			if (inputStream == null)
				return null;
			
			// Count number of lines
			LinesResult		= FileUtility.GetNumberOfLines (inputStream);
			inputStream.BaseStream.Seek (0, SeekOrigin.Begin);

			if (excludeEmptyLine)			LineArray	= new string [LinesResult.NumberOfLines - LinesResult.NumberOfEmptyLines];
			else							LineArray	= new string [LinesResult.NumberOfLines];

			// Read all lines
			NumberOfAddedLines = 0;
			//InputFileStream		= new System.IO.StreamReader(fileName,System.Text.Encoding.Default);
			//InputFileStream		= new System.IO.StreamReader(fileName,System.Text.Encoding.UTF8);
			for (int i = 0; i < LinesResult.NumberOfLines; i++)
			{
				CurrentLine = inputStream.ReadLine ();
				if (CurrentLine.Length == 0)
				{
					if (!excludeEmptyLine)
					{
						LineArray [NumberOfAddedLines] = CurrentLine;
						if (keepLineTermination)
							LineArray [NumberOfAddedLines] += "\n";
						NumberOfAddedLines++;
					}
				}
				else
				{
					LineArray [NumberOfAddedLines] = CurrentLine;
					if (keepLineTermination)
						LineArray [NumberOfAddedLines] += "\n";
					NumberOfAddedLines++;
				}
			}

			// DO NOT CLOSE, IT'S PARENT FUNCTION JOB
			// inputStream.Close ();
			return LineArray;
		}

		/// <summary>
		/// Read padding byte to stream
		/// </summary>
		public static void ReadPaddingBytes (BinaryReader binaryReader, int numberOfPaddingBytes)
		{
			if (binaryReader == null)			throw new NolmeArgumentNullException ();

			for (int i = 0; i < numberOfPaddingBytes; i++)
			{
				byte u8Padding = binaryReader.ReadByte ();
				if (u8Padding != 0)
				{
					// [ERROR], not a valid padding byte
					throw new NolmeOutOfBoundsException (u8Padding, "FileUtility.ReadPaddingBytes () : Padding not null");
					//throw new IndexOutOfRangeException (string.Format (CultureInfo.InvariantCulture, "FileUtility.ReadPaddingBytes () : Padding not null"));
				}
			}
		}

		/// <summary>
		/// Read a date from disk with 2 bytes padding
		/// </summary>
		public static DateTime ReadShortDate (BinaryReader binaryReader)
		{
			if (binaryReader == null)			throw new NolmeArgumentNullException ();

			DateTime LocalDateTime = DateTime.MinValue;	// Start 1/1/1

			LocalDateTime = LocalDateTime.AddYears			(binaryReader.ReadInt32 () - 1);
			LocalDateTime = LocalDateTime.AddMonths			(binaryReader.ReadByte  () - 1);
			LocalDateTime = LocalDateTime.AddDays			(binaryReader.ReadByte  () - 1);
			ReadPaddingBytes (binaryReader, 2);					// 0
			return LocalDateTime;
		}

		/// <summary>
		/// Read a date & time from disk with 2 bytes padding
		/// </summary>
		public static DateTime ReadShortDateTime (BinaryReader binaryReader)
		{
			if (binaryReader == null)			throw new NolmeArgumentNullException ();

			DateTime LocalDateTime = DateTime.MinValue;	// Start 1/1/1

			LocalDateTime = LocalDateTime.AddYears			(binaryReader.ReadInt32 () - 1);
			LocalDateTime = LocalDateTime.AddMonths			(binaryReader.ReadByte  () - 1);
			LocalDateTime = LocalDateTime.AddDays			(binaryReader.ReadByte  () - 1);
			LocalDateTime = LocalDateTime.AddHours			(binaryReader.ReadByte  () - 1);
			LocalDateTime = LocalDateTime.AddMinutes		(binaryReader.ReadByte  () - 1);
			LocalDateTime = LocalDateTime.AddSeconds		(binaryReader.ReadByte  () - 1);
			LocalDateTime = LocalDateTime.AddMilliseconds	(binaryReader.ReadByte  () - 1);
			ReadPaddingBytes (binaryReader, 2);					// 0
			
			/* Excluded from short loading
			 * See : FileUtility.WriteShortDateTime()
			 * */
			return LocalDateTime;
		}

		
		public static string ReadAsciiString (BinaryReader binaryReader)
		{
			if (binaryReader == null)			throw new NolmeArgumentNullException ();

			// Read length
			int Length = binaryReader.ReadInt32 ();
			string szString;

			// Read each bytes
			byte []ByteBuffer = new byte [Length];
			binaryReader.Read (ByteBuffer, 0, Length);
			szString = System.Text.Encoding.Default.GetString (ByteBuffer);

			// Read padding
			if ((Length % 4) != 0)
			{
				FileUtility.ReadPaddingBytes (binaryReader, 4-(Length % 4));
			}
			return szString;
		}

		public static string[] ReadAsciiStringArray (BinaryReader binaryReader)
		{
			if (binaryReader == null)			throw new NolmeArgumentNullException ();

			int		Length;
			string	[]aszString;

			Length		= binaryReader.ReadInt32 ();
			aszString	= null;
			if (Length != 0)
			{
				aszString	= new string [Length];
				for (int i = 0; i < Length; i++)
				{
					aszString[i] = FileUtility.ReadAsciiString (binaryReader);
				}
			}
			return aszString;
		}
		#endregion

		#region Write file
		/// <summary>
		/// Write lines to stream
		/// </summary>
		public static void WriteLine (string fileName, string line, bool append)
		{
			string []aszLine = new string [1];
			aszLine[0] = line;
			FileUtility.WriteAllLines (fileName, aszLine, append);
		}

		/// <summary>
		/// Write lines to stream
		/// </summary>
		public static void WriteAllLines (string fileName, string []lineArray)
		{
			FileUtility.WriteAllLines (fileName, lineArray, false);
		}

		/// <summary>
		/// Write lines to stream
		/// </summary>
		public static void WriteAllLines (string fileName, string []lineArray, bool append)
		{
			if (lineArray == null)
			{
				throw new NolmeArgumentNullException ();
			}

			StreamWriter	oWriteTextStream	= new StreamWriter (fileName, append, System.Text.Encoding.Default);

			for (int i = 0; i < lineArray.Length; i++)
			{
				oWriteTextStream.WriteLine	(lineArray[i]);
			}
			oWriteTextStream.Close		();
		}

		/// <summary>
		/// Write padding byte to stream
		/// </summary>
		public static void WritePaddingBytes (BinaryWriter writer, int numberOfPaddingBytes)
		{
			if (writer == null)			throw new NolmeArgumentNullException ();

			for (int i = 0; i < numberOfPaddingBytes; i++)
			{
				byte u8Padding = 0;
				writer.Write (u8Padding);
			}
		}

		/// <summary>
		/// Write a date to disk with 2 bytes padding
		/// </summary>
		public static void WriteShortDate (BinaryWriter writer, DateTime dateToManage)
		{
			if (writer == null)			throw new NolmeArgumentNullException ();

			writer.Write ((int) (dateToManage.Year));			// [1..9999]
			writer.Write ((byte)(dateToManage.Month));			// [1..12]
			writer.Write ((byte)(dateToManage.Day));			// [1..31]
			WritePaddingBytes (writer, 2);					// 0
		}

		/// <summary>
		/// Write a date & time to disk with 2 bytes padding
		/// </summary>
		public static void WriteShortDateTime (BinaryWriter writer, DateTime dateToManage)
		{
			if (writer == null)			throw new NolmeArgumentNullException ();

			writer.Write ((int) (dateToManage.Year));			// [1..9999]
			writer.Write ((byte)(dateToManage.Month));			// [1..12]
			writer.Write ((byte)(dateToManage.Day));			// [1..31]
			writer.Write ((byte)(dateToManage.Hour));			// [0..24[
			writer.Write ((byte)(dateToManage.Minute));			// [0..60[
			writer.Write ((byte)(dateToManage.Second));			// [0..60[
			writer.Write ((byte)(dateToManage.Millisecond));	// [0..100[
			WritePaddingBytes (writer, 2);					// 0
			
			/* Excluded from short saving
			dateToManage.DayOfWeek;		// [0..6] Recalculated
			dateToManage.DayOfYear;		// [1..366] Recalculated
			
			dateToManage.Ticks;
			dateToManage.TimeOfDay.TotalDays;
			dateToManage.TimeOfDay.TotalHours;
			dateToManage.TimeOfDay.TotalMinutes;
			dateToManage.TimeOfDay.TotalSeconds;
			dateToManage.TimeOfDay.TotalMilliseconds;
			dateToManage.TimeOfDay.Ticks;
			[...]
			*/
		}

		public static void WriteAsciiString (BinaryWriter writer, string bufferToManage)
		{
			if (writer == null)				throw new NolmeArgumentNullException ();
			if (bufferToManage == null)		throw new NolmeArgumentNullException ();

			// Write length
			writer.Write ((int)bufferToManage.Length);

			// Write each byte
			for (int i = 0; i < bufferToManage.Length; i++)
			{
				byte b = (byte)bufferToManage [i];
				writer.Write (b);
			}

			// Write padding
			if ((bufferToManage.Length % 4) != 0)
			{
				FileUtility.WritePaddingBytes (writer, 4-(bufferToManage.Length % 4));
			}
		}

		public static void WriteAsciiStringArray (BinaryWriter writer, string []bufferToManageArray)
		{
			if (writer == null)					throw new NolmeArgumentNullException ();
			if (bufferToManageArray == null)	throw new NolmeArgumentNullException ();

			writer.Write (bufferToManageArray.Length);
			for (int i = 0; i < bufferToManageArray.Length; i++)
			{
				FileUtility.WriteAsciiString (writer, bufferToManageArray [i]);
			}
		}

		public static void DumpToFile (string path, string fileName, MemoryStream memoryStream)
		{
			if (memoryStream == null)			throw new NolmeArgumentNullException ();

			if (!Directory.Exists (path))
			{
				Directory.CreateDirectory (path);
			}
			string szFullPath = DirectoryUtility.FormatPathWithFileName (path, fileName);
			FileUtility.DumpToFile (szFullPath, memoryStream);
		}

		public static void DumpToFile (string fullFileName, MemoryStream memoryStream)
		{
			if (memoryStream == null)			throw new NolmeArgumentNullException ();

			Stream			oWriteBinStream	= File.Open(fullFileName, FileMode.Create);
			BinaryWriter	oWriteBinOutput	= new BinaryWriter (oWriteBinStream);
			
			oWriteBinOutput.Write (memoryStream.GetBuffer (), 0, (int)memoryStream.Length);
				
			oWriteBinOutput.Close ();
			oWriteBinStream.Close ();
		}
		#endregion

		/// <summary>
		/// Delete a file (remove read only if exist)
		/// </summary>
		public static bool DeleteFile (string fullFileName)
		{
			bool BooleanResult = File.Exists (fullFileName);
			if (BooleanResult)
			{
				File.SetAttributes (fullFileName, FileAttributes.Normal);
				File.Delete (fullFileName);
			}
			return BooleanResult;
		}
	}
}
