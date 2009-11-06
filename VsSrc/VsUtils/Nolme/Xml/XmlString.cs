using System;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlString.
	/// </summary>
	public class XmlString
	{
		private string m_String;

		public XmlString ()
		{
		}

		public XmlString (string newText)
		{
			this.String = newText;
		}
		

		// Serializes Text to XML.
		[System.Xml.Serialization.XmlAttribute ("String")]
		public string String
		{
			get { return m_String; }
			set { if (value != null) 
					  m_String = value; 
				else
					  m_String = String.Empty; }
		}

		// Serializes Text length to XML.
		[System.Xml.Serialization.XmlAttribute ("Length")] 
		public int Length
		{
			get { return m_String.Length; }
			set { System.Diagnostics.Debug.Assert (value == m_String.Length);  /* Nothing to do, count updated during load, keep function for serialization */ }
		}
	}
}
