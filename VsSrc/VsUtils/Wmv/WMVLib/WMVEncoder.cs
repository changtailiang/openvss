using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using WMEncoderLib;
using Vs.Encoder.WmvLib.WMFSDKWrapper;

namespace Vs.Encoder.WmvLib
{
	public class WmvEncoder : IDisposable
	{
        WmvWriter writer = null;
        VideoInfoHeader viHeader;
        INSSBuffer sample = null;
        int bmcount = 0;
        Bitmap frame = null;
        ulong fps;
       
		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="framesPerSecond">Frames per second.</param>
		/// <param name="bitmaps">Bitmaps.</param>
        public WmvEncoder(string profileFileName, ulong framesPerSecond)
        {
            try
            {
                WMEncoder encoder = new WMEncoder();
                IWMEncProfile2 profile = WMEncProfile.LoadEncodingProfile(encoder, profileFileName);
                WMEncProfile.ReleaseEncoder(ref encoder);

                writer = new WmvWriter();
                writer.SetProfile((IWMProfile)profile.SaveToIWMProfile());

                viHeader = new VideoInfoHeader();
                bool bret = writer.FindVideoInputFormat(0, MediaSubTypes.WMMEDIASUBTYPE_RGB24, ref viHeader, false);
                if (!bret) throw new Exception("FindVideoInputFormat error"); ;
                frame = new Bitmap((int)viHeader.bmiHeader.biWidth, (int)viHeader.bmiHeader.biHeight, PixelFormat.Format24bppRgb);

                fps = framesPerSecond;
            }
            catch (Exception)
            {
                // error handle
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Dispose();
                        writer = null;
                        frame.Dispose();
                        frame = null;
                        Marshal.FreeHGlobal(MarshalToPointer(viHeader));
                    }
                    catch (Exception)
                    {
                        // error handle
                        throw;
                    }
                }
            }
        }

        // change video input
        public void StartRecord(string fileName)
        {
            try
            {
                writer.SetFilename(fileName);
                writer.Start();
                bmcount = 0;
            }
            catch (Exception)
            {
                // error handle
                throw;
            }
        }

        // recording
        public void DoRecord(Bitmap bitmap)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(frame))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(bitmap, 0, 0, frame.Width, frame.Height);
                }

                ulong time = ((ulong)bmcount++ * TimeSpan.TicksPerSecond) / fps;
                sample = writer.GetSampleFromBitmap(frame);
                writer.Writer.WriteSample(0, time, (uint)WMT_STREAM_SAMPLE_TYPE.WM_SF_CLEANPOINT, sample);

			    Marshal.ReleaseComObject(sample);
			    sample = null;
            }
            catch (Exception)
            {
                // error handle
                throw;
            }
        }

        // stop recording
        public void StopRecord()
        {
            if (writer != null)
            {
                try
                {
                    writer.Stop();
                }
                catch (Exception)
                {
                    // error handle
                    throw;
                }
            }
        }

        private IntPtr MarshalToPointer(object str)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(str));
            Marshal.StructureToPtr(str, ptr, false);
            return ptr;
        }
	}
}