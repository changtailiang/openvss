#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	[StructLayout(LayoutKind.Sequential)]
	public struct WMT_TIMECODE_EXTENSION_DATA
	{
		public ushort wRange;
		public uint dwTimecode;
		public uint dwUserbits;
		public uint dwAmFlags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WM_STREAM_PRIORITY_RECORD
	{
		public ushort wStreamNumber;

		[MarshalAs(UnmanagedType.Bool)]
		public bool fMandatory;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WM_MEDIA_TYPE
	{
		public Guid majortype;
		public Guid subtype;
		[MarshalAs(UnmanagedType.Bool)]
		public bool bFixedSizeSamples;
		[MarshalAs(UnmanagedType.Bool)]
		public bool bTemporalCompression;
		public uint lSampleSize;
		public Guid formattype;
		public IntPtr pUnk;
		public uint cbFormat;
		public IntPtr pbFormat;
	}
}
