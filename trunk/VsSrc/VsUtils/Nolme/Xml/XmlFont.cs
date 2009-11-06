using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

// Thanks : http://forum.hardware.fr/hardwarefr/Programmation/C-Serializer-objet-Font-sujet-83305-1.htm

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlFont.
	/// </summary>
	public class XmlFont
	{
		private XmlString m_FontFamily;
		private System.Drawing.GraphicsUnit m_GraphicsUnit;
		private float m_Size;
		private System.Drawing.FontStyle m_Style;

		public XmlFont()
		{
		}

		public XmlFont(System.Drawing.Font newFont)
		{
			this.Font = newFont;
		}
		
		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public System.Drawing.Font Font
		{
			get { return new System.Drawing.Font(m_FontFamily.String, m_Size, m_Style, m_GraphicsUnit); }
			set {	if (value == null) throw new NolmeXmlArgumentNullException ();
					m_FontFamily = new XmlString (value.FontFamily.Name);
					m_GraphicsUnit = value.Unit;
					m_Size = value.Size;
					m_Style = value.Style;}
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public string FontFamily
		{
			get { return this.m_FontFamily.String; }
			set { this.m_FontFamily = new XmlString (value); }
		}

		[System.Xml.Serialization.XmlElement ("FontFamily")]
		public XmlString XmlFontFamily
		{
			get { return this.m_FontFamily; }
			set { this.m_FontFamily = value; }
		}

		[System.Xml.Serialization.XmlElement ("GraphicsUnit")]
		public System.Drawing.GraphicsUnit GraphicsUnit
		{
			get { return this.m_GraphicsUnit; }
			set { this.m_GraphicsUnit = value; }
		}

		[System.Xml.Serialization.XmlElement ("Size")]
		public float Size
		{
			get { return this.m_Size; }
			set { this.m_Size = value; }
		}

		[System.Xml.Serialization.XmlElement ("Style")]
		public System.Drawing.FontStyle Style
		{
			get { return this.m_Style; }
			set { this.m_Style = value; }
		}		
		#endregion
	}
}
