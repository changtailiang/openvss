using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlColorBlend.
	/// </summary>
	public class XmlColorBlend
	{
		private ColorBlend	m_ColorBlend;

		public XmlColorBlend()
		{
			
		}

		public XmlColorBlend(ColorBlend color)
		{
			m_ColorBlend = color;
		}

		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public ColorBlend ColorBlend
		{
			get { return m_ColorBlend; }
			set { m_ColorBlend = value; }
		}

		[System.Xml.Serialization.XmlElement ("Colors")]
		public XmlList Colors
		{
			get { return new XmlList(m_ColorBlend.Colors); }
			set 
			{
				if (value == null) throw new NolmeXmlArgumentNullException ();

				XmlColor[] NewXmlColors = new XmlColor [value.Items.ArrayList.Count];
				Color[] NewColors = new Color [NewXmlColors.Length];
				value.Items.ArrayList.CopyTo (0, NewXmlColors, 0, value.Items.ArrayList.Count);
				for (int i = 0; i < NewXmlColors.Length; i++)
				{
					NewColors[i] = NewXmlColors[i].Color;
				}
				m_ColorBlend.Colors = NewColors;
			}
		}

		[System.Xml.Serialization.XmlElement ("Positions")]
		public XmlList Positions
		{
			get { return new XmlList(m_ColorBlend.Positions); }
			set {	if (value == null) throw new NolmeXmlArgumentNullException ();
					value.Items.ArrayList.CopyTo (0, m_ColorBlend.Positions, 0, value.Items.ArrayList.Count); }
		}
		#endregion
	}
}
