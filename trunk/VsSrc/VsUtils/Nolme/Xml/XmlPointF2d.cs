using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlPointF2d.
	/// </summary>
	public class XmlPointF2d
	{
		private PointF	m_Location;

		public XmlPointF2d()
		{
			
		}

		public XmlPointF2d(Point newLocation)
		{
			m_Location = newLocation;
		}

		public XmlPointF2d(float positionOnX, float positionOnY)
		{
			m_Location = new PointF (positionOnX, positionOnY);
		}

		// Set serialization to ignore this property
		// because other properties are used instead to serialize the Color as an HTML string.
		[XmlIgnoreAttribute()]
		public PointF FLocation
		{
			get { return m_Location;	}
			set { m_Location = value;	}
		}
		
		// Serializes the Width to XML.
		[System.Xml.Serialization.XmlAttribute ("X")]
		public float X
		{
			get { return m_Location.X; }
			set { m_Location.X = value; }
		}

		// Serializes the Height to XML.
		[System.Xml.Serialization.XmlAttribute ("Y")]
		public float Y
		{
			get { return m_Location.Y; }
			set { m_Location.Y = value; }
		}
	}
}
