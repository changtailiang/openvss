// ylqs	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qaxa	
// pwff	 By downloading, copying, installing or using the software you agree to this license.
// iari	 If you do not agree to this license, do not download, install,
// pzmz	 copy or use the software.
// pyqa	
// hukw	                          License Agreement
// xmun	         For OpenVss - Open Source Video Surveillance System
// feda	
// ahpq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dulj	
// uhwp	Third party copyrights are property of their respective owners.
// wasx	
// ticz	Redistribution and use in source and binary forms, with or without modification,
// vqlv	are permitted provided that the following conditions are met:
// qbdd	
// cszd	  * Redistribution's of source code must retain the above copyright notice,
// wqii	    this list of conditions and the following disclaimer.
// kvwv	
// mhfz	  * Redistribution's in binary form must reproduce the above copyright notice,
// yuzw	    this list of conditions and the following disclaimer in the documentation
// twtx	    and/or other materials provided with the distribution.
// cefj	
// wtab	  * Neither the name of the copyright holders nor the names of its contributors 
// rigc	    may not be used to endorse or promote products derived from this software 
// issf	    without specific prior written permission.
// skny	
// mhmn	This software is provided by the copyright holders and contributors "as is" and
// llxv	any express or implied warranties, including, but not limited to, the implied
// bgjf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ybbs	In no event shall the Prince of Songkla University or contributors be liable 
// lymq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vude	(including, but not limited to, procurement of substitute goods or services;
// acrg	loss of use, data, or profits; or business interruption) however caused
// ctej	and on any theory of liability, whether in contract, strict liability,
// jvlu	or tort (including negligence or otherwise) arising in any way out of
// rryk	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Vs.Monitor
{
	/// <summary>
	/// VsChannelGrid
	/// </summary>
	public class VsChannelGrid : System.Windows.Forms.Control
	{
		private short		cols = 2, rows = 2;
		private string[,]	labels;
		private Point		lastClickPoint;

		// Cols property
		[DefaultValue(2)]
		public short Cols
		{
			get { return cols; }
			set
			{
				cols = value;
				Redim();
				Invalidate();
			}
		}
		// Rows property
		[DefaultValue(2)]
		public short Rows
		{
			get { return rows; }
			set
			{
				rows = value;
				Redim();
				Invalidate();
			}
		}

		// Constructor
		public VsChannelGrid()
		{
			InitializeComponent();

			labels = new string[rows, cols];

			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
						ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
		}

		private void InitializeComponent()
		{
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChannelGrid_MouseDown);
		}

		//
		private void Redim()
		{
			string[,] t =labels;
			labels = new string [rows, cols];

			int		r = Math.Min(rows, t.GetLength(0));
			int		c = Math.Min(cols, t.GetLength(1));

			// copy old labels into new
			for (int i = 0; i < r; i++)
			{
				for (int j = 0; j < c; j++)
				{
					labels[i, j] = t[i, j];
				}
			}

		}

		// Paint the control
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics	g = pe.Graphics;
			Rectangle	rc = this.ClientRectangle;
			int			cellWidth = rc.Width / cols;
			int			cellHeight = rc.Height / rows;

			Pen			pen = new Pen(Color.Black, 1);
			Brush		brush1 = new SolidBrush(Color.FromArgb(240, 240, 255));
			Brush		brush2 = new SolidBrush(Color.FromArgb(0, 0, 0));
			Font		font = new Font("Arial", 8);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					g.DrawRectangle(pen, j * cellWidth, i * cellHeight, cellWidth - 2, cellHeight - 2);
					g.FillRectangle(brush1, j * cellWidth + 1, i * cellHeight + 1, cellWidth - 3, cellHeight - 3);

					if (labels[i, j] != null)
						g.DrawString(labels[i, j], font, brush2, new RectangleF(j * cellWidth + 2, i * cellHeight + 2, cellWidth - 6, cellHeight - 6));
				}
			}

			font.Dispose();
			brush1.Dispose();
			brush2.Dispose();
			pen.Dispose();

			// Calling the base class OnPaint
			base.OnPaint(pe);
		}

		// Set label and return it's coordinates in rows and cols
		public Point SetLabel(string label, Point clientPt)
		{
			Point point = ClientToGrid(clientPt);

			labels[point.Y, point.X] = label;
			Invalidate();

			return point;
		}

		public Point SetLabel(string label)
		{
			return SetLabel(label, lastClickPoint);
		}

		public void SetLabel(string label, int row, int col)
		{
			labels[row, col] = label;
			Invalidate();
		}

        public String GetLabel(int row, int col)
        {
            return labels[row, col];
        }

		// Convert client coordinates to grids row and column
		protected Point ClientToGrid(Point pt)
		{
			Rectangle	rc = this.ClientRectangle;
			int			cellWidth = rc.Width / cols;
			int			cellHeight = rc.Height / rows;

			return new Point(pt.X / cellWidth, pt.Y / cellHeight);
		}

		// On mouse down
		private void ChannelGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			lastClickPoint = new Point(e.X, e.Y);
		}
	}
}
