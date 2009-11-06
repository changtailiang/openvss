using System;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Serialization;
using Nolme.Xml;

namespace Nolme.WinForms
{
	/// <summary>
	/// Summary description for ChartLegend.
	/// </summary>
	public class ChartLegend : CustomPanel
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ChartLegendDescription	m_ChartLegendDescription;

		public ChartLegend(System.ComponentModel.IContainer container)
		{
			Debug.Assert (container != null);

			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			if (container != null)
				container.Add(this);
			InitializeComponent();

			this.InitDefault ();
		}

		public ChartLegend()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			this.InitDefault ();
		}

		private void InitDefault ()
		{
			m_ChartLegendDescription = new ChartLegendDescription ();
			m_ChartLegendDescription.InitDefault ();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Properties
		public ChartLegendDescription	ChartLegendDescription
		{
			get {return m_ChartLegendDescription; }
			set {m_ChartLegendDescription = value; }
		}
		#endregion

		#region Highlevel functions
		virtual public ChartLegendItem	AddItem (Color itemColor, string text)
		{
			ChartLegendItem	newItem = new ChartLegendItem (itemColor, text);

			this.ChartLegendDescription.Items.Add (newItem);
			return newItem;
		}
		#endregion

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent) 
		{
			base.OnPaintBackground(pevent);

			if (this.ChartLegendDescription.Items != null)
			{
				int			delta			= this.ChartLegendDescription.ItemFont.Height - this.ChartLegendDescription.ItemSize;
				Rectangle	iconRectangle	= new Rectangle (this.ChartLegendDescription.LeftMargin + this.ChartLegendDescription.ItemLeftMargin, this.ChartLegendDescription.TopMargin + this.ChartLegendDescription.ItemTopMargin, this.ChartLegendDescription.ItemSize, this.ChartLegendDescription.ItemSize);
				Rectangle	textRectangle	= new Rectangle (iconRectangle.X + iconRectangle.Width + this.ChartLegendDescription.ItemRightMargin, iconRectangle.Y - delta / 2, this.Width - this.ChartLegendDescription.LeftMargin - this.ChartLegendDescription.ItemLeftMargin - iconRectangle.Width, this.ChartLegendDescription.ItemFont.Height);
				IEnumerator Iterator		= this.ChartLegendDescription.Items.GetEnumerator ();
				while (Iterator.MoveNext ())
				{
					ChartLegendItem	currentItem = (ChartLegendItem)Iterator.Current;

					// Draw item
					currentItem.OnPaintBackground (pevent, this, iconRectangle, textRectangle);

					// Next
					iconRectangle.Y += this.ChartLegendDescription.ItemSize + this.ChartLegendDescription.ItemBottomMargin;
					textRectangle.Y += this.ChartLegendDescription.ItemSize + this.ChartLegendDescription.ItemBottomMargin;
				}
			}

			// Draw main title
			this.DisplayTitle (pevent);
		}

		virtual protected void DisplayTitle (System.Windows.Forms.PaintEventArgs e)
		{
			if (this.ChartLegendDescription.MainTitle != null)
			{
				Point			point				= new Point (this.ChartLegendDescription.LeftMargin, 0);
				Size			size				= new Size (this.Width - this.ChartLegendDescription.LeftMargin - this.ChartLegendDescription.RightMargin, this.ChartLegendDescription.MainTitleFont.Height) ; //event.Graphics.MeasureString (this.MainTitle, this.MainTitleFont);
				StringFormat	legendDrawFormat	= new StringFormat();
				legendDrawFormat.Alignment			= StringAlignment.Center;
				legendDrawFormat.LineAlignment		= StringAlignment.Center;
				Rectangle textRectangle				= new Rectangle (point, size);

				e.Graphics.DrawString (this.ChartLegendDescription.MainTitle, this.ChartLegendDescription.MainTitleFont, this.ChartLegendDescription.MainTitleBrush, textRectangle, legendDrawFormat);
			}
		}

		#region Save /Load
		public virtual Type[] GetExtraTypes ()
		{
			Type [] BaseTypes = XmlConfiguration.GetXmlTypes ();
			Type [] ExtraTypes= new Type[BaseTypes.Length + 3];
			
			BaseTypes.CopyTo (ExtraTypes, 0);
			ExtraTypes[BaseTypes.Length + 0] = typeof(ChartLegendDescription);
			ExtraTypes[BaseTypes.Length + 1] = typeof(ChartLegendItem);
			ExtraTypes[BaseTypes.Length + 2] = typeof(ChartDescription);

			return ExtraTypes;
		}

		public void Save (string fileName)
		{
			Type [] extraTypes= this.GetExtraTypes ();

			StreamWriter objStreamWriter2 = new StreamWriter(fileName);
			XmlSerializer x2 = new XmlSerializer(this.ChartLegendDescription.GetType (), extraTypes);
			x2.Serialize(objStreamWriter2, this.ChartLegendDescription);
			objStreamWriter2.Close();
		}

		public void Load (string fileName)
		{
			this.ChartLegendDescription.InitDefault ();

			Type [] extraTypes= this.GetExtraTypes ();

			StreamReader objStreamReader = new StreamReader(fileName);
			XmlSerializer x2 = new XmlSerializer(this.ChartLegendDescription.GetType (), extraTypes);
			this.ChartLegendDescription = (ChartLegendDescription)x2.Deserialize(objStreamReader);
			objStreamReader.Close();
		}
		#endregion

	}
}
