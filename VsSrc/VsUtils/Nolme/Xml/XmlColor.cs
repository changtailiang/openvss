using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlColor.
	/// </summary>
	public class XmlColor
	{
		private Color	m_Color = Color.Black;

		public XmlColor ()
		{
		}

		public XmlColor (Color newColor)
		{
			m_Color = newColor;
		}

		#region Properties
		// Set serialization to ignore this property
		// because the 'Name' property
		// is used instead to serialize the Color as an HTML string.
		[XmlIgnoreAttribute()]
		public Color Color
		{
			get { return m_Color;	}
			set { m_Color = value;	}
		}
		
		// Serializes the Color to XML.
		[System.Xml.Serialization.XmlAttribute ("Name")]
		public string Name
		{
			get { return ColorTranslator.ToHtml(m_Color); }
			set { m_Color = ColorTranslator.FromHtml( value ); }
		}

		// Serializes the Color to XML.
		[System.Xml.Serialization.XmlAttribute ("Alpha")]
		public int Alpha
		{
			get { return m_Color.A; }
			set { m_Color = Color.FromArgb (value, m_Color.R, m_Color.G, m_Color.B); }
		}

		// Serializes the Color to XML.
		[System.Xml.Serialization.XmlAttribute ("Red")]
		public int Red
		{
			get { return m_Color.R; }
			set { m_Color = Color.FromArgb (m_Color.A, value, m_Color.G, m_Color.B); }
		}

		// Serializes the Color to XML.
		[System.Xml.Serialization.XmlAttribute ("Green")]
		public int Green
		{
			get { return m_Color.G; }
			set { m_Color = Color.FromArgb (m_Color.A, m_Color.R, value, m_Color.B); }
		}

		// Serializes the Color to XML.
		[System.Xml.Serialization.XmlAttribute ("Blue")]
		public int Blue
		{
			get { return m_Color.B; }
			set { m_Color = Color.FromArgb (m_Color.A, m_Color.R, m_Color.G, value); }
		}
		#endregion

		#region Static
		public static XmlColor[]	ConvertArray (Color []array)
		{
			XmlColor[] Result = null;
			if (array != null)
			{
				Result = new XmlColor [array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					Result[i] = new XmlColor (array[i]);
				}
			}
			return Result;
		}

		public static Color[]	ConvertArray (XmlColor []array)
		{
			Color[] Result = null;
			if (array != null)
			{
				Result = new Color [array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					Result[i] = array[i].Color;
				}
			}
			return Result;
		}
		#endregion
	}
}
