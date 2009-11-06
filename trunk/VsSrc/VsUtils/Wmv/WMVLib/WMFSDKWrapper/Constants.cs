#region Using directives



#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{

	public class Constants
	{
		public const int S_OK = 0;
        public const int NS_E_INVALID_INPUT_FORMAT = unchecked((int)0xC00D0BB8);
        public const int NS_E_INVALID_DATA = unchecked((int)0xC00D002F);
        public const int NS_E_INVALID_REQUEST = unchecked((int)0xC00D002B);
		public const int NS_E_NO_MORE_SAMPLES = unchecked((int)0xC00D0BCF);
        public const int NS_E_LATE_OPERATION = unchecked((int)0xC00D002E);
        public const int NS_E_AUDIO_CODEC_ERROR = unchecked((int)0xC00D0BC3);
		public const int ASF_E_NOTFOUND = unchecked((int)0xC00D07F0);
		public const int E_UNEXPECTED = unchecked((int)0x8000FFFF);
		public const int E_NOTIMPL = unchecked((int)0x80004001);

		////////////////////////////////////////////////////////////////
		//
		// These are the special case attributes that give information 
		// about the Windows Media file.
		//
		public const string g_wszWMDuration = "Duration";
		public const string g_wszWMBitrate = "Bitrate";
		public const string g_wszWMSeekable = "Seekable";
		public const string g_wszWMStridable = "Stridable";
		public const string g_wszWMBroadcast = "Broadcast";
		public const string g_wszWMProtected = "Is_Protected";
		public const string g_wszWMTrusted = "Is_Trusted";
		public const string g_wszWMSignature_Name = "Signature_Name";
		public const string g_wszWMHasAudio = "HasAudio";
		public const string g_wszWMHasImage = "HasImage";
		public const string g_wszWMHasScript = "HasScript";
		public const string g_wszWMHasVideo = "HasVideo";
		public const string g_wszWMCurrentBitrate = "CurrentBitrate";
		public const string g_wszWMOptimalBitrate = "OptimalBitrate";
		public const string g_wszWMHasAttachedImages = "HasAttachedImages";
		public const string g_wszWMSkipBackward = "Can_Skip_Backward";
		public const string g_wszWMSkipForward = "Can_Skip_Forward";
		public const string g_wszWMNumberOfFrames = "NumberOfFrames";
		public const string g_wszWMFileSize = "FileSize";
		public const string g_wszWMHasArbitraryDataStream = "HasArbitraryDataStream";
		public const string g_wszWMHasFileTransferStream = "HasFileTransferStream";
		public const string g_wszWMContainerFormat = "WM/ContainerFormat";

		////////////////////////////////////////////////////////////////
		//
		// The content description object supports 5 basic attributes.
		//
		public const string g_wszWMTitle = "Title";
		public const string g_wszWMAuthor = "Author";
		public const string g_wszWMDescription = "Description";
		public const string g_wszWMRating = "Rating";
		public const string g_wszWMCopyright = "Copyright";

		////////////////////////////////////////////////////////////////
		//
		// These attributes are used to configure and query DRM settings in the reader and writer.
		//
		public const string g_wszWMUse_DRM = "Use_DRM";
		public const string g_wszWMDRM_Flags = "DRM_Flags";
		public const string g_wszWMDRM_Level = "DRM_Level";
		public const string g_wszWMUse_Advanced_DRM = "Use_Advanced_DRM";
		public const string g_wszWMDRM_KeySeed = "DRM_KeySeed";
		public const string g_wszWMDRM_KeyID = "DRM_KeyID";
		public const string g_wszWMDRM_ContentID = "DRM_ContentID";
		public const string g_wszWMDRM_IndividualizedVersion = "DRM_IndividualizedVersion";
		public const string g_wszWMDRM_LicenseAcqURL = "DRM_LicenseAcqUR";
		public const string g_wszWMDRM_V1LicenseAcqURL = "DRM_V1LicenseAcqUR";
		public const string g_wszWMDRM_HeaderSignPrivKey = "DRM_HeaderSignPrivKey";
		public const string g_wszWMDRM_LASignaturePrivKey = "DRM_LASignaturePrivKey";
		public const string g_wszWMDRM_LASignatureCert = "DRM_LASignatureCert";
		public const string g_wszWMDRM_LASignatureLicSrvCert = "DRM_LASignatureLicSrvCert";
		public const string g_wszWMDRM_LASignatureRootCert = "DRM_LASignatureRootCert";

		////////////////////////////////////////////////////////////////
		//
		// These are the additional attributes defined in the WM attribute
		// namespace that give information about the content.
		//
		public const string g_wszWMAlbumTitle = "WM/AlbumTitle";
		public const string g_wszWMTrack = "WM/Track";
		public const string g_wszWMPromotionURL = "WM/PromotionURL";
		public const string g_wszWMAlbumCoverURL = "WM/AlbumCoverURL";
		public const string g_wszWMGenre = "WM/Genre";
		public const string g_wszWMYear = "WM/Year";
		public const string g_wszWMGenreID = "WM/GenreID";
		public const string g_wszWMMCDI = "WM/MCDI";
		public const string g_wszWMComposer = "WM/Composer";
		public const string g_wszWMLyrics = "WM/Lyrics";
		public const string g_wszWMTrackNumber = "WM/TrackNumber";
		public const string g_wszWMToolName = "WM/ToolName";
		public const string g_wszWMToolVersion = "WM/ToolVersion";
		public const string g_wszWMIsVBR = "IsVBR";
		public const string g_wszWMAlbumArtist = "WM/AlbumArtist";

		////////////////////////////////////////////////////////////////
		//
		// These optional attributes may be used to give information 
		// about the branding of the content.
		//
		public const string g_wszWMBannerImageType = "BannerImageType";
		public const string g_wszWMBannerImageData = "BannerImageData";
		public const string g_wszWMBannerImageURL = "BannerImageURL";
		public const string g_wszWMCopyrightURL = "CopyrightURL";
		////////////////////////////////////////////////////////////////
		//
		// Optional attributes, used to give information 
		// about video stream properties.
		//
		public const string g_wszWMAspectRatioX = "AspectRatioX";
		public const string g_wszWMAspectRatioY = "AspectRatioY";

		////////////////////////////////////////////////////////////////
		//
		// Optional attributes, used to give information 
		// about the overall streaming properties of VBR files.
		// This attribute takes the format:
		//  WORD wReserved (must be 0)
		//  WM_LEAKY_BUCKET_PAIR pair1
		//  WM_LEAKY_BUCKET_PAIR pair2
		//  ...
		//
		public const string g_wszASFLeakyBucketPairs = "ASFLeakyBucketPairs";

		////////////////////////////////////////////////////////////////
		//
		// The NSC file supports the following attributes.
		//
		public const string g_wszWMNSCName = "NSC_Name";
		public const string g_wszWMNSCAddress = "NSC_Address";
		public const string g_wszWMNSCPhone = "NSC_Phone";
		public const string g_wszWMNSCEmail = "NSC_Email";
		public const string g_wszWMNSCDescription = "NSC_Description";

		////////////////////////////////////////////////////////////////
		//
		// Attributes introduced in V9
		//
		public const string g_wszWMWriter = "WM/Writer";
		public const string g_wszWMConductor = "WM/Conductor";
		public const string g_wszWMProducer = "WM/Producer";
		public const string g_wszWMDirector = "WM/Director";
		public const string g_wszWMContentGroupDescription = "WM/ContentGroupDescription";
		public const string g_wszWMSubTitle = "WM/SubTitle";
		public const string g_wszWMPartOfSet = "WM/PartOfSet";
		public const string g_wszWMProtectionType = "WM/ProtectionType";
		public const string g_wszWMVideoHeight = "WM/VideoHeight";
		public const string g_wszWMVideoWidth = "WM/VideoWidth";
		public const string g_wszWMVideoFrameRate = "WM/VideoFrameRate";
		public const string g_wszWMMediaClassPrimaryID = "WM/MediaClassPrimaryID";
		public const string g_wszWMMediaClassSecondaryID = "WM/MediaClassSecondaryID";
		public const string g_wszWMPeriod = "WM/Period";
		public const string g_wszWMCategory = "WM/Category";
		public const string g_wszWMPicture = "WM/Picture";
		public const string g_wszWMLyrics_Synchronised = "WM/Lyrics_Synchronised";
		public const string g_wszWMOriginalLyricist = "WM/OriginalLyricist";
		public const string g_wszWMOriginalArtist = "WM/OriginalArtist";
		public const string g_wszWMOriginalAlbumTitle = "WM/OriginalAlbumTitle";
		public const string g_wszWMOriginalReleaseYear = "WM/OriginalReleaseYear";
		public const string g_wszWMOriginalFilename = "WM/OriginalFilename";
		public const string g_wszWMPublisher = "WM/Publisher";
		public const string g_wszWMEncodedBy = "WM/EncodedBy";
		public const string g_wszWMEncodingSettings = "WM/EncodingSettings";
		public const string g_wszWMEncodingTime = "WM/EncodingTime";
		public const string g_wszWMAuthorURL = "WM/AuthorURL";
		public const string g_wszWMUserWebURL = "WM/UserWebURL";
		public const string g_wszWMAudioFileURL = "WM/AudioFileURL";
		public const string g_wszWMAudioSourceURL = "WM/AudioSourceURL";
		public const string g_wszWMLanguage = "WM/Language";
		public const string g_wszWMParentalRating = "WM/ParentalRating";
		public const string g_wszWMBeatsPerMinute = "WM/BeatsPerMinute";
		public const string g_wszWMInitialKey = "WM/InitialKey";
		public const string g_wszWMMood = "WM/Mood";
		public const string g_wszWMText = "WM/Text";
		public const string g_wszWMDVDID = "WM/DVDID";
		public const string g_wszWMWMContentID = "WM/WMContentID";
		public const string g_wszWMWMCollectionID = "WM/WMCollectionID";
		public const string g_wszWMWMCollectionGroupID = "WM/WMCollectionGroupID";
		public const string g_wszWMUniqueFileIdentifier = "WM/UniqueFileIdentifier";
		public const string g_wszWMModifiedBy = "WM/ModifiedBy";
		public const string g_wszWMRadioStationName = "WM/RadioStationName";
		public const string g_wszWMRadioStationOwner = "WM/RadioStationOwner";
		public const string g_wszWMPlaylistDelay = "WM/PlaylistDelay";
		public const string g_wszWMCodec = "WM/Codec";
		public const string g_wszWMDRM = "WM/DRM";
		public const string g_wszWMISRC = "WM/ISRC";
		public const string g_wszWMProvider = "WM/Provider";
		public const string g_wszWMProviderRating = "WM/ProviderRating";
		public const string g_wszWMProviderStyle = "WM/ProviderStyle";
		public const string g_wszWMContentDistributor = "WM/ContentDistributor";
		public const string g_wszWMSubscriptionContentID = "WM/SubscriptionContentID";
		public const string g_wszWMWMADRCPeakReference = "WM/WMADRCPeakReference";
		public const string g_wszWMWMADRCPeakTarget = "WM/WMADRCPeakTarget";
		public const string g_wszWMWMADRCAverageReference = "WM/WMADRCAverageReference";
		public const string g_wszWMWMADRCAverageTarget = "WM/WMADRCAverageTarget";

		////////////////////////////////////////////////////////////////
		//
		// VBR encoding settings
		//
		public const string g_wszVBREnabled = "_VBRENABLED";
		public const string g_wszVBRQuality = "_VBRQUALITY";
		public const string g_wszVBRBitrateMax = "_RMAX";
		public const string g_wszVBRBufferWindowMax = "_BMAX";
        public const string g_wszNumPasses = "_PASSESUSED";

		////////////////////////////////////////////////////////////////
		//
		// These are setting names for use in Get/SetOutputSetting
		//
		public const string g_wszEarlyDataDelivery = "EarlyDataDelivery";
		public const string g_wszJustInTimeDecode = "JustInTimeDecode";
		public const string g_wszSingleOutputBuffer = "SingleOutputBuffer";
		public const string g_wszSoftwareScaling = "SoftwareScaling";
		public const string g_wszDeliverOnReceive = "DeliverOnReceive";
		public const string g_wszScrambledAudio = "ScrambledAudio";
		public const string g_wszDedicatedDeliveryThread = "DedicatedDeliveryThread";
		public const string g_wszEnableDiscreteOutput = "EnableDiscreteOutput";
		public const string g_wszSpeakerConfig = "SpeakerConfig";
		public const string g_wszDynamicRangeControl = "DynamicRangeControl";
		public const string g_wszAllowInterlacedOutput = "AllowInterlacedOutput";
		public const string g_wszVideoSampleDurations = "VideoSampleDurations";
		public const string g_wszStreamLanguage = "StreamLanguage";
		public const string g_wszEnableWMAProSPDIFOutput = "EnableWMAProSPDIFOutput";

		////////////////////////////////////////////////////////////////
		//
		// These are setting names for use in Get/SetInputSetting
		//
		public const string g_wszDeinterlaceMode = "DeinterlaceMode";
		public const string g_wszInitialPatternForInverseTelecine = "InitialPatternForInverseTelecine";
		public const string g_wszJPEGCompressionQuality = "JPEGCompressionQuality";
		public const string g_wszWatermarkCLSID = "WatermarkCLSID";
		public const string g_wszWatermarkConfig = "WatermarkConfig";
		public const string g_wszInterlacedCoding = "InterlacedCoding";
		public const string g_wszFixedFrameRate = "FixedFrameRate";

        ////////////////////////////////////////////////////////////////
        //
        // All known IWMPropertyVault property names
        //
        // g_wszOriginalSourceFormatTag is obsolete and has been superceded by g_wszOriginalWaveFormat
        public const string g_wszOriginalSourceFormatTag = "_SOURCEFORMATTAG";
        public const string g_wszOriginalWaveFormat = "_ORIGINALWAVEFORMAT";
        public const string g_wszEDL = "_ED";
        public const string g_wszComplexity = "_COMPLEXITYEX";
        public const string g_wszDecoderComplexityRequested = "_DECODERCOMPLEXITYPROFILE";
	}
}

