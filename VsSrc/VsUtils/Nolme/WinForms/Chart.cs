using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Nolme.Win32;
using Nolme.Xml;

namespace Nolme.WinForms
{
	public enum ChartRenderingMode
	{
		Linear3d,
		BarWith3d,
		BarWith3dGradient,
		Max
	};

	public enum ChartCumulativeMode
	{
		StartFrom0,
		StartFromLastValue,
		Max
	};

	/// <summary>
	/// Summary description for Chart.
	/// </summary>
	public class Chart : CustomPanel	//System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ChartDescription	m_ChartDescription;

		

		public Chart(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			if (container != null)
				container.Add(this);
			InitializeComponent();

			this.InitDefault ();
		}

		public Chart()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			this.InitDefault ();
		}

		public void InitDefault ()
		{
			this.ChartDescription = new ChartDescription ();
			this.ChartDescription.InitDefault ();
		}

		#region Properties
		public ChartDescription	ChartDescription
		{
			get { return m_ChartDescription; }
			set { m_ChartDescription = value; }
		}

		public ChartCumulativeMode	CumulativeMode
		{
			get { return this.ChartDescription.CumulativeMode; }
			set { this.ChartDescription.CumulativeMode = value; 
					// In this case, axis must be computed again
					this.AdjustVerticalAxis ();
				}
		}
		#endregion

		#region Highlevel functions
		public ChartColumn	AddColumn (int value)
		{
			int []localArray = new int [1];
			localArray[0] = value;
			
			return AddColumn (localArray);
		}

		public ChartColumn	AddColumn (int value0, int value1)
		{
			int []localArray = new int [2];
			localArray[0] = value0;
			localArray[1] = value1;
			
			return AddColumn (localArray);
		}

		public ChartColumn	AddColumn (int value0, int value1, int value2)
		{
			int []localArray = new int [3];
			localArray[0] = value0;
			localArray[1] = value1;
			localArray[2] = value2;
			
			return AddColumn (localArray);
		}

		public ChartColumn	AddColumn (int value0, int value1, int value2, int value3)
		{
			int []localArray = new int [4];
			localArray[0] = value0;
			localArray[1] = value1;
			localArray[2] = value2;
			localArray[3] = value3;
			
			return AddColumn (localArray);
		}

		public ChartColumn	AddColumn (int []values)
		{
			return this.AddColumn (values, null);
		}

		public ChartColumn	AddColumn (int []values, string title)
		{
			// Create new column
			ChartColumn	newColumn = this.AllocateColumn (values, title);

			// Resize vertical axis
			if (newColumn.PositiveValuesSum > this.ChartDescription.VerticalAxisMaxValue)
				this.ChartDescription.VerticalAxisMaxValue = newColumn.PositiveValuesSum;
			if (newColumn.NegativeValuesSum < this.ChartDescription.VerticalAxisMinValue)
				this.ChartDescription.VerticalAxisMinValue = newColumn.NegativeValuesSum;

			// Add column
			this.ChartDescription.Columns.Add (newColumn);
			return newColumn;
		}

		virtual protected ChartColumn	AllocateColumn (int []values, string title)
		{
			ChartColumn	newColumn = new ChartColumn (values, title);
			return newColumn;
		}

		/// <summary>
		/// Automatic detection and adjustment of vertical axis maximum
		/// </summary>
		public void AdjustVerticalAxis ()
		{
			// Reset current max
			this.ChartDescription.VerticalAxisMaxValue = 0;
			this.ChartDescription.VerticalAxisMinValue = 0;
			int savedVerticalAxisMaxValue = int.MinValue;
			int savedVerticalAxisMinValue = int.MaxValue;

			// Iterate to get highest value
			if (this.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFromLastValue)
			{
				IEnumerator Iterator = this.ChartDescription.Columns.GetEnumerator ();
				while (Iterator.MoveNext ())
				{
					ChartColumn currentColumn = (ChartColumn)Iterator.Current;
					if (currentColumn.PositiveValuesSum > savedVerticalAxisMaxValue)
						savedVerticalAxisMaxValue = currentColumn.PositiveValuesSum;
					if (currentColumn.NegativeValuesSum < savedVerticalAxisMinValue)
						savedVerticalAxisMinValue = currentColumn.NegativeValuesSum;
				}
			}
			else if (this.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFrom0)
			{
				IEnumerator Iterator = this.ChartDescription.Columns.GetEnumerator ();
				while (Iterator.MoveNext ())
				{
					ChartColumn currentColumn = (ChartColumn)Iterator.Current;
					if (currentColumn.HighestValue > savedVerticalAxisMaxValue)
						savedVerticalAxisMaxValue = currentColumn.HighestValue;
					if (currentColumn.LowestValue < savedVerticalAxisMinValue)
						savedVerticalAxisMinValue = currentColumn.LowestValue;
				}
			}
			else 
			{
				Debug.Assert (this.ChartDescription.CumulativeMode == ChartCumulativeMode.Max, "Chart.AdjustVerticalAxis", "Cumulative mode not managed");
			}

			// Compute digits for min & max and adjust to maximum digits
			// Avoir missing grid text when max = 1000 & min = -20 -> scale on [-1000..+1000]
			string	Value1		= savedVerticalAxisMaxValue.ToString (CultureInfo.InvariantCulture);
			int		NbMaxDigits = Value1.Length;
			string	Value2		= (-savedVerticalAxisMinValue).ToString (CultureInfo.InvariantCulture);
			int		NbMinDigits = Value2.Length;
			int		NbDigitsToUse = Math.Max (NbMaxDigits, NbMinDigits);
			
			// Round max value
			if (savedVerticalAxisMaxValue != 0)
			{
				if (savedVerticalAxisMaxValue == 0)
					this.ChartDescription.VerticalAxisMaxValue = 0;
				else
				{
					int Round    = (int)Math.Pow (10.0F, (double)(NbDigitsToUse - 1));
					// N.B.: Round must be an even number in order to make the following calculation works
					// As Round is a base-10 number, this condition is true.
					Debug.Assert (Round%2 == 0, "Chart.AdjustVerticalAxis ()", "Can't proceed when Round is odd");
					this.ChartDescription.VerticalAxisMaxValue = ((savedVerticalAxisMaxValue + Round) / Round) * Round;
				}

				Debug.Assert (this.ChartDescription.VerticalAxisMaxValue >= savedVerticalAxisMaxValue, "Chart.AdjustVerticalAxis", string.Format (CultureInfo.InvariantCulture, "Overflow during resize from to {0} (max {1})", this.ChartDescription.VerticalAxisMaxValue, savedVerticalAxisMaxValue));
			}

			// Round min value
			if (savedVerticalAxisMinValue != 0)
			{
				int Round    = (int)Math.Pow (10.0F, (double)(NbDigitsToUse - 1));
				// N.B.: Round must be an even number in order to make the following calculation works
				// As Round is a base-10 number, this condition is true.
				Debug.Assert (Round%2 == 0, "Chart.AdjustVerticalAxis ()", "Can't proceed when Round is odd");
				this.ChartDescription.VerticalAxisMinValue = - (((-savedVerticalAxisMinValue + Round) / Round) * Round);

				Debug.Assert (this.ChartDescription.VerticalAxisMinValue <= savedVerticalAxisMinValue, "Chart.AdjustVerticalAxis", string.Format (CultureInfo.InvariantCulture, "Overflow during resize from to {0} (max {1})", this.ChartDescription.VerticalAxisMinValue, savedVerticalAxisMinValue));
			}

			// To avoid later integer divided by 0, make sure min != max
			if (this.ChartDescription.VerticalAxisMaxValue == this.ChartDescription.VerticalAxisMinValue)
			{
				this.ChartDescription.VerticalAxisMaxValue = Math.Abs (this.ChartDescription.VerticalAxisMinValue) * 10000;
			}

			// Change VerticalAxisStep if > VerticalAxisMaxValue
			if (this.ChartDescription.VerticalAxisStep > this.ChartDescription.VerticalAxisMaxValue)
			{
				this.ChartDescription.VerticalAxisStep = this.ChartDescription.VerticalAxisMaxValue / 10;
			}
		}
		#endregion

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

		/// <summary>
		/// Shift all values to the left
		/// </summary>
		public void ShiftLeft ()
		{
			int numberOfColumns = this.ChartDescription.Columns.Count;
			if (numberOfColumns > 1)
			{
				for (int i = 1; i < numberOfColumns; i++)
				{
					this.ChartDescription.Columns[i-1] = this.ChartDescription.Columns[i];
				}

				// Create new column (keep in mind that at this stage, Columns[numberOfColumns-1] & Columns[numberOfColumns-2] 
				// are 2 pointers on the SAME OBJECT.
				ChartColumn LastColumn = new ChartColumn ((ChartColumn)this.ChartDescription.Columns[numberOfColumns-2]);
				LastColumn.ResetValues ();
				this.ChartDescription.Columns[numberOfColumns-1] = LastColumn;
			}
		}


		#region Display & Paint
		/*
	PANEL ALIGNMENT                                  CHART COLUMN
*************************                     |      
*            ^          * TM : Top Margin     |       T3________T2                    
*		     | TM       * BM : Bottom Margin  |        /        /|                     
*            v          * LM : Left Margin    |       /        / |     _________        
*      P3_________P6    * RM : Right Margin   |      /________/  |    /|       /|       
*    P2/|         |  RM *                     |     Top0    T1|  |   / |      / |      
*<--->| |         |<--->*                     |     |         |  |  /________/  |      
*  LM | |         |     *                     |     |         |  | |   |     |  |      
*     | |P1       |P5   *                     |     |  B3_____|B2|_|___|_____|__|____  
*     |/__________/     *                     |     |  /      | /  |  /      | /    /  
*    P0      ^   P4     *                     |     | /       |/   | /       |/    /   
*		     | BM       *                     |     |/________/____|/________/____/    
*            v          *                     |     Base0    B1                        
*************************                     |    <---------><---->
											      ColumnWidth  MarginBetweenColumn
		*/
		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent) 
		{
			int	verticalAxisMaxValueInPixels;
			int x0, y0, x1, y2, x5;
			//int x2, x3, x4, x6;
			//int y1, y3, y4, y5, y6;

			base.OnPaintBackground(pevent);

            try
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;

                // Diagonal border
                x0 = this.ChartDescription.LeftMargin;
                y0 = this.Height - this.ChartDescription.BottomMargin;
                x1 = x0 + this.ChartDescription.DeltaDepth;
                //y1 = y0 - this.ChartDescription.DeltaDepth;

                //x2= x0;
                y2 = this.ChartDescription.TopMargin + this.ChartDescription.DeltaDepth;
                //x3= x1;
                //y3= this.ChartDescription.TopMargin;

                //x4 = this.Width - this.ChartDescription.RightMargin - this.ChartDescription.DeltaDepth;
                //y4 = y0;
                x5 = this.Width - this.ChartDescription.RightMargin;
                //y5 = y1;

                //x6 = this.Width - this.ChartDescription.RightMargin;
                //y6 = this.ChartDescription.TopMargin;

                verticalAxisMaxValueInPixels = y0 - y2;

                // Draw main title
                this.DisplayGrid(pevent);

                // Draw columns
                if (this.ChartDescription.Columns != null)
                {
                    int numberOfColumns = this.ChartDescription.Columns.Count;
                    if (numberOfColumns != 0)
                    {
                        int columnWidth = (x5 - x1) / (numberOfColumns);
                        int columnWidthNoMargin = columnWidth - this.ChartDescription.MarginBetweenColumn;
                        int columnStartOffset = x0 + this.ChartDescription.MarginBetweenColumn / 2;		// Center columns on graph

                        // Draw columns title
                        this.DisplayColumnsTitle(pevent, columnWidth, columnWidthNoMargin, columnStartOffset, verticalAxisMaxValueInPixels, x0, y0);

                        if (this.ChartDescription.RenderingMode == ChartRenderingMode.BarWith3d)
                        {
                            this.DisplayColumnsAsBarWith3d(pevent, columnWidth, columnWidthNoMargin, columnStartOffset, verticalAxisMaxValueInPixels, x0, y0, false);
                        }
                        else if (this.ChartDescription.RenderingMode == ChartRenderingMode.BarWith3dGradient)
                        {
                            this.DisplayColumnsAsBarWith3d(pevent, columnWidth, columnWidthNoMargin, columnStartOffset, verticalAxisMaxValueInPixels, x0, y0, true);
                        }
                        else if (this.ChartDescription.RenderingMode == ChartRenderingMode.Linear3d)
                        {
                            this.DisplayColumnsAsLinear(pevent, columnWidth, columnWidthNoMargin, columnStartOffset, verticalAxisMaxValueInPixels, x0, y0);
                        }

                        if (this.ChartDescription.DisplayTextOnColumns)
                        {
                            this.DisplayColumnsText(pevent, columnWidth, columnWidthNoMargin, columnStartOffset, verticalAxisMaxValueInPixels, x0, y0 - this.ChartDescription.DeltaDepth);
                        }
                    }
                }

                // Draw main title
                this.DisplayMainTitle(pevent);
            }
            catch { }
		}

		virtual protected void DisplayColumnsAsLinear (System.Windows.Forms.PaintEventArgs e, int columnWidth, int columnWidthNoMargin, int columnStartOffset, int verticalAxisMaxValueInPixels, int lowerLeftX, int lowerLeftY)
		{
			Point Base0, Base1, Base2, Base3;

			IEnumerator Iterator		= this.ChartDescription.Columns.GetEnumerator ();
			ChartColumn	previousColumn	= null;
			Point		prevBase0		= new Point (0,0);
			Point		prevBase1		= new Point (0,0);
			Point		prevBase2		= new Point (0,0);
			Point		prevBase3		= new Point (0,0);
			int			columnCurrentOffset = columnStartOffset;
			int			offsetFor0			= (-this.ChartDescription.VerticalAxisMinValue) * verticalAxisMaxValueInPixels / (this.ChartDescription.VerticalAxisMaxValue - this.ChartDescription.VerticalAxisMinValue);
			while (Iterator.MoveNext ())
			{
				ChartColumn	currentColumn = (ChartColumn)Iterator.Current;
				Debug.Assert (currentColumn.PositiveValuesSum <= this.ChartDescription.VerticalAxisMaxValue, "Chart.DisplayColumns_BarWith3d", "Vertical axis overflow, verify why current column value is higher than axis vertical value");
				Debug.Assert (this.ChartDescription.VerticalAxisMaxValue > 0, "Chart.DisplayColumns_BarWith3d", "Integer divided by 0");

				Base0 = new Point (columnCurrentOffset, lowerLeftY-offsetFor0);
				Base1 = new Point (columnCurrentOffset + columnWidthNoMargin, lowerLeftY-offsetFor0);
				Base2 = new Point (columnCurrentOffset + columnWidthNoMargin + this.ChartDescription.DeltaDepth, lowerLeftY - offsetFor0 - this.ChartDescription.DeltaDepth);
				Base3 = new Point (columnCurrentOffset + this.ChartDescription.DeltaDepth, lowerLeftY -offsetFor0 - this.ChartDescription.DeltaDepth);

				currentColumn.DisplayAsLinear (e, this, previousColumn, columnWidthNoMargin, verticalAxisMaxValueInPixels, Base0, Base1, Base2, Base3, prevBase0, prevBase1, prevBase2, prevBase3);

				// Next
				prevBase0 = Base0;
				prevBase1 = Base1;
				prevBase2 = Base2;
				prevBase3 = Base3;
				columnCurrentOffset += columnWidth;
				previousColumn		= currentColumn;
			}
		}

		virtual protected void DisplayColumnsAsBarWith3d (System.Windows.Forms.PaintEventArgs e, int columnWidth, int columnWidthNoMargin, int columnStartOffset, int verticalAxisMaxValueInPixels, int lowerLeftX, int lowerLeftY, bool gradientMode)
		{
			Point Base0, Base1, Base2, Base3;

			System.Diagnostics.Debug.Assert (this.ChartDescription.VerticalAxisMaxValue - this.ChartDescription.VerticalAxisMinValue != 0);

			IEnumerator Iterator		= this.ChartDescription.Columns.GetEnumerator ();
			ChartColumn	previousColumn	= null;
			Point		prevBase0		= new Point (0,0);
			Point		prevBase1		= new Point (0,0);
			Point		prevBase2		= new Point (0,0);
			Point		prevBase3		= new Point (0,0);
			int			columnCurrentOffset = columnStartOffset;
			int			offsetFor0			= (-this.ChartDescription.VerticalAxisMinValue) * verticalAxisMaxValueInPixels / (this.ChartDescription.VerticalAxisMaxValue - this.ChartDescription.VerticalAxisMinValue);
			while (Iterator.MoveNext ())
			{
				ChartColumn	currentColumn = (ChartColumn)Iterator.Current;

				if (this.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFromLastValue)
					Debug.Assert (currentColumn.PositiveValuesSum <= this.ChartDescription.VerticalAxisMaxValue, "Chart.DisplayColumns_BarWith3d", "Vertical axis overflow, verify why current column value is higher than axis vertical value");

				Base0 = new Point (columnCurrentOffset, lowerLeftY-offsetFor0);
				Base1 = new Point (columnCurrentOffset + columnWidthNoMargin, lowerLeftY-offsetFor0);
				Base2 = new Point (columnCurrentOffset + columnWidthNoMargin + this.ChartDescription.DeltaDepth, lowerLeftY - offsetFor0 - this.ChartDescription.DeltaDepth);
				Base3 = new Point (columnCurrentOffset + this.ChartDescription.DeltaDepth, lowerLeftY - offsetFor0 - this.ChartDescription.DeltaDepth);

				currentColumn.DisplayAsBarWith3d (e, this, previousColumn, columnWidthNoMargin, verticalAxisMaxValueInPixels, Base0, Base1, Base2, Base3, prevBase0, prevBase1, prevBase2, prevBase3, gradientMode);

				// Next column
				prevBase0 = Base0;
				prevBase1 = Base1;
				prevBase2 = Base2;
				prevBase3 = Base3;
				columnCurrentOffset += columnWidth;
				previousColumn		= currentColumn;
			}
		}

		virtual protected void DisplayColumnsTitle (System.Windows.Forms.PaintEventArgs e, int columnWidth, int columnWidthNoMargin, int columnStartOffset, int verticalAxisMaxValueInPixels, int lowerLeftX, int lowerLeftY)
		{
			IEnumerator Iterator = this.ChartDescription.Columns.GetEnumerator ();
			int columnCurrentOffset = columnStartOffset;
			while (Iterator.MoveNext ())
			{
				ChartColumn	currentColumn = (ChartColumn)Iterator.Current;

				Point Base0 = new Point (columnCurrentOffset, lowerLeftY);
				Point Base1 = new Point (columnCurrentOffset + columnWidthNoMargin, lowerLeftY);

				currentColumn.DisplayTitle (e, this, Base0, Base1);

				// Jump to next offset
				columnCurrentOffset += columnWidth;
			}
		}

		/// <summary>
		/// Display all text on chart for all columns
		/// </summary>
		/// <param name="e"></param>
		/// <param name="columnWidth"></param>
		/// <param name="columnWidthNoMargin"></param>
		/// <param name="columnStartOffset"></param>
		/// <param name="verticalAxisMaxValueInPixels"></param>
		/// <param name="lowerLeftX"></param>
		/// <param name="lowerLeftY"></param>
		virtual protected void DisplayColumnsText (System.Windows.Forms.PaintEventArgs e, int columnWidth, int columnWidthNoMargin, int columnStartOffset, int verticalAxisMaxValueInPixels, int lowerLeftX, int lowerLeftY)
		{
			int			offset;
			int			offsetFor0;
			IEnumerator Iterator			= this.ChartDescription.Columns.GetEnumerator ();
			int			columnCurrentOffset = columnStartOffset;

			System.Diagnostics.Debug.Assert (this.ChartDescription.VerticalAxisMaxValue - this.ChartDescription.VerticalAxisMinValue != 0);

			offsetFor0 = (-this.ChartDescription.VerticalAxisMinValue) * verticalAxisMaxValueInPixels / (this.ChartDescription.VerticalAxisMaxValue - this.ChartDescription.VerticalAxisMinValue);
			while (Iterator.MoveNext ())
			{
				ChartColumn	currentColumn = (ChartColumn)Iterator.Current;

				if (this.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFromLastValue)
					Debug.Assert (currentColumn.PositiveValuesSum <= this.ChartDescription.VerticalAxisMaxValue, "Chart.OnPaintBackground", "Vertical axis overflow, verify why current column value is higher than axis vertical value");

				if (this.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFrom0)
				{
					if (currentColumn.HighestValue >= 0)
						offset  = offsetFor0 + (verticalAxisMaxValueInPixels * currentColumn.HighestValue / (this.ChartDescription.VerticalAxisMaxValue-this.ChartDescription.VerticalAxisMinValue));
					else
					{
						// In this case, align text on the '0' line offset
						offset  = offsetFor0 ;
					}
				}
				else if (this.ChartDescription.CumulativeMode == ChartCumulativeMode.StartFromLastValue)
				{
					offset  = offsetFor0 + (verticalAxisMaxValueInPixels * currentColumn.PositiveValuesSum / (this.ChartDescription.VerticalAxisMaxValue-this.ChartDescription.VerticalAxisMinValue));
				}
				else
				{
					Debug.Assert (this.ChartDescription.CumulativeMode == ChartCumulativeMode.Max, "Chart.OnPaintBackground", "Cumulative mode not managed");
					offset  = 0;
				}

				int						AbsoluteSum	= currentColumn.PositiveValuesSum - currentColumn.NegativeValuesSum;

				// Compute sie of bouding rectangle
				System.Drawing.SizeF    Size		= e.Graphics.MeasureString (AbsoluteSum.ToString (CultureInfo.InvariantCulture), this.ChartDescription.ColumnFont);
				PointF					Base0		= new PointF ((float)columnCurrentOffset, (float)(lowerLeftY - offset) - Size.Height);
				RectangleF backgroundRectangle		= new RectangleF (Base0, Size);

				// Align rectangle on column width
				backgroundRectangle.X = columnCurrentOffset + this.ChartDescription.MarginBetweenColumn / 2 + ((columnWidthNoMargin - backgroundRectangle.Width) / 2);
				currentColumn.DisplayText (e, this, backgroundRectangle);

				// Jump to next offset
				columnCurrentOffset += columnWidth;
			}
		}

		virtual protected void DisplayGrid (System.Windows.Forms.PaintEventArgs e)
		{
			int x0, y0, x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;

            try
            {
                // Diagonal border from front side to back side
                x0 = this.ChartDescription.LeftMargin;
                y0 = this.Height - this.ChartDescription.BottomMargin;
                x1 = x0 + this.ChartDescription.DeltaDepth;
                y1 = y0 - this.ChartDescription.DeltaDepth;
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x0, y0, x1, y1);

                x2 = x0;
                y2 = this.ChartDescription.TopMargin + this.ChartDescription.DeltaDepth;
                x3 = x1;
                y3 = this.ChartDescription.TopMargin;
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x2, y2, x3, y3);

                x4 = this.Width - this.ChartDescription.RightMargin - this.ChartDescription.DeltaDepth;
                y4 = y0;
                x5 = this.Width - this.ChartDescription.RightMargin;
                y5 = y1;
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x4, y4, x5, y5);

                x6 = this.Width - this.ChartDescription.RightMargin;
                y6 = this.ChartDescription.TopMargin;

                // Horizontal & vertical borders
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x0, y0, x4, y4);
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x0, y0, x2, y2);
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x1, y1, x3, y3);
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x6, y6, x3, y3);
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x6, y6, x5, y5);
                e.Graphics.DrawLine(this.ChartDescription.GridPen, x1, y1, x5, y5);

                // Vertical Axis
                System.Diagnostics.Debug.Assert(this.ChartDescription.VerticalAxisStep != 0);
                System.Diagnostics.Debug.Assert(this.ChartDescription.VerticalAxisStep <= this.ChartDescription.VerticalAxisMaxValue);
                int currentNumber = 0;
                int numberOfSteps = (this.ChartDescription.VerticalAxisMaxValue - this.ChartDescription.VerticalAxisMinValue) / this.ChartDescription.VerticalAxisStep;

                System.Diagnostics.Debug.Assert(numberOfSteps != 0);
                int tmpY = y0;
                int deltaStep = (y0 - y2) / numberOfSteps;

                // Loop for all steps but avoid rounding error & overdraw by not drawing last step
                for (int iVertical = 0; iVertical < numberOfSteps - 1; iVertical++)
                {
                    tmpY -= deltaStep;
                    currentNumber = this.ChartDescription.VerticalAxisMinValue + (iVertical + 1) * this.ChartDescription.VerticalAxisStep;

                    if ((currentNumber == 0) && (this.ChartDescription.VerticalAxisMinValue < 0))
                    {
                        // Draw diagonal
                        e.Graphics.DrawLine(this.ChartDescription.GridPenFor0, x0, tmpY, x1, tmpY - this.ChartDescription.DeltaDepth);
                        //e.Graphics.DrawLine (GridPenFor0, x4, tmpY, x5, tmpY - DeltaDepth);

                        // Draw horizontal on chart
                        e.Graphics.DrawLine(this.ChartDescription.GridPenFor0, x5, tmpY - this.ChartDescription.DeltaDepth, x1, tmpY - this.ChartDescription.DeltaDepth);
                        //e.Graphics.DrawLine (this.ChartDescription.GridPenFor0, x0, tmpY, x4, tmpY);
                    }
                    else
                    {
                        // Draw diagonal
                        e.Graphics.DrawLine(this.ChartDescription.GridPen, x0, tmpY, x1, tmpY - this.ChartDescription.DeltaDepth);

                        // Draw horizontal on chart
                        e.Graphics.DrawLine(this.ChartDescription.GridPen, x5, tmpY - this.ChartDescription.DeltaDepth, x1, tmpY - this.ChartDescription.DeltaDepth);
                    }
                }

                // Draw vertical legend 
                StringFormat legendDrawFormat = new StringFormat();
                legendDrawFormat.Alignment = StringAlignment.Far;
                legendDrawFormat.LineAlignment = StringAlignment.Center;

                tmpY = y0;
                for (int iVertical = 0; iVertical <= numberOfSteps; iVertical++)
                {

                    // Draw horizontal on scaling
                    e.Graphics.DrawLine(this.ChartDescription.GridPen, x0, tmpY, x0 - 5, tmpY);

                    // Draw legend
                    currentNumber = this.ChartDescription.VerticalAxisMinValue + (iVertical) * this.ChartDescription.VerticalAxisStep;
                    PointF point = new PointF(x0 - 5, tmpY);		// remove few pixels from vertical line
                    e.Graphics.DrawString(currentNumber.ToString(CultureInfo.InvariantCulture), this.ChartDescription.LegendFont, this.ChartDescription.LegendBrush, point, legendDrawFormat);

                    tmpY -= deltaStep;
                }
            }
            catch { }
		}

		virtual protected void DisplayMainTitle (System.Windows.Forms.PaintEventArgs e)
		{
			if (this.ChartDescription.MainTitle != null)
			{
				Point			point				= new Point (this.ChartDescription.LeftMargin, this.Height - this.ChartDescription.MainTitleFont.Height);
				Size			size				= new Size (this.Width - this.ChartDescription.LeftMargin - this.ChartDescription.RightMargin, this.ChartDescription.MainTitleFont.Height) ; //e.Graphics.MeasureString (this.ChartDescription.MainTitle, this.ChartDescription.MainTitleFont);
				StringFormat	legendDrawFormat	= new StringFormat();
				legendDrawFormat.Alignment		= StringAlignment.Center;
				legendDrawFormat.LineAlignment	= StringAlignment.Center;
				Rectangle textRectangle			= new Rectangle (point, size);

				e.Graphics.DrawString (this.ChartDescription.MainTitle, this.ChartDescription.MainTitleFont, this.ChartDescription.LegendBrush, textRectangle, legendDrawFormat);
			}
		}

		#endregion

		#region Load / Save
		public virtual Type[] GetExtraTypes ()
		{
			Type [] BaseTypes = XmlConfiguration.GetXmlTypes ();
			Type [] ExtraTypes= new Type[BaseTypes.Length + 4];

			BaseTypes.CopyTo (ExtraTypes, 0);
			ExtraTypes[BaseTypes.Length + 0] = typeof(ChartLegendDescription);
			ExtraTypes[BaseTypes.Length + 1] = typeof(ChartLegendItem);
			ExtraTypes[BaseTypes.Length + 2] = typeof(ChartDescription);
			ExtraTypes[BaseTypes.Length + 3] = typeof(ChartColumn);

			return ExtraTypes;
		}

		public void Save (string outputFileName)
		{
			// Init extra type
			Type [] extraTypes= this.GetExtraTypes ();

			StreamWriter objStreamWriter = new StreamWriter(outputFileName);
			XmlSerializer x = new XmlSerializer(this.ChartDescription.GetType (), extraTypes);
			x.Serialize(objStreamWriter, this.ChartDescription);
			objStreamWriter.Close();
		}

		public void Load (string inputFileName)
		{
			Type []			ExtraTypes= this.GetExtraTypes ();

			// Reset default parameters
			//this.ChartDescription.InitDefault ();

			StreamReader objStreamReader = new StreamReader(inputFileName);
			XmlSerializer x2 = new XmlSerializer(this.ChartDescription.GetType (), ExtraTypes);
			this.ChartDescription = (ChartDescription)x2.Deserialize(objStreamReader);
			objStreamReader.Close();
		}
		#endregion

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
	}
}
