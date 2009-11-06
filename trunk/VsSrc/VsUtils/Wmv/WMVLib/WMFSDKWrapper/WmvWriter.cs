//#define DEBUG_SAMPLES

#region Using directives

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
    public sealed class WmvWriter : WmvBase
    {
        private uint[] _preprocessPasses = null;

        private uint _writerInputCount = 0;
        public uint WriterInputCount
        {
            get
            {
                return _writerInputCount;
            }
        }

        private uint _writerStreamCount = 0;
        public uint WriterStreamCount
        {
            get
            {
                return _writerStreamCount;
            }
        }

        private IWMWriter _writer = null;
        public IWMWriter Writer
        {
            get
            {
                return _writer;
            }
        }

        public bool IsPreprocessingDone
        {
            get
            {
                bool isDone = true;

                for (uint i = 0; i < _writerInputCount; i++)
                {
                    //
                    // if any inputs still have preprocessing passes to go, then break out and say we're not done
                    //
                    if (_preprocessPasses[i] > 0)
                    {
                        isDone = false;
                        break;
                    }
                }

                return isDone;
            }
        }

        public WmvWriter()
        {
            _writer = Helpers.CreateWriter();
        }

        public void Initialize(IWMProfile profile, string filePath)
        {
            if (filePath == null || filePath.Length == 0)
                throw new ArgumentNullException("filePath", "Invalid string parameter.");

            //
            // assign profile to writer
            //
            _writer.SetProfile(profile);

            Logger.WriteLogMessage("Set profile on writer.");

            _writer.SetOutputFilename(filePath);

            Logger.WriteLogMessage("Set output filename [" + filePath + "] for writing.");

            _writer.GetInputCount(out _writerInputCount);

            Logger.WriteLogMessage("Found " + _writerInputCount + " writer inputs.");

            profile.GetStreamCount(out _writerStreamCount);

            Logger.WriteLogMessage("Found " + _writerStreamCount + " writer streams.");
        }

        public void SetProfile(IWMProfile profile)
        {
            //
            // assign profile to writer
            //
            _writer.SetProfile(profile);

            Logger.WriteLogMessage("Set profile on writer.");

            profile.GetStreamCount(out _writerStreamCount);

            Logger.WriteLogMessage("Found " + _writerStreamCount + " writer streams.");
        }

        public void SetFilename(string filePath)
        {
            if (filePath.Length == 0)
                throw new ArgumentNullException("filePath", "Invalid string parameter.");

            _writer.SetOutputFilename(filePath);

            Logger.WriteLogMessage("Set output filename [" + filePath + "] for writing.");

            _writer.GetInputCount(out _writerInputCount);

            Logger.WriteLogMessage("Found " + _writerInputCount + " writer inputs.");
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_writer != null)
                    {
                        try
                        {
                            _writer.EndWriting();

                            Logger.WriteLogMessage("Finished writing to output file.");
                        }
                        catch (COMException)
                        {
                            // error handle
                            throw;

                            //if (e.ErrorCode == Constants.NS_E_INVALID_DATA)
                            //{
                            //    Logger.WriteLogMessage("Received NS_E_INVALID_DATA error from IWMWriter.EndWriting.");
                            //}
                            //else
                            //{
                            //    Logger.WriteLogMessage("Received unknown HRESULT [" + String.Format("0x{0:X}", e.ErrorCode) + "] from IWMWriter.EndWriting.");
                            //}
                        }
                    }

                    Logger.WriteLogMessage("Completed dispose.");
                }
            }

            base.Dispose(disposing);
        }

        public void Start()
        {
            // start writing output file
            //
            try
            {
                _writer.BeginWriting();
            }
            catch (Exception)
            {
                // error handle
                throw;
            }
        }

        public void Stop()
        {
            // stop writing output file
            //
            if (_writer != null)
            {
                try
                {
                    _writer.EndWriting();

                    Logger.WriteLogMessage("Finished writing to output file.");
                }
                catch (COMException)
                {
                    // error handle
                    throw;

                    //if (e.ErrorCode == Constants.NS_E_INVALID_DATA)
                    //{
                        //Logger.WriteLogMessage("Received NS_E_INVALID_DATA error from IWMWriter.EndWriting.");
                    //}
                    //else
                    //{
                        //Logger.WriteLogMessage("Received unknown HRESULT [" + String.Format("0x{0:X}", e.ErrorCode) + "] from IWMWriter.EndWriting.");
                    //}
                }
            }
        }

        public bool FindVideoInputFormat(uint inputNum, Guid subtype, ref VideoInfoHeader inputVideoInfoHeader, bool enableCompressedSamples)
        {
            bool success = false;
            IWMInputMediaProps writerInputProps = null;
            WM_MEDIA_TYPE mediaType;
            uint bufferSize = (uint)(Marshal.SizeOf(typeof(WM_MEDIA_TYPE)) + Marshal.SizeOf(typeof(VideoInfoHeader)));
            uint formatCount;

            Logger.WriteLogMessage("Finding video input formats for writer, input [" + inputNum + "].");

            _writer.GetInputFormatCount(inputNum, out formatCount);

            Logger.WriteLogMessage("Video writer can consume " + formatCount + " possible video input formats.");

            IntPtr buffer = Marshal.AllocCoTaskMem((int)bufferSize);

            try
            {
                for (uint j = 0; j < formatCount; j++)
                {
                    uint size = 0;

                    try
                    {
                        _writer.GetInputFormat(inputNum, j, out writerInputProps);

                        writerInputProps.GetMediaType(IntPtr.Zero, ref size);

                        if (size > bufferSize)
                        {
                            bufferSize = size;
                            Marshal.FreeCoTaskMem(buffer);
                            buffer = Marshal.AllocCoTaskMem((int)bufferSize);
                        }

                        writerInputProps.GetMediaType(buffer, ref size);

                        mediaType = (WM_MEDIA_TYPE)Marshal.PtrToStructure(buffer, typeof(WM_MEDIA_TYPE));

                        if (mediaType.formattype == FormatTypes.WMFORMAT_VideoInfo)
                        {
                            Logger.WriteLogMessage("Found video writer input format [" + j + "], format type [" + GetFormatTypeName(mediaType.formattype) + "], subtype [" + GetSubTypeName(mediaType.subtype) + "], sample size [" + mediaType.lSampleSize + "].");

                            inputVideoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.pbFormat, typeof(VideoInfoHeader));

                            Logger.WriteLogMessage("Found input video stream, width [" + inputVideoInfoHeader.bmiHeader.biWidth + "], height [" + inputVideoInfoHeader.bmiHeader.biHeight + "], bit count [" + inputVideoInfoHeader.bmiHeader.biBitCount + "], image size [" + inputVideoInfoHeader.bmiHeader.biSizeImage + "].");

                            if (mediaType.subtype == subtype)
                            {
                                writerInputProps.SetMediaType(ref mediaType);

                                if (!enableCompressedSamples)
                                    _writer.SetInputProps(inputNum, writerInputProps);
                                else
                                    _writer.SetInputProps(inputNum, null);

                                success = true;
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // error handle
                        throw;
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(writerInputProps);
                        writerInputProps = null;
                    }
                }
            }
            catch (Exception)
            {
                // error handle
                throw;
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer);
            }

            return success;
        }

        public bool FindAudioInputFormat(uint inputNum, Guid subtype, WaveFormat readerWaveFormat)
        {
            bool success = false;
            IWMInputMediaProps writerInputProps = null;
            WM_MEDIA_TYPE mediaType;
            uint bufferSize = (uint)(Marshal.SizeOf(typeof(WM_MEDIA_TYPE)) + Marshal.SizeOf(typeof(WaveFormat)));
            uint formatCount;

            Logger.WriteLogMessage("Finding audio input formats for writer, input [" + inputNum + "].");

            _writer.GetInputFormatCount(inputNum, out formatCount);

            Logger.WriteLogMessage("Audio writer can consume " + formatCount + " possible audio input formats.");

            IntPtr buffer = Marshal.AllocCoTaskMem((int)bufferSize);

            try
            {
                for (uint j = 0; j < formatCount; j++)
                {
                    uint size = 0;

                    try
                    {
                        _writer.GetInputFormat(inputNum, j, out writerInputProps);

                        writerInputProps.GetMediaType(IntPtr.Zero, ref size);

                        if (size > bufferSize)
                        {
                            bufferSize = size;
                            Marshal.FreeCoTaskMem(buffer);
                            buffer = Marshal.AllocCoTaskMem((int)bufferSize);
                        }

                        writerInputProps.GetMediaType(buffer, ref size);

                        mediaType = (WM_MEDIA_TYPE)Marshal.PtrToStructure(buffer, typeof(WM_MEDIA_TYPE));

                        if (mediaType.formattype == FormatTypes.WMFORMAT_WaveFormatEx)
                        {
                            Logger.WriteLogMessage("Found writer audio input format [" + j + "], format type [" + GetFormatTypeName(mediaType.formattype) + "], subtype [" + GetSubTypeName(mediaType.subtype) + "], sample size [" + mediaType.lSampleSize + "].");

                            WaveFormat waveFormat = (WaveFormat)Marshal.PtrToStructure(mediaType.pbFormat, typeof(WaveFormat));
                            WaveFormats format = (WaveFormats)waveFormat.wFormatTag;

                            Logger.WriteLogMessage("Found audio stream, format [" + format + "], sample rate [" + waveFormat.nSamplesPerSec + "], bits per sample [" + waveFormat.wBitsPerSample +
                                "], bytes/sec [" + waveFormat.nAvgBytesPerSec + "], channels [" + waveFormat.nChannels + "].");

                            if (waveFormat.nSamplesPerSec == readerWaveFormat.nSamplesPerSec &&
                                waveFormat.nChannels == readerWaveFormat.nChannels &&
                                waveFormat.wBitsPerSample == readerWaveFormat.wBitsPerSample &&
                                waveFormat.wFormatTag == readerWaveFormat.wFormatTag)
                            {
                                writerInputProps.SetMediaType(ref mediaType);

                                _writer.SetInputProps(inputNum, writerInputProps);
                                success = true;
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // error handle
                        throw;
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(writerInputProps);
                        writerInputProps = null;
                    }
                }
            }
            catch (Exception)
            {
                // error handle
                throw;
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffer);
            }

            return success;
        }

        public INSSBuffer GetSampleFromBitmap(Bitmap bitmap)
        {
            INSSBuffer sample = null;
            IntPtr sampleBuffer;
            uint length = 0;

#if DEBUG && DEBUG_SAMPLES
            Logger.WriteLogMessage("Grabbing sample from bitmap.");
#endif

        	BitmapData bitmapData = null;
            uint actualLength = 0;

            try
            {
                //
                // assume incoming bitmap was screen-oriented
                // 
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

                length = (uint)(bitmapData.Height * bitmapData.Stride);

#if DEBUG && DEBUG_SAMPLES
                Logger.WriteLogMessage("Locked bits on bitmap, rect [" + rect + "], length [" + length + "], width [" + bitmapData.Width + "], height [" + bitmapData.Height + "], stride [" + bitmapData.Stride + "], pixelFormat [" + bitmap.PixelFormat + "].");
#endif

#if DEBUG_BITMAP_IMAGE
         //       SaveBitmapAsImage(bitmap, bitmapData);
#endif

                //
                // allocate new sample and grab sample buffer
                //
                _writer.AllocateSample(length, out sample);

#if DEBUG && DEBUG_SAMPLES
                Logger.WriteLogMessage("Allocated sample, [" + length + "] bytes.");
#endif

                sample.GetBufferAndLength(out sampleBuffer, out actualLength);

#if DEBUG && DEBUG_SAMPLES
                Logger.WriteLogMessage("Grabbed buffer from sample, [" + actualLength + "] bytes.");
#endif

                Helpers.CopyMemory(sampleBuffer, bitmapData.Scan0, length);

#if DEBUG && DEBUG_SAMPLES
                Logger.WriteLogMessage("Copied [" + length + "] bytes from bitmap to sample buffer.");
#endif
            }
            catch (Exception)
            {
                // error handle
                throw;
                //Logger.WriteLogError("Failed converting bitmap to sample.", e);
            }
            finally
            {
                if (bitmapData != null)
                {
                    bitmap.UnlockBits(bitmapData);

#if DEBUG && DEBUG_SAMPLES
                    Logger.WriteLogMessage("Unlocked bits on bitmap.");
#endif
                }
            }

            return sample;
        }

        public void InitializePreprocess()
        {
            //
            // allocate preprocess passes
            //
            _preprocessPasses = new uint[_writerInputCount];

            for (uint i = 0; i < _writerInputCount; i++)
            {
                _preprocessPasses[i] = 0;

                SetPreprocessingPasses(i);
            }
        }

        public void SetPreprocessingPasses(uint inputNum)
        {
            IWMWriterPreprocess writerPreprocess = (IWMWriterPreprocess)_writer;

            writerPreprocess.GetMaxPreprocessingPasses(inputNum, 0, out _preprocessPasses[inputNum]);

            //
            // NOTE: if this value is 1, the codec supports two-pass encoding; the final pass is not counted
            //
            Logger.WriteLogMessage("Found [" + _preprocessPasses[inputNum] + "] preprocessing passes for writer input [" + inputNum + "].");

            if (_preprocessPasses[inputNum] != 0)
            {
                writerPreprocess.SetNumPreprocessingPasses(inputNum, 0, _preprocessPasses[inputNum]);

                writerPreprocess.BeginPreprocessingPass(inputNum, 0);

                Logger.WriteLogMessage("Began preprocessing pass, writer input [" + inputNum + "].");
            }
        }

        public void Preprocess()
        {
        }

        public void FinishPreprocessPass()
        {
            IWMWriterPreprocess writerPreprocess = (IWMWriterPreprocess)_writer;

            for (uint i = 0; i < _writerInputCount; i++)
            {
                if (_preprocessPasses[i] > 0)
                {
                    _preprocessPasses[i]--;

                    Logger.WriteLogMessage("Decremented preprocessing passes [" + _preprocessPasses[i] + "], writer input [" + i + "].");

                    if (_preprocessPasses[i] == 0)
                    {
                        writerPreprocess.EndPreprocessingPass(i, 0);

                        Logger.WriteLogMessage("Ended preprocessing pass, writer input [" + i + "].");
                    }
                }
            }
        }

        public bool NeedsPreprocessing(uint inputNum)
        {
            return (_preprocessPasses[inputNum] > 0);
        }
    }
}
