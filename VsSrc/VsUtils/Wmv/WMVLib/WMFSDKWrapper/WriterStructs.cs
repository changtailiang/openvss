#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	[StructLayout(LayoutKind.Sequential)]
	public struct WM_WRITER_STATISTICS
	{
		public ulong qwSampleCount;
		public ulong qwByteCount;
		public ulong qwDroppedSampleCount;
		public ulong qwDroppedByteCount;
		public uint dwCurrentBitrate;
		public uint dwAverageBitrate;
		public uint dwExpectedBitrate;
		public uint dwCurrentSampleRate;
		public uint dwAverageSampleRate;
		public uint dwExpectedSampleRate;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WM_WRITER_STATISTICS_EX
	{
		public uint dwBitratePlusOverhead;
		public uint dwCurrentSampleDropRateInQueue;
		public uint dwCurrentSampleDropRateInCodec;
		public uint dwCurrentSampleDropRateInMultiplexer;
		public uint dwTotalSampleDropsInQueue;
		public uint dwTotalSampleDropsInCodec;
		public uint dwTotalSampleDropsInMultiplexer;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WMT_BUFFER_SEGMENT
	{
		public INSSBuffer pBuffer;
		public uint cbOffset;
		public uint cbLength;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WMT_PAYLOAD_FRAGMENT
	{
		public uint dwPayloadIndex;
		public WMT_BUFFER_SEGMENT segmentData;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WMT_FILESINK_DATA_UNIT
	{
		public WMT_BUFFER_SEGMENT packetHeaderBuffer;
		public uint cPayloads;
		/*WMT_BUFFER_SEGMENT* */
		public IntPtr pPayloadHeaderBuffers;
		public uint cPayloadDataFragments;
		/*WMT_PAYLOAD_FRAGMENT* */
		public IntPtr pPayloadDataFragments;
	}
}
