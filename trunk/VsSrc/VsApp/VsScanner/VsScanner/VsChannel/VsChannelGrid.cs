// krur	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bolw	
// mttp	 By downloading, copying, installing or using the software you agree to this license.
// wzsh	 If you do not agree to this license, do not download, install,
// fasb	 copy or use the software.
// qfkt	
// jqwj	                          License Agreement
// ycuy	         For OpenVSS - Open Source Video Surveillance System
// caix	
// niwk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// casr	
// qnnc	Third party copyrights are property of their respective owners.
// cpmc	
// wjme	Redistribution and use in source and binary forms, with or without modification,
// gbhk	are permitted provided that the following conditions are met:
// scyk	
// zunv	  * Redistribution's of source code must retain the above copyright notice,
// qutx	    this list of conditions and the following disclaimer.
// dizq	
// mtdv	  * Redistribution's in binary form must reproduce the above copyright notice,
// dthj	    this list of conditions and the following disclaimer in the documentation
// qrct	    and/or other materials provided with the distribution.
// nerm	
// alra	  * Neither the name of the copyright holders nor the names of its contributors 
// cisv	    may not be used to endorse or promote products derived from this software 
// arli	    without specific prior written permission.
// vpzo	
// jwrn	This software is provided by the copyright holders and contributors "as is" and
// xmhy	any express or implied warranties, including, but not limited to, the implied
// vpuh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// suhm	In no event shall the Prince of Songkla University or contributors be liable 
// dhxs	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qzoe	(including, but not limited to, procurement of substitute goods or services;
// ahvl	loss of use, data, or profits; or business interruption) however caused
// hyna	and on any theory of liability, whether in contract, strict liability,
// sojr	or tort (including negligence or otherwise) arising in any way out of
// mdon	the use of this software, even if advised of the possibility of such damage.
// dsem	
// nkcg	Intelligent Systems Laboratory (iSys Lab)
// jyen	Faculty of Engineering, Prince of Songkla University, THAILAND
// sgxk	Project leader by Nikom SUVONVORN
// inmq	Project website at http://code.google.com/p/openvss/

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
