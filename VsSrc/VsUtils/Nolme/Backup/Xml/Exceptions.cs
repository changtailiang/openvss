using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for Exception.
	/// </summary>
	[Serializable()]
	public class NolmeXmlException : Exception 
	{
		public		NolmeXmlException () : base () {}
		public		NolmeXmlException (string message) : base (message) {}
		public		NolmeXmlException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeXmlException (SerializationInfo info, StreamingContext context) : base(info, context) {}
	}

	[Serializable()]
	public class NolmeXmlGenericException : NolmeXmlException
	{
		public		NolmeXmlGenericException (string message) : base (message) {}
		public		NolmeXmlGenericException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeXmlGenericException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public	NolmeXmlGenericException ()
		{
			throw new NolmeXmlException (string.Format (CultureInfo.InvariantCulture, "Nolmë Xml Exception : Generic exception"));
		}

		public	NolmeXmlGenericException	(string baseText, string additionalText)
		{
			throw new NolmeXmlException (string.Format (CultureInfo.InvariantCulture, "Nolmë Xml Exception : Generic exception <{0}> <{1}>", baseText, additionalText));
		}
	}

	[Serializable()]
	public class NolmeXmlInvalidCaseException : NolmeXmlException
	{
		public		NolmeXmlInvalidCaseException (string message) : base (message) {}
		public		NolmeXmlInvalidCaseException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeXmlInvalidCaseException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public	NolmeXmlInvalidCaseException ()
		{
			throw new NolmeXmlException (string.Format (CultureInfo.InvariantCulture, "Nolmë Xml Exception : Invalid case exception"));
		}

		public	NolmeXmlInvalidCaseException	(string baseText, string additionalText)
		{
			throw new NolmeXmlException (string.Format (CultureInfo.InvariantCulture, "Nolmë Xml Exception : Invalid case exception <{0}> <{1}>", baseText, additionalText));
		}
	}

	[Serializable()]
	public class NolmeXmlArgumentNullException : NolmeXmlException
	{
		public		NolmeXmlArgumentNullException (string message) : base (message) {}
		public		NolmeXmlArgumentNullException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeXmlArgumentNullException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeXmlArgumentNullException ()
		{
			throw new NolmeXmlException (string.Format (CultureInfo.InvariantCulture, "Nolmë Xml Exception : Argument is Null"));
		}
	}

	[Serializable()]
	public class NolmeXmlMemberNullException : NolmeXmlException
	{
		public		NolmeXmlMemberNullException (string message) : base (message) {}
		public		NolmeXmlMemberNullException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeXmlMemberNullException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeXmlMemberNullException ()
		{
			throw new NolmeXmlException (string.Format (CultureInfo.InvariantCulture, "Nolmë Xml Exception : member is Null or not initialized"));
		}
	}
}
