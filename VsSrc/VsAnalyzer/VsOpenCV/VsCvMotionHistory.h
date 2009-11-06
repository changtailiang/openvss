#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvMotionHistory : public VsCvImage
	{
		private:

		String^ vsResult;

		// various tracking parameters (in seconds)
		static double MHI_DURATION = 1;
		static double MAX_TIME_DELTA = 0.50;
		static double MIN_TIME_DELTA = 0.05;

		static int N = 2;

		// ring image1 buffer
		int object_size;
		int last;
		int width, height;
		int diff_threshold;

		// process image1;
		IplImage **buf;
		IplImage *mue, *sig, *acc1, *acc2, *dst, *mask, *pyr1;

		bool firstFrame;
		int initCount;
		int initFrame;
		double alpha;
		double percentage;

		IplConvKernel* element;
		int element_shape;

		int max_iters;
		int open_close_pos;
		int erode_dilate_pos;

		int threshold1, threshold2;

		public:

		VsCvMotionHistory(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
		}

		~VsCvMotionHistory(void)
		{
			IplImage* ptr;
			ptr = mue; cvReleaseImage(&ptr);
			ptr = sig; cvReleaseImage(&ptr);
			ptr = acc1; cvReleaseImage(&ptr);
			ptr = acc2; cvReleaseImage(&ptr);
			ptr = mask; cvReleaseImage(&ptr);
			ptr = dst; cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			vsResult = "";

			firstFrame = true;
			initCount=0;
			initFrame=20;
			alpha = 0.05;
			percentage=0;

			element = 0;
			element_shape = CV_SHAPE_ELLIPSE;

			max_iters = 10;
			open_close_pos = 0;
			erode_dilate_pos = 0;
			threshold1 = 5;
			threshold2 = 5;

			int i;
			last = 0;
			diff_threshold = 30;
			width = Width; height = Height;
			CvSize size = cvSize(width, height); // get current frame size
			object_size=0;

			//create a single channel 1 byte image1 (i.e. gray-level image1)
			mue = cvCreateImage( size, IPL_DEPTH_32F, 1 ); cvSetZero(mue);
			sig = cvCreateImage( size, IPL_DEPTH_32F, 1 ); cvSetZero(sig);
			acc1 = cvCreateImage( size, IPL_DEPTH_32F, 1 ); cvSetZero(acc1);
			acc2 = cvCreateImage( size, IPL_DEPTH_32F, 1 ); cvSetZero(acc2);
			dst = cvCreateImage( size, IPL_DEPTH_8U, 3 );
			mask = cvCreateImage( size, IPL_DEPTH_8U, 1 );
			pyr1 = cvCreateImage( cvSize(size.width/2, size.height/2), IPL_DEPTH_8U, 1 );

			// allocate images at the beginning or
			// reallocate them if the frame size is changed
			buf = (IplImage**)malloc(N*sizeof(buf[0]));
			memset( buf, 0, N*sizeof(buf[0]));
			for( i = 0; i < N; i++ ) 
			{
				cvReleaseImage( &buf[i] );
				buf[i] = cvCreateImage( size, IPL_DEPTH_8U, 1 );
				cvZero( buf[i] );
			}
		}

		// callback function for open/close trackbar
		void OpenClose(IplImage *img, int pos)   
		{
			int n = pos - max_iters;
			int an = n > 0 ? n : -n;
			element = cvCreateStructuringElementEx( an*2+1, an*2+1, an, an, element_shape, 0 );
			if( n < 0 )
			{
				cvErode(img,img,element,1);
				cvDilate(img,img,element,1);
			}
			else
			{
				cvDilate(img,img,element,1);
				cvErode(img,img,element,1);
			}
			IplConvKernel* prt = element;
			cvReleaseStructuringElement(&prt);
		}   

		// callback function for erode/dilate trackbar
		void ErodeDilate(IplImage *img, int pos)   
		{
			int n = pos - max_iters;
			int an = n > 0 ? n : -n;
			element = cvCreateStructuringElementEx( an*2+1, an*2+1, an, an, element_shape, 0 );
			if( n < 0 )
			{
				cvErode(img,img,element,1);
			}
			else
			{
				cvDilate(img,img,element,1);
			}
			IplConvKernel* prt = element;
			cvReleaseStructuringElement(&prt);
		}   

		void VsConfiguration(int th1, int th2)
		{
			threshold1 = th1;
			threshold2 = th2;
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1)
		{
			LoadImage(srcImage1, 1);

			vsResult = "";

			cvCopy(image1, imageout);

			double timestamp = (double)clock()/CLOCKS_PER_SEC; // get current time in seconds
			int idx1 = 0, idx2 = 1, idx3=2, idx4=3;
			int k=threshold2;
			alpha = threshold1/100.0; 
			CvSize size = cvSize(width, height); // get current frame size

			cvCvtColor(image1, buf[idx1], CV_RGB2GRAY);

			// down-scale and upscale the image1 to filter out the noise
			cvPyrDown(buf[idx1], pyr1);
			cvPyrUp(pyr1, buf[idx1]);

			// thresholding |current - background| > T
			// motion detection
			// cal threshold
			// |cur-mue| > k*sigma -> (cur-mue)*(cur-mue) > k^2*sigma^2
			// cal (cur-mue)
			cvConvertScale(buf[idx1], acc1);	// convert to float
			cvSub(acc1, mue, acc1);				// (cur-mue)
			cvMul(acc1, acc1, acc1);			// (cur-mue)*(cur-mue)
			
			cvSetZero(acc2);
			cvScaleAdd(sig, cvScalar(k*k), acc2, acc2); // k^2*sigma^2

			cvSetZero(buf[idx2]);
			cvCmp(acc1, acc2, buf[idx2], CV_CMP_GT);

			// erosion & dilation operation
			// delete very small noise
			ErodeDilate(buf[idx2], 9);
			ErodeDilate(buf[idx2], 11);

			cvCopy(buf[idx2], mask);
			ErodeDilate(mask, 15);

			// compute motion percentage
			percentage = (double)cvCountNonZero(buf[idx2])/(image1->width*image1->height)*100;

			if(percentage > 75)
			{
				initCount = 0;
				cvSetZero(mue);
				cvSetZero(sig);
			}
			if(percentage > 3)
				vsResult = percentage.ToString();
			else vsResult = "";
			//printf("Motion Percentage = %lf\n", percentage);

			// copy result
			cvZero(dst);
			cvCopy(image1, dst, buf[idx2]);
			cvCopy(dst, imageout);

			//cvShowImage("Motion", dst);

			// selectivity's area
			cvNot(mask, mask);

			// running average with selectivity
			if(initCount<initFrame)
			{	
				// mue
				cvRunningAvg(buf[idx1], mue, alpha, NULL);

				// sigma
				// sigma^2 = alpha*(cur-mue)^2 + (1-alpha)*sigma^2
				cvRunningAvg(acc1, sig, alpha, NULL); //alpha*(cur-mue)^2 + (1-alpha)*sigma^2

				if(percentage<0.05) initCount++;
			}
			else
			{
				// mue
				cvRunningAvg(buf[idx1], mue, alpha, mask);

				// sigma
				// sigma^2 = alpha*(cur-mue)^2 + (1-alpha)*sigma^2
				// cal (cur-mue)
				cvRunningAvg(acc1, sig, alpha, mask); //alpha*(cur-mue)^2 + (1-alpha)*sigma^2
			}

			// background model (mue, sigma)
			cvConvertScale(mue, buf[idx2], 1.0, 0.0);
			//cvShowImage("Mue", buf[idx2]);

 			cvConvertScale(sig, buf[idx2], 1.0, 0.0);
			//cvShowImage("Sigma", buf[idx2]);

			return SaveImage(1);
		}
	};
}