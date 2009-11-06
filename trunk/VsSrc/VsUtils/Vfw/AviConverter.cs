using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Vs.Encoder.AviLib
{
	public class AviConverter : IDisposable
	{
        private AVIReader reader = null;
        private AVIWriter writer = null;

        private String fileFrom;
        private String fileTo;
        
        // Saves the video.
        public AviConverter()
        {
            writer = new AVIWriter();
        }

        // Saves the video.
        public AviConverter(string fromName, string toName, string codec)
        {
            fileFrom = fromName;
            fileTo = toName;
            writer = new AVIWriter(codec);
            reader = new AVIReader();
        }

        public void StartConvert()
        {
            // begin read file
            reader.Open(fileFrom);

            // begin write file
            writer.Open(fileTo, (int)reader.FrameRate, reader.Width, reader.Height);

            while(reader.CurrentPosition < reader.Length)
            {
                writer.AddFrame(reader.GetNextFrame());
            }
        }

        // dispose 
        public void Dispose()
        {
            Dispose(true);
        }

        // virtual dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }

                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                    writer = null;
                }
            }
        }
	}
}