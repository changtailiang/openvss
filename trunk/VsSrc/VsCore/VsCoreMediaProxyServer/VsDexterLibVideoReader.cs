// rbfu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// adif	
// txml	 By downloading, copying, installing or using the software you agree to this license.
// efxy	 If you do not agree to this license, do not download, install,
// aosg	 copy or use the software.
// vsnj	
// tssp	                          License Agreement
// turl	         For OpenVSS - Open Source Video Surveillance System
// fniy	
// gftp	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dapf	
// glcg	Third party copyrights are property of their respective owners.
// qbdc	
// uumy	Redistribution and use in source and binary forms, with or without modification,
// ovah	are permitted provided that the following conditions are met:
// ksmy	
// fbgq	  * Redistribution's of source code must retain the above copyright notice,
// wzsv	    this list of conditions and the following disclaimer.
// udcv	
// dhdh	  * Redistribution's in binary form must reproduce the above copyright notice,
// qmyr	    this list of conditions and the following disclaimer in the documentation
// rpqk	    and/or other materials provided with the distribution.
// ajjk	
// emek	  * Neither the name of the copyright holders nor the names of its contributors 
// oqzf	    may not be used to endorse or promote products derived from this software 
// fljr	    without specific prior written permission.
// jhir	
// srvg	This software is provided by the copyright holders and contributors "as is" and
// ssqy	any express or implied warranties, including, but not limited to, the implied
// tuhq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kwqn	In no event shall the Prince of Songkla University or contributors be liable 
// qiqh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ysgn	(including, but not limited to, procurement of substitute goods or services;
// ixce	loss of use, data, or profits; or business interruption) however caused
// chij	and on any theory of liability, whether in contract, strict liability,
// gysi	or tort (including negligence or otherwise) arising in any way out of
// ocsm	the use of this software, even if advised of the possibility of such damage.
// vgqt	
// iiuj	Intelligent Systems Laboratory (iSys Lab)
// vwbb	Faculty of Engineering, Prince of Songkla University, THAILAND
// qasz	Project leader by Nikom SUVONVORN
// lhyu	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using DexterLib;
using System.Drawing;

namespace Vs.Core.MediaProxyServer
{
    public class VsDexterLibVideoReader
    {
        string videoFile;
        Size target;

        IMediaDet mediaDet;
        _AMMediaType mediaType;

        int bmpinfoheaderSize = 40; //equals to sizeof(CommonClasses.BITMAPINFOHEADER);
        int bufferSize;
        IntPtr frameBuffer;

        public double streamLength;

        public int outputFrameInterval = 0;//min sec//famerate = 1000/outputFrameInterval
        public int inputFrameInterval = 0;

        public ulong currentPosition = 0;

        public VsDexterLibVideoReader(string videoFilePath, Size targ)
            : this(videoFilePath, targ,0)
        {
            this.outputFrameInterval = this.inputFrameInterval;
        }
        public VsDexterLibVideoReader(string videoFilePath, Size targ, int outputFrameInterval)
        {
            this.videoFile = videoFilePath;
            this.target = targ;

            if (target.Width % 4 != 0 || target.Height % 4 != 0)
                throw new ArgumentException("Target size must be a multiple of 4", "target");


            if (openVideoStream(videoFile, out mediaDet, out mediaType))
            {
                this.streamLength = mediaDet.StreamLength;

                if (target == Size.Empty)
                    target = getVideoSize(mediaType);
                else
                {
                    Size s = getVideoSize(mediaType);

                    if (s.Width < target.Width)
                        target.Width = s.Width;
                    if (s.Height < target.Height)
                        target.Height = s.Height;

                    target = scaleToFit(target, getVideoSize(mediaType));
                    //ensures that the size is a multiple of 4 (required by the Bitmap constructor)
                    target.Width -= target.Width % 4;
                    target.Height -= target.Height % 4;
                }

                unsafe
                {
                    Size s = getVideoSize(mediaType);
                    bufferSize = (((s.Width * s.Height) * 24) / 8) + bmpinfoheaderSize;	//equals to mediaDet.GetBitmapBits(0d, ref bufferSize, ref *buffer, target.Width, target.Height);	

                }
                
                this.outputFrameInterval = outputFrameInterval;
                this.inputFrameInterval = (int)(1000/mediaDet.FrameRate);

            }
            else
            {
                throw new Exception("No video stream was found");
            }
        }

        public void Close()
        {
            if (mediaDet != null)
                Marshal.ReleaseComObject(mediaDet);
            GC.SuppressFinalize(this);
        }

        public Bitmap GetFrameFromVideoPosition(double Position)
        {
            if (mediaDet == null)
                throw new ArgumentNullException("mediaDet");
            if (Position > streamLength || Position < 0)
                throw new ArgumentOutOfRangeException("percentagePosition", Position, "Valid range is 0.0 .. 1.0");

            unsafe
            {
                frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
                byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();
                //gets bitmap, save in frameBuffer2
                mediaDet.GetBitmapBits(Position, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);

                //now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits

                Bitmap bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));

                bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);
                return bmp;
            }
        }
        public Bitmap[] GetFrameFromVideo(int frameRate)
        {
            double Position = 0;
            if (mediaDet == null)
                throw new ArgumentNullException("mediaDet");
            if (Position > streamLength || Position < 0)
                throw new ArgumentOutOfRangeException("percentagePosition", Position, "Valid range is 0.0 .. 1.0");

            List<Bitmap> bits = new List<Bitmap>();
            unsafe
            {
                frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
                byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();
                //gets bitmap, save in frameBuffer2
                Bitmap bmp;
                while (true)
                {
                    mediaDet.GetBitmapBits(Position, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);
                    //now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits
                    bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

                    bits.Add(bmp);

                    Position += 1.0 / frameRate;
                    if (Position > streamLength)
                    {
                        break;
                    }
                }

                System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);
                return bits.ToArray();
            }
        }

        //outputFrameInterval must >0
        public bool getNextFrameAsInterval(out Bitmap frameOutput)
        {
            try
            {
                double secPosition = (double)currentPosition / 1000;
                frameOutput = GetFrameFromVideoPosition(secPosition);
                currentPosition += (ulong)this.outputFrameInterval;
                return (frameOutput != null);
            }
            catch
            {
                frameOutput = null;
                return false;
            }

            //frameOutput = null;

        }


        private static bool openVideoStream(string videoFile, out IMediaDet mediaDet, out _AMMediaType aMMediaType)
        {
            mediaDet = new MediaDetClass();

            //loads file
            mediaDet.Filename = videoFile;

            //gets # of streams
            int streamsNumber = mediaDet.OutputStreams;

            //finds a video stream
            for (int i = 0; i < streamsNumber; i++)
            {
                mediaDet.CurrentStream = i;
                _AMMediaType mediaType = mediaDet.StreamMediaType;

                if (mediaType.majortype == MayorTypes.MEDIATYPE_Video)
                {
                    //video stream found
                    aMMediaType = mediaType;
                    return true;
                }
            }

            //no video stream found
            Marshal.ReleaseComObject(mediaDet);
            mediaDet = null;
            aMMediaType = new _AMMediaType();
            return false;
        }

        private static Size getVideoSize(_AMMediaType mediaType)
        {
            WinStructs.VIDEOINFOHEADER videoInfo = (WinStructs.VIDEOINFOHEADER)Marshal.PtrToStructure(mediaType.pbFormat, typeof(WinStructs.VIDEOINFOHEADER));

            return new Size(videoInfo.bmiHeader.biWidth, videoInfo.bmiHeader.biHeight);
        }
        private static Size scaleToFit(Size target, Size original)
        {
            if (target.Height * original.Width > target.Width * original.Height)
                target.Height = target.Width * original.Height / original.Width;
            else
                target.Width = target.Height * original.Width / original.Height;

            return target;
        }
    }

    public class MayorTypes
    {
        public static Guid MEDIATYPE_Video = new Guid(0x73646976, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_Audio = new Guid(0x73647561, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_Text = new Guid(0x73747874, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_Midi = new Guid(0x7364696D, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_Stream = new Guid(0xe436eb83, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70);

        public static Guid MEDIATYPE_Interleaved = new Guid(0x73766169, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_File = new Guid(0x656c6966, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_ScriptCommand = new Guid(0x73636d64, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_AUXLine21Data = new Guid(0x670aea80, 0x3a82, 0x11d0, 0xb7, 0x9b, 0x0, 0xaa, 0x0, 0x37, 0x67, 0xa7);

        public static Guid MEDIATYPE_VBI = new Guid(0xf72a76e1, 0xeb0a, 0x11d0, 0xac, 0xe4, 0x00, 0x00, 0xc0, 0xcc, 0x16, 0xba);

        public static Guid MEDIATYPE_Timecode = new Guid(0x482dee3, 0x7817, 0x11cf, 0x8a, 0x3, 0x0, 0xaa, 0x0, 0x6e, 0xcb, 0x65);

        public static Guid MEDIATYPE_LMRT = new Guid(0x74726c6d, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

        public static Guid MEDIATYPE_URL_STREAM = new Guid(0x736c7275, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xaa, 0x00, 0x38, 0x9b, 0x71);

    }
    public class WinStructs
    {
        /// <summary>
        /// The VIDEOINFOHEADER structure describes the bitmap and color information for a video image
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct VIDEOINFOHEADER
        {
            /// <summary>RECT structure that specifies the source video window. This structure can be a clipping rectangle, to select a portion of the source video stream.</summary>
            public RECT rcSource;
            /// <summary>RECT structure that specifies the destination video window.</summary>
            public RECT rcTarget;
            /// <summary>Approximate data rate of the video stream, in bits per second</summary>
            public uint dwBitRate;
            /// <summary>Data error rate, in bit errors per second</summary>
            public uint dwBitErrorRate;
            /// <summary>The desired average display time of the video frames, in 100-nanosecond units. The actual time per frame may be longer. See Remarks.</summary>
            public long AvgTimePerFrame;
            /// <summary>BITMAPINFOHEADER structure that contains color and dimension information for the video image bitmap. If the format block contains a color table or color masks, they immediately follow the bmiHeader member. You can get the first color entry by casting the address of member to a BITMAPINFO pointer</summary>
            public BITMAPINFOHEADER bmiHeader;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        int left;
        int top;
        int right;
        int bottom;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        /// <summary>Specifies the number of bytes required by the structure. This value does not include the size of the color table or the size of the color masks, if they are appended to the end of structure. See Remarks.</summary>
        public uint biSize;
        /// <summary>Specifies the width of the bitmap, in pixels. For information about calculating the stride of the bitmap, see Remarks.</summary>
        public int biWidth;
        /// <summary>Specifies the height of the bitmap, in pixels. SEE MSDN</summary>
        public int biHeight;
        /// <summary>Specifies the number of planes for the target device. This value must be set to 1</summary>
        public ushort biPlanes;
        /// <summary>Specifies the number of bits per pixel (bpp).  For uncompressed formats, this value gives to the average number of bits per pixel. For compressed formats, this value gives the implied bit depth of the uncompressed image, after the image has been decoded.</summary>
        public ushort biBitCount;
        /// <summary>For compressed video and YUV formats, this member is a FOURCC code, specified as a DWORD in little-endian order. For example, YUYV video has the FOURCC 'VYUY' or 0x56595559. SEE MSDN</summary>
        public uint biCompression;
        /// <summary>Specifies the size, in bytes, of the image. This can be set to 0 for uncompressed RGB bitmaps</summary>
        public uint biSizeImage;
        /// <summary>Specifies the horizontal resolution, in pixels per meter, of the target device for the bitmap</summary>
        public int biXPelsPerMeter;
        /// <summary>Specifies the vertical resolution, in pixels per meter, of the target device for the bitmap</summary>
        public int biYPelsPerMeter;
        /// <summary>Specifies the number of color indices in the color table that are actually used by the bitmap. See Remarks for more information.</summary>
        public uint biClrUsed;
        /// <summary>Specifies the number of color indices that are considered important for displaying the bitmap. If this value is zero, all colors are important</summary>
        public uint biClrImportant;
    }
}

//public static Bitmap GetFrameFromVideoPercentage(string videoFile, double percentagePosition, out double streamLength, Size target)
//{
//    if (videoFile == null)
//        throw new ArgumentNullException("videoFile");
//    if (percentagePosition > 1 || percentagePosition < 0)
//        throw new ArgumentOutOfRangeException("percentagePosition", percentagePosition, "Valid range is 0.0 .. 1.0");
//    if (target.Width % 4 != 0 || target.Height % 4 != 0)
//        throw new ArgumentException("Target size must be a multiple of 4", "target");

//    IMediaDet mediaDet = null;
//    try
//    {
//        _AMMediaType mediaType;
//        if (openVideoStream(videoFile, out mediaDet, out mediaType))
//        {
//            streamLength = mediaDet.StreamLength;

//            //calculates the REAL target size of our frame
//            if (target == Size.Empty)
//                target = getVideoSize(mediaType);
//            else
//            {
//                target = scaleToFit(target, getVideoSize(mediaType));
//                //ensures that the size is a multiple of 4 (required by the Bitmap constructor)
//                target.Width -= target.Width % 4;
//                target.Height -= target.Height % 4;
//            }

//            unsafe
//            {
//                Size s = getVideoSize(mediaType);
//                int bmpinfoheaderSize = 40; //equals to sizeof(CommonClasses.BITMAPINFOHEADER);

//                //get size for buffer
//                int bufferSize = (((s.Width * s.Height) * 24) / 8) + bmpinfoheaderSize;	//equals to mediaDet.GetBitmapBits(0d, ref bufferSize, ref *buffer, target.Width, target.Height);	

//                //allocates enough memory to store the frame
//                IntPtr frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
//                byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();

//                //gets bitmap, save in frameBuffer2
//                mediaDet.GetBitmapBits(streamLength * percentagePosition, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);

//                //now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits

//                Bitmap bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));

//                bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
//                System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);

//                return bmp;
//            }
//        }
//    }
//    catch (COMException ex)
//    {
//        // throw new InvalidVideoFileException(getErrorMsg((uint)ex.ErrorCode), ex);
//    }
//    finally
//    {
//        if (mediaDet != null)
//            Marshal.ReleaseComObject(mediaDet);
//    }

//    throw new Exception("No video stream was found");
//}

//public static Bitmap GetFrameFromVideoPosition(string videoFile, double percentagePosition, out double streamLength, Size target)
//{
//    if (videoFile == null)
//        throw new ArgumentNullException("videoFile");
//    if (percentagePosition > 1 || percentagePosition < 0)
//        throw new ArgumentOutOfRangeException("percentagePosition", percentagePosition, "Valid range is 0.0 .. 1.0");
//    if (target.Width % 4 != 0 || target.Height % 4 != 0)
//        throw new ArgumentException("Target size must be a multiple of 4", "target");

//    IMediaDet mediaDet = null;
//    try
//    {
//        _AMMediaType mediaType;
//        if (openVideoStream(videoFile, out mediaDet, out mediaType))
//        {
//            streamLength = mediaDet.StreamLength;

//            //calculates the REAL target size of our frame
//            if (target == Size.Empty)
//                target = getVideoSize(mediaType);
//            else
//            {
//                target = scaleToFit(target, getVideoSize(mediaType));
//                //ensures that the size is a multiple of 4 (required by the Bitmap constructor)
//                target.Width -= target.Width % 4;
//                target.Height -= target.Height % 4;
//            }

//            unsafe
//            {
//                Size s = getVideoSize(mediaType);
//                int bmpinfoheaderSize = 40; //equals to sizeof(CommonClasses.BITMAPINFOHEADER);

//                //get size for buffer
//                int bufferSize = (((s.Width * s.Height) * 24) / 8) + bmpinfoheaderSize;	//equals to mediaDet.GetBitmapBits(0d, ref bufferSize, ref *buffer, target.Width, target.Height);	

//                //allocates enough memory to store the frame
//                IntPtr frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
//                byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();

//                //gets bitmap, save in frameBuffer2
//                mediaDet.GetBitmapBits(streamLength * percentagePosition, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);

//                //now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits

//                Bitmap bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));

//                bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
//                System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);

//                return bmp;
//            }
//        }
//    }
//    catch (COMException ex)
//    {
//        // throw new InvalidVideoFileException(getErrorMsg((uint)ex.ErrorCode), ex);
//    }
//    finally
//    {
//        if (mediaDet != null)
//            Marshal.ReleaseComObject(mediaDet);
//    }

//    throw new Exception("No video stream was found");
//}

//public static Bitmap GetFrameFromVideoPosition(IMediaDet mediaDet, _AMMediaType mediaType, double position, double streamLength, Size target)
//{
//    if (mediaDet == null)
//        throw new ArgumentNullException("mediaDet");
//    if (position > streamLength || position < 0)
//        throw new ArgumentOutOfRangeException("percentagePosition", position, "Valid range is 0.0 .. 1.0");
//    if (target.Width % 4 != 0 || target.Height % 4 != 0)
//        throw new ArgumentException("Target size must be a multiple of 4", "target");

//    // IMediaDet mediaDet = null;
//    try
//    {
//        //calculates the REAL target size of our frame
//        if (target == Size.Empty)
//            target = getVideoSize(mediaType);
//        else
//        {
//            target = scaleToFit(target, getVideoSize(mediaType));
//            //ensures that the size is a multiple of 4 (required by the Bitmap constructor)
//            target.Width -= target.Width % 4;
//            target.Height -= target.Height % 4;
//        }

//        unsafe
//        {
//            Size s = getVideoSize(mediaType);
//            int bmpinfoheaderSize = 40; //equals to sizeof(CommonClasses.BITMAPINFOHEADER);

//            //get size for buffer
//            int bufferSize = (((s.Width * s.Height) * 24) / 8) + bmpinfoheaderSize;	//equals to mediaDet.GetBitmapBits(0d, ref bufferSize, ref *buffer, target.Width, target.Height);	

//            //allocates enough memory to store the frame
//            IntPtr frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
//            byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();

//            //gets bitmap, save in frameBuffer2
//            mediaDet.GetBitmapBits(position, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);

//            //now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits

//            Bitmap bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));

//            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
//            System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);

//            return bmp;
//        }

//    }
//    catch (COMException ex)
//    {
//        // throw new InvalidVideoFileException(getErrorMsg((uint)ex.ErrorCode), ex);
//    }
//    finally
//    {
//        if (mediaDet != null)
//            Marshal.ReleaseComObject(mediaDet);
//    }

//    throw new Exception("No video stream was found");
//}

//public static Bitmap GetFrameFromVideoPosition(IMediaDet mediaDet, _AMMediaType mediaType, double position, Size target)
//{

//    if (target.Width % 4 != 0 || target.Height % 4 != 0)
//        throw new ArgumentException("Target size must be a multiple of 4", "target");

//    // IMediaDet mediaDet = null;
//    try
//    {
//        //calculates the REAL target size of our frame
//        if (target == Size.Empty)
//            target = getVideoSize(mediaType);
//        else
//        {
//            target = scaleToFit(target, getVideoSize(mediaType));
//            //ensures that the size is a multiple of 4 (required by the Bitmap constructor)
//            target.Width -= target.Width % 4;
//            target.Height -= target.Height % 4;
//        }

//        unsafe
//        {
//            Size s = getVideoSize(mediaType);
//            int bmpinfoheaderSize = 40; //equals to sizeof(CommonClasses.BITMAPINFOHEADER);

//            //get size for buffer
//            int bufferSize = (((s.Width * s.Height) * 24) / 8) + bmpinfoheaderSize;	//equals to mediaDet.GetBitmapBits(0d, ref bufferSize, ref *buffer, target.Width, target.Height);	

//            //allocates enough memory to store the frame
//            IntPtr frameBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(bufferSize);
//            byte* frameBuffer2 = (byte*)frameBuffer.ToPointer();

//            //gets bitmap, save in frameBuffer2
//            mediaDet.GetBitmapBits(position, ref bufferSize, ref *frameBuffer2, target.Width, target.Height);

//            //now in buffer2 we have a BITMAPINFOHEADER structure followed by the DIB bits

//            Bitmap bmp = new Bitmap(target.Width, target.Height, target.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, new IntPtr(frameBuffer2 + bmpinfoheaderSize));

//            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
//            System.Runtime.InteropServices.Marshal.FreeHGlobal(frameBuffer);

//            return bmp;
//        }

//    }
//    catch (COMException ex)
//    {
//        // throw new InvalidVideoFileException(getErrorMsg((uint)ex.ErrorCode), ex);
//    }
//    finally
//    {
//        if (mediaDet != null)
//            Marshal.ReleaseComObject(mediaDet);
//    }

//    throw new Exception("No video stream was found");
//}

