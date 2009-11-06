#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
    [ComImport]
    [Guid("72995A79-5090-42a4-9C8C-D9D0B6D34BE5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMPropertyVault
    {
        void GetPropertyCount([Out] out uint pdwCount);

        void GetPropertyByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [Out] out WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In, Out] ref uint pdwSize);

        void SetProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [In] WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In] uint ddwSize);

        void GetPropertyByIndex(
            [In] uint dwIndex,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName,
            [In, Out] ref uint pdwNameLen,
            [Out] out WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In, Out] ref uint pdwSize);

        void CopyPropertiesFrom([In, MarshalAs(UnmanagedType.Interface)] IWMPropertyVault pIWMPropertyVault);

        void Clear();
    }

    [ComImport]
    [Guid("96406BDC-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig
    {
        void GetStreamType([Out] out Guid pguidStreamType);
        void GetStreamNumber([Out] out ushort pwStreamNum);
        void SetStreamNumber([In] ushort wStreamNum);
        void GetStreamName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszStreamName,
                           [In, Out] ref ushort pcchStreamName);
        void SetStreamName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszStreamName);
        void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszInputName,
                               [In, Out] ref ushort pcchInputName);
        void SetConnectionName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszInputName);
        void GetBitrate([Out] out uint pdwBitrate);
        void SetBitrate([In] uint pdwBitrate);
        void GetBufferWindow([Out] out uint pmsBufferWindow);
        void SetBufferWindow([In] uint msBufferWindow);
    }

    [ComImport]
    [Guid("7688D8CB-FC0D-43BD-9459-5A8DEC200CFA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig2 : IWMStreamConfig
    {
        #region IWMStreamConfig

        new void GetStreamType([Out] out Guid pguidStreamType);
        new void GetStreamNumber([Out] out ushort pwStreamNum);
        new void SetStreamNumber([In] ushort wStreamNum);
        new void GetStreamName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszStreamName,
         [In, Out] ref ushort pcchStreamName);
        new void SetStreamName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszStreamName);
        new void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszInputName,
         [In, Out] ref ushort pcchInputName);
        new void SetConnectionName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszInputName);
        new void GetBitrate([Out] out uint pdwBitrate);
        new void SetBitrate([In] uint pdwBitrate);
        new void GetBufferWindow([Out] out uint pmsBufferWindow);
        new void SetBufferWindow([In] uint msBufferWindow);

        #endregion

        void GetTransportType([Out] out WMT_TRANSPORT_TYPE pnTransportType);
        void SetTransportType([In] WMT_TRANSPORT_TYPE nTransportType);
        void AddDataUnitExtension([In] Guid guidExtensionSystemID,
                                  [In] ushort cbExtensionDataSize,
                                  [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbExtensionSystemInfo,
                                  [In] uint cbExtensionSystemInfo);

        void GetDataUnitExtensionCount([Out] out ushort pcDataUnitExtensions);
        void GetDataUnitExtension([In] uint wDataUnitExtensionNumber,
                                  [Out] out Guid pguidExtensionSystemID,
                                  [Out] out ushort pcbExtensionDataSize,
            /*[out, size_is( *pcbExtensionSystemInfo )]*/ IntPtr pbExtensionSystemInfo,
                                  [In, Out] ref uint pcbExtensionSystemInfo);
        void RemoveAllDataUnitExtensions();
    }

    [ComImport]
    [Guid("CB164104-3AA9-45a7-9AC9-4DAEE131D6E1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig3 : IWMStreamConfig2
    {
        #region IWMStreamConfig

        new void GetStreamType([Out] out Guid pguidStreamType);
        new void GetStreamNumber([Out] out ushort pwStreamNum);
        new void SetStreamNumber([In] ushort wStreamNum);
        new void GetStreamName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszStreamName,
         [In, Out] ref ushort pcchStreamName);
        new void SetStreamName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszStreamName);
        new void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszInputName,
         [In, Out] ref ushort pcchInputName);
        new void SetConnectionName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszInputName);
        new void GetBitrate([Out] out uint pdwBitrate);
        new void SetBitrate([In] uint pdwBitrate);
        new void GetBufferWindow([Out] out uint pmsBufferWindow);
        new void SetBufferWindow([In] uint msBufferWindow);

        #endregion

        #region IWMStreamConfig2

        new void GetTransportType([Out] out WMT_TRANSPORT_TYPE pnTransportType);
        new void SetTransportType([In] WMT_TRANSPORT_TYPE nTransportType);
        new void AddDataUnitExtension([In] Guid guidExtensionSystemID,
          [In] ushort cbExtensionDataSize,
          [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbExtensionSystemInfo,
          [In] uint cbExtensionSystemInfo);

        new void GetDataUnitExtensionCount([Out] out ushort pcDataUnitExtensions);
        new void GetDataUnitExtension([In] uint wDataUnitExtensionNumber,
         [Out] out Guid pguidExtensionSystemID,
         [Out] out ushort pcbExtensionDataSize,
            /*[out, size_is( *pcbExtensionSystemInfo )]*/ IntPtr pbExtensionSystemInfo,
         [In, Out] ref uint pcbExtensionSystemInfo);
        new void RemoveAllDataUnitExtensions();

        #endregion

        void GetLanguage([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszLanguageString,
                         [In, Out] ref ushort pcchLanguageStringLength);
        void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string pwszLanguageString);
    }

    [ComImport]
    [Guid("96406BDB-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile
    {
        void GetVersion([Out] out WMT_VERSION pdwVersion);
        void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                     [In, Out] ref uint pcchName);
        void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
                            [In, Out] ref uint pcchDescription);
        void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription);
        void GetStreamCount([Out] out uint pcStreams);
        void GetStream([In] uint dwStreamIndex, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        void GetStreamByNumber([In] ushort wStreamNum, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        void RemoveStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        void RemoveStreamByNumber([In] ushort wStreamNum);
        void AddStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        void ReconfigStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        void CreateNewStream([In] ref Guid guidStreamType,
                             [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        void GetMutualExclusionCount([Out] out uint pcME);
        void GetMutualExclusion([In] uint dwMEIndex,
                                [Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        void RemoveMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        void AddMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        void CreateNewMutualExclusion([Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
    }

    [ComImport]
    [Guid("d16679f2-6ca0-472d-8d31-2f5d55aee155")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManager
    {
        void CreateEmptyProfile([In] WMT_VERSION dwVersion,
                                [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        void LoadProfileByID([In] ref Guid guidProfile,
                             [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        void LoadProfileByData([In, MarshalAs(UnmanagedType.LPWStr)] string pwszProfile,
                               [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        void SaveProfile([In, MarshalAs(UnmanagedType.Interface)] IWMProfile pIWMProfile,
                         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszProfile,
                         [In, Out] ref uint pdwLength);
        void GetSystemProfileCount([Out] out uint pcProfiles);
        void LoadSystemProfile([In] uint dwProfileIndex,
                               [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
    }

    [ComImport]
    [Guid("7A924E51-73C1-494d-8019-23D37ED9B89A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManager2 : IWMProfileManager
    {
        #region IWMProfileManager

        new void CreateEmptyProfile([In] WMT_VERSION dwVersion,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        new void LoadProfileByID([In] ref Guid guidProfile,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        new void LoadProfileByData([In, MarshalAs(UnmanagedType.LPWStr)] string pwszProfile,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        new void SaveProfile([In, MarshalAs(UnmanagedType.Interface)] IWMProfile pIWMProfile,
         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszProfile,
         [In, Out] ref uint pdwLength);
        new void GetSystemProfileCount([Out] out uint pcProfiles);
        new void LoadSystemProfile([In] uint dwProfileIndex,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);

        #endregion

        void GetSystemProfileVersion([Out] out WMT_VERSION pdwVersion);
        void SetSystemProfileVersion([In] WMT_VERSION dwVersion);
    }

    [ComImport]
    [Guid("BA4DCC78-7EE0-4ab8-B27A-DBCE8BC51454")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManagerLanguage
    {
        void GetUserLanguageID([Out] out ushort wLangID);
        void SetUserLanguageID([In] ushort wLangID);
    }

    [ComImport]
    [Guid("07E72D33-D94E-4be7-8843-60AE5FF7E5F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile2 : IWMProfile
    {
        #region IWMProfile

        new void GetVersion([Out] out WMT_VERSION pdwVersion);
        new void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
         [In, Out] ref uint pcchName);
        new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        new void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
         [In, Out] ref uint pcchDescription);
        new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription);
        new void GetStreamCount([Out] out uint pcStreams);
        new void GetStream([In] uint dwStreamIndex, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        new void GetStreamByNumber([In] ushort wStreamNum, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        new void RemoveStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        new void RemoveStreamByNumber([In] ushort wStreamNum);
        new void AddStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        new void ReconfigStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        new void CreateNewStream([In] ref Guid guidStreamType,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        new void GetMutualExclusionCount([Out] out uint pcME);
        new void GetMutualExclusion([In] uint dwMEIndex,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        new void RemoveMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        new void AddMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        new void CreateNewMutualExclusion([Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);

        #endregion

        void GetProfileID([Out] out Guid pguidID);
    }

    [ComImport]
    [Guid("00EF96CC-A461-4546-8BCD-C9A28F0E06F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile3 : IWMProfile2
    {
        #region IWMProfile

        new void GetVersion([Out] out WMT_VERSION pdwVersion);
        new void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
         [In, Out] ref uint pcchName);
        new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        new void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
         [In, Out] ref uint pcchDescription);
        new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription);
        new void GetStreamCount([Out] out uint pcStreams);
        new void GetStream([In] uint dwStreamIndex, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        new void GetStreamByNumber([In] ushort wStreamNum, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        new void RemoveStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        new void RemoveStreamByNumber([In] ushort wStreamNum);
        new void AddStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        new void ReconfigStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        new void CreateNewStream([In] ref Guid guidStreamType,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        new void GetMutualExclusionCount([Out] out uint pcME);
        new void GetMutualExclusion([In] uint dwMEIndex,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        new void RemoveMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        new void AddMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        new void CreateNewMutualExclusion([Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);

        #endregion

        #region IWMProfile2

        new void GetProfileID([Out] out Guid pguidID);

        #endregion

        void GetStorageFormat([Out] out WMT_STORAGE_FORMAT pnStorageFormat);
        void SetStorageFormat([In] WMT_STORAGE_FORMAT nStorageFormat);
        void GetBandwidthSharingCount([Out] out uint pcBS);
        void GetBandwidthSharing([In] uint dwBSIndex,
                                 [Out, MarshalAs(UnmanagedType.Interface)] out IWMBandwidthSharing ppBS);
        void RemoveBandwidthSharing([In, MarshalAs(UnmanagedType.Interface)] IWMBandwidthSharing pBS);
        void AddBandwidthSharing([In, MarshalAs(UnmanagedType.Interface)] IWMBandwidthSharing pBS);
        void CreateNewBandwidthSharing([Out, MarshalAs(UnmanagedType.Interface)] out IWMBandwidthSharing ppBS);
        void GetStreamPrioritization([Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamPrioritization ppSP);
        void SetStreamPrioritization([In, MarshalAs(UnmanagedType.Interface)] IWMStreamPrioritization pSP);
        void RemoveStreamPrioritization();
        void CreateNewStreamPrioritization([Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamPrioritization ppSP);
        void GetExpectedPacketCount([In] ulong msDuration, [Out] out ulong pcPackets);
    }

    [ComImport]
    [Guid("A970F41E-34DE-4a98-B3BA-E4B3CA7528F0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMCodecInfo
    {
        void GetCodecInfoCount(
            [In] ref Guid guidType,
            [Out] out uint pcCodecs);

        void GetCodecFormatCount(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [Out] out uint pcFormat);

        void GetCodecFormat(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In] uint dwFormatIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppIStreamConfig);
    }

    [ComImport]
    [Guid("AA65E273-B686-4056-91EC-DD768D4DF710")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMCodecInfo2 : IWMCodecInfo
    {
        #region IWMCodecInfo

        new void GetCodecInfoCount(
            [In] ref Guid guidType,
            [Out] out uint pcCodecs);

        new void GetCodecFormatCount(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [Out] out uint pcFormat);

        new void GetCodecFormat(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In] uint dwFormatIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppIStreamConfig);

        #endregion

        void GetCodecName(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
            [In, Out] ref uint pcchName);

        void GetCodecFormatDesc(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In] uint dwFormatIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppIStreamConfig,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDesc,
            [In, Out] ref uint pcchDesc);
    }

    [ComImport]
    [Guid("7e51f487-4d93-4f98-8ab4-27d0565adc51")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMCodecInfo3 : IWMCodecInfo2
    {
        #region IWMCodecInfo

        new void GetCodecInfoCount(
            [In] ref Guid guidType,
            [Out] out uint pcCodecs);

        new void GetCodecFormatCount(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [Out] out uint pcFormat);

        new void GetCodecFormat(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In] uint dwFormatIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppIStreamConfig);

        #endregion

        #region IWMCodecInfo2

        new void GetCodecName(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
            [In, Out] ref uint pcchName);

        new void GetCodecFormatDesc(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In] uint dwFormatIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppIStreamConfig,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDesc,
            [In, Out] ref uint pcchDesc);

        #endregion

        void GetCodecFormatProp(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In] uint dwFormatIndex,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [Out] out WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In, Out] ref uint pdwSize);

        void GetCodecProp(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [Out] out WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In, Out] ref uint pdwSize);

        void SetCodecEnumerationSetting(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [In] WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In] uint ddwSize);

        void GetCodecEnumerationSetting(
            [In] ref Guid guidType,
            [In] uint dwCodecIndex,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [Out] out WMT_ATTR_DATATYPE pType,
            IntPtr pValue,
            [In, Out] ref uint pdwSize);
    }
}

