using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Nolme.Core
{
	/// <summary>
	/// Summary description for Exception.
	/// </summary>
	[Serializable()]
	public class NolmeException : Exception 
	{
		public		NolmeException () : base () {}
		public		NolmeException (string message) : base (message) {}
		public		NolmeException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeException (SerializationInfo info, StreamingContext context) : base(info, context) {}
	}

	[Serializable()]
	public class NolmeGenericException : NolmeException
	{
		public		NolmeGenericException (string message) : base (message) {}
		public		NolmeGenericException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeGenericException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public	NolmeGenericException ()
		{
			throw new NolmeException (string.Format (CultureInfo.InvariantCulture, "Nolmë Exception : Generic exception"));
		}

		public	NolmeGenericException	(string baseText, string additionalText)
		{
			throw new NolmeException (string.Format (CultureInfo.InvariantCulture, "Nolmë Exception : Generic exception <{0}> <{1}>", baseText, additionalText));
		}
	}

	[Serializable()]
	public class NolmeFileNotFoundException : NolmeException
	{
		public		NolmeFileNotFoundException () : base () {}
		public		NolmeFileNotFoundException (string message) : base (message) {}
		public		NolmeFileNotFoundException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeFileNotFoundException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public	NolmeFileNotFoundException (string fullFileName, string additionalText)
		{
			throw new NolmeException (NolmeFileNotFoundException.CreateMessage (fullFileName, additionalText));
		}

		static private string CreateMessage (string fullFileName, string additionalText)
		{
			if (fullFileName == null)	throw new NolmeArgumentNullException ();

			string TemporaryBuffer;

			if (StringUtility.IsValid (additionalText))
				TemporaryBuffer = String.Format (CultureInfo.InvariantCulture, "Nolmë Exception : File NOT found '{0}' <{1}>", fullFileName, additionalText);
			else
				TemporaryBuffer = String.Format (CultureInfo.InvariantCulture, "Nolmë Exception : File NOT found '{0}'", fullFileName);
			return TemporaryBuffer;
		}
	}

	[Serializable()]
	public class NolmeOutOfBoundsException : NolmeException
	{
		public		NolmeOutOfBoundsException () : base () {}
		public		NolmeOutOfBoundsException (string message) : base (message) {}
		public		NolmeOutOfBoundsException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeOutOfBoundsException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public	NolmeOutOfBoundsException (int badValue)
		{
			throw new NolmeException (NolmeOutOfBoundsException.CreateMessage (badValue, null));
		}

		public	NolmeOutOfBoundsException (int badValue, string additionalText)
		{
			throw new NolmeException (NolmeOutOfBoundsException.CreateMessage (badValue, additionalText));
		}

		public	NolmeOutOfBoundsException (int badValue, int minimumValue, int maximumValue, string additionalText)
		{
			throw new NolmeException (NolmeOutOfBoundsException.CreateMessage (badValue, minimumValue, maximumValue, additionalText));
		}

		static private string CreateMessage (int badValue, string additionalText)
		{
			string TemporaryBuffer;

			if (StringUtility.IsValid (additionalText))
				TemporaryBuffer = String.Format (CultureInfo.InvariantCulture, "Nolmë Exception : BAD value '{0}' <{1}>", badValue.ToString(CultureInfo.InvariantCulture), additionalText);
			else
				TemporaryBuffer = String.Format (CultureInfo.InvariantCulture, "Nolmë Exception : BAD value '{0}'", badValue.ToString(CultureInfo.InvariantCulture));
			return TemporaryBuffer;
		}

		static private string CreateMessage (int badValue, int minimumValue, int maximumValue, string additionalText)
		{
			string TemporaryBuffer;

			if (StringUtility.IsValid (additionalText))
				TemporaryBuffer = String.Format (CultureInfo.InvariantCulture, "Nolmë Exception : BAD value '{0}' in [{1}..{2}] <{3}>", badValue.ToString(CultureInfo.InvariantCulture), minimumValue, maximumValue, additionalText);
			else
				TemporaryBuffer = String.Format (CultureInfo.InvariantCulture, "Nolmë Exception : BAD value '{0}' in [{1}..{2}]", badValue.ToString(CultureInfo.InvariantCulture), minimumValue, maximumValue);
			return TemporaryBuffer;
		}
	}

	[Serializable()]
	public class NolmeArgumentNullException : NolmeException
	{
		public		NolmeArgumentNullException (string message) : base (message) {}
		public		NolmeArgumentNullException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeArgumentNullException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeArgumentNullException ()
		{
			throw new NolmeException (string.Format (CultureInfo.InvariantCulture, "Nolmë Exception : Argument is Null"));
		}
	}

	[Serializable()]
	public class NolmeMemberNullException : NolmeException
	{
		public		NolmeMemberNullException (string message) : base (message) {}
		public		NolmeMemberNullException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeMemberNullException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeMemberNullException ()
		{
			throw new NolmeException (string.Format (CultureInfo.InvariantCulture, "Nolmë Exception : member is Null or not initialized"));
		}
	}

	[Serializable()]
	public class NolmeBooleanFalseException : NolmeException
	{
		public		NolmeBooleanFalseException (string message) : base (message) {}
		public		NolmeBooleanFalseException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeBooleanFalseException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeBooleanFalseException ()
		{
			throw new NolmeException (string.Format (CultureInfo.InvariantCulture, "Nolmë Exception : Boolean set to False"));
		}
	}

	[Serializable()]
	public class NolmeBooleanTrueException : NolmeException
	{
		public		NolmeBooleanTrueException (string message) : base (message) {}
		public		NolmeBooleanTrueException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeBooleanTrueException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeBooleanTrueException ()
		{
			throw new NolmeException (string.Format (CultureInfo.InvariantCulture, "Nolmë Exception : Boolean set to True"));
		}
	}
}
