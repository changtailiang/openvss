#pragma once
#include <time.h>


namespace VsOpenCV
{
	public ref class VsCvEdgeDetection : public VsCvImage
	{
		private:

		String^ vsResult; 
		
		static int edge_thresh1 = 1;
		static int edge_thresh2 = 1;

		IplImage *cedge, *gray, *edge;

		public:

		VsCvEdgeDetection(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
		}

		~VsCvEdgeDetection(void)
		{
			IplImage* ptr;
			ptr = gray; cvReleaseImage(&ptr);
			ptr = edge; cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			// Convert to grayscale
			cedge = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 3);
			gray = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 1);
			edge = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 1);

			// vsResult
			vsResult = "";
		}

		void VsConfiguration(int th1, int th2)
		{
			edge_thresh1 = th1;
			edge_thresh2 = th2;
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1)
		{
			LoadImage(srcImage1, 1);

			vsResult = "";

			cvCvtColor(image1, gray, CV_BGR2GRAY);

			cvSmooth( gray, edge, CV_BLUR, 3, 3, 0, 0 );
			cvNot( gray, edge );

			// Run the edge detector on grayscale
			cvCanny(gray, edge, (float)edge_thresh1, (float)edge_thresh2, 3);
		  
			// copy edge points
			cvZero(imageout);
			cvCopy(image1, imageout, edge);

			return SaveImage(1);
		}
	};
}