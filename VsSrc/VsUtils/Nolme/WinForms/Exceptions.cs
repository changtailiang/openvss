using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Nolme.WinForms
{
	/// <summary>
	/// Summary description for Exception.
	/// </summary>
	[Serializable()]
	public class NolmeWinFormsException : Exception 
	{
		public		NolmeWinFormsException () : base () {}
		public		NolmeWinFormsException (string message) : base (message) {}
		public		NolmeWinFormsException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeWinFormsException (SerializationInfo info, StreamingContext context) : base(info, context) {}
	}

	[Serializable()]
	public class NolmeWinFormsArgumentNullException : NolmeWinFormsException
	{
		public		NolmeWinFormsArgumentNullException (string message) : base (message) {}
		public		NolmeWinFormsArgumentNullException (string message, Exception inner) : base(message,inner) {}
		protected	NolmeWinFormsArgumentNullException (SerializationInfo info, StreamingContext context) : base(info, context) {}

		public		NolmeWinFormsArgumentNullException ()
		{
			throw new NolmeWinFormsException (string.Format (CultureInfo.InvariantCulture, "Nolmë WinForms Exception : Argument is Null"));
		}
	}
}
