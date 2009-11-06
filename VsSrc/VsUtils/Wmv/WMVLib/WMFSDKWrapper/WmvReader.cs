using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Vs.Encoder.WmvLib.WMFSDKWrapper;
//#define DEBUG_SAMPLES
//#define DEBUG_BITMAP_TEXT
//#define DEBUG_BITMAP_IMAGE

#region Using directives



#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
    public abstract class WmvBase : Helpers.DisposableBase
    {

        public string GetMediaTypeName(Guid mediatype)
        {
               return mediatype.ToString();
        }

        public string GetFormatTypeName(Guid formattype)
        {
                return formattype.ToString();
        }

        public string GetSubTypeName(Guid subtype)
        {
                return subtype.ToString();
        }
    }

    public sealed class WmvReader : WmvBase
    {
        private uint _readerStreamCount = 0;
        public uint ReaderStreamCount
        {
            get
            {
                return _readerStreamCount;
            }
        }

        private uint _readerOutputCount = 0;
        public uint ReaderOutputCount
        {
            get
            {
                return _readerOutputCount;
            }
        }

        private IWMSyncReader _reader = null;
        public IWMSyncReader Reader
        {
            get
            {
                return _reader;
            }
        }

        public WmvReader()
        {
            _reader = Helpers.CreateSyncReader(WMT_RIGHTS.WMT_RIGHT_NO_DRM);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_reader != null)
                    {
                        try
                        {
                            _reader.Close();

                            Logger.WriteLogMessage("Disposed IWMSyncReader.");
                        }
                        catch (Exception)
                        {
                            //
                            // eat exception
                            //
                        }

                        _reader = null;
                    }

                    Logger.WriteLogMessage("Completed dispose.");
                }
            }

            base.Dispose(disposing);
        }

        public void Open(string filePath)
        {
            Open(filePath, TimeSpan.Zero, TimeSpan.Zero);
        }

        public void Open(string filePath, TimeSpan startTime, TimeSpan duration)
        {
            if (Utility.IsEmptyString(filePath))
                throw new ArgumentNullException("inputFilePath", "Invalid string parameter.");

            _reader.Open(filePath);

            Logger.WriteLogMessage("Opened file [" + filePath + "] for reading.");

            WMHeaderInfo readerHeaderInfo = new WMHeaderInfo((IWMHeaderInfo)_reader);

            WM_ATTR attr = readerHeaderInfo.GetAttribute(Constants.g_wszWMDuration);
            TimeSpan readerDuration = new TimeSpan((long)(ulong)attr.Value);

            Logger.WriteLogMessage("Found input duration [" + readerDuration + "].");

            if (startTime != TimeSpan.Zero)
            {
                //
                // startTime, duration are in 100-nsec ticks
                //
                _reader.SetRange((ulong)startTime.Ticks, duration.Ticks); // seek

                Logger.WriteLogMessage("Set range on reader, startTime [" + startTime + "], duration [" + duration + "].");
            }

            _reader.GetOutputCount(out _readerOutputCount);

            Logger.WriteLogMessage("Found " + _readerOutputCount + " reader outputs.");

            IWMProfile readerProfile = (IWMProfile)_reader;

            readerProfile.GetStreamCount(out _readerStreamCount);
        }

        public bool FindVideoInfo(ref WM_MEDIA_TYPE mediaType, ref VideoInfoHeader videoInfoHeader)
        {
            bool success = false;
            IWMStreamConfig stream = null;
            IWMMediaProps props = null;
            Guid mediaTypeGuid;

            IWMProfile profile = (IWMProfile)_reader;

            for (uint i = 0; i < _readerStreamCount; i++)
            {
                profile.GetStream(i, out stream);

                props = (IWMMediaProps)stream;

                WMMediaProps mediaProps = new WMMediaProps(props);

                mediaType = mediaProps.MediaType;
                mediaTypeGuid = mediaType.majortype;

                if (mediaTypeGuid == MediaTypes.WMMEDIATYPE_Video)
                {
                    Logger.WriteLogMessage("Found video stream [" + i + "], format type [" + mediaType.formattype + "].");

                    videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.pbFormat, typeof(VideoInfoHeader));
                    success = true;
                    break;
                }
            }

            return success;
        }

        public bool FindAudioInfo(ref WM_MEDIA_TYPE mediaType, ref WaveFormat waveFormat)
        {
            bool success = false;
            IWMStreamConfig stream = null;
            IWMMediaProps props = null;
            Guid mediaTypeGuid;

            IWMProfile profile = (IWMProfile)_reader;

            for (uint i = 0; i < _readerStreamCount; i++)
            {
                profile.GetStream(i, out stream);

                props = (IWMMediaProps)stream;

                WMMediaProps mediaProps = new WMMediaProps(props);

                mediaType = mediaProps.MediaType;
                mediaTypeGuid = mediaType.majortype;

                if (mediaTypeGuid == MediaTypes.WMMEDIATYPE_Audio)
                {
                    Logger.WriteLogMessage("Found audio stream [" + i + "], format type [" + mediaType.formattype + "].");

                    waveFormat = (WaveFormat)Marshal.PtrToStructure(mediaType.pbFormat, typeof(WaveFormat));
                    success = true;
                    break;
                }
            }

            return success;
        }
        
        public void FindVideoOutputFormat(uint outputNum, ref WM_MEDIA_TYPE mediaType, ref Guid subtype, ref VideoInfoHeader outputVideoInfoHeader)
        {
            IWMOutputMediaProps readerOutputProps = null;
            uint bufferSize = (uint)(Marshal.SizeOf(typeof(WM_MEDIA_TYPE)) + Marshal.SizeOf(typeof(VideoInfoHeader)));
            uint formatCount;

            Logger.WriteLogMessage("Finding video output formats for reader, output [" + outputNum + "].");

            _reader.GetOutputFormatCount(outputNum, out formatCount);

            Logger.WriteLogMessage("Reader can produce " + formatCount + " possible video output formats.");

            IntPtr buffer = Marshal.AllocCoTaskMem((int)bufferSize);

            try
            {
                for (uint j = 0; j < formatCount; j++)
                {
                    uint size = 0;

                    _reader.GetOutputFormat(outputNum, j, out readerOutputProps);

                    readerOutputProps.GetMediaType(IntPtr.Zero, ref size);

                    if (size > bufferSize)
                    {
                        bufferSize = size;
                        Marshal.FreeCoTaskMem(buffer);
                        buffer = Marshal.AllocCoTaskMem((int)bufferSize);
                    }

                    readerOutputProps.GetMediaType(buffer, ref size);

                    mediaType = (WM_MEDIA_TYPE)Marshal.PtrToStructure(buffer, typeof(WM_MEDIA_TYPE));

                    if (mediaType.formattype == FormatTypes.WMFORMAT_VideoInfo)
                    {
                        Logger.WriteLogMessage("Walking output format [" + j + "], format type [" + GetFormatTypeName(mediaType.formattype) + "], subtype [" + GetSubTypeName(mediaType.subtype) + "], sample size [" + mediaType.lSampleSize + "].");

                        //
                        // NOTE: only look for RGB subtypes
                        //
                        if ((mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB555) ||
                             (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB24) ||
                             (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_RGB32))
                        {
                            Logger.WriteLogMessage("- Found RGB555, RGB24 or RGB32 sub type, grabbing VideoInfoHeader.");

                            subtype = mediaType.subtype;

                            outputVideoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.pbFormat, typeof(VideoInfoHeader));

                            Logger.WriteLogMessage("- width [" + outputVideoInfoHeader.bmiHeader.biWidth + "], height [" + outputVideoInfoHeader.bmiHeader.biHeight + "], dwBitrate [" + outputVideoInfoHeader.dwBitRate + "], dwBitErrorRate [" + outputVideoInfoHeader.dwBitErrorRate + "].");

                            _reader.SetOutputProps(outputNum, readerOutputProps);
                            break;
                        }
                    }
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer);
            }

            Marshal.ReleaseComObject(readerOutputProps);
        }

        public void FindAudioOutputFormat(uint outputNum, ref WM_MEDIA_TYPE mediaType, ref Guid subtype, ref WaveFormat waveFormat)
        {
            IWMOutputMediaProps readerOutputProps = null;
            uint bufferSize = (uint)(Marshal.SizeOf(typeof(WM_MEDIA_TYPE)) + Marshal.SizeOf(typeof(WaveFormat)));
            uint formatCount;

            Logger.WriteLogMessage("Finding audio output formats for reader, output [" + outputNum + "].");

            _reader.GetOutputFormatCount(outputNum, out formatCount);

            Logger.WriteLogMessage("Reader can produce " + formatCount + " possible audio output formats.");

            IntPtr buffer = Marshal.AllocCoTaskMem((int)bufferSize);

            try
            {
                for (uint j = 0; j < formatCount; j++)
                {
                    uint size = 0;

                    _reader.GetOutputFormat(outputNum, j, out readerOutputProps);

                    readerOutputProps.GetMediaType(IntPtr.Zero, ref size);

                    if (size > bufferSize)
                    {
                        bufferSize = size;
                        Marshal.FreeCoTaskMem(buffer);
                        buffer = Marshal.AllocCoTaskMem((int)bufferSize);
                    }

                    readerOutputProps.GetMediaType(buffer, ref size);

                    mediaType = (WM_MEDIA_TYPE)Marshal.PtrToStructure(buffer, typeof(WM_MEDIA_TYPE));

                    if (mediaType.formattype == FormatTypes.WMFORMAT_WaveFormatEx)
                    {
                        Logger.WriteLogMessage("Walking output format [" + j + "], format type [" + GetFormatTypeName(mediaType.formattype) + "], subtype [" + GetSubTypeName(mediaType.subtype) + "], sample size [" + mediaType.lSampleSize + "].");

                        //
                        // NOTE: only look for PCM subtypes
                        //
                        if (mediaType.subtype == MediaSubTypes.WMMEDIASUBTYPE_PCM)
                        {
                            subtype = mediaType.subtype;

                            Logger.WriteLogMessage("- Found PCM sub type, grabbing WaveFormat.");

                            waveFormat = (WaveFormat)Marshal.PtrToStructure(mediaType.pbFormat, typeof(WaveFormat));
                            WaveFormats format = (WaveFormats)waveFormat.wFormatTag;

                            Logger.WriteLogMessage("- format [" + format + "], sample rate [" + waveFormat.nSamplesPerSec + "], bits per sample [" + waveFormat.wBitsPerSample +
                                "], bytes/sec [" + waveFormat.nAvgBytesPerSec + "], channels [" + waveFormat.nChannels + "].");

                            _reader.SetOutputProps(outputNum, readerOutputProps);
                            break;
                        }
                    }
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer);
            }

            Marshal.ReleaseComObject(readerOutputProps);
        }

        public void SetSelectedStreams(uint readerOutputCount, ushort[] readerStreamNumbers, WMT_STREAM_SELECTION[] readerStreamSelections)
        {
            Logger.WriteLogMessage("Selecting [" + readerOutputCount + "] streams on reader.");

            for (uint i = 0; i < readerOutputCount; i++)
            {
                Logger.WriteLogMessage("- stream [" + readerStreamNumbers[i] + "], selection [" + readerStreamSelections[i] + "].");
            }

            //
            // select all streams
            //
            _reader.SetStreamsSelected((ushort)readerOutputCount, readerStreamNumbers, readerStreamSelections);

            Logger.WriteLogMessage("Set selected streams on reader.");
        }

        public Bitmap GetBitmapFromSample(INSSBuffer sample, Guid videoSubType, VideoInfoHeader outputVideoInfoHeader, VideoInfoHeader inputVideoInfoHeader)
        {
            IntPtr sampleBuffer;
        	PixelFormat pixelFormat = PixelFormat.DontCare;
            uint length = 0;

            sample.GetBufferAndLength(out sampleBuffer, out length);

            if (videoSubType == MediaSubTypes.WMMEDIASUBTYPE_RGB32)
            {
                pixelFormat = PixelFormat.Format32bppRgb;
            }
            else if (videoSubType == MediaSubTypes.WMMEDIASUBTYPE_RGB555)
            {
                pixelFormat = PixelFormat.Format16bppRgb555;
            }
            else if (videoSubType == MediaSubTypes.WMMEDIASUBTYPE_RGB24)
            {
                pixelFormat = PixelFormat.Format24bppRgb;
            }
            else
            {
                throw new ArgumentException("videoSubType", "Unsupported video subtype [" + videoSubType + "].");
            }

#if DEBUG && DEBUG_SAMPLES
            Logger.WriteLogMessage("Grabbed sample buffer, length [" + length + "], pixelFormat [" + pixelFormat + "].");
#endif

            uint stride = outputVideoInfoHeader.bmiHeader.biWidth * outputVideoInfoHeader.bmiHeader.biPlanes * outputVideoInfoHeader.bmiHeader.biBitCount / 8;

#if DEBUG && DEBUG_SAMPLES
            Logger.WriteLogMessage("Creating bitmap [" + outputVideoInfoHeader.bmiHeader.biWidth + "x" + outputVideoInfoHeader.bmiHeader.biHeight + "], stride [" + stride + "], pixelFormat [" + pixelFormat + "].");
#endif

            Bitmap outputBitmap = new Bitmap((int)outputVideoInfoHeader.bmiHeader.biWidth, (int)outputVideoInfoHeader.bmiHeader.biHeight, (int)stride, pixelFormat, sampleBuffer);
            Bitmap inputBitmap = new Bitmap((int)inputVideoInfoHeader.bmiHeader.biWidth, (int)inputVideoInfoHeader.bmiHeader.biHeight, outputBitmap.PixelFormat);

            using (Graphics g = Graphics.FromImage(inputBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(outputBitmap, 0, 0, inputBitmap.Width, inputBitmap.Height);

#if DEBUG && DEBUG_SAMPLES
                Logger.WriteLogMessage("Copied output bitmap [" + outputBitmap.Width + "x" + outputBitmap.Height + "] to input bitmap [" + inputBitmap.Width + "x" + inputBitmap.Height + "].");
#endif
            }

            //
            // make bitmap was screen-oriented
            // 
            inputBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            return inputBitmap;
        }
    }
}
