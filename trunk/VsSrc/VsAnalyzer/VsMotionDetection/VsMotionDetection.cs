// mlud	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pojg	
// xinb	 By downloading, copying, installing or using the software you agree to this license.
// hikq	 If you do not agree to this license, do not download, install,
// vufw	 copy or use the software.
// ovif	
// msuo	                          License Agreement
// wvod	         For OpenVss - Open Source Video Surveillance System
// dods	
// dbtf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// gjrg	
// xyqd	Third party copyrights are property of their respective owners.
// frks	
// dvtr	Redistribution and use in source and binary forms, with or without modification,
// dpqw	are permitted provided that the following conditions are met:
// uujc	
// tkys	  * Redistribution's of source code must retain the above copyright notice,
// ernu	    this list of conditions and the following disclaimer.
// aaqf	
// dcho	  * Redistribution's in binary form must reproduce the above copyright notice,
// brje	    this list of conditions and the following disclaimer in the documentation
// lwzh	    and/or other materials provided with the distribution.
// vmpo	
// kxll	  * Neither the name of the copyright holders nor the names of its contributors 
// zpmn	    may not be used to endorse or promote products derived from this software 
// axyn	    without specific prior written permission.
// eprd	
// fnnb	This software is provided by the copyright holders and contributors "as is" and
// hcvd	any express or implied warranties, including, but not limited to, the implied
// leqx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lqxs	In no event shall the Prince of Songkla University or contributors be liable 
// cykd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pfgn	(including, but not limited to, procurement of substitute goods or services;
// pund	loss of use, data, or profits; or business interruption) however caused
// svav	and on any theory of liability, whether in contract, strict liability,
// ewch	or tort (including negligence or otherwise) arising in any way out of
// yohi	the use of this software, even if advised of the possibility of such damage.

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
    public class VsMotionDetection : VsCoreAnalyzer, IDisposable
    {
        private static int width = 320;	// image width
        private static int height= 240;	// image height
        private static int block = 16;  // block size
        private int blockChanged;

        double threshold1, threshold2;
        bool bLastDetected = false;
        int counter = 0;

        private Bitmap curImage = null;
        private byte[]  bkgFrame = null;
		private byte[]	curFrame = null;
		private byte[]	dilatatedFrame = null;
        static int fW = (((width - 1) / block) + 1);
        static int fH = (((height - 1) / block) + 1);
        static int len = fW * fH;

        string AnalyszerName
        {
            set { analyserName = value;  }
        }

		// Constructor
        public VsMotionDetection(long syncTimer)
            : base(syncTimer, 1, 1)
		{
            threshold1 = 10;

            curImage = new Bitmap(width, height);
        }

        protected override void Dispose(bool disposing)
        {
            curImage.Dispose();

            base.Dispose(true);
        }

        // Process new frame
        public override void process_Frame1(VsImage lastFrame)
        {
            try
            {
                // frame sampling for background estimation
                // ----------------------------------------------------------------
                counter++; if (counter > 65000) counter = 0;
                if (threshold2 > 0 && counter % threshold2 != 0)
                {
                    lastFrame.Result = "";
                    lastFrame.IsAnalyzed = true;
                    lastFrame.IsDetected = bLastDetected;
                    return;
                }

                // image scaling
                using (Graphics gp = Graphics.FromImage(curImage)) gp.DrawImage(lastFrame.Image, 0, 0, width, height);

                // first frame checking for memory allocation
                // ----------------------------------------------------------------
                if (bkgFrame == null)
                {
                    threshold1 = double.Parse(AnalyzerConfiguration["ThresholdAlpha"].ToString()) / 100.0;
                    if (threshold1 < 0.1) threshold1 = 0.005;
                    threshold2 = double.Parse(AnalyzerConfiguration["ThresholdSigma"].ToString());
                    if (threshold2 < 0) threshold2 = 1;

                    // alloc memory for a backgound image and for current image
                    bkgFrame = new byte[len];
                    curFrame = new byte[len];
                    dilatatedFrame = new byte[len];

                    // lock image
                    BitmapData imgData = curImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    // create initial backgroung image
                    preprocess_Frame(imgData, width, height, bkgFrame);

                    // unlock the image
                    curImage.UnlockBits(imgData);
                }

                // background estimation
                // ----------------------------------------------------------------
                // lock image
                BitmapData dataImage = curImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // preprocess input image
                preprocess_Frame(dataImage, width, height, curFrame);

                // unlock the image
                curImage.UnlockBits(dataImage);

                // update background by running average
                float alpha = 0.30F;
                for (int i = 0; i < len; i++) bkgFrame[i] = (byte)(alpha * curFrame[i] + (1 - alpha) * bkgFrame[i]);

                // motion detection
                // ----------------------------------------------------------------
                // by difference and thresholding
                for (int i = 0; i < len; i++)
                {
                    int t = curFrame[i] - bkgFrame[i];
                    if (t < 0) t = -t;

                    if (t >= 5) curFrame[i] = (byte)255;
                    else curFrame[i] = (byte)0;
                }

                // erosion analogue
                // it can be skipped
                blockChanged = 0;
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
                                blockChanged += (block * block);
                                curFrame[k] = (byte)255;
                            }
                            else curFrame[k] = (byte)0;
                        }
                    }
                }

                // postprocess the input image
                // lock image
                /*
                lastFrame.AnalyzedImage = (Bitmap)curImage.Clone();
                BitmapData adata = lastFrame.AnalyzedImage.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                 * 
                postprocess_Frame(adata, width, height, curFrame);

                lastFrame.AnalyzedImage.UnlockBits(adata);
                */

                // set motion index
                // ----------------------------------------------------------------
                lastFrame.Result = ""; lastFrame.IsAnalyzed = true;

                double ch = (double)blockChanged / (width * height);
                if (ch > threshold1 && ch < 0.8)
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
