using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Nolme.Win32;


// Source : http://www.codeproject.com/vb/net/custompanel.asp

namespace Nolme.WinForms
{
	[FlagsAttribute()] public enum CornerCurveModes
	{
		None = 0,
		TopLeft = 1,
		TopRight = 2,
		TopLeftTopRight = 3,
		BottomLeft = 4,
		TopLeftBottomLeft = 5,
		TopRightBottomLeft = 6,
		TopLeftTopRightBottomLeft = 7,
		BottomRight = 8,
		BottomRightTopLeft = 9,
		BottomRightTopRight = 10,
		BottomRightTopLeftTopRight = 11,
		BottomRightBottomLeft = 12,
		BottomRightTopLeftBottomLeft = 13,
		BottomRightTopRightBottomLeft = 14,
		All = 15
	}

	/*public enum LinearGradientMode
	{
		Horizontal = 0,
		Vertical = 1,
		ForwardDiagonal = 2,
		BackwardDiagonal = 3,
		None = 4
	}*/


	[System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.Panel))]
	public class CustomPanel : System.Windows.Forms.Panel
	{
		// Fields
		private System.Drawing.Color				m_BackColor1 = System.Drawing.SystemColors.Window;
		private System.Drawing.Color				m_BackColor2 = System.Drawing.SystemColors.Window;
		private LinearGradientMode					m_GradientMode = LinearGradientMode.Horizontal;
		private System.Windows.Forms.BorderStyle	m_BorderStyle = System.Windows.Forms.BorderStyle.None;
		private System.Drawing.Color				m_BorderColor = System.Drawing.SystemColors.WindowFrame;
		private int									m_BorderWidth = 1;
		private int									m_Curvature;

		// Properties
		//   Shadow the Backcolor property so that the base class will still render with a transparent backcolor
		private CornerCurveModes					m_CurveMode = CornerCurveModes.All;

		[System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "Window"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The primary background color used to display text and graphics in the control.")]
		public new System.Drawing.Color BackColor 
		{
			get 
			{
				return this.m_BackColor1;
			}
			set 
			{
				this.m_BackColor1 = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "Window"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The secondary background color used to paint the control.")]
		public System.Drawing.Color BackColor2 
		{
			get 
			{
				return this.m_BackColor2;
			}
			set 
			{
				this.m_BackColor2 = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(LinearGradientMode), "None"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The gradient direction used to paint the control.")]
		public LinearGradientMode GradientMode 
		{
			get 
			{
				return this.m_GradientMode;
			}
			set 
			{
				this.m_GradientMode = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(System.Windows.Forms.BorderStyle), "None"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The border style used to paint the control.")]
		public new System.Windows.Forms.BorderStyle BorderStyle 
		{
			get 
			{
				return this.m_BorderStyle;
			}
			set 
			{
				this.m_BorderStyle = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "WindowFrame"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The border color used to paint the control.")]
		public System.Drawing.Color BorderColor 
		{
			get 
			{
				return this.m_BorderColor;
			}
			set 
			{
				this.m_BorderColor = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(int), "1"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The width of the border used to paint the control.")]
		public int BorderWidth 
		{
			get 
			{
				return this.m_BorderWidth;
			}
			set 
			{
				this.m_BorderWidth = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(int), "0"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The radius of the curve used to paint the corners of the control.")]
		public int Curvature 
		{
			get 
			{
				return this.m_Curvature;
			}
			set 
			{
				this.m_Curvature = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		[System.ComponentModel.DefaultValueAttribute(typeof(CornerCurveModes), "All"), System.ComponentModel.CategoryAttribute("Appearance"), System.ComponentModel.DescriptionAttribute("The style of the curves to be drawn on the control.")]
		public CornerCurveModes CurveMode 
		{
			get 
			{
				return this.m_CurveMode;
			}
			set 
			{
				this.m_CurveMode = value;
				if (this.DesignMode == true) 
				{
					this.Invalidate();
				}
			}
		}

		private int adjustedCurve 
		{
			get 
			{
				int curve = 0;
				if (!(this.m_CurveMode == CornerCurveModes.None)) 
				{
					if (this.m_Curvature > (this.ClientRectangle.Width / 2)) 
					{
						curve = DoubleToInt(this.ClientRectangle.Width / 2);
					} 
					else 
					{
						curve = this.m_Curvature;
					}
					if (curve > (this.ClientRectangle.Height / 2)) 
					{
						curve = DoubleToInt(this.ClientRectangle.Height / 2);
					}
				}
				return curve;
			}
		}

		public CustomPanel() : base()
		{
			this.SetDefaultControlStyles();
			this.customInitialisation();
		}

		private void SetDefaultControlStyles()
		{
			this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);

			//this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, false);
			this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);	// Thanks timbits214  ;p
		}

		private void customInitialisation()
		{
			this.SuspendLayout();
			base.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ResumeLayout(false);
		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent) 
		{
			base.OnPaintBackground(pevent);
			pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			System.Drawing.Drawing2D.GraphicsPath graphPath;
			graphPath = this.CreatePath();
			//	Create Gradient Brush (Cannot be width or height 0)
			System.Drawing.Drawing2D.LinearGradientBrush filler;
			System.Drawing.Rectangle rect = this.ClientRectangle;
			if (this.ClientRectangle.Width == 0) 
			{
				rect.Width += 1;
			}
			if (this.ClientRectangle.Height == 0) 
			{
				rect.Height += 1;
			}
			
			/*if (this.m_GradientMode == LinearGradientMode.None) 
			{
				filler = new System.Drawing.Drawing2D.LinearGradientBrush(rect, this.m_BackColor1, this.m_BackColor1, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
			} 
			else 
			{
				filler = new System.Drawing.Drawing2D.LinearGradientBrush(rect, this.m_BackColor1, this.m_BackColor2, ((System.Drawing.Drawing2D.LinearGradientMode)this.m_GradientMode));
			}
			*/
			filler = new System.Drawing.Drawing2D.LinearGradientBrush(rect, this.m_BackColor1, this.m_BackColor2, ((System.Drawing.Drawing2D.LinearGradientMode)this.m_GradientMode));


			pevent.Graphics.FillPath(filler, graphPath);
			//filler.Dispose();	// Fxcop warning
			if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle) 
			{
				System.Drawing.Pen borderPen = new System.Drawing.Pen(this.m_BorderColor, this.m_BorderWidth);
				pevent.Graphics.DrawPath(borderPen, graphPath);
				borderPen.Dispose();
			} 
			else if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D) 
			{
				DrawBorder3D(pevent.Graphics, this.ClientRectangle);
			} 
			else if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.None) 
			{
			}
			filler.Dispose();
			graphPath.Dispose();
		}

		protected System.Drawing.Drawing2D.GraphicsPath CreatePath()
		{
			System.Drawing.Drawing2D.GraphicsPath graphPath = new System.Drawing.Drawing2D.GraphicsPath();
			if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D) 
			{
				graphPath.AddRectangle(this.ClientRectangle);
			} 
			else 
			{
				//try 
				//{
					int curve = 0;
					System.Drawing.Rectangle rect = this.ClientRectangle;
					int offset = 0;
					if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle) 
					{
						if (this.m_BorderWidth > 1) 
						{
							offset = DoubleToInt(this.BorderWidth / 2);
						}
						curve = this.adjustedCurve;
					} 
					else if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D) 
					{
					} 
					else if (this.m_BorderStyle == System.Windows.Forms.BorderStyle.None) 
					{
						curve = this.adjustedCurve;
					}
					if (curve == 0) 
					{
						graphPath.AddRectangle(System.Drawing.Rectangle.Inflate(rect, -offset, -offset));
					} 
					else 
					{
						int rectWidth = rect.Width - 1 - offset;
						int rectHeight = rect.Height - 1 - offset;
						int curveWidth = 1;
						if ((this.m_CurveMode & CornerCurveModes.TopRight) != 0) 
						{
							curveWidth = (curve * 2);
						} 
						else 
						{
							curveWidth = 1;
						}
						graphPath.AddArc(rectWidth - curveWidth, offset, curveWidth, curveWidth, 270, 90);
						if ((this.m_CurveMode & CornerCurveModes.BottomRight) != 0) 
						{
							curveWidth = (curve * 2);
						} 
						else 
						{
							curveWidth = 1;
						}
						graphPath.AddArc(rectWidth - curveWidth, rectHeight - curveWidth, curveWidth, curveWidth, 0, 90);
						if ((this.m_CurveMode & CornerCurveModes.BottomLeft) != 0) 
						{
							curveWidth = (curve * 2);
						} 
						else 
						{
							curveWidth = 1;
						}
						graphPath.AddArc(offset, rectHeight - curveWidth, curveWidth, curveWidth, 90, 90);
						if ((this.m_CurveMode & CornerCurveModes.TopLeft) != 0) 
						{
							curveWidth = (curve * 2);
						} 
						else 
						{
							curveWidth = 1;
						}
						graphPath.AddArc(offset, offset, curveWidth, curveWidth, 180, 90);
						graphPath.CloseFigure();
					}
				/*} [FXCOP] 
				catch (System.Exception) 
				{
					graphPath.AddRectangle(this.ClientRectangle);
				}*/
			}
			return graphPath;
		}

		public static void DrawBorder3D(System.Drawing.Graphics graphics, System.Drawing.Rectangle rectangle)
		{
			System.Diagnostics.Debug.Assert (graphics != null);
			if (graphics != null)
			{
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
				graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Y);
				graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.X, rectangle.Height - 1);
				graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, rectangle.Y + 1);
				graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.X + 1, rectangle.Height - 1);
				graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.X + 1, rectangle.Height - 2, rectangle.Width - 2, rectangle.Height - 2);
				graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.Width - 2, rectangle.Y + 1, rectangle.Width - 2, rectangle.Height - 2);
				graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.X, rectangle.Height - 1, rectangle.Width - 1, rectangle.Height - 1);
				graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.Width - 1, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
			}
		}

		public static int DoubleToInt(double value)
		{
			return System.Decimal.ToInt32(System.Decimal.Floor(System.Decimal.Parse((value).ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)));
		}

		/// <summary>
		/// Captures the specified area of the control or whats underneath
		/// the control. If the argument flag client is true, only the client
		/// area of the control is captured, otherwise the entire control is 
		/// captured. If the argument flag under is true, the capture area under
		/// the control is captured, otherwise the specified area on the control
		/// is captured.
		/// </summary>
		/// <returns>bitmap image of the control or whats underneath the control</returns>
		public Bitmap Capture ()
		{
			return CaptureUtility.Capture (this);
		}

	}
}