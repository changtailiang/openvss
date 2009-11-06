#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	[ComImport]
	[Guid("96406BCE-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMMediaProps
	{
		void GetType([Out] out Guid pguidType);

		void GetMediaType(
			/*[out] WM_MEDIA_TYPE* */ IntPtr pType,
			[In, Out] ref uint pcbType);

		void SetMediaType([In] ref WM_MEDIA_TYPE pType);
	}

	[ComImport]
	[Guid("96406BCF-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMVideoMediaProps : IWMMediaProps
	{
		#region IWMMediaProps

		new void GetType([Out] out Guid pguidType);

		new void GetMediaType(
			/*[out] WM_MEDIA_TYPE* */ IntPtr pType,
			[In, Out] ref uint pcbType);

		new void SetMediaType([In] ref WM_MEDIA_TYPE pType);

		#endregion

		void GetMaxKeyFrameSpacing([Out] out long pllTime);

		void SetMaxKeyFrameSpacing([In] long llTime);

		void GetQuality([Out] out uint pdwQuality);

		void SetQuality([In] uint dwQuality);
	}

	[ComImport]
	[Guid("96406BD5-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMInputMediaProps : IWMMediaProps
	{
		#region IWMMediaProps

		new void GetType([Out] out Guid pguidType);

		new void GetMediaType(
			/*[out] WM_MEDIA_TYPE* */ IntPtr pType,
			[In, Out] ref uint pcbType);

		new void SetMediaType([In] ref WM_MEDIA_TYPE pType);

		#endregion

		void GetConnectionName(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchName);

		void GetGroupName(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchName);
	}


	[ComImport]
	[Guid("96406BD7-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMOutputMediaProps : IWMMediaProps
	{
		#region IWMMediaProps

		new void GetType(
			[Out] out Guid pguidType);

		new void GetMediaType(
			/*[out] WM_MEDIA_TYPE* */ IntPtr pType,
			[In, Out] ref uint pcbType);

		new void SetMediaType([In] ref WM_MEDIA_TYPE pType);

		#endregion

		void GetStreamGroupName(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchName);

		void GetConnectionName(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchName);
	}

	[ComImport]
	[Guid("96406BDD-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMStreamList
	{
		void GetStreams([Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
						[In, Out] ref ushort pcStreams);

		void AddStream([In] ushort wStreamNum);

		void RemoveStream([In] ushort wStreamNum);
	}

	[ComImport]
	[Guid("96406BDE-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMMutualExclusion : IWMStreamList
	{
		#region IWMStreamList

		new void GetStreams(
			[Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
			[In, Out] ref ushort pcStreams);

		new void AddStream([In] ushort wStreamNum);

		new void RemoveStream([In] ushort wStreamNum);

		#endregion

		void GetType([Out] out Guid pguidType);

		void SetType([In] ref Guid guidType);
	}

	[ComImport]
	[Guid("0302B57D-89D1-4ba2-85C9-166F2C53EB91")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMMutualExclusion2 : IWMMutualExclusion
	{
		#region IWMStreamList

		new void GetStreams(
			[Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
			[In, Out] ref ushort pcStreams);

		new void AddStream([In] ushort wStreamNum);

		new void RemoveStream([In] ushort wStreamNum);

		#endregion

		#region IWMMutualExclusion

		new void GetType([Out] out Guid pguidType);

		new void SetType([In] ref Guid guidType);

		#endregion

		void GetName(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchName);

		void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);

		void GetRecordCount([Out] out ushort pwRecordCount);

		void AddRecord();

		void RemoveRecord([In] ushort wRecordNumber);

		void GetRecordName(
			[In] ushort wRecordNumber,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszRecordName,
			[In, Out] ref ushort pcchRecordName);

		void SetRecordName(
			[In] ushort wRecordNumber,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszRecordName);

		void GetStreamsForRecord(
			[In] ushort wRecordNumber,
			[Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
			[In, Out] ref ushort pcStreams);

		void AddStreamForRecord([In] ushort wRecordNumber, [In] ushort wStreamNumber);

		void RemoveStreamForRecord([In] ushort wRecordNumber, [In] ushort wStreamNumber);
	}

	[ComImport]
	[Guid("AD694AF1-F8D9-42F8-BC47-70311B0C4F9E")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMBandwidthSharing : IWMStreamList
	{
		#region IWMStreamList

		new void GetStreams(
			[Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
			[In, Out] ref ushort pcStreams);

		new void AddStream([In] ushort wStreamNum);

		new void RemoveStream([In] ushort wStreamNum);

		#endregion

		void GetType([Out] out Guid pguidType);

		void SetType([In] ref Guid guidType);

		void GetBandwidth([Out] out uint pdwBitrate, [Out] out uint pmsBufferWindow);

		void SetBandwidth([In] uint dwBitrate, [In] uint msBufferWindow);
	}

	[ComImport]
	[Guid("8C1C6090-F9A8-4748-8EC3-DD1108BA1E77")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMStreamPrioritization
	{
		void GetPriorityRecords(
			[Out, MarshalAs(UnmanagedType.LPArray)] WM_STREAM_PRIORITY_RECORD[] pRecordArray,
			[In, Out] ref ushort pcRecords);

		void SetPriorityRecords(
			[In, MarshalAs(UnmanagedType.LPArray)] WM_STREAM_PRIORITY_RECORD[] pRecordArray,
			[In] ushort cRecords);
	}

	[ComImport]
	[Guid("6d7cdc70-9888-11d3-8edc-00c04f6109cf")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMStatusCallback
	{
		void OnStatus(
			[In] WMT_STATUS Status,
			[In] int hr,
			[In] WMT_ATTR_DATATYPE dwType,
			[In] IntPtr pValue,
			[In] IntPtr pvContext);
	}

	[ComImport]
	[Guid("96406BDA-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMHeaderInfo
	{
		void GetAttributeCount(
			[In] ushort wStreamNum,
			[Out] out ushort pcAttributes);

		void GetAttributeByIndex(
			[In] ushort wIndex,
			[In, Out] ref ushort pwStreamNum,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchNameLen,
			[Out] out WMT_ATTR_DATATYPE pType,
			IntPtr pValue,
			[In, Out] ref ushort pcbLength);

		void GetAttributeByName(
			[In, Out] ref ushort pwStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[Out] out WMT_ATTR_DATATYPE pType,
			IntPtr pValue,
			[In, Out] ref ushort pcbLength);

		void SetAttribute(
			[In] ushort wStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In] WMT_ATTR_DATATYPE Type,
			IntPtr pValue,
			[In] ushort cbLength);

		void GetMarkerCount([Out] out ushort pcMarkers);

		void GetMarker(
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszMarkerName,
			[In, Out] ref ushort pcchMarkerNameLen,
			[Out] out ulong pcnsMarkerTime);

		void AddMarker(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszMarkerName,
			[In] ulong cnsMarkerTime);

		void RemoveMarker([In] ushort wIndex);

		void GetScriptCount([Out] out ushort pcScripts);

		void GetScript(
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszType,
			[In, Out] ref ushort pcchTypeLen,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszCommand,
			[In, Out] ref ushort pcchCommandLen,
			[Out] out ulong pcnsScriptTime);

		void AddScript(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszType,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommand,
			[In] ulong cnsScriptTime);

		void RemoveScript([In] ushort wIndex);
	}

	[ComImport]
	[Guid("15CF9781-454E-482e-B393-85FAE487A810")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMHeaderInfo2 : IWMHeaderInfo
	{
		#region IWMHeaderInfo

		new void GetAttributeCount([In] ushort wStreamNum, [Out] out ushort pcAttributes);

		new void GetAttributeByIndex(
			[In] ushort wIndex,
			[In, Out] ref ushort pwStreamNum,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchNameLen,
			[Out] out WMT_ATTR_DATATYPE pType,
		    IntPtr pValue,
		    [In, Out] ref ushort pcbLength);

		new void GetAttributeByName(
			[In, Out] ref ushort pwStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[Out] out WMT_ATTR_DATATYPE pType,
		    IntPtr pValue,
		    [In, Out] ref ushort pcbLength);

		new void SetAttribute(
			[In] ushort wStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In] WMT_ATTR_DATATYPE Type,
		    IntPtr pValue,
		    [In] ushort cbLength);
 
		new void GetMarkerCount([Out] out ushort pcMarkers);

		new void GetMarker(
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszMarkerName,
			[In, Out] ref ushort pcchMarkerNameLen,
			[Out] out ulong pcnsMarkerTime);

		new void AddMarker(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszMarkerName,
			[In] ulong cnsMarkerTime);

		new void RemoveMarker([In] ushort wIndex);

		new void GetScriptCount([Out] out ushort pcScripts);

		new void GetScript(
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszType,
			[In, Out] ref ushort pcchTypeLen,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszCommand,
			[In, Out] ref ushort pcchCommandLen,
			[Out] out ulong pcnsScriptTime);

		new void AddScript(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszType,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommand,
			[In] ulong cnsScriptTime);

		new void RemoveScript([In] ushort wIndex);

		#endregion

		void GetCodecInfoCount([Out] out uint pcCodecInfos);

		void GetCodecInfo(
			[In] uint wIndex,
			[In, Out] ref ushort pcchName,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchDescription,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
			[Out] out WMT_CODEC_INFO_TYPE pCodecType,
			[In, Out] ref ushort pcbCodecInfo,
			IntPtr pbCodecInfo);
	}

	[ComImport]
	[Guid("15CC68E3-27CC-4ecd-B222-3F5D02D80BD5")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMHeaderInfo3 : IWMHeaderInfo2
	{
		#region IWMHeaderInfo

		new void GetAttributeCount([In] ushort wStreamNum, [Out] out ushort pcAttributes);

		new void GetAttributeByIndex(
			[In] ushort wIndex,
			[In, Out] ref ushort pwStreamNum,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchNameLen,
			[Out] out WMT_ATTR_DATATYPE pType,
		    IntPtr pValue,
		    [In, Out] ref ushort pcbLength);

		new void GetAttributeByName(
			[In, Out] ref ushort pwStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[Out] out WMT_ATTR_DATATYPE pType,
		    IntPtr pValue,
		    [In, Out] ref ushort pcbLength);

		new void SetAttribute(
			[In] ushort wStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In] WMT_ATTR_DATATYPE Type,
		    IntPtr pValue,
		    [In] ushort cbLength);

		new void GetMarkerCount([Out] out ushort pcMarkers);

		new void GetMarker(
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszMarkerName,
			[In, Out] ref ushort pcchMarkerNameLen,
			[Out] out ulong pcnsMarkerTime);

		new void AddMarker(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszMarkerName,
			[In] ulong cnsMarkerTime);

		new void RemoveMarker([In] ushort wIndex);

		new void GetScriptCount([Out] out ushort pcScripts);

		new void GetScript(
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszType,
			[In, Out] ref ushort pcchTypeLen,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszCommand,
			[In, Out] ref ushort pcchCommandLen,
			[Out] out ulong pcnsScriptTime);

		new void AddScript(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszType,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommand,
			[In] ulong cnsScriptTime);

		#endregion

		#region IWMHeaderInfo2

		new void GetCodecInfoCount([Out] out uint pcCodecInfos);

		new void GetCodecInfo(
			[In] uint wIndex,
			[In, Out] ref ushort pcchName,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pcchDescription,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
			[Out] out WMT_CODEC_INFO_TYPE pCodecType,
			[In, Out] ref ushort pcbCodecInfo,
			IntPtr pbCodecInfo);

		#endregion

		void GetAttributeCountEx(
			[In] ushort wStreamNum,
			[Out] out ushort pcAttributes);

		void GetAttributeIndices(
			[In] ushort wStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
			/* DWORD* */ IntPtr pwLangIndex,
			[Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwIndices,
			[In, Out] ref ushort pwCount);

		void GetAttributeByIndexEx(
			[In] ushort wStreamNum,
			[In] ushort wIndex,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
			[In, Out] ref ushort pwNameLen,
			[Out] out WMT_ATTR_DATATYPE pType,
			[Out] out ushort pwLangIndex,
			IntPtr pValue,
			[In, Out] ref uint pdwDataLength);

		void ModifyAttribute(
			[In] ushort wStreamNum,
			[In] ushort wIndex,
			[In] WMT_ATTR_DATATYPE Type,
			[In] ushort wLangIndex,
			IntPtr pValue,
			[In] uint dwLength);

		void AddAttribute(
			[In] ushort wStreamNum,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[Out] out ushort pwIndex,
			[In] WMT_ATTR_DATATYPE Type,
			[In] ushort wLangIndex,
			IntPtr pValue,
			[In] uint dwLength);

		void DeleteAttribute(
			[In] ushort wStreamNum,
			[In] ushort wIndex);

		void AddCodecInfo(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription,
			[In] WMT_CODEC_INFO_TYPE codecType,
			[In] ushort cbCodecInfo,
			IntPtr pbCodecInfo);
	}

	[ComImport]
	[Guid("96406BD9-2B2B-11d3-B36B-00C04F6108FF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMMetadataEditor
	{
		void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);

		void Close();

		void Flush();
	}

	[Guid("203CFFE3-2E18-4fdf-B59D-6E71530534CF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMMetadataEditor2 : IWMMetadataEditor
	{
		#region IWMMetadataEditor

		new void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);

		new void Close();

		new void Flush();

		#endregion

		void OpenEx(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename,
			[In] uint dwDesiredAccess,
			[In] uint dwShareMode);
	}

	[ComImport]
	[Guid("6d7cdc71-9888-11d3-8edc-00c04f6109cf")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMIndexer
	{
		void StartIndexing(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
			[In, MarshalAs(UnmanagedType.Interface)] IWMStatusCallback pCallback,
			[In] IntPtr pvContext);

		void Cancel();
	}

	[ComImport]
	[Guid("B70F1E42-6255-4df0-A6B9-02B212D9E2BB")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWMIndexer2 : IWMIndexer
	{
		#region IWMIndexer

		new void StartIndexing(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
			[In, MarshalAs(UnmanagedType.Interface)] IWMStatusCallback pCallback,
			[In] IntPtr pvContext);

		new void Cancel();

		#endregion

		void Configure(
			[In] ushort wStreamNum,
			[In] WMT_INDEXER_TYPE nIndexerType,
			[In] IntPtr pvInterval,
			[In] IntPtr pvIndexType);
	}
}
