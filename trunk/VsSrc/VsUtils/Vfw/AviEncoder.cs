using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Vs.Encoder.AviLib
{
	public class AviEncoder : IDisposable
	{
        private AVIWriter writer = null;

        public AviEncoder()
        {
        }
       		
        public AviEncoder(string codec)
		{
        }

        // start record
        /*
        public void StartRecord(string fname, int frate, int width, int height)
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }

            writer = new AVIWriter();
            writer.Open(fname, frate, width, height);
        }
        */

        // start record
        public void StartRecord(string codec, string fname, int frate, int width, int height)
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }

            writer = new AVIWriter(codec);
            writer.Open(fname, frate, width, height);
        }

        // do recording
        public void DoRecord(Bitmap bitmap)
        {
            if (writer == null) return;
            writer.AddFrame(bitmap);
        }

        // stop recording
        public void StopRecord()
        {
            Dispose();
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