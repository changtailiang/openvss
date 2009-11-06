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
	public class WMVService
	{
		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="dr">Dr.</param>
		public static void SaveVideo(string fileName, string profileFileName, SqlDataReader dr)
		{
			SaveVideo(fileName, profileFileName, (ulong) WMEncProfile.DEFAULT_FRAME_RATE, dr);
		}

		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="dr">Dr.</param>
		public static void SaveVideo(string fileName, string profileFileName, ulong framesPerSecond, SqlDataReader dr)
		{
			WMEncoder encoder = new WMEncoder();
			IWMEncProfile2 profile = WMEncProfile.LoadEncodingProfile(encoder, profileFileName);
			WMEncProfile.ReleaseEncoder(ref encoder);
			
			using(WmvWriter writer = new WmvWriter())
			{
				
				writer.Initialize((IWMProfile)profile.SaveToIWMProfile(), fileName);
				
				VideoInfoHeader viHeader = new VideoInfoHeader();
				writer.FindVideoInputFormat(0, MediaSubTypes.WMMEDIASUBTYPE_RGB24, ref viHeader, false);
				writer.Start();

				
				INSSBuffer sample = null;
				int bmcount = 0;
				Bitmap c = new Bitmap((int)viHeader.bmiHeader.biWidth, (int)viHeader.bmiHeader.biHeight, PixelFormat.Format24bppRgb);;
				ulong fps = viHeader.AvgTimePerFrame / 100000;

				while(dr.Read())
				{
					Bitmap b = Image.FromStream(new MemoryStream(dr.GetValue(1) as byte[])) as Bitmap;
					
					using (Graphics g = Graphics.FromImage(c))
					{
						g.InterpolationMode = InterpolationMode.HighQualityBicubic;
						g.CompositingQuality = CompositingQuality.HighQuality;
						g.SmoothingMode = SmoothingMode.HighQuality;
						g.PixelOffsetMode = PixelOffsetMode.HighQuality;
						g.DrawImage(b, 0, 0, c.Width, c.Height);
					}

					try
					{	
						ulong time = ((ulong)bmcount++ * TimeSpan.TicksPerSecond)/fps;
						sample = writer.GetSampleFromBitmap(c);
						writer.Writer.WriteSample(0, time, (uint)WMT_STREAM_SAMPLE_TYPE.WM_SF_CLEANPOINT, sample);
					}
					finally
					{
						Marshal.ReleaseComObject(sample);
						sample = null;
						b = null;
						GC.Collect();
					}
				}
			}
		}

		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="files">Files.</param>
		public static void SaveVideo(string fileName, string profileFileName, string [] files)
		{
			SaveVideo(fileName, profileFileName, (ulong) WMEncProfile.DEFAULT_FRAME_RATE, files);
		}

		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="files">Files.</param>
		public static void SaveVideo(string fileName, string profileFileName, ulong framesPerSecond, string [] files)
		{
			WMEncoder encoder = new WMEncoder();
			IWMEncProfile2 profile = WMEncProfile.LoadEncodingProfile(encoder, profileFileName);
			WMEncProfile.ReleaseEncoder(ref encoder);
			
			using(WmvWriter writer = new WmvWriter())
			{
				
				writer.Initialize((IWMProfile)profile.SaveToIWMProfile(), fileName);
				
				VideoInfoHeader viHeader = new VideoInfoHeader();
				writer.FindVideoInputFormat(0, MediaSubTypes.WMMEDIASUBTYPE_RGB24, ref viHeader, false);
				writer.Start();

				INSSBuffer sample = null;
				int bmcount = 0;
				Bitmap frame = new Bitmap((int)viHeader.bmiHeader.biWidth, (int)viHeader.bmiHeader.biHeight, PixelFormat.Format24bppRgb);;
				ulong fps = framesPerSecond;	
				
				for(int i = 0; i < files.Length; i++)
				{
					if(files[i] != null)
					{		
						Bitmap bmp = new Bitmap(files[i]);
						using (Graphics g = Graphics.FromImage(frame))
						{
							g.InterpolationMode = InterpolationMode.HighQualityBicubic;
							g.CompositingQuality = CompositingQuality.HighQuality;
							g.SmoothingMode = SmoothingMode.HighQuality;
							g.PixelOffsetMode = PixelOffsetMode.HighQuality;
							g.DrawImage(bmp, 0, 0, frame.Width, frame.Height);
							Console.Out.Write(".");
						}

						// Now render to the movie
						try
						{	
							ulong time = ((ulong)bmcount++ * TimeSpan.TicksPerSecond)/fps;
							sample = writer.GetSampleFromBitmap(frame);
							writer.Writer.WriteSample(0, time, (uint)WMT_STREAM_SAMPLE_TYPE.WM_SF_CLEANPOINT, sample);
						}
						finally
						{													
							Marshal.ReleaseComObject(sample);
							sample = null;
							bmp = null;
							GC.Collect();
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="bitmaps">Bitmaps.</param>
		public void SaveVideo(string fileName, string profileFileName, Bitmap [] bitmaps)
		{
			SaveVideo(fileName, profileFileName, (ulong) WMEncProfile.DEFAULT_FRAME_RATE, bitmaps);
		}

		/// <summary>
		/// Saves the video.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="profileFileName">Name of the profile file.</param>
		/// <param name="framesPerSecond">Frames per second.</param>
		/// <param name="bitmaps">Bitmaps.</param>
		public void SaveVideo(string fileName, string profileFileName, ulong framesPerSecond, Bitmap [] bitmaps)
		{
			WMEncoder encoder = new WMEncoder();
			IWMEncProfile2 profile = WMEncProfile.LoadEncodingProfile(encoder, profileFileName);
			WMEncProfile.ReleaseEncoder(ref encoder);
			
			using(WmvWriter writer = new WmvWriter())
			{
				writer.Initialize((IWMProfile)profile.SaveToIWMProfile(), fileName);
				
				VideoInfoHeader viHeader = new VideoInfoHeader();
				writer.FindVideoInputFormat(0, MediaSubTypes.WMMEDIASUBTYPE_RGB24, ref viHeader, false);
				writer.Start();

				INSSBuffer sample = null;
				int bmcount = 0;
				Bitmap frame = new Bitmap((int)viHeader.bmiHeader.biWidth, (int)viHeader.bmiHeader.biHeight, PixelFormat.Format24bppRgb);;
				
				ulong fps = framesPerSecond;
				
				for(int i = 0; i < bitmaps.Length; i++)
				{
					if(bitmaps[i] != null)
					{						
						using (Graphics g = Graphics.FromImage(frame))
						{
							g.InterpolationMode = InterpolationMode.HighQualityBicubic;
							g.CompositingQuality = CompositingQuality.HighQuality;
							g.SmoothingMode = SmoothingMode.HighQuality;
							g.PixelOffsetMode = PixelOffsetMode.HighQuality;
							g.DrawImage(bitmaps[i], 0, 0, frame.Width, frame.Height);
						}

						// Now render to the movie
						try
						{	
							ulong time = ((ulong)bmcount++ * TimeSpan.TicksPerSecond)/fps;
							sample = writer.GetSampleFromBitmap(frame);
							writer.Writer.WriteSample(0, time, (uint)WMT_STREAM_SAMPLE_TYPE.WM_SF_CLEANPOINT, sample);
						}
						finally
						{													
							Marshal.ReleaseComObject(sample);
							sample = null;
							bitmaps[i] = null;
							GC.Collect();
						}
					}
				}
			}
		}
	}
}