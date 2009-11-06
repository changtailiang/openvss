using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using Nolme.Xml;

namespace Nolme.WinForms
{
	/// <summary>
	/// Summary description for ChartLegendItem.
	/// </summary>
	public class ChartLegendItem
	{
		private XmlString	m_Text;
		private XmlColor	m_Color;

		public ChartLegendItem()
		{
		}

		public ChartLegendItem(Color itemColor, string text)
		{
			m_Color	= new XmlColor (itemColor);
			m_Text	= new XmlString (text);
		}

		public ChartLegendItem(XmlColor itemColor, XmlString text)
		{
			m_Color	= itemColor;
			m_Text	= text;
		}

		#region Properties
		public XmlString	Text
		{
			get {return m_Text; }
			set {m_Text = value; }
		}

		public XmlColor	Color
		{
			get {return m_Color; }
			set {m_Color = value; }
		}
		#endregion

		internal void OnPaintBackground(System.Windows.Forms.PaintEventArgs e, ChartLegend parent, Rectangle iconRectangle, Rectangle textRectangle)
		{
			Pen		itemPen			= new Pen (System.Drawing.Color.Black);
			Brush	itemBrush		= new SolidBrush (this.Color.Color);
			Brush	itemTextBrush	= new SolidBrush (System.Drawing.Color.Black);

			e.Graphics.FillRectangle (itemBrush, iconRectangle);
			e.Graphics.DrawRectangle (itemPen, iconRectangle);

			StringFormat	legendDrawFormat	= new StringFormat();
			legendDrawFormat.Alignment			= StringAlignment.Near;
			legendDrawFormat.LineAlignment		= StringAlignment.Center;

			e.Graphics.DrawString (this.Text.String, parent.ChartLegendDescription.ItemFont, itemTextBrush, textRectangle, legendDrawFormat);
		}
	}
}
