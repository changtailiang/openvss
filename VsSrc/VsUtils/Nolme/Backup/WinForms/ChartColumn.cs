using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Diagnostics;
using Nolme.Xml;

namespace Nolme.WinForms
{
	/// <summary>
	/// Summary description for ChartColumn.
	/// </summary>
	public class ChartColumn
	{
		private int[]	m_Values;				/// Values in column
		private int		m_PositiveValuesSum;	/// Sum of all positives values stored (usd for debug & scaling)
		private int		m_NegativeValuesSum;	/// Sum of all negatives values stored (usd for debug & scaling)
		private int		m_HighestValue;			/// Highest value in all values stored
		private int		m_LowestValue;			/// Lowest value in all values stored
		private string	m_Title;				/// Title of column

		public ChartColumn()
		{
			m_Title = String.Empty;	
		}

		public ChartColumn(ChartColumn sourceColumn)
		{
			if( sourceColumn == null ) throw new NolmeWinFormsArgumentNullException ();

			this.m_Values				= new int [sourceColumn.m_Values.Length];
			sourceColumn.m_Values.CopyTo (this.m_Values, 0);
			this.m_PositiveValuesSum	= sourceColumn.m_PositiveValuesSum;
			this.m_NegativeValuesSum	= sourceColumn.m_NegativeValuesSum;
			this.m_HighestValue			= sourceColumn.m_HighestValue;
			this.m_LowestValue			= sourceColumn.m_LowestValue;
			this.m_Title				= sourceColumn.m_Title;
		}

		public ChartColumn(int []values)
		{
			this.Init (values);
		}

		public ChartColumn(int []values, string title)
		{
			this.Title = title;
			this.Init (values);
		}

		void Init (int []values)
		{
			this.AssignValues (values);
		}

		#region Properties
		public int HighestValue
		{
			get {return m_HighestValue;}
		}

		public int LowestValue
		{
			get {return m_LowestValue;}
		}

		public int PositiveValuesSum
		{
			get {return m_PositiveValuesSum;}
		}

		public int NegativeValuesSum
		{
			get {return m_NegativeValuesSum;}
		}

		public int Length
		{
			get {return m_Values.Length;}
		}

		[System.Xml.Serialization.XmlIgnore ()]
		public string Title
		{
			get {return m_Title; }
			set {m_Title = value; }
		}

		[System.Xml.Serialization.XmlElement ("MainTitle")]
		public XmlString XmlTitle
		{
			get {return new XmlString (m_Title); }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					m_Title = value.String; }
		}

		[System.Xml.Serialization.XmlIgnore ()] 
		public int[] Values
		{
			get { return m_Values; }
			set { this.AssignValues (value); }
		}

		[System.Xml.Serialization.XmlElement ("ItemList")] 
		public XmlList XmlValues
		{
			get {	return new XmlList (this.Values);  }
			set {	if( value == null ) throw new NolmeWinFormsArgumentNullException ();
					object []NewArray = (value.Items.ArrayList.ToArray ());
					int []TmpValues = new int [NewArray.Length];
					NewArray.CopyTo (TmpValues, 0); 
					this.AssignValues (TmpValues);		// Use this function to update highest value, min, max...
					}
		}

		public void AssignValues (int[] valuesToSet)
		{
			if( valuesToSet == null ) throw new NolmeWinFormsArgumentNullException ();

			m_Values			= valuesToSet;
			m_NegativeValuesSum	= 0;
			m_PositiveValuesSum	= 0;
			m_HighestValue		= int.MinValue;
			m_LowestValue		= int.MaxValue;
			for (int i = 0; i < valuesToSet.Length; i++)
			{
				if (valuesToSet [i] >= 0)
					m_PositiveValuesSum	+= valuesToSet [i];
				else
					m_NegativeValuesSum	+= valuesToSet [i];

				if (valuesToSet [i] > m_HighestValue)
				{
					m_HighestValue = valuesToSet [i];
				}
				if (valuesToSet [i] < m_LowestValue)
				{
					m_LowestValue = valuesToSet [i];
				}
			}
		}

		public void ResetValues ()
		{
			if (m_Values != null)
			{
				for (int i = 0; i < m_Values.Length; i++)
				{
					m_Values [i] = 0;
				}
			}

			m_NegativeValuesSum	= 0;
			m_PositiveValuesSum	= 0;
			m_HighestValue		= int.MinValue;
			m_LowestValue		= int.MaxValue;
		}

		#endregion

		#region Drawing
		virtual internal void DisplayAsLinear (System.Windows.Forms.PaintEventArgs pevent, Chart parent, ChartColumn	previousColumn, 
												int columnWidthNoMargin, int verticalAxisMaxValueInPixels, 
												Point base0, Point base1, Point base2, Point base3,
												Point prevBase0, Point prevBase1, Point prevBase2, Point prevBase3)
		{
			Debug.Assert (parent.ChartDescription.RenderingMode == ChartRenderingMode.Linear3d, "ChartColumn.DisplayBars", "Rendering mode not yet managed");

			// First column, nothing to draw
			if (previousColumn == null)
				return;

			// Draw all values
			for (int i = 0; i < this.m_Values.Length; i++)
			{
				Color		currentColor		= parent.ChartDescription.GetPredefinedColor (i);
				Brush		CurrentBrush		= new SolidBrush (currentColor);
				Brush		CurrentBrushDarken	= new SolidBrush (Color.FromArgb (currentColor.A, currentColor.R  /2, currentColor.G  /2, currentColor.B  /2));

				// Compute points
				int			prevY			= prevBase0.Y - (previousColumn.m_Values[i] * verticalAxisMaxValueInPixels / (parent.ChartDescription.VerticalAxisMaxValue - parent.ChartDescription.VerticalAxisMinValue));
				int			y				= base0.Y - (this.m_Values[i] * verticalAxisMaxValueInPixels / (parent.ChartDescription.VerticalAxisMaxValue - parent.ChartDescription.VerticalAxisMinValue));
				Point		currentPoint0	= new Point (prevBase0.X + columnWidthNoMargin / 2, prevY);
				Point		currentPoint1	= new Point (base0.X + columnWidthNoMargin / 2, y);
				Point		currentPoint2	= new Point (base3.X + columnWidthNoMargin / 2, y - parent.ChartDescription.DeltaDepth);
				Point		currentPoint3	= new Point (prevBase3.X + columnWidthNoMargin / 2, prevY - parent.ChartDescription.DeltaDepth);
			
				// Local top value path
				GraphicsPath pathSubValues = new GraphicsPath ();

				pathSubValues.AddLine (currentPoint0, currentPoint1);
				pathSubValues.AddLine (currentPoint1, currentPoint2);
				pathSubValues.AddLine (currentPoint2, currentPoint3);
				pathSubValues.AddLine (currentPoint3, currentPoint0);
				if (prevY > y)
					pevent.Graphics.FillPath (CurrentBrushDarken, pathSubValues);
				else
					pevent.Graphics.FillPath (CurrentBrush, pathSubValues);
			}
		}

		virtual internal void DisplayAsBarWith3d (System.Windows.Forms.PaintEventArgs pevent, Chart parent, ChartColumn	previousColumn, 
													int columnWidthNoMargin, int verticalAxisMaxValueInPixels, 
													Point base0, Point base1, Point base2, Point base3,
													Point prevBase0, Point prevBase1, Point prevBase2, Point prevBase3, bool gradientMode)
		{
			bool  FirstNegativeBarToDraw = true;

			// Draw all values
			Point CurrentBase0 = base0;
			Point CurrentBase1 = base1;
			Point CurrentBase2 = base2;
			Point CurrentBase3 = base3;

			Point CurrentBasePositive0 = base0;
			Point CurrentBasePositive1 = base1;
			Point CurrentBasePositive2 = base2;
			Point CurrentBasePositive3 = base3;

			Point CurrentBaseNegative0 = base0;
			Point CurrentBaseNegative1 = base1;
			Point CurrentBaseNegative2 = base2;
			Point CurrentBaseNegative3 = base3;

			for (int i = 0; i < this.m_Values.Length; i++)
			{
				// Check if current value is the top level (all next values are 0)
				// This boolean is used to known when we must draw the top of bar
				bool AllNextValuesAreZero = true;
				for (int j = i+1; j < this.m_Values.Length; j++)
				{
					if (this.m_Values[j] != 0)
					{
						AllNextValuesAreZero = false;
						break;
					}
				}

				//
				int   offset      = this.m_Values[i] * (verticalAxisMaxValueInPixels) / (parent.ChartDescription.VerticalAxisMaxValue - parent.ChartDescription.VerticalAxisMinValue);

				if (this.m_Values[i] != 0)
				{
					if (this.m_Values[i] >= 0)
					{
						CurrentBase0 = CurrentBasePositive0;
						CurrentBase1 = CurrentBasePositive1;
						CurrentBase2 = CurrentBasePositive2;
						CurrentBase3 = CurrentBasePositive3;
					}
					else
					{
						CurrentBase0 = CurrentBaseNegative0;
						CurrentBase1 = CurrentBaseNegative1;
						CurrentBase2 = CurrentBaseNegative2;
						CurrentBase3 = CurrentBaseNegative3;
					}

					Point	CurrentTop0			= new Point (CurrentBase0.X, CurrentBase0.Y - offset);
					Point	CurrentTop1			= new Point (CurrentBase1.X, CurrentBase1.Y - offset);
					Point	CurrentTop2			= new Point (CurrentBase2.X, CurrentBase2.Y - offset);
					Point	CurrentTop3			= new Point (CurrentBase3.X, CurrentBase3.Y - offset);
					Color	CurrentColor		= parent.ChartDescription.GetPredefinedColor (i);

					//
					// 3D Gradient & 3D Flat
					//
					if ((parent.ChartDescription.RenderingMode == ChartRenderingMode.BarWith3dGradient) ||(parent.ChartDescription.RenderingMode == ChartRenderingMode.BarWith3d))
					{
						// Solid brush or gradient brush
						Color CurrentColor2;
						if (parent.ChartDescription.RenderingMode == ChartRenderingMode.BarWith3dGradient)
							CurrentColor2	= Color.FromArgb (CurrentColor.A, CurrentColor.R  /2, CurrentColor.G  /2, CurrentColor.B  /2);
						else
							CurrentColor2	= CurrentColor;

						// Compute boundaries to fill
						GraphicsPath		pathSubValues = new GraphicsPath ();
						LinearGradientBrush	CurrentBrush;
						if (this.m_Values[i] >= 0)
						{
							Point TopLeft		= new Point (CurrentBase2.X, CurrentBase1.Y);
							Point BottomRight	= new Point (CurrentTop0.X, CurrentTop3.Y);
							CurrentBrush		= new LinearGradientBrush (TopLeft, BottomRight, CurrentColor, CurrentColor2);

							pathSubValues.AddLine (CurrentBase0, CurrentBase1);
							pathSubValues.AddLine (CurrentBase1, CurrentBase2);
							pathSubValues.AddLine (CurrentBase2, CurrentTop2);

							if (AllNextValuesAreZero)
							{
								// Add the 'Top' part'	
								pathSubValues.AddLine (CurrentTop2, CurrentTop3);
								pathSubValues.AddLine (CurrentTop3, CurrentTop0);
								pathSubValues.AddLine (CurrentTop0, CurrentBase0);
							}
							else
							{
								// Skip the 'Top' part
								pathSubValues.AddLine (CurrentTop2, CurrentTop1);
								pathSubValues.AddLine (CurrentTop1, CurrentTop0);
								pathSubValues.AddLine (CurrentTop0, CurrentBase0);
							}
						}
						else 
						{
							Point TopLeft		= new Point (CurrentBase0.X, CurrentBase3.Y);
							Point BottomRight	= new Point (CurrentTop2.X, CurrentTop1.Y);
							CurrentBrush		= new LinearGradientBrush (TopLeft, BottomRight, CurrentColor, CurrentColor2);

							pathSubValues.AddLine (CurrentTop0, CurrentTop1);
							pathSubValues.AddLine (CurrentTop1, CurrentTop2);
							pathSubValues.AddLine (CurrentTop2, CurrentBase2);
							if (( FirstNegativeBarToDraw) && (this.PositiveValuesSum == 0))
							{
								// Add the 'Top' part'	
								pathSubValues.AddLine (CurrentBase2, CurrentBase3);
								pathSubValues.AddLine (CurrentBase3, CurrentBase0);
								pathSubValues.AddLine (CurrentBase0, CurrentTop0);
								FirstNegativeBarToDraw = false;
							}
							else
							{
								// Skip the 'Top' part
								pathSubValues.AddLine (CurrentBase2, CurrentBase1);
								pathSubValues.AddLine (CurrentBase1, CurrentBase0);
								pathSubValues.AddLine (CurrentBase0, CurrentTop0);
							}
						}

						// Fill path
						pevent.Graphics.FillPath (CurrentBrush, pathSubValues);

						// Draw borders on path
						this.DisplayBorders (pevent, parent, this.m_Values[i], CurrentBase0, CurrentBase1, CurrentBase2, CurrentBase3, CurrentTop0, CurrentTop1, CurrentTop2, CurrentTop3);
					}
					else
					{
						Debug.Assert (parent.ChartDescription.RenderingMode == ChartRenderingMode.Linear3d, "ChartColumn.DisplayBars", "Rendering mode not yet managed");
					}

					// Next
					if (parent.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFromLastValue)
					{
						if (this.m_Values[i] >= 0)
						{
							CurrentBasePositive0 = CurrentTop0;
							CurrentBasePositive1 = CurrentTop1;
							CurrentBasePositive2 = CurrentTop2;
							CurrentBasePositive3 = CurrentTop3;
						}
						else
						{
							CurrentBaseNegative0 = CurrentTop0;
							CurrentBaseNegative1 = CurrentTop1;
							CurrentBaseNegative2 = CurrentTop2;
							CurrentBaseNegative3 = CurrentTop3;
						}
					}
				}
			}

			// Redraw top to override hidden pen color
			GraphicsPath pathTop = new GraphicsPath ();
			pathTop.AddLine (CurrentBasePositive0, CurrentBasePositive1);
			pathTop.AddLine (CurrentBasePositive1, CurrentBasePositive2);
			pathTop.AddLine (CurrentBasePositive2, CurrentBasePositive3);
			pathTop.AddLine (CurrentBasePositive3, CurrentBasePositive0);
			pevent.Graphics.DrawPath (parent.ChartDescription.ColumnPen, pathTop);
		}

		virtual internal void DisplayBorders (System.Windows.Forms.PaintEventArgs pevent, Chart parent, int currentValue,
											Point base0, Point base1, Point base2, Point base3,
											Point top0, Point top1, Point top2, Point top3)
		{
			if (parent.ChartDescription.DisplayHiddenSides)
			{
				if (currentValue >= 0)
				{
					pevent.Graphics.DrawLine (parent.ChartDescription.HiddenColumnPen, base0, base3);
					pevent.Graphics.DrawLine (parent.ChartDescription.HiddenColumnPen, base3, top3);
					pevent.Graphics.DrawLine (parent.ChartDescription.HiddenColumnPen, base3, base2);
				}
				else
				{
					pevent.Graphics.DrawLine (parent.ChartDescription.HiddenColumnPen, top0, top3);
					pevent.Graphics.DrawLine (parent.ChartDescription.HiddenColumnPen, base3, top3);
					pevent.Graphics.DrawLine (parent.ChartDescription.HiddenColumnPen, top3, top2);
				}
			}

			// Top
			/*GraphicsPath pathTop = new GraphicsPath ();
			pathTop.AddLine (top0, top1);
			pathTop.AddLine (top1, top2);
			pathTop.AddLine (top2, top3);
			pathTop.AddLine (top3, top0);
			pevent.Graphics.DrawPath (parent.ColumnPen, pathTop);
			*/

			// Left
			/*GraphicsPath pathSubValueLeft = new GraphicsPath ();
			pathSubValueLeft.AddLine (currentBase0, currentBase3);
			pathSubValueLeft.AddLine (currentBase3, currentTop3);
			pathSubValueLeft.AddLine (currentTop3, currentTop0);
			pathSubValueLeft.AddLine (currentTop0, currentBase0);
			pevent.Graphics.FillPath (CurrentBrushDarken, pathSubValueLeft);*/

			// Back
			/*GraphicsPath pathSubValueBack = new GraphicsPath ();
			pathSubValueBack.AddLine (currentBase3, currentBase2);
			pathSubValueBack.AddLine (currentBase2, currentTop2);
			pathSubValueBack.AddLine (currentTop2, currentTop3);
			pathSubValueBack.AddLine (currentTop3, currentBase3);
			pevent.Graphics.FillPath (CurrentBrushDarken, pathSubValueBack);*/

			// Front
			GraphicsPath pathSubValueFront = new GraphicsPath ();
			pathSubValueFront.AddLine (base0, base1);
			pathSubValueFront.AddLine (base1, top1);
			pathSubValueFront.AddLine (top1, top0);
			pathSubValueFront.AddLine (top0, base0);
			pevent.Graphics.DrawPath (parent.ChartDescription.ColumnPen, pathSubValueFront);

			// Right
			GraphicsPath pathSubValueRightSide = new GraphicsPath ();
			pathSubValueRightSide.AddLine (base1, base2);
			pathSubValueRightSide.AddLine (base2, top2);
			pathSubValueRightSide.AddLine (top2, top1);
			pathSubValueRightSide.AddLine (top1, base1);
			pevent.Graphics.DrawPath (parent.ChartDescription.ColumnPen, pathSubValueRightSide);
		}

		/// <summary>
		/// Display title of column on bottom of grid
		/// </summary>
		/// <param name="pevent"></param>
		/// <param name="parent"></param>
		/// <param name="base0"></param>
		/// <param name="base1"></param>
		virtual internal void DisplayTitle (System.Windows.Forms.PaintEventArgs pevent, Chart parent, Point base0, Point base1)
		{
			if (this.Title != null)
			{
				StringFormat legendDrawFormat	= new StringFormat();
				legendDrawFormat.Alignment		= StringAlignment.Far;
				legendDrawFormat.LineAlignment	= StringAlignment.Center;

				// Draw oblique
				Matrix oldMatrix = pevent.Graphics.Transform.Clone();
				pevent.Graphics.TranslateTransform( base0.X + (base1.X-base0.X)/2, base0.Y + 5);	// Add few pixels
				pevent.Graphics.RotateTransform(-45);
				pevent.Graphics.DrawString(this.Title, parent.ChartDescription.ColumnTitleFont, parent.ChartDescription.LegendBrush, 0, 0, legendDrawFormat);
				pevent.Graphics.Transform = oldMatrix;
			}
		}


		/// <summary>
		/// Draw some text on top of the chart column
		/// </summary>
		/// <param name="pevent"></param>
		/// <param name="parent"></param>
		/// <param name="backgroundRectangle"></param>
		virtual internal void DisplayText (System.Windows.Forms.PaintEventArgs pevent, Chart parent, RectangleF backgroundRectangle)
		{
			// Draw legend background
			LinearGradientBrush	backgroundBrush = new LinearGradientBrush (backgroundRectangle, Color.White, Color.Gray, 45.0f, true);
			pevent.Graphics.FillRectangle (backgroundBrush, backgroundRectangle);
			pevent.Graphics.DrawRectangle (parent.ChartDescription.ColumnPen, backgroundRectangle.X, backgroundRectangle.Y, backgroundRectangle.Width, backgroundRectangle.Height);

			// Draw legend
			int TotalValues = this.PositiveValuesSum - this.NegativeValuesSum;
			pevent.Graphics.DrawString (TotalValues.ToString (CultureInfo.InvariantCulture), parent.ChartDescription.ColumnFont, parent.ChartDescription.LegendBrush, backgroundRectangle);
		}
		#endregion
	}
}
