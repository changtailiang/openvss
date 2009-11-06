// hmsw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// fjsa	
// ypbt	 By downloading, copying, installing or using the software you agree to this license.
// hrpu	 If you do not agree to this license, do not download, install,
// tgvo	 copy or use the software.
// lexv	
// jzew	                          License Agreement
// lyfj	         For OpenVss - Open Source Video Surveillance System
// fihl	
// fyyv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// sbux	
// qzfl	Third party copyrights are property of their respective owners.
// iyln	
// tvzc	Redistribution and use in source and binary forms, with or without modification,
// owng	are permitted provided that the following conditions are met:
// evpz	
// kroy	  * Redistribution's of source code must retain the above copyright notice,
// jeov	    this list of conditions and the following disclaimer.
// hzvk	
// kafj	  * Redistribution's in binary form must reproduce the above copyright notice,
// tson	    this list of conditions and the following disclaimer in the documentation
// nrqj	    and/or other materials provided with the distribution.
// ifwi	
// lrrx	  * Neither the name of the copyright holders nor the names of its contributors 
// mumz	    may not be used to endorse or promote products derived from this software 
// khcd	    without specific prior written permission.
// jqgu	
// apso	This software is provided by the copyright holders and contributors "as is" and
// rdnm	any express or implied warranties, including, but not limited to, the implied
// gbmt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// afqd	In no event shall the Prince of Songkla University or contributors be liable 
// hfjp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ixxp	(including, but not limited to, procurement of substitute goods or services;
// ogzm	loss of use, data, or profits; or business interruption) however caused
// pldx	and on any theory of liability, whether in contract, strict liability,
// lwit	or tort (including negligence or otherwise) arising in any way out of
// nirh	the use of this software, even if advised of the possibility of such damage.

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
