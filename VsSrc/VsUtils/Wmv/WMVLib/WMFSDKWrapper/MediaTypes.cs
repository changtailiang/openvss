#region Using directives

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class MediaTypes
	{
		public static Guid WMMEDIATYPE_Audio = new Guid("73647561-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIATYPE_FileTransfer = new Guid("D9E47579-930E-4427-ADFC-AD80F290E470");
		public static Guid WMMEDIATYPE_Image = new Guid("34A50FD8-8AA5-4386-81FE-A0EFE0488E31");
		public static Guid WMMEDIATYPE_Script = new Guid("73636D64-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIATYPE_Text = new Guid("9BBA1EA7-5AB2-4829-BA57-0940209BCF3E");
		public static Guid WMMEDIATYPE_Video = new Guid("73646976-0000-0010-8000-00AA00389B71");
	}

	public class MediaSubTypes
	{
		public static Guid WMMEDIASUBTYPE_I420 = new Guid("30323449-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_IYUV = new Guid("56555949-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_RGB1 = new Guid("E436EB78-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_RGB24 = new Guid("E436EB7D-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_RGB32 = new Guid("E436EB7E-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_RGB4 = new Guid("E436EB79-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_RGB555 = new Guid("E436EB7C-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_RGB565 = new Guid("E436EB7B-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_RGB8 = new Guid("E436EB7A-524F-11CE-9F53-0020AF0BA770");
		public static Guid WMMEDIASUBTYPE_UYVY = new Guid("59565955-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_VIDEOIMAGE = new Guid("1D4A45F2-E5F6-4B44-8388-F0AE5C0E0C37");
        public static Guid WMMEDIASUBTYPE_YV12 = new Guid("32315659-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_NV12 = new Guid("3231564E-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_IMC1 = new Guid("31434D49-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_IMC2 = new Guid("32434d49-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_IMC3 = new Guid("33434d49-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_IMC4 = new Guid("34434d49-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_S340 = new Guid("30343353-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_S342 = new Guid("32343353-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_Overlay = new Guid("e436eb7f-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1Packet = new Guid("e436eb80-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1Payload = new Guid("e436eb81-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1AudioPayload = new Guid("00000050-0000-0010-8000-00AA00389B71");
        public static Guid WMMEDIASUBTYPE_MPEG1SystemStream = new Guid("e436eb82-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1System = new Guid("e436eb84-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1VideoCD = new Guid("e436eb85-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1Video = new Guid("e436eb86-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_MPEG1Audio = new Guid("e436eb87-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_Avi = new Guid("e436eb88-524f-11ce-9f53-0020af0ba770");
        public static Guid WMMEDIASUBTYPE_Asf = new Guid("3DB80F90-9412-11d1-ADED-0000F8754B99");
        public static Guid WMMEDIASUBTYPE_YUY2 = new Guid("32595559-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_YVU9 = new Guid("39555659-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_YVYU = new Guid("55595659-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_ACELPnet = new Guid("00000130-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_Base = new Guid("00000000-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_DRM = new Guid("00000009-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_MP3 = new Guid("00000050-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_MP43 = new Guid("3334504D-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_MP4S = new Guid("5334504D-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_MPEG2_VIDEO = new Guid("E06D8026-DB46-11CF-B4D1-00805F6CBBEA");
		public static Guid WMMEDIASUBTYPE_MSS1 = new Guid("3153534D-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_MSS2 = new Guid("3253534D-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_PCM = new Guid("00000001-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WebStream = new Guid("776257D4-C627-41CB-8F81-7AC7FF1C40CC");
		public static Guid WMMEDIASUBTYPE_WMAudio_Lossless = new Guid("00000163-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMAudioV2 = new Guid("00000161-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMAudioV7 = new Guid("00000161-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMAudioV8 = new Guid("00000161-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMAudioV9 = new Guid("00000162-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMSP1 = new Guid("0000000A-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMV1 = new Guid("31564D57-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMV2 = new Guid("32564D57-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMV3 = new Guid("33564D57-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMVP = new Guid("50564D57-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WMVA = new Guid("41564D57-0000-0010-8000-00AA00389B71");
		public static Guid WMMEDIASUBTYPE_WVP2 = new Guid("32505657-0000-0010-8000-00AA00389B71");
	}

	public class FormatTypes
	{
		public static Guid WMFORMAT_MPEG2Video = new Guid("E06D80E3-DB46-11CF-B4D1-00805F6CBBEA");
		public static Guid WMFORMAT_Script = new Guid("5C8510F2-DEBE-4CA7-BBA5-F07A104F8DFF");
		public static Guid WMFORMAT_VideoInfo = new Guid("05589F80-C356-11CE-BF01-00AA0055595A");
		public static Guid WMFORMAT_WaveFormatEx = new Guid("05589F81-C356-11CE-BF01-00AA0055595A");
		public static Guid WMFORMAT_WebStream = new Guid("DA1E6B13-8359-4050-B398-388E965BF00C");
	}

	public class ScriptTypes
	{
		public static Guid WMSCRIPTTYPE_TwoStrings = new Guid("82F38A70-C29F-11D1-97AD-00A0C95EA850");
	}
}

