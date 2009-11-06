using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;
using Nolme.Xml;

namespace Nolme.WinForms
{
	public class ChartLegendDescription
	{
		private int		m_LeftMargin;
		private int		m_RightMargin;
		private int		m_TopMargin;
		private int		m_BottomMargin;

		private int		m_ItemLeftMargin;
		private int		m_ItemRightMargin;
		private int		m_ItemTopMargin;
		private int		m_ItemBottomMargin;
		private int		m_ItemSize;
		private Font	m_ItemFont;
		private Brush	m_ItemBrush;

		private string	m_MainTitle;
		private Font	m_MainTitleFont;
		private Brush	m_MainTitleBrush;

		private ArrayList	m_Items;

		public ChartLegendDescription()
		{
			this.InitDefault ();
		}

		public void InitDefault ()
		{
			this.LeftMargin				= 20;
			this.RightMargin			= 20;
			this.TopMargin				= 20;
			this.BottomMargin			= 20;

			this.ItemLeftMargin			= 5;
			this.ItemRightMargin		= 10;
			this.ItemTopMargin			= 20;
			this.ItemBottomMargin		= 30;
			this.ItemSize				= 10;
			this.ItemFont				= new Font("Arial", 12F, FontStyle.Italic);
			this.ItemBrush				= new SolidBrush(Color.Black);
			
			//this.ItemBrush				= new LinearGradientBrush(new Rectangle (0,0,200,200), Color.Black, Color.Blue, 15, false);
			
			/*Bitmap image1 = (Bitmap) Image.FromFile(@"C:\Windows\plume.bmp", true);
			TextureBrush texture = new TextureBrush(image1);
			texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
			this.ItemBrush	= texture;*/

			this.MainTitle				= "Main title";
			this.MainTitleFont			= new Font("Arial", 16F, FontStyle.Underline | FontStyle.Bold);
			this.MainTitleBrush			= new SolidBrush(Color.Black);

			this.m_Items				= new ArrayList ();
		}

		#region Properties
		[System.Xml.Serialization.XmlAttribute ("LeftMargin")]
		public int	LeftMargin
		{
			get {return m_LeftMargin; }
			set {m_LeftMargin = value; }
		}
		
		[System.Xml.Serialization.XmlAttribute ("RightMargin")]
		public int	RightMargin
		{
			get {return m_RightMargin; }
			set {m_RightMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("TopMargin")]
		public int	TopMargin
		{
			get {return m_TopMargin; }
			set {m_TopMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("BottomMargin")]
		public int	BottomMargin
		{
			get {return m_BottomMargin; }
			set {m_BottomMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("ItemLeftMargin")]
		public int	ItemLeftMargin
		{
			get {return m_ItemLeftMargin; }
			set {m_ItemLeftMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("ItemRightMargin")]
		public int	ItemRightMargin
		{
			get {return m_ItemRightMargin; }
			set {m_ItemRightMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("ItemTopMargin")]
		public int	ItemTopMargin
		{
			get {return m_ItemTopMargin; }
			set {m_ItemTopMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("ItemBottomMargin")]
		public int	ItemBottomMargin
		{
			get {return m_ItemBottomMargin; }
			set {m_ItemBottomMargin = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("ItemSize")]
		public int	ItemSize
		{
			get {return m_ItemSize; }
			set {m_ItemSize = value; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Font	ItemFont
		{
			get {return m_ItemFont; }
			set {m_ItemFont = value; }
		}

		[System.Xml.Serialization.XmlElement ("ItemFont")]
		public XmlFont	ItemXmlFont
		{
			get {	return new XmlFont (m_ItemFont); }
			set {	if ( value == null) throw new NolmeWinFormsArgumentNullException ();
					m_ItemFont = value.Font; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Brush	ItemBrush
		{
			get {return m_ItemBrush; }
			set {m_ItemBrush = value; }
		}

		[System.Xml.Serialization.XmlElement ("ItemBrush")]
		public XmlBrush	ItemXmlBrush
		{
			get { return XmlBrush.AllocateXmlBrush (m_ItemBrush); }
			set {	if ( value == null) throw new NolmeWinFormsArgumentNullException ();
					m_ItemBrush = value.Brush; }
		}

		[System.Xml.Serialization.XmlElement ("MainTitle")]
		public string	MainTitle
		{
			get {return m_MainTitle; }
			set {m_MainTitle = value; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Font	MainTitleFont
		{
			get {return m_MainTitleFont; }
			set {m_MainTitleFont = value; }
		}

		[System.Xml.Serialization.XmlElement ("MainTitleFont")]
		public XmlFont	XmlMainTitleFont
		{
			get {return new XmlFont (m_MainTitleFont); }
			set {	if ( value == null) throw new NolmeWinFormsArgumentNullException ();
					m_MainTitleFont = value.Font; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Brush	MainTitleBrush
		{
			get {return m_MainTitleBrush; }
			set {m_MainTitleBrush = value; }
		}

		[System.Xml.Serialization.XmlElement ("MainTitleBrush")]
		public XmlBrush	XmlMainTitleBrush
		{
			get { return XmlBrush.AllocateXmlBrush (m_MainTitleBrush); }
			set {	if ( value == null) throw new NolmeWinFormsArgumentNullException ();
					m_MainTitleBrush = value.Brush; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public ArrayList	Items
		{
			get {return m_Items; }
			set { m_Items = value; }
		}

		[System.Xml.Serialization.XmlElement ("ItemList")]
		public XmlList	XmlItems
		{
			get {return new XmlList (m_Items.ToArray ()); }
			set {	if ( value == null) throw new NolmeWinFormsArgumentNullException ();
					m_Items = value.Items.ArrayList; }
		}
		#endregion

		#region Highlevel functions
		virtual public ChartLegendItem	AddItem (Color itemColor, string text)
		{
			ChartLegendItem	newItem = new ChartLegendItem (itemColor, text);

			this.m_Items.Add (newItem);
			return newItem;
		}
		#endregion

	}
}
