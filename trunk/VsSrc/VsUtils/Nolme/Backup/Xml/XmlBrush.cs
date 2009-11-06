using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlBrush.
	/// </summary>
	public abstract class XmlBrush
	{
		private Brush		m_Brush;

		static public XmlBrush AllocateXmlBrush (Brush brush)
		{
			SolidBrush			NewSolidBrush			= brush as SolidBrush;
			LinearGradientBrush NewLinearGradientBrush	= brush as LinearGradientBrush;
			TextureBrush		NewTextureBrush			= brush as TextureBrush;

			if (NewSolidBrush != null)				return new XmlSolidBrush			(NewSolidBrush); 
			if (NewLinearGradientBrush != null)		return new XmlLinearGradientBrush	(NewLinearGradientBrush); 
			if (NewTextureBrush != null)			return new XmlTextureBrush			(NewTextureBrush); 

			// Unknown brush type
			throw new NolmeXmlInvalidCaseException ();
		}

		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public Brush Brush
		{
			get { return this.m_Brush; }
			set { this.m_Brush = value; }
		}
		#endregion
	}


	/// <summary>
	/// Summary description for XmlSolidBrush.
	/// </summary>
	public class XmlSolidBrush : XmlBrush
	{
		public XmlSolidBrush()
		{
			
		}

		public XmlSolidBrush(SolidBrush newBrush)
		{
			this.Brush = newBrush;
		}

		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public Color Color
		{
			get { return ((SolidBrush)this.Brush).Color; }
			set { if (this.Brush == null) throw new NolmeXmlMemberNullException ();
				((SolidBrush)this.Brush).Color = value; }
		}

		[System.Xml.Serialization.XmlElement ("Color")]
		public XmlColor XmlColor
		{
			get { return new XmlColor (((SolidBrush)this.Brush).Color); }
			set {	if (value == null) throw new NolmeXmlArgumentNullException ();
					SolidBrush NewBrush  = new SolidBrush (value.Color); 
					this.Brush = NewBrush; }
		}
		#endregion
	}

	/// <summary>
	/// Summary description for XmlLinearGradientBrush. TODO
	/// </summary>
	public class XmlLinearGradientBrush : XmlBrush
	{
		public XmlLinearGradientBrush()
		{
			
		}

		public XmlLinearGradientBrush(LinearGradientBrush newBrush)
		{
			this.Brush = newBrush;
		}

		#region Properties
		[System.Xml.Serialization.XmlElement ("Rectangle")]
		public RectangleF Rectangle
		{
			get { return ((LinearGradientBrush)this.Brush).Rectangle; }
			set { /* Nothing to add */ }
		}

		[System.Xml.Serialization.XmlElement ("Blend")]
		public Blend Blend
		{
			get { return ((LinearGradientBrush)this.Brush).Blend; }
			set { ((LinearGradientBrush)this.Brush).Blend = value; }
		}

		[System.Xml.Serialization.XmlElement ("GammaCorrection")]
		public bool GammaCorrection
		{
			get { return ((LinearGradientBrush)this.Brush).GammaCorrection; }
			set { ((LinearGradientBrush)this.Brush).GammaCorrection = value; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public ColorBlend InterpolationColors
		{
			get { return ((LinearGradientBrush)this.Brush).InterpolationColors; }
			set { ((LinearGradientBrush)this.Brush).InterpolationColors = value; }
		}

		/*[System.Xml.Serialization.XmlElement ("InterpolationColors")]
		public XmlColorBlend XmlInterpolationColors
		{
			get { 	//ColorBlend test2 = ((LinearGradientBrush)this.Brush).InterpolationColors;
					ColorBlend test = new ColorBlend (10);
					XmlColorBlend MyColors = new XmlColorBlend (test); return MyColors; 
				}
			set { ((LinearGradientBrush)this.Brush).InterpolationColors = null; }
		}*/

		[System.Xml.Serialization.XmlIgnore ()]
		public  Color[] LinearColors
		{
			get { return ((LinearGradientBrush)this.Brush).LinearColors; }
			set { ((LinearGradientBrush)this.Brush).LinearColors = value; }
		}

		[System.Xml.Serialization.XmlElement ("LinearColors")]
		public XmlList XmlLinearColors
		{
			get { return new XmlList(((LinearGradientBrush)this.Brush).LinearColors); }
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
				((LinearGradientBrush)this.Brush).LinearColors = NewColors;
			}
		}

		[System.Xml.Serialization.XmlElement ("Transform")]
		public Matrix Transform
		{
			get { return ((LinearGradientBrush)this.Brush).Transform; }
			set { ((LinearGradientBrush)this.Brush).Transform = value; }
		}

		[System.Xml.Serialization.XmlElement ("WrapMode")]
		public WrapMode WrapMode
		{
			get { return ((LinearGradientBrush)this.Brush).WrapMode; }
			set { ((LinearGradientBrush)this.Brush).WrapMode = value; }
		}
		#endregion
	}

	/// <summary>
	/// Summary description for XmlTextureBrush.
	/// </summary>
	public class XmlTextureBrush : XmlBrush
	{
		public XmlTextureBrush()
		{
			
		}

		public XmlTextureBrush(TextureBrush newBrush)
		{
			this.Brush = newBrush;
		}

		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public Image Image
		{
			get { return ((TextureBrush)this.Brush).Image; }
			set { /* Read only */ }
		}

		[System.Xml.Serialization.XmlElement ("Image")]
		public XmlImage XmlImage
		{
			get { return new XmlImage (((TextureBrush)this.Brush).Image); }
			set { /* Read only */  }
		}

		[System.Xml.Serialization.XmlElement ("Transform")]
		public Matrix Transform
		{
			get { return ((TextureBrush)this.Brush).Transform; }
			set { ((TextureBrush)this.Brush).Transform = value; }
		}

		[System.Xml.Serialization.XmlElement ("WrapMode")]
		public WrapMode WrapMode
		{
			get { return ((TextureBrush)this.Brush).WrapMode; }
			set { ((TextureBrush)this.Brush).WrapMode = value; }
		}
		#endregion
	}
}
