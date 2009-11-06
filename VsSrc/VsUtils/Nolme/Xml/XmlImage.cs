using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlImage.
	/// XML Serialization not finished
	/// </summary>
	public class XmlImage
	{
		private Image	m_Image;

		public XmlImage()
		{
			
		}

		public XmlImage(Image image)
		{
			m_Image = image;
		}

		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public Image Image
		{
			get { return m_Image; }
			set { m_Image = value; }
		}

		[System.Xml.Serialization.XmlElement ("Height")]
		public int Height
		{
			get { return this.Image.Height; }
			set { /* read only */ }
		}

		[System.Xml.Serialization.XmlElement ("Width")]
		public int Width
		{
			get { return this.Image.Width; }
			set { /* read only */ }
		}
		#endregion
	}
}
