// hniu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bndi	
// pufp	 By downloading, copying, installing or using the software you agree to this license.
// chov	 If you do not agree to this license, do not download, install,
// juij	 copy or use the software.
// mklr	
// bder	                          License Agreement
// wmla	         For OpenVss - Open Source Video Surveillance System
// vpgt	
// enya	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// cwgo	
// cabz	Third party copyrights are property of their respective owners.
// qayb	
// kwbw	Redistribution and use in source and binary forms, with or without modification,
// bqsx	are permitted provided that the following conditions are met:
// jmlc	
// iftn	  * Redistribution's of source code must retain the above copyright notice,
// avqw	    this list of conditions and the following disclaimer.
// vhgq	
// ewob	  * Redistribution's in binary form must reproduce the above copyright notice,
// bebw	    this list of conditions and the following disclaimer in the documentation
// okpz	    and/or other materials provided with the distribution.
// okro	
// uarp	  * Neither the name of the copyright holders nor the names of its contributors 
// ldgx	    may not be used to endorse or promote products derived from this software 
// gnzu	    without specific prior written permission.
// jcfd	
// pkre	This software is provided by the copyright holders and contributors "as is" and
// bqwe	any express or implied warranties, including, but not limited to, the implied
// kooy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// puzp	In no event shall the Prince of Songkla University or contributors be liable 
// dcbv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qqfb	(including, but not limited to, procurement of substitute goods or services;
// qqun	loss of use, data, or profits; or business interruption) however caused
// fgnl	and on any theory of liability, whether in contract, strict liability,
// fmkd	or tort (including negligence or otherwise) arising in any way out of
// tmmd	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using Vs.Core.Analyzer;
using Vs.Core.Image;

namespace Vs.Analyzer.MotionDetection
{
    public class VsMotionDetectionOrigin : VsCoreAnalyzer, IDisposable
    {
        private int width;	// image width
        private int height;	// image height
        private int pixelsChanged;

        double threshold1, threshold2;
        bool bLastDetected = false;
        int counter = 0;

        private byte[]  bkgFrame = null;
		private byte[]	curFrame = null;
		private byte[]	dilatatedFrame = null;
        private int     block = 32;

        string AnalyszerName
        {
            set { analyserName = value;  }
        }

		// Constructor
        public VsMotionDetectionOrigin(long syncTimer)
            : base(syncTimer, 1, 1)
		{
            threshold1 = 10;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(true);
        }

        // Call pixels changes in persentage
        private double CalPixelChange()
        {
            return (double) pixelsChanged / (width * height); ;
        }

        // Process new frame
        public override void process_Frame1(VsImage lastFrame)
        {
            try
            {
                counter++; if (counter > 65000) counter = 0;
                if (threshold2 > 0 && counter % threshold2 != 0)
                {
                    lastFrame.Result = "";
                    lastFrame.IsAnalyzed = true;
                    lastFrame.IsDetected = bLastDetected;
                    return;
                }

                width = lastFrame.Image.Width;
                height = lastFrame.Image.Height;

                int fW = (((width - 1) / block) + 1);
                int fH = (((height - 1) / block) + 1);
                int len = fW * fH;

                if (bkgFrame == null)
                {
                    threshold1 = double.Parse(AnalyzerConfiguration["ThresholdAlpha"].ToString()) / 100.0;
                    threshold2 = double.Parse(AnalyzerConfiguration["ThresholdSigma"].ToString());

                    // alloc memory for a backgound image and for current image
                    bkgFrame = new byte[len];
                    curFrame = new byte[len];
                    dilatatedFrame = new byte[len];

                    // lock image
                    BitmapData imgData = lastFrame.Image.LockBits(
                        new Rectangle(0, 0, width, height),
                        ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    // create initial backgroung image
                    preprocess_Frame(imgData, width, height, bkgFrame);

                    // unlock the image
                    lastFrame.Image.UnlockBits(imgData);
                }

                // lock image
                BitmapData data = lastFrame.Image.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // preprocess input image
                preprocess_Frame(data, width, height, curFrame);

                float alpha = 0.30F;
                for (int i = 0; i < len; i++)
                {
                    bkgFrame[i] = (byte)(alpha * curFrame[i] + (1 - alpha) * bkgFrame[i]);
                }

                // difference and thresholding
                for (int i = 0; i < len; i++)
                {
                    int t = curFrame[i] - bkgFrame[i];
                    if (t < 0) t = -t;

                    if (t >= 10)
                    {
                        curFrame[i] = (byte)255;
                    }
                    else
                    {
                        curFrame[i] = (byte)0;
                    }
                }

                // erosion analogue
                // it can be skipped
                pixelsChanged = 0;
                for (int i = 1; i < fH - 1; i++)
                {
                    for (int j = 1; j < fW - 1; j++)
                    {
                        int k = i * fW + j;
                        if (curFrame[k] == 255)
                        {
                            if ((curFrame[i * fW + (j + 1)] == 255) ||
                                (curFrame[i * fW + (j - 1)] == 255) ||
                                (curFrame[(i - 1) * fW + j] == 255) ||
                                (curFrame[(i + 1) * fW + j] == 255))
                            {
                                pixelsChanged += (block * block);
                                curFrame[k] = (byte)255;
                            }
                            else curFrame[k] = (byte)0;
                        }
                    }
                }

                // unlock the image
                lastFrame.Image.UnlockBits(data);

                // postprocess the input image
                // lock image
                /*
                lastFrame.AnalyzedImage = (Bitmap)lastFrame.Image.Clone();
                BitmapData adata = lastFrame.AnalyzedImage.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                 * 
                postprocess_Frame(adata, width, height, curFrame);

                lastFrame.AnalyzedImage.UnlockBits(adata);
                */

                lastFrame.Result = "";
                lastFrame.IsAnalyzed = true;

                if (CalPixelChange() > threshold1)
                {
                    lastFrame.IsDetected = true;
                    bLastDetected = true;
                }
                else
                {
                    lastFrame.IsDetected = false;
                    bLastDetected = false;
                }
            }
            catch { }
        }

		// Preprocess input image
		private void preprocess_Frame(BitmapData data, int width, int height, byte[] buf )
		{
			int stride = data.Stride;
			int offset = stride - width * 3;
			int len = (int)( ( width - 1 ) / block ) + 1;
			int rem = ( ( width - 1 ) % block ) + 1;
			int[] tmp = new int[len];
			int i, j, t1, t2, k = 0;

			unsafe
			{
				byte * src = (byte *) data.Scan0.ToPointer( );

				for ( int y = 0; y < height; )
				{
					// collect pixels
					Array.Clear( tmp, 0, len );

					// calculate
					for ( i = 0; ( i < block ) && ( y < height ); i++, y++ )
					{
						// for each pixel
						for ( int x = 0; x < width; x++, src += 3 )
						{
							// grayscale value using BT709
                            tmp[(int)(x / block)] += (int)(0.2125f * src[VsColorRGB.R] + 0.7154f * src[VsColorRGB.G] + 0.0721f * src[VsColorRGB.B]);
						}
						src += offset;
					}

					// get average values
					t1 = i * block;
					t2 = i * rem;

					for ( j = 0; j < len - 1; j++, k++ )
						buf[k] = (byte)( tmp[j] / t1 );
					buf[k++] = (byte)( tmp[j] / t2 );
				}
			}
		}

		// Postprocess input image
		private String postprocess_Frame(BitmapData data, int width, int height, byte[] buf )
		{
            String str="";
			int stride = data.Stride;
			int offset = stride - width * 3;
			int len = (int)( ( width - 1 ) / block ) + 1;
			int lenWM1 = len - 1;
			int lenHM1 = (int)( ( height - 1 ) / block);
			int rem = (( width - 1 ) % block ) + 1;

			int i, j, k;
            int xmin=width, xmax=0, ymin=height, ymax=0;
	
			unsafe
			{
				byte * src = (byte *) data.Scan0.ToPointer( );

				// for each line
				for ( int y = 0; y < height; y++ )
				{
					i = (y / block);

					// for each pixel
					for ( int x = 0; x < width; x++, src += 3 )
					{
						j = x / block;	
						k = i * len + j;

						// check if we need to highlight moving object
						if (buf[k] == 255)
						{
                            src[VsColorRGB.R] = 255;
                            if (y > 20)
                            {
                                if (x < xmin) xmin = x;
                                if (x > xmax) xmax = x;
                                if (y < ymin) ymin = y;
                                if (y > ymax) ymax = y;
                            }
						}
					}
					src += offset;
				}
			}
            str += (xmin.ToString() + "," + ymin.ToString() + "," + (xmax-xmin).ToString() + "," + (ymax-ymin).ToString() + ";");
            return str;
		}
    }
}
