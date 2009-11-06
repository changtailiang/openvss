using System;
using System.Drawing;
using System.Globalization;

namespace Nolme.Core
{
	/// <summary>
	/// Summary description for DrawingUtility.
	/// </summary>
	public sealed class DrawingUtility
	{
		private DrawingUtility() {}
		
		public static int ConvertColor2Integer (Color colorToConvert)
		{
			int iResult = colorToConvert.ToArgb ();
			//int iResult2 = (colorToConvert.R << 16) + (colorToConvert.G << 8)+ (colorToConvert.B << 0) + (colorToConvert.A << 24);
			return iResult;
		}

		public static Color ConvertInteger2Color (int valueToConvert)
		{
			Color oColorResult;

			oColorResult = Color.FromArgb (	GetAlphaComponent(valueToConvert),
											GetRedComponent  (valueToConvert),
											GetGreenComponent(valueToConvert),
											GetBlueComponent (valueToConvert));
			return oColorResult;
		}

		public static byte GetRedComponent (int valueToConvert)
		{
			byte u8Result = (byte)(valueToConvert & 0xFF);
			return u8Result;
		}
		public static byte GetGreenComponent (int valueToConvert)
		{
			byte u8Result = (byte)((valueToConvert & 0xFF00) >> 8);
			return u8Result;
		}

		public static byte GetBlueComponent (int valueToConvert)
		{
			byte u8Result = (byte)((valueToConvert & 0xFF0000) >> 16);
			return u8Result;
		}

		public static byte GetAlphaComponent (int valueToConvert)
		{
			byte u8Result = (byte)((valueToConvert & 0xFF000000) >> 24);
			return u8Result;
		}

		public static Color ConvertToColor (string sourceColorBuffer, Color defaultColor)
		{
			return ConvertToColor (StringUtility.GetWordArray2 (sourceColorBuffer), defaultColor);
		}

		public static Color ConvertToColor (string []sourceColor, Color defaultColor)
		{
			Color	DestinationColor;
			int		r,g,b,a;
			bool	UseAlpha;

			r	= 0;
			g	= 0;
			b	= 0;
			a	= 0;
			UseAlpha = false;
			if ((sourceColor != null) && (sourceColor.Length >= 3))
			{
				r		= Int32.Parse (sourceColor[0], CultureInfo.InvariantCulture);
				g		= Int32.Parse (sourceColor[1], CultureInfo.InvariantCulture);
				b		= Int32.Parse (sourceColor[2], CultureInfo.InvariantCulture);
				if (sourceColor.Length >= 4)
				{
					UseAlpha = true;
					a	= Int32.Parse (sourceColor[3], CultureInfo.InvariantCulture);
				}

				if (UseAlpha)
					DestinationColor = System.Drawing.Color.FromArgb(((System.Byte)(r)), ((System.Byte)(g)), ((System.Byte)(b)), ((System.Byte)(a)));
				else
					DestinationColor = System.Drawing.Color.FromArgb(((System.Byte)(r)), ((System.Byte)(g)), ((System.Byte)(b)));
			}
			else
			{
				DestinationColor = defaultColor;
			}
			
			return DestinationColor;
		}
	}
}
