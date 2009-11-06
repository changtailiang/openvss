using System;
using System.Text;
using System.Collections;
using System.Globalization;

/*
 from : http://www.codeproject.com/books/0735616485.asp
	int i = 123456;

	Console.WriteLine("{0:C}", i); // £123,456.00
	Console.WriteLine("{0:D}", i); // 123456
	Console.WriteLine("{0:E}", i); // 1.234560E+005
	Console.WriteLine("{0:F}", i); // 123456.00
	Console.WriteLine("{0:G}", i); // 123456
	Console.WriteLine("{0:N}", i); // 123,456.00
	Console.WriteLine("{0:P}", i); // 12,345,600.00 %
	Console.WriteLine("{0:X}", i); // 1E240

	//The precision specifier controls the number of significant digits or zeros to the right of a decimal: 
	Console.WriteLine("{0:C5}", i); // £123,456.00000
	Console.WriteLine("{0:D5}", i); // 123456
	Console.WriteLine("{0:E5}", i); // 1.23456E+005
	Console.WriteLine("{0:F5}", i); // 123456.00000
	Console.WriteLine("{0:G5}", i); // 1.23456E5
	Console.WriteLine("{0:N5}", i); // 123,456.00000
	Console.WriteLine("{0:P5}", i); // 12,345,600.00000 %
	Console.WriteLine("{0:X5}", i); // 1E240
	
	double d = 1.2345678901234567890;
	Console.WriteLine("Floating-Point:\t{0:F16}", d);  // 1.2345678901234600
	Console.WriteLine("Roundtrip:\t{0:R16}", d);       // 1.2345678901234567
	
	int i = 123456;
	Console.WriteLine();
	Console.WriteLine("{0:#0}", i);             // 123456
	Console.WriteLine("{0:#0;(#0)}", i);        // 123456
	Console.WriteLine("{0:#0;(#0);<zero>}", i); // 123456
	Console.WriteLine("{0:#%}", i);				// 12345600%

	i = -123456;
	Console.WriteLine();
	Console.WriteLine("{0:#0}", i);             // -123456
	Console.WriteLine("{0:#0;(#0)}", i);        // (123456)
	Console.WriteLine("{0:#0;(#0);<zero>}", i); // (123456)
	Console.WriteLine("{0:#%}", i);             // -12345600%

	i = 0;
	Console.WriteLine();
	Console.WriteLine("{0:#0}", i);             // 0
	Console.WriteLine("{0:#0;(#0)}", i);        // 0
	Console.WriteLine("{0:#0;(#0);<zero>}", i); // <zero>
	Console.WriteLine("{0:#%}", i);             // %
 * */

namespace Nolme.Core
{
	public enum Character
	{
		Null			= 0,
		CarriageReturn	= 0x0D,		// 13 or \n
		Linefeed		= 0x0A,		// \r
		Escape			= 0x1B,		// 27
		Space			= ' ',		//
		Tabulation		= 0x09,		// 9
		Quotes			= 0x22		// "
	};

	/// <summary>
	/// Various tools using string object
	/// </summary>
	public sealed class StringUtility
	{
		private StringUtility() {}

		/// <summary>
		/// Check a string
		/// </summary>
		public static bool IsValid (string bufferToManage)
		{
			if ((bufferToManage != null) && (bufferToManage.Length != 0))
				return true;
			return false;
		}

		public static bool IsNumber (string bufferToManage)
		{
			if (bufferToManage == null)
			{
				throw new NolmeArgumentNullException ();
			}

			for (int i = 0; i < bufferToManage.Length; i++)
			{
				if ((bufferToManage[i] < '0') || (bufferToManage[i] > '9'))
					return false;
			}
			return true;
		}

		public static string CreateEmptyString ()
		{
			return string.Format (CultureInfo.InvariantCulture, "");
		}

		public static string CreateCarriageReturnString ()
		{
			return string.Format (CultureInfo.InvariantCulture, "\r");
		}

		public static string CreateLinefeedString ()
		{
			return string.Format (CultureInfo.InvariantCulture, "\n");
		}

		public static string GenerateString (char characterToGenerate, int numberOfItemsToInsert)
		{
			/*string ResultBuffer = StringUtility.CreateEmptyString ();

			for (int i = 0; i < numberOfItemsToInsert; i++)
				ResultBuffer += characterToGenerate;
			return ResultBuffer;
			*/
			StringBuilder LocalStringBuilder = new StringBuilder();
			for (int i = 0; i < numberOfItemsToInsert; i++)
			{
				LocalStringBuilder.Append (characterToGenerate);
			}
			return LocalStringBuilder.ToString ();
		}

		#region Quick & fast crypt
		/// <summary>
		/// Fast & very simple crypt
		/// </summary>
		public static string CryptDecrypt (string bufferToManage, byte cryptKey, bool cryptOrDecrypt)
		{
			if (bufferToManage == null)		throw new NolmeArgumentNullException ();

			char[] achBuffer		= bufferToManage.ToCharArray ();
			char[] achBufferCrypted	= new char [achBuffer.Length];

			for (int i = 0; i < achBuffer.Length; i++)
			{
				if (cryptOrDecrypt)
				{
					byte u8Src = (byte)(achBuffer [i]);
					byte u8Char = (byte)(u8Src + cryptKey);
					achBufferCrypted [i] = (char)u8Char;
					//achBufferCrypted [i] = (char)((byte)achBuffer [i] + cryptKey);
				}
				else
				{
					byte u8Src = (byte)(achBuffer [i]);
					byte u8Char = (byte)(u8Src - cryptKey);
					achBufferCrypted [i] = (char)u8Char;
					//achBufferCrypted [i] = (char)((byte)achBuffer [i] - cryptKey);
				}
			}
			
			string szCryptedString = new string (achBufferCrypted);
			return szCryptedString;
		}

		/// <summary>
		/// Fast & very simple crypt to hexa string
		/// </summary>
		public static string CryptAsciiStringToHexadecimalString (string bufferToManage, byte cryptKey, bool cryptOrDecrypt)
		{
			if (bufferToManage == null)			throw new NolmeArgumentNullException ();

			StringBuilder LocalStringBuilder;
			string TemporaryBuffer;
			string ResultBuffer = StringUtility.CreateEmptyString ();
			byte[] TextBytesArray = null;

			if (cryptOrDecrypt)
			{
				TextBytesArray = Encoding.ASCII.GetBytes(bufferToManage);

				/*
				foreach (byte a in TextBytesArray)
				{
					byte bCryptedByte = (byte)(a + cryptKey);
					if (bCryptedByte<16)
						ResultBuffer += "0" + bCryptedByte.ToString ("X", CultureInfo.InvariantCulture);
					else
						ResultBuffer += bCryptedByte.ToString ("X", CultureInfo.InvariantCulture);
				}
				*/
				LocalStringBuilder = new StringBuilder();
				foreach (byte a in TextBytesArray)
				{
					byte bCryptedByte = (byte)(a + cryptKey);
					if (bCryptedByte<16)
						TemporaryBuffer = "0" + bCryptedByte.ToString ("X", CultureInfo.InvariantCulture);
					else
						TemporaryBuffer = bCryptedByte.ToString ("X", CultureInfo.InvariantCulture);
					LocalStringBuilder.Append (TemporaryBuffer);
				}
				ResultBuffer = LocalStringBuilder.ToString ();
			}
			else
			{
				int Offset = 0;
				TextBytesArray = new byte [bufferToManage.Length /2];

				for (int i = 0; i < bufferToManage.Length /2; i++)
				{
					TextBytesArray [Offset] = (byte)Int32.Parse(bufferToManage.Substring(i*2,2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
					TextBytesArray [Offset] = (byte)(TextBytesArray [Offset] - cryptKey);	// DECRYPT
					Offset++;
				}

				char[] AsciiCharacterArray = new char[Encoding.ASCII.GetCharCount(TextBytesArray, 0, TextBytesArray.Length)];
				Encoding.ASCII.GetChars(TextBytesArray, 0, TextBytesArray.Length, AsciiCharacterArray, 0);
				
				ResultBuffer = new string(AsciiCharacterArray);
			}
			return ResultBuffer;
		}
		#endregion

		#region Get word array
		public static string[]	GetWordArray (string bufferToManage, char []separatorArray)
		{
			if (bufferToManage == null)			throw new NolmeArgumentNullException ();
			if (separatorArray == null)			throw new NolmeArgumentNullException ();

			string[]	ValueArray;
			string[]	ValueArrayReturned;

			if (!StringUtility.IsValid(bufferToManage))
			{
				ValueArray = new string [0];
				return ValueArray;
			}

			// This operation can return String.empty elements, scan & compute real string
			ValueArray = bufferToManage.Split (separatorArray);

			int i, iNullCounter = 0;
			for (i = 0; i < ValueArray.Length; i++)
			{
				if (!StringUtility.IsValid(ValueArray[i]))
					iNullCounter++;
			}

			// Save new array
			int Offset = 0;
			ValueArrayReturned = new string [ValueArray.Length-iNullCounter];
			for (i = 0; i < ValueArray.Length; i++)
			{
				if (!StringUtility.IsValid(ValueArray[i]))
				{
					// Don' save this element
				}
				else
				{
					ValueArrayReturned [Offset] = ValueArray[i];
					Offset++;
				}
			}
			return ValueArrayReturned;
		}

		/// <summary>
		/// Convert a string to an array of words (use space & tabulation as separator)
		/// </summary>
		public static string[]	GetWordArray (string bufferToManage)
		{
			char	[]as8Separator = { ' ', (char)0x09};
			return StringUtility.GetWordArray (bufferToManage, as8Separator);
		}

		public static string[]	GetWordArray (string bufferToManage, char separator)
		{
			char	[]as8Separator = {separator};
			return StringUtility.GetWordArray (bufferToManage, as8Separator);
		}

		/// <summary>
		/// Convert a string to an array of words (use space & tabulation as separator)
		/// Quotes are managed here "word0 word1" will be 1 parameter
		/// </summary>
		public static string[]	GetWordArray2 (string bufferToManage)
		{
			if (bufferToManage == null)		throw new NolmeArgumentNullException ();

			string[]	ValueArray;
			int			ReadIndex, QuoteStart, QuoteEnd, NoQuoteEnd;
			int			SpaceAndTab;
			string		TemporaryString;
			char[]		SeparatorArray = { ' ', (char)0x09};
			ArrayList	LocalElementArrayList = new ArrayList ();

			if (!StringUtility.IsValid(bufferToManage))
			{
				ValueArray = new string [0];
				return ValueArray;
			}

			// Check a quick case with no string inside
			QuoteStart = bufferToManage.IndexOf ('\"');
			if (QuoteStart == -1)
			{
				// No string using quotes, only separated by space or tab
				ValueArray = StringUtility.GetWordArray (bufferToManage);
			}
			else
			{
				// convert bufferToManage to string[]
				ReadIndex = 0;
				while (ReadIndex < bufferToManage.Length)
				{
					if (bufferToManage [ReadIndex] == '\"')
					{
						// separated by quotes, get end of quotes to retrieve datas
						QuoteEnd = bufferToManage.IndexOf ('\"', ReadIndex+1);
						if (QuoteEnd == -1)
							QuoteEnd = bufferToManage.Length;
						TemporaryString = bufferToManage.Substring (ReadIndex+1, QuoteEnd-(ReadIndex+1));

						// Skip element found
						ReadIndex += TemporaryString.Length + 2;	// Add one to skip 2 quotes
					}
					else
					{
						// Not using quotes, only separated by space or tab
						NoQuoteEnd = bufferToManage.IndexOfAny  (SeparatorArray, ReadIndex+1);
						if (NoQuoteEnd == -1)
							NoQuoteEnd = bufferToManage.Length;
						TemporaryString = bufferToManage.Substring (ReadIndex, NoQuoteEnd-(ReadIndex));

						// Skip element found
						ReadIndex += TemporaryString.Length;
					}

					// Skip spaces & tabs
					SpaceAndTab = ReadIndex;
					while (SpaceAndTab < bufferToManage.Length)
					{
						if ((bufferToManage [SpaceAndTab] == ' ') || (bufferToManage [SpaceAndTab] == 0x09))
						{
							SpaceAndTab++;
						}
						else
						{
							break;
						}
					}
					ReadIndex = SpaceAndTab;

					// Add element
					LocalElementArrayList.Add (TemporaryString);
				}

				// Convert ArrayList to string[]
				ValueArray = new string [LocalElementArrayList.Count];
				for (int i = 0; i < LocalElementArrayList.Count; i++)
				{
					ValueArray [i] = ((string)LocalElementArrayList[i]);
				}
			}
			return ValueArray;
		}

		#endregion

		#region Remove comments quotes...
		/// <summary>
		/// Remove a comment in a string
		/// </summary>
		public static string RemoveQuotes (string bufferToManage)
		{
			if (bufferToManage == null) throw new NolmeArgumentNullException ();

			string szResult;
			if (bufferToManage.StartsWith ("\"") && bufferToManage.EndsWith ("\""))
			{
				szResult = bufferToManage.Substring (1, bufferToManage.Length-2);
				return szResult;
			}
			else
			{
				return bufferToManage;
			}
		}

		/// <summary>
		/// Remove a comment in a string
		/// </summary>
		public static string RemoveComment (string bufferToManage, string commentStartTag)
		{
			if (bufferToManage  == null)			throw new NolmeArgumentNullException ();
			if (commentStartTag == null)			throw new NolmeArgumentNullException ();

			string	ResultBuffer, ResultBufferTrim;
			int		QuoteStart, QuoteEnd, iQuote;
			int		iCommentStart;

			// Check if a comment is inserted
			iCommentStart = bufferToManage.IndexOf (commentStartTag);
			if (iCommentStart == -1)
			{
				// No comment inside, return same string
				ResultBuffer = bufferToManage;
			}
			else
			{
				// A comment tag has been found but it may be inside a string
				QuoteStart = bufferToManage.IndexOf ("\"");
				if (QuoteStart == -1)
				{
					// Return from [0..iCommentStart[
					// Comment is at  iCommentStart with length bufferToManage.Length-iCommentStart
					ResultBuffer = bufferToManage.Substring (0, iCommentStart);
				}
				else
				{
					// Check before if quote start AFTER comment start
					if (iCommentStart < QuoteStart)
					{
						// Return from [0..iCommentStart[
						// Comment is at  iCommentStart with length bufferToManage.Length-iCommentStart
						ResultBuffer = bufferToManage.Substring (0, iCommentStart);
					}
					else
					{
						// String & comment both exists, check if last commentStartTag is after last quote so it's a real comment to end of line
						QuoteEnd = bufferToManage.IndexOf ("\"", QuoteStart+1);
						if (QuoteEnd == -1)
						{
							// [ERROR] String not well terminated, assume full string
							ResultBuffer = bufferToManage + "\"";
						}
						else
						{
							iQuote			= bufferToManage.LastIndexOf ("\"");
							iCommentStart	= bufferToManage.LastIndexOf (commentStartTag);
							if (iCommentStart > iQuote)
							{
								// Remove this comment
								ResultBuffer = bufferToManage.Substring (0, iCommentStart);
							}
							else
							{
								// comment tag is inside string, don't modify
								ResultBuffer = bufferToManage;
							}
						}
					}
				}
			}

			// Last stage, remove start spaces & stabs
			ResultBufferTrim = ResultBuffer.Trim ();
			return ResultBufferTrim;
		}

		/// <summary>
		/// Remove .INI comment like in a string
		/// </summary>
		public static string RemoveIniComment (string bufferToManage)
		{
			return RemoveComment (bufferToManage, ";");
		}

		/// <summary>
		/// Remove .CPP comment like in a string
		/// </summary>
		public static string RemoveCppComment (string bufferToManage)
		{
			return RemoveComment (bufferToManage, "//");
		}

		/// <summary>
		/// Remove .INI & .CPP comment like in a string
		/// </summary>
		public static string RemoveIniCppComment (string bufferToManage)
		{
			string TemporaryBuffer = RemoveIniComment (bufferToManage);
			return RemoveCppComment (TemporaryBuffer);
		}
		#endregion

		#region Convert string to decimal & decimal to string
		/// <summary>
		/// Convert a string like 'abcdefghijklmnopqrstuvwxyz' to decimal string like '6162636465666768696A6B6C6D6E6F707172737475767778797A'
		/// ONLY UNICODE IN THIS FUNCTION
		/// </summary>
		/// <param name="bufferToManage">String to convert</param>
		/// <returns></returns>
		public static string ConvertUnicodeStringToHexadecimalString (string bufferToManage)
		{
			byte[] TextBytesArray	= Encoding.Unicode.GetBytes(bufferToManage);

			/*
			string ResultBuffer		= StringUtility.CreateEmptyString ();
			foreach (byte a in TextBytesArray)
			{
				if (a<16)
					ResultBuffer += "0" + a.ToString ("X", CultureInfo.InvariantCulture);
				else
					ResultBuffer += a.ToString ("X", CultureInfo.InvariantCulture);
			}
			return ResultBuffer;
			*/
			StringBuilder LocalStringBuilder = new StringBuilder();
			foreach (byte a in TextBytesArray)
			{
				string TemporaryBuffer;
				if (a<16)
					TemporaryBuffer = "0" + a.ToString ("X", CultureInfo.InvariantCulture);
				else
					TemporaryBuffer = a.ToString ("X", CultureInfo.InvariantCulture);
				LocalStringBuilder.Append (TemporaryBuffer);
			}
			return LocalStringBuilder.ToString ();
		}

		/// <summary>
		/// Convert a string like '6162636465666768696A6B6C6D6E6F707172737475767778797A' to decimal string like 'abcdefghijklmnopqrstuvwxyz'
		/// ONLY UNICODE IN THIS FUNCTION
		/// </summary>
		/// <param name="bufferToManage">String to convert</param>
		/// <returns></returns>
		public static string ConvertHexadecimalStringToUnicodeString (string bufferToManage)
		{
			if (bufferToManage == null)			throw new NolmeArgumentNullException ();

			int		Offset			= 0;
			string	ResultBuffer	= StringUtility.CreateEmptyString ();
			byte[]	TextBytesArray	= new byte [bufferToManage.Length /2];

			for (int i = 0; i < bufferToManage.Length /2; i++)
			{
				TextBytesArray [Offset] = (byte)Int32.Parse(bufferToManage.Substring(i*2,2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				Offset++;
			}

			char[] AsciiCharacterArray = new char[Encoding.Unicode.GetCharCount(TextBytesArray, 0, TextBytesArray.Length)];
			Encoding.Unicode.GetChars(TextBytesArray, 0, TextBytesArray.Length, AsciiCharacterArray, 0);
			ResultBuffer = new string(AsciiCharacterArray);

			return ResultBuffer;
		}

		/// <summary>
		/// Convert a string like 'abcdefghijklmnopqrstuvwxyz' to decimal string like '6162636465666768696A6B6C6D6E6F707172737475767778797A'
		/// ONLY ASCII IN THIS FUNCTION
		/// </summary>
		/// <param name="bufferToManage">String to convert</param>
		/// <returns></returns>
		public static string ConvertAsciiStringToHexadecimalString (string bufferToManage)
		{
			string TemporaryBuffer;
			byte[] TextBytesArray	= Encoding.ASCII.GetBytes(bufferToManage);

			/*
			string ResultBuffer		= StringUtility.CreateEmptyString ();
			foreach (byte a in TextBytesArray)
			{
				if (a<16)
					ResultBuffer += "0" + a.ToString ("X", CultureInfo.InvariantCulture);
				else
					ResultBuffer += a.ToString ("X", CultureInfo.InvariantCulture);
			}
			return ResultBuffer;
			*/
			StringBuilder LocalStringBuilder = new StringBuilder();
			foreach (byte a in TextBytesArray)
			{
				if (a<16)
					TemporaryBuffer = "0" + a.ToString ("X", CultureInfo.InvariantCulture);
				else
					TemporaryBuffer = a.ToString ("X", CultureInfo.InvariantCulture);

				LocalStringBuilder.Append (TemporaryBuffer);
			}
			return LocalStringBuilder.ToString ();
		}

		/// <summary>
		/// Convert a string like '6162636465666768696A6B6C6D6E6F707172737475767778797A' to decimal string like 'abcdefghijklmnopqrstuvwxyz'
		/// ONLY ASCII IN THIS FUNCTION
		/// </summary>
		/// <param name="bufferToManage">String to convert</param>
		/// <returns></returns>
		public static string ConvertHexadecimalStringToAsciiString (string bufferToManage)
		{
			if (bufferToManage == null)			throw new NolmeArgumentNullException ();

			int		Offset			= 0;
			string	ResultBuffer	= StringUtility.CreateEmptyString ();
			byte[]	TextBytesArray	= new byte [bufferToManage.Length /2];

			for (int i = 0; i < bufferToManage.Length /2; i++)
			{
				TextBytesArray [Offset] = (byte)Int32.Parse(bufferToManage.Substring(i*2,2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				Offset++;
			}

			char[] AsciiCharacterArray = new char[Encoding.ASCII.GetCharCount(TextBytesArray, 0, TextBytesArray.Length)];
			Encoding.ASCII.GetChars(TextBytesArray, 0, TextBytesArray.Length, AsciiCharacterArray, 0);
				
			ResultBuffer = new string(AsciiCharacterArray);
			return ResultBuffer;
		}
		#endregion
	}
}
