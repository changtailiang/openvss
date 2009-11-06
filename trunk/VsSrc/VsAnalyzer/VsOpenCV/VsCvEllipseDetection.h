#pragma once
#include <time.h>

namespace VsOpenCV
{
	public ref class VsCvEllipseDetection : public VsCvImage
	{
		private:

		String^ vsResult;

		static int slider_pos = 70;
		static int edge_thresh=1;
		// Load the source image1. HighGUI use.
		IplImage *image02, *image04, *color;

		public:

		VsCvEllipseDetection(int in, int out, int w, int h, cvDepth depth, int channels)
			: VsCvImage(in, out, w, h, depth, channels)
		{
		}

		~VsCvEllipseDetection(void)
		{
			IplImage* ptr;
			ptr = image02; cvReleaseImage(&ptr);
			ptr = image04; cvReleaseImage(&ptr);
			ptr = color; cvReleaseImage(&ptr);
		}

		void VsInit()
		{
			// Convert to grayscale
			image02 = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 1);
			image04 = cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 1);			
			color =   cvCreateImage(cvSize(Width, Height), IPL_DEPTH_8U, 3);			   

			// 
			vsResult = "";
		}

		void VsConfiguration(int th)
		{
			slider_pos = th;
		}

		String^ VsResult()
		{
			return vsResult;
		}

		Bitmap^ VsProcess(Bitmap^ srcImage1)
		{
			LoadImage(srcImage1, 1);

			vsResult = "";

			CvMemStorage* stor;
			CvSeq* cont;
			CvBox2D32f* box;
			CvPoint* PointArray;
			CvPoint2D32f* PointArray2D32f;

			cvCvtColor(image1, image02, CV_BGR2GRAY);
			cvCopy(image1, imageout);

			// Create dynamic structure and sequence.
			stor = cvCreateMemStorage(0);
			cont = cvCreateSeq(CV_SEQ_ELTYPE_POINT, sizeof(CvSeq), sizeof(CvPoint) , stor);

			// Run the edge detector on grayscale
			//cvCanny(image02, image02, (float)edge_thresh, (float)edge_thresh*3, 3);

			// Threshold the source image1. This needful for cvFindContours().
			cvThreshold( image02, image02, slider_pos, 255, CV_THRESH_BINARY );

			// Find all contours.
			CvSeq* seq = cont;
			cvFindContours(image02, stor, &seq, sizeof(CvContour), 
							CV_RETR_LIST, CV_CHAIN_APPROX_NONE, cvPoint(0,0));

			// Clear images. IPL use.
			cvZero(image02);
			cvZero(image04);

			// This cycle draw all contours and approximate it by ellipses.
			for(;seq;seq = seq->h_next)
			{   
				int i; // Indicator of cycle.
				int count = seq->total; // This is number point in contour
				CvPoint center;
				CvSize size;
			    
				// Number point must be more than or equal to 6 (for cvFitEllipse_32f).        
				if(count < 20)
					continue;
			    
				// Alloc memory for contour point set.    
				PointArray = (CvPoint*)malloc( count*sizeof(CvPoint) );
				PointArray2D32f= (CvPoint2D32f*)malloc( count*sizeof(CvPoint2D32f) );
			    
				// Alloc memory for ellipse data.
				box = (CvBox2D32f*)malloc(sizeof(CvBox2D32f));
			    
				// Get contour point set.
				cvCvtSeqToArray(seq, PointArray, CV_WHOLE_SEQ);
			    
				// Convert CvPoint set to CvBox2D32f set.
				for(i=0; i<count; i++)
				{
					PointArray2D32f[i].x = (float)PointArray[i].x;
					PointArray2D32f[i].y = (float)PointArray[i].y;
				}
			    
				// Fits ellipse to current contour.
				cvFitEllipse(PointArray2D32f, count, box);
			    
				// Draw current contour.
				cvDrawContours(imageout, seq, CV_RGB(0,255,0), CV_RGB(0,255,0), 0, 1, 8, cvPoint(0,0));
			    
				// Convert ellipse data from float to integer representation.
				center.x = (int)(box->center.x);
				center.y = (int)(box->center.y);
				size.width = (int)(box->size.width*0.5);
				size.height = (int)(box->size.height*0.5);
				box->angle = -box->angle;
			    
				// Draw ellipse.
				if(size.width > 5 && size.height > 5)
				{
					cvEllipse(imageout, center, size,
							  box->angle, 0, 360,
							  CV_RGB(255,0,0), 3, CV_AA, 0);
					vsResult += center.x.ToString() + "," + center.y.ToString() + "," + size.width.ToString() + "," + size.height.ToString() + ";";
				}
			    
				// Free memory.          
				free(PointArray);
				free(PointArray2D32f);
				free(box);
			}

			CvMemStorage* smem = stor;
			cvReleaseMemStorage(&stor);

			return SaveImage(1);
		}
	};
}