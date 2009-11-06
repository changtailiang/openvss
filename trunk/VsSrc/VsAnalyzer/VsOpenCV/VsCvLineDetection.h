#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvLineDetection : public VsCvImage
	{
		private:
		int edge_thresh1, edge_thresh2, edge_thresh3;

		IplImage *cedge, *gray, *edge;
		CvMemStorage* storage;
		CvSeq* lines;

		String^ vsResult;

		public:

		VsCvLineDetection(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
		}

		~VsCvLineDetection(void)
		{
			IplImage* ptr;
			ptr = gray; cvReleaseImage(&ptr);
			ptr = edge; cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			// Convert to grayscale
			cedge = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 3);
			gray =  cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 1);
			edge =  cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 1);			

			storage = cvCreateMemStorage(0);
			lines = 0;
			edge_thresh1 = 50; edge_thresh2 = 200; edge_thresh3 = 100;

			// 
			vsResult = "";
		}

		void VsConfiguration(int th1, int th2, int th3)
		{
			edge_thresh1 = th1;
			edge_thresh2 = th2;
			edge_thresh3 = th3;
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
			cvCopy(image1, imageout);

			cvCanny(gray, edge, edge_thresh1, edge_thresh2, 3 );
		
			lines = cvHoughLines2(edge, storage, CV_HOUGH_STANDARD, 1, CV_PI/180, edge_thresh3, 0, 0 );

			for(int i = 0; i < MIN(lines->total,100); i++ )
			{
				float* line = (float*)cvGetSeqElem(lines,i);
				float rho = line[0];
				float theta = line[1];
				CvPoint pt1, pt2;
				double a = cos(theta), b = sin(theta);
				double x0 = a*rho, y0 = b*rho;
				pt1.x = cvRound(x0 + 1000*(-b));
				pt1.y = cvRound(y0 + 1000*(a));
				pt2.x = cvRound(x0 - 1000*(-b));
				pt2.y = cvRound(y0 - 1000*(a));
				cvLine(imageout, pt1, pt2, CV_RGB(255,0,0), 3, CV_AA, 0);

				vsResult += pt1.x.ToString() + "," + pt1.y.ToString() + "," + pt2.x.ToString() + "," + pt2.y.ToString() + ";";
			}

			return SaveImage(1);
		}
	};
}