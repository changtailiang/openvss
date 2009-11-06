#define DEBUG_SAMPLES

#region Using directives

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public  class Logger
	{
		public static void WriteLogMessage(string s)
		{
			Trace.WriteLine(s);
		}

		public static void WriteLogError(string s, Exception e)
		{
			Trace.WriteLine(s);
			Trace.WriteLine(e.Message);

		}
	}
	public class Utility
	{
		public static bool IsEmptyString(string path)
		{
			return path == null || path.Length == 0;
		}
	}

	public class Helpers
	{
		[DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
		public static extern int CopyMemory(IntPtr lpvDest, IntPtr lpvSrc, uint cbCopy);


		static Helpers()
		{
		}

		private static IWMProfileManager _profileManager = null;
		public static IWMProfileManager ProfileManager
		{
			get
			{
				lock (typeof(Helpers))
				{
					if (_profileManager == null)
					{
						_profileManager = CreateProfileManager();

						IWMProfileManager2 pm2 = (IWMProfileManager2)_profileManager;

						pm2.SetSystemProfileVersion(WMT_VERSION.WMT_VER_9_0);

						Logger.WriteLogMessage("Created WMProfileManager.");
					}
				}

				return _profileManager;
			}
		}

		public static IWMReader CreateReader(WMT_RIGHTS rights)
		{
			IWMReader res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateReader(IntPtr.Zero, rights, out res));
			return res;
		}

		public static IWMSyncReader CreateSyncReader(WMT_RIGHTS rights)
		{
			IWMSyncReader res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateSyncReader(IntPtr.Zero, rights, out res));
			return res;
		}

		public static IWMProfileManager CreateProfileManager()
		{
			IWMProfileManager res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateProfileManager(out res));
			return res;
		}

		public static IWMMetadataEditor CreateEditor()
		{
			IWMMetadataEditor res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateEditor(out res));
			return res;
		}

		public static IWMIndexer CreateIndexer()
		{
			IWMIndexer res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateIndexer(out res));
			return res;
		}

		public static IWMWriter CreateWriter()
		{
			IWMWriter res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateWriter(IntPtr.Zero, out res));
			return res;
		}

		public static IWMWriterFileSink CreateWriterFileSink()
		{
			IWMWriterFileSink res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateWriterFileSink(out res));
			return res;
		}

		public static IWMWriterNetworkSink CreateWriterNetworkSink()
		{
			IWMWriterNetworkSink res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateWriterNetworkSink(out res));
			return res;
		}

		public static IWMWriterPushSink CreateWriterPushSink()
		{
			IWMWriterPushSink res = null;
			Marshal.ThrowExceptionForHR(Functions.WMCreateWriterPushSink(out res));
			return res;
		}

		//		public static void SaveWmvImage(string wmvFilePath, TimeSpan imageTime, string imageFilePath, ImageFormat imageFormat)
		//		{
		//			uint bufferSize = (uint)(Marshal.SizeOf(typeof(WM_MEDIA_TYPE)) + Marshal.SizeOf(typeof(VideoInfoHeader)));
		//			IWMSyncReader reader = null;
		//			uint videoOutput = uint.MaxValue;
		//			uint videoStream = uint.MaxValue;
		//			uint outputCount = 0;
		//			WM_MEDIA_TYPE mediaType = new WM_MEDIA_TYPE();
		//			VideoInfoHeader infoHeader = new VideoInfoHeader();
		//
		//			reader = Helpers.CreateSyncReader(WMT_RIGHTS.WMT_RIGHT_NO_DRM);
		//			reader.Open(wmvFilePath);
		//
		//			Logger.WriteLogMessage("Opened file [" + wmvFilePath + "] for reading.");
		//
		//			reader.GetOutputCount(out outputCount);
		//
		//			ushort[] streamNumbers = new ushort[outputCount];
		//
		//			WMT_STREAM_SELECTION[] streamSelections = new WMT_STREAM_SELECTION[outputCount];
		//			IWMOutputMediaProps props = null;
		//			Guid mediaTypeGuid;
		//			ushort streamNumber;
		//			uint formatCount;
		//
		//			//
		//			// Look for the video stream within the ASF file
		//			//
		//			for (uint i = 0; i < outputCount; i++)
		//			{
		//				Logger.WriteLogMessage("Getting IWMOutputMediaProps for stream [" + i + "].");
		//
		//				reader.GetOutputProps(i, out props);
		//
		//				reader.GetStreamNumberForOutput(i, out streamNumber);
		//
		//				streamNumbers[i] = streamNumber;
		//				streamSelections[i] = WMT_STREAM_SELECTION.WMT_OFF;
		//
		//				props.GetType(out mediaTypeGuid);
		//
		//				if (mediaTypeGuid == MediaTypes.WMMEDIATYPE_Video)
		//				{
		//					videoOutput = i;
		//					streamSelections[i] = WMT_STREAM_SELECTION.WMT_ON;
		//
		//					Logger.WriteLogMessage("Stream [" + i + "], video stream.");
		//
		//					reader.GetOutputFormatCount(i, out formatCount);
		//
		//					IntPtr buffer = Marshal.AllocCoTaskMem((int)bufferSize);
		//
		//					try
		//					{
		//						//
		//						// Look for the first uncompressed RGB output format
		//						//
		//						for (uint j = 0; j < formatCount; j++)
		//						{
		//							uint size = 0;
		//
		//							reader.GetOutputFormat(i, j, out props);
		//
		//							props.GetMediaType(IntPtr.Zero, ref size);
		//
		//							if (size > bufferSize)
		//							{
		//								bufferSize = size;
		//								Marshal.FreeCoTaskMem(buffer);
		//								buffer = Marshal.AllocCoTaskMem((int)bufferSize);
		//							}
		//
		//							props.GetMediaType(buffer, ref size);
		//
		//							mediaType = (WM_MEDIA_TYPE)Marshal.PtrToStructure(buffer, typeof(WM_MEDIA_TYPE));
		//
		//							if (mediaType.formattype == Formats.WMFORMAT_VideoInfo)
		//							{
		//								Logger.WriteLogMessage("Found VideoInfo format type.");
		//
		//								if ((mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB555) ||
		//									 (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB24) ||
		//									 (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB32))
		//								{
		//									Logger.WriteLogMessage("Found RGB555, RGB24 or RGB32 sub type, grabbing VideoInfoHeader.");
		//
		//									videoStream = streamNumber;
		//									infoHeader = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.pbFormat, typeof(VideoInfoHeader));
		//
		//									reader.SetOutputProps(i, props);
		//									break;
		//								}
		//							}
		//						}
		//					}
		//					finally
		//					{
		//						Marshal.FreeCoTaskMem(buffer);
		//					}
		//				}
		//			}
		//
		//			if (videoOutput == uint.MaxValue)
		//				throw new InvalidOperationException("No video stream found in file [" + wmvFilePath + "].");
		//
		//			if (videoStream == uint.MaxValue)
		//				throw new InvalidOperationException("No valid uncompressed video format found in file [" + wmvFilePath + "].");
		//
		//			INSSBuffer sample = null;
		//			IntPtr sampleBuffer;
		//			ulong sampleTime, duration;
		//			uint flags, outputNum;
		//			ushort streamNum;
		//			PixelFormat pixelFormat = PixelFormat.DontCare;
		//
		//			Logger.WriteLogMessage("Saving video sample to image [" + imageFilePath + "].");
		//
		//			reader.SetStreamsSelected((ushort)outputCount, streamNumbers, streamSelections);
		//
		//			reader.SetRange((ulong)imageTime.Ticks, 0);
		//
		//			reader.GetNextSample((ushort)videoStream, out sample, out sampleTime, out duration, out flags, out outputNum, out streamNum);
		//
		//			Logger.WriteLogMessage("Grabbed next video sample, sampleTime [" + sampleTime + "], duration [" + duration + "], flags [" + flags + "], outputNum [" + outputNum + "], streamNum [" + streamNum + "].");
		//
		//			//
		//			// Use GetBufferAndLength instead if you want to do aditional error check
		//			//
		//			sample.GetBuffer(out sampleBuffer);
		//
		//			if (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB555)
		//			{
		//				pixelFormat = PixelFormat.Format16bppRgb555;
		//			}
		//			else if (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB24)
		//			{
		//				pixelFormat = PixelFormat.Format24bppRgb;
		//			}
		//			else if (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB32)
		//			{
		//				pixelFormat = PixelFormat.Format32bppRgb;
		//			}
		//
		//			Logger.WriteLogMessage("Grabbed sample buffer, pixelFormat [" + pixelFormat + "].");
		//
		//			uint stride = infoHeader.bmiHeader.biWidth * infoHeader.bmiHeader.biPlanes * infoHeader.bmiHeader.biBitCount / 8;
		//
		//			using (Bitmap bitmap = new Bitmap((int)infoHeader.bmiHeader.biWidth, (int)infoHeader.bmiHeader.biHeight, (int)stride, pixelFormat, sampleBuffer))
		//			{
		//				Logger.WriteLogMessage("Created bitmap, width [" + bitmap.Width + "], height [" + bitmap.Height + "].");
		//
		//				bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
		//
		//				bitmap.Save(imageFilePath, imageFormat);
		//
		//				Logger.WriteLogMessage("Saved bitmap as image [" + imageFilePath + "], imageFormat [" + imageFormat + "].");
		//			}
		//		}

		public static void CopyWmv(string inputFilePath, string outputFilePath)
		{
			CopyWmv(inputFilePath, outputFilePath, 0, 0);
		}

		public static void CopyWmv(string inputFilePath, string outputFilePath, ulong startTime, long duration)
		{
			IWMWriterAdvanced writerAdvanced = null;
			IWMProfile profile = null;
			IWMStreamConfig streamConfig = null;
			uint streamCount = 0;
			uint inputCount = 0;
			ushort[] streamNumbers = null;
			WMT_STREAM_SELECTION[] streamSelections = null;
			ulong sampleTime, sampleDuration;
			uint flags, outputNum;
			ushort streamNum;
			INSSBuffer sample = null;

			IWMSyncReader reader = Helpers.CreateSyncReader(WMT_RIGHTS.WMT_RIGHT_NO_DRM);
			IWMWriter writer = Helpers.CreateWriter();

			try
			{
				reader.Open(inputFilePath);

				Logger.WriteLogMessage("Opened file [" + inputFilePath + "] for reading.");

				profile = (IWMProfile)reader;

				profile.GetStreamCount(out streamCount);

				streamNumbers = new ushort[streamCount];

				streamSelections = new WMT_STREAM_SELECTION[streamCount];

				for (uint i = 0; i < streamCount; i++)
				{
					profile.GetStream(i, out streamConfig);

					streamConfig.GetStreamNumber(out streamNumbers[i]);

					streamSelections[i] = WMT_STREAM_SELECTION.WMT_ON;

					//
					// Read compressed samples
					//
					reader.SetReadStreamSamples(streamNumbers[i], true);
				}

				//
				// select all streams
				//
				reader.SetStreamsSelected((ushort)streamCount, streamNumbers, streamSelections);

				writer.SetProfile(profile);

				writer.GetInputCount(out inputCount);

				for (uint i = 0; i < inputCount; i++)
				{
					writer.SetInputProps(i, null); // write compressed samples
				}

				writer.SetOutputFilename(outputFilePath);

				Logger.WriteLogMessage("Set output filename [" + outputFilePath + "] for writing.");

				writerAdvanced = (IWMWriterAdvanced)writer;

				// Copy attributes avoided
				// Copy Codec Info avoided
				// Copy all scripts in the header avoided

				writer.BeginWriting();

				//
				// startTime, duration are in 100-nsec ticks
				//
				reader.SetRange(startTime, duration); // seek

				Logger.WriteLogMessage("Set range on reader, startTime [" + startTime + "], duration [" + duration + "].");

				for (uint streamsRead = 0; streamsRead < streamCount; )
				{
					try
					{
						streamNum = 0;

						reader.GetNextSample(0, out sample, out sampleTime, out sampleDuration, out flags, out outputNum, out streamNum);

						Logger.WriteLogMessage("Grabbed next video sample, sampleTime [" + sampleTime + "], duration [" + sampleDuration + "], flags [" + flags + "], outputNum [" + outputNum + "], streamNum [" + streamNum + "].");

						writerAdvanced.WriteStreamSample(streamNum, sampleTime, 0, sampleDuration, flags, sample);

						Logger.WriteLogMessage("Wrote sample, sampleTime [" + sampleTime + "], duration [" + sampleDuration + "], flags [" + flags + "], outputNum [" + outputNum + "], streamNum [" + streamNum + "].");
					}
					catch (COMException e)
					{
						if (e.ErrorCode == Constants.NS_E_NO_MORE_SAMPLES)
							streamsRead++;
						else
							throw;
					}
				}

				writer.EndWriting();
			}
			finally
			{
				reader.Close();
			}
		}


		public abstract class DisposableBase : IDisposable
		{
			public DisposableBase()
			{
			}
			protected bool _disposed = false;

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				/*
				if (!_disposed)
				{
					if (disposing)
					{
					}
				}
				*/
			}
		}
	}
}
