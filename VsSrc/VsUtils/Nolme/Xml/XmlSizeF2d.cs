using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlSizeF2d.
	/// </summary>
	public class XmlSizeF2d
	{
		private SizeF	m_Size;

		public XmlSizeF2d()
		{
			
		}

		public XmlSizeF2d(Size newSize)
		{
			m_Size = newSize;
		}

		public XmlSizeF2d(float width, float height)
		{
			m_Size = new SizeF (width, height);
		}

		// Set serialization to ignore this property
		// because other properties are used instead to serialize the Color as an HTML string.
		[XmlIgnoreAttribute()]
		public SizeF Size
		{
			get { return m_Size;	}
			set { m_Size = value;	}
		}
		
		// Serializes the Width to XML.
		[System.Xml.Serialization.XmlAttribute ("Width")]
		public float Width
		{
			get { return m_Size.Width; }
			set { m_Size.Width = value; }
		}

		// Serializes the Height to XML.
		[System.Xml.Serialization.XmlAttribute ("Height")]
		public float Height
		{
			get { return m_Size.Height; }
			set { m_Size.Height = value; }
		}
	}
}
