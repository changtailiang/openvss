// izqy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// unqa	
// zcxg	 By downloading, copying, installing or using the software you agree to this license.
// dlii	 If you do not agree to this license, do not download, install,
// tksp	 copy or use the software.
// cwpb	
// ouag	                          License Agreement
// otck	         For OpenVss - Open Source Video Surveillance System
// ytgt	
// fiiv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ftdr	
// fpgu	Third party copyrights are property of their respective owners.
// hwjk	
// wvdl	Redistribution and use in source and binary forms, with or without modification,
// kpjz	are permitted provided that the following conditions are met:
// mkmf	
// znij	  * Redistribution's of source code must retain the above copyright notice,
// fpcl	    this list of conditions and the following disclaimer.
// bxki	
// sxvz	  * Redistribution's in binary form must reproduce the above copyright notice,
// ngzr	    this list of conditions and the following disclaimer in the documentation
// krnd	    and/or other materials provided with the distribution.
// puiq	
// yjjv	  * Neither the name of the copyright holders nor the names of its contributors 
// hxss	    may not be used to endorse or promote products derived from this software 
// hxor	    without specific prior written permission.
// uxiz	
// kvsn	This software is provided by the copyright holders and contributors "as is" and
// tkmf	any express or implied warranties, including, but not limited to, the implied
// kvvh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zetl	In no event shall the Prince of Songkla University or contributors be liable 
// gmns	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nobv	(including, but not limited to, procurement of substitute goods or services;
// edrq	loss of use, data, or profits; or business interruption) however caused
// shxn	and on any theory of liability, whether in contract, strict liability,
// jnsu	or tort (including negligence or otherwise) arising in any way out of
// bvxo	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using NLog; 

namespace Vs.Core.SystemInfo
{
	/// <summary>
	/// Summary description for DataChart.
	/// </summary>
	public class VsDataChart : System.Windows.Forms.UserControl
	{
        static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ArrayList _arrayList;

		private Color _colorLine;
		private Color _colorGrid;
		
		private int  _yMaxInit;
		private int  _gridPixel;
		private ChartType _chartType;

		#region Constructor/Dispose
		public VsDataChart()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			BackColor = Color.Silver;

			_colorLine = Color.DarkBlue;
			_colorGrid = Color.Yellow;

			_yMaxInit = 1000;
			_gridPixel = 0;
			_chartType = ChartType.Stick;

			_arrayList = new ArrayList();
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
		#endregion

		public void UpdateChart(double d)
		{
			Rectangle rt = this.ClientRectangle;
			int dataCount = rt.Width/2;

			if (_arrayList.Count >= dataCount) 
				_arrayList.RemoveAt(0);

			_arrayList.Add(d);

			Invalidate();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Name = "DataChart";
			this.Size = new System.Drawing.Size(150, 16);
		}
		#endregion

		#region "Properties"

		[Description("Gets or sets the current Line Color in chart"), Category("DataChart")]
		public Color LineColor
		{
			get { return _colorLine; }
			set { _colorLine = value; }
		}

		[Description("Gets or sets the current Grid Color in chart"), Category("DataChart")]
		public Color GridColor
		{
			get { return _colorGrid; }
			set { _colorGrid = value; }
		}

		[Description("Gets or sets the initial maximum Height for sticks in chart"), Category("DataChart")]
		public int InitialHeight
		{
			get { return _yMaxInit; }
			set { _yMaxInit = value; }
		}

		[Description("Gets or sets the current chart Type for stick or Line"), Category("DataChart")]
		public ChartType ChartType
		{
			get { return _chartType; }
			set { _chartType = value; }
		}

		[Description("Enables grid drawing with spacing of the Pixel number"), Category("DataChart")]
		public int GridPixels
		{
			get { return _gridPixel; }
			set { _gridPixel = value; }
		}

		#endregion

		#region Drawing
		protected override void OnPaint(PaintEventArgs e)
		{
            try
            {
                int count = _arrayList.Count;
                if (count == 0) return;

                double y = 0, yMax = InitialHeight;
                for (int i = 0; i < count; i++)
                {
                    y = Convert.ToDouble(_arrayList[i]);
                    if (y > yMax) yMax = y;
                }

                Rectangle rt = this.ClientRectangle;
                y = yMax == 0 ? 1 : rt.Height / yMax;		// y ratio

                int xStart = rt.Width;
                int yStart = rt.Height;
                int nX, nY;

                Pen pen = null;
                e.Graphics.Clear(BackColor);

                if (GridPixels != 0)
                {
                    pen = new Pen(GridColor, 1);
                    nX = rt.Width / GridPixels;
                    nY = rt.Height / GridPixels;

                    for (int i = 1; i <= nX; i++)
                        e.Graphics.DrawLine(pen, i * GridPixels, 0, i * GridPixels, yStart);

                    for (int i = 1; i < nY; i++)
                        e.Graphics.DrawLine(pen, 0, i * GridPixels, xStart, i * GridPixels);
                }

                // From the most recent data, so X <--------------|	
                // Get data from _arrayList	 a[0]..<--...a[count-1]

                if (ChartType == ChartType.Stick)
                {
                    pen = new Pen(LineColor, 2);

                    for (int i = count - 1; i >= 0; i--)
                    {
                        nX = xStart - 2 * (count - i);
                        if (nX <= 0) break;

                        nY = (int)(yStart - y * Convert.ToDouble(_arrayList[i]));
                        e.Graphics.DrawLine(pen, nX, yStart, nX, nY);
                    }
                }
                else
                    if (ChartType == ChartType.Line)
                    {
                        pen = new Pen(LineColor, 1);

                        int nX0 = xStart - 2;
                        int nY0 = (int)(yStart - y * Convert.ToDouble(_arrayList[count - 1]));
                        for (int i = count - 2; i >= 0; i--)
                        {
                            nX = xStart - 2 * (count - i);
                            if (nX <= 0) break;

                            nY = (int)(yStart - y * Convert.ToDouble(_arrayList[i]));
                            e.Graphics.DrawLine(pen, nX0, nY0, nX, nY);

                            nX0 = nX;
                            nY0 = nY;
                        }
                    }
            }
            catch { }

			base.OnPaint(e);
		}
		#endregion
	}

	public enum ChartType { Stick, Line }

}
