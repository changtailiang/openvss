#region Using directives

using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Rect
	{
		public uint left;
		public uint top;
		public uint right;
		public uint bottom;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BitmapInfoHeader
	{
		public uint biSize;
		public uint biWidth;
		public uint biHeight;
		public ushort biPlanes;
		public ushort biBitCount;
		public uint biCompression;
		public uint biSizeImage;
		public uint biXPelsPerMeter;
		public uint biYPelsPerMeter;
		public uint biClrUsed;
		public uint biClrImportant;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VideoInfoHeader
	{
		public Rect rcSource;
		public Rect rcTarget;
		public uint dwBitRate;
		public uint dwBitErrorRate;
		public ulong AvgTimePerFrame;
		public BitmapInfoHeader bmiHeader;
	}
}
