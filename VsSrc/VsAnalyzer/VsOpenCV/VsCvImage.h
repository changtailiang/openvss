/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

#include "stdafx.h"

#include "VsCvUtils.h"
#include "VsCvArr.h"

namespace VsOpenCV
{
	public enum class cvDepth
	{
		Depth1U = IPL_DEPTH_1U,
		Depth8U = IPL_DEPTH_8U,
		Depth16U = IPL_DEPTH_16U,
		Depth32F = IPL_DEPTH_32F,
		Depth8S = IPL_DEPTH_8S,
		Depth16S = IPL_DEPTH_16S,
		Depth32S = IPL_DEPTH_32S,
	};

	public ref class VsCvImage : public VsCvArr, public IDisposable
	{
	protected:
		IplImage *image1, *image2, *image3, *image4, *image5, *imageout;
		IplImage *imagetmp, *imagedst1, *imagedst2, *imagedst3;
		bool created;
		int numIn, numOut;

	private:
		void Create(int in, int out, int width, int height, cvDepth depth, int channels)
		{
			numIn = in; numOut = out;

			if(numIn>=5) image5 = cvCreateImage(cvSize(width, height), (int)depth,  channels);
			if(numIn>=4) image4 = cvCreateImage(cvSize(width, height), (int)depth,  channels);
			if(numIn>=3) image3 = cvCreateImage(cvSize(width, height), (int)depth,  channels);
			if(numIn>=2) image2 = cvCreateImage(cvSize(width, height), (int)depth,  channels);
			if(numIn>=1) image1 = cvCreateImage(cvSize(width, height), (int)depth,  channels);

			imageout = cvCreateImage(cvSize(width*numIn, height), (int)depth,  channels);

			imagedst1 = cvCreateImage(cvSize(width, height), (int)depth, 1); 
			imagedst2 = cvCreateImage(cvSize(width, height), (int)depth, 1); 
			imagedst3 = cvCreateImage(cvSize(width, height), (int)depth, 1); 

			imagetmp = cvCreateImageHeader(cvSize(width, height), (int)depth,  channels);
			
			created = true;
		}
	public:
		VsCvImage(int in, int out, int width, int height, cvDepth depth, int channels)
		{
			Create(in, out, width, height, depth, channels);
		}

		VsCvImage(String^ filename)
		{
			LoadImage(filename, true);
		}

		VsCvImage(String^ filename, bool isColor)
		{
			LoadImage(filename, isColor);
		}

        VsCvImage(Bitmap^ srcImage) 
        { 
			LoadImage(srcImage, 1);
        } 

		virtual ~VsCvImage()
		{
			Release();
		}

		void Release()
		{
			if (!created) return;

			IplImage* ptr;

			if(numIn>=5) { ptr = image5; cvReleaseImage(&ptr); }
			if(numIn>=4) { ptr = image4; cvReleaseImage(&ptr); }
			if(numIn>=3) { ptr = image3; cvReleaseImage(&ptr); }
			if(numIn>=2) { ptr = image2; cvReleaseImage(&ptr); }
			if(numIn>=1) { ptr = image1; cvReleaseImage(&ptr); }

			ptr = imagedst1; cvReleaseImage(&ptr); 
			ptr = imagedst2; cvReleaseImage(&ptr); 
			ptr = imagedst3; cvReleaseImage(&ptr); 

			ptr = imagetmp; cvReleaseImage(&ptr); 			
		}

		void LoadImage(String^ filename, bool isColor)
		{
			Release();
			char fn[1024 + 1];
			VsCvUtils::StringToCharPointer(filename, fn, 1024);
			image1 = cvLoadImage(fn, isColor ? 1 : 0);
			created = true;
		}

        void LoadImage(Bitmap^ srcImage, int input) 
        { 
            System::Drawing::Rectangle rect; 
            rect.X = 0 ; 
            rect.Y = 0 ; 
            rect.Width = srcImage->Width; 
            rect.Height = srcImage->Height; 

			// lock image
            Imaging::BitmapData^ bData = srcImage->LockBits(rect, Imaging::ImageLockMode::ReadWrite, srcImage->PixelFormat); 

            imagetmp->imageData = (char *)bData->Scan0.ToPointer(); 

            cvSplit(imagetmp, imagedst1, imagedst2, imagedst3, NULL); 
            
			switch(input)
			{
				case 1 : cvMerge(imagedst1, imagedst2, imagedst3, NULL, image1); break;
				case 2 : cvMerge(imagedst1, imagedst2, imagedst3, NULL, image2); break;
				case 3 : cvMerge(imagedst1, imagedst2, imagedst3, NULL, image3); break;
				case 4 : cvMerge(imagedst1, imagedst2, imagedst3, NULL, image4); break;
				case 5 : cvMerge(imagedst1, imagedst2, imagedst3, NULL, image5); break;
			}

            srcImage->UnlockBits(bData); 

            created = true; 
        } 

		Bitmap^ SaveImage(int input)
		{
			void* dst_ptr = 0;
			CvMat imagedst;

			HDC hdc = CreateCompatibleDC(0);

			uchar buffer[sizeof(BITMAPINFO) + 255*sizeof(RGBQUAD)];
			BITMAPINFO* binfo = (BITMAPINFO*)buffer;

			FillBitmapInfo(binfo, imageout->width, imageout->height, 24, 1);

			HBITMAP hBitmap = CreateDIBSection(hdc, binfo, DIB_RGB_COLORS, &dst_ptr, 0, 0);
			if (hBitmap == NULL) return nullptr;

			cvInitMatHeader(&imagedst, imageout->height, imageout->width, CV_8UC3, dst_ptr, (imageout->width * 0 + 3) & -4);
			cvConvertImage(imageout, &imagedst, imageout->origin == 0 ? CV_CVTIMG_FLIP : 0);

			Bitmap^ bmpImage = Image::FromHbitmap(IntPtr(hBitmap));

			DeleteObject(hBitmap);
			DeleteDC(hdc);

			return bmpImage;
			/*
			SIZE size = { 0, 0 };
			int channels = 0;
			void* dst_ptr = 0;
			const int channels0 = 3;
			int origin = 0;
			CvMat stub, dst, *imageout;
			bool changed_size = false;

			HDC hdc = CreateCompatibleDC(0);

			CvArr* arr = this->Array;

			if (CV_IS_IMAGE_HDR(arr)) origin = ((IplImage*)arr)->origin;

			imageout = cvGetMat(arr, &stub);

			uchar buffer[sizeof(BITMAPINFO) + 255*sizeof(RGBQUAD)];
			BITMAPINFO* binfo = (BITMAPINFO*)buffer;

			size.cx = imageout->width;
			size.cy = imageout->height;
			channels = channels0;

			FillBitmapInfo(binfo, size.cx, size.cy, channels*8, 1);

			HBITMAP hBitmap = CreateDIBSection(hdc, binfo, DIB_RGB_COLORS, &dst_ptr, 0, 0);
			if (hBitmap == NULL)
				return nullptr;

			cvInitMatHeader(&dst, size.cy, size.cx, CV_8UC3, dst_ptr, (size.cx * channels + 3) & -4);
			cvConvertImage(imageout, &dst, origin == 0 ? CV_CVTIMG_FLIP : 0);

			Bitmap^ bmpImage = Image::FromHbitmap(IntPtr(hBitmap));

			DeleteObject(hBitmap);
			DeleteDC(hdc);

			return bmpImage;
			*/
		}

		static void FillBitmapInfo( BITMAPINFO* bmi, int width, int height, int bpp, int origin )
		{
			assert( bmi && width >= 0 && height >= 0 && (bpp == 8 || bpp == 24 || bpp == 32));

			BITMAPINFOHEADER* bmih = &(bmi->bmiHeader);

			memset( bmih, 0, sizeof(*bmih));
			bmih->biSize = sizeof(BITMAPINFOHEADER);
			bmih->biWidth = width;
			bmih->biHeight = origin ? abs(height) : -abs(height);
			bmih->biPlanes = 1;
			bmih->biBitCount = (unsigned short)bpp;
			bmih->biCompression = BI_RGB;

			if( bpp == 8 )
			{
				RGBQUAD* palette = bmi->bmiColors;
				int i;
				for( i = 0; i < 256; i++ )
				{
					palette[i].rgbBlue = palette[i].rgbGreen = palette[i].rgbRed = (BYTE)i;
					palette[i].rgbReserved = 0;
				}
			}
		}

		property int Width
		{
			int get()
			{
				return image1->width;
			}
		}

		property int Height
		{
			int get()
			{
				return image1->height;
			}
		}

		property int Channels
		{
			int get()
			{
				return image1->nChannels;
			}
		}

		property cvDepth Depth
		{
			cvDepth get()
			{
				return (cvDepth) image1->depth;
			}
		}

		virtual property CvArr* Array
		{
			CvArr* get() override
			{
				pin_ptr<CvArr> intr = imageout;
				return intr;
			}
		}

		virtual property IplImage* Internal
		{
			IplImage* get()
			{
				return (IplImage*) Array;
			}
		}
	};
};