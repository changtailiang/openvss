using System;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlConfigurationNode.
	/// </summary>
	public class XmlConfigurationNode
	{
		private string		m_NodeName;
		private XmlList		m_SubNodes;

		public XmlConfigurationNode()
		{
			m_NodeName	= String.Empty;
			m_SubNodes	= new XmlList ();
		}

		public XmlConfigurationNode(string nodeName)
		{
			m_NodeName	= nodeName;
			m_SubNodes	= new XmlList ();
		}

		#region Properties
		public XmlList		SubNodes
		{
			get { return m_SubNodes; }
			set { m_SubNodes = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("NodeName")]
		public string		NodeName
		{
			get { return m_NodeName; }
			set { m_NodeName = value; }
		}
		#endregion
	}
}
