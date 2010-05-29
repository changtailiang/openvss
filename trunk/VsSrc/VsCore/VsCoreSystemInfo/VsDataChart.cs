// yyms	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vikx	
// esss	 By downloading, copying, installing or using the software you agree to this license.
// zemy	 If you do not agree to this license, do not download, install,
// pszn	 copy or use the software.
// fxpf	
// tluj	                          License Agreement
// ifeh	         For OpenVSS - Open Source Video Surveillance System
// ysno	
// bgdj	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// clcv	
// oycw	Third party copyrights are property of their respective owners.
// kujf	
// nksb	Redistribution and use in source and binary forms, with or without modification,
// jhzk	are permitted provided that the following conditions are met:
// nboz	
// nltg	  * Redistribution's of source code must retain the above copyright notice,
// rxwi	    this list of conditions and the following disclaimer.
// pqku	
// utqu	  * Redistribution's in binary form must reproduce the above copyright notice,
// iyyo	    this list of conditions and the following disclaimer in the documentation
// wyto	    and/or other materials provided with the distribution.
// amfu	
// hsvb	  * Neither the name of the copyright holders nor the names of its contributors 
// wdid	    may not be used to endorse or promote products derived from this software 
// fvem	    without specific prior written permission.
// yaqx	
// axgp	This software is provided by the copyright holders and contributors "as is" and
// qebp	any express or implied warranties, including, but not limited to, the implied
// czdp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rfgf	In no event shall the Prince of Songkla University or contributors be liable 
// sbbw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ujxr	(including, but not limited to, procurement of substitute goods or services;
// lnpn	loss of use, data, or profits; or business interruption) however caused
// ulqv	and on any theory of liability, whether in contract, strict liability,
// ivoc	or tort (including negligence or otherwise) arising in any way out of
// fpec	the use of this software, even if advised of the possibility of such damage.
// rgyx	
// zslz	Intelligent Systems Laboratory (iSys Lab)
// pyuw	Faculty of Engineering, Prince of Songkla University, THAILAND
// ytdq	Project leader by Nikom SUVONVORN
// zoec	Project website at http://code.google.com/p/openvss/

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
