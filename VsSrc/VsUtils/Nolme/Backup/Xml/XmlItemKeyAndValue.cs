using System;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlItemKeyAndValue.
	/// </summary>
	[Serializable ()]
	public class XmlItemKeyAndValue
	{
		private string m_Key;
		private object m_Value;

		public XmlItemKeyAndValue()
		{
		}

		public XmlItemKeyAndValue(string key, object value)
		{
			m_Key	= key;
			m_Value	= value;
		}

		//[System.Xml.Serialization.XmlElement ("Key")] 
		[System.Xml.Serialization.XmlAttribute ("KeyName")] 
		public string Key
		{
			get { return m_Key; }
			set { m_Key = value; }
		}

		[System.Xml.Serialization.XmlElement ("Value")] 
		public object Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
	}
}
