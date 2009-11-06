#region Using directives

using System;
using System.Runtime.InteropServices;
using WMEncoderLib;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class WMEncProfile
	{
        public const float DEFAULT_FRAME_RATE = 30.0F;
        public const int DEFAULT_COMPRESSION_QUALITY = 100;
        public const int DEFAULT_IMAGE_SHARPNESS = 90;
        public const int DEFAULT_KEYFRAME_DISTANCE = 3;

        public static string[] VideoCodecs = new string[] 
		{
			"Windows Media Video V7",
			"Windows Media Video 9 Screen",
			"Windows Media Video 9",
			"Windows Media Video V8",
			"Windows Media Video 9 Advanced Profile",
			"Windows Media Video 9 Image v2",
			"Full frames (uncompressed)"
		};

        public static string[] AudioCodecs = new string[]
		{
			"Windows Media Audio 9.1",
			"ACELP.net",
			"Windows Media Audio 9 Voice",
			"Windows Media Audio 9.1 Professional",
			"None (PCM)",
		};

        public static IWMEncProfile2 LoadEncodingProfile(WMEncoder encoder, string profileFilePath)
        {
            if (encoder == null)
                throw new ArgumentNullException("encoder", "Invalid WMEncoder parameter.");
        
            WMEncProfile2 profile2 = new WMEncProfile2();
            profile2.LoadFromFile(profileFilePath);

            return (IWMEncProfile2)profile2;
        }

        public static int GetSecondsTilDone(WMEncoder encoder, DateTime startTime)
        {
            int secsleft = -1;

            IWMEncStatistics stats = encoder.Statistics;
            IWMEncSourceGroup grp = encoder.SourceGroupCollection.Item("SG_1");
            IWMEncAudioSource audsrc = (IWMEncAudioSource)grp.get_Source(WMENC_SOURCE_TYPE.WMENC_AUDIO, 0);

            double durationSecs = (double)GetAudioSourceDuration(audsrc) / 1000F;
            double encodingTimeSecs = (double)(stats.EncodingTime * 10);

            double percentDone = encodingTimeSecs / durationSecs;

            TimeSpan ts = DateTime.UtcNow.Subtract(startTime);

            double estimatedTime = (ts.TotalSeconds / percentDone);

            secsleft = (int)(estimatedTime - ts.TotalSeconds);

            if (secsleft < 0)
                secsleft = -1;

            Logger.WriteLogMessage("Duration: " + durationSecs.ToString("G4") + " seconds, encoding source elapsed time: " + encodingTimeSecs.ToString("G4") + " seconds.");
            Logger.WriteLogMessage("Percent done: " + String.Format("{0:P}", percentDone) + ", encoding time left: " + secsleft + " seconds, estimated encoding time: " + estimatedTime.ToString("G4") + " seconds, elapsed time: " + ts.TotalSeconds.ToString("G4") + " seconds.");

            return secsleft;
        }

        private static int GetAudioSourceDuration(IWMEncAudioSource audsrc)
        {
            int clipduration = audsrc.MarkOut - audsrc.MarkIn;

            if (clipduration == 0)
                return audsrc.Duration;
            else
                return clipduration;
        }

//        private static void ConfigureAudioProfile(IWMEncProfile2 encProfile, IWMEncAudienceObj aud, WmaStreamSettings audStream)
//        {
//            Logger.WriteLogMessage("Using audio VBR mode [" + audStream.VbrMode + "], bitrate [" + audStream.Bitrate + "], peak bitrate [" + audStream.PeakBitrate + "].");
//
//            switch (audStream.VbrMode)
//            {
//                case TranscoderSettingsBase.VbrModes.BitrateVBR:
//                    encProfile.set_VBRMode(WMENC_SOURCE_TYPE.WMENC_AUDIO, 0, WMENC_PROFILE_VBR_MODE.WMENC_PVM_BITRATE_BASED);
//                    break;
//                case TranscoderSettingsBase.VbrModes.BitrateVBRPeak:
//                    encProfile.set_VBRMode(WMENC_SOURCE_TYPE.WMENC_AUDIO, 0, WMENC_PROFILE_VBR_MODE.WMENC_PVM_PEAK);
//                    aud.set_AudioPeakBitrate(0, audStream.PeakBitrate ?? audStream.Bitrate);
//                    break;
//                case TranscoderSettingsBase.VbrModes.QualityVBR:
//                    encProfile.set_VBRMode(WMENC_SOURCE_TYPE.WMENC_AUDIO, 0, WMENC_PROFILE_VBR_MODE.WMENC_PVM_UNCONSTRAINED);
//                    break;
//                case TranscoderSettingsBase.VbrModes.CBR:
//                    encProfile.set_VBRMode(WMENC_SOURCE_TYPE.WMENC_AUDIO, 0, WMENC_PROFILE_VBR_MODE.WMENC_PVM_NONE);
//                    break;
//            }
//
//            int codec = -1;
//            object codecName;
//            int fourCC;
//
//            Logger.WriteLogMessage("Attempting to enumerate audio codec [" + audStream.CodecName + "].");
//
//            for (int i = 0; i < encProfile.AudioCodecCount; i++)
//            {
//                fourCC = encProfile.EnumAudioCodec(i, out codecName);
//
//                if (audStream.CodecName == (string)codecName)
//                {
//                    codec = i;
//                    break;
//                }
//            }
//
//            if (codec < 0)
//                throw new Common.InvalidOperationException("Failed to locate audio codec [" + audStream.CodecName + "].");
//
//            Logger.WriteLogMessage("Using audio codec [" + audStream.CodecName + "], index [" + codec + "].");
//
//            aud.set_AudioCodec(0, codec);
//
//            Logger.WriteLogMessage("Using audio sample rate [" + audStream.SampleRate + "], channels [" + audStream.Channels + "], bits per sample [" + audStream.BitsPerSample + "], .");
//
//            aud.SetAudioConfig(0, (short)audStream.Channels, (int)audStream.SampleRate, audStream.Bitrate, (short)audStream.BitsPerSample);
//
//            Logger.WriteLogMessage("Configured audio profile.");
//        }

        public static void ReleaseEncoder(ref WMEncoder encoder)
		{
			if (encoder == null)
				return;

			try
			{
				Logger.WriteLogMessage("Attempting to stop WMEncoder application, state: " + encoder.RunState + ".");

				if (encoder.RunState != WMENC_ENCODER_STATE.WMENC_ENCODER_STOPPED)
					encoder.Stop();

				encoder.Reset();

				Logger.WriteLogMessage("Successfully stopped WMEncoder application, state: " + encoder.RunState + ".");
			}
			catch (COMException e)
			{
				Logger.WriteLogError("Failed to kill WMEncoder application. HRESULT [" + String.Format("0x{0:x}", e.ErrorCode) + "].", e);
			}
			catch (Exception e)
			{
				Logger.WriteLogError("Failed to kill WMEncoder application.", e);
			}
			finally
			{
				Logger.WriteLogMessage("Releasing runtime callable wrapper.");

				while (Marshal.ReleaseComObject(encoder) > 0)
				{
					Logger.WriteLogMessage("Releasing runtime callable wrapper again.");
				}

				encoder = null;

				Logger.WriteLogMessage("Successfully killed WMEncoder application.");
			}
		}
    }
}

