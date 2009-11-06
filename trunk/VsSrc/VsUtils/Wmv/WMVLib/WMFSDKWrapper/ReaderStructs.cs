#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WM_READER_CLIENTINFO
	{
		public uint cbSize;
		
		[MarshalAs(UnmanagedType.LPWStr)]
		public string wszLang;
		
		[MarshalAs(UnmanagedType.LPWStr)]
		public string wszBrowserUserAgent;
		
		[MarshalAs(UnmanagedType.LPWStr)]
		public string wszBrowserWebPage;
		
		ulong qwReserved;
		
		public IntPtr pReserved;
		
		[MarshalAs(UnmanagedType.LPWStr)]
		public string wszHostExe;
		
		public ulong qwHostVersion;
		
		[MarshalAs(UnmanagedType.LPWStr)]
		public string wszPlayerUserAgent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WM_READER_STATISTICS
	{
		public uint cbSize;
		public uint dwBandwidth;
		public uint cPacketsReceived;
		public uint cPacketsRecovered;
		public uint cPacketsLost;
		public uint wQuality;
	}
}
