using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Nolme.Xml;

namespace Nolme.WinForms
{
	/// <summary>
	/// Summary description for ChartDescription.
	/// </summary>
	public class ChartDescription : IDisposable
	{
		private int		m_LeftMargin;
		private int		m_RightMargin;
		private int		m_TopMargin;
		private int		m_BottomMargin;
		private int		m_DeltaDepth;

		private bool	m_DisplayTextOnColumns;
		private bool	m_DisplayHiddenSides;

		private Pen		m_GridPen;
		private Pen		m_GridPenFor0;

		private Pen		m_ColumnPen;
		private Font	m_ColumnFont;
		private Font	m_ColumnTitleFont;
		private Pen		m_HiddenColumnPen;
		
		private Brush	m_LegendBrush;
		private Font	m_LegendFont;

		private int		m_VerticalAxisMinValue;
		private int		m_VerticalAxisMaxValue;
		private int		m_VerticalAxisStep;
		private int		m_MarginBetweenColumn;

		private string	m_MainTitle;
		private Font	m_MainTitleFont;

		private ArrayList	m_Columns;

		private Color	[]m_PredefinedColors = {Color.FromArgb (125, Color.Red),
												   Color.FromArgb (125, Color.Green),
												   Color.FromArgb (125, Color.Blue),
												   Color.FromArgb (125, Color.Yellow),
												   Color.FromArgb (125, Color.Cyan),
												   Color.FromArgb (125, Color.Magenta),
												   Color.FromArgb (125, Color.Maroon),
												   Color.FromArgb (125, Color.Aqua),
												   Color.FromArgb (125, Color.Beige),
												   Color.FromArgb (125, Color.Orange),
												   Color.FromArgb (125, Color.Coral),
												   Color.FromArgb (125, Color.Lavender),
												   Color.FromArgb (125, Color.Gainsboro),
												   Color.FromArgb (125, Color.Ivory),
												   Color.FromArgb (125, Color.LemonChiffon),
												   Color.FromArgb (125, Color.Pink)};

		private	ChartRenderingMode	m_RenderingMode;
		private ChartCumulativeMode	m_CumulativeMode;

		public ChartDescription()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void InitDefault ()
		{
			this.LeftMargin				= 50;
			this.RightMargin			= 20;
			this.TopMargin				= 20;
			this.BottomMargin			= 20;
			this.DeltaDepth				= 10;

			this.GridPen				= new Pen (Color.Black, 1);
			this.GridPenFor0			= new Pen (Color.Violet, 2);
			this.ColumnPen				= new Pen (Color.Black, 1);
			this.HiddenColumnPen		= new Pen (Color.Gray, 1);

			this.LegendFont				= new Font("Arial", 11F, FontStyle.Bold);
			this.LegendBrush			= new SolidBrush(Color.Black);

			this.ColumnFont				= new Font("Arial", 8F, FontStyle.Italic);
			this.ColumnTitleFont		= new Font("Arial", 10F, FontStyle.Underline);

			this.MainTitle				= "Main title";
			this.MainTitleFont			= new Font("Arial", 16F, FontStyle.Underline | FontStyle.Bold);

			this.DisplayTextOnColumns	= true;
			this.DisplayHiddenSides		= true;

			this.VerticalAxisMinValue	= 0;
			this.VerticalAxisMaxValue	= 5000;
			this.VerticalAxisStep		= 1000;
			this.MarginBetweenColumn	= 20;

			this.m_Columns				= new ArrayList ();

			this.RenderingMode			= ChartRenderingMode.Linear3d;
			this.m_CumulativeMode		= ChartCumulativeMode.StartFrom0;	// Do not call Property to avoid computing of vertical axis
		}

		#region IDisposable implementation
		// Track whether Dispose has been called.
		private bool disposed;
		public void Dispose()
		{
			Dispose(true);
			// This object will be cleaned up by the Dispose method.
			// Therefore, you should call GC.SupressFinalize to
			// take this object off the finalization queue 
			// and prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly
		// or indirectly by a user's code. Managed and unmanaged resources
		// can be disposed.
		// If disposing equals false, the method has been called by the 
		// runtime from inside the finalizer and you should not reference 
		// other objects. Only unmanaged resources can be disposed.
		private void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if(!this.disposed)
			{
				// If disposing equals true, dispose all managed 
				// and unmanaged resources.
				if(disposing)
				{
					// Dispose managed resources.
					// Nothing to dispose : component.Dispose();
				}
             
				// Call the appropriate methods to clean up 
				// unmanaged resources here.
				// If disposing is false, 
				// only the following code is executed.
				if ( m_GridPen != null ) 
				{
					m_GridPen.Dispose ();
					Marshal.ReleaseComObject( m_GridPen );
					m_GridPen = null;
				}

				if ( m_GridPenFor0 != null ) 
				{
					m_GridPenFor0.Dispose ();
					Marshal.ReleaseComObject( m_GridPenFor0 );
					m_GridPenFor0 = null;
				}

				if ( m_ColumnPen != null ) 
				{
					m_ColumnPen.Dispose ();
					Marshal.ReleaseComObject( m_ColumnPen );
					m_ColumnPen = null;
				}

				if ( m_HiddenColumnPen != null ) 
				{
					m_HiddenColumnPen.Dispose ();
					Marshal.ReleaseComObject( m_HiddenColumnPen );
					m_HiddenColumnPen = null;
				}
			}
			disposed = true;
		}
		#endregion

		#region Properties
		public ChartCumulativeMode	CumulativeMode
		{
			get { return m_CumulativeMode; }
			set 
			{
				m_CumulativeMode = value; 
				// In this case, axis must be computed again
				// CALL ONLY THIS FUNCTION FOR STATE SAVING
				// OTHERWISE CALL Chart.CumulativeMode
			}
		}

		public ChartRenderingMode	RenderingMode
		{
			get { return m_RenderingMode; }
			set { m_RenderingMode = value; }
		}

		public Color	GetPredefinedColor (int colorIndex)
		{
			return m_PredefinedColors [colorIndex];
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Color[] PredefinedColors
		{
			get {return m_PredefinedColors; }
			set {m_PredefinedColors = value; }
		}

		[System.Xml.Serialization.XmlElement ("PredefinedColorList")]
		public XmlList XmlPredefinedColors
		{
			get {return new XmlList (m_PredefinedColors); }
			set 
			{
				if( value == null ) throw new NolmeWinFormsArgumentNullException ();
				object []NewArray = (value.Items.ArrayList.ToArray ());
				m_PredefinedColors = new Color [NewArray.Length];
				for (int i = 0 ; i< m_PredefinedColors.Length; i++)
				{
					m_PredefinedColors[i] = ((XmlColor)(NewArray[i])).Color;
				}		
			}
		}

		public int	NumberOfItemsPerColumn
		{
			get
			{
				int iCount = 0;
				if ((m_Columns != null) && (m_Columns.Count != 0))
				{
					ChartColumn column = (ChartColumn)m_Columns[0];
					iCount = column.Length;
				}
				return iCount;
			}
		}

		public int	LeftMargin
		{
			get {return m_LeftMargin; }
			set {m_LeftMargin = value; }
		}

		public int	RightMargin
		{
			get {return m_RightMargin; }
			set {m_RightMargin = value; }
		}

		public int	TopMargin
		{
			get {return m_TopMargin; }
			set {m_TopMargin = value; }
		}

		public int	BottomMargin
		{
			get {return m_BottomMargin; }
			set {m_BottomMargin = value; }
		}

		public int DeltaDepth
		{
			get {return m_DeltaDepth; }
			set {m_DeltaDepth = value; }
		}

		public bool	DisplayTextOnColumns
		{
			get {return m_DisplayTextOnColumns; }
			set {m_DisplayTextOnColumns = value; }
		}

		public bool	DisplayHiddenSides
		{
			get {return m_DisplayHiddenSides; }
			set {m_DisplayHiddenSides = value; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Pen		GridPen
		{
			get {return m_GridPen; }
			set {m_GridPen = value; }
		}

		[System.Xml.Serialization.XmlElement ("GridPen")]
		public XmlPen	XmlGridPen
		{
			get { return new XmlPen (m_GridPen); 	}
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_GridPen = new Pen (value.Pen.Brush, value.Width); }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Pen		GridPenFor0
		{
			get {return m_GridPenFor0; }
			set {m_GridPenFor0 = value; }
		}

		[System.Xml.Serialization.XmlElement ("GridPenFor0")]
		public XmlPen	XmlGridPenFor0
		{
			get { return new XmlPen (m_GridPenFor0); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_GridPenFor0 = value.Pen; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Pen		ColumnPen
		{
			get {return m_ColumnPen; }
			set {m_ColumnPen = value; }
		}

		[System.Xml.Serialization.XmlElement ("ColumnPen")]
		public XmlPen	XmlColumnPen
		{
			get {	return new XmlPen (m_ColumnPen); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_ColumnPen = value.Pen; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Pen		HiddenColumnPen
		{
			get {return m_HiddenColumnPen; }
			set {m_HiddenColumnPen = value; }
		}

		[System.Xml.Serialization.XmlElement ("HiddenColumnPen")]
		public XmlPen	XmlHiddenColumnPen
		{
			get {	return new XmlPen (m_HiddenColumnPen); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_HiddenColumnPen = value.Pen; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Brush	LegendBrush
		{
			get {return m_LegendBrush; }
			set {m_LegendBrush = value; }
		}

		[System.Xml.Serialization.XmlElement ("LegendBrush")]
		public XmlBrush	XmlLegendBrush
		{
			get {	return XmlBrush.AllocateXmlBrush (m_LegendBrush); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_LegendBrush = value.Brush; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Font	LegendFont
		{
			get {return m_LegendFont; }
			set {m_LegendFont = value; }
		}

		[System.Xml.Serialization.XmlElement ("LegendFont")]
		public XmlFont	XmlLegendFont
		{
			get {	return new XmlFont (m_LegendFont); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_LegendFont = value.Font; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Font	ColumnFont
		{
			get {return m_ColumnFont; }
			set {m_ColumnFont = value; }
		}

		[System.Xml.Serialization.XmlElement ("ColumnFont")]
		public XmlFont	XmlColumnFont
		{
			get {	return new XmlFont (m_ColumnFont); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_ColumnFont = value.Font; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public Font	ColumnTitleFont
		{
			get {return m_ColumnTitleFont; }
			set {m_ColumnTitleFont = value; }
		}

		[System.Xml.Serialization.XmlElement ("ColumnTitleFont")]
		public XmlFont	XmlColumnTitleFont
		{
			get {	return new XmlFont (m_ColumnTitleFont); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_ColumnTitleFont = value.Font; }
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
			get {	return new XmlFont (m_MainTitleFont); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_MainTitleFont = value.Font; }
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public string	MainTitle
		{
			get {return m_MainTitle; }
			set {m_MainTitle = value; }
		}

		[System.Xml.Serialization.XmlElement ("MainTitle")]
		public XmlString	XmlMainTitle
		{
			get {	return new XmlString (m_MainTitle); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_MainTitle = value.String; }
		}

		public int		VerticalAxisMinValue
		{
			get {return m_VerticalAxisMinValue; }
			set {m_VerticalAxisMinValue = value; }
		}

		public int		VerticalAxisMaxValue
		{
			get {return m_VerticalAxisMaxValue; }
			set {m_VerticalAxisMaxValue = value; }
		}

		public int		VerticalAxisStep
		{
			get {return m_VerticalAxisStep; }
			set {
				System.Diagnostics.Debug.Assert (value <= this.VerticalAxisMaxValue);
                //if (value <= this.VerticalAxisMaxValue)
                //    this.VerticalAxisMaxValue = value;
				m_VerticalAxisStep = value; 
			}
		}

		public int		MarginBetweenColumn
		{
			get {return m_MarginBetweenColumn; }
			set {m_MarginBetweenColumn = value; }
		}
		
		[System.Xml.Serialization.XmlIgnore ()]
		public ArrayList	Columns
		{
			get {return m_Columns; }		// Use carefully
		}

		[System.Xml.Serialization.XmlElement ("ColumnList")]
		public XmlList	XmlColumns
		{
			get { return new XmlList (m_Columns.ToArray());  }		// Use carefully
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					object []NewArray = (value.Items.ArrayList.ToArray ());
					m_Columns = new ArrayList (NewArray.Length);
					for (int i = 0 ; i< NewArray.Length; i++)
					{
						m_Columns.Add ((ChartColumn)NewArray[i]);
					}
				}
		}
		#endregion
	}
}
