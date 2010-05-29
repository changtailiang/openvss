// yogc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ccve	
// bddj	 By downloading, copying, installing or using the software you agree to this license.
// ubwq	 If you do not agree to this license, do not download, install,
// opfh	 copy or use the software.
// bgmn	
// yvik	                          License Agreement
// jzrf	         For OpenVSS - Open Source Video Surveillance System
// gbjv	
// noni	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ulnc	
// vrab	Third party copyrights are property of their respective owners.
// uxqa	
// qkbs	Redistribution and use in source and binary forms, with or without modification,
// cseg	are permitted provided that the following conditions are met:
// ulvb	
// lyds	  * Redistribution's of source code must retain the above copyright notice,
// sbda	    this list of conditions and the following disclaimer.
// bwmq	
// sksh	  * Redistribution's in binary form must reproduce the above copyright notice,
// uhpl	    this list of conditions and the following disclaimer in the documentation
// jrov	    and/or other materials provided with the distribution.
// artu	
// kgoj	  * Neither the name of the copyright holders nor the names of its contributors 
// plqx	    may not be used to endorse or promote products derived from this software 
// niit	    without specific prior written permission.
// uqyt	
// ylzs	This software is provided by the copyright holders and contributors "as is" and
// awln	any express or implied warranties, including, but not limited to, the implied
// vjst	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jisb	In no event shall the Prince of Songkla University or contributors be liable 
// iipv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// idah	(including, but not limited to, procurement of substitute goods or services;
// tvtm	loss of use, data, or profits; or business interruption) however caused
// ywqs	and on any theory of liability, whether in contract, strict liability,
// tvwo	or tort (including negligence or otherwise) arising in any way out of
// rbtn	the use of this software, even if advised of the possibility of such damage.
// vanf	
// txnf	Intelligent Systems Laboratory (iSys Lab)
// phll	Faculty of Engineering, Prince of Songkla University, THAILAND
// bdkv	Project leader by Nikom SUVONVORN
// lsyf	Project website at http://code.google.com/p/openvss/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace VsStreamerTest
{
    public class VsScreenCapture : System.MarshalByRefObject
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(
            IntPtr hdcDest, // handle to destination DC
            int nXDest, // x-coord of destination upper-left corner
            int nYDest, // y-coord of destination upper-left corner
            int nWidth, // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc, // handle to source DC
            int nXSrc, // x-coordinate of source upper-left corner
            int nYSrc, // y-coordinate of source upper-left corner
            System.Int32 dwRop // raster operation code
            );
        private const Int32 SRCCOPY = 0xCC0020;
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;

        public Size GetDesktopBitmapSize()
        {
            return new Size(GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN));
        }

        public static Bitmap GetDesktopBitmap()
        {
            Size DesktopBitmapSize = new Size(GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN));
            Graphics Graphic = Graphics.FromHwnd(GetDesktopWindow());
            Bitmap MemImage = new Bitmap(DesktopBitmapSize.Width, DesktopBitmapSize.Height, Graphic);

            Graphics MemGraphic = Graphics.FromImage(MemImage);
            IntPtr dc1 = Graphic.GetHdc();
            IntPtr dc2 = MemGraphic.GetHdc();
            BitBlt(dc2, 0, 0, DesktopBitmapSize.Width, DesktopBitmapSize.Height, dc1, 0, 0, SRCCOPY);
            Graphic.ReleaseHdc(dc1);
            MemGraphic.ReleaseHdc(dc2);
            Graphic.Dispose();
            MemGraphic.Dispose();

            return MemImage;
        }

        public byte[] GetDesktopBitmapBytes()
        {
            Bitmap DrawImage = new Bitmap(320, 240);
            Size DesktopBitmapSize = GetDesktopBitmapSize();
            Graphics Graphic = Graphics.FromHwnd(GetDesktopWindow());
            Bitmap MemImage = new Bitmap(DesktopBitmapSize.Width, DesktopBitmapSize.Height, Graphic);

            Graphics MemGraphic = Graphics.FromImage(MemImage);
            IntPtr dc1 = Graphic.GetHdc();
            IntPtr dc2 = MemGraphic.GetHdc();
            BitBlt(dc2, 0, 0, DesktopBitmapSize.Width, DesktopBitmapSize.Height, dc1, 0, 0, SRCCOPY);
            Graphic.ReleaseHdc(dc1);
            MemGraphic.ReleaseHdc(dc2);
            Graphic.Dispose();
            MemGraphic.Dispose();

            Graphics g = System.Drawing.Graphics.FromImage(MemImage);
            System.Windows.Forms.Cursor cur = System.Windows.Forms.Cursors.Arrow;
            cur.Draw(g, new Rectangle(System.Windows.Forms.Cursor.Position.X - 10, System.Windows.Forms.Cursor.Position.Y - 10, cur.Size.Width, cur.Size.Height));

            using (Graphics gp = Graphics.FromImage(DrawImage))
            {
                gp.DrawImage(MemImage, 0, 0, 320, 240);
            }
            int offset = 623;
            EncoderParameter epQuality = new EncoderParameter(Encoder.Quality, 74L);
            // Store the quality parameter in the list of encoder parameters
            EncoderParameters epParameters = new EncoderParameters(1);
            epParameters.Param[0] = epQuality;

            MemoryStream ms = new MemoryStream();
            DrawImage.Save(ms, GetImageCodecInfo(ImageFormat.Jpeg), epParameters);

            byte[] data = new byte[(int)ms.Length - offset];
            Array.Copy(ms.GetBuffer(), offset, data, 0, (int)ms.Length - offset);
            return data;
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
                if (info.FormatID == format.Guid) return info;
            return null;
        }

        public Image Get_Resized_Image(int w, int h, byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);

            Image bt = Image.FromStream(ms);
            try
            {
                Size sizing = new Size(w, h);
                bt = new System.Drawing.Bitmap(bt, sizing);

            }
            catch (Exception) { }
            return bt;

        }

        public float difference(Image OrginalImage, Image SecoundImage)
        {
            float percent = 0;
            try
            {
                float counter = 0;

                Bitmap bt1 = new Bitmap(OrginalImage);
                Bitmap bt2 = new Bitmap(SecoundImage);
                int size_H = bt1.Size.Height;
                int size_W = bt1.Size.Width;

                float total = size_H * size_W;

                Color pixel_image1;
                Color pixel_image2;

                for (int x = 0; x != size_W; x++)
                {

                    for (int y = 0; y != size_H; y++)
                    {
                        pixel_image1 = bt1.GetPixel(x, y);
                        pixel_image2 = bt2.GetPixel(x, y);

                        if (pixel_image1 != pixel_image2)
                        {
                            counter++;
                        }

                    }

                }
                percent = (counter / total) * 100;

            }
            catch (Exception) { percent = 0; }

            return percent;
        }
    }
}
