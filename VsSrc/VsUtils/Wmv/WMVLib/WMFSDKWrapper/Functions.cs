#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class Functions
	{
		[DllImport("WMVCore.dll", EntryPoint = "WMCreateEditor", SetLastError = true,
			 CharSet = CharSet.Unicode, ExactSpelling = true,
			 CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateEditor(
			[Out, MarshalAs(UnmanagedType.Interface)] out IWMMetadataEditor ppMetadataEditor);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateReader", SetLastError = true,
		 CharSet = CharSet.Unicode, ExactSpelling = true,
		 CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateReader(
			IntPtr pUnkReserved,
			WMT_RIGHTS dwRights,
			[Out, MarshalAs(UnmanagedType.Interface)] out IWMReader ppReader);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateSyncReader", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateSyncReader(
			IntPtr pUnkCert,
			WMT_RIGHTS dwRights,
			[Out, MarshalAs(UnmanagedType.Interface)] out IWMSyncReader ppSyncReader);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateProfileManager", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateProfileManager([Out, MarshalAs(UnmanagedType.Interface)] out IWMProfileManager ppProfileManager);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateIndexer", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateIndexer([Out, MarshalAs(UnmanagedType.Interface)] out IWMIndexer ppIndexer);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateWriter", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateWriter(
			IntPtr pUnkReserved, 
			[Out, MarshalAs(UnmanagedType.Interface)] out IWMWriter ppWriter);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateWriterFileSink", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateWriterFileSink([Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterFileSink ppSink);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateWriterNetworkSink", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateWriterNetworkSink([Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterNetworkSink ppSink);

		[DllImport("WMVCore.dll", EntryPoint = "WMCreateWriterPushSink", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCreateWriterPushSink([Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterPushSink ppSink);

		[DllImport("WMVCore.dll", EntryPoint = "WMIsAvailableOffline", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMIsAvailableOffline(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszLanguage,
			[Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsAvailableOffline);

		[DllImport("WMVCore.dll", EntryPoint = "WMIsContentProtected", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMIsContentProtected(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
			[Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsProtected);

		[DllImport("WMVCore.dll", EntryPoint = "WMValidateData", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMValidateData(
			[In, MarshalAs(UnmanagedType.LPArray)] byte[] pbData,
			[In, Out] ref uint pdwDataSize);

		[DllImport("WMVCore.dll", EntryPoint = "WMCheckURLExtension", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCheckURLExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL);

		[DllImport("WMVCore.dll", EntryPoint = "WMCheckURLScheme", SetLastError = true,
		   CharSet = CharSet.Unicode, ExactSpelling = true,
		   CallingConvention = CallingConvention.StdCall)]
		public static extern int WMCheckURLScheme([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURLScheme);
	}
}
